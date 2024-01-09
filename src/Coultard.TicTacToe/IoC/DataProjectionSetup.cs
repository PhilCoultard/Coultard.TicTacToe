using Microsoft.Extensions.Options;

namespace Coultard.TicTacToe.IoC;

public static class DataProjectionSetup
{
    public static void RegisterSettings(this IServiceCollection services, IConfiguration config)
    {
        // services.ConfigureAndValidate<DataProjectionSettings>(config);
        // services.AddTransient(sp =>
        //     sp.GetRequiredService<IOptions<DataProjectionSettings>>().Value);
    }
}