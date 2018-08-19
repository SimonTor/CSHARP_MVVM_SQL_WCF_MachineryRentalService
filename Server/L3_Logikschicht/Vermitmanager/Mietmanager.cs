using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crosscutting.Logging.Contracts;
using Crosscutting.MietmaterialdatenbankKlassen;
using Server.L2.Mietmaterialdatenbankzugriffsschicht.Contracts;
using Server.L3.Logikschicht.Contracts;



namespace Server.L3.Logikschicht
{
    public class Mietmanager : IDisposable, IMietmanager
    {
        public IKunden_Verwaltungsklasse Kunden_Verwaltungsklasse { get; set; }
        public ILagerbestand_Verwaltungsklasse Lagerbestand_Verwaltungsklasse { get; set; }
        public IMaschinenarten_Verwaltungsklasse Maschinenarten_Verwaltungsklasse { get; set; }
        public IMaschinenkauf_Verwaltungsklasse Maschinenkauf_Verwaltungsklasse { get; set; }
        public IVermitungs_Verwaltungsklasse Vermitungs_Verwaltungsklasse { get; set; }
        public ILogger Logger { get; set; }

        public Mietmanager(IKunden_Verwaltungsklasse kunden_Verwaltungsklasse,
                           ILagerbestand_Verwaltungsklasse lagerbestand_Verwaltungsklasse,
                           IMaschinenarten_Verwaltungsklasse maschinenarten_Verwaltungsklasse,
                           IMaschinenkauf_Verwaltungsklasse maschinenkauf_Verwaltungsklasse,
                           IVermitungs_Verwaltungsklasse vermitungs_Verwaltungsklasse,
                           ILogger logger)
        {
            Kunden_Verwaltungsklasse = kunden_Verwaltungsklasse;
            Lagerbestand_Verwaltungsklasse = lagerbestand_Verwaltungsklasse;
            Maschinenarten_Verwaltungsklasse = maschinenarten_Verwaltungsklasse;
            Maschinenkauf_Verwaltungsklasse = maschinenkauf_Verwaltungsklasse;
            Vermitungs_Verwaltungsklasse = vermitungs_Verwaltungsklasse;
            Logger = logger;
        }

        public void Dispose()
        {
            Kunden_Verwaltungsklasse.Dispose();
            Lagerbestand_Verwaltungsklasse.Dispose();
            Maschinenarten_Verwaltungsklasse.Dispose();
            Maschinenkauf_Verwaltungsklasse.Dispose();
            Vermitungs_Verwaltungsklasse.Dispose();
        }

        ///-------------------------------------------------------------------------------------
        ///-------------------------------------------------------------------------------------
        ///-------------------------------------------------------------------------------------
        /// <summary>
        /// Laden eines Flugs
        /// </summary>
        public Kunde GetKundeById(int Kunden_ID)
        {
            return Kunden_Verwaltungsklasse.GetKundeById(Kunden_ID);
        }

        /// <summary>
        /// Laden eines Flugs
        /// </summary>
        public List<Kunde> GetAllKunden()
        {
            return Kunden_Verwaltungsklasse.GetAllKunden();
        }

        /// <summary>
        /// Laden eines Flugs
        /// </summary>
        public List<Kunde> SaveKundenSet(List<Kunde> KundenSet, out string Statistik)
        {
            return Kunden_Verwaltungsklasse.SaveKundenSet(KundenSet, out Statistik);
        }

        ///-------------------------------------------------------------------------------------
        ///-------------------------------------------------------------------------------------
        ///-------------------------------------------------------------------------------------
        /// 
        /// <summary>
        /// Laden eines Flugs
        /// </summary>
        public Lagerbestand GetLagerbestandById(int Lagerbestand_ID)
        {
            return Lagerbestand_Verwaltungsklasse.GetLagerbestandById(Lagerbestand_ID);
        }

        /// <summary>
        /// Laden eines Flugs
        /// </summary>
        public List<Lagerbestand> GetAllLagerbestandlisten()
        {
            return Lagerbestand_Verwaltungsklasse.GetAllLagerbestandlisten();
        }

        /// <summary>
        /// Laden eines Flugs
        /// </summary>
        public Lagerbestand GetLagerbestandByMaschinenartenId(int Maschinenart_ID)
        {
            return Lagerbestand_Verwaltungsklasse.GetLagerbestandByMaschinenartenId(Maschinenart_ID);
        }

        /// <summary>
        /// Laden eines Flugs
        /// </summary>
        public List<Lagerbestand> GetLagerbestandVorhanden()
        {
            return Lagerbestand_Verwaltungsklasse.GetLagerbestandVorhanden();
        }

        /// <summary>
        /// Laden eines Flugs
        /// </summary>
        public List<Lagerbestand> GetLagerbestandLeer()
        {
            return Lagerbestand_Verwaltungsklasse.GetLagerbestandLeer();
        }

        /// <summary>
        /// Laden eines Flugs
        /// </summary>
        public List<Lagerbestand> GetLagerbestandNichtsVermietet()
        {
            return Lagerbestand_Verwaltungsklasse.GetLagerbestandNichtsVermietet();
        }

        /// <summary>
        /// Laden eines Flugs
        /// </summary>
        public List<Lagerbestand> GetLagerbestandVermietet()
        {
            return Lagerbestand_Verwaltungsklasse.GetLagerbestandVermietet();
        }

        /// <summary>
        /// Laden eines Flugs
        /// </summary>
        public List<Lagerbestand> GetLagerbestandNichtImPool()
        {
            return Lagerbestand_Verwaltungsklasse.GetLagerbestandNichtImPool();
        }

        public List<Lagerbestand> SaveLagerSet(List<Lagerbestand> LagerSet, out string statistik)
        {
            return Lagerbestand_Verwaltungsklasse.SaveLagerSet(LagerSet, out statistik);
        }

        ///-------------------------------------------------------------------------------------
        ///-------------------------------------------------------------------------------------
        ///-------------------------------------------------------------------------------------

        /// <summary>
        /// Laden eines Flugs
        /// </summary>
        public Maschinenart GetMaschinenarteById(int MaschinenartenlistenID)
        {
            return Maschinenarten_Verwaltungsklasse.GetMaschinenarteById(MaschinenartenlistenID);
        }

        /// <summary>
        /// Laden eines Flugs
        /// </summary>
        public List<Maschinenart> GetAllMaschinenarten()
        {
            return Maschinenarten_Verwaltungsklasse.GetAllMaschinenarten();
        }

        /// <summary>
        /// Laden eines Flugs
        /// </summary>
        public List<Maschinenart> GetAllMaschinenartenIstRentabel()
        {
            return Maschinenarten_Verwaltungsklasse.GetAllMaschinenartenIstRentabel();
        }

        /// <summary>
        /// Laden eines Flugs
        /// </summary>
        public List<Maschinenart> GetAllMaschinenartenIstUnrentabel()
        {
            return Maschinenarten_Verwaltungsklasse.GetAllMaschinenartenIstUnrentabel();
        }

        /// <summary>
        /// Laden eines Flugs
        /// </summary>
        public List<Maschinenart> SaveMaschinenartSet(List<Maschinenart> MaschinenartenSet, out string Statistik)
        {
            return Maschinenarten_Verwaltungsklasse.SaveMaschinenartSet(MaschinenartenSet, out Statistik);
        }

        ///-------------------------------------------------------------------------------------
        ///-------------------------------------------------------------------------------------
        ///-------------------------------------------------------------------------------------

        /// <summary>
        /// Laden eines Flugs
        /// </summary>
        public Maschinenkauf GetMaschinenkaufById(int Maschinenkauf_ID)
        {
            return Maschinenkauf_Verwaltungsklasse.GetMaschinenkaufById(Maschinenkauf_ID);
        }

        /// <summary>
        /// Laden eines Flugs
        /// </summary>
        public List<Maschinenkauf> GetAllMaschinenkaufe()
        {
            return Maschinenkauf_Verwaltungsklasse.GetAllMaschinenkaufe();
        }

        /// <summary>
        /// Laden eines Flugs
        /// </summary>
        public List<Maschinenkauf> GetAllMaschinenkaufeByMaschinenart(int Maschinenart_ID)
        {
            return Maschinenkauf_Verwaltungsklasse.GetAllMaschinenkaufeByMaschinenart(Maschinenart_ID);
        }

        /// <summary>
        /// Laden eines Flugs
        /// </summary>
        public List<Maschinenkauf> GetAllMaschinenkaufeByDate(DateTime Kaufdatum)
        {
            return Maschinenkauf_Verwaltungsklasse.GetAllMaschinenkaufeByDate(Kaufdatum);
        }

        /// <summary>
        /// Laden Vermietungslisten mit bestimmtem Datum
        /// </summary>
        public List<Maschinenkauf> GetAllMaschinenkaufeInZeitraum(DateTime Vermitbegin, DateTime Vermitende)
        {
            return Maschinenkauf_Verwaltungsklasse.GetAllMaschinenkaufeInZeitraum(Vermitbegin, Vermitende);
        }

        /// <summary>
        /// Laden Vermietungslisten mit bestimmtem Datum
        /// </summary>
        public List<Maschinenkauf> SaveMaschinenkaufe(List<Maschinenkauf> MaschinenkaufSet, out string Statistik)
        {
            return Maschinenkauf_Verwaltungsklasse.SaveMaschinenkaufe(MaschinenkaufSet, out Statistik);
        }

        ///-------------------------------------------------------------------------------------
        ///-------------------------------------------------------------------------------------
        ///-------------------------------------------------------------------------------------
        /// 
        /// <summary>
        /// Laden eines Flugs
        /// </summary>
        public Vermietung GetVermietungById(int VermietungslisteID)
        {
            return Vermitungs_Verwaltungsklasse.GetVermietungById(VermietungslisteID);
        }

        /// <summary>
        /// Laden eines Flugs
        /// </summary>
        public List<Vermietung> GetAllVermietungen()
        {
            return Vermitungs_Verwaltungsklasse.GetAllVermietungen();
        }

        /// <summary>
        /// Laden Vermietungslisten mit bestimmtem Datum
        /// </summary>
        public List<Vermietung> GetVermietungenInZeitraum(DateTime Vermitbegin, DateTime Vermitende)
        {
            return Vermitungs_Verwaltungsklasse.GetVermietungenInZeitraum(Vermitbegin, Vermitende);
        }

        /// <summary>
        /// Laden Vermietungslisten mit bestimmtem Datum
        /// </summary>
        public List<Vermietung> GetVermietungenAnKunde(int Kunden_ID)
        {
            return Vermitungs_Verwaltungsklasse.GetVermietungenAnKunde(Kunden_ID);
        }

        /// <summary>
        /// Laden Vermietungslisten mit bestimmtem Datum
        /// </summary>
        public List<Vermietung> SaveVermitungenSet(List<Vermietung> VermietungSet, out string Statistik)
        {
            return Vermitungs_Verwaltungsklasse.SaveVermitungenSet(VermietungSet, out Statistik);
        }

        ///-------------------------------------------------------------------------------------
        ///-------------------------------------------------------------------------------------
        ///-------------------------------------------------------------------------------------

        public Kunde NuerKunde(String Kundenname)
        {
            return Kunden_Verwaltungsklasse.NuerKunde(Kundenname);
        }

        /// <summary>
        /// Füge einen Passagier zu einem Flug hinzu
        /// </summary>
        public Lagerbestand NuerLagerplatz(int MaschinenartID)
        {
            return Lagerbestand_Verwaltungsklasse.NuerLagerplatz(MaschinenartID);
        }

        /// <summary>
        /// Füge einen Passagier zu einem Flug hinzu
        /// </summary>
        public Maschinenart NeueMaschinenart(string Maschinenartbezeichnung)
        {
            return Maschinenarten_Verwaltungsklasse.NeueMaschinenart(Maschinenartbezeichnung);
        }

        ///-------------------------------------------------------------------------------------
        ///-------------------------------------------------------------------------------------
        ///-------------------------------------------------------------------------------------
        
        /// <summary>
        /// Füge einen Passagier zu einem Flug hinzu
        /// </summary>
        public Maschinenkauf NeuMaschinenkauf(int MaschinenartID, int anz, int Einzelpreis, DateTime Kaufdatum)
        {
            try
            {
                // Transaktion, nur erfolgreich wenn Platzanzahl reduziert und Buchung erstellt!
                using (System.Transactions.TransactionScope t = new System.Transactions.TransactionScope())
                {
                    // hier erfolgen Änderungen in Datenbanken über zwei Methoden der Datenzugriffsschicht
                    Maschinenkauf kauf = Maschinenkauf_Verwaltungsklasse.NeuMaschinenkauf(MaschinenartID, anz, Einzelpreis, Kaufdatum);
                    if (kauf != null) return null;
                    // Lagerbestand erhöhen
                    Lagerbestand lager = Maschinenkauf_Verwaltungsklasse.AddGekaufteMaschineZuLager(MaschinenartID, anz);
                    if (lager != null) return null; 
                    // Zu Maschinenartenliste hinzufügen
                    Maschinenart art = Maschinenkauf_Verwaltungsklasse.AddGekaufteMaschineZuMaschinenart(MaschinenartID, anz * Einzelpreis);
                    if (art != null) return null;


                    //  Transaktion erfolgreich abschließen
                    t.Complete();

                    // Buchungscode zurückgeben
                    return kauf;
                }
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
        public Vermietung NeueVermietungAnKunden(int KundenID, DateTime Vermitbegin, DateTime Vermitende)
        {    
            try
            {
                // Transaktion, nur erfolgreich wenn Platzanzahl reduziert und Buchung erstellt!
                using (System.Transactions.TransactionScope t = new System.Transactions.TransactionScope())
                {
                    // hier erfolgen Änderungen in Datenbanken über zwei Methoden der Datenzugriffsschicht
                    Vermietung vermietung = Vermitungs_Verwaltungsklasse.NeueVermietung(Vermitbegin, Vermitende);
                    if (vermietung != null) return null;
                    // Kunde zu Vermietung hinzufügen
                    vermietung = Kunden_Verwaltungsklasse.AddKundeZuVermitung(KundenID, vermietung.Vermiet_ID);
                    if (vermietung != null) return null;

                    //  Transaktion erfolgreich abschließen
                    t.Complete();

                    // Buchungscode zurückgeben
                    return vermietung;
                }
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
        public Vermietung MaterialAnVermietungAnfügen(int VermietID, int MaschinenartID)
        {
            try
            {
                // Transaktion, nur erfolgreich wenn Platzanzahl reduziert und Buchung erstellt!
                using (System.Transactions.TransactionScope t = new System.Transactions.TransactionScope())
                {
                    // hier erfolgen Änderungen in Datenbanken über zwei Methoden der Datenzugriffsschicht
                    Vermietung vermietung = Maschinenarten_Verwaltungsklasse.AddMaschinenartZuVermitung(MaschinenartID, VermietID);
                    if (vermietung != null) return null;
                   
                    //  Transaktion erfolgreich abschließen
                    t.Complete();

                    // Buchungscode zurückgeben
                    return vermietung;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return null;
            }
        }

        ///-------------------------------------------------------------------------------------
        ///-------------------------------------------------------------------------------------
        ///-------------------------------------------------------------------------------------

    }


}
