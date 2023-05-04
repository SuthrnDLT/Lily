using DiscordCommandAttribute = Discord.Commands.CommandAttribute;

namespace Lily.Core.Commands;

/// <summary>
/// Represents an <see cref="Attribute"/> for marking <see cref="Command"/>s.
/// </summary>
public sealed class CommandAttribute : DiscordCommandAttribute
{
    /// <summary>
    /// Creates a new <see cref="CommandAttribute"/> instance.
    /// </summary>
    /// <param name="key">Gets or sets the key for invoking the <see cref="Command"/>.</param>
    public CommandAttribute(string name) :
        base(name)
    { }
}
