using BUS_SERVICE_SAMPLE.Models;

namespace BUS_SERVICE_SAMPLE.Interfaces
{
    public interface IStudentRepository
    {
        void AddStudent(Student student);
        Student GetStudentByEmail(string email);
    }

}
