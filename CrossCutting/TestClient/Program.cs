using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossCutting.Mietmaschinendatenbank_DataClasses;
using System.Data.SqlClient;
using System.Data.EntityClient;

namespace Crosscutting.CrosscuttingTestClient
{
    class Program
    {
        
        static void Main(string[] args)
        {
            MietmaschinendatenbankModelContainer modell = null;
            try
            {
                // Specify the provider name, server and database.
                string providerName = "System.Data.SqlClient";
                string serverName = ".\\sqlexpress";
                string databaseName = "mietdatenbank";

                // Initialize the connection string builder for the
                // underlying provider.
                SqlConnectionStringBuilder sqlBuilder =
                    new SqlConnectionStringBuilder();

                // Set the properties for the data source.
                sqlBuilder.DataSource = serverName;
                sqlBuilder.InitialCatalog = databaseName;
                sqlBuilder.IntegratedSecurity = true;

                // Build the SqlConnection connection string.
                string providerString = sqlBuilder.ToString();

                // Initialize the EntityConnectionStringBuilder.
                EntityConnectionStringBuilder entityBuilder =
                    new EntityConnectionStringBuilder();

                //Set the provider name.
                entityBuilder.Provider = providerName;

                // Set the provider-specific connection string.
                entityBuilder.ProviderConnectionString = providerString;

                // Set the Metadata location.
                entityBuilder.Metadata = @"E:\Projekte\Git\CSHARP_MVVM_SQL_WCF_MachineryRentalService\CrossCutting\Mietmaschinendatenbank_DataClasses\bin\Debug\MietmaschinendatenbankModel.csdl|         
                                           E:\Projekte\Git\CSHARP_MVVM_SQL_WCF_MachineryRentalService\CrossCutting\Mietmaschinendatenbank_DataClasses\bin\Debug\MietmaschinendatenbankModel.ssdl|         
                                           E:\Projekte\Git\CSHARP_MVVM_SQL_WCF_MachineryRentalService\CrossCutting\Mietmaschinendatenbank_DataClasses\bin\Debug\MietmaschinendatenbankModel.msl";
                Console.WriteLine(entityBuilder.ToString());

                EntityConnection conn = new EntityConnection(entityBuilder.ToString());
                modell = new MietmaschinendatenbankModelContainer(conn);
                //modell = new MietmaschinendatenbankModelContainer();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                Console.ReadLine();
            }

            Kunde DieserKunde = new Kunde();
            DieserKunde.Kundenname = "Simon";
            DieserKunde.Kundengesamtumsatz = 0;

            //modell.KundenlisteSatz.AddObject(DieserKunde);


            try
            {
                Console.Write(modell.Connection.ConnectionString);
                //---------------------------------
                try
                {
                    var abfrage1 = from Kundendaten in modell.KundenlisteSatz select Kundendaten;
                    object test = abfrage1.ToList();
                    foreach (Kunde testKunde in abfrage1)
                    {
                        Console.WriteLine(testKunde);
                        if (testKunde.Kundenname == "Sa")
                        {
                            testKunde.Kundenname = "Sandra";
                        }
                    }
                }
                catch(Exception ex)
                {
                    Console.Write("Error:" + ex.ToString());
                }
                //---------------------------------
                try
                {
                    var abfrage2 = from Lager in modell.LagerbestandSatz select Lager;
                    object test = abfrage2.ToList();
                }
                catch(Exception ex)
                {
                    Console.Write("Error:" + ex.ToString());
                }
                //---------------------------------
                try
                {
                    var abfrage3 = from Maschinenart in modell.MaschinenartenlisteSatz select Maschinenart;
                    object test = abfrage3.ToList();
                }
                catch(Exception ex)
                {
                    Console.Write("Error:" + ex.ToString());
                }
                //---------------------------------
                try
                {
                    var abfrage4 = from Maschinenkauf in modell.MaschinenkauflisteSatz select Maschinenkauf;
                    object test = abfrage4.ToList();
                }
                catch(Exception ex)
                {
                    Console.Write("Error:" + ex.ToString());
                }
                //---------------------------------
                try
                {
                    var abfrage5 = from Vermietung in modell.VermietungslisteSatz select Vermietung;
                    object test = abfrage5.ToList();
                }
                catch(Exception ex)
                {
                    Console.Write("Error:" + ex.ToString());
                }
                //---------------------------------
                
                modell.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(DieserKunde.ToString() + " | " + ex.Message.ToString());
                Console.ReadLine();
            }
        }
    }
}
