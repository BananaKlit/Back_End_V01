using BackEnd.Api.DAL.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services,
            WebApplicationBuilder builder)
        {
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddDbContext<MyContext>(options =>
               options.UseSqlServer("Server=DESKTOP-IA0QE6J;Database=Bakom_car;Integrated Security=True"));
            
            builder.Services.AddMediatR(typeof(Program));
            builder.Services.AddAutoMapper(typeof(Program));
            return services;
        }

    }
}
