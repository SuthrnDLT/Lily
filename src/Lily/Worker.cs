using System.Diagnostics.CodeAnalysis;
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
    private readonly SecretService _secretService;
    private readonly ILogger _logger;

    public Worker(
        DiscordSocketClient client,
        CommandService commandService,
        SecretService secretService,
        ILogger<Worker> logger)
    {
        _client = client;
        _commandService = commandService;
        _secretService = secretService;
        _logger = logger;
    }

    [SuppressMessage(
        "Microsoft.Security",
        "CA1848:AvoidUseOfRuntimeUnverifiableCode",
        Justification = "High performance logging is not needed right now.")]
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
        string token = _secretService.Get("DiscordToken") ?? throw new InvalidOperationException("Discord token is null or empty.");

        _logger.Log(LogLevel.Information, "Attempting to login to Discord.");
        await _client.LoginAsync(TokenType.Bot, token).ConfigureAwait(continueOnCapturedContext: false);

        _logger.Log(LogLevel.Information, "Attempting to start Discord client.");
        await _client.StartAsync().ConfigureAwait(continueOnCapturedContext: false);
    }
}
