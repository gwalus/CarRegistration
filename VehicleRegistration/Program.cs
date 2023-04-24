using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using VehicleRegistration.Data;
using VehicleRegistration.Models;

namespace VehicleRegistration
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;

            var context = services.GetRequiredService<DataContext>();
            await context.Database.MigrateAsync();

            if (!context.Prefixes.Any())
            {
                var file = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "codes.txt"));
                var codes = file.Split(null);
                codes = codes.Where(x => x != string.Empty).ToArray();

                foreach (var code in codes)
                {
                    context.Prefixes.Add(new Prefix { Name = code });
                }
                await context.SaveChangesAsync();
            }
                
            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
