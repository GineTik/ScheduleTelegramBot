using ScheduleTelegramBot.Core.Models;
using ScheduleTelegramBot.Data.EF;
using ScheduleTelegramBot.Data.Repositories.Interfaces;

namespace ScheduleTelegramBot.Data.Repositories.Implements
{
    public class ScheduleDayRepository : Repository<ScheduleDay>, IScheduleDayRepository
    {
        public ScheduleDayRepository(DataContext context) : base(context)
        { }
    }
}
