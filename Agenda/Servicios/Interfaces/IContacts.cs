using Agenda.DTOs;

namespace Agenda.Servicios.Interfaces
{
    public interface IContacts
    {
        public Task <IEnumerable<responseContactDTO>> list(string idUser);
        public Task <responseContactDTO> Get(int idContact);
        public Task<bool> Create(createContactDTO newContact, string idUser);
        public Task<bool> Update(updateContactDTO updateC, string idUser);
        public Task<mensajeContactDTO> Delete( int idContact);
    }
}