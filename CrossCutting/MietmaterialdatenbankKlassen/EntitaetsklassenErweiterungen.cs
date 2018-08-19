using System;
using System.ComponentModel;
namespace Crosscutting.MietmaterialdatenbankKlassen
{
    public partial class Kunde
    {        
        public string GanzerName { get { return this.Kundenname; } }
        public override string ToString()
        {           
            return "Kunde #" + this.Kunden_ID + ": " + this.GanzerName;
        }

        private ObjectState objectState;
        public ObjectState ObjectState
        {
            get { return objectState; }
            set
            {
                objectState = value;
            }
        }

        public static void Clone(Kunde source, Kunde target)
        {
            Kunde temp = new Kunde();
            target.Kunden_ID = source.Kunden_ID;
            target.Kundengesamtumsatz = source.Kundengesamtumsatz;
            target.Kundenname = source.Kundenname;
            //target.Vermietung = source.Vermietung;
            target.ChangeTracker = source.ChangeTracker;
        }
    }

    public partial class Lagerbestand
    {
        public string Lagerdaten { get { return "MaschineID: " + this.Maschinenart_ID.ToString() + " Gesamtanzahl: " + this.Gesamtanzahl.ToString() + " Lagermenge: " + this.Lagermenge.ToString() + " VermietetMenge: " + this.VermietetMenge.ToString(); } }

        public override string ToString()
        {
            return "Lagerbestand #" + this.Lagerbestand_ID + ": " + this.Lagerdaten;
        }

        public static void Clone(Lagerbestand source, Lagerbestand target)
        {
            Kunde temp = new Kunde();
            target.Lagerbestand_ID = source.Lagerbestand_ID;
            target.Maschinenart_ID = source.Maschinenart_ID;
            target.Gesamtanzahl = source.Gesamtanzahl;
            target.Lagermenge = source.Lagermenge;
            target.VermietetMenge = source.VermietetMenge;
            target.ChangeTracker = source.ChangeTracker;
        }
    }

    public partial class Maschinenart 
    {
        public string Maschinenartdaten { get { return "Maschinenartbezeichnung: " + this.Maschinenartbezeichnung + "Gesamtkosten: " + this.Gesamtkosten.ToString() + " Gesamteinnahmen: " + this.Gesamteinnahmen.ToString() + " Vermietfaktor: " + this.Vermietfaktor.ToString() + " Tagessatz: " + this.Tagessatz.ToString() + " Rentabilität: " + this.Rentabilität.ToString(); ; } }

        public override string ToString()
        {
            return "Lagerbestand #" + this.Maschinenart_ID + ": " + this.Maschinenartdaten;
        }

        public static void Clone(Maschinenart source, Maschinenart target)
        {
            Maschinenart temp = new Maschinenart();
            target.Maschinenart_ID = source.Maschinenart_ID;
            target.Gesamtkosten = source.Gesamtkosten;
            target.Vermietfaktor = source.Vermietfaktor;
            target.Tagessatz = source.Tagessatz;
            target.Rentabilität = source.Rentabilität;
            target.Maschinenartbezeichnung = source.Maschinenartbezeichnung;
            target.ChangeTracker = source.ChangeTracker;
        }
    }

    public partial class Maschinenkauf
    {
        public string Maschinenkaufdaten { get { return "Maschinenart_ID: " + this.Maschinenart_ID.ToString() + " Anzahl: " + this.Anzahl.ToString() + " Einzelpreis: " + this.Einzelpreis.ToString() + " Rechnungspreis: " + this.Rechnungspreis.ToString() + " Kaufdatum: " + this.Kaufdatum.ToString(); ; } }

        public override string ToString()
        {
            return "Lagerbestand #" + this.Maschinenkauf_ID + ": " + this.Maschinenkaufdaten;
        }

        public static void Clone(Maschinenkauf source, Maschinenkauf target)
        {
            Maschinenkauf temp = new Maschinenkauf();
            target.Maschinenkauf_ID = source.Maschinenkauf_ID;
            target.Anzahl = source.Anzahl;
            target.Einzelpreis = source.Einzelpreis;
            target.Rechnungspreis = source.Rechnungspreis;
            target.Kaufdatum = source.Kaufdatum;
            target.Maschinenart_ID = source.Maschinenart_ID;
            target.ChangeTracker = source.ChangeTracker;
        }
    }

    public partial class Vermietung
    {
        public string Vermietungsdaten { get { return "Vermietbegin: " + this.Vermietbegin.ToString() + " Vermietende: " + this.Vermietende.ToString() + " Gesamtpreis: " + this.Gesamtpreis.ToString() + " Kunden_ID: " + this.Kunden_ID.ToString(); ; } }

        public override string ToString()
        {
            return "Lagerbestand #" + this.Vermiet_ID + ": " + this.Vermietungsdaten;
        }

        public static void Clone(Vermietung source, Vermietung target)
        {
            Vermietung temp = new Vermietung();
            target.Vermiet_ID = source.Vermiet_ID;
            target.Vermietbegin = source.Vermietbegin;
            target.Vermietende = source.Vermietende;
            target.Gesamtpreis = source.Gesamtpreis;
            target.Kunden_ID = source.Kunden_ID;
            target.ChangeTracker = source.ChangeTracker;
        }
    }    
}