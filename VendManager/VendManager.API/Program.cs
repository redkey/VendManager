
using VendManager.API.Middleware;
using VendManager.Application;
using VendManager.Infrastructure;
using VendManager.Persistence;
using VendManager.Identity;
using Microsoft.AspNetCore.DataProtection;
namespace VendManager.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddInfrastructureServices(builder.Configuration);
            builder.Services.AddPersistenceServices(builder.Configuration);
            builder.Services.AddIdentityServices(builder.Configuration);
            builder.Services.AddApplicationServices();

            builder.Services.AddDataProtection()
     // Persist keys to a shared folder accessible by all servers
     .PersistKeysToFileSystem(new DirectoryInfo(@"C:\Users\Public\Keys"))
     // Set a unique application name to ensure key isolation from other apps
     .SetApplicationName("MyBlazorApp");

            builder.Services.AddControllers();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Read the "ShowDetailedErrors" setting from appsettings.json
            var showDetailedErrors = builder.Configuration.GetValue<bool>("ShowDetailedErrors");

            app.UseMiddleware<ExceptionMiddleware>();

            //// Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
            //    app.UseSwagger();
            //    app.UseSwaggerUI();
            //}

            // Show developer errors if the setting is true
            if (showDetailedErrors)
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // Optionally use a global exception handler for production errors
                app.UseMiddleware<ExceptionMiddleware>();
            }

            app.UseHttpsRedirection();

            app.UseCors("AllowAll");

            app.UseAuthentication();
            app.UseAuthorization();

            // Use Swagger UI
            app.UseSwagger();
            app.UseSwaggerUI();

            app.MapControllers();

            app.Run();
        }
    }
}
