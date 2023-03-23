using ScheduleTelegramBot.Core.Models;
using ScheduleTelegramBot.Data.EF;
using ScheduleTelegramBot.Data.Repositories.Interfaces;

namespace ScheduleTelegramBot.Data.Repositories.Implements
{
    public class TeacherRepository : Repository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(DataContext context) : base(context)
        { }
    }
}
