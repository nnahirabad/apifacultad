
using ApiFacultad.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiFacultad
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
            builder.Services.AddEntityFrameworkNpgsql().
            AddDbContext<FacultadContext>
            (options => options.UseNpgsql(builder.Configuration.GetConnectionString("ConexionDatabase")));

            builder.Services.AddCors();


            var app = builder.Build();

            AppContext.SetSwitch("NpgSql.EnableLegacyTimestampBehavior", true);

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(c =>
            {
                c.AllowAnyMethod();
                c.AllowAnyHeader();
                c.AllowAnyOrigin();
            });
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
