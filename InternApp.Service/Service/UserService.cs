using InternApp.Domain.Entities;
using InternApp.Domain.Persistance;
using Microsoft.EntityFrameworkCore;

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
            var company = _context.Companies.SingleOrDefault(c => c.Id == user.CompanyId);
            if(company == null)
            {
                return user;
            }
            _context.Users.Add(user);
            company.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public void DeleteUser(Guid id)
        {
            _context.Remove(_context.Users.Single(x => x.Id == id));
            _context.SaveChanges();
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _context.Users.OrderBy(c => c.Company.Name).ToListAsync();
        }

        public IEnumerable<User> GetAllUsersByCompanyId(Guid companyId)
        {
            return _context.Users.Where(u => u.CompanyId == companyId).ToList();
        }

        public User UpdateUser(Guid id, User user)
        {
            User? currentUser = _context.Users.Single(u => u.Id == id);
            if(currentUser == null)
            {
                return user;
            }
            currentUser.FirstName = user.FirstName;
            currentUser.LastName = user.LastName;
            currentUser.CompanyId = user.CompanyId;
            currentUser.DateOfBirth= user.DateOfBirth;
            currentUser.Position = user.Position;
            currentUser.PhoneNumber = user.PhoneNumber;
            _context.SaveChanges();
            return user;
        }
    }
}
