using Agenda.Models;

namespace Agenda.DTOs
{
    public class responseContactDTO
    {
        public responseContactDTO() { }

        public responseContactDTO(Contactos c)
        {
            Id = c.Id;
            Name = c.Name;
            Surname = c.Surname;
            Tel = c.Tel;
        }

        public int Id { get; set; }
        public string Name { get; set; }    
        public string Surname { get; set; }
        public int Tel { get; set; }
    }
}
