using BUS_SERVICE_SAMPLE.Models;

namespace BUS_SERVICE_SAMPLE.Interfaces
{
    public interface IAuthenticationService
    {
        bool RegisterStudent(StudentRegistrationViewModel model);

        Student LoginStudent(string email, string password);

        Admin LoginAdmin(string email, string password);
    }

}
