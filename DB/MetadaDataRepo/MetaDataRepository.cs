using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.MetadaDataRepo
{
    public class MetadataRepository
    {
        private readonly string _connectionString;

        public MetadataRepository(IConfiguration configuration)
        {
            //_connectionString = "Server=DESKTOP-NHJBSQV\\SQLEXPRESS;Database=EAV_DB;User Id=sa;Password=root;";
            //_connectionString = configuration.GetSection("DBConstring:ConnectionString").Value;
            _connectionString = configuration.GetConnectionString("Local");
        }

        // Pobieranie danych
        public List<Metadata> GetAllMetadata()
        {
            var metadataList = new List<Metadata>();
            string query = "SELECT [metadata_id], [attribute_id], [data_type], [is_requeired], [format], [is_searchable] FROM [EAV_DB].[dbo].[Metadata]";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var metadata = new Metadata
                        {
                            MetadataId = reader.GetInt32(0),
                            AttributeId = reader.GetInt32(1),
                            DataType = reader.GetString(2),
                            IsRequired = reader.GetBoolean(3),
                            Format = reader.GetString(4),
                            IsSearchable = reader.GetBoolean(5)
                        };
                        metadataList.Add(metadata);
                    }
                }
            }

            return metadataList;
        }

        // Dodawanie danych
        public void AddMetadata(Metadata metadata)
        {
            string query = @"INSERT INTO [EAV_DB].[dbo].[Metadata] 
                         ([attribute_id], [data_type], [is_requeired], [format], [is_searchable]) 
                         VALUES (@AttributeId, @DataType, @IsRequired, @Format, @IsSearchable)";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@AttributeId", metadata.AttributeId);
                command.Parameters.AddWithValue("@DataType", metadata.DataType);
                command.Parameters.AddWithValue("@IsRequired", metadata.IsRequired);
                command.Parameters.AddWithValue("@Format", metadata.Format);
                command.Parameters.AddWithValue("@IsSearchable", metadata.IsSearchable);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // Aktualizacja danych
        public void UpdateMetadata(Metadata metadata)
        {
            string query = @"UPDATE [EAV_DB].[dbo].[Metadata] 
                         SET [attribute_id] = @AttributeId, 
                             [data_type] = @DataType, 
                             [is_requeired] = @IsRequired, 
                             [format] = @Format, 
                             [is_searchable] = @IsSearchable 
                         WHERE [metadata_id] = @MetadataId";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MetadataId", metadata.MetadataId);
                command.Parameters.AddWithValue("@AttributeId", metadata.AttributeId);
                command.Parameters.AddWithValue("@DataType", metadata.DataType);
                command.Parameters.AddWithValue("@IsRequired", metadata.IsRequired);
                command.Parameters.AddWithValue("@Format", metadata.Format);
                command.Parameters.AddWithValue("@IsSearchable", metadata.IsSearchable);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
