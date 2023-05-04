using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace Lily;

// Disabled because this class is injected into the DI container.
#pragma warning disable CA1812

internal sealed class Worker : BackgroundService
{
    private readonly DiscordSocketClient _client;
    private readonly CommandService _commandService;
    private readonly IConfiguration _configuration;
    private readonly ILogger _logger;

    public Worker(
        IConfiguration configuration,
        DiscordSocketClient client,
        CommandService commandService,
        ILogger<Worker> logger)
    {
        _client = client;
        _commandService = commandService;
        _configuration = configuration;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.Log(LogLevel.Information, $"Starting Lily.");
        _client.Connected += () =>
        {
            _logger.Log(LogLevel.Information, "Connected to Discord.");
            return Task.CompletedTask;
        };

        _client.Disconnected += (exception) =>
        {
            _logger.Log(LogLevel.Information, "Disconnected from Discord.");
            _logger.Log(LogLevel.Information, exception.Message);
            return Task.CompletedTask;
        };

        _logger.Log(LogLevel.Information, "Attempting to load authentication information.");
        string token = _configuration["discordToken"] ?? throw new InvalidOperationException("Discord token is null or empty.");

        _logger.Log(LogLevel.Information, "Attempting to login to Discord.");
        await _client.LoginAsync(TokenType.Bot, token).ConfigureAwait(continueOnCapturedContext: false);

        _logger.Log(LogLevel.Information, "Attempting to start Discord client.");
        await _client.StartAsync().ConfigureAwait(continueOnCapturedContext: false);
    }
}
