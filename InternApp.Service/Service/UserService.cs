using InternApp.Domain;
using InternApp.Domain.Entities;
using InternApp.Domain.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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
            var company = _context.Companies.SingleOrDefault(x => x.Name.Equals(user.CompanyName));
            if(company == null)
            {
                return user;
            }
            user.CompanyId = company.Id;
            _context.Users.Add(user);
            company.Users.Add(user);
            _context.SaveChanges();
            return user;
        }
        //mozda dodati povratnu vrednost User? umesto void, u slucaju da ne nadjemo User po Id vratili bismo null; response NotFound()
        public void DeleteUser(string id)
        {
            _context.Remove(_context.Users.SingleOrDefault(x => x.Id.ToString() == id));
            _context.SaveChanges();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.OrderBy(c => c.CompanyName).ToList();
        }

        public IEnumerable<User> GetAllUsersByCompanyId(string companyId)
        {
            return _context.Users.Where(u => u.CompanyId.ToString() == companyId);
        }

        public User UpdateUser(string id, User user)
        {
            User? currentUser = _context.Users.Single(u => u.Id.ToString() == id);
            if(currentUser == null)
            {
                return user;
            }
            currentUser.FirstName = user.FirstName;
            currentUser.LastName = user.LastName;
            currentUser.CompanyName= user.CompanyName;
            currentUser.PhoneNumber= user.PhoneNumber;
            currentUser.DateOfBirth = user.DateOfBirth;
            currentUser.Position= user.Position;
            Company? company = _context.Companies.SingleOrDefault(c => c.Name == user.CompanyName);
            if(company == null)
            {
                return user;
            }
            currentUser.CompanyId = company.Id;
        /*public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public DateTime DOB { get; set; }
        public Position position { get; set; }
        public string PhoneNumber { get; set; }
        */
            
            _context.SaveChanges();
            return user;
        }
    }
}
