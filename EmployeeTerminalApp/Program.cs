using EmployeeTerminalApp.Controllers;
using EmployeeTerminalApp.Dtos;
using EmployeeTerminalApp.Entities;
using EmployeeTerminalApp.Interfaces;
using EmployeeTerminalApp.Repositories;
using Microsoft.Extensions.DependencyInjection;

//DI
var serviceProvider = new ServiceCollection()
    .AddSingleton<IRepository<User,UserDto>,UserRepository>()
    .AddSingleton<IExecutable,UserCommander>()
    .BuildServiceProvider();

var comander = serviceProvider.GetRequiredService<IExecutable>();

comander.Execute(args);