using Lily.Community.Games;

namespace Lily.Community.Tests.Games;

public class EightBallCommandTests
{
    [Fact]
    public void NullRandom_ThrowsArgumentNullException()
    {
        // Arrange
        Random random = null!;

        // Act
        void TestCreation() => new EightBallCommand(random, null!);

        // Assert
        Assert.Throws<ArgumentNullException>(TestCreation);
    }
}