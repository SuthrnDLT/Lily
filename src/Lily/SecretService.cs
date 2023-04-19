namespace Lily;

// Disabled because this class is injected into the DI container.
#pragma warning disable CA1812

internal sealed class SecretService
{
    private readonly IConfigurationRoot _configuration;
    
    public SecretService()
    {
        _configuration = new ConfigurationBuilder()
            .AddUserSecrets<Program>()
            .Build();
    }

    public string? Get(string key)
    {
        if (string.IsNullOrWhiteSpace(key))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

        string? result = _configuration[key];
        return result;
    }
}
