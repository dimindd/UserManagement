using UserManagementApp.Application.Interfaces;
using UserManagementApp.Domain.Entities;

namespace UserManagementApp.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }

        public async Task<int> CreateUserAsync(User user)
        {
            return await _userRepository.CreateUserAsync(user);
        }
    }
}
