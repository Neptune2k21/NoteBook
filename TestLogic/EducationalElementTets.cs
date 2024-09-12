using Logic;
using System.Reflection;
using Xunit;

namespace TestLogic
{
    public class EducationalElementTests
    {
        [Fact]
        public void Constructor_ValidParameters_ShouldCreateObject()
        {
            // Arrange & Act
            var element = new Module("Algèbre", 2.0f);

            // Assert
            Assert.Equal("Algèbre", element.Name);
            Assert.Equal(2.0f, element.Coefficient);
        }

        [Fact]
        public void Constructor_InvalidName_ShouldThrowArgumentException()
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentException>(() => new Module("", 2.0f));
        }

        [Fact]
        public void Constructor_InvalidCoefficient_ShouldThrowArgumentException()
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentException>(() => new Module("Algèbre", 0));
        }
    }
}
