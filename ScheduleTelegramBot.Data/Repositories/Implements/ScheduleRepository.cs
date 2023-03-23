using ScheduleTelegramBot.Core.Models;
using ScheduleTelegramBot.Data.EF;
using ScheduleTelegramBot.Data.Repositories.Interfaces;

namespace ScheduleTelegramBot.Data.Repositories.Implements
{
    public class ScheduleRepository : Repository<Schedule>, IScheduleRepository
    {
        public ScheduleRepository(DataContext context) : base(context)
        { }
    }
}
