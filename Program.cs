using DatabaseOperations.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;

namespace DatabaseOperations
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

            ConnectToMySql(builder);
           // ConnectToSqlServer(builder);
            


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

        private static void ConnectToSqlServer(WebApplicationBuilder builder)
        {
            var connectionStringSqlServer = builder.Configuration.GetConnectionString("SqlServerConnection");
            builder.Services
                .AddDbContext<MyDbContext>(o =>
                    o.UseSqlServer(connectionStringSqlServer));
        }

        protected static void ConnectToMySql(WebApplicationBuilder builder)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
            var connectionStringMySql = builder.Configuration.GetConnectionString("MySqlConnection");
            builder.Services
                .AddDbContext<MyDbContext>(o =>
                    o.UseMySql(connectionStringMySql, serverVersion));
        }
    }
}