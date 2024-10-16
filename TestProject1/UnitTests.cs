using Logic;
using Xunit;

namespace TestLogic
{
    public class UnitTests
    {
        [Fact]
        public void TestComputeAverages()
        {
            Unit unit = new Unit("UE1", 1);
            Logic.Module module1 = new Module("Math", 1);
            Logic.Module module2 = new Module("Physics", 1);
            unit.AddModule(module1);
            unit.AddModule(module2);

            Exam[] exams = {
                new Exam(module1, 1, 15),
                new Exam(module1, 2, 10),
                new Exam(module2, 3, 20)
            };

            var avgScores = unit.ComputeAverages(exams);
            Assert.Equal(2, avgScores.Length); // Devrait retourner des moyennes pour les deux modules
        }

        [Fact]
        public void TestComputeAverages_NoModules_ReturnsEmptyArray()
        {
            Unit unit = new Unit("UE1", 1);
            var avgScores = unit.ComputeAverages(new Exam[0]); // Pas de modules
            Assert.Empty(avgScores);
        }
    }
}
