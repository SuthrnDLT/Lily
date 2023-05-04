using Discord.Commands;
using Discord.WebSocket;

namespace Microsoft.Extensions.DependencyInjection;

internal static class DependencyInjectionExtensions
{
    internal static IServiceCollection AddDiscord(this IServiceCollection services)
    {
        var commandServiceConfiguration = new CommandServiceConfig {
            CaseSensitiveCommands = false,
            ThrowOnError = true,
            IgnoreExtraArgs = true
        };

        var commandService = new CommandService(commandServiceConfiguration);
        return services.AddSingleton(commandService)
            .AddSingleton<DiscordSocketClient>();

    }
}
