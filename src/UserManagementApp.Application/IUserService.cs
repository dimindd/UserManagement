using UserManagementApp.Domain.Entities;
using System.Threading.Tasks;

namespace UserManagementApp.Application.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUserByIdAsync(int id); 
        Task<int> CreateUserAsync(User user); 
    }
}
