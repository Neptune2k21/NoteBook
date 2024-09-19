using Logic;
using Xunit;

namespace TestLogic
{
    public class UnitTests
    {
        [Fact]
        public void AddModule_ValidModule_ShouldAddToUnit()
        {

            var unit = new Unit("Mathématiques", 5.0f);
            var module = new Module("Algèbre", 2.0f);

            unit.AddModule(module);


            Assert.Contains(module, unit.Modules);
        }

        [Fact]
        public void AddModule_NullModule_ShouldThrowArgumentException()
        {

            var unit = new Unit("Mathématiques", 5.0f);

            Assert.Throws<ArgumentException>(() => unit.AddModule(null));
        }

        [Fact]
        public void RemoveModule_ModuleNotInUnit_ShouldThrowArgumentException()
        {

            var unit = new Unit("Mathématiques", 5.0f);
            var module = new Module("Algèbre", 2.0f);


            Assert.Throws<ArgumentException>(() => unit.RemoveModule(module));
        }

        [Fact]
        public void RemoveModule_ModuleInUnit_ShouldRemoveFromUnit()
        {

            var unit = new Unit("Mathématiques", 5.0f);
            var module = new Module("Algèbre", 2.0f);
            unit.AddModule(module);

            unit.RemoveModule(module);

            Assert.DoesNotContain(module, unit.Modules);
        }
    }
}
