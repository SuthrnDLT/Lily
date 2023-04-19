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
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.Log(LogLevel.Information, $"Starting Lily.");
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.Log(LogLevel.Information, $"Lily is running.");
            await Task.Delay(millisecondsDelay: 1000, stoppingToken)
                      .ConfigureAwait(continueOnCapturedContext: false);
        }
    }
}
