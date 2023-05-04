# Notes

The following snippet is provided by Chat GPT to guide the simplification of the bot's foundation.

```csharp
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace SampleBot
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Create a new instance of DiscordSocketClient
            var client = new DiscordSocketClient();

            // Add the CommandService to the ServiceCollection
            var services = new ServiceCollection()
                .AddSingleton(new CommandService(new CommandServiceConfig
                {
                    CaseSensitiveCommands = false,
                    ThrowOnError = true,
                    IgnoreExtraArgs = true
                }))
                .AddSingleton<SampleGreetingService>();

            // Build the ServiceCollection and create a new ServiceProvider
            var serviceProvider = services.BuildServiceProvider();

            // Set up the command handler using the CommandService and ServiceProvider
            var commandHandler = new CommandHandler(client, serviceProvider);
            await commandHandler.InstallCommandsAsync();

            // Log in to Discord using your bot token
            await client.LoginAsync(TokenType.Bot, "your_bot_token_here");
            await client.StartAsync();

            // Keep the bot running until it is stopped
            await Task.Delay(-1);
        }
    }

    public class SampleGreetingService
    {
        public string Greet() => "Hello, world!";
    }

    public class GreetCommand : ModuleBase<SocketCommandContext>
    {
        private readonly SampleGreetingService _greetingService;

        public GreetCommand(SampleGreetingService greetingService)
        {
            _greetingService = greetingService;
        }

        [Command("greet")]
        public async Task GreetAsync()
        {
            await ReplyAsync(_greetingService.Greet());
        }
    }

    public class CommandHandler
    {
        private readonly DiscordSocketClient _client;
        private readonly CommandService _commandService;
        private readonly IServiceProvider _serviceProvider;

        public CommandHandler(DiscordSocketClient client, IServiceProvider serviceProvider)
        {
            _client = client;
            _commandService = serviceProvider.GetService<CommandService>();
            _serviceProvider = serviceProvider;

            // Subscribe to the MessageReceived event to handle commands
            _client.MessageReceived += HandleCommandAsync;
        }

        public async Task InstallCommandsAsync()
        {
            // Add the GreetCommand to the CommandService
            await _commandService.AddModuleAsync<GreetCommand>(_serviceProvider);
        }

        private async Task HandleCommandAsync(SocketMessage message)
        {
            // Ignore system messages and messages from bots
            if (!(message is SocketUserMessage userMessage) || userMessage.Author.IsBot)
            {
                return;
            }

            // Create a CommandContext for the message
            var context = new SocketCommandContext(_client, userMessage);

            // Execute the command if it is recognized by the CommandService
            int argPos = 0;
            if (_commandService.HasCommand(userMessage.Content, ref argPos))
            {
                await _commandService.ExecuteAsync(context, argPos, _serviceProvider);
            }
        }
    }
}
```

The prompt for this snippet was simple:

> I want to create a sample discord bot written in C#. It should feature a sample greeting service that has one method:
>
> ```csharp
> public string Greet() => "Hello, world!";
> ```
>
> It should have a single slash command that is encapsulated in a class and uses the sample greeting service to send the results of `Greet` to the invoking user. The sample greeting service should be injected into the command through its constructor using dependency injection.
