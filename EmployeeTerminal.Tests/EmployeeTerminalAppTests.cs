
using EmployeeTerminalApp.Dtos;
using EmployeeTerminalApp.Entities;
using EmployeeTerminalApp.Interfaces;
using EmployeeTerminalApp.Repositories;

namespace EmployeeTerminal.Tests
{
    public class EmployeeTerminalAppTests
    {
        [Fact]
        public void UserRepository_GetAll_ReturnsTwoUsers()
        {
            //arrange
            IRepository<User,UserDto> repository = new UserRepository(new List<User>());
            repository.Add(new UserDto() { FirstName= "Moore", LastName= "Miller", SalaryPerHour= 120 });
            repository.Add(new UserDto() { FirstName = "White ", LastName = "Davis", SalaryPerHour = 120 });

            //act
            var users = repository.GetAll();

            //assert
            Assert.Equal(2, users.Count);
        }

        [Fact]
        public void UserRepository_GetById_ReturnsUser()
        {
            //arrange
            IRepository<User, UserDto> repository = new UserRepository(new List<User>());
            var testUser = new UserDto() { FirstName = "Moore", LastName = "Miller", SalaryPerHour = 120 };
            repository.Add(testUser);
            repository.Add(new UserDto() { FirstName = "White ", LastName = "Davis", SalaryPerHour = 120 });

            //act
            var user = repository.Get(1);

            //assert
            Assert.NotEqual(null,user);
        }

        [Fact]
        public void UserRepository_DeleteUser_ReturnsOneUser()
        {
            //arrange
            IRepository<User, UserDto> repository = new UserRepository(new List<User>());
            repository.Add(new UserDto() { FirstName = "Moore", LastName = "Miller", SalaryPerHour = 120 });
            repository.Add(new UserDto() { FirstName = "White ", LastName = "Davis", SalaryPerHour = 120 });

            //act
            repository.Delete(1);
            var user = repository.GetAll();

            //assert
            Assert.Equal(1, user.Count);
        }
    }
}