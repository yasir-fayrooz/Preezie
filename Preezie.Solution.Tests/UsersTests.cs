using Microsoft.AspNetCore.Mvc.Testing;
using NUnit.Framework;
using Preezie.Shared.DTOs.Paging;
using Preezie.Shared.DTOs.Users;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Preezie.Solution.Tests
{
    public class UsersTests
    {
        private WebApplicationFactory<Program> application;
        private HttpClient client;

        [SetUp]
        public void Setup()
        {
            application = new WebApplicationFactory<Program>();
            client = application.CreateClient();
        }

        #region GetUsers

        [Test]
        public async Task Get_Users_Pagination_Works()
        {
            var pagedList = await client.GetFromJsonAsync<PagedResult_DTO<UserList_DTO>>("/api/users?pageSize=15");

            //Assert
            Assert.AreEqual(15, pagedList.PageSize);
            Assert.AreEqual(15, pagedList.Items.Count);
        }

        [Test]
        public async Task Get_Users_Sorting()
        {
            var pagedList = await client.GetFromJsonAsync<PagedResult_DTO<UserList_DTO>>("/api/users?sort=true&columnname=email");

            //Assert
            Assert.AreEqual(pagedList.Items.OrderBy(x => x.Email), pagedList.Items);
        }

        [Test]
        public async Task Get_Users_Filtering()
        {
            var pagedList = await client.GetFromJsonAsync<PagedResult_DTO<UserList_DTO>>("/api/users?columnname=email&filter=10");

            //Assert
            Assert.AreEqual(1, pagedList.Items.Count);
        }

        #endregion

        #region CreateUser

        [Test]
        public async Task Create_User()
        {
            var createUserDTO = new CreateUser_DTO
            {
                Email = "yasir@test.com",
                DisplayName = "updated name",
                Password = "1abcsdAwe2"
            };

            var response = await client.PostAsJsonAsync<CreateUser_DTO>("/api/users", createUserDTO);
            
            //Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [Test]
        public async Task Create_User_Invalid_Password_Requirements()
        {
            var createUserDTO = new CreateUser_DTO
            {
                Email = "yasir1@test.com",
                DisplayName = "updated name",
                Password = "AasaAEDFxxx" //no number
            };

            var response = await client.PostAsJsonAsync<CreateUser_DTO>("/api/users", createUserDTO);

            //Assert
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Test]
        public async Task Create_User_Existing_UserID()
        {
            var createUserDTO = new CreateUser_DTO
            {
                Email = "test1@test.com",
                DisplayName = "asdsda",
                Password = "AasaAEDFxxx1"
            };

            var response = await client.PostAsJsonAsync<CreateUser_DTO>("/api/users", createUserDTO);

            //Assert
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        #endregion

        #region UpdateUser

        [Test]
        public async Task Update_User()
        {
            const string userID = "test1@test.com";
            var updateUserDTO = new UpdateUser_DTO
            {
                DisplayName = "updated name",
                Password = "1abcsdAwe2"
            };

            var response = await client.PutAsJsonAsync<UpdateUser_DTO>($"/api/users/{userID}", updateUserDTO);

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [Test]
        public async Task Update_User_Invalid_Password_Requirements()
        {
            const string userID = "test1@test.com";
            var updateUserDTO = new UpdateUser_DTO
            {
                DisplayName = "updated name",
                Password = "1aaaasfw"
            };

            var response = await client.PutAsJsonAsync<UpdateUser_DTO>($"/api/users/{userID}", updateUserDTO);

            //Assert
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Test]
        public async Task Update_User_Invalid_UserID()
        {
            const string userID = "test100@test.com";
            var updateUserDTO = new UpdateUser_DTO
            {
                DisplayName = "updated name",
                Password = "1aaaaAsfw"
            };

            var response = await client.PutAsJsonAsync<UpdateUser_DTO>($"/api/users/{userID}", updateUserDTO);

            //Assert
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }

        #endregion
    }
}