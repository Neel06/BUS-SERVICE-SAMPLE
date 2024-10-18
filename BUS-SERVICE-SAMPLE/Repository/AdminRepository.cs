using BUS_SERVICE_SAMPLE.CommonConstants;
using BUS_SERVICE_SAMPLE.Interfaces;
using BUS_SERVICE_SAMPLE.Models;

namespace BUS_SERVICE_SAMPLE.Repository
{
    public class AdminRepository : IAdminRepository
    {
        private readonly AppDbContext _context;

        public AdminRepository(AppDbContext context)
        {
            _context = context;
        }

        public Admin GetAdminByEmail(string email)
        {
            return _context.Admins.FirstOrDefault(a => a.Email == email && a.UserRole == Constants.UserRole.ADMIN);
        }
    }

}
