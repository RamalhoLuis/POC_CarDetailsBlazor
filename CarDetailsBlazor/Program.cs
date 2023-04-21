using CarDetailsBlazor.Interfaces;
using CarDetailsModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using MediatR;
using System.Reflection;
using CarDetailsAPI;
using CarDetailsAPI.Queries;

namespace CarDetailsBlazor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddHttpClient();
            builder.Services.AddMvc();


            builder.Services.AddRefitClient<ICarWebServiceAPI>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://localhost:7126"));
            builder.Services.AddRefitClient<IManufacturerWebServiceAPI>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://localhost:7126"));
            builder.Services.AddRefitClient<IJointInfoWebServiceAPI>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://localhost:7126"));


            //builder.Services.AddMediatR(typeof(CarLibraryMediatREntrypoint).Assembly);

            builder.Services.AddMediatR(c => c.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            /*builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(GetCarsListQuery)));
            */






            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }
}