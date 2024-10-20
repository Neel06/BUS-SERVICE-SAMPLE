using BUS_SERVICE_SAMPLE.CommonConstants;
using BUS_SERVICE_SAMPLE.Interfaces;
using BUS_SERVICE_SAMPLE.Models;
using MySqlConnector;
using System.Data;

namespace BUS_SERVICE_SAMPLE.Repository
{
    public class AdminRepository : IAdminRepository
    {
        private readonly IConfiguration _configuration;

        public AdminRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Admin GetAdminByEmail(string email)
        {
            Admin adminUser = null;

            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            using MySqlConnection connection = new MySqlConnection(connectionString);

            string storeProcedure = "GET_USER_MASTER";

            using MySqlCommand command = new MySqlCommand(storeProcedure, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("EMAIL", email);

            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            using MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                adminUser = new();
                if (!reader.IsDBNull(reader.GetOrdinal("EMAIL")))
                {
                    adminUser.Email = reader.GetString(reader.GetOrdinal("EMAIL"));
                }
                if (!reader.IsDBNull(reader.GetOrdinal("NAME")))
                {
                    adminUser.Name = reader.GetString(reader.GetOrdinal("NAME"));
                }
                if (!reader.IsDBNull(reader.GetOrdinal("PASSWORD")))
                {
                    adminUser.Password= reader.GetString(reader.GetOrdinal("PASSWORD"));
                } 
                if (!reader.IsDBNull(reader.GetOrdinal("ROLE_ID")))
                {
                    adminUser.UserRole = reader.GetInt32(reader.GetOrdinal("ROLE_ID"));
                }
            }

            return adminUser;
            //return _context.Admins.FirstOrDefault(a => a.Email == email && a.UserRole == Constants.UserRole.ADMIN);
        }
    }

}
