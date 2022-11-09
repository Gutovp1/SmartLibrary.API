using Microsoft.EntityFrameworkCore;
using SmartLibrary.API.Data;

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
                c.AddPolicy("AllowOrigin", options => options.WithOrigins("http://localhost:8080").AllowAnyMethod().AllowAnyHeader());
            });

            services.AddDbContext<SmartContext>(context => context.UseSqlite(Configuration.GetConnectionString("Default")));

            services.AddScoped<IRepository, Repository>();

            //JSON Serializer 
            services.AddControllers()
                .AddNewtonsoftJson(opt =>opt.SerializerSettings.ReferenceLoopHandling = 
                Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }
        public void Configure(WebApplication app, IWebHostEnvironment environment)
        {
            //Enable CORS
            app.UseCors(options=>options.WithOrigins("http://localhost:8080").AllowAnyMethod().AllowAnyHeader());

            // Configure the HTTP request pipeline.
            if (environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();

            app.MapControllers();
        }
    }
}
