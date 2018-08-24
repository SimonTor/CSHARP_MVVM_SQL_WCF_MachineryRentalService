using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossCutting.Mietmaschinendatenbank_DataClasses;
using Server.L2.Mietmaterialdatenbankzugriffsschicht.Contracts;

namespace Server.L2.Mietmaterialdatenbankzugriffsschicht
{
    public class Kunden_Verwaltungsklasse : IDisposable, IKunden_Verwaltungsklasse
    {
        // Eine Instanz des Framework-Kontextes pro Manager-Instanz
        MietmaschinendatenbankModelContainer modell = null;

        public Kunden_Verwaltungsklasse()
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
        public Kunden_Verwaltungsklasse(bool LazyLoading = false)
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
        public Kunde GetKundeById(int Kunden_ID)
        {
            var abfrage = from Kunde in modell.KundenlisteSatz where Kunde.Kunden_ID == Kunden_ID select Kunde;
            return abfrage.SingleOrDefault();
        }

        /// <summary>
        /// Laden eines Flugs
        /// </summary>
        public List<Kunde> GetAllKunden()
        {
            var abfrage = from Kunde in modell.KundenlisteSatz .Include("Vermietung") select Kunde;

            /*
            Explizit
            // Load the orders for the customer explicitly.
            if (!contact.SalesOrderHeaders.IsLoaded)
            {
              contact.SalesOrderHeaders.Load();
            }
            */

            return abfrage.ToList();
        }

            /// <summary>
            /// Füge einen Passagier zu einem Flug hinzu
            /// </summary>
        public Kunde NuerKunde(String Kundenname)
        {
            try
            {
                Kunde DieserKunde = new Kunde();
                DieserKunde.Kundenname = Kundenname;
                DieserKunde.Kundengesamtumsatz = 0;

                modell.KundenlisteSatz.AddObject(DieserKunde);
                try
                {
                    modell.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(DieserKunde.ToString() + " | " + ex.Message.ToString());
                }

                return DieserKunde;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return null;
            }
        }

        /// <summary>
        /// Füge einen Passagier zu einem Flug hinzu
        /// </summary>
        public Vermietung AddKundeZuVermitung(int KundenID, int VermitID)
        {
            try
            {
                Vermietung dieseVermietung = modell.VermietungslisteSatz.Where(f => f.Vermiet_ID == VermitID).SingleOrDefault();
                Kunde kunde = GetKundeById(KundenID);
                dieseVermietung.Kunde.Kunden_ID = KundenID;

                modell.SaveChanges();
                return dieseVermietung;
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
        public List<Kunde> SaveKundenSet(List<Kunde> KundenSet, out string Statistik)
        {
            //https://blogs.msdn.microsoft.com/diego/2010/10/05/self-tracking-entities-applychanges-and-duplicate-entities/
            // Änderungen für jeden einzelnen Passagier übernehmen


            try
            {
                foreach (Kunde p in KundenSet)
                {
                    if (p.ChangeTracker.State == ObjectState.Modified)
                    {
                        var abfrage = from Kundendaten in modell.KundenlisteSatz select Kundendaten;
                        Kunde current = abfrage.Where(o => o.Kunden_ID == p.Kunden_ID).First();

                        Kunde.Clone(p, current);

                        modell.KundenlisteSatz.ApplyChanges(current);

                        current.ChangeTracker.State = ObjectState.Unchanged;
                    }
                    else if (p.ChangeTracker.State == ObjectState.Deleted)
                    {
                        var abfrage = from Kundendaten in modell.KundenlisteSatz select Kundendaten;
                        Kunde current = abfrage.Where(o => o.Kunden_ID == p.Kunden_ID).First();
                        current.MarkAsDeleted();
                        modell.KundenlisteSatz.DeleteObject(current);
                    }
                    else if (p.ChangeTracker.State == ObjectState.Added)
                    {
                        modell.KundenlisteSatz.ApplyChanges(p);
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
            List<Kunde> NeueKunden = KundenSet.Where(f => f.ChangeTracker.State == ObjectState.Added).ToList();

            // Änderungen speichern
            modell.SaveChanges();

            modell.Refresh(System.Data.Objects.RefreshMode.StoreWins, modell.KundenlisteSatz);
            // Statistik der Änderungen zurückgeben
            return NeueKunden;
        }
    }
}
