using Benner.DeveloperEvaluation.IoC;
using Benner.DeveloperEvaluation.ORM;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Benner.DeveloperEvaluation.Common.Security;
using Benner.DeveloperEvaluation.Application;
using Benner.DeveloperEvaluation.Common.Validation;
using MediatR;
using System.Text.Json.Serialization;
using Benner.DeveloperEvaluation.WebApi.Middleware;
using System.Data.Common;

public class Program
{
    private static void Main(string[] args)
    {
        try
        {

            Log.Information("Starting web application");

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

            builder.Services.AddDbContext<DefaultContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ServerConnection"),
                        optionsOptions => {
                            optionsOptions.EnableRetryOnFailure(
                                maxRetryCount: 5,
                                maxRetryDelay: TimeSpan.FromSeconds(10),
                                errorNumbersToAdd: new[] { 1205 }
                            );
                        }
                )
            );

            builder.Services.AddJwtAuthentication(builder.Configuration);

            builder.RegisterDependencies();

            builder.Services.AddAutoMapper(typeof(Program).Assembly, typeof(ApplicationLayer).Assembly);

            builder.Services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblies(
                    typeof(ApplicationLayer).Assembly,
                    typeof(Program).Assembly
                );
            });

            builder.Services.AddCors();

            builder.Services.AddMvc()
                 .AddJsonOptions(
                     options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles
                 );

            builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            var app = builder.Build();

            app.UseMiddleware<ValidationExceptionMiddleware>();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Application terminated unexpectedly");
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }
}