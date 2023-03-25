using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ScheduleTelegramBot.Data.EF;
using ScheduleTelegramBot.Data.Repositories;

namespace ScheduleTelegramBot.Bot.Extensions.ServicesExtensions
{
    public static class AddDbExtension
    {
        public static void AddDbContextAndRepositories(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(connectionString));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
