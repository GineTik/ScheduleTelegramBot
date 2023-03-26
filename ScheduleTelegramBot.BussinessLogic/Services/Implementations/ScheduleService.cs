using Microsoft.Extensions.Configuration;
using ScheduleTelegramBot.BussinessLogic.Services.Interfaces;
using ScheduleTelegramBot.Core.DTOs.ScheduleDTOs;
using ScheduleTelegramBot.Core.DTOs.ScheduleWeekDTOs;
using ScheduleTelegramBot.Core.Models;
using ScheduleTelegramBot.Data.Repositories;

namespace ScheduleTelegramBot.BussinessLogic.Services.Implementations
{
    public class ScheduleService : IScheduleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;

        public ScheduleService(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        public async Task<Guid?> AddScheduleAsync(AddScheduleDTO dto)
        {
            var schedule = new Schedule
            {
                Name = dto.Name,
                Weeks = new List<ScheduleWeek>()
                {
                    new ScheduleWeek
                    {
                        Name = _configuration.GetSection("Schedule:Week:DefaultName").Value,
                        Position = null
                    }
                }
            };

            var result = await _unitOfWork.ScheduleRepository.AddAsync(schedule);
            return result ? schedule.Id : null;
        }

        public async Task<ScheduleWithWeeksDTO?> GetScheduleAsync(Guid id)
        {
            var schedule = await _unitOfWork.ScheduleRepository.GetAsync(id);

            if (schedule == null)
                return null;

            var weeks = await _unitOfWork.ScheduleWeekRepository.GetScheduleWeeksAsync(schedule.Id);

            return new ScheduleWithWeeksDTO
            {
                Id = schedule.Id,
                Name = schedule.Name,
                Weeks = weeks.Select(w => new ShortScheduleWeekDTO
                {
                    Id = w.Id,
                    Name = w.Name,
                })
            };
        }
    }
}
