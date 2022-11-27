using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NetDevPack.Identity.Jwt;
using SmartLibrary.API.Data;

using NetDevPack.Identity.User;
using NetDevPack.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace SmartLibrary.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //Enable CORS
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOriginVue", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            services.AddDbContext<SmartContext>(context => context.UseSqlite(Configuration.GetConnectionString("Default")));

            services.AddScoped<IRepository, Repository>();

            //JSON Serializer 
            services.AddControllers()
                .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling =
                Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //////Authentication and Authorization
            services.AddIdentityEntityFrameworkContextConfiguration(options =>
                options.UseSqlite(Configuration.GetConnectionString("Default")));

            services.AddJwtConfiguration(Configuration, "AppSettings");
            
            services.AddIdentityConfiguration();

            ////// Setting the interactive AspNetUser (logged in)
            //services.AddAspNetUserConfiguration();


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Enter the JWT token in this format: Bearer {your token}",
                    Name = "Authorization",
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}
                        }
                    });
            });

        }
        public void Configure(WebApplication app, IWebHostEnvironment environment)
        {
            //Enable CORS
            app.UseCors("AllowOriginVue");

            // Configure the HTTP request pipeline.
            if (environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthConfiguration();
            //app.UseAuthorization();

            app.MapControllers();
        }
    }
}
