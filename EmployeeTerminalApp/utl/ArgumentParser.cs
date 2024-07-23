using EmployeeTerminalApp.Dtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTerminalApp.utl
{
    public static class ArgumentParser
    {
        public static UserDto ToUserDto(IEnumerable<string> input)
        {
            var props = GetProperties(input);

            var dto = new UserDto();

            foreach (var item in props)
            {
                FillProperty(dto, item);
            }

            return dto;
        }

        public static int GetIdProperty(IEnumerable<string> input)
        {
            var props = GetProperties(input);

            return int.Parse(props.Where(k => k.Key == "Id").Select(k => k.Value).FirstOrDefault());
        }

        private static Dictionary<string,string> GetProperties(IEnumerable<string> input)
        {
            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();

            foreach (var item in input)
            {
                var pair = item.Split(':');
                keyValuePairs.Add(pair[0], pair[1]);
            }
            return keyValuePairs;
        }

        private static UserDto FillProperty(UserDto dto, KeyValuePair<string, string> kvp)
        {
            if (kvp.Key == "FirstName") dto.FirstName = kvp.Value;
            if (kvp.Key == "LastName") dto.LastName = kvp.Value;
            if (kvp.Key == "SalaryPerHour") dto.SalaryPerHour = decimal.Parse(kvp.Value);
            return dto;
        }
    }
}
