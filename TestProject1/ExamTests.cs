using Logic;
using System;
using Xunit;

namespace TestLogic
{
    public class ExamTests
    {
        [Fact]
        public void TestExamInitialization()
        {
           Logic.Module module = new Module("Math", 1);
            Exam exam = new Exam(module, 2, 15.5f);

            Assert.Equal(module, exam.Module);
            Assert.Equal(2, exam.Coefficient);
            Assert.Equal(15.5f, exam.Score);
        }

        [Fact]
        public void TestInvalidScore()
        {
            Logic.Module module = new Module("Math", 1);
            var exception = Assert.Throws<ArgumentException>(() => new Exam(module, 1, 25));
            Assert.Equal("Le score doit être entre 0 et 20.", exception.Message);
        }

        [Fact]
        public void TestInvalidCoefficient()
        {
            Logic.Module module = new Module("Math", 1);
            var exception = Assert.Throws<ArgumentException>(() => new Exam(module, 0, 10));
            Assert.Equal("Le coefficient doit être > 0.", exception.Message);
        }
    }
}
