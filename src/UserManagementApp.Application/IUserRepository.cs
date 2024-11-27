using UserManagementApp.Domain.Entities;

namespace UserManagementApp.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserByIdAsync(int id);
        Task<int> CreateUserAsync(User user);
    }
}
