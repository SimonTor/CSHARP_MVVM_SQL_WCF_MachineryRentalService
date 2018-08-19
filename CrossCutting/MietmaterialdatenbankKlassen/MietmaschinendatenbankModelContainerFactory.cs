using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.EntityClient;

namespace Crosscutting.MietmaterialdatenbankKlassen
{
    public class MietmaschinendatenbankModelContainerFactory
    {
        public static MietmaschinendatenbankModelContainer MietmaschinendatenbankModelContainerFactoryGenerator()
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

                return modell;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                Console.ReadLine();

                return null;
            }
        }   
    }
}
