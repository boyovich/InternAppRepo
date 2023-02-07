using InternApp.Domain.Entities;

namespace InternApp.Service.Service
{
    public interface IUserService
    {
        public Task<IEnumerable<User>> GetAllUsers(int pageNumber, int pageSize);
        public Task<IEnumerable<User>> GetAllUsersByCompanyId(Guid companyId, int pageNumber, int pageSize);
        public User CreateUser(User user);
        public User UpdateUser(Guid id, User user);
        public void DeleteUser(Guid id);
    }
}
