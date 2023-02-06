using InternApp.Domain;

namespace InternApp.Service.Service
{
    public class UpdateUserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid CompanyId { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public Position Position { get; set; }
        public string PhoneNumber { get; set; }
    }
}