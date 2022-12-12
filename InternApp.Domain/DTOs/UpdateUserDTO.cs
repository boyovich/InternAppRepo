using InternApp.Domain;

namespace InternApp.Service.Service
{
    public class UpdateUserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Position Position { get; set; }
        public string PhoneNumber { get; set; }
    }
}