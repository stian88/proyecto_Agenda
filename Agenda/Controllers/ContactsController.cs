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

        [Authorize]
        public IActionResult Index()
        {
            var idUserCurrent = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var reponse = _contactsServices.list(idUserCurrent);

            return View(reponse);
          
        }

        [Authorize]
        public IActionResult getContact(int idContact)

        {

            var response = _contactsServices.Get(idContact);
            return View(response);
        }


        [Authorize]
        public IActionResult getContacts(string idUser)
        {
            var response = _contactsServices.list(idUser);
            return View(response);
        }
        

        [Authorize]
        public IActionResult createContact(createContactDTO contact, string idUser)
        {
            var idUserCurrent = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var response = _contactsServices.Create(contact, idUserCurrent);

            return RedirectToAction("Index");
        }


        [Authorize]
        public IActionResult Edit(int Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var contact = _contactsServices.Get(Id);

            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }


        [Authorize]
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public IActionResult updateContact(updateContactDTO update, string idUser)
        {
            var idUserCurrent = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var response = _contactsServices.Update(update);

            if (response)

            {

                return RedirectToAction("Index");

            }
            else

            {
                return NotFound();
            }
        }

        public IActionResult New()
        {
            return View();
        }


        [Authorize]
        public IActionResult deleteContact(int Id)
        {            
            var response = _contactsServices.Delete(Id);

            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }
    }
}
