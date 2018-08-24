using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crosscutting.Logging.Contracts;
using CrossCutting.Mietmaschinendatenbank_DataClasses;
using Server.L2.Mietmaterialdatenbankzugriffsschicht.Contracts;

namespace Server.L2.Mietmaterialdatenbankzugriffsschicht
{
    public class Vermitungs_Verwaltungsklasse : IDisposable, IVermitungs_Verwaltungsklasse
    {
        // Eine Instanz des Framework-Kontextes pro Manager-Instanz
        MietmaschinendatenbankModelContainer modell = null;

        public Vermitungs_Verwaltungsklasse()
        {
            try
            {
                modell = MietmaschinendatenbankModelContainerFactory.MietmaschinendatenbankModelContainerFactoryGenerator();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                Console.ReadLine();
            }
        }   

        /// <summary>
        /// Konstruktor
        /// </summary>
        public Vermitungs_Verwaltungsklasse(bool LazyLoading = false)
            :this()
        {
            modell.ContextOptions.LazyLoadingEnabled = LazyLoading;
        }

        /// <summary>
        /// Objekt vernichten
        /// </summary>
        public void Dispose()
        {
            modell.Dispose();
        }

        /// <summary>
        /// Laden eines Flugs
        /// </summary>
        public Vermietung GetVermietungById(int VermietungslisteID)
        {
            var abfrage = from Vermietung in modell.VermietungslisteSatz where Vermietung.Vermiet_ID == VermietungslisteID select Vermietung;
            return abfrage.SingleOrDefault();
        }

        /// <summary>
        /// Laden eines Flugs
        /// </summary>
        public List<Vermietung> GetAllVermietungen()
        {
            var abfrage = from Vermietung in modell.VermietungslisteSatz .Include("Maschinenart") .Include("Kunde") select Vermietung;
            return abfrage.ToList();
        }

        /// <summary>
        /// Laden Vermietungslisten mit bestimmtem Datum
        /// </summary>
        public List<Vermietung> GetVermietungenInZeitraum(DateTime Vermitbegin, DateTime Vermitende)
        {
            // Grundabfrage
            var abfrage = from Vermietung in modell.VermietungslisteSatz select Vermietung;
            // Abfrage ggf. erweitern
            if (Vermitbegin != null) abfrage = from Vermietung in abfrage where Vermietung.Vermietbegin >= Vermitbegin select Vermietung;
            if (Vermitende != null) abfrage = from Vermietung in abfrage where Vermietung.Vermietende <= Vermitende select Vermietung;

            return abfrage.ToList();
        }

        /// <summary>
        /// Laden Vermietungslisten mit bestimmtem Datum
        /// </summary>
        public List<Vermietung> GetVermietungenAnKunde(int Kunden_ID)
        {
            // Grundabfrage
            var abfrage = from Vermietung in modell.VermietungslisteSatz select Vermietung;
            // Abfrage ggf. erweitern
            if (Kunden_ID >= 0) abfrage = from Vermietung in abfrage where Vermietung.Kunden_ID == Kunden_ID select Vermietung;

            return abfrage.ToList();
        }

        /// <summary>
        /// Füge einen Passagier zu einem Flug hinzu
        /// </summary>
        public Vermietung NeueVermietung(DateTime Vermitbegin, DateTime Vermitende)
        {
            try
            {
                Vermietung DieseVermietung = new Vermietung();
                DieseVermietung.Vermietbegin = Vermitbegin;
                DieseVermietung.Vermietende = Vermitende;
                DieseVermietung.Gesamtpreis = 0;

                modell.VermietungslisteSatz.AddObject(DieseVermietung);
                try
                {
                    modell.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(DieseVermietung.ToString() + " | " + ex.Message.ToString());
                    return null;
                }

                return DieseVermietung;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return null;
            }
        }

        /// <summary>
        /// Änderungen an einer Liste von Passagieren speichern
        /// Die neu hinzugefügten Passagiere muss die Routine wieder zurückgeben, da die IDs für die 
        /// neuen Passagiere erst beim Speichern von der Datenbank vergeben werden
        /// </summary>
        public List<Vermietung> SaveVermitungenSet(List<Vermietung> VermietungsDatensatz, out string Statistik)
        {
            //https://blogs.msdn.microsoft.com/diego/2010/10/05/self-tracking-entities-applychanges-and-duplicate-entities/
            // Änderungen für jeden einzelnen Passagier übernehmen


            try
            {
                foreach (Vermietung p in VermietungsDatensatz)
                {
                    if (p.ChangeTracker.State == ObjectState.Modified)
                    {
                        var abfrage = from Vermietung in modell.VermietungslisteSatz.Include("Maschinenart").Include("Kunde") select Vermietung;
                        Vermietung current = abfrage.Where(o => o.Vermiet_ID == p.Vermiet_ID).First();

                        CrossCutting.Mietmaschinendatenbank_DataClasses.Vermietung.Clone(p, current);

                        modell.VermietungslisteSatz.ApplyChanges(current);

                        current.ChangeTracker.State = ObjectState.Unchanged;
                    }
                    else if (p.ChangeTracker.State == ObjectState.Deleted)
                    {
                        var abfrage = from Vermietung in modell.VermietungslisteSatz.Include("Maschinenart").Include("Kunde") select Vermietung;
                        Vermietung current = abfrage.Where(o => o.Vermiet_ID == p.Vermiet_ID).First();
                        current.MarkAsDeleted();
                        modell.VermietungslisteSatz.DeleteObject(current);
                    }
                    else if (p.ChangeTracker.State == ObjectState.Added)
                    {
                        modell.VermietungslisteSatz.ApplyChanges(p);
                    }
                }
            }
            catch
            {
                Console.Write("Context is up to date");
            }


            // Statistik der Änderungen zusammenstellen
            Statistik = "";
            Statistik += "Geändert: " + modell.ObjectStateManager.GetObjectStateEntries(System.Data.EntityState.Modified).Count();
            Statistik += " Neu: " + modell.ObjectStateManager.GetObjectStateEntries(System.Data.EntityState.Added).Count();
            Statistik += " Gelöscht: " + modell.ObjectStateManager.GetObjectStateEntries(System.Data.EntityState.Deleted).Count();

            // Neue Datensätze merken, da diese nach Speichern zurückgegeben werden müssen (haben dann erst ihre IDs!)
            List<Vermietung> NeueVermitungen = VermietungsDatensatz.Where(f => f.ChangeTracker.State == ObjectState.Added).ToList();

            // Änderungen speichern
            modell.SaveChanges();

            modell.Refresh(System.Data.Objects.RefreshMode.StoreWins, modell.VermietungslisteSatz);
            // Statistik der Änderungen zurückgeben
            return NeueVermitungen;
        }
    }    
}
