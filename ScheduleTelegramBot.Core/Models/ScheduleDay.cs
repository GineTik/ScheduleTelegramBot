namespace ScheduleTelegramBot.Core.Models
{
    public class ScheduleDay
    {
        public Guid Id { get; set; }
        public ICollection<ScheduleLesson> Lessons { get; set; }
    }
}
