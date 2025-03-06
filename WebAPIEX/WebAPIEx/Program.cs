using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebAPIEx.Data;
namespace WebAPIEx
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<WebAPIExContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("WebAPIExContext") ?? throw new InvalidOperationException("Connection string 'WebAPIExContext' not found.")));

            // Add services to the container.

            builder.Services.AddControllers();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
