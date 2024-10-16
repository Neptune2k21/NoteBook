using Logic;
using Xunit;

namespace TestLogic
{
    public class TestNotebook
    {
        [Fact]
        public void TestComputeOverallAverage()
        {
            Notebook notebook = new Notebook();
            Unit unit = new Unit("UE1", 1);
            notebook.AddUnit(unit); 

            Logic.Module module1 = new Module("Math", 1);
            Logic.Module module2 = new Module("Physics", 1);
            unit.AddModule(module1);
            unit.AddModule(module2);

            Exam[] exams = {
                new Exam(module1, 1, 15),
                new Exam(module1, 2, 10),
                new Exam(module2, 3, 20)
            };

            foreach (var exam in exams)
            {
                notebook.AddExam(exam);
            }

            var avgScore = notebook.ComputeOverallAverage(); 
            Assert.NotNull(avgScore);
            Assert.Equal("Moyenne Générale", avgScore.Element.Name);
            Assert.Equal(15.0f, avgScore.Average); 
        }

        [Fact]
        public void TestComputeOverallAverage_NoUnits_ReturnsNull()
        {
            Notebook notebook = new Notebook();
            var avgScore = notebook.ComputeOverallAverage();
            Assert.Null(avgScore);
        }
    }
}
