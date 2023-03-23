namespace ScheduleTelegramBot.Core.Models
{
    public class Schedule : BaseModel
    {
        public string Name { get; set; }
        public ICollection<ScheduleWeek> Weeks { get; set; }
    }
}
