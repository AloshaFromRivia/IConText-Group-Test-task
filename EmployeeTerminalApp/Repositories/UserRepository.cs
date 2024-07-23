using EmployeeTerminalApp.Dtos;
using EmployeeTerminalApp.Entities;
using EmployeeTerminalApp.Interfaces;
using EmployeeTerminalApp.utl;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace EmployeeTerminalApp.Repositories
{
    public class UserRepository : IRepository<User,UserDto>
    {
        private const string PATH= "G:\\Test" + "/testData/test data.json";
        private List<User> _users;

        public UserRepository()
        {
            using (FileStream fstream = File.OpenRead(PATH))
            {
                // выделяем массив для считывания данных из файла
                byte[] buffer = new byte[fstream.Length];
                // считываем данные
                fstream.Read(buffer, 0, buffer.Length);
                // декодируем байты в строку
                string textFromFile = Encoding.Default.GetString(buffer);
                _users = JsonConvert.DeserializeObject<List<User>>(textFromFile);
            }
        }
        public void Add(UserDto dto)
        {
            var user = dto.ToUser();
            user.Id= _users.Count+1;

            _users.Add(user);

            Save();
        }

        public void Delete(int Id)
        {
            var user = _users.FirstOrDefault(x => x.Id == Id);
            if(user == null) throw new NullReferenceException($"No user with id - {Id}");

            _users.Remove(user);

            Save();
        }

        public User Get(int id)
        {
           return _users.FirstOrDefault(x => x.Id == id) ?? throw new NullReferenceException($"No user with id - {id}");
        }

        public IReadOnlyCollection<User> GetAll() => _users;

        public void Update(int id, UserDto dto)
        {
            var user = Get(id);
            if(dto == null) throw new NullReferenceException($"No user with id - {id}");

            //update user info
            if(dto.FirstName != null) user.FirstName = dto.FirstName;
            if(dto.LastName != null) user.LastName = dto.LastName;
            if(dto.SalaryPerHour !=null) user.SalaryPerHour = dto.SalaryPerHour.Value;

            Save();
        }

        private void Save()
        {
            JsonSerializer serializer = new JsonSerializer();

            using (StreamWriter sw = new StreamWriter(PATH))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, _users);
            }
        }
    }
}
