using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Logic;
using Xunit;

namespace TestLogic
{
    public class TestNotebook
    {
        [Fact]
        public void Notebook_ShouldStartWithEmptyUnitsList()
        {
            // Arrange
            var notebook = new Notebook();

            // Act
            var units = notebook.ListUnits();

            // Assert
            Assert.Empty(units);
        }

        [Fact]
        public void AddUnit_ShouldAddUnitSuccessfully()
        {
            // Arrange
            var notebook = new Notebook();
            var unit = new Unit("Mathématiques", 5.0f);

            // Act
            notebook.AddUnit(unit);
            var units = notebook.ListUnits();

            // Assert
            Assert.Single(units);
            Assert.Equal("Mathématiques", units[0].Name);
        }

        [Fact]
        public void AddUnit_WithDuplicateName_ShouldThrowException()
        {
            // Arrange
            var notebook = new Notebook();
            var unit1 = new Unit("Mathématiques", 5.0f);
            var unit2 = new Unit("Mathématiques", 4.0f);

            // Act
            notebook.AddUnit(unit1);

            // Assert
            Assert.Throws<ArgumentException>(() => notebook.AddUnit(unit2));
        }

        [Fact]
        public void RemoveUnit_ShouldRemoveUnitSuccessfully()
        {
            // Arrange
            var notebook = new Notebook();
            var unit = new Unit("Mathématiques", 5.0f);
            notebook.AddUnit(unit);

            // Act
            notebook.RemoveUnit(unit);
            var units = notebook.ListUnits();

            // Assert
            Assert.Empty(units);
        }

        [Fact]
        public void RemoveUnit_NotInList_ShouldThrowException()
        {
            // Arrange
            var notebook = new Notebook();
            var unit = new Unit("Physique", 5.0f);

            // Assert
            Assert.Throws<ArgumentException>(() => notebook.RemoveUnit(unit));
        }
    }
}

