using Coultard.TicTacToe.IoC;
using Coultard.DotNet.Prog;

namespace Coultard.TicTacToe;

public static class Program
{
    public static async Task<int> Main(string[] args)
    {
        var app = Host
            .CreateDefaultBuilder(args)
            .ConfigureConfig(args)
            .ConfigureLogs()
            .RegisterServices()
            .UseConsoleLifetime()
            .Build();

        await app.RunAsync();
        return 0;
    }


    private static IHostBuilder RegisterServices(this IHostBuilder hostBuilder)
    {
        hostBuilder.ConfigureServices((hostContext, services) =>
        {
            services.RegisterServices(hostContext.Configuration);
        });

        return hostBuilder;
    }

    public static void RegisterServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddOptions();

        // Configuration
        services.AddTransient(_ => config);

        // Worker
        services.AddHostedService<Worker>();

        // Business logic services
        services.RegisterSettings(config);
    }
}