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
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="logger"/> is <see langword="null"/>.</exception>
    public Command(ILogger logger)
    {
        if (logger is null)
            throw new ArgumentNullException(nameof(logger));

        Logger = logger;
    }

    /// <summary>
    /// Gets the <see cref="ILogger"/> utilized by this command instance.
    /// </summary>
    protected ILogger Logger { get; private set; }
}
