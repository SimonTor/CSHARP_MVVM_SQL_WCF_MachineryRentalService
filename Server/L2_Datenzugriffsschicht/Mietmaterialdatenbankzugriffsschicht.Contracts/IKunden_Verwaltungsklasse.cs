using System.Collections.Generic;
using CrossCutting.Mietmaschinendatenbank_DataClasses;

namespace Server.L2.Mietmaterialdatenbankzugriffsschicht.Contracts
{
    public interface IKunden_Verwaltungsklasse
    {
        Vermietung AddKundeZuVermitung(int KundenID, int VermitID);
        void Dispose();
        List<Kunde> GetAllKunden();
        Kunde GetKundeById(int Kunden_ID);
        Kunde NuerKunde(string Kundenname);
        List<Kunde> SaveKundenSet(List<Kunde> KundenSet, out string Statistik);
    }
}