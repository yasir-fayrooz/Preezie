using Preezie.Shared.DTOs.Users;

namespace Preezie.Services.UsersService
{
    public class UsersService
    {
        public UsersService()
        {

        }

        public async Task<List<UserList_DTO>> GetUsers()
        {
            return null;
        }

        public async Task CreateUser(CreateUser_DTO userDTO)
        {

        }

        public async Task UpdateUser(string userID, UpdateUser_DTO userUpdateDTO)
        {
        }
    }
}