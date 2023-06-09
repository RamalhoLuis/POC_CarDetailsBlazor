using CarDetailsAPI.Helpers;
using CarDetailsAPI.Queries;
using CarDetailsDataAccess.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using System.Reflection;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using AutoMapper;

namespace CarDetailsAPI
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

            // builder.Services.AddDbContext<IDataContext,AppDbContext>(option => option.UseSqlServer("Data Source=DESKTOP-7KHJ0MN\\SQLEXPRESS;Initial Catalog=CarAPPDatabase; Trusted_Connection=True; TrustServerCertificate=True;", b => b.MigrationsAssembly("CarDetailsAPI"))); //I set this on appsettings.json
            builder.Services
                .AddDbContext<IDataContext, AppDbContext>(ServiceLifetime.Scoped); //I set this on appsettings.json
            builder.Services.AddMediatR(c => c.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(TracingBehavior<,>));
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(GetCarsListQuery)));
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());





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