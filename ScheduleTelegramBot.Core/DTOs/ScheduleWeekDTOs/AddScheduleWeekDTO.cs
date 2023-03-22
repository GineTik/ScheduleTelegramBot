namespace ScheduleTelegramBot.Core.DTOs.ScheduleWeekDTOs
{
    public class AddScheduleWeekDTO
    {
        public Guid Id { get; set; }
        public Guid ScheduleId { get; set; }
        public int Position { get; set; }
    }
}
