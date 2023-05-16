using Lily.Core.Commands;
using Microsoft.Extensions.Logging;

namespace Lily.Core.Tests.Commands;

/// <summary>
/// Represents a mock <see cref="Command"/> for testing purposes.
/// </summary>
/// <typeparam name="TCategory">Specifies the category the mock command should use for its logger.</typeparam>
internal class MockCommand<TCategory> : Command
{
    /// <summary>
    /// Creates a new <see cref="MockCommand{TCategory}"/> instance.
    /// </summary>
    /// <param name="logger">The <see cref="ILogger{TCategory}"/> to use for logging.</param>
    public MockCommand(ILogger<TCategory> logger) :
        base(logger)
    { }
}