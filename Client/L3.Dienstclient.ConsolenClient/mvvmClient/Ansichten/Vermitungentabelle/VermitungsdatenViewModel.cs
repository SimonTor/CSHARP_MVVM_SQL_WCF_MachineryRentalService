﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Media;
using mvvmClient.Model;
using mvvmClient.Commands;
using Mietmaschienenservice_Dienstproxy.Client.L2.Proxy.ClientProxy;

namespace mvvmClient.Ansichten
{
    public partial class VermietungsdatenViewModel : INotifyPropertyChanged, IDisposable
    {
        ///  ########################### Befehle ###########################################
        public ActionCommand Vermietungstabeldoubleclick { get; set; }
        private void VermietungstabeldoubleclickMethod()
        {
            walkthrowGridUpdaterMethod();
        }

        public ActionCommand Vermietungstabelclick { get; set; }
        private void VermietungstabelclickMethod()
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
            Vermietung newVermietung = new Vermietung();
            Vermietungs.Add(newVermietung);

            walkthrowGridUpdaterMethod();
        }

        //-----------------

        public ActionCommand SaveCommand { get; set; }

        private void Save()
        {
            Console.WriteLine("Save");

            walkthrowGridUpdaterMethod();

            DataService saveclient = new DataService();
            String Statistik = saveclient.SaveVermitungenSet(ref vermietungs);
            saveclient.Close();

            DataService loadclient = new DataService(); //use a new client because with the old the tracker is not updated
            Vermietungs = null;
            Vermietungs = loadclient.GetAllVermietungen();  //load data again so that all is unchanged again
            loadclient.Close();
        }

        //-----------------

        public ActionCommand DeleteCommand { get; set; }

        private void Delete()
        {
            if (CurrentVermietungs != null)
            {
                int index = Vermietungs.IndexOf(CurrentVermietungs);
                CurrentVermietungs.ChangeTracker.State = ObjectState.Deleted;
                Vermietungs[index] = CurrentVermietungs;

                walkthrowGridUpdaterMethod();

                //kunden.Remove(currentKunde);
            }
            Console.WriteLine("Delete");
        }

        private void walkthrowGridUpdaterMethod()
        {
            OnPropertyChanged("Vermietungs");
            ObservableCollection<Vermietung> temp_Vermietungs = new ObservableCollection<Vermietung>(Vermietungs);
            Vermietungs = null;
            OnPropertyChanged("Vermietungs");
            Vermietungs = temp_Vermietungs;
            OnPropertyChanged("Vermietungs");
        }

        ///  ########################### Daten (Properties) ###########################################
        ObservableCollection<Vermietung> vermietungs;
        public ObservableCollection<Vermietung> Vermietungs // Liste der Orte für Abflug- und Zielauswahl
        {
            get { return vermietungs; }
            set { vermietungs = value; OnPropertyChanged("Vermietungs"); }
        }

        //-----------------

        private Vermietung currentVermietungs;
        public Vermietung CurrentVermietungs
        {
            get { return currentVermietungs; }
            set
            {
                currentVermietungs = value;
                OnPropertyChanged("CurrentVermietungs"); //INotifyPropertyChange
            }
        }

        ///  ########################### Konstruktor ###########################################

        public VermietungsdatenViewModel(Vermietungsdaten Vermietungsdaten = null)
        {
            ///  ########################### Befehle Verknüpfen ###########################################
            Vermietungstabeldoubleclick = new ActionCommand(VermietungstabeldoubleclickMethod);
            Vermietungstabelclick = new ActionCommand(VermietungstabelclickMethod);
            PressEnterKey = new ActionCommand(PressEnterKeyMethod);

            AddCommand = new ActionCommand(Add);
            SaveCommand = new ActionCommand(Save);
            DeleteCommand = new ActionCommand(Delete);

            DataService client = new DataService();
            Vermietungs = client.GetAllVermietungen();
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
        // ~VermietungsdatenViewModel() {
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
