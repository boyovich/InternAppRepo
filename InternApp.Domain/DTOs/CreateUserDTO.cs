﻿using InternApp.Domain;

namespace InternApp.Service.Service
{
    public class CreateUserDTO
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyId { get; set; }
        public string CompanyName { get; set; }
        public DateTime DOB { get; set; }
        public Position position { get; set; }
        public string PhoneNumber { get; set; }
    }
}