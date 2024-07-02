
using DapperStoredProcedure.Services;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace DapperStoredProcedure
{
    public class Program
    {
        IConfiguration _configuration;
       
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            var services = builder.Services;

            /*services.AddCors(option => option.AddPolicy("APIPolicy", builder => {
                builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
            }));*/

            IConfiguration conf = builder.Configuration; 
            

        services.AddTransient<IDapperRepository, DapperRepository>(provider => new DapperRepository(conf));

            // Add services to the container.

          

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

           // app.UseCors("APIPolicy");

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