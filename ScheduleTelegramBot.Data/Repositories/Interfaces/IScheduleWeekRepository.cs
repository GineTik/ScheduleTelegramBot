using ScheduleTelegramBot.Core.Models;

namespace ScheduleTelegramBot.Data.Repositories.Interfaces
{
    public interface IScheduleWeekRepository : IRepository<ScheduleWeek>
    {
        public Task<IEnumerable<ScheduleWeek>> GetScheduleWeeksAsync(Guid scheduleId);
    }
}
