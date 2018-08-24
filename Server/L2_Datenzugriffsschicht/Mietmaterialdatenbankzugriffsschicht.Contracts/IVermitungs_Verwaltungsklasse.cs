using System;
using System.Collections.Generic;
using CrossCutting.Mietmaschinendatenbank_DataClasses;

namespace Server.L2.Mietmaterialdatenbankzugriffsschicht.Contracts
{
    public interface IVermitungs_Verwaltungsklasse
    {
        void Dispose();
        List<Vermietung> GetAllVermietungen();
        Vermietung GetVermietungById(int VermietungslisteID);
        List<Vermietung> GetVermietungenAnKunde(int Kunden_ID);
        List<Vermietung> GetVermietungenInZeitraum(DateTime Vermitbegin, DateTime Vermitende);
        Vermietung NeueVermietung(DateTime Vermitbegin, DateTime Vermitende);
        List<Vermietung> SaveVermitungenSet(List<Vermietung> VermietungsDatensatz, out string Statistik);
    }
}