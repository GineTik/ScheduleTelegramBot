using ScheduleTelegramBot.Core.DTOs.ScheduleWeekDTOs;

namespace ScheduleTelegramBot.Core.DTOs.ScheduleDTOs
{
    public class ScheduleWithWeeksDTO : ShortInfoScheduleDTO
    {
        public IEnumerable<ShortScheduleWeekDTO> Weeks { get; set; }
    }
}
