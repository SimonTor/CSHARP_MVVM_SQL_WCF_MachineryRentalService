using System;
using System.Collections.ObjectModel;
using Crosscutting.MietmaterialdatenbankKlassen;
using mvvmClient.Model;

namespace mvvmClient.Design
{
    public class DesignDataService : IDataService
    {
        public void GetData(Action<DataItem, Exception> callback)
        {
            // Use this to create design time data

            var item = new DataItem("Welcome to MVVM Light [design]");
            callback(item, null);
        }
        //--------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------
        public string Call(string ClientName)
        {
            return "Demomodus";
        }
        //--------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------
        public ObservableCollection<Kunde> GetAllKunden()
        {
            Kunde KundeA = new Kunde();
            KundeA.Kundenname = "Simon";
            KundeA.Kunden_ID = 1;
            KundeA.Kundengesamtumsatz = 100;

            Kunde KundeB = new Kunde();
            KundeB.Kundenname = "Fabian";
            KundeA.Kunden_ID = 2;
            KundeA.Kundengesamtumsatz = 200;

            ObservableCollection<Kunde> retval = new ObservableCollection<Kunde>();
            retval.Add(KundeA);
            retval.Add(KundeB);

            return retval;
        }
        public Kunde GetKundeById(int KundenID)
        {
            Kunde KundeA = new Kunde();
            KundeA.Kundenname = "Dummy";
            KundeA.Kunden_ID = 1;
            KundeA.Kundengesamtumsatz = 100;

            return KundeA;
        }
        //--------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------
        public ObservableCollection<Lagerbestand> GetAllLagerbestandlisten()
        {
            throw new NotImplementedException();
        } 
        public Lagerbestand GetLagerbestandById(int LagerID)
        {
            throw new NotImplementedException();
        }
        public Lagerbestand GetLagerbestandByMaschinenartenId(int MaschinenartID)
        {
            throw new NotImplementedException();
        }
        public ObservableCollection<Lagerbestand> GetLagerbestandLeer()
        {
            throw new NotImplementedException();
        }
        public ObservableCollection<Lagerbestand> GetLagerbestandNichtImPool()
        {
            throw new NotImplementedException();
        }
        public ObservableCollection<Lagerbestand> GetLagerbestandNichtsVermietet()
        {
            throw new NotImplementedException();
        }
        public ObservableCollection<Lagerbestand> GetLagerbestandVermietet()
        {
            throw new NotImplementedException();
        }
        public ObservableCollection<Lagerbestand> GetLagerbestandVorhanden()
        {
            throw new NotImplementedException();
        }
        //--------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------
        public Maschinenart GetMaschinenarteById(int MaschinenartID)
        {
            throw new NotImplementedException();
        }
        public ObservableCollection<Maschinenart> GetAllMaschinenarten()
        {
            throw new NotImplementedException();
        }
        public ObservableCollection<Maschinenart> GetAllMaschinenartenIstRentabel()
        {
            throw new NotImplementedException();
        }
        public ObservableCollection<Maschinenart> GetAllMaschinenartenIstUnrentabel()
        {
            throw new NotImplementedException();
        }
        public Maschinenkauf GetMaschinenkaufById(int MaschinenkaufID)
        {
            throw new NotImplementedException();
        }
        public ObservableCollection<Maschinenkauf> GetAllMaschinenkaufe()
        {
            throw new NotImplementedException();
        }
        public ObservableCollection<Maschinenkauf> GetAllMaschinenkaufeByMaschinenart(int MaschinenartID)
        {
            throw new NotImplementedException();
        }
        public ObservableCollection<Maschinenkauf> GetAllMaschinenkaufeByDate(DateTime Kaufdatum)
        {
            throw new NotImplementedException();
        }
        public ObservableCollection<Maschinenkauf> GetAllMaschinenkaufeInZeitraum(DateTime Vermitbegin, DateTime Vermitende)
        {
            throw new NotImplementedException();
        }
        //--------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------
        public Vermietung GetVermietungById(int VermietungslisteID)
        {
            throw new NotImplementedException();
        }
        public ObservableCollection<Vermietung> GetAllVermietungen()
        {
            throw new NotImplementedException();
        }
        public ObservableCollection<Vermietung> GetVermietungenInZeitraum(DateTime Vermitbegin, DateTime Vermitende)
        {
            throw new NotImplementedException();
        }
        public ObservableCollection<Vermietung> GetVermietungenAnKunde(int KundenID)
        {
            throw new NotImplementedException();
        }
        //--------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------
        public Kunde NuerKunde(string Kundenname)
        {
            throw new NotImplementedException();
        }
        public Lagerbestand NuerLagerplatz(int MaschinenartID)
        {
            throw new NotImplementedException();
        }
        public Maschinenart NeueMaschinenart(string Maschinenartname)
        {
            throw new NotImplementedException();
        }

        public Maschinenkauf NeuMaschinenkauf(int Einzelpreis, DateTime Kaufdatum, int MaschinenartID, int anz)
        {
            throw new NotImplementedException();
        }
        public Vermietung NeueVermietungAnKunden(int KundenID, DateTime Vermitbegin, DateTime Vermitende)
        {
            throw new NotImplementedException();
        }
        //--------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------
        public Vermietung MaterialAnVermietungAnfügen(int MaschinenartID, int VermietID)
        {
            throw new NotImplementedException();
        }
        //--------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------
        public string SaveKundenSet(ref ObservableCollection<Kunde> NeueKunden)
        {
            throw new NotImplementedException();
        }
        public string SaveLagerSet(ref ObservableCollection<Lagerbestand> NeueLagerbestaende)
        {
            throw new NotImplementedException();
        }
        public string SaveMaschinenartSet(ref ObservableCollection<Maschinenart> NeueMaschinenart)
        {
            throw new NotImplementedException();
        }
        public string SaveMaschinenkaufe(ref ObservableCollection<Maschinenkauf> NeueMaschinenkaufe)
        {
            throw new NotImplementedException();
        }
        public string SaveVermitungenSet(ref ObservableCollection<Vermietung> NeueVermietungen)
        {
            throw new NotImplementedException();
        }
        //--------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------

    }
}