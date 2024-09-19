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

            var notebook = new Notebook();


            var units = notebook.ListUnits();


            Assert.Empty(units);
        }

        [Fact]
        public void AddUnit_ShouldAddUnitSuccessfully()
        {

            var notebook = new Notebook();
            var unit = new Unit("Mathématiques", 5.0f);

            notebook.AddUnit(unit);
            var units = notebook.ListUnits();


            Assert.Single(units);
            Assert.Equal("Mathématiques", units[0].Name);
        }

        [Fact]
        public void AddUnit_WithDuplicateName_ShouldThrowException()
        {

            var notebook = new Notebook();
            var unit1 = new Unit("Mathématiques", 5.0f);
            var unit2 = new Unit("Mathématiques", 4.0f);


            notebook.AddUnit(unit1);

            Assert.Throws<ArgumentException>(() => notebook.AddUnit(unit2));
        }

        [Fact]
        public void RemoveUnit_ShouldRemoveUnitSuccessfully()
        {

            var notebook = new Notebook();
            var unit = new Unit("Mathématiques", 5.0f);
            notebook.AddUnit(unit);


            notebook.RemoveUnit(unit);
            var units = notebook.ListUnits();


            Assert.Empty(units);
        }

        [Fact]
        public void RemoveUnit_NotInList_ShouldThrowException()
        {

            var notebook = new Notebook();
            var unit = new Unit("Physique", 5.0f);

            Assert.Throws<ArgumentException>(() => notebook.RemoveUnit(unit));
        }
    }
}

