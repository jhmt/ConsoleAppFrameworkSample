using System;
using System.IO;
using System.Threading.Tasks;
using ConsoleAppFramework;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace ConsoleAppFrameworkSample
{
    class Program : ConsoleAppBase
    {
        static async Task Main(string[] args)
        {
            Log.Logger = CreateLogger();
            try
            {
                Log.Logger.Information("starting app now...");
                await Host.CreateDefaultBuilder().RunConsoleAppFrameworkAsync<Program>(args);
            }
            catch (Exception ex)
            {
                Log.Logger.Error($"{ex.Message}");
            }
        }

        public void Run()
        {
            Console.WriteLine($"Hello My ConsoleApp");
        }

        public static ILogger CreateLogger() =>
            new LoggerConfiguration()
                .ReadFrom.Configuration(CreateBuilder().Build())
                .CreateLogger();
        
        public static IConfigurationBuilder CreateBuilder() =>
             new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                // .SetBasePath(GetBasePath())
                .AddJsonFile("appsettings.json", false)
                .AddEnvironmentVariables();
    }

    // Batches.
    public class Foo : ConsoleAppBase
    {
        public void Echo(string msg)
        {
            Console.WriteLine(msg);
        }

        public void Sum(int x, int y)
        {
            Console.WriteLine((x + y).ToString());
        }
    }
}
