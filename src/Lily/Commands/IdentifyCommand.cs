using Lily.Core.Commands;

namespace Lily.Commands;

internal sealed class IdentifyCommand : Command
{
    public IdentifyCommand(ILogger<IdentifyCommand> logger) :
        base(logger)
    { }

    [Command("identify", "Prompts Lily to identify herself.")]
    public async Task Identify()
    {
        Logger.LogInformation("Received invocation for the identify command.");
        string message = "👋 Hey there! I'm Lily, a simple but ambitious chatbot created by tacosontitan.";
        await ReplyAsync(message);
    }
}
