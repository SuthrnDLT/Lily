using System.Diagnostics.CodeAnalysis;

namespace Lily;

public class Worker : BackgroundService
{
    private readonly ILogger _logger;

    public Worker(ILogger<Worker> logger)
    {
        _logger = logger;
    }

    [SuppressMessage(
        "Microsoft.Security",
        "CA1848:AvoidUseOfRuntimeUnverifiableCode",
        Justification = "High performance logging is not needed right now.")]
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.Log(LogLevel.Information, $"Starting Lily.");
        return Task.CompletedTask;
    }
}
