using BUS_SERVICE_SAMPLE.Models;

namespace BUS_SERVICE_SAMPLE.Interfaces
{
    public interface IAdminRepository
    {
        Admin GetAdminByEmail(string email);
    }

}
