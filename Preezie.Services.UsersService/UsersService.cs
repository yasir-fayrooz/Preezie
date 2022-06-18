using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Preezie.DataAccess.Database;
using Preezie.Shared.DTOs.Users;

namespace Preezie.Services.UsersService
{
    public class UsersService
    {
        private readonly PreezieContext _context;
        private readonly IMapper _mapper;

        public UsersService(PreezieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<UserList_DTO>> GetUsers(UserQuery_DTO userQueryDTO)
        {
            var users = await _context.Users.ToListAsync();

            return _mapper.Map<List<UserList_DTO>>(users);
        }

        public async Task CreateUser(CreateUser_DTO userDTO)
        {

        }

        public async Task UpdateUser(string userID, UpdateUser_DTO userUpdateDTO)
        {
        }
    }
}