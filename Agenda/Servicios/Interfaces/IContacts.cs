using Agenda.DTOs;

namespace Agenda.Servicios.Interfaces
{
    public interface IContacts
    {
        public IEnumerable<responseContactDTO> list(string idUser);
        public responseContactDTO Get(int idContact);
        public bool Create(createContactDTO newContact, string idUser);
        public bool Update(updateContactDTO updateC);
        public mensajeContactDTO Delete( int idContact);
    }
}