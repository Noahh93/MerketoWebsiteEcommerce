using AssignmentMVC.Models;
using System.Data.SqlClient;

namespace AssignmentMVC.Repositories
{
    public class CountryRepository
    {
        private readonly ApplicationDBContext _context;
        public CountryRepository()
        {
            _context = new ApplicationDBContext();
        }

    }
}
