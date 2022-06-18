using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Preezie.DataAccess.Database;
using Preezie.DataAccess.Models.User;
using Preezie.Services.UsersService.Validators;
using Preezie.Shared.DTOs.Paging;
using Preezie.Shared.DTOs.Users;
using Preezie.Solution.ExceptionHandler.CustomExceptions;
using System.Linq.Dynamic.Core;

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

        public async Task<PagedResult_DTO<UserList_DTO>> GetUsers(UserQuery_DTO userQueryDTO)
        {
            var usersCount = _context.Users.Count();

            //paginate by the callers query params
            var query = _context.Users.AsQueryable();

            //apply filters and/or sorting
            if (!string.IsNullOrEmpty(userQueryDTO.ColumnName))
            {
                //send a bad request if column doesnt exist in UserList_DTO
                if (!UsersValidator.UserListHasColumn(userQueryDTO.ColumnName))
                    throw new BadRequestException("Invalid Column Name");

                //add generic column name sort to query
                if (userQueryDTO.Sort)
                    query = query.OrderBy(userQueryDTO.ColumnName);

                //add generic filtering to the column name
                if (userQueryDTO.Filter != null)
                    query = query.Where($"{userQueryDTO.ColumnName}.Contains(@0)", userQueryDTO.Filter);
            }

            //Add paging
            query = query.Skip(userQueryDTO.Page * userQueryDTO.PageSize).Take(userQueryDTO.PageSize);

            var users = await query.AsNoTracking().ToListAsync();

            //Map DB Model to DTO
            var userListDTO = _mapper.Map<List<UserList_DTO>>(users);

            return new PagedResult_DTO<UserList_DTO>
            {
                Items = userListDTO,
                PageSize = userQueryDTO.PageSize,
                TotalItems = usersCount
            };
        }

        public async Task CreateUser(CreateUser_DTO userDTO)
        {
            if (_context.Users.Any(x => x.Email.Equals(userDTO.Email, StringComparison.CurrentCultureIgnoreCase)))
                throw new BadRequestException("User ID already exists in system");

            await _context.Users.AddAsync(new User
            {
                Email = userDTO.Email,
                DisplayName = userDTO.DisplayName,
                Password = userDTO.Password
            });

            await _context.SaveChangesAsync();
        }

        public async Task UpdateUser(string userID, UpdateUser_DTO userUpdateDTO)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == userID);

            //Return not found response if no user found
            if(user == null)
                throw new NotFoundException("User ID could not be found");

            if (!string.IsNullOrEmpty(userUpdateDTO.DisplayName))
                user.DisplayName = userUpdateDTO.DisplayName;

            if (!string.IsNullOrEmpty(userUpdateDTO.Password))
                user.Password = userUpdateDTO.Password;

            await _context.SaveChangesAsync();
        }
    }
}