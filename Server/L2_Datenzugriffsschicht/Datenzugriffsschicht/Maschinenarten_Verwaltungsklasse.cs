using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossCutting.Mietmaschinendatenbank_DataClasses;
using Server.L2.Mietmaterialdatenbankzugriffsschicht.Contracts;

namespace Server.L2.Mietmaterialdatenbankzugriffsschicht
{
    public class Maschinenarten_Verwaltungsklasse : IDisposable, IMaschinenarten_Verwaltungsklasse
    {
        // Eine Instanz des Framework-Kontextes pro Manager-Instanz
        MietmaschinendatenbankModelContainer modell = null;

        public Maschinenarten_Verwaltungsklasse()
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
        public Maschinenarten_Verwaltungsklasse(bool LazyLoading = false)
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
        public Maschinenart GetMaschinenarteById(int MaschinenartenlistenID)
        {
            var abfrage = from Maschinenart in modell.MaschinenartenlisteSatz where Maschinenart.Maschinenart_ID == MaschinenartenlistenID select Maschinenart;
            return abfrage.SingleOrDefault();
        }

        /// <summary>
        /// Laden eines Flugs
        /// </summary>
        public List<Maschinenart> GetAllMaschinenarten()
        {
            var abfrage = from Maschinenart in modell.MaschinenartenlisteSatz select Maschinenart;
            return abfrage.ToList();
        }

        /// <summary>
        /// Laden eines Flugs
        /// </summary>
        public List<Maschinenart> GetAllMaschinenartenIstRentabel()
        {
            var abfrage = from Maschinenart in modell.MaschinenartenlisteSatz where Maschinenart.Rentabilität > 0 select Maschinenart;
            return abfrage.ToList();
        }

        /// <summary>
        /// Laden eines Flugs
        /// </summary>
        public List<Maschinenart> GetAllMaschinenartenIstUnrentabel()
        {
            var abfrage = from Maschinenart in modell.MaschinenartenlisteSatz where Maschinenart.Rentabilität <=0 select Maschinenart;
            return abfrage.ToList();
        }

        /// <summary>
        /// Füge einen Passagier zu einem Flug hinzu
        /// </summary>
        public Maschinenart NeueMaschinenart(string Maschinenartbezeichnung)
        {
            try
            {
                Maschinenart DieserMaschinenart = new Maschinenart();
                DieserMaschinenart.Maschinenartbezeichnung = Maschinenartbezeichnung;
                DieserMaschinenart.Gesamtkosten = 0;
                DieserMaschinenart.Gesamteinnahmen = 0;
                DieserMaschinenart.Vermietfaktor = 0;
                DieserMaschinenart.Tagessatz = 0;
                DieserMaschinenart.Rentabilität = 0;

                modell.MaschinenartenlisteSatz.AddObject(DieserMaschinenart);
                try
                {
                    modell.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(DieserMaschinenart.ToString() + " | " + ex.Message.ToString());

                }

                return DieserMaschinenart;
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
        public List<Maschinenart> SaveMaschinenartSet(List<Maschinenart> MaschinenartSet, out string Statistik)
        {
            //https://blogs.msdn.microsoft.com/diego/2010/10/05/self-tracking-entities-applychanges-and-duplicate-entities/
            // Änderungen für jeden einzelnen Passagier übernehmen


            try
            {
                foreach (Maschinenart p in MaschinenartSet)
                {
                    if (p.ChangeTracker.State == ObjectState.Modified)
                    {
                        //var abfrage = from Maschinenart in modell.MaschinenartenlisteSatz.Include("Maschinenkaufliste").Include("Vermietung").Include("Lagerbestand") select Maschinenart;
                        var abfrage = from Maschinenart in modell.MaschinenartenlisteSatz select Maschinenart;
                        Maschinenart current = abfrage.Where(o => o.Maschinenart_ID == p.Maschinenart_ID).First();

                        CrossCutting.Mietmaschinendatenbank_DataClasses.Maschinenart.Clone(p, current);

                        modell.MaschinenartenlisteSatz.ApplyChanges(current);

                        current.ChangeTracker.State = ObjectState.Unchanged;
                    }
                    else if (p.ChangeTracker.State == ObjectState.Deleted)
                    {
                        var abfrage = from Maschinenart in modell.MaschinenartenlisteSatz.Include("Maschinenkaufliste").Include("Vermietung").Include("Lagerbestand") select Maschinenart;
                        Maschinenart current = abfrage.Where(o => o.Maschinenart_ID == p.Maschinenart_ID).First();
                        current.MarkAsDeleted();
                        modell.MaschinenartenlisteSatz.DeleteObject(current);
                    }
                    else if (p.ChangeTracker.State == ObjectState.Added)
                    {
                        modell.MaschinenartenlisteSatz.ApplyChanges(p);
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
            List<Maschinenart> NeueMaschinenart = MaschinenartSet.Where(f => f.ChangeTracker.State == ObjectState.Added).ToList();

            // Änderungen speichern
            modell.SaveChanges();

            modell.Refresh(System.Data.Objects.RefreshMode.StoreWins, modell.MaschinenartenlisteSatz);
            // Statistik der Änderungen zurückgeben
            return NeueMaschinenart;
        }

        /// <summary>
        /// Füge einen Passagier zu einem Flug hinzu
        /// </summary>
        public Vermietung AddMaschinenartZuVermitung(int MaschinenartID, int VermitID)
        {
            try
            {
                Vermietung dieseVermietung = modell.VermietungslisteSatz.Where(f => f.Vermiet_ID == VermitID).SingleOrDefault();
                Maschinenart maschine = GetMaschinenarteById(MaschinenartID);
                dieseVermietung.Maschinenart.Add(maschine);

                modell.SaveChanges();
                return dieseVermietung;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return null;
            }
        }
    }
}
