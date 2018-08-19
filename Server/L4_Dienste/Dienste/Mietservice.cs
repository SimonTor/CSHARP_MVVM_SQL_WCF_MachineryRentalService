using System;
using Server.L3.Logikschicht.Contracts;
using Crosscutting.Dienste.Shared.Contracts;
using System.ServiceModel;
using System.Threading;

namespace Server.L4.Dienste
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall,
                 ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class Mietservice : IDisposable, IMietservice
    {
        #region IBuchungsservice Members
        public IMietmanager Mietmanager { get; set; }       

        public Mietservice(IMietmanager mietmanager)
        {
            Mietmanager = mietmanager;
        }
        

        #endregion


        // maintain instance count 
        public int i;
        public GetCallAntwort Call(GetCallAnfrage ClientName)
        {
            // increment instance counts
            i++;
            
            // display client name, instance number , thread number and time when 
            // the method was called            

            string ret = ("Client name :" + ClientName + " Instance:" +
              i.ToString() + " Thread:" + Thread.CurrentThread.ManagedThreadId.ToString() +
              " Time:" + DateTime.Now.ToString() + "\n\n");

            return new GetCallAntwort() { runstate =  ret };           

        }

        ///-------------------------------------------------------------------------------------
        ///-------------------------------------------------------------------------------------
        ///-------------------------------------------------------------------------------------
        /// <summary>
        /// Laden eines Flugs
        /// </summary>
        public GetKundeByIdAntwort GetKundeById(GetKundeByIdAnfrage anfrage)
        {
            return new GetKundeByIdAntwort() { Kunde = Mietmanager.GetKundeById(anfrage.KundenID) };
        }

        /// <summary>
        /// Laden eines Flugs
        /// </summary>
        public GetAllKundenAntwort GetAllKunden(GetAllKundenAnfrage anfrage)
        {
            return new GetAllKundenAntwort() { Kunden = Mietmanager.GetAllKunden() };
        }

        ///-------------------------------------------------------------------------------------
        ///-------------------------------------------------------------------------------------
        ///-------------------------------------------------------------------------------------

        /// <summary>
        /// Laden eines Flugs
        /// </summary>
        public GetLagerbestandByIdAntwort GetLagerbestandById(GetLagerbestandByIdAnfrage anfrage)
        {
            return new GetLagerbestandByIdAntwort() { Lager = Mietmanager.GetLagerbestandById(anfrage.LagerID) };
        }

        /// <summary>
        /// Laden eines Flugs
        /// </summary>
        public GetAllLagerbestandlistenAntwort GetAllLagerbestandlisten(GetAllLagerbestandlistenAnfrage Anfrage)
        {
            return new GetAllLagerbestandlistenAntwort() { Lager = Mietmanager.GetAllLagerbestandlisten() };
        }

        /// <summary>
        /// Laden eines Flugs
        /// </summary>
        public GetLagerbestandByMaschinenartenIdAntwort GetLagerbestandByMaschinenartenId(GetLagerbestandByMaschinenartenIdAnfrage anfrage)
        {
            return new GetLagerbestandByMaschinenartenIdAntwort() { Lager = Mietmanager.GetLagerbestandByMaschinenartenId(anfrage.MaschinenartID) };
        }

        ///// <summary>
        ///// Laden eines Flugs
        ///// </summary>
        public GetLagerbestandVorhandenAntwort GetLagerbestandVorhanden(GetLagerbestandVorhandenAnfrage anfrage)
        {
            return new GetLagerbestandVorhandenAntwort() { Lager = Mietmanager.GetLagerbestandVorhanden() };
        }

        ///// <summary>
        ///// Laden eines Flugs
        ///// </summary>
        public GetLagerbestandLeerAntwort GetLagerbestandLeer(GetLagerbestandLeerAnfrage anfrage)
        {
            return new GetLagerbestandLeerAntwort() { Lager = Mietmanager.GetLagerbestandLeer() };
        }

        ///// <summary>
        ///// Laden eines Flugs
        ///// </summary>
        public GetLagerbestandNichtsVermietetAntwort GetLagerbestandNichtsVermietet(GetLagerbestandNichtsVermietetAnfrage anfrage)
        {
            return new GetLagerbestandNichtsVermietetAntwort() { Lager = Mietmanager.GetLagerbestandNichtsVermietet() };
        }

        ///// <summary>
        ///// Laden eines Flugs
        ///// </summary>
        public GetLagerbestandVermietetAntwort GetLagerbestandVermietet(GetLagerbestandVermietetAnfrage anfrage)
        {
            return new GetLagerbestandVermietetAntwort() { Lager = Mietmanager.GetLagerbestandVermietet() };
        }

        ///// <summary>
        ///// Laden eines Flugs
        ///// </summary>
        public GetLagerbestandNichtImPoolAntwort GetLagerbestandNichtImPool(GetLagerbestandNichtImPoolAnfrage anfrage)
        {
            return new GetLagerbestandNichtImPoolAntwort() { Lager = Mietmanager.GetLagerbestandNichtImPool() };
        }

        /////-------------------------------------------------------------------------------------
        /////-------------------------------------------------------------------------------------
        /////-------------------------------------------------------------------------------------

        ///// <summary>
        ///// Laden eines Flugs
        ///// </summary>
        public GetMaschinenarteByIdAntwort GetMaschinenarteById(GetMaschinenarteByIdAnfrage anfrage)
        {
            return new GetMaschinenarteByIdAntwort() { Maschinenart = Mietmanager.GetMaschinenarteById(anfrage.MaschinenartID) };
        }

        ///// <summary>
        ///// Laden eines Flugs
        ///// </summary>
        public GetAllMaschinenartenAntwort GetAllMaschinenarten(GetAllMaschinenartenAnfrage anfrage)
        {
            return new GetAllMaschinenartenAntwort() { Maschinenart = Mietmanager.GetAllMaschinenarten() };
        }

        ///// <summary>
        ///// Laden eines Flugs
        ///// </summary>
        public GetAllMaschinenartenIstRentabelAntwort GetAllMaschinenartenIstRentabel(GetAllMaschinenartenIstRentabelAnfrage anfrage)
        {
            return new GetAllMaschinenartenIstRentabelAntwort() { Maschinenart = Mietmanager.GetAllMaschinenartenIstRentabel() };
        }

        ///// <summary>
        ///// Laden eines Flugs
        ///// </summary>
        public GetAllMaschinenartenIstUnrentabelAntwort GetAllMaschinenartenIstUnrentabel(GetAllMaschinenartenIstUnrentabelAnfrage anfrage)
        {
            return new GetAllMaschinenartenIstUnrentabelAntwort() { Maschinenart = Mietmanager.GetAllMaschinenartenIstUnrentabel() };
        }

        /////-------------------------------------------------------------------------------------
        /////-------------------------------------------------------------------------------------
        /////-------------------------------------------------------------------------------------

        ///// <summary>
        ///// Laden eines Flugs
        ///// </summary>
        public GetMaschinenkaufByIdAntwort GetMaschinenkaufById(GetMaschinenkaufByIdAnfrage anfrage)
        {
            return new GetMaschinenkaufByIdAntwort() { Maschinenkauf = Mietmanager.GetMaschinenkaufById(anfrage.MaschinenkaufID) };
        }

        ///// <summary>
        ///// Laden eines Flugs
        ///// </summary>
        public GetAllMaschinenkaufeAntwort GetAllMaschinenkaufe(GetAllMaschinenkaufeAnfrage anfrage)
        {
            return new GetAllMaschinenkaufeAntwort() { Maschinenkauf = Mietmanager.GetAllMaschinenkaufe() };
        }

        ///// <summary>
        ///// Laden eines Flugs
        ///// </summary>
        public GetAllMaschinenkaufeByMaschinenartAntwort GetAllMaschinenkaufeByMaschinenart(GetAllMaschinenkaufeByMaschinenartAnfrage anfrage)
        {
            return new GetAllMaschinenkaufeByMaschinenartAntwort() { Maschinenkauf = Mietmanager.GetAllMaschinenkaufeByMaschinenart(anfrage.MaschinenartID) };
        }

        ///// <summary>
        ///// Laden eines Flugs
        ///// </summary>
        public GetAllMaschinenkaufeByDateAntwort GetAllMaschinenkaufeByDate(GetAllMaschinenkaufeByDateAnfrage anfrage)
        {
            return new GetAllMaschinenkaufeByDateAntwort() { Maschinenkauf = Mietmanager.GetAllMaschinenkaufeByDate(anfrage.Kaufdatum) };
        }

        ///// <summary>
        ///// Laden Vermietungslisten mit bestimmtem Datum
        ///// </summary>
        public GetAllMaschinenkaufeInZeitraumAntwort GetAllMaschinenkaufeInZeitraum(GetAllMaschinenkaufeInZeitraumAnfrage anfrage)
        {
            return new GetAllMaschinenkaufeInZeitraumAntwort() { Maschinenkauf = Mietmanager.GetAllMaschinenkaufeInZeitraum(anfrage.Vermitbegin, anfrage.Vermitende) };
        }

        /////-------------------------------------------------------------------------------------
        /////-------------------------------------------------------------------------------------
        /////-------------------------------------------------------------------------------------
        ///// 
        ///// <summary>
        ///// Laden eines Flugs
        ///// </summary>
        public GetVermietungByIdAntwort GetVermietungById(GetVermietungByIdAnfrage anfrage)
        {
            return new GetVermietungByIdAntwort() { Vermietung = Mietmanager.GetVermietungById(anfrage.VermietungslisteID) };
        }

        ///// <summary>
        ///// Laden eines Flugs
        ///// </summary>
        public GetAllVermietungenAntwort GetAllVermietungen(GetAllVermietungenAnfrage anfrage)
        {
            return new GetAllVermietungenAntwort() { Vermietung = Mietmanager.GetAllVermietungen() };
        }

        ///// <summary>
        ///// Laden Vermietungslisten mit bestimmtem Datum
        ///// </summary>
        public GetVermietungenInZeitraumAntwort GetVermietungenInZeitraum(GetVermietungenInZeitraumAnfrage anfrage)
        {
            return new GetVermietungenInZeitraumAntwort() { Vermietung = Mietmanager.GetVermietungenInZeitraum(anfrage.Vermitbegin, anfrage.Vermitende) };
        }

        ///// <summary>
        ///// Laden Vermietungslisten mit bestimmtem Datum
        ///// </summary>
        public GetVermietungenAnKundeAntwort GetVermietungenAnKunde(GetVermietungenAnKundeAnfrage anfrage)
        {
            return new GetVermietungenAnKundeAntwort() { Vermietung = Mietmanager.GetVermietungenAnKunde(anfrage.KundenID) };
        }

        /////-------------------------------------------------------------------------------------
        /////-------------------------------------------------------------------------------------
        /////-------------------------------------------------------------------------------------

        public NuerKundeAntwort NuerKunde(NuerKundeAnfrage anfrage)
        {
            return new NuerKundeAntwort() { Kunde = Mietmanager.NuerKunde(anfrage.Kundenname) };
        }

        ///// <summary>
        ///// Füge einen Passagier zu einem Flug hinzu
        ///// </summary>
        public NuerLagerplatzAntwort NuerLagerplatz(NuerLagerplatzAnfrage anfrage)
        {
            return new NuerLagerplatzAntwort() { Lagerbestand = Mietmanager.NuerLagerplatz(anfrage.MaschinenartID) };
        }

        ///// <summary>
        ///// Füge einen Passagier zu einem Flug hinzu
        ///// </summary>
        public NeueMaschinenartAntwort NeueMaschinenart(NeueMaschinenartAnfrage anfrage)
        {
            return new NeueMaschinenartAntwort() { Maschinenart = Mietmanager.NeueMaschinenart(anfrage.Maschinenartname) };
        }

        /////-------------------------------------------------------------------------------------
        /////-------------------------------------------------------------------------------------
        /////-------------------------------------------------------------------------------------

        ///// <summary>
        ///// Füge einen Passagier zu einem Flug hinzu
        ///// </summary>
        public NeuMaschinenkaufAntwort NeuMaschinenkauf(NeuMaschinenkaufAnfrage anfrage)
        {
            return new NeuMaschinenkaufAntwort() { Maschinenkauf = Mietmanager.NeuMaschinenkauf(anfrage.MaschinenartID, anfrage.anz, anfrage.Einzelpreis, anfrage.Kaufdatum) };
        }

        ///// <summary>
        ///// Füge einen Passagier zu einem Flug hinzu
        ///// </summary>
        public NeueVermietungAnKundenAntwort NeueVermietungAnKunden(NeueVermietungAnKundenAnfrage anfrage)
        {
            return new NeueVermietungAnKundenAntwort() { NeueVermietungAnKunden = Mietmanager.NeueVermietungAnKunden(anfrage.KundenID, anfrage.Vermitbegin, anfrage.Vermitende) };
        }

        ///// <summary>
        ///// Füge einen Passagier zu einem Flug hinzu
        ///// </summary>
        public MaterialAnVermietungAnfügenAntwort MaterialAnVermietungAnfügen(MaterialAnVermietungAnfügenAnfrage anfrage)
        {
            return new MaterialAnVermietungAnfügenAntwort() { MaterialAnVermietungAnfügen = Mietmanager.MaterialAnVermietungAnfügen(anfrage.VermietID, anfrage.MaschinenartID) };
        }




       

        ///// <summary>
        ///// Füge einen Passagier zu einem Flug hinzu
        ///// </summary>
        public SaveKundenSetAntwort SaveKundenSet(SaveKundenSetAnfrage anfrage)
        {
            var Antwort = new SaveKundenSetAntwort();
            string statistik;
            Antwort.NeueKunden = Mietmanager.SaveKundenSet(anfrage.NeueKunden, out statistik);
            Antwort.Statistik = statistik;
            return Antwort;
        }

        ///// <summary>
        ///// Füge einen Passagier zu einem Flug hinzu
        ///// </summary>
        public SaveLagerSetAntwort SaveLagerSet(SaveLagerSetAnfrage anfrage)
        {
            var Antwort = new SaveLagerSetAntwort();
            string statistik;
            Antwort.NeueLagerbestaende = Mietmanager.SaveLagerSet(anfrage.NeueLagerbestaende, out statistik);
            Antwort.Statistik = statistik;
            return Antwort;
        }

        ///// <summary>
        ///// Füge einen Passagier zu einem Flug hinzu
        ///// </summary>
        public SaveMaschinenartSetAntwort SaveMaschinenartSet(SaveMaschinenartSetAnfrage anfrage)
        {
            var Antwort = new SaveMaschinenartSetAntwort();
            string statistik;
            Antwort.NeueMaschinenarten = Mietmanager.SaveMaschinenartSet(anfrage.NeueMaschinenarten, out statistik);
            Antwort.Statistik = statistik;
            return Antwort;
        }

        ///// <summary>
        ///// Füge einen Passagier zu einem Flug hinzu
        ///// </summary>
        public SaveMaschinenkaufeAntwort SaveMaschinenkaufe(SaveMaschinenkaufeAnfrage anfrage)
        {
            var Antwort = new SaveMaschinenkaufeAntwort();
            string statistik;
            Antwort.NeueMaschinenkaufe = Mietmanager.SaveMaschinenkaufe(anfrage.NeueMaschinenkaufe, out statistik);
            Antwort.Statistik = statistik;
            return Antwort;
        }

        ///// <summary>
        ///// Füge einen Passagier zu einem Flug hinzu
        ///// </summary>
        public SaveVermitungenSetAntwort SaveVermitungenSet(SaveVermitungenSetAnfrage anfrage)
        {
            var Antwort = new SaveVermitungenSetAntwort();
            string statistik;
            Antwort.NeueVermietungen = Mietmanager.SaveVermitungenSet(anfrage.NeueVermietungen, out statistik);
            Antwort.Statistik = statistik;
            return Antwort;
        }



        #region IDisposable Members

        public void Dispose()
        {
            Mietmanager.Dispose();
        }

        #endregion
    }
}
