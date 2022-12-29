using InternApp.Domain.Entities;
using InternApp.Domain.Persistance;

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
            user.CompanyId = company.Id;
            _context.Users.Add(user);
            company.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public void DeleteUser(Guid id)
        {
            _context.Remove(_context.Users.SingleOrDefault(x => x.Id == id));
            _context.SaveChanges();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.OrderBy(c => c.Company.Name).ToList();
        }

        public IEnumerable<User> GetAllUsersByCompanyId(Guid companyId)
        {
            return _context.Users.Where(u => u.CompanyId.ToString() == companyId.ToString());
        }

        public User UpdateUser(Guid id, User user)
        {
            User? currentUser = _context.Users.Single(u => u.Id.ToString() == id.ToString());
            if(currentUser == null)
            {
                return user;
            }
            currentUser.FirstName = user.FirstName;
            currentUser.LastName = user.LastName;
            currentUser.CompanyId= user.CompanyId;
            currentUser.PhoneNumber= user.PhoneNumber;
            currentUser.DateOfBirth = user.DateOfBirth;
            currentUser.Position= user.Position;
            Company? company = _context.Companies.SingleOrDefault(c => c.Id == user.CompanyId);         
            _context.SaveChanges();
            return user;
        }
    }
}
