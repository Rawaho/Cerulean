using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Cerulean.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseUrls("http://localhost");
                    webBuilder.UseStartup<Startup>();
                });
    }
}
