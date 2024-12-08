
using Backend.Data;
using Backend.Endpoint;
using Backend.Models;
using Backend.Repository;
using Microsoft.EntityFrameworkCore;

namespace PatientInfo.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("PatientInMemoryDatabase"));

            builder.Services.AddScoped<IRepository<Patient>, Repository<Patient>>();
            builder.Services.AddScoped<PatientRepository, PatientRepository>();

            // Add CORS policy that allows everything
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy
                        .AllowAnyOrigin()    // Allows any origin
                        .AllowAnyMethod()    // Allows any HTTP method (GET, POST, PUT, DELETE, etc.)
                        .AllowAnyHeader();   // Allows any headers
                });
            });

            var app = builder.Build();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("AllowAll");
            app.UseHttpsRedirection();
            app.UseAuthorization();

            app.PatientEndpointConfiguration();

            app.MapFallbackToFile("/index.html");

            app.Run();
        }
    }
}
