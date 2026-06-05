using Microsoft.Data.SqlClient;
using System.Data;

namespace CustomerEngagementPlatform.DataAccess
{
    public class AdoNetHelper
    {
        private readonly string _connectionString;

        public AdoNetHelper(IConfiguration configuration)
        {
            _connectionString =
                configuration.GetConnectionString("DefaultConnection");
        }

        public int GetCustomerCount()
        {
            int count = 0;

            using (SqlConnection con =
                new SqlConnection(_connectionString))
            {
                string query =
                    "SELECT COUNT(*) FROM Customers";

                SqlCommand cmd =
                    new SqlCommand(query, con);

                con.Open();

                count = (int)cmd.ExecuteScalar();
            }

            return count;
        }
    }
}