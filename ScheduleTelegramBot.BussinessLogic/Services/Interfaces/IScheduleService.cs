using ScheduleTelegramBot.Core.DTOs.ScheduleDTOs;

namespace ScheduleTelegramBot.BussinessLogic.Services.Interfaces
{
    public interface IScheduleService
    {
        Task<Guid?> AddScheduleAsync(AddScheduleDTO dto);
        Task<ScheduleWithWeeksDTO?> GetScheduleAsync(Guid id);
    }
}
