using Microsoft.EntityFrameworkCore;
using ScheduleTelegramBot.Core.Models;
using ScheduleTelegramBot.Data.EF;
using ScheduleTelegramBot.Data.Repositories.Interfaces;

namespace ScheduleTelegramBot.Data.Repositories.Implements
{
    public class Repository<T> : IRepository<T>
        where T : BaseModel, new()
    {
        protected readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(T model)
        {
            var result = (await _context.Set<T>().AddAsync(model)).State == EntityState.Added;
            await _context.SaveChangesAsync();
            return result;
        }

        public async Task<T?> GetAsync(Guid id)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<T>> GetPageAsync(int page, int pageSize)
        {
            return await Task.Run(() => _context.Set<T>().Skip((page - 1) * pageSize).Take(pageSize));
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            var result = _context.Set<T>().Remove(new T { Id = id }).State == EntityState.Deleted;
            await _context.SaveChangesAsync();
            return result;
        }

        public async Task<bool> UpdateAsync(Guid id, T model)
        {
            var result = _context.Set<T>().Update(model).State == EntityState.Modified;
            await _context.SaveChangesAsync();
            return result;
        }
    }
}
