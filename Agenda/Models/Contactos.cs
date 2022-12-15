using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agenda.Models
{
    public class Contactos
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Surname { get; set; } 
        public int Tel { get; set; }
        public DateTime CreatedDate { get; set; }

        [Required]
        [ForeignKey("User")]
        public string idUser { get; set; }

        public virtual IdentityUser User { get; set; }
    }
}  