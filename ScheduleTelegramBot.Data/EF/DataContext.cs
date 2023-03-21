using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ScheduleTelegramBot.Core.Models;

namespace ScheduleTelegramBot.Data.EF
{
    public class DataContext : DbContext
    {
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<ScheduleWeek> ScheduleWeeks { get; set; }
        public DbSet<ScheduleDay> ScheduleDays { get; set; }
        public DbSet<ScheduleLesson> ScheduleLessons { get; set; }

        public IConfiguration _configuration;

        public DataContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        { }

        //protected internal virtual void OnConfiguring(DbContextOptionsBuilder builder)
        //{

        //}
    }
}
