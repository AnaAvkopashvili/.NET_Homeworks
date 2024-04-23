using PizzaRestaurant.API.infrastructure.Extensions;
using PizzaRestaurant.API.infrastructure.Mappings;
using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using Serilog;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;


namespace PizzaProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Logging.ClearProviders();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Configuration)
                .CreateLogger();

            builder.Host.UseSerilog();

            // Add services to the container.

            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddSwaggerExamplesFromAssemblyOf<Program>();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Pizza Restaurant API",
                    Version = "v1",
                    Description = "Api to manage pizza restaurant",
                    Contact = new OpenApiContact
                    {
                        Name = "Papa's Pizzeria",
                        Email = "PapasPizzeria@pizza.com",
                        Url = new Uri("https://www.friv.com/z/games/papaspizzeria/game.html"),
                    },
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                options.IncludeXmlComments(xmlPath);
                options.ExampleFilters();
            });

            builder.Services.AddServices();
            builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
            builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            builder.Services.RegisterMaps();

            var app = builder.Build();

            app.UseExceptionHandling();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseRequestResponseLogging();

            app.UseHttpsRedirection();

            //app.UseAuthorization();

            app.UseRequestCulture();

            app.MapControllers();

            app.Run();
        }
    }
}