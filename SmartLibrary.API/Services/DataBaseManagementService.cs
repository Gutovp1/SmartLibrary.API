using Microsoft.EntityFrameworkCore;
using SmartLibrary.API.Data;
using SmartLibrary.API.Models;

namespace SmartLibrary.API.Services
{
    public static class DataBaseManagementService
    {
        public static void MigrationInitialisation(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope()) 
            {
                serviceScope.ServiceProvider.GetService<SmartContext>().Database.Migrate();
            }
        }
    }
}
