using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Aggravation.Models;
using Aggravation.Services;
using Serilog;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Aggravation
{
    class Program
    {
        public static void Main(string[] args)
        {
            var builder = new HostBuilder();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var path = $"{ Directory.GetCurrentDirectory() }\\appConfig.json";
            var configText = File.ReadAllText(path);
            var config = JsonConvert.DeserializeObject<Config>(configText);

            Log.Logger =  new LoggerConfiguration()
                                .WriteTo.File("Logs\\log.txt", rollingInterval: RollingInterval.Day)
                                .CreateLogger();


            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<Config>(config);
                    services.AddHostedService<Worker>();
                })
                .ConfigureLogging((hostContext, logging) =>
                {
                    logging.AddSerilog();
                })
                .UseWindowsService();
        }

    }

}
