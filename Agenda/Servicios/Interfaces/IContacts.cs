using Agenda.DTOs;

namespace Agenda.Servicios.Interfaces
{
    public interface IContacts
    {
        public IEnumerable<responseContactDTO> list(string idUser);
        public mensajeContactDTO delete(int idContact, int idUser);
        public bool Create(createContactDTO newContact, string idUser);
        public bool updateContact(updateContactDTO updateC);
    }
}