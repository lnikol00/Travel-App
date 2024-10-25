
using Backend.Logic.CarsLogic;
using Backend.Logic.EmployeeLogic;
using Backend.Logic.TravelOrdersLogic;
using Backend.Models;
using Backend.Services.CarsService;
using Backend.Services.EmployeeService;
using Backend.Services.Models;
using Backend.Services.TravelOrdersService;
using Microsoft.EntityFrameworkCore;

namespace Backend
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

            // Employee
            builder.Services.AddScoped<IEmployeeLogic, EmployeeLogic>();
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();

            // Cars
            builder.Services.AddScoped<ICarsLogic, CarsLogic>();
            builder.Services.AddScoped<ICarsService, CarsService>();

            // TravelOrder
            builder.Services.AddScoped<ITravelOrdersLogic, TravelOrdersLogic>();
            builder.Services.AddScoped<ITravelOrdersService, TravelOrdersService>();

            builder.Services.AddCors(p => p.AddPolicy("cors_policy_allow_all", builder =>
            {
                builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
            }));

            // Validation
            builder.Services.Configure<EmployeeValidation>(builder.Configuration.GetSection("EmployeeValidation"));
            builder.Services.Configure<CarsValidation>(builder.Configuration.GetSection("CarsValidation"));
            builder.Services.Configure<TravelOrderValidation>(builder.Configuration.GetSection("TravelOrderValidation"));

            // Database

            builder.Services.AddDbContext<DatabaseContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors("cors_policy_allow_all");

            app.MapControllers();

            app.Run();
        }
    }
}
