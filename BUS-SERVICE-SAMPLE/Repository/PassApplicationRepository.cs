using BUS_SERVICE_SAMPLE.Interfaces;
using BUS_SERVICE_SAMPLE.Models;
using MySqlConnector;
using System.Data;

namespace BUS_SERVICE_SAMPLE.Repository
{
    public class PassApplicationRepository : IPassApplicationRepository
    {
        private readonly IConfiguration _configuration;

        public PassApplicationRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void AddApplication(PassApplication pass)
        {
            using var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            string query = "INS_PASS_APPLICATION";
            using var command = new MySqlCommand(query, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("APPLICATION_ID", pass.ApplicationId);
            command.Parameters.AddWithValue("APPLICATION_DATE", pass.ApplicationDate.Date);
            command.Parameters.AddWithValue("ACADEMIC_YEAR", pass.AcademicYear);
            command.Parameters.AddWithValue("EMAIL", pass.Email);
            command.Parameters.AddWithValue("NAME", pass.FullName);
            command.Parameters.AddWithValue("ADDRESS_CURRENT", pass.AddressCurrent);
            command.Parameters.AddWithValue("ADDRESS_PERMANANT", pass.AddressPermanant);
            command.Parameters.AddWithValue("BLOCK_CURRENT", pass.BlockCurrent);
            command.Parameters.AddWithValue("BLOCK_PERMANANT", pass.BlockPermanant);
            command.Parameters.AddWithValue("CATEGORY", pass.Category);
            command.Parameters.AddWithValue("CLASS", pass.Class);
            command.Parameters.AddWithValue("CLASS_GROUP", pass.ClassGroup);
            command.Parameters.AddWithValue("CLUSTER_CURRENT", pass.ClusterCurrent);
            command.Parameters.AddWithValue("CLUSTER_PERMANANT", pass.ClusterPermanant);
            command.Parameters.AddWithValue("COUNTER_NAME", pass.CounterName);
            command.Parameters.AddWithValue("CREATED_DATETIME", pass.Created_DateTime);
            command.Parameters.AddWithValue("CREATED_USER_ID", pass.Created_UserId);
            command.Parameters.AddWithValue("DISTRICT_CURRENT", pass.DistrictCurrent);
            command.Parameters.AddWithValue("DEPOSIT_AMOUNT", pass.DepositAmount);
            command.Parameters.AddWithValue("DATE_OF_BIRTH", pass.DateOfBirth);
            command.Parameters.AddWithValue("DISTRICT_PERMANANT", pass.DistrictPermanant);
            command.Parameters.AddWithValue("FROM_LOCATION", pass.FromLocation);
            command.Parameters.AddWithValue("GENDER", pass.Gender);
            command.Parameters.AddWithValue("ICARD_AMOUNT", pass.IcardAmount);
            command.Parameters.AddWithValue("IS_ACTIVE", pass.IsActive);
            command.Parameters.AddWithValue("IS_DEPOSIT", pass.IsDeposit);
            command.Parameters.AddWithValue("IS_RURAL", pass.IsRural);
            command.Parameters.AddWithValue("MOBILE_NUMBER", pass.MobileNumber);
            command.Parameters.AddWithValue("NUMBER_OF_DAYS", pass.NumberOfDays);
            command.Parameters.AddWithValue("PASS_DURATION", pass.PassDuration);
            command.Parameters.AddWithValue("PASS_AMOUNT", pass.PassAmount);
            command.Parameters.AddWithValue("PASS_FROM", pass.PassFrom);
            command.Parameters.AddWithValue("PASS_TO", pass.PassTo);
            command.Parameters.AddWithValue("PASS_TYPE", pass.PassType);
            command.Parameters.AddWithValue("PAYABLE_AMOUNT", pass.PayableAmount);
            command.Parameters.AddWithValue("PAYMENT_METHOD", pass.PaymentMethod);
            command.Parameters.AddWithValue("ROLL_NUMBER", pass.RollNumber);
            command.Parameters.AddWithValue("ROUTE", pass.Route);
            command.Parameters.AddWithValue("SAME_AS_PERMANANT", pass.SameAsPermanant);
            command.Parameters.AddWithValue("SCHOOL_ADDRESS", pass.SchoolAddress);
            command.Parameters.AddWithValue("SCHOOL_NAME", pass.SchoolName);
            command.Parameters.AddWithValue("SECTION", pass.Section);
            command.Parameters.AddWithValue("STAGE", pass.Stage);
            command.Parameters.AddWithValue("STATUS", pass.Status);
            command.Parameters.AddWithValue("STUDENT_ID", pass.StudentID);
            command.Parameters.AddWithValue("TERM", pass.Term);
            command.Parameters.AddWithValue("TERM_FROM", pass.TermFrom);
            command.Parameters.AddWithValue("TERM_TO", pass.TermTo);
            command.Parameters.AddWithValue("TOTAL_PASS_AMOUNT", pass.TotalPassAmount);
            command.Parameters.AddWithValue("TO_LOCATION", pass.ToLocation);
            command.Parameters.AddWithValue("UPDATED_DATETIME", pass.Updated_DateTime);
            command.Parameters.AddWithValue("UPDATED_USER_ID", pass.Updated_UserId);
            //command.Parameters.AddWithValue("USER_ROLE", pass.UserRole);
            command.Parameters.AddWithValue("VILLAGE_CURRENT", pass.VillageCurrent);
            command.Parameters.AddWithValue("VILLAGE_PERMANANT", pass.VillagePermanant);

            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            command.ExecuteNonQuery();
        }

        public List<PassApplication> GetApplicationsByStudentId(string studentId)
        {
            //return _context.PassApplications.Where(a => a.StudentID == studentId).ToList();
            PassApplication application = null;
            List<PassApplication> apps = new List<PassApplication>();
            using var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            string query = "GET_APPLICAITION_BY_STD_ID";
            using var command = new MySqlCommand(query, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("STUDENT_ID", studentId);

            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            MySqlDataReader reader = command.ExecuteReader();
            //using IDataReader reader = mySqlDataReader;

            while (reader.Read())
            {
                application = FetchApplicationRecordsForReader(reader);
                apps.Add(application);
            }
            return apps;
        }

        protected PassApplication FetchApplicationRecordsForReader(MySqlDataReader reader)
        {
            var application = new PassApplication();
            if (!reader.IsDBNull(reader.GetOrdinal("ACADEMIC_YEAR")))
            {
                application.AcademicYear = reader.GetString(reader.GetOrdinal("ACADEMIC_YEAR"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("EMAIL")))
            {
                application.Email = reader.GetString(reader.GetOrdinal("EMAIL"));
            }
            //if (!reader.IsDBNull(reader.GetOrdinal("ROLE_ID")))
            //{
            //    application.UserRole = reader.GetInt32(reader.GetOrdinal("ROLE_ID"));
            //}
            if (!reader.IsDBNull(reader.GetOrdinal("NAME")))
            {
                application.FullName = reader.GetString(reader.GetOrdinal("NAME"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("ROUTE")))
            {
                application.Route = reader.GetString(reader.GetOrdinal("ROUTE"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("IS_RURAL")))
            {
                application.IsRural = reader.GetBoolean(reader.GetOrdinal("IS_RURAL"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("ADDRESS_CURRENT")))
            {
                application.AddressCurrent = reader.GetString(reader.GetOrdinal("ADDRESS_CURRENT"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("ADDRESS_PERMANANT")))
            {
                application.AddressPermanant = reader.GetString(reader.GetOrdinal("ADDRESS_PERMANANT"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("APPLICATION_DATE")))
            {
                application.ApplicationDate = reader.GetDateTime(reader.GetOrdinal("APPLICATION_DATE"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("APPLICATION_ID")))
            {
                application.ApplicationId = reader.GetInt32(reader.GetOrdinal("APPLICATION_ID"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("BLOCK_CURRENT")))
            {
                application.BlockCurrent = reader.GetString(reader.GetOrdinal("BLOCK_CURRENT"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("BLOCK_PERMANANT")))
            {
                application.BlockPermanant = reader.GetString(reader.GetOrdinal("BLOCK_PERMANANT"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("CATEGORY")))
            {
                application.Category = reader.GetString(reader.GetOrdinal("CATEGORY"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("CLASS")))
            {
                application.Class = reader.GetString(reader.GetOrdinal("CLASS"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("CLASS_GROUP")))
            {
                application.ClassGroup = reader.GetString(reader.GetOrdinal("CLASS_GROUP"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("CLUSTER_CURRENT")))
            {
                application.ClusterCurrent = reader.GetString(reader.GetOrdinal("CLUSTER_CURRENT"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("COUNTER_NAME")))
            {
                application.CounterName = reader.GetString(reader.GetOrdinal("COUNTER_NAME"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("CREATED_DATETIME")))
            {
                application.Created_DateTime = reader.GetDateTime(reader.GetOrdinal("CREATED_DATETIME"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("CREATED_USER_ID")))
            {
                application.Created_UserId = reader.GetString(reader.GetOrdinal("CREATED_USER_ID"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("DISTRICT_CURRENT")))
            {
                application.DistrictCurrent = reader.GetString(reader.GetOrdinal("DISTRICT_CURRENT"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("DATE_OF_BIRTH")))
            {
                application.DateOfBirth = reader.GetDateTime(reader.GetOrdinal("DATE_OF_BIRTH"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("DEPOSIT_AMOUNT")))
            {
                application.DepositAmount = reader.GetDecimal(reader.GetOrdinal("DEPOSIT_AMOUNT"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("DISTRICT_PERMANANT")))
            {
                application.DistrictPermanant = reader.GetString(reader.GetOrdinal("DISTRICT_PERMANANT"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("FROM_LOCATION")))
            {
                application.FromLocation = reader.GetString(reader.GetOrdinal("FROM_LOCATION"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("GENDER")))
            {
                application.Gender = reader.GetString(reader.GetOrdinal("GENDER"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("ICARD_AMOUNT")))
            {
                application.IcardAmount = reader.GetInt32(reader.GetOrdinal("ICARD_AMOUNT"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("IS_ACTIVE")))
            {
                application.IsActive = reader.GetBoolean(reader.GetOrdinal("IS_ACTIVE"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("IS_DEPOSIT")))
            {
                application.IsDeposit = reader.GetBoolean(reader.GetOrdinal("IS_DEPOSIT"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("MOBILE_NUMBER")))
            {
                application.MobileNumber = reader.GetString(reader.GetOrdinal("MOBILE_NUMBER"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("NUMBER_OF_DAYS")))
            {
                application.NumberOfDays = reader.GetInt32(reader.GetOrdinal("NUMBER_OF_DAYS"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("PASS_DURATION")))
            {
                application.PassDuration = reader.GetString(reader.GetOrdinal("PASS_DURATION"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("PASS_AMOUNT")))
            {
                application.PassAmount = reader.GetInt32(reader.GetOrdinal("PASS_AMOUNT"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("PASS_FROM")))
            {
                application.PassFrom = reader.GetDateTime(reader.GetOrdinal("PASS_FROM"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("PASS_TO")))
            {
                application.PassTo = reader.GetDateTime(reader.GetOrdinal("PASS_TO"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("PASS_TYPE")))
            {
                application.PassType = reader.GetString(reader.GetOrdinal("PASS_TYPE"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("PAYABLE_AMOUNT")))
            {
                application.PayableAmount = reader.GetInt32(reader.GetOrdinal("PAYABLE_AMOUNT"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("PAYMENT_METHOD")))
            {
                application.PaymentMethod = reader.GetString(reader.GetOrdinal("PAYMENT_METHOD"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("ROLL_NUMBER")))
            {
                application.RollNumber = reader.GetString(reader.GetOrdinal("ROLL_NUMBER"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("SAME_AS_PERMANANT")))
            {
                application.SameAsPermanant = reader.GetBoolean(reader.GetOrdinal("SAME_AS_PERMANANT"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("SCHOOL_ADDRESS")))
            {
                application.SchoolAddress = reader.GetString(reader.GetOrdinal("SCHOOL_ADDRESS"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("SCHOOL_NAME")))
            {
                application.SchoolName = reader.GetString(reader.GetOrdinal("SCHOOL_NAME"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("SECTION")))
            {
                application.Section = reader.GetString(reader.GetOrdinal("SECTION"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("STAGE")))
            {
                application.Stage = reader.GetInt32(reader.GetOrdinal("STAGE"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("STATUS")))
            {
                application.Status = reader.GetString(reader.GetOrdinal("STATUS"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("STUDENT_ID")))
            {
                application.StudentID = reader.GetString(reader.GetOrdinal("STUDENT_ID"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("TERM")))
            {
                application.Term = reader.GetString(reader.GetOrdinal("TERM"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("TERM_FROM")))
            {
                application.TermFrom = reader.GetDateTime(reader.GetOrdinal("TERM_FROM"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("TERM_TO")))
            {
                application.TermTo = reader.GetDateTime(reader.GetOrdinal("TERM_TO"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("UPDATED_DATETIME")))
            {
                application.Updated_DateTime = reader.GetDateTime(reader.GetOrdinal("UPDATED_DATETIME"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("UPDATED_USER_ID")))
            {
                application.Updated_UserId = reader.GetString(reader.GetOrdinal("UPDATED_USER_ID"));
            }
            //if (!reader.IsDBNull(reader.GetOrdinal("USER_ROLE")))
            //{
            //    application.UserRole = reader.GetInt32(reader.GetOrdinal("USER_ROLE"));
            //}
            if (!reader.IsDBNull(reader.GetOrdinal("VILLAGE_CURRENT")))
            {
                application.VillageCurrent = reader.GetString(reader.GetOrdinal("VILLAGE_CURRENT"));
            }
            if (!reader.IsDBNull(reader.GetOrdinal("VILLAGE_PERMANANT")))
            {
                application.VillagePermanant = reader.GetString(reader.GetOrdinal("VILLAGE_PERMANANT"));
            };
            return application;
        }

        public PassApplication GetApplicationById(int applicationId)
        {
            PassApplication application = null;
            using var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            string query = "GET_APPLICAITION_BY_ID";
            using var command = new MySqlCommand(query, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("APPLICATION_ID", applicationId);

            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                application = FetchApplicationRecordsForReader(reader);
            }
            return application;
        }

        public void UpdateApplication(PassApplication application)
        {
            string query = _configuration.GetConnectionString("DefaultConnection");
            using MySqlConnection connection = new (query);
            string procedureName = "UPDATE_APPLICTION";
            using MySqlCommand command = new MySqlCommand(procedureName,connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("APPLICATION_ID", application.ApplicationId);
            command.Parameters.AddWithValue("STATUS", application.Status);
            
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            command.ExecuteNonQuery();
        }

        public List<PassApplication> GetAllApplications()
        {
            PassApplication application = null;
            List<PassApplication> apps = new();
            using var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            string query = "GET_ALL_APPLICATIONS";
            using var command = new MySqlCommand(query, connection);
            command.CommandType = CommandType.StoredProcedure;
            //command.Parameters.AddWithValue("STUDENT_ID", studentId);
                
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                application = FetchApplicationRecordsForReader(reader);
                apps.Add(application);
            }
            return apps;
        }
    }

}
