using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Media;
using Crosscutting.MietmaterialdatenbankKlassen;
using mvvmClient.Model;
using mvvmClient.Commands;
using System.Data;
using System.Windows.Controls;

namespace mvvmClient.Ansichten
{
    public partial class KundendatenViewModel : INotifyPropertyChanged, IDisposable
    {
        ///  ########################### Befehle ###########################################
        public ActionCommand Kundentabeldoubleclick { get; set; }
        private void KundentabeldoubleclickMethod()
        {
            walkthrowGridUpdaterMethod();
        }

        public ActionCommand Kundentabelclick { get; set; }
        private void KundentabelclickMethod()
        {
            walkthrowGridUpdaterMethod();
        }

        public ActionCommand PressEnterKey { get; set; }
        private void PressEnterKeyMethod()
        {
            walkthrowGridUpdaterMethod();
        }
        //-----------------

        public ActionCommand AddCommand { get; set; }

        private void Add()
        {
            Kunde newKunde = new Kunde();
            Kunden.Add(newKunde);

            walkthrowGridUpdaterMethod();
        }

        //-----------------

        public ActionCommand SaveCommand { get; set; }

        private void Save()
        {
            Console.WriteLine("Save");

            walkthrowGridUpdaterMethod();

            DataService saveclient = new DataService();
            String Statistik = saveclient.SaveKundenSet(ref kunden);
            saveclient.Close();

            DataService loadclient = new DataService(); //use a new client because with the old the tracker is not updated
            Kunden = null;
            Kunden = loadclient.GetAllKunden();  //load data again so that all is unchanged again
            loadclient.Close();           
        }

        //-----------------

        public ActionCommand DeleteCommand { get; set; }

        private void Delete()
        {
            if (currentKunde != null)
            {
                int index = Kunden.IndexOf(currentKunde);
                currentKunde.ChangeTracker.State = ObjectState.Deleted;
                currentKunde.Kundenname = currentKunde.Kundenname + "_deleted";
                Kunden[index] = currentKunde;

                walkthrowGridUpdaterMethod();
                
                //kunden.Remove(currentKunde);
            }
            Console.WriteLine("Delete");
        }

        private void walkthrowGridUpdaterMethod()
        {
            OnPropertyChanged("Kunden");
            ObservableCollection<Kunde> temp_kunden = new ObservableCollection<Kunde>(Kunden);
            Kunden = null;
            OnPropertyChanged("Kunden");
            Kunden = temp_kunden;
            OnPropertyChanged("Kunden");
        }

        ///  ########################### Daten (Properties) ###########################################
        ObservableCollection<Kunde> kunden;
        public ObservableCollection<Kunde> Kunden // Liste der Orte für Abflug- und Zielauswahl
        {
            get { return kunden; }
            set { kunden = value; OnPropertyChanged("Kunden"); }
        }

        //-----------------

        private Kunde currentKunde;
        public Kunde CurrentKunde
        {
            get { return currentKunde; }
            set
            {
                currentKunde = value;
                OnPropertyChanged("CurrentKunde"); //INotifyPropertyChange
            }
        }

        ///  ########################### Konstruktor ###########################################

        public KundendatenViewModel(Kunde kunde = null)
        {
            ///  ########################### Befehle Verknüpfen ###########################################
            Kundentabeldoubleclick = new ActionCommand(KundentabeldoubleclickMethod);
            Kundentabelclick = new ActionCommand(KundentabelclickMethod);
            PressEnterKey = new ActionCommand(PressEnterKeyMethod);

            AddCommand = new ActionCommand(Add);
            SaveCommand = new ActionCommand(Save);
            DeleteCommand = new ActionCommand(Delete);

            DataService client = new DataService();
            Kunden = client.GetAllKunden();                        

            client.Close();            
        }


        ///  ########################### INotifyPropertyChanged ###########################################

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // Dient zur Erkennung redundanter Aufrufe.

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    DataService client = new DataService();
                    client.Dispose();
                }

                // TODO: nicht verwaltete Ressourcen (nicht verwaltete Objekte) freigeben und Finalizer weiter unten überschreiben.
                // TODO: große Felder auf Null setzen.

                disposedValue = true;
            }
        }

        // TODO: Finalizer nur überschreiben, wenn Dispose(bool disposing) weiter oben Code für die Freigabe nicht verwalteter Ressourcen enthält.
        // ~KundendatenViewModel() {
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
        #endregion
    }
}
