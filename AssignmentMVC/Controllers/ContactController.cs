using Microsoft.AspNetCore.Mvc;
using AssignmentMVC.Models;
using AssignmentMVC.Repositories;
using AssignmentMVC.ViewModel;

namespace AssignmentMVC.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index(Contact contact)
        {

            return View();
        }
        [HttpPost]
        public ActionResult RegisterContact(ContactViewModel contactWM) //SAVE THE INFO FROM FORM
        {
            if (ModelState.IsValid)
            {
                ContactRepository contactRepository = new ContactRepository();
                Contact contact = new Contact();
                contact.Name = contactWM.Name;
                contact.Email = contactWM.Email;
                contact.Phone = contactWM.Phone;
                contact.CompanyName = contactWM.CompanyName;
                contact.Message = contactWM.Message;
                if (contactWM.SaveMyInfo != null)
                {
                    contact.SaveMyInfo = true;
                }
                else
                {
                    contact.SaveMyInfo = false;
                }

                bool returnContact = contactRepository.SaveContact(contact);
            }


            return View("ThankYouContact");
        }
    }
}
