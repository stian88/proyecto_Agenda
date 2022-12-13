using Agenda.DTOs;


namespace Agenda.Servicios.Interfaces
{
    public interface IContacts
    {
        public responseContactDTO list(int idUser);
        public mensajeContactDTO delete(int idContact, int idUser);
        public bool Create(createContactDTO newContact, string idUser);
        public bool updateContact(updateContactDTO updateC);
    }
}