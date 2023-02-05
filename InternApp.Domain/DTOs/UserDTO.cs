namespace InternApp.Domain.DTOs
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string CompanyName { get; set; }
        public string Position { get; set; }
        public string PhoneNumber { get; set; }
    }
}


