using Microsoft.AspNetCore.Mvc;
using Agenda.DTOs;
using Agenda.Servicios.Interfaces;
using Agenda.Controllers;

namespace Agenda.Servicios.Interfaces
{
    public interface IContacts
    {
        public IEnumerable<responseContactDTO> list(int idUser);
        public mensajeContactDTO delete(int idContact, int idUser);
        public bool Create(createContactDTO newContact, string idUser);
        public bool updateContact(updateContactDTO updateC);
    }
}