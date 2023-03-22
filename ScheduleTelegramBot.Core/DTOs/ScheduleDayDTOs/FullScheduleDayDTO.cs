using ScheduleTelegramBot.Core.Models;

namespace ScheduleTelegramBot.Core.DTOs.ScheduleDayDTOs
{
    public class FullScheduleDayDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<ScheduleLesson> Lessons { get; set; }
    }
}
