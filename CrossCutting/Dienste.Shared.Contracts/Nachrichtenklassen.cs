using System;
using System.Collections.Generic;
using System.ServiceModel;
using CrossCutting.Mietmaschinendatenbank_DataClasses;

namespace Crosscutting.Dienste.Shared.Contracts
{
    //----------------------------------------------------------------------
    //----------------------------------------------------------------------
    //----------------------------------------------------------------------
    [MessageContract]
    public class GetCallAnfrage
    {
        [MessageBodyMember]
        public string ClientName;
    }

    [MessageContract]
    public class GetCallAntwort
    {
        [MessageBodyMember]
        public string runstate;
    }  
    //----------------------------------------------------------------------
    //----------------------------------------------------------------------
    //----------------------------------------------------------------------
    [MessageContract]
    public class GetKundeByIdAnfrage
    {
        [MessageBodyMember]
        public int KundenID;
    }

    [MessageContract]
    public class GetKundeByIdAntwort
    {
        [MessageBodyMember]
        public Kunde Kunde { get; set; }
    }
    //----------------------------------------------------------------------
    //----------------------------------------------------------------------
    //----------------------------------------------------------------------
    [MessageContract]
    public class GetAllKundenAnfrage
    {

    }

    [MessageContract]
    public class GetAllKundenAntwort
    {
        [MessageBodyMember]
        public List<Kunde> Kunden { get; set; }
    }
    //----------------------------------------------------------------------
    //----------------------------------------------------------------------
    //----------------------------------------------------------------------
    [MessageContract]
    public class GetLagerbestandByIdAnfrage
    {
        [MessageBodyMember]
        public int LagerID;
    }

    [MessageContract]
    public class GetLagerbestandByIdAntwort
    {
        [MessageBodyMember]
        public Lagerbestand Lager { get; set; }
    }
    //----------------------------------------------------------------------
    //----------------------------------------------------------------------
    //----------------------------------------------------------------------
    [MessageContract]
    public class GetAllLagerbestandlistenAnfrage
    {

    }

    [MessageContract]
    public class GetAllLagerbestandlistenAntwort
    {
        [MessageBodyMember]
        public List<Lagerbestand> Lager { get; set; }
    }
    //----------------------------------------------------------------------
    //----------------------------------------------------------------------
    //----------------------------------------------------------------------
    [MessageContract]
    public class GetLagerbestandByMaschinenartenIdAnfrage
    {
        [MessageBodyMember]
        public int MaschinenartID;
    }

    [MessageContract]
    public class GetLagerbestandByMaschinenartenIdAntwort
    {
        [MessageBodyMember]
        public Lagerbestand Lager { get; set; }
    }
    //----------------------------------------------------------------------
    //----------------------------------------------------------------------
    //----------------------------------------------------------------------
    [MessageContract]
    public class GetLagerbestandVorhandenAnfrage
    {

    }

    [MessageContract]
    public class GetLagerbestandVorhandenAntwort
    {
        [MessageBodyMember]
        public List<Lagerbestand> Lager { get; set; }
    }
    //----------------------------------------------------------------------
    //----------------------------------------------------------------------
    //----------------------------------------------------------------------
    [MessageContract]
    public class GetLagerbestandLeerAnfrage
    {

    }

    [MessageContract]
    public class GetLagerbestandLeerAntwort
    {
        [MessageBodyMember]
        public List<Lagerbestand> Lager { get; set; }
    }
    //----------------------------------------------------------------------
    //----------------------------------------------------------------------
    //----------------------------------------------------------------------
    [MessageContract]
    public class GetLagerbestandNichtsVermietetAnfrage
    {

    }

    [MessageContract]
    public class GetLagerbestandNichtsVermietetAntwort
    {
        [MessageBodyMember]
        public List<Lagerbestand> Lager { get; set; }
    }
    //----------------------------------------------------------------------
    //----------------------------------------------------------------------
    //----------------------------------------------------------------------
    [MessageContract]
    public class GetLagerbestandVermietetAnfrage
    {

    }

    [MessageContract]
    public class GetLagerbestandVermietetAntwort
    {
        [MessageBodyMember]
        public List<Lagerbestand> Lager { get; set; }
    }
    //----------------------------------------------------------------------
    //----------------------------------------------------------------------
    //----------------------------------------------------------------------
    [MessageContract]
    public class GetLagerbestandNichtImPoolAnfrage
    {

    }

    [MessageContract]
    public class GetLagerbestandNichtImPoolAntwort
    {
        [MessageBodyMember]
        public List<Lagerbestand> Lager { get; set; }
    }
    //----------------------------------------------------------------------
    //----------------------------------------------------------------------
    //----------------------------------------------------------------------
    [MessageContract]
    public class GetMaschinenarteByIdAnfrage
    {
        [MessageBodyMember]
        public int MaschinenartID;
    }

    [MessageContract]
    public class GetMaschinenarteByIdAntwort
    {
        [MessageBodyMember]
        public Maschinenart Maschinenart { get; set; }
    }
    //----------------------------------------------------------------------
    //----------------------------------------------------------------------
    //----------------------------------------------------------------------
    [MessageContract]
    public class GetAllMaschinenartenAnfrage
    {

    }

    [MessageContract]
    public class GetAllMaschinenartenAntwort
    {
        [MessageBodyMember]
        public List<Maschinenart> Maschinenart { get; set; }
    }
    //----------------------------------------------------------------------
    //----------------------------------------------------------------------
    //----------------------------------------------------------------------
    [MessageContract]
    public class GetAllMaschinenartenIstRentabelAnfrage
    {

    }

    [MessageContract]
    public class GetAllMaschinenartenIstRentabelAntwort
    {
        [MessageBodyMember]
        public List<Maschinenart> Maschinenart { get; set; }
    }
    //----------------------------------------------------------------------
    //----------------------------------------------------------------------
    //----------------------------------------------------------------------
    [MessageContract]
    public class GetAllMaschinenartenIstUnrentabelAnfrage
    {

    }

    [MessageContract]
    public class GetAllMaschinenartenIstUnrentabelAntwort
    {
        [MessageBodyMember]
        public List<Maschinenart> Maschinenart { get; set; }
    }
    //----------------------------------------------------------------------
    //----------------------------------------------------------------------
    //----------------------------------------------------------------------
    [MessageContract]
    public class GetMaschinenkaufByIdAnfrage
    {
        [MessageBodyMember]
        public int MaschinenkaufID;
    }

    [MessageContract]
    public class GetMaschinenkaufByIdAntwort
    {
        [MessageBodyMember]
        public Maschinenkauf Maschinenkauf { get; set; }

    }
    //----------------------------------------------------------------------
    //----------------------------------------------------------------------
    //----------------------------------------------------------------------
    [MessageContract]
    public class GetAllMaschinenkaufeAnfrage
    {

    }

    [MessageContract]
    public class GetAllMaschinenkaufeAntwort
    {
        [MessageBodyMember]
        public List<Maschinenkauf> Maschinenkauf { get; set; }
    }
    //----------------------------------------------------------------------
    //----------------------------------------------------------------------
    //----------------------------------------------------------------------
    [MessageContract]
    public class GetAllMaschinenkaufeByMaschinenartAnfrage
    {
        [MessageBodyMember]
        public int MaschinenartID;
    }

    [MessageContract]
    public class GetAllMaschinenkaufeByMaschinenartAntwort
    {
        [MessageBodyMember]
        public List<Maschinenkauf> Maschinenkauf { get; set; }
    }
    //----------------------------------------------------------------------
    //----------------------------------------------------------------------
    //----------------------------------------------------------------------
    [MessageContract]
    public class GetAllMaschinenkaufeByDateAnfrage
    {
        [MessageBodyMember]
        public DateTime Kaufdatum;
    }

    [MessageContract]
    public class GetAllMaschinenkaufeByDateAntwort
    {
        [MessageBodyMember]
        public List<Maschinenkauf> Maschinenkauf { get; set; }
    }
    //----------------------------------------------------------------------
    //----------------------------------------------------------------------
    //----------------------------------------------------------------------
    [MessageContract]
    public class GetAllMaschinenkaufeInZeitraumAnfrage
    {
        [MessageBodyMember]
        public DateTime Vermitbegin;
        [MessageBodyMember]
        public DateTime Vermitende;
    }

    [MessageContract]
    public class GetAllMaschinenkaufeInZeitraumAntwort
    {
        [MessageBodyMember]
        public List<Maschinenkauf> Maschinenkauf { get; set; }
    }
    //----------------------------------------------------------------------
    //----------------------------------------------------------------------
    //----------------------------------------------------------------------
    [MessageContract]
    public class GetVermietungByIdAnfrage
    {
        [MessageBodyMember]
        public int VermietungslisteID;

    }

    [MessageContract]
    public class GetVermietungByIdAntwort
    {
        [MessageBodyMember]
        public Vermietung Vermietung { get; set; }

    }
    //----------------------------------------------------------------------
    //----------------------------------------------------------------------
    //----------------------------------------------------------------------
    [MessageContract]
    public class GetAllVermietungenAnfrage
    {

    }

    [MessageContract]
    public class GetAllVermietungenAntwort
    {
        [MessageBodyMember]
        public List<Vermietung> Vermietung { get; set; }
    }
    //----------------------------------------------------------------------
    //----------------------------------------------------------------------
    //----------------------------------------------------------------------
    [MessageContract]
    public class GetVermietungenInZeitraumAnfrage
    {
        [MessageBodyMember]
        public DateTime Vermitbegin;
        [MessageBodyMember]
        public DateTime Vermitende;
    }

    [MessageContract]
    public class GetVermietungenInZeitraumAntwort
    {
        [MessageBodyMember]
        public List<Vermietung> Vermietung { get; set; }
    }
    //----------------------------------------------------------------------
    //----------------------------------------------------------------------
    //----------------------------------------------------------------------
    [MessageContract]
    public class GetVermietungenAnKundeAnfrage
    {
        [MessageBodyMember]
        public int KundenID;
    }

    [MessageContract]
    public class GetVermietungenAnKundeAntwort
    {
        [MessageBodyMember]
        public List<Vermietung> Vermietung { get; set; }
    }
    //----------------------------------------------------------------------
    //----------------------------------------------------------------------
    //----------------------------------------------------------------------
    [MessageContract]
    public class NuerKundeAnfrage
    {
        [MessageBodyMember]
        public string Kundenname;

    }

    [MessageContract]
    public class NuerKundeAntwort
    {
        [MessageBodyMember]
        public Kunde Kunde { get; set; }
    }
    //----------------------------------------------------------------------
    //----------------------------------------------------------------------
    //----------------------------------------------------------------------
    [MessageContract]
    public class NuerLagerplatzAnfrage
    {
        [MessageBodyMember]
        public int MaschinenartID;
    }

    [MessageContract]
    public class NuerLagerplatzAntwort
    {
        [MessageBodyMember]
        public Lagerbestand Lagerbestand { get; set; }
    }
    //----------------------------------------------------------------------
    //----------------------------------------------------------------------
    //----------------------------------------------------------------------
    [MessageContract]
    public class NeueMaschinenartAnfrage
    {
        [MessageBodyMember]
        public string Maschinenartname;
    }

    [MessageContract]
    public class NeueMaschinenartAntwort
    {
        [MessageBodyMember]
        public Maschinenart Maschinenart { get; set; }
    }
    //----------------------------------------------------------------------
    //----------------------------------------------------------------------
    //----------------------------------------------------------------------
    [MessageContract]
    public class NeuMaschinenkaufAnfrage
    {
        [MessageBodyMember]
        public int MaschinenartID;
        [MessageBodyMember]
        public int anz;
        [MessageBodyMember]
        public int Einzelpreis;
        [MessageBodyMember]
        public DateTime Kaufdatum;
    }

    [MessageContract]
    public class NeuMaschinenkaufAntwort
    {
        [MessageBodyMember]
        public Maschinenkauf Maschinenkauf { get; set; }
    }
    //----------------------------------------------------------------------
    //----------------------------------------------------------------------
    //----------------------------------------------------------------------
    [MessageContract]
    public class NeueVermietungAnKundenAnfrage
    {
        [MessageBodyMember]
        public int KundenID;
        [MessageBodyMember]
        public DateTime Vermitbegin;
        [MessageBodyMember]
        public DateTime Vermitende;
    }

    [MessageContract]
    public class NeueVermietungAnKundenAntwort
    {
        [MessageBodyMember]
        public Vermietung NeueVermietungAnKunden { get; set; }
    }
    //----------------------------------------------------------------------
    //----------------------------------------------------------------------
    //----------------------------------------------------------------------
    [MessageContract]
    public class MaterialAnVermietungAnfügenAnfrage
    {
        [MessageBodyMember]
        public int VermietID;
        [MessageBodyMember]
        public int MaschinenartID;

    }

    [MessageContract]
    public class MaterialAnVermietungAnfügenAntwort
    {
        [MessageBodyMember]
        public Vermietung MaterialAnVermietungAnfügen { get; set; }
    }
    //----------------------------------------------------------------------
    //----------------------------------------------------------------------
    //----------------------------------------------------------------------
    [MessageContract]
    public class SaveKundenSetAnfrage
    {
        [MessageBodyMember]
        public List<Kunde> NeueKunden { get; set; }
    }

    [MessageContract]
    public class SaveKundenSetAntwort
    {
        [MessageBodyMember]
        public List<Kunde> NeueKunden { get; set; }
        [MessageBodyMember]
        public string Statistik { get; set; }
    }
    //----------------------------------------------------------------------
    //----------------------------------------------------------------------
    //----------------------------------------------------------------------
    [MessageContract]
    public class SaveLagerSetAnfrage
    {
        [MessageBodyMember]
        public List<Lagerbestand> NeueLagerbestaende { get; set; }
    }

    [MessageContract]
    public class SaveLagerSetAntwort
    {
        [MessageBodyMember]
        public List<Lagerbestand> NeueLagerbestaende { get; set; }
        [MessageBodyMember]
        public string Statistik { get; set; }
    }
    //----------------------------------------------------------------------
    //----------------------------------------------------------------------
    //----------------------------------------------------------------------
    [MessageContract]
    public class SaveMaschinenartSetAnfrage
    {
        [MessageBodyMember]
        public List<Maschinenart> NeueMaschinenarten { get; set; }
    }

    [MessageContract]
    public class SaveMaschinenartSetAntwort
    {
        [MessageBodyMember]
        public List<Maschinenart> NeueMaschinenarten { get; set; }
        [MessageBodyMember]
        public string Statistik { get; set; }
    }
    //----------------------------------------------------------------------
    //----------------------------------------------------------------------
    //----------------------------------------------------------------------
    [MessageContract]
    public class SaveMaschinenkaufeAnfrage
    {
        [MessageBodyMember]
        public List<Maschinenkauf> NeueMaschinenkaufe { get; set; }
    }

    [MessageContract]
    public class SaveMaschinenkaufeAntwort
    {
        [MessageBodyMember]
        public List<Maschinenkauf> NeueMaschinenkaufe { get; set; }
        [MessageBodyMember]
        public string Statistik { get; set; }
    }
    //----------------------------------------------------------------------
    //----------------------------------------------------------------------
    //----------------------------------------------------------------------
    [MessageContract]
    public class SaveVermitungenSetAnfrage
    {
        [MessageBodyMember]
        public List<Vermietung> NeueVermietungen { get; set; }
    }

    [MessageContract]
    public class SaveVermitungenSetAntwort
    {
        [MessageBodyMember]
        public List<Vermietung> NeueVermietungen { get; set; }
        [MessageBodyMember]
        public string Statistik { get; set; }
    }
    //----------------------------------------------------------------------
    //----------------------------------------------------------------------
    //----------------------------------------------------------------------
}
