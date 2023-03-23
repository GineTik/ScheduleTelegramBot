using ScheduleTelegramBot.Data.Repositories.Interfaces;

namespace ScheduleTelegramBot.Data.Repositories
{
    public interface IUnitOfWork
    {
        public IScheduleRepository ScheduleRepository { get; }
        public IScheduleWeekRepository ScheduleWeekRepository { get; }
        public IScheduleDayRepository ScheduleDayRepository { get; }
        public IScheduleLessonRepository ScheduleLessonRepository { get; }
        public ITeacherRepository TeacherRepository { get; }
    }
}
