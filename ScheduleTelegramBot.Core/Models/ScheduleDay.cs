namespace ScheduleTelegramBot.Core.Models
{
    public class ScheduleDay : BaseModel
    {
        public string Name { get; set; }
        public ICollection<ScheduleLesson> Lessons { get; set; }
    }
}
