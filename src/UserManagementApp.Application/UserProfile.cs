using AutoMapper;
using UserManagementApp.Domain.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;
using UserManagementApp.Application.DTOs;

namespace UserManagementApp.Application.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();
        }
    }
}
