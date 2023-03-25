using ScheduleTelegramBot.Core.DTOs.ScheduleDTOs;

namespace ScheduleTelegramBot.BussinessLogic.Services.Interfaces
{
    public interface IScheduleService
    {
        Task<bool> AddScheduleAsync(AddScheduleDTO dto);
        Task<ScheduleWithWeeksDTO?> GetScheduleAsync(Guid id);
    }
}
