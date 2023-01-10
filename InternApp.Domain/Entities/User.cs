using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace InternApp.Domain.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public Guid CompanyId { get; set; }
        public virtual Company Company { get; set;}
        public DateTime DateOfBirth { get; set; }
        public Position Position { get; set; }
        public string PhoneNumber { get; set; }          
    }
    
}
