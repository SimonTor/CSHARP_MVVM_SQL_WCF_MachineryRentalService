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
    public partial class MaschinenkaufdatenViewModel : INotifyPropertyChanged, IDisposable
    {
        ///  ########################### Befehle ###########################################
        public ActionCommand Maschinenkauftabeldoubleclick { get; set; }
        private void MaschinenkauftabeldoubleclickMethod()
        {
            walkthrowGridUpdaterMethod();
        }

        public ActionCommand Maschinenkauftabelclick { get; set; }
        private void MaschinenkauftabelclickMethod()
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
            Maschinenkauf newMaschinenkauf = new Maschinenkauf();
            Maschinenkauf.Add(newMaschinenkauf);

            walkthrowGridUpdaterMethod();
        }

        //-----------------

        public ActionCommand SaveCommand { get; set; }

        private void Save()
        {
            Console.WriteLine("Save");

            walkthrowGridUpdaterMethod();

            DataService saveclient = new DataService();
            String Statistik = saveclient.SaveMaschinenkaufe(ref maschinenkauf);
            saveclient.Close();

            DataService loadclient = new DataService(); //use a new client because with the old the tracker is not updated
            Maschinenkauf = null;
            Maschinenkauf = loadclient.GetAllMaschinenkaufe();  //load data again so that all is unchanged again
            loadclient.Close();
        }

        //-----------------

        public ActionCommand DeleteCommand { get; set; }

        private void Delete()
        {
            if (CurrentMaschinenkauf != null)
            {
                int index = Maschinenkauf.IndexOf(CurrentMaschinenkauf);
                CurrentMaschinenkauf.ChangeTracker.State = ObjectState.Deleted;
                Maschinenkauf[index] = CurrentMaschinenkauf;

                walkthrowGridUpdaterMethod();

                //kunden.Remove(currentKunde);
            }
            Console.WriteLine("Delete");
        }

        private void walkthrowGridUpdaterMethod()
        {
            OnPropertyChanged("Maschinenkauf");
            ObservableCollection<Maschinenkauf> temp_Maschinenkauf = new ObservableCollection<Maschinenkauf>(Maschinenkauf);
            Maschinenkauf = null;
            OnPropertyChanged("Maschinenkauf");
            Maschinenkauf = temp_Maschinenkauf;
            OnPropertyChanged("Maschinenkauf");
        }

        ///  ########################### Daten (Properties) ###########################################
        ObservableCollection<Maschinenkauf> maschinenkauf;
        public ObservableCollection<Maschinenkauf> Maschinenkauf // Liste der Orte für Abflug- und Zielauswahl
        {
            get { return maschinenkauf; }
            set { maschinenkauf = value; OnPropertyChanged("Maschinenkauf"); }
        }

        //-----------------

        private Maschinenkauf currentMaschinenkauf;
        public Maschinenkauf CurrentMaschinenkauf
        {
            get { return currentMaschinenkauf; }
            set
            {
                currentMaschinenkauf = value;
                OnPropertyChanged("CurrentMaschinenkauf"); //INotifyPropertyChange
            }
        }

        ///  ########################### Konstruktor ###########################################

        public MaschinenkaufdatenViewModel(Maschinenkaufdaten Maschinenkaufdaten = null)
        {
            ///  ########################### Befehle Verknüpfen ###########################################
            Maschinenkauftabeldoubleclick = new ActionCommand(MaschinenkauftabeldoubleclickMethod);
            Maschinenkauftabelclick = new ActionCommand(MaschinenkauftabelclickMethod);
            PressEnterKey = new ActionCommand(PressEnterKeyMethod);

            AddCommand = new ActionCommand(Add);
            SaveCommand = new ActionCommand(Save);
            DeleteCommand = new ActionCommand(Delete);

            DataService client = new DataService();
            Maschinenkauf = client.GetAllMaschinenkaufe();
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
        // ~MaschinenkaufdatenViewModel() {
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
