using ScheduleTelegramBot.Core.Models;
using ScheduleTelegramBot.Data.EF;
using ScheduleTelegramBot.Data.Repositories.Interfaces;

namespace ScheduleTelegramBot.Data.Repositories.Implements
{
    public class ScheduleLessonRepository : Repository<ScheduleLesson>, IScheduleLessonRepository
    {
        public ScheduleLessonRepository(DataContext context) : base(context)
        { }
    }
}
