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
        public UserService(InternDbContext context)
        {
            _context = context;
        }
        
        public User CreateUser(User user)
        {
            user.Id = Guid.NewGuid();
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public void DeleteUser(string id)
        {
            _context.Remove(_context.Users.SingleOrDefault(x => x.Id.ToString() == id));
            _context.SaveChanges();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users;
        }

        public IEnumerable<User> GetAllUsersByCompanyId(string companyId)
        {
            return _context.Users.Where(u => u.CompanyId.ToString() == companyId);
        }

        public User UpdateUser(string id, UpdateUserDTO updateUserDTO)
        {
            var user = _context.Users.SingleOrDefault(u => u.Id.ToString() == id);
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
            user.DateOfBirth= updateUserDTO.DateOfBirth;
            user.Position = updateUserDTO.Position;
            user.PhoneNumber = updateUserDTO.PhoneNumber;
            _context.SaveChanges();
            return user;
        }
    }
}
