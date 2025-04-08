using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IBaseService<T> 
    {
        Task<T> Add(T entity);

        Task<List<T>> GetAll();

        Task<T> GetById(int id);

        Task<T> Update(T entity);

        Task<T> Delete(T entity);

    }
}
