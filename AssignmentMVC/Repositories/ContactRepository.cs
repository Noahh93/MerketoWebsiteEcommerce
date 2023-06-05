using AssignmentMVC.Models;
using AssignmentMVC.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentMVC.Repositories
{
    public class ContactRepository
    {
        private readonly ApplicationDBContext _context;

        public ContactRepository() 
        {
            _context = new ApplicationDBContext();
        }
        public bool SaveContact(Contact contact)
        {
            try
            {
                _context.Contacts.Add(contact);
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
