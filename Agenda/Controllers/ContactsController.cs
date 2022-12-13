using Microsoft.AspNetCore.Mvc;
using Agenda.DTOs;
using Agenda.Servicios.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace Agenda.Controllers
{
    public class ContactsController : Controller
    {
        private readonly IContacts _contactsServices;
        public ContactsController(IContacts ContactsServices)
        {
            _contactsServices = ContactsServices;
        }
        public IActionResult Index(int Iduser)
        {
            var reponse = _contactsServices.list(Iduser);
            return View(reponse);
          
        }

        [Authorize]
        public IActionResult getContacts(int idUser)
        {
            var response = _contactsServices.list(idUser);
            return View(response);
        }

        [Authorize]
        public IActionResult deleteContact(int idContact, int idUser)
        {
            var response = _contactsServices.delete(idContact, idUser);

            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult createContact(createContactDTO contact, string idUser)
        {
            var response = _contactsServices.Create(contact, idUser);

            return RedirectToAction("Index");
        }

        [Authorize]
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public IActionResult updateContact(updateContactDTO updateC)
        {
            var response = _contactsServices.updateContact(updateC);

            if (response)

            {

                return RedirectToAction("Index");

            }
            else

            {
                return NotFound();
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
