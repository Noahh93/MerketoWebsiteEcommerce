using AssignmentMVC.Models;
using System.Data.SqlClient;

namespace AssignmentMVC.Repositories
{
    public class UserRepository
    {
        private readonly ApplicationDBContext _context;
        public UserRepository()
        {
            _context = new ApplicationDBContext();
        }

        public bool SaveUser(AppUser user)
        {
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }
        
    }
}
