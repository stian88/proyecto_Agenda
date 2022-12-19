using Agenda.Servicios.Interfaces;
using Microsoft.EntityFrameworkCore;
using Agenda.DTOs;
using Agenda.Models;
using Microsoft.AspNetCore.Identity;

namespace Agenda.Servicios
{
    public class ContactsServices : IContacts
    {
        private readonly AppDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public ContactsServices(AppDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IEnumerable<responseContactDTO> list(string idUser)
        {

              var response = _context.Contactos
                .Include(x => x.User)
                .Where(c => c.idUser.Equals(idUser))
                .Select(c => new responseContactDTO(c)
             {
                    Id = c.Id,
                 Name = c.Name,
                 Surname = c.Surname,
                 Tel = c.Tel
                
             })
              .ToList();

            return response;
        }

        public responseContactDTO Get(int idContact)
        {
            var contact = _context.Contactos
                  .Where(c => c.Id == idContact)
                 .Select(t => new responseContactDTO(t))
                 .FirstOrDefault();

            return contact;
        }


        public bool Create(createContactDTO newContact, string idUser)
        {
            var c = new Contactos()
            {
                Name = newContact.Name,
                Surname = newContact.Surname,
                Tel = newContact.Tel,
                CreatedDate = DateTime.Now,
                idUser = idUser, 
            };

            var result = _context.Contactos.Add(c);
            _context.SaveChanges();
            return true;
        }


        public bool Update(updateContactDTO updateC)
        {            
            var Contact = _context.Contactos
                .Where(c => c.Id == updateC.Id)
                .FirstOrDefault();  

            if(Contact != null)
            {
                Contact.Name = updateC.Name;    
                Contact.Surname = updateC.Surname;
                Contact.Tel = updateC.Tel;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public mensajeContactDTO Delete( int idContact)
        {
            
            var contact = _context.Contactos.Where(c => c.Id == idContact)
                .FirstOrDefault();

            if (contact != null)
            {

                _context.Contactos.Remove(contact);
                _context.SaveChanges();
                return new mensajeContactDTO()
                {
                    estado = "Borrado",
                    mensaje = $"El contacto con id: {idContact} fue borrado correctamente"
                };
            }
            else
            {
                return new mensajeContactDTO()
                {
                    estado = "Error",
                    mensaje = $"El contacto con id: {idContact} no existe en la base de datos"
                };
            }
        }
    }
}
