using ScheduleTelegramBot.Core.Models;
using ScheduleTelegramBot.Data.EF;
using ScheduleTelegramBot.Data.Repositories.Interfaces;

namespace ScheduleTelegramBot.Data.Repositories.Implements
{
    public class ScheduleWeekRepository : Repository<ScheduleWeek>, IScheduleWeekRepository
    {
        public ScheduleWeekRepository(DataContext context) : base(context)
        { }
    }
}
