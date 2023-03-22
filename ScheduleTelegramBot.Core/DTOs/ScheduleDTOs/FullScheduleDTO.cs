using ScheduleTelegramBot.Core.DTOs.ScheduleWeekDTOs;

namespace ScheduleTelegramBot.Core.DTOs.ScheduleDTOs
{
    public class FullScheduleDTO : ShortScheduleDTO
    {
        public IEnumerable<ShortScheduleWeekDTO> Weeks { get; set; }
    }
}
