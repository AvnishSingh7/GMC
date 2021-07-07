using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GMCManagementSystemAPI.Services.Generic
{
    public interface IGenericService<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetAllWithData(int id);
        Task<IEnumerable<T>> GetAll(int page, int pageSize);
        Task<IEnumerable<T>> GetAll(string include);
        Task<T> GetById(int id);
        T Create(T model);
        Task<T> Update(T model);
        void Delete(int id);
        Task<IEnumerable<T>> GetByAny(int value);

    }
}
