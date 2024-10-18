using BUS_SERVICE_SAMPLE.Interfaces;
using BUS_SERVICE_SAMPLE.Models;
using MySqlConnector;
using Microsoft.Extensions.Configuration;
using System.Data;
using BUS_SERVICE_SAMPLE.CommonConstants;
using System.Data.Common;

namespace BUS_SERVICE_SAMPLE.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public StudentRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void AddStudent(Student student)
        {
            //_context.Students.Add(student);
            //_context.SaveChanges();

            using var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            string query = "INS_USER_MASTER";
            using var command = new MySqlCommand(query, connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("_EMAIL", student.Email);
            command.Parameters.AddWithValue("_STUDENT_ID", student.StudentID);
            command.Parameters.AddWithValue("_NAME", student.Name);
            command.Parameters.AddWithValue("_PASSWORD", student.Password);
            command.Parameters.AddWithValue("_BIRTH_DATE", student.BirthDate);
            command.Parameters.AddWithValue("_ROLE_ID", Constants.UserRole.STUDENT);

            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            command.ExecuteNonQuery();
        }

        public Student GetStudentByEmail(string email)
        {
            Student student = null;
            using var connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection"));

            string query = "GET_USER_MASTER";
            using var command = new MySqlCommand(query, connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("EMAIL", email);

            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            MySqlDataReader reader = command.ExecuteReader();
            //using IDataReader reader = mySqlDataReader;

            while (reader.Read())
            {
                student = new Student();
                if (!reader.IsDBNull(reader.GetOrdinal("EMAIL")))
                {
                    student.Email = reader.GetString(reader.GetOrdinal("EMAIL"));
                }
                if (!reader.IsDBNull(reader.GetOrdinal("STUDENT_ID")))
                {
                    student.StudentID = reader.GetString(reader.GetOrdinal("STUDENT_ID"));
                }
                if (!reader.IsDBNull(reader.GetOrdinal("NAME")))
                {
                    student.Name = reader.GetString(reader.GetOrdinal("NAME"));
                }
                if (!reader.IsDBNull(reader.GetOrdinal("ROLE_ID")))
                {
                    student.UserRole = reader.GetInt32(reader.GetOrdinal("ROLE_ID"));
                }
                if (!reader.IsDBNull(reader.GetOrdinal("PASSWORD")))
                {
                    student.Password = reader.GetString(reader.GetOrdinal("PASSWORD"));
                }
                if (!reader.IsDBNull(reader.GetOrdinal("BIRTH_DATE")))
                {
                    student.BirthDate = reader.GetDateTime(reader.GetOrdinal("BIRTH_DATE"));
                }
            }
            return student;
        }
    }

}
