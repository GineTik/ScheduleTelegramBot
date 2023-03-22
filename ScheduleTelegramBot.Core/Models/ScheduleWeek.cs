namespace ScheduleTelegramBot.Core.Models
{
    public class ScheduleWeek
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Position { get; set; }
        public ICollection<ScheduleDay> Days { get; set; }
    }
}
