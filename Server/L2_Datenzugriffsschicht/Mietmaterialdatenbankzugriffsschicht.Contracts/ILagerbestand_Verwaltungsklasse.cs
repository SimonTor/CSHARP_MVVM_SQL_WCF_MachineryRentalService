using System.Collections.Generic;
using Crosscutting.MietmaterialdatenbankKlassen;

namespace Server.L2.Mietmaterialdatenbankzugriffsschicht.Contracts
{
    public interface ILagerbestand_Verwaltungsklasse
    {
        void Dispose();
        List<Lagerbestand> GetAllLagerbestandlisten();
        Lagerbestand GetLagerbestandById(int Lagerbestand_ID);
        Lagerbestand GetLagerbestandByMaschinenartenId(int Maschinenart_ID);
        List<Lagerbestand> GetLagerbestandLeer();
        List<Lagerbestand> GetLagerbestandNichtImPool();
        List<Lagerbestand> GetLagerbestandNichtsVermietet();
        List<Lagerbestand> GetLagerbestandVermietet();
        List<Lagerbestand> GetLagerbestandVorhanden();
        Lagerbestand NuerLagerplatz(int MaschinenartID);
        List<Lagerbestand> SaveLagerSet(List<Lagerbestand> LagerSet, out string Statistik);
    }
}