using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Media;
using Crosscutting.MietmaterialdatenbankKlassen;
using mvvmClient.Model;
using mvvmClient.Commands;

namespace mvvmClient.Ansichten
{
    public partial class MaschinenartendatenViewModel : INotifyPropertyChanged, IDisposable
    {
        ///  ########################### Befehle ###########################################
        public ActionCommand Maschinenartentabeldoubleclick { get; set; }
        private void MaschinenartentabeldoubleclickMethod()
        {
            walkthrowGridUpdaterMethod();
        }

        public ActionCommand Maschinenartentabelclick { get; set; }
        private void MaschinenartentabelclickMethod()
        {
            walkthrowGridUpdaterMethod();
        }

        public ActionCommand PressEnterKey { get; set; }
        private void PressEnterKeyMethod()
        {
            walkthrowGridUpdaterMethod();
        }

        public ActionCommand AddCommand { get; set; }

        private void Add()
        {
            Maschinenart newMaschinenart = new Maschinenart();
            Maschinenarten.Add(newMaschinenart);

            walkthrowGridUpdaterMethod();
        }

        //-----------------

        public ActionCommand SaveCommand { get; set; }

        private void Save()
        {
            Console.WriteLine("Save");

            walkthrowGridUpdaterMethod();

            DataService saveclient = new DataService();
            String Statistik = saveclient.SaveMaschinenartSet(ref maschinenarten);
            saveclient.Close();

            DataService loadclient = new DataService(); //use a new client because with the old the tracker is not updated
            Maschinenarten = null;
            Maschinenarten = loadclient.GetAllMaschinenarten();  //load data again so that all is unchanged again
            loadclient.Close();
        }

        //-----------------

        public ActionCommand DeleteCommand { get; set; }

        private void Delete()
        {
            if (maschinenarten != null)
            {
                int index = Maschinenarten.IndexOf(currentMaschinenart);
                currentMaschinenart.ChangeTracker.State = ObjectState.Deleted;
                Maschinenarten[index] = currentMaschinenart;

                walkthrowGridUpdaterMethod();

                //kunden.Remove(currentKunde);
            }
            Console.WriteLine("Delete");
        }

        private void walkthrowGridUpdaterMethod()
        {
            OnPropertyChanged("Maschinenarten");
            ObservableCollection<Maschinenart> temp_maschinenarten = new ObservableCollection<Maschinenart>(Maschinenarten);
            Maschinenarten = null;
            OnPropertyChanged("Maschinenarten");
            Maschinenarten = temp_maschinenarten;
            OnPropertyChanged("Maschinenarten");
        }
        ///  ########################### Daten (Properties) ###########################################
        ObservableCollection<Maschinenart> maschinenarten;
        public ObservableCollection<Maschinenart> Maschinenarten // Liste der Orte für Abflug- und Zielauswahl
        {
            get { return maschinenarten; }
            set { maschinenarten = value; OnPropertyChanged("Maschinenarten"); }
        }

        //-----------------

        private Maschinenart currentMaschinenart;
        public Maschinenart CurrentMaschinenart
        {
            get { return currentMaschinenart; }
            set
            {
                currentMaschinenart = value;
                OnPropertyChanged("CurrentMaschinenart"); //INotifyPropertyChange
            }
        }

        ///  ########################### Konstruktor ###########################################

        public MaschinenartendatenViewModel(Maschinenartendaten Maschinenartendaten = null)
        {
            ///  ########################### Befehle Verknüpfen ###########################################
            Maschinenartentabeldoubleclick = new ActionCommand(MaschinenartentabeldoubleclickMethod);
            Maschinenartentabelclick = new ActionCommand(MaschinenartentabelclickMethod);
            PressEnterKey = new ActionCommand(PressEnterKeyMethod);

            AddCommand = new ActionCommand(Add);
            SaveCommand = new ActionCommand(Save);
            DeleteCommand = new ActionCommand(Delete); 

            DataService client = new DataService();
            Maschinenarten = client.GetAllMaschinenarten();
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
        // ~MaschinenartendatenViewModel() {
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
