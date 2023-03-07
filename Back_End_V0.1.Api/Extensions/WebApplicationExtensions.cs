using BackEnd.Api.Api.Features.VoitureFeature;
using BackEnd.Api.DAL.DataAccess;
using BackEnd.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Api.Extensions
{
    public static class WebApplicationExtensions
    {
        public static WebApplication ConfigureApplication(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            
                     
            return app; }
    }
   
}
