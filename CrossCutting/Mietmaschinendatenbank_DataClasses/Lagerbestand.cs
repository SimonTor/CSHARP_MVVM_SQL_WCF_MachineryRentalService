//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.Serialization;

namespace CrossCutting.Mietmaschinendatenbank_DataClasses
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(Maschinenart))]
    public partial class Lagerbestand: IObjectWithChangeTracker, INotifyPropertyChanged
    {
        #region Simple Properties
    
        [DataMember]
        public int Lagerbestand_ID
        {
            get { return _lagerbestand_ID; }
            set
            {
                if (_lagerbestand_ID != value)
                {
                    if (ChangeTracker.ChangeTrackingEnabled && ChangeTracker.State != ObjectState.Added)
                    {
                        throw new InvalidOperationException("The property 'Lagerbestand_ID' is part of the object's key and cannot be changed. Changes to key properties can only be made when the object is not being tracked or is in the Added state.");
                    }
                    _lagerbestand_ID = value;
                    OnPropertyChanged("Lagerbestand_ID");
                }
            }
        }
        private int _lagerbestand_ID;
    
        [DataMember]
        public int Gesamtanzahl
        {
            get { return _gesamtanzahl; }
            set
            {
                if (_gesamtanzahl != value)
                {
                    _gesamtanzahl = value;
                    OnPropertyChanged("Gesamtanzahl");
                }
            }
        }
        private int _gesamtanzahl;
    
        [DataMember]
        public int Lagermenge
        {
            get { return _lagermenge; }
            set
            {
                if (_lagermenge != value)
                {
                    _lagermenge = value;
                    OnPropertyChanged("Lagermenge");
                }
            }
        }
        private int _lagermenge;
    
        [DataMember]
        public int VermietetMenge
        {
            get { return _vermietetMenge; }
            set
            {
                if (_vermietetMenge != value)
                {
                    _vermietetMenge = value;
                    OnPropertyChanged("VermietetMenge");
                }
            }
        }
        private int _vermietetMenge;
    
        [DataMember]
        public int Maschinenart_ID
        {
            get { return _maschinenart_ID; }
            set
            {
                if (_maschinenart_ID != value)
                {
                    ChangeTracker.RecordOriginalValue("Maschinenart_ID", _maschinenart_ID);
                    if (!IsDeserializing)
                    {
                        if (Maschinenart != null && Maschinenart.Maschinenart_ID != value)
                        {
                            Maschinenart = null;
                        }
                    }
                    _maschinenart_ID = value;
                    OnPropertyChanged("Maschinenart_ID");
                }
            }
        }
        private int _maschinenart_ID;

        #endregion

        #region Navigation Properties
    
        [DataMember]
        public Maschinenart Maschinenart
        {
            get { return _maschinenart; }
            set
            {
                if (!ReferenceEquals(_maschinenart, value))
                {
                    var previousValue = _maschinenart;
                    _maschinenart = value;
                    FixupMaschinenart(previousValue);
                    OnNavigationPropertyChanged("Maschinenart");
                }
            }
        }
        private Maschinenart _maschinenart;

        #endregion

        #region ChangeTracking
    
        protected virtual void OnPropertyChanged(String propertyName)
        {
            if (ChangeTracker.State != ObjectState.Added && ChangeTracker.State != ObjectState.Deleted)
            {
                ChangeTracker.State = ObjectState.Modified;
            }
            if (_propertyChanged != null)
            {
                _propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        protected virtual void OnNavigationPropertyChanged(String propertyName)
        {
            if (_propertyChanged != null)
            {
                _propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged{ add { _propertyChanged += value; } remove { _propertyChanged -= value; } }
        private event PropertyChangedEventHandler _propertyChanged;
        private ObjectChangeTracker _changeTracker;
    
        [DataMember]
        public ObjectChangeTracker ChangeTracker
        {
            get
            {
                if (_changeTracker == null)
                {
                    _changeTracker = new ObjectChangeTracker();
                    _changeTracker.ObjectStateChanging += HandleObjectStateChanging;
                }
                return _changeTracker;
            }
            set
            {
                if(_changeTracker != null)
                {
                    _changeTracker.ObjectStateChanging -= HandleObjectStateChanging;
                }
                _changeTracker = value;
                if(_changeTracker != null)
                {
                    _changeTracker.ObjectStateChanging += HandleObjectStateChanging;
                }
            }
        }
    
        private void HandleObjectStateChanging(object sender, ObjectStateChangingEventArgs e)
        {
            if (e.NewState == ObjectState.Deleted)
            {
                ClearNavigationProperties();
            }
        }
    
        protected bool IsDeserializing { get; private set; }
    
        [OnDeserializing]
        public void OnDeserializingMethod(StreamingContext context)
        {
            IsDeserializing = true;
        }
    
        [OnDeserialized]
        public void OnDeserializedMethod(StreamingContext context)
        {
            IsDeserializing = false;
            ChangeTracker.ChangeTrackingEnabled = true;
        }
    
        protected virtual void ClearNavigationProperties()
        {
            Maschinenart = null;
        }

        #endregion

        #region Association Fixup
    
        private void FixupMaschinenart(Maschinenart previousValue)
        {
            if (IsDeserializing)
            {
                return;
            }
    
            if (previousValue != null && previousValue.Lagerbestand.Contains(this))
            {
                previousValue.Lagerbestand.Remove(this);
            }
    
            if (Maschinenart != null)
            {
                Maschinenart.Lagerbestand.Add(this);
    
                Maschinenart_ID = Maschinenart.Maschinenart_ID;
            }
            if (ChangeTracker.ChangeTrackingEnabled)
            {
                if (ChangeTracker.OriginalValues.ContainsKey("Maschinenart")
                    && (ChangeTracker.OriginalValues["Maschinenart"] == Maschinenart))
                {
                    ChangeTracker.OriginalValues.Remove("Maschinenart");
                }
                else
                {
                    ChangeTracker.RecordOriginalValue("Maschinenart", previousValue);
                }
                if (Maschinenart != null && !Maschinenart.ChangeTracker.ChangeTrackingEnabled)
                {
                    Maschinenart.StartTracking();
                }
            }
        }

        #endregion

    }
}
