using Preezie.DataAccess.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preezie.DataAccess.Database
{
    public static class Seed
    {
        public static async Task SeedData(PreezieContext context)
        {
            List<User> users = new List<User>()
            {
                new User
                {
                    Email = "Test1@test.com",
                    DisplayName = "Test1",
                    Password = "Testing1"
                },
                new User
                {
                    Email = "Test2@test.com",
                    DisplayName = "Test2",
                    Password = "Testing2"
                },
                new User
                {
                    Email = "Test3@test.com",
                    DisplayName = "Test3",
                    Password = "Testing3"
                },
                new User
                {
                    Email = "Test4@test.com",
                    DisplayName = "Test4",
                    Password = "Testing4"
                },
                new User
                {
                    Email = "Test5@test.com",
                    DisplayName = "Test5",
                    Password = "Testing5"
                },
                new User
                {
                    Email = "Test6@test.com",
                    DisplayName = "Test6",
                    Password = "Testing6"
                },
                new User
                {
                    Email = "Test7@test.com",
                    DisplayName = "Test7",
                    Password = "Testing7"
                },
                new User
                {
                    Email = "Test8@test.com",
                    DisplayName = "Test8",
                    Password = "Testing8"
                },
                new User
                {
                    Email = "Test9@test.com",
                    DisplayName = "Test9",
                    Password = "Testing9"
                },
                new User
                {
                    Email = "Test10@test.com",
                    DisplayName = "Test10",
                    Password = "Testing10"
                },
                new User
                {
                    Email = "Test11@test.com",
                    DisplayName = "Test11",
                    Password = "Testing11"
                },
                new User
                {
                    Email = "Test12@test.com",
                    DisplayName = "Test12",
                    Password = "Testing12"
                },
                new User
                {
                    Email = "Test13@test.com",
                    DisplayName = "Test13",
                    Password = "Testing13"
                },
                new User
                {
                    Email = "Test14@test.com",
                    DisplayName = "Test14",
                    Password = "Testing14"
                },
                new User
                {
                    Email = "Test15@test.com",
                    DisplayName = "Test15",
                    Password = "Testing15"
                },
                new User
                {
                    Email = "Test16@test.com",
                    DisplayName = "Test16",
                    Password = "Testing16"
                },
                new User
                {
                    Email = "Test17@test.com",
                    DisplayName = "Test17",
                    Password = "Testing17"
                },
                new User
                {
                    Email = "Test18@test.com",
                    DisplayName = "Test18",
                    Password = "Testing18"
                },
                new User
                {
                    Email = "Test19@test.com",
                    DisplayName = "Test19",
                    Password = "Testing19"
                },
                new User
                {
                    Email = "Test20@test.com",
                    DisplayName = "Test20",
                    Password = "Testing20"
                },
            };

            await context.Users.AddRangeAsync(users);
            await context.SaveChangesAsync();
        }

    }
}
