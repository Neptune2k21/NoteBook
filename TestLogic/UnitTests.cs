using Logic;
using Xunit;

namespace TestLogic
{
    public class UnitTests
    {
        [Fact]
        public void AddModule_ValidModule_ShouldAddToUnit()
        {
            // Arrange
            var unit = new Unit("Mathématiques", 5.0f);
            var module = new Module("Algèbre", 2.0f);

            // Act
            unit.AddModule(module);

            // Assert
            Assert.Contains(module, unit.Modules);
        }

        [Fact]
        public void AddModule_NullModule_ShouldThrowArgumentException()
        {
            // Arrange
            var unit = new Unit("Mathématiques", 5.0f);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => unit.AddModule(null));
        }

        [Fact]
        public void RemoveModule_ModuleNotInUnit_ShouldThrowArgumentException()
        {
            // Arrange
            var unit = new Unit("Mathématiques", 5.0f);
            var module = new Module("Algèbre", 2.0f);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => unit.RemoveModule(module));
        }

        [Fact]
        public void RemoveModule_ModuleInUnit_ShouldRemoveFromUnit()
        {
            // Arrange
            var unit = new Unit("Mathématiques", 5.0f);
            var module = new Module("Algèbre", 2.0f);
            unit.AddModule(module);

            // Act
            unit.RemoveModule(module);

            // Assert
            Assert.DoesNotContain(module, unit.Modules);
        }
    }
}
