
using Backend.Logic.CarsLogic;
using Backend.Logic.EmployeeLogic;
using Backend.Logic.TravelOrdersLogic;
using Backend.Models;
using Backend.Services.CarsService;
using Backend.Services.EmployeeService;
using Backend.Services.TravelOrdersService;

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
            builder.Services.AddSingleton<IEmployeeLogic, EmployeeLogic>();
            builder.Services.AddSingleton<IEmployeeService, EmployeeService>();

            // Cars
            builder.Services.AddSingleton<ICarsLogic, CarsLogic>();
            builder.Services.AddSingleton<ICarsService, CarsService>();

            // TravelOrder
            builder.Services.AddSingleton<ITravelOrdersLogic, TravelOrdersLogic>();
            builder.Services.AddSingleton<ITravelOrdersService, TravelOrdersService>();

            builder.Services.AddCors(p => p.AddPolicy("cors_policy_allow_all", builder =>
            {
                builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
            }));

            // Validation
            builder.Services.Configure<EmployeeValidation>(builder.Configuration.GetSection("EmployeeValidation"));
            builder.Services.Configure<CarsValidation>(builder.Configuration.GetSection("CarsValidation"));
            builder.Services.Configure<TravelOrderValidation>(builder.Configuration.GetSection("TravelOrderValidation"));

            // Database
            builder.Services.Configure<DBConfiguration>(builder.Configuration.GetSection("Database"));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
