using Discord.Commands;
using Microsoft.Extensions.Logging;

namespace Lily.Core.Commands;

/// <summary>
/// Represents a command for execution by Lily.
/// </summary>
public abstract class Command : ModuleBase<SocketCommandContext>
{
    /// <summary>
    /// Creates a new <see cref="Command"/> instance.
    /// </summary>
    /// <param name="logger">The logger the command should use.</param>
    public Command(ILogger logger) =>
        Logger = logger;

    /// <summary>
    /// Gets the <see cref="ILogger"/> utilized by this command instance.
    /// </summary>
    protected ILogger Logger { get; private set; }
}
