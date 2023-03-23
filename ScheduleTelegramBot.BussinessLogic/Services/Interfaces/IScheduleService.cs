using ScheduleTelegramBot.Core.DTOs.ScheduleDTOs;

namespace ScheduleTelegramBot.BussinessLogic.Services.Interfaces
{
    public interface IScheduleService
    {
        Task<bool> AddSchedule(AddScheduleDTO dto);
        Task<ScheduleWithWeeksDTO> GetSchedule(Guid id);
    }
}
