using System.Collections.Generic;
using System.ServiceModel;
using System.IO;

namespace Crosscutting.Dienste.Shared.Contracts
{
    /// <summary>
    /// DienstSchnittstellendefinition 
    /// </summary>
    [ServiceContract(Namespace = "http://www.Baumaschinenmietservice.de/Services")]
    public interface IMietservice
    {   //-------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------
        [OperationContract]
        GetCallAntwort Call(GetCallAnfrage ClientName);
        //-------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------
        [OperationContract]
        GetKundeByIdAntwort GetKundeById(GetKundeByIdAnfrage Anfrage);

        [OperationContract]
        GetAllKundenAntwort GetAllKunden(GetAllKundenAnfrage Anfrage);
        //-------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------
        [OperationContract]
        GetLagerbestandByIdAntwort GetLagerbestandById(GetLagerbestandByIdAnfrage Anfrage);

        [OperationContract]
        GetAllLagerbestandlistenAntwort GetAllLagerbestandlisten(GetAllLagerbestandlistenAnfrage Anfrage);

        [OperationContract]
        GetLagerbestandByMaschinenartenIdAntwort GetLagerbestandByMaschinenartenId(GetLagerbestandByMaschinenartenIdAnfrage Anfrage);

        [OperationContract]
        GetLagerbestandVorhandenAntwort GetLagerbestandVorhanden(GetLagerbestandVorhandenAnfrage Anfrage);

        [OperationContract]
        GetLagerbestandLeerAntwort GetLagerbestandLeer(GetLagerbestandLeerAnfrage Anfrage);

        [OperationContract]
        GetLagerbestandNichtsVermietetAntwort GetLagerbestandNichtsVermietet(GetLagerbestandNichtsVermietetAnfrage Anfrage);

        [OperationContract]
        GetLagerbestandVermietetAntwort GetLagerbestandVermietet(GetLagerbestandVermietetAnfrage Anfrage);

        [OperationContract]
        GetLagerbestandNichtImPoolAntwort GetLagerbestandNichtImPool(GetLagerbestandNichtImPoolAnfrage Anfrage);
        //-------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------
        [OperationContract]
        GetMaschinenarteByIdAntwort GetMaschinenarteById(GetMaschinenarteByIdAnfrage Anfrage);

        [OperationContract]
        GetAllMaschinenartenAntwort GetAllMaschinenarten(GetAllMaschinenartenAnfrage Anfrage);

        [OperationContract]
        GetAllMaschinenartenIstRentabelAntwort GetAllMaschinenartenIstRentabel(GetAllMaschinenartenIstRentabelAnfrage Anfrage);

        [OperationContract]
        GetAllMaschinenartenIstUnrentabelAntwort GetAllMaschinenartenIstUnrentabel(GetAllMaschinenartenIstUnrentabelAnfrage Anfrage);
        //-------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------
        [OperationContract]
        GetMaschinenkaufByIdAntwort GetMaschinenkaufById(GetMaschinenkaufByIdAnfrage Anfrage);

        [OperationContract]
        GetAllMaschinenkaufeAntwort GetAllMaschinenkaufe(GetAllMaschinenkaufeAnfrage Anfrage);

        [OperationContract]
        GetAllMaschinenkaufeByMaschinenartAntwort GetAllMaschinenkaufeByMaschinenart(GetAllMaschinenkaufeByMaschinenartAnfrage Anfrage);

        [OperationContract]
        GetAllMaschinenkaufeByDateAntwort GetAllMaschinenkaufeByDate(GetAllMaschinenkaufeByDateAnfrage Anfrage);

        [OperationContract]
        GetAllMaschinenkaufeInZeitraumAntwort GetAllMaschinenkaufeInZeitraum(GetAllMaschinenkaufeInZeitraumAnfrage Anfrage);
        //-------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------
        [OperationContract]
        GetVermietungByIdAntwort GetVermietungById(GetVermietungByIdAnfrage Anfrage);

        [OperationContract]
        GetAllVermietungenAntwort GetAllVermietungen(GetAllVermietungenAnfrage Anfrage);

        [OperationContract]
        GetVermietungenInZeitraumAntwort GetVermietungenInZeitraum(GetVermietungenInZeitraumAnfrage Anfrage);

        [OperationContract]
        GetVermietungenAnKundeAntwort GetVermietungenAnKunde(GetVermietungenAnKundeAnfrage Anfrage);
        //-------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------
        [OperationContract]
        NuerKundeAntwort NuerKunde(NuerKundeAnfrage Anfrage);

        [OperationContract]
        NuerLagerplatzAntwort NuerLagerplatz(NuerLagerplatzAnfrage Anfrage);

        [OperationContract]
        NeueMaschinenartAntwort NeueMaschinenart(NeueMaschinenartAnfrage Anfrage);

        [OperationContract]
        NeuMaschinenkaufAntwort NeuMaschinenkauf(NeuMaschinenkaufAnfrage Anfrage);

        [OperationContract]
        NeueVermietungAnKundenAntwort NeueVermietungAnKunden(NeueVermietungAnKundenAnfrage Anfrage);
        //-------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------
        [OperationContract]
        MaterialAnVermietungAnfügenAntwort MaterialAnVermietungAnfügen(MaterialAnVermietungAnfügenAnfrage Anfrage);
        //-------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------
        [OperationContract]
        SaveKundenSetAntwort SaveKundenSet(SaveKundenSetAnfrage anfrage);

        [OperationContract]
        SaveLagerSetAntwort SaveLagerSet(SaveLagerSetAnfrage anfrage);

        [OperationContract]
        SaveMaschinenartSetAntwort SaveMaschinenartSet(SaveMaschinenartSetAnfrage anfrage);

        [OperationContract]
        SaveMaschinenkaufeAntwort SaveMaschinenkaufe(SaveMaschinenkaufeAnfrage anfrage);

        [OperationContract]
        SaveVermitungenSetAntwort SaveVermitungenSet(SaveVermitungenSetAnfrage anfrage);
        //-------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------
    }
}
