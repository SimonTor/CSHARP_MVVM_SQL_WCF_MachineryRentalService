using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crosscutting.MietmaterialdatenbankKlassen;
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
                entityBuilder.Metadata = @"K:\C#\Baumaschinenverleih\Software\CrossCutting\Mietmaschinendatenbank_DataClasses\bin\Debug\MietmaschinendatenbankModel.csdl|         
                                           K:\C#\Baumaschinenverleih\Software\CrossCutting\Mietmaschinendatenbank_DataClasses\bin\Debug\MietmaschinendatenbankModel.ssdl|         
                                           K:\C#\Baumaschinenverleih\Software\CrossCutting\Mietmaschinendatenbank_DataClasses\bin\Debug\MietmaschinendatenbankModel.msl";
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
                var abfrage = from Kundendaten in modell.KundenlisteSatz select Kundendaten;

                foreach (Kunde testKunde in abfrage)
                {
                    Console.WriteLine(testKunde);
                    if (testKunde.Kundenname == "Sa")
                    {
                        testKunde.Kundenname = "Sandra";                        
                    }
                }
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
