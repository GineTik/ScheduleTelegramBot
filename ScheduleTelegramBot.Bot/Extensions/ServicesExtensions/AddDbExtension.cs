using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ScheduleTelegramBot.Data.EF;
using ScheduleTelegramBot.Data.Repositories;
using System.Configuration;

namespace ScheduleTelegramBot.Bot.Extensions.ServicesExtensions
{
    public static class AddDbExtension
    {
        public static void AddDbContextAndRepositories(this IServiceCollection services)
        {
            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
