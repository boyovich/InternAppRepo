using InternApp.Domain;
using InternApp.Domain.Entities;
using InternApp.Domain.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace InternApp.Service.Service
{
    public class UserService : IUserService
    {
        private InternDbContext _context;
        private Random random = new Random();
        public UserService(InternDbContext context)
        {
            _context = context;
        }
        
        public User CreateUser(CreateUserDTO createUserDTO)
        {
            var user = new User();
            user.FirstName= createUserDTO.FirstName;
            user.LastName= createUserDTO.LastName;
            user.PhoneNumber= createUserDTO.PhoneNumber;
            user.CompanyName= createUserDTO.CompanyName;

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            user.Id = new string(Enumerable.Repeat(chars, 20).Select(s => s[random.Next(chars.Length)]).ToArray());
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public void DeleteUser(string id)
        {
            _context.Remove(_context.Users.SingleOrDefault(x => x.Id == id));
            _context.SaveChanges();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users;
        }

        public IEnumerable<User> GetAllUsersByCompanyId(string companyId)
        {
            return _context.Users.Where(u => u.CompanyId == companyId);
        }

        public User UpdateUser(string id, UpdateUserDTO updateUserDTO)
        {
            var user = _context.Users.SingleOrDefault(u => u.Id == id);
        /*public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public DateTime DOB { get; set; }
        public Position position { get; set; }
        public string PhoneNumber { get; set; }
        */
            user.FirstName = updateUserDTO.FirstName;
            user.LastName = updateUserDTO.LastName;
            user.CompanyName = updateUserDTO.CompanyName;
            user.DOB= updateUserDTO.DOB;
            user.position = updateUserDTO.position;
            user.PhoneNumber = updateUserDTO.PhoneNumber;
            _context.SaveChanges();
            return user;
        }
    }
}
