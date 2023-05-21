using Lily.Community.Games;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace Lily.Community.Tests.Games;

public class EightBallCommandTests
{
    [Fact]
    public void NullRandom_ThrowsArgumentNullException()
    {
        // Arrange
        Random random = null!;
        ILogger<EightBallCommand> logger = Substitute.For<ILogger<EightBallCommand>>();;

        // Act
        void TestCreation() => new EightBallCommand(random, logger);

        // Assert
        Assert.Throws<ArgumentNullException>(TestCreation);
    }
}