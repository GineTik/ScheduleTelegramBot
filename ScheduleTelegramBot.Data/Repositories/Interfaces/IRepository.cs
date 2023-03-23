using ScheduleTelegramBot.Core.Models;

namespace ScheduleTelegramBot.Data.Repositories.Interfaces
{
    public interface IRepository<T>
        where T : BaseModel
    {
        Task<T?> GetAsync(Guid id);
        Task<IEnumerable<T>> GetPageAsync(int page, int pageSize);
        Task<bool> AddAsync(T model);
        Task<bool> RemoveAsync(Guid id);
        Task<bool> UpdateAsync(Guid id, T model);
    }
}
