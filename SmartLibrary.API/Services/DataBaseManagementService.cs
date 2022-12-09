using Microsoft.EntityFrameworkCore;
using SmartLibrary.API.Data;
using SmartLibrary.API.Models;
using NetDevPack.Identity.Jwt;
using NetDevPack.Identity.User;
using NetDevPack.Identity;
using NetDevPack.Identity.Data;

namespace SmartLibrary.API.Services
{
    public static class DataBaseManagementService
    {
        public static void MigrationInitialisation(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope()) 
            {
                serviceScope.ServiceProvider.GetService<SmartContext>().Database.Migrate();
                serviceScope.ServiceProvider.GetService<NetDevPackAppDbContext>().Database.Migrate();
            }
        }
    }
}
