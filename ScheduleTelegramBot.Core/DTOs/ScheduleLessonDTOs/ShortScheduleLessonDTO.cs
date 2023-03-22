using ScheduleTelegramBot.Core.DTOs.TeacherDTOs;
using ScheduleTelegramBot.Core.Models.Enums;

namespace ScheduleTelegramBot.Core.DTOs.ScheduleLessonDTOs
{
    public class ShortScheduleLessonDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public int LessonPosition { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public LessonType LessonType { get; set; }

        public ShortTeacherDTO Teacher { get; set; }
    }
}
