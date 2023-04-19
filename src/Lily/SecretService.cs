namespace Lily;

// Disabled because this class is injected into the DI container.
#pragma warning disable CA1812

internal sealed class SecretService
{
    private readonly ILogger _logger;
    private readonly IConfigurationRoot _configuration;
    
    public SecretService(ILogger<SecretService> logger)
    {
        _logger = logger;
        _configuration = new ConfigurationBuilder()
            .AddUserSecrets("0xlily")
            .Build();
    }

    public string? Get(string key)
    {
        if (string.IsNullOrWhiteSpace(key))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

        _logger.Log(LogLevel.Information, $"Attempting to retrieve secret {key}.");
        string? result = _configuration[key];

        if (string.IsNullOrWhiteSpace(result))
            _logger.Log(LogLevel.Warning, $"Secret {key} is null or empty.");
            
        return result;
    }
}
