using ScheduleTelegramBot.Core.DTOs.TeacherDTOs;
using ScheduleTelegramBot.Core.Models.Enums;

namespace ScheduleTelegramBot.Core.DTOs.ScheduleLessonDTOs
{
    public class AddScheduleLessonDTO
    {
        public Guid Id { get; set; }
        public Guid ScheduleDayId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int LessonPosition { get; set; }
        public LessonType LessonType { get; set; }
        public ShortTeacherDTO? Teacher { get; set; }
    }
}
