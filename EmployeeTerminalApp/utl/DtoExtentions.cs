using EmployeeTerminalApp.Dtos;
using EmployeeTerminalApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTerminalApp.utl
{
    public static class DtoExtentions
    {
        public static User ToUser(this UserDto dto) => new User() { FirstName = dto.FirstName , LastName = dto.LastName, SalaryPerHour = dto.SalaryPerHour.Value};
        public static UserDto ToUserDto(this UpdateDto dto) => new UserDto() {  FirstName = dto.FirstName, LastName = dto.LastName,SalaryPerHour = dto.SalaryPerHour};
    }
}
