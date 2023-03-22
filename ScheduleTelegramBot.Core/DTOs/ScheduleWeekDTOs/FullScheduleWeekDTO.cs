using ScheduleTelegramBot.Core.DTOs.ScheduleDayDTOs;

namespace ScheduleTelegramBot.Core.DTOs.ScheduleWeekDTOs
{
    public class FullScheduleWeekDTO : ShortScheduleWeekDTO
    {
        public IEnumerable<FullScheduleDayDTO> Days { get; set; }
    }
}
