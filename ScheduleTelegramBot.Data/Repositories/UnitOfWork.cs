using ScheduleTelegramBot.Data.EF;
using ScheduleTelegramBot.Data.Repositories.Implements;
using ScheduleTelegramBot.Data.Repositories.Interfaces;

namespace ScheduleTelegramBot.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public IScheduleRepository ScheduleRepository => new ScheduleRepository(_context);
        public IScheduleWeekRepository ScheduleWeekRepository => new ScheduleWeekRepository(_context);
        public IScheduleDayRepository ScheduleDayRepository => new ScheduleDayRepository(_context);
        public IScheduleLessonRepository ScheduleLessonRepository => new ScheduleLessonRepository(_context);
        public ITeacherRepository TeacherRepository => new TeacherRepository(_context);
    }
}
