using System;
using System.Collections.Generic;
using Crosscutting.Logging.Contracts;
using Crosscutting.MietmaterialdatenbankKlassen;
using Server.L2.Mietmaterialdatenbankzugriffsschicht.Contracts;

namespace Server.L3.Logikschicht.Contracts
{
    public interface IMietmanager
    {
        IKunden_Verwaltungsklasse Kunden_Verwaltungsklasse { get; set; }
        ILagerbestand_Verwaltungsklasse Lagerbestand_Verwaltungsklasse { get; set; }
        ILogger Logger { get; set; }
        IMaschinenarten_Verwaltungsklasse Maschinenarten_Verwaltungsklasse { get; set; }
        IMaschinenkauf_Verwaltungsklasse Maschinenkauf_Verwaltungsklasse { get; set; }
        IVermitungs_Verwaltungsklasse Vermitungs_Verwaltungsklasse { get; set; }

        void Dispose();
        List<Kunde> GetAllKunden();
        List<Lagerbestand> GetAllLagerbestandlisten();
        List<Maschinenart> GetAllMaschinenarten();
        List<Maschinenart> GetAllMaschinenartenIstRentabel();
        List<Maschinenart> GetAllMaschinenartenIstUnrentabel();
        List<Maschinenkauf> GetAllMaschinenkaufe();
        List<Maschinenkauf> GetAllMaschinenkaufeByDate(DateTime Kaufdatum);
        List<Maschinenkauf> GetAllMaschinenkaufeByMaschinenart(int Maschinenart_ID);
        List<Maschinenkauf> GetAllMaschinenkaufeInZeitraum(DateTime Vermitbegin, DateTime Vermitende);
        List<Vermietung> GetAllVermietungen();
        Kunde GetKundeById(int Kunden_ID);
        Lagerbestand GetLagerbestandById(int Lagerbestand_ID);
        Lagerbestand GetLagerbestandByMaschinenartenId(int Maschinenart_ID);
        List<Lagerbestand> GetLagerbestandLeer();
        List<Lagerbestand> GetLagerbestandNichtImPool();
        List<Lagerbestand> GetLagerbestandNichtsVermietet();
        List<Lagerbestand> GetLagerbestandVermietet();
        List<Lagerbestand> GetLagerbestandVorhanden();
        Maschinenart GetMaschinenarteById(int MaschinenartenlistenID);
        Maschinenkauf GetMaschinenkaufById(int Maschinenkauf_ID);
        Vermietung GetVermietungById(int VermietungslisteID);
        List<Vermietung> GetVermietungenAnKunde(int Kunden_ID);
        List<Vermietung> GetVermietungenInZeitraum(DateTime Vermitbegin, DateTime Vermitende);
        Vermietung MaterialAnVermietungAnfügen(int VermietID, int MaschinenartID);
        Maschinenart NeueMaschinenart(string Maschinenartname);
        Vermietung NeueVermietungAnKunden(int KundenID, DateTime Vermitbegin, DateTime Vermitende);
        Maschinenkauf NeuMaschinenkauf(int MaschinenartID, int anz, int Einzelpreis, DateTime Kaufdatum);
        Kunde NuerKunde(string Kundenname);
        Lagerbestand NuerLagerplatz(int MaschinenartID);
        List<Kunde> SaveKundenSet(List<Kunde> KundenSet, out string Statistik);
        List<Lagerbestand> SaveLagerSet(List<Lagerbestand> LagerSet, out string statistik);
        List<Maschinenart> SaveMaschinenartSet(List<Maschinenart> MaschinenartenSet, out string Statistik);
        List<Maschinenkauf> SaveMaschinenkaufe(List<Maschinenkauf> MaschinenkaufSet, out string Statistik);
        List<Vermietung> SaveVermitungenSet(List<Vermietung> VermietungSet, out string Statistik);
    }
}