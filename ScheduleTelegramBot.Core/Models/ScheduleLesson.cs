using ScheduleTelegramBot.Core.Models.Enums;

namespace ScheduleTelegramBot.Core.Models
{
    public class ScheduleLesson
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public int LessonPosition { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public LessonType LessonType { get; set; }

        public Guid TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}
