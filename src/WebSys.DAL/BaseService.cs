using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebSys.IDAL;
using WebSys.Models;

namespace WebSys.DAL
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity, new()
    {
        public WebSysDBContext _db;

        public BaseService(WebSysDBContext db)
        {
            _db = db;
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public async Task CreateAsync(T model, bool saved = true)
        {
            _db.Set<T>().Add(model);
            if (saved) await _db.SaveChangesAsync();
        }

        public async Task EditAsync(T model, bool saved = true)
        {
            _db.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            if (saved)
            {
                await _db.SaveChangesAsync();
            }
        }

        public async Task RemoveAsync(Guid id, bool saved = true)
        {
            var t = new T() { Id = id };
            _db.Entry(t).State = EntityState.Unchanged;
            t.IsRemoved = true;
            if (saved)
                await _db.SaveChangesAsync();
        }

        public async Task RemoveAsync(T model, bool saved = true)
        {
            await RemoveAsync(model.Id, saved);
        }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }

        public IQueryable<T> GetALLAsync()
        {
            return _db.Set<T>().Where(m => !m.IsRemoved).AsNoTracking();
        }

        public IQueryable<T> GetAllByOrderAsync(bool asc = true)
        {
            var datas = GetALLAsync();
            if (asc)
                datas = datas.OrderBy(m => m.CreateTime);
            else
                datas = datas.OrderByDescending(m => m.CreateTime);
            return datas;
        }

        public IQueryable<T> GetAllByPageAsync(int pageSize = 10, int pageIndex = 0)
        {
            return GetALLAsync().Skip(pageIndex * pageSize).Take(pageIndex);
        }

        public IQueryable<T> GetAllByPageOrderAsync(int pageSize = 10, int pageIndex = 0, bool asc = true)
        {
            return GetAllByOrderAsync(asc).Skip(pageSize * pageIndex).Take(pageIndex);
        }

        public async Task<T> GetOneByIdAsync(Guid id)
        {
            return await GetALLAsync().FirstAsync(predicate: m => m.Id == id);
        }
    }
}