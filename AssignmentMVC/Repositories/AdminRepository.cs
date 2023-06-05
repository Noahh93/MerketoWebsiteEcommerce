using AssignmentMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace AssignmentMVC.Repositories
{

    public class AdminRepository
    {
        private readonly ApplicationDBContext _context;


        public AdminRepository()
        {
            _context = new ApplicationDBContext();
        }

        public List<AppUser> GetAllUsers()
        {
            List<AppUser> users = _context.Users.ToList();
            return users;
        }
    }
}
