using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mietmaschienenservice_Dienstproxy.Client.L2.Proxy.ClientProxy;

namespace mvvmClient.Model
{
    public interface IDataService
    {
        void GetData(Action<DataItem, Exception> callback);
        //--------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------
        string Call(string ClientName);
        //--------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------
        Kunde GetKundeById(int KundenID);
        System.Collections.ObjectModel.ObservableCollection<Kunde> GetAllKunden();
        //--------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------
        Lagerbestand GetLagerbestandById(int LagerID);
        System.Collections.ObjectModel.ObservableCollection<Lagerbestand> GetAllLagerbestandlisten();
        Lagerbestand GetLagerbestandByMaschinenartenId(int MaschinenartID);
        System.Collections.ObjectModel.ObservableCollection<Lagerbestand> GetLagerbestandVorhanden();
        System.Collections.ObjectModel.ObservableCollection<Lagerbestand> GetLagerbestandLeer();
        System.Collections.ObjectModel.ObservableCollection<Lagerbestand> GetLagerbestandNichtsVermietet();
        System.Collections.ObjectModel.ObservableCollection<Lagerbestand> GetLagerbestandVermietet();
        System.Collections.ObjectModel.ObservableCollection<Lagerbestand> GetLagerbestandNichtImPool();
        //--------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------
        Maschinenart GetMaschinenarteById(int MaschinenartID);
        System.Collections.ObjectModel.ObservableCollection<Maschinenart> GetAllMaschinenarten();
        System.Collections.ObjectModel.ObservableCollection<Maschinenart> GetAllMaschinenartenIstRentabel();
        System.Collections.ObjectModel.ObservableCollection<Maschinenart> GetAllMaschinenartenIstUnrentabel();
        //-------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------
        Maschinenkauf GetMaschinenkaufById(int MaschinenkaufID);
        System.Collections.ObjectModel.ObservableCollection<Maschinenkauf> GetAllMaschinenkaufe();
        System.Collections.ObjectModel.ObservableCollection<Maschinenkauf> GetAllMaschinenkaufeByMaschinenart(int MaschinenartID);
        System.Collections.ObjectModel.ObservableCollection<Maschinenkauf> GetAllMaschinenkaufeByDate(DateTime Kaufdatum);
        System.Collections.ObjectModel.ObservableCollection<Maschinenkauf> GetAllMaschinenkaufeInZeitraum(DateTime Vermitbegin, DateTime Vermitende);
        //--------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------
        Vermietung GetVermietungById(int VermietungslisteID);
        System.Collections.ObjectModel.ObservableCollection<Vermietung> GetAllVermietungen();
        System.Collections.ObjectModel.ObservableCollection<Vermietung> GetVermietungenInZeitraum(DateTime Vermitbegin, DateTime Vermitende);
        System.Collections.ObjectModel.ObservableCollection<Vermietung> GetVermietungenAnKunde(int KundenID);
        //--------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------
        Kunde NuerKunde(string Kundenname);
        Lagerbestand NuerLagerplatz(int MaschinenartID);
        Maschinenart NeueMaschinenart(string Maschinenartname);
        Maschinenkauf NeuMaschinenkauf(int Einzelpreis, DateTime Kaufdatum, int MaschinenartID, int anz);
        Vermietung NeueVermietungAnKunden(int KundenID, DateTime Vermitbegin, DateTime Vermitende);
        //-------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------
        Vermietung MaterialAnVermietungAnfügen(int MaschinenartID, int VermietID);
        //-------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------
        string SaveKundenSet(ref System.Collections.ObjectModel.ObservableCollection<Kunde> NeueKunden);
        string SaveLagerSet(ref System.Collections.ObjectModel.ObservableCollection<Lagerbestand> NeueLagerbestaende);
        string SaveMaschinenartSet(ref System.Collections.ObjectModel.ObservableCollection<Maschinenart> NeueMaschinenart);
        string SaveMaschinenkaufe(ref System.Collections.ObjectModel.ObservableCollection<Maschinenkauf> NeueMaschinenkaufe);
        string SaveVermitungenSet(ref System.Collections.ObjectModel.ObservableCollection<Vermietung> NeueVermietungen);
        //-------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------
    }
}
