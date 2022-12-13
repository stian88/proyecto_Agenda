﻿using Agenda.Servicios.Interfaces;
using Microsoft.EntityFrameworkCore;
using Agenda.DTOs;
using Agenda.Models;

namespace Agenda.Servicios
{
    public class ContactsServices : IContacts
    {
        private readonly AppDbContext _context;

        public ContactsServices(AppDbContext context)
        {
            _context = context;
        }

        public responseContactDTO list(int idUser)
        {

            var response = _context.Contactos
                .Include(c => c.Id)
                 .Where(c => c.Id == idUser)
                 .Select(c => new responseContactDTO(c))
                 .FirstOrDefault();

            return response;
        }
    
        public mensajeContactDTO delete (int idContact, int idUser)
        {
            var contact = _context.Contactos.Where(c => c.Id == idContact).FirstOrDefault();

            if(contact != null)
            {

                _context.Contactos.Remove(contact);
                _context.SaveChanges();
                return new mensajeContactDTO()
                {
                    estado = "Borrado",
                    mensaje = $"El contacto con id: {idUser} fue borrado correctamente"
                };
            }
            else
            {
                return new mensajeContactDTO()
                {
                    estado = "Error",
                    mensaje = $"El contacto con id: {idUser} no existe en la base de datos"
                };
            }
        }

        public bool Create(createContactDTO newContact, string idUser)
        {
            var c = new Contactos()
            {
                Name = newContact.Name,
                Surname = newContact.Surname,
                Tel = newContact.Tel,
                CreatedDate = DateTime.Now,
            };

            var result = _context.Contactos.Add(c);
            _context.SaveChanges();
            return true;
        }

        public bool updateContact(updateContactDTO updateC)
        {
            var Contact = _context.Contactos.Include(c => c.Name)
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
    }
}