using Microsoft.EntityFrameworkCore;
using Preezie.DataAccess.Database;
using Preezie.Shared.DTOs.Users;

namespace Preezie.Services.UsersService
{
    public class UsersService
    {
        private readonly PreezieContext _context;

        public UsersService(PreezieContext context)
        {
            _context = context;
        }

        public async Task<List<UserList_DTO>> GetUsers(UserQuery_DTO userQueryDTO)
        {
            var users = await _context.Users.ToListAsync();
        }

        public async Task CreateUser(CreateUser_DTO userDTO)
        {

        }

        public async Task UpdateUser(string userID, UpdateUser_DTO userUpdateDTO)
        {
        }
    }
}