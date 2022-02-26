using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface IService<T> where T : class
    {
        Task<int> Create(T item);
        Task<IList<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> GetByName(string name);
        Task<int> Update(T item);
        Task<int> Delete(int id);
    }
}
