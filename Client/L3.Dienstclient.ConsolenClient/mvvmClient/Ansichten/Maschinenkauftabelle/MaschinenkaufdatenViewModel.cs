using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Media;
using mvvmClient.Model;
using mvvmClient.Commands;
using Mietmaschienenservice_Dienstproxy.Client.L2.Proxy.ClientProxy;
using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using System.Windows;

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

        //-----------------

        ///  ########################### Daten (Properties) ###########################################
        ObservableCollection<Maschinenkauf> maschinenkauf;
        public ObservableCollection<Maschinenkauf> Maschinenkauf // Liste der Orte für Abflug- und Zielauswahl
        {
            get { return maschinenkauf; }
            set { 
                    maschinenkauf = value; 
                    OnPropertyChanged("Maschinenkauf"); 
                }
        }

        ObservableCollection<Maschinenart> maschinenart;
        public ObservableCollection<Maschinenart> Maschinenart // Liste der Orte für Abflug- und Zielauswahl
        {
            get { return maschinenart; }
            set
            {
                maschinenart = value;
                OnPropertyChanged("Maschinenart");
            }
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
                locked = false;
            }
        }

        //-----------------

        ObservableCollection<int> maschinenartenIDs;
        public ObservableCollection<int> MaschinenartenIDs // Liste der Orte für Abflug- und Zielauswahl
        {
            get { return maschinenartenIDs; }
            set
            {
                maschinenartenIDs = value;
                OnPropertyChanged("MaschinenartenIDs"); 
            }
        }

        ObservableCollection<string> maschinenartenBezeichnung;
        public ObservableCollection<string> MaschinenartenBezeichnung // Liste der Orte für Abflug- und Zielauswahl
        {
            get { return maschinenartenBezeichnung; }
            set
            {
                maschinenartenBezeichnung = value;
                OnPropertyChanged("MaschinenartenBezeichnung");
            }
        }

        private string currentMaschinenartenBezeichnung;
        public string CurrentMaschinenartenBezeichnung
        {
            get { return currentMaschinenartenBezeichnung; }
            set
            {
                currentMaschinenartenBezeichnung = value;

                //After change a Maschine the MaschinID in the corresponding (currentMaschinenkauf) must also be updatet according to this number
                //Find number coresponding to Bezeichner

                int ID = 0;
                foreach (Maschinenart temp in Maschinenart)
                {
                    if (temp.Maschinenartbezeichnung == currentMaschinenartenBezeichnung)
                    {
                        ID = temp.Maschinenart_ID;
                        break;
                    }
                }
                CurrentMaschinenkauf.Maschinenart_ID = ID;

                OnPropertyChanged("CurrentMaschinenartenBezeichnung"); //INotifyPropertyChange
                locked = false;
            }
        }

        ///  ####################### gebundene Funktionen ######################################

        private bool locked = false;

        public void UpdateAllEndpreises()
        {            
            if (Maschinenkauf != null && locked == false)
            {
                foreach (Maschinenkauf _maschinenkauf in Maschinenkauf)
                {
                    if (_maschinenkauf != null)
                    {
                        if (_maschinenkauf.Anzahl > 0 && _maschinenkauf.Einzelpreis > 0)
                        {
                            _maschinenkauf.Rechnungspreis = _maschinenkauf.Anzahl * _maschinenkauf.Einzelpreis;
                            locked = true;
                            OnPropertyChanged("Maschinenkauf");
                        }
                    }
                }
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
            Maschinenart = client.GetAllMaschinenarten();

            MaschinenartenIDs = new ObservableCollection<int>(client.GetAllMaschinenarten().Select(p => p.Maschinenart_ID));
            MaschinenartenBezeichnung = new ObservableCollection<string>(client.GetAllMaschinenarten().Select(p => p.Maschinenartbezeichnung));
            client.Close();
        }


        ///  ########################### INotifyPropertyChanged ###########################################

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                UpdateAllEndpreises();
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
