using GalaSoft.MvvmLight;
using MVVM.Commands;
using System.ComponentModel;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System;
using mvvmClient.Model;
using mvvmClient.Commands;
using System.Windows;
using Mietmaschienenservice_Dienstproxy.Client.L2.Proxy.ClientProxy;

namespace mvvmClient.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase, INotifyPropertyChanged
    {

        ///  ########################### Befehle ###########################################
        public ActionCommand EndeCommand { get; set; }

        private void Ende()
        {
            Application.Current.MainWindow.Close();
        }

        


        ///  ########################### Daten ###########################################
        private bool kundenDatenTabAktive;
        private bool lagerDatenTabAktive;
        private bool maschinenartenDatenDatenTabAktive;
        private bool maschinenkaufDatenTabAktive;
        private bool vermietungsDatenTabAktive;


        /// <summary>
        /// Ist Ribbon Tab 1 ausgewählt?
        /// </summary>
        public bool KundenDatenTabAktive
        {
            get { return kundenDatenTabAktive; }
            set
            {
                kundenDatenTabAktive = value;

                if (kundenDatenTabAktive)
                {
                    this.ActiveAnsichtViewModel = new mvvmClient.Ansichten.KundendatenViewModel();
                }

                OnPropertyChanged("KundenDatenTabAktive");
            }
        }

        /// <summary>
        /// Ist Ribbon Tab 1 ausgewählt?
        /// </summary>
        public bool LagerDatenTabAktive
        {
            get { return lagerDatenTabAktive; }
            set
            {
                lagerDatenTabAktive = value;

                if (lagerDatenTabAktive)
                {
                    this.ActiveAnsichtViewModel = new mvvmClient.Ansichten.LagerdatenViewModel();
                }

                OnPropertyChanged("LagerDatenTabAktive");
            }
        }

        /// <summary>
        /// Ist Ribbon Tab 1 ausgewählt?
        /// </summary>
        public bool MaschinenartenDatenTabAktive
        {
            get { return maschinenartenDatenDatenTabAktive; }
            set
            {
                maschinenartenDatenDatenTabAktive = value;

                if (maschinenartenDatenDatenTabAktive)
                {
                    this.ActiveAnsichtViewModel = new mvvmClient.Ansichten.MaschinenartendatenViewModel();
                }

                OnPropertyChanged("MaschinenartenDatenTabAktive");
            }
        }

        /// <summary>
        /// Ist Ribbon Tab 1 ausgewählt?
        /// </summary>
        public bool MaschinenkaufDatenTabAktive
        {
            get { return maschinenkaufDatenTabAktive; }
            set
            {
                maschinenkaufDatenTabAktive = value;

                if (maschinenkaufDatenTabAktive)
                {
                    this.ActiveAnsichtViewModel = new mvvmClient.Ansichten.MaschinenkaufdatenViewModel();
                }

                OnPropertyChanged("MaschinenkaufDatenTabAktive");
            }
        }

        /// <summary>
        /// Ist Ribbon Tab 1 ausgewählt?
        /// </summary>
        public bool VermietungsDatenTabAktive
        {
            get { return vermietungsDatenTabAktive; }
            set
            {
                vermietungsDatenTabAktive = value;

                if (vermietungsDatenTabAktive)
                {
                    this.ActiveAnsichtViewModel = new mvvmClient.Ansichten.VermietungsdatenViewModel();
                }

                OnPropertyChanged("VermietungsDatenTabAktive");
            }
        }


        private INotifyPropertyChanged activeAnsichtViewModel;

        /// <summary>
        /// Welche ist das aktive ViewModel
        /// </summary>
        public INotifyPropertyChanged ActiveAnsichtViewModel
        {
            get { return activeAnsichtViewModel; }
            set { activeAnsichtViewModel = value; OnPropertyChanged("ActiveAnsichtViewModel"); }
        }


        ///  ########################### INotifyPropertyChanged #########################################
        #region INotifyPropertyChanged Members

        public new event PropertyChangedEventHandler PropertyChanged;


        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        ///  ########################### Konstruktur ###########################################
        public MainViewModel()
        {

            EndeCommand = new ActionCommand(Ende);           
            // Erste Viewmodel
           // this.ActiveAnsichtViewModel = new mvvmClient.Ansichten.KundendatenViewModel();

        }

        #endregion

    }
}