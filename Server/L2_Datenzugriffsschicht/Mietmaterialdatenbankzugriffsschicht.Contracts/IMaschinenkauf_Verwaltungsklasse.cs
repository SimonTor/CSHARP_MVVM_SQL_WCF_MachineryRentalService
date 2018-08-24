using System;
using System.Collections.Generic;
using CrossCutting.Mietmaschinendatenbank_DataClasses;

namespace Server.L2.Mietmaterialdatenbankzugriffsschicht.Contracts
{
    public interface IMaschinenkauf_Verwaltungsklasse
    {
        Lagerbestand AddGekaufteMaschineZuLager(int MaschinenartID, int Anzahl);
        Maschinenart AddGekaufteMaschineZuMaschinenart(int MaschinenartID, int rechnungspreis);
        void Dispose();
        List<Maschinenkauf> GetAllMaschinenkaufe();
        List<Maschinenkauf> GetAllMaschinenkaufeByDate(DateTime Kaufdatum);
        List<Maschinenkauf> GetAllMaschinenkaufeByMaschinenart(int Maschinenart_ID);
        List<Maschinenkauf> GetAllMaschinenkaufeInZeitraum(DateTime Vermitbegin, DateTime Vermitende);
        Maschinenkauf GetMaschinenkaufById(int Maschinenkauf_ID);
        Maschinenkauf NeuMaschinenkauf(int MaschinenartID, int anz, int Einzelpreis, DateTime Kaufdatum);
        List<Maschinenkauf> SaveMaschinenkaufe(List<Maschinenkauf> Maschinenkaufset, out string Statistik);
    }
}