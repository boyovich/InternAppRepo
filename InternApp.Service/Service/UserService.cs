using InternApp.Domain.Entities;
using InternApp.Domain.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternApp.Service.Service
{
    public class UserService : IUserService
    {
        private InternDbContext _context;

        public UserService(InternDbContext context)
        {
            _context = context;
        }
        
        public User CreateUser(CreateUserDTO createUserDTO)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(string id)
        {
            throw new NotImplementedException();
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
            
        }
    }
}
