
using Lily.Core.Commands;
using Microsoft.Extensions.Logging;

namespace Lily.Community.Games;

public sealed class EightBallCommand : Command
{
    private readonly Random _random;

    public EightBallCommand(Random random, ILogger<EightBallCommand> logger) :
        base(logger)
    {
        if (random is null)
            throw new ArgumentNullException(nameof(random));

        _random = random;
    }

    [Command("8ball", "Ask the magic 8-ball a question.")]
    public async Task Identify()
    {
        Logger.LogInformation("Received invocation for the identify command.");
        
        string message = "TODO: Implement 8ball command.";

        await ReplyAsync(message);
    }
}
