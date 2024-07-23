using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTerminalApp.Dtos
{
    public record UserDto
    {
        public string? FirstName { get; set; }
        public decimal? SalaryPerHour { get; set; }
        public string? LastName { get; set; }
    }
}
