using Microsoft.Extensions.Logging;

namespace Lily.Core.Tests.Commands;

public class CommandTests
{
    [Fact]
    public void NullLogger_ThrowsArgumentNullException()
    {
        // Arrange
        ILogger<MockCommand<object>> logger = null!;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => new MockCommand<object>(logger));
    }
}
