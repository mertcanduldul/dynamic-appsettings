using System.Data;
using Microsoft.Data.SqlClient;

namespace dynamic_appsettings.Repository.Base
{
    public class BaseRepository
    {
        private readonly string _connectionString;

        internal IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_connectionString);
            }
        }


        public BaseRepository()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(ConfigReader.GetConnectionStringsValue("DbConnectionString"));
            var dbPassword = ConfigReader.GetConnectionStringsValue("DbPassword");
            builder.Password = dbPassword;
            _connectionString = builder.ConnectionString;
        }
    }
}