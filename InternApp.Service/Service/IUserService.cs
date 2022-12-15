using InternApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternApp.Service.Service
{
    public interface IUserService
    {
        public IEnumerable<User> GetAllUsers();
        public IEnumerable<User> GetAllUsersByCompanyId(string companyId);
        public User CreateUser(User user);
        public User UpdateUser(string id, User user);
        public void DeleteUser(string id);
    }
}
