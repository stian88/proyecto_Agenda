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
        public async Task<IActionResult> Index()
        {
            var idUserCurrent = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var reponse = await _contactsServices.list(idUserCurrent);

            return View(reponse);
          
        }

        [Authorize]
        public async Task<IActionResult> getContact(int idContact)

        {

            var response = await _contactsServices.Get(idContact);
            return View(response);
        }


        [Authorize]
        public async Task<IActionResult> getContacts(string idUser)
        {
            var response = await _contactsServices.list(idUser);
            return View(response);
        }
        

        [Authorize]
        public async Task<IActionResult> createContact(createContactDTO contact, string idUser)
        {
            var idUserCurrent = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var response = await _contactsServices.Create(contact, idUserCurrent);

            return RedirectToAction("Index");
        }


        [Authorize]
        public async Task<IActionResult> Edit(int Id)
        {
            if (Id == 0)
            {
                return NotFound();
            }

            var contact = await _contactsServices.Get(Id);

            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }


        [Authorize]
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> updateContact(updateContactDTO update, string idUser)
        {
            var idUserCurrent = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var response = await _contactsServices.Update(update, idUser);

            if (response)

            {

                return RedirectToAction("Index");

            }
            else

            {
                return NotFound();
            }
        }

       
        [Authorize]
        public async Task<IActionResult> deleteContact(int Id)
        {            
            var response = await _contactsServices.Delete(Id);

            return RedirectToAction("Index");
        }


        public IActionResult New()
        {
            return View();
        }


        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }
    }
}
