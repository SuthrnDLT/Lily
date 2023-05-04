#pragma warning disable CA1852 // Disable 1852 on the basis that sealing Program is not a concern for this project.

using Lily;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((hostingContext, config) => {
        config.AddUserSecrets("0xlily");
    })
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>()
                .AddDiscord();
    })
    .Build();

host.Run();
