using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.EntityClient;

namespace CrossCutting.Mietmaschinendatenbank_DataClasses
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
                entityBuilder.Metadata = @"E:\Projekte\Git\CSHARP_MVVM_SQL_WCF_MachineryRentalService\CrossCutting\Mietmaschinendatenbank_DataClasses\bin\Debug\MietmaschinendatenbankModel.csdl|         
                                           E:\Projekte\Git\CSHARP_MVVM_SQL_WCF_MachineryRentalService\CrossCutting\Mietmaschinendatenbank_DataClasses\bin\Debug\MietmaschinendatenbankModel.ssdl|         
                                           E:\Projekte\Git\CSHARP_MVVM_SQL_WCF_MachineryRentalService\CrossCutting\Mietmaschinendatenbank_DataClasses\bin\Debug\MietmaschinendatenbankModel.msl";
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
