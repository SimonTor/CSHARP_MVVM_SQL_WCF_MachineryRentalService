using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossCutting.Mietmaschinendatenbank_DataClasses;
using Server.L2.Mietmaterialdatenbankzugriffsschicht.Contracts;

namespace Server.L2.Mietmaterialdatenbankzugriffsschicht
{
    public class Maschinenkauf_Verwaltungsklasse : IDisposable, IMaschinenkauf_Verwaltungsklasse
    {
        // Eine Instanz des Framework-Kontextes pro Manager-Instanz
        MietmaschinendatenbankModelContainer modell = null;

        public Maschinenkauf_Verwaltungsklasse()
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
        public Maschinenkauf_Verwaltungsklasse(bool LazyLoading = false)
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
        public Maschinenkauf GetMaschinenkaufById(int Maschinenkauf_ID)
        {
            var abfrage = from Maschinenkauf in modell.MaschinenkauflisteSatz where Maschinenkauf.Maschinenkauf_ID == Maschinenkauf_ID select Maschinenkauf;
            return abfrage.SingleOrDefault();
        }

        /// <summary>
        /// Laden eines Flugs
        /// </summary>
        public List<Maschinenkauf> GetAllMaschinenkaufe()
        {
            var abfrage = from Maschinenkauf in modell.MaschinenkauflisteSatz .Include("Maschinenartenliste") select Maschinenkauf;
            return abfrage.ToList();
        }

        /// <summary>
        /// Laden eines Flugs
        /// </summary>
        public List<Maschinenkauf> GetAllMaschinenkaufeByMaschinenart(int Maschinenart_ID)
        {
            var abfrage = from Maschinenkauf in modell.MaschinenkauflisteSatz where Maschinenkauf.Maschinenart_ID == Maschinenart_ID select Maschinenkauf;
            return abfrage.ToList();
        }

        /// <summary>
        /// Laden eines Flugs
        /// </summary>
        public List<Maschinenkauf> GetAllMaschinenkaufeByDate(DateTime Kaufdatum)
        {
            var abfrage = from Maschinenkauf in modell.MaschinenkauflisteSatz where Maschinenkauf.Kaufdatum == Kaufdatum select Maschinenkauf;
            return abfrage.ToList();
        }

        /// <summary>
        /// Laden Vermietungslisten mit bestimmtem Datum
        /// </summary>
        public List<Maschinenkauf> GetAllMaschinenkaufeInZeitraum(DateTime Vermitbegin, DateTime Vermitende)
        {
            // Grundabfrage
            var abfrage = from Maschinenkauf in modell.MaschinenkauflisteSatz select Maschinenkauf;
            // Abfrage ggf. erweitern
            if (Vermitbegin != null) abfrage = from Vermietung in abfrage where Vermietung.Kaufdatum >= Vermitbegin select Vermietung;
            if (Vermitende != null) abfrage = from Vermietung in abfrage where Vermietung.Kaufdatum <= Vermitende select Vermietung;

            return abfrage.ToList();
        }

        /// <summary>
        /// Füge einen Passagier zu einem Flug hinzu
        /// </summary>
        public Maschinenkauf NeuMaschinenkauf(int MaschinenartID, int anz, int Einzelpreis, DateTime Kaufdatum)
        {
            try
            {
                Maschinenkauf kauf = new Maschinenkauf();
                kauf.Maschinenart_ID = MaschinenartID;
                kauf.Anzahl = anz;
                kauf.Einzelpreis = Einzelpreis;
                kauf.Rechnungspreis = anz * Einzelpreis;
                kauf.Kaufdatum = Kaufdatum;

                modell.MaschinenkauflisteSatz.AddObject(kauf);
                try
                {
                    modell.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(kauf.ToString() + " | " + ex.Message.ToString());
                    return null;
                }

                return kauf;
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
        public Lagerbestand AddGekaufteMaschineZuLager(int MaschinenartID, int Anzahl)
        {
            try
            {
                Lagerbestand lager = modell.LagerbestandSatz.Where(f => f.Maschinenart_ID == MaschinenartID).SingleOrDefault();
                lager.Gesamtanzahl += Anzahl;
                lager.Lagermenge += Anzahl;

                modell.SaveChanges();
                return lager;
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
        public Maschinenart AddGekaufteMaschineZuMaschinenart(int MaschinenartID, int rechnungspreis)
        {
            try
            {
                Maschinenart art = modell.MaschinenartenlisteSatz.Where(f => f.Maschinenart_ID == MaschinenartID).SingleOrDefault();
                Lagerbestand lager = modell.LagerbestandSatz.Where(f => f.Maschinenart_ID == MaschinenartID).SingleOrDefault(); ;
                art.Gesamtkosten += rechnungspreis;
                art.Tagessatz = art.Gesamtkosten / lager.Gesamtanzahl * 0.1;
                art.Rentabilität = ((art.Gesamteinnahmen / art.Gesamtkosten)-1)*100;

                modell.SaveChanges();
                return art;
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
        public List<Maschinenkauf> SaveMaschinenkaufe(List<Maschinenkauf> Maschinenkaufset, out string Statistik)
        {
            //https://blogs.msdn.microsoft.com/diego/2010/10/05/self-tracking-entities-applychanges-and-duplicate-entities/
            // Änderungen für jeden einzelnen Passagier übernehmen


            try
            {
                foreach (Maschinenkauf p in Maschinenkaufset)
                {
                    if (p.ChangeTracker.State == ObjectState.Modified)
                    {
                        var abfrage = from Maschinenkauf in modell.MaschinenkauflisteSatz.Include("Maschinenartenliste") select Maschinenkauf;
                        Maschinenkauf current = abfrage.Where(o => o.Maschinenkauf_ID == p.Maschinenkauf_ID).First();

                        CrossCutting.Mietmaschinendatenbank_DataClasses.Maschinenkauf.Clone(p, current);

                        modell.MaschinenkauflisteSatz.ApplyChanges(current);

                        current.ChangeTracker.State = ObjectState.Unchanged;
                    }
                    else if (p.ChangeTracker.State == ObjectState.Deleted)
                    {
                        var abfrage = from Maschinenkauf in modell.MaschinenkauflisteSatz.Include("Maschinenartenliste") select Maschinenkauf;
                        Maschinenkauf current = abfrage.Where(o => o.Maschinenkauf_ID == p.Maschinenkauf_ID).First();
                        current.MarkAsDeleted();
                        modell.MaschinenkauflisteSatz.DeleteObject(current);
                    }
                    else if (p.ChangeTracker.State == ObjectState.Added)
                    {
                        modell.MaschinenkauflisteSatz.ApplyChanges(p);
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
            List<Maschinenkauf> NeueMaschinenkaufe = Maschinenkaufset.Where(f => f.ChangeTracker.State == ObjectState.Added).ToList();

            // Änderungen speichern
            modell.SaveChanges();

            modell.Refresh(System.Data.Objects.RefreshMode.StoreWins, modell.MaschinenkauflisteSatz);
            // Statistik der Änderungen zurückgeben
            return NeueMaschinenkaufe;
        }
    }
}
