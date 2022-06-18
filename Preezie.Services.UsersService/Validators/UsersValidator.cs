using Preezie.Shared.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Preezie.Services.UsersService.Validators
{
    public static class UsersValidator
    {
        public static bool UserListHasColumn(string propertyName)
        {
            return typeof(UserList_DTO).GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance) != null;
        }
    }
}
