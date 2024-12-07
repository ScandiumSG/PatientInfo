
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

            var app = builder.Build();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();

            app.PatientEndpointConfiguration();

            app.MapFallbackToFile("/index.html");

            app.Run();
        }
    }
}
