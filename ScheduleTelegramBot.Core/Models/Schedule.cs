namespace ScheduleTelegramBot.Core.Models
{
    public class Schedule
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<ScheduleWeek> Weeks { get; set; }
    }
}
