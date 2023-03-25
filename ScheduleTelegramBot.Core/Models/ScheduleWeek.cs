namespace ScheduleTelegramBot.Core.Models
{
    public class ScheduleWeek : BaseModel
    {
        public string Name { get; set; }
        public int? Position { get; set; }
        public ICollection<ScheduleDay> Days { get; set; }
    }
}
