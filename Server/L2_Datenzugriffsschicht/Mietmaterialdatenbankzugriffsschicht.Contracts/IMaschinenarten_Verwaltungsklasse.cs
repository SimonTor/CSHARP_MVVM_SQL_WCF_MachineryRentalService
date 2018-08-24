using System.Collections.Generic;
using CrossCutting.Mietmaschinendatenbank_DataClasses;

namespace Server.L2.Mietmaterialdatenbankzugriffsschicht.Contracts
{
    public interface IMaschinenarten_Verwaltungsklasse
    {
        Vermietung AddMaschinenartZuVermitung(int MaschinenartID, int VermitID);
        void Dispose();
        List<Maschinenart> GetAllMaschinenarten();
        List<Maschinenart> GetAllMaschinenartenIstRentabel();
        List<Maschinenart> GetAllMaschinenartenIstUnrentabel();
        Maschinenart GetMaschinenarteById(int MaschinenartenlistenID);
        Maschinenart NeueMaschinenart(string Maschinenartbezeichnung);
        List<Maschinenart> SaveMaschinenartSet(List<Maschinenart> MaschinenartSet, out string Statistik);
    }
}