namespace ScheduleTelegramBot.Core.DTOs.TeacherDTOs
{
    public class AddTeacherDTO
    {
        public Guid ScheduleLessonId { get; set; }
        public string Name { get; set; }
    }
}
