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
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.Log(LogLevel.Information, $"Worker running at: {DateTimeOffset.Now}");
            await Task.Delay(millisecondsDelay: 1000, stoppingToken)
                      .ConfigureAwait(continueOnCapturedContext: false);
        }
    }
}
