using System;
using System.Linq;
using System.Threading.Tasks;
using WebSys.Models;

namespace WebSys.IDAL
{
    public interface IBaseService<T> : IDisposable where T : BaseEntity, new()
    {
        Task CreateAsync(T model, bool saved = true);

        Task EditAsync(T model, bool saved = true);

        Task RemoveAsync(Guid id, bool saved = true);

        Task RemoveAsync(T model, bool saved = true);

        Task Save();

        Task<T> GetOneByIdAsync(Guid id);

        IQueryable<T> GetALLAsync();

        IQueryable<T> GetAllByPageAsync(int pageSize = 10, int pageIndex = 0);

        IQueryable<T> GetAllByOrderAsync(bool asc = true);

        IQueryable<T> GetAllByPageOrderAsync(int pageSize = 10, int pageIndex = 0, bool asc = true);
    }
}