using BUS_SERVICE_SAMPLE.CommonConstants;
using BUS_SERVICE_SAMPLE.Interfaces;
using BUS_SERVICE_SAMPLE.Models;
using BUS_SERVICE_SAMPLE.Repository;

namespace BUS_SERVICE_SAMPLE.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IAdminRepository _adminRepository;

        public AuthenticationService(IStudentRepository studentRepository, IAdminRepository adminRepository)
        {
            _studentRepository = studentRepository;
            _adminRepository = adminRepository;
        }

        public bool RegisterStudent(StudentRegistrationViewModel model)
        {
            if (string.IsNullOrEmpty(model.Email))
            {
                ArgumentException.ThrowIfNullOrEmpty(model.Email);
            }

            if (_studentRepository.GetStudentByEmail(model.Email) != null)
            {
                throw new Exception("Student already exists.");
            }

            var student = new Student
            {
                StudentID = model.StudentID,
                Name = model.Name,
                Email = model.Email,
                BirthDate = model.BirthDate,
                Password = HashPassword(model.Password)
            };

            _studentRepository.AddStudent(student);
            return true;
        }

        public Student LoginStudent(string email, string password)
        {
            if (string.IsNullOrEmpty(email))
                ArgumentNullException.ThrowIfNullOrEmpty(email);

            if (string.IsNullOrEmpty(password))
                ArgumentNullException.ThrowIfNullOrEmpty(password);

            var student = _studentRepository.GetStudentByEmail(email);
            if (student == null || !VerifyPassword(student.Password, password))
            {
                throw new Exception("Invalid login credentials.");
            }

            return student;
        }

        public Admin LoginAdmin(string email, string password)
        {
            var admin = _adminRepository.GetAdminByEmail(email);
            if (admin == null || !VerifyPassword(admin.Password, password) || admin.UserRole != Constants.UserRole.ADMIN)
            {
                throw new Exception("Invalid login credentials.");
            }

            return admin;
        }

        private string HashPassword(string password)
        {
            // Here you'd have a real password hashing mechanism, e.g., bcrypt or PBKDF2.
            return password; // Placeholder for demonstration.
        }

        private bool VerifyPassword(string hashedPassword, string password)
        {
            // In a real-world app, you'd compare the hashed password with the stored hash.
            return hashedPassword == password;
        }
    }

}
