using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crosscutting.MietmaterialdatenbankKlassen;
using Server.L2.Mietmaterialdatenbankzugriffsschicht.Contracts;

namespace Server.L2.Mietmaterialdatenbankzugriffsschicht
{
    public class Lagerbestand_Verwaltungsklasse : IDisposable, ILagerbestand_Verwaltungsklasse
    {
        // Eine Instanz des Framework-Kontextes pro Manager-Instanz
        MietmaschinendatenbankModelContainer modell = null;

        public Lagerbestand_Verwaltungsklasse()
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
        public Lagerbestand_Verwaltungsklasse(bool LazyLoading = false)
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
        public Lagerbestand GetLagerbestandById(int Lagerbestand_ID)
        {
            var abfrage = from Lager in modell.LagerbestandSatz where Lager.Lagerbestand_ID == Lagerbestand_ID select Lager;
            return abfrage.SingleOrDefault();
        }

        /// <summary>
        /// Laden eines Flugs
        /// </summary>
        public List<Lagerbestand> GetAllLagerbestandlisten()
        {
            var abfrage = from Lager in modell.LagerbestandSatz .Include("Maschinenart") select Lager;
            return abfrage.ToList();
        }

        /// <summary>
        /// Laden eines Flugs
        /// </summary>
        public Lagerbestand GetLagerbestandByMaschinenartenId(int Maschinenart_ID)
        {
            var abfrage = from Lager in modell.LagerbestandSatz where Lager.Maschinenart_ID == Maschinenart_ID select Lager;
            return abfrage.SingleOrDefault();
        }

        /// <summary>
        /// Laden eines Flugs
        /// </summary>
        public List<Lagerbestand> GetLagerbestandVorhanden()
        {
            var abfrage = from Lager in modell.LagerbestandSatz where Lager.Lagermenge > 0 select Lager;
            return abfrage.ToList();
        }

        /// <summary>
        /// Laden eines Flugs
        /// </summary>
        public List<Lagerbestand> GetLagerbestandLeer()
        {
            var abfrage = from Lager in modell.LagerbestandSatz where Lager.Lagermenge == 0 select Lager;
            return abfrage.ToList();
        }

        /// <summary>
        /// Laden eines Flugs
        /// </summary>
        public List<Lagerbestand> GetLagerbestandNichtsVermietet()
        {
            var abfrage = from Lager in modell.LagerbestandSatz where Lager.VermietetMenge == 0 select Lager;
            return abfrage.ToList();
        }

        /// <summary>
        /// Laden eines Flugs
        /// </summary>
        public List<Lagerbestand> GetLagerbestandVermietet()
        {
            var abfrage = from Lager in modell.LagerbestandSatz where Lager.VermietetMenge > 0 select Lager;
            return abfrage.ToList();
        }

        /// <summary>
        /// Laden eines Flugs
        /// </summary>
        public List<Lagerbestand> GetLagerbestandNichtImPool()
        {
            var abfrage = from Lager in modell.LagerbestandSatz where Lager.Gesamtanzahl == 0 select Lager;
            return abfrage.ToList();
        }

        /// <summary>
        /// Füge einen Passagier zu einem Flug hinzu
        /// </summary>
        public Lagerbestand NuerLagerplatz(int MaschinenartID)
        {
            try
            {
                Lagerbestand DiesesLager = new Lagerbestand();
                DiesesLager.Maschinenart_ID = MaschinenartID;

                modell.LagerbestandSatz.AddObject(DiesesLager);
                try
                {
                    modell.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(DiesesLager.ToString() + " | " + ex.Message.ToString());

                }

                return DiesesLager;
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
        public List<Lagerbestand> SaveLagerSet(List<Lagerbestand> LagerSet, out string Statistik)
        {
            //https://blogs.msdn.microsoft.com/diego/2010/10/05/self-tracking-entities-applychanges-and-duplicate-entities/
            // Änderungen für jeden einzelnen Passagier übernehmen


            try
            {
                foreach (Lagerbestand p in LagerSet)
                {
                    if (p.ChangeTracker.State == ObjectState.Modified)
                    {
                        var abfrage = from Lager in modell.LagerbestandSatz.Include("Maschinenart") select Lager;
                        Lagerbestand current = abfrage.Where(o => o.Lagerbestand_ID == p.Lagerbestand_ID).First();

                        Lagerbestand.Clone(p, current);

                        modell.LagerbestandSatz.ApplyChanges(current);

                        current.ChangeTracker.State = ObjectState.Unchanged;
                    }
                    else if (p.ChangeTracker.State == ObjectState.Deleted)
                    {
                        var abfrage = from Lager in modell.LagerbestandSatz.Include("Maschinenart") select Lager;
                        Lagerbestand current = abfrage.Where(o => o.Lagerbestand_ID == p.Lagerbestand_ID).First();
                        current.MarkAsDeleted();
                        modell.LagerbestandSatz.DeleteObject(current);
                    }
                    else if (p.ChangeTracker.State == ObjectState.Added)
                    {
                        modell.LagerbestandSatz.ApplyChanges(p);
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
            List<Lagerbestand> NeueLager = LagerSet.Where(f => f.ChangeTracker.State == ObjectState.Added).ToList();

            // Änderungen speichern
            modell.SaveChanges();

            modell.Refresh(System.Data.Objects.RefreshMode.StoreWins, modell.LagerbestandSatz);
            // Statistik der Änderungen zurückgeben
            return NeueLager;
        }
    }
}
