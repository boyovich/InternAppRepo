using InternApp.Domain.Entities;

namespace InternApp.Service.Service
{
    public interface IUserService
    {
        public Task<IEnumerable<User>> GetAllUsers();
        public IEnumerable<User> GetAllUsersByCompanyId(Guid companyId);
        public User CreateUser(User user);
        public User UpdateUser(Guid id, User user);
        public void DeleteUser(Guid id);
    }
}
