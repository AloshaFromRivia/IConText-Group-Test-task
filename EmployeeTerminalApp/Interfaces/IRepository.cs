using EmployeeTerminalApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTerminalApp.Interfaces
{
    public interface IRepository<T, V> where T : IEntity
    {
        void Add(V dto);
        void Update(int id, V dto);
        IReadOnlyCollection<T> GetAll();
        T Get(int id);
        void Delete(int Id);
    }
}
