using System;
using Crosscutting.MietmaterialdatenbankKlassen;
using Mietmaschienenservice_Dienstproxy.Client.L2.Proxy.ClientProxy;

namespace mvvmClient.Model
{
    public class DataService : IDataService , IDisposable
    {
        private MietserviceClient modell = new MietserviceClient();
        
        public void GetData(Action<DataItem, Exception> callback)
        {
            // Use this to connect to the actual data service
            var item = new DataItem("Welcome to MVVM Light");
            callback(item, null);
        }
        //--------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------
        public string Call(string ClientName)
        {
            Func<string, string> convertMethod = modell.Call;
            return convertMethod(ClientName);
        }
        //--------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------
        public Kunde GetKundeById(int KundenID)
        {
            return modell.GetKundeById(KundenID);
        }
        public System.Collections.ObjectModel.ObservableCollection<Kunde> GetAllKunden()
        {
            return modell.GetAllKunden();
        }
        //--------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------
        public Lagerbestand GetLagerbestandById(int LagerID)
        {
            return modell.GetLagerbestandById(LagerID);
        }
        public System.Collections.ObjectModel.ObservableCollection<Lagerbestand> GetAllLagerbestandlisten()
        {
            return modell.GetAllLagerbestandlisten();
        }
        public Lagerbestand GetLagerbestandByMaschinenartenId(int MaschinenartID)
        {
            return modell.GetLagerbestandByMaschinenartenId(MaschinenartID);
        }
        public System.Collections.ObjectModel.ObservableCollection<Lagerbestand> GetLagerbestandVorhanden()
        {
            return modell.GetLagerbestandVorhanden();
        }
        public System.Collections.ObjectModel.ObservableCollection<Lagerbestand> GetLagerbestandLeer()
        {
            return modell.GetLagerbestandLeer();
        }
        public System.Collections.ObjectModel.ObservableCollection<Lagerbestand> GetLagerbestandNichtsVermietet()
        {
            return modell.GetLagerbestandNichtsVermietet();
        }
        public System.Collections.ObjectModel.ObservableCollection<Lagerbestand> GetLagerbestandVermietet()
        {
            return modell.GetLagerbestandVermietet();
        }
        public System.Collections.ObjectModel.ObservableCollection<Lagerbestand> GetLagerbestandNichtImPool()
        {
            return modell.GetLagerbestandNichtImPool();
        }
        //--------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------
        public Maschinenart GetMaschinenarteById(int MaschinenartID)
        {
            return modell.GetMaschinenarteById(MaschinenartID);
        }
        public System.Collections.ObjectModel.ObservableCollection<Maschinenart> GetAllMaschinenarten( )
        {
            return modell.GetAllMaschinenarten();
        }
        public System.Collections.ObjectModel.ObservableCollection<Maschinenart> GetAllMaschinenartenIstRentabel( )
        {
            return modell.GetAllMaschinenartenIstRentabel();
        }
        public System.Collections.ObjectModel.ObservableCollection<Maschinenart> GetAllMaschinenartenIstUnrentabel( )
        {
            return modell.GetAllMaschinenartenIstUnrentabel();
        }
        public Maschinenkauf GetMaschinenkaufById(int MaschinenkaufID)
        {
            return modell.GetMaschinenkaufById(MaschinenkaufID);
        }
        public System.Collections.ObjectModel.ObservableCollection<Maschinenkauf> GetAllMaschinenkaufe( )
        {
            return modell.GetAllMaschinenkaufe();
        }
        //-------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------
        public System.Collections.ObjectModel.ObservableCollection<Maschinenkauf> GetAllMaschinenkaufeByMaschinenart(int MaschinenartID)
        {
            return modell.GetAllMaschinenkaufeByMaschinenart(MaschinenartID);
        }
        public System.Collections.ObjectModel.ObservableCollection<Maschinenkauf> GetAllMaschinenkaufeByDate(DateTime Kaufdatum)
        {
            return modell.GetAllMaschinenkaufeByDate(Kaufdatum);
        }
        public System.Collections.ObjectModel.ObservableCollection<Maschinenkauf> GetAllMaschinenkaufeInZeitraum(DateTime Vermitbegin, DateTime Vermitende )
        {
            return modell.GetAllMaschinenkaufeInZeitraum(Vermitbegin, Vermitende);
        }
        //--------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------
        public Vermietung GetVermietungById(int VermietungslisteID)
        {
            return modell.GetVermietungById(VermietungslisteID);
        }
        public System.Collections.ObjectModel.ObservableCollection<Vermietung> GetAllVermietungen( )
        {
            return modell.GetAllVermietungen();
        }
        public System.Collections.ObjectModel.ObservableCollection<Vermietung> GetVermietungenInZeitraum(DateTime Vermitbegin, DateTime Vermitende)
        {
            return modell.GetVermietungenInZeitraum(Vermitbegin, Vermitende);
        }
        public System.Collections.ObjectModel.ObservableCollection<Vermietung> GetVermietungenAnKunde(int KundenID)
        {
            return modell.GetVermietungenAnKunde(KundenID);
        }
        //--------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------
        public Kunde NuerKunde(string Kundenname)
        {
            return modell.NuerKunde(Kundenname);
        }
        public Lagerbestand NuerLagerplatz(int MaschinenartID)
        {
            return modell.NuerLagerplatz(MaschinenartID);
        }
        public Maschinenart NeueMaschinenart(string Maschinenartname )
        {
            return modell.NeueMaschinenart(Maschinenartname);
        }
        public Maschinenkauf NeuMaschinenkauf(int Einzelpreis, DateTime Kaufdatum, int MaschinenartID, int anz )
        {
            return modell.NeuMaschinenkauf(Einzelpreis, Kaufdatum, MaschinenartID, anz);
        }
        public Vermietung NeueVermietungAnKunden(int KundenID, DateTime Vermitbegin, DateTime Vermitende )
        {
            return modell.NeueVermietungAnKunden(KundenID, Vermitbegin, Vermitende);
        }
        //-------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------
        public Vermietung MaterialAnVermietungAnfügen(int MaschinenartID, int VermietID)
        {
            return modell.MaterialAnVermietungAnfügen(MaschinenartID, VermietID);
        }
        //-------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------
        public string SaveKundenSet(ref System.Collections.ObjectModel.ObservableCollection<Kunde> NeueKunden)
        {
            return modell.SaveKundenSet(ref NeueKunden);
        }
        public string SaveLagerSet(ref System.Collections.ObjectModel.ObservableCollection<Lagerbestand> NeueLagerbestaende)
        {
            return modell.SaveLagerSet(ref NeueLagerbestaende);
        }
        public string SaveMaschinenartSet(ref System.Collections.ObjectModel.ObservableCollection<Maschinenart> NeueMaschinenart)
        {
            return modell.SaveMaschinenartSet(ref NeueMaschinenart);
        }
        public string SaveMaschinenkaufe(ref System.Collections.ObjectModel.ObservableCollection<Maschinenkauf> NeueMaschinenkaufe)
        {
            return modell.SaveMaschinenkaufe(ref NeueMaschinenkaufe);
        }
        public string SaveVermitungenSet(ref System.Collections.ObjectModel.ObservableCollection<Vermietung> NeueVermietungen)
        {
            return modell.SaveVermitungenSet(ref NeueVermietungen);
        }
        //-------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------
        public void Close()
        {
            modell.Close();
        }
        //-------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------
        #region IDisposable Support
        private bool disposedValue = false; // Dient zur Erkennung redundanter Aufrufe.

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    modell.Close();
                }

                // TODO: nicht verwaltete Ressourcen (nicht verwaltete Objekte) freigeben und Finalizer weiter unten überschreiben.
                // TODO: große Felder auf Null setzen.

                disposedValue = true;
            }
        }

        // TODO: Finalizer nur überschreiben, wenn Dispose(bool disposing) weiter oben Code für die Freigabe nicht verwalteter Ressourcen enthält.
        // ~DataService() {
        //   // Ändern Sie diesen Code nicht. Fügen Sie Bereinigungscode in Dispose(bool disposing) weiter oben ein.
        //   Dispose(false);
        // }

        // Dieser Code wird hinzugefügt, um das Dispose-Muster richtig zu implementieren.
        public void Dispose()
        {
            // Ändern Sie diesen Code nicht. Fügen Sie Bereinigungscode in Dispose(bool disposing) weiter oben ein.
            Dispose(true);
            // TODO: Auskommentierung der folgenden Zeile aufheben, wenn der Finalizer weiter oben überschrieben wird.
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}