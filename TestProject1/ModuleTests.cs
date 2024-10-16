using Logic;
using Xunit;

namespace TestLogic
{
    public class ModuleTests
    {
        [Fact]
        public void TestComputeAverage()
        {
            Module module = new Module("Math", 1);
            Exam[] exams = {
                new Exam(module, 1, 15),
                new Exam(module, 2, 10),
                new Exam(module, 3, 20)
            };

            var avgScore = module.ComputeAverage(exams);
            Assert.NotNull(avgScore);
            Assert.Equal(15.0f, avgScore.Average); // (15*1 + 10*2 + 20*3) / (1 + 2 + 3)
        }

        [Fact]
        public void TestComputeAverage_NoExams_ReturnsNull()
        {
            Module module = new Module("Math", 1);
            var avgScore = module.ComputeAverage(new Exam[0]); // Pas d'examens
            Assert.Null(avgScore);
        }
    }
}
