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
    public partial class LagerdatenViewModel : INotifyPropertyChanged, IDisposable
    {
        ///  ########################### Befehle ###########################################
        public ActionCommand Lagertabeldoubleclick { get; set; }
        private void LagertabeldoubleclickMethod()
        {
            walkthrowGridUpdaterMethod();
        }

        public ActionCommand Lagertabelclick { get; set; }
        private void LagertabelclickMethod()
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
            Lagerbestand newLagerbestand = new Lagerbestand();
            Lager.Add(newLagerbestand);

            walkthrowGridUpdaterMethod();
        }

        //-----------------

        public ActionCommand SaveCommand { get; set; }

        private void Save()
        {
            Console.WriteLine("Save");

            walkthrowGridUpdaterMethod();

            DataService saveclient = new DataService();
            String Statistik = saveclient.SaveLagerSet(ref lager);
            saveclient.Close();

            DataService loadclient = new DataService(); //use a new client because with the old the tracker is not updated
            Lager = null;
            Lager = loadclient.GetAllLagerbestandlisten();  //load data again so that all is unchanged again
            loadclient.Close();
        }

        //-----------------

        public ActionCommand DeleteCommand { get; set; }

        private void Delete()
        {
            if (currentLager != null)
            {
                int index = Lager.IndexOf(currentLager);
                currentLager.ChangeTracker.State = ObjectState.Deleted;
                Lager[index] = currentLager;

                walkthrowGridUpdaterMethod();

            }
            Console.WriteLine("Delete");
        }

        private void walkthrowGridUpdaterMethod()
        {
            OnPropertyChanged("Lager");
            ObservableCollection<Lagerbestand> temp_lager = new ObservableCollection<Lagerbestand>(Lager);
            Lager = null;
            OnPropertyChanged("Lager");
            Lager = temp_lager;
            OnPropertyChanged("Lager");
        }

        ///  ########################### Daten (Properties) ###########################################
        ObservableCollection<Lagerbestand> lager;
        public ObservableCollection<Lagerbestand> Lager // Liste der Orte für Abflug- und Zielauswahl
        {
            get { return lager; }
            set { lager = value; OnPropertyChanged("Lager"); }
        }

        //-----------------

        private Lagerbestand currentLager;
        public Lagerbestand CurrentLager
        {
            get { return currentLager; }
            set
            {
                currentLager = value;
                OnPropertyChanged("CurrentLager"); //INotifyPropertyChange
            }
        }

        ///  ########################### Konstruktor ###########################################

        public LagerdatenViewModel(Lagerbestand lager = null)
        {
            ///  ########################### Befehle Verknüpfen ###########################################
            Lagertabeldoubleclick = new ActionCommand(LagertabeldoubleclickMethod);
            Lagertabelclick = new ActionCommand(LagertabelclickMethod);
            PressEnterKey = new ActionCommand(PressEnterKeyMethod);

            AddCommand = new ActionCommand(Add);
            SaveCommand = new ActionCommand(Save);
            DeleteCommand = new ActionCommand(Delete);

            DataService client = new DataService();
            Lager = client.GetAllLagerbestandlisten();

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
        // ~LagerdatenViewModel() {
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
