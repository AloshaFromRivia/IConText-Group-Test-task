using EmployeeTerminalApp.Dtos;
using EmployeeTerminalApp.Entities;
using EmployeeTerminalApp.Interfaces;
using EmployeeTerminalApp.utl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTerminalApp.Controllers
{
    public class UserCommander : IExecutable
    {
        private readonly IRepository<User, UserDto> repository;

        public UserCommander(IRepository<User, UserDto> repository)
        {
            this.repository = repository;
        }

        public virtual void Execute(string[] args)
        {
            var command = args[0];
            var arguments = args.Skip(1);
            if(string.IsNullOrEmpty(command)) throw new ArgumentNullException(nameof(command));
            if(command.Equals("-getall")) GetUsers();
            if(command.Equals("-get")) Get(ArgumentParser.GetIdProperty(arguments));
            if(command.Equals("-delete")) Delete(ArgumentParser.GetIdProperty(arguments));
            if(command.Equals("-add")) Add(ArgumentParser.ToUserDto(arguments));
            if (command.Equals("-update")) Update(ArgumentParser.ToUpdateDto(arguments));
        }

        private void Add(UserDto user)
        {
            repository.Add(user);
            Console.WriteLine("User added successfully ");
        }

        private void GetUsers()
        {
            foreach (var user in repository.GetAll())
            {
                Console.WriteLine(user.ToString());
            }
        }

        private void Get(int id)
        {
            var user = repository.Get(id);

            Console.WriteLine(user.ToString());
        }

        private void Delete(int id)
        {
            repository.Delete(id);
            Console.WriteLine("User deleted");
        }

        private void Update(UpdateDto dto)
        {
            repository.Update(dto.Id,dto.ToUserDto());
            Console.WriteLine("User Updated");
        }
    }
}
