using AutoMapper;
using Preezie.DataAccess.Models.User;
using Preezie.Shared.DTOs.Users;

namespace Preezie.Solution.AutoMapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserList_DTO>();
        }
    }
}