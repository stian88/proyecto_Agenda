using Microsoft.AspNetCore.Mvc;
using Agenda.DTOs;
using Agenda.Servicios.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Agenda.Servicios;

namespace Agenda.Controllers
{
    public class ContactsController : Controller
    {
        private readonly IContacts _contactsServices;
        private readonly UserManager<IdentityUser> _userManager;

        public ContactsController(IContacts contactsServices, UserManager<IdentityUser> userManager)

        {
            _contactsServices = contactsServices;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var idUserCurrent = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var reponse = _contactsServices.list(idUserCurrent);

            return View(reponse);
          
        }

  
        public IActionResult getContacts(string idUser)
        {
            var response = _contactsServices.list(idUser);
            return View(response);
        }

        
        public IActionResult deleteContact(int idContact, int idUser)
        {
            var response = _contactsServices.delete(idContact, idUser);

            return RedirectToAction("Index");
        }

      
        public IActionResult createContact(createContactDTO contact, string idUser)
        {
            var response = _contactsServices.Create(contact, idUser);

            return RedirectToAction("Index");
        }

       
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
