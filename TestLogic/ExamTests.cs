using Logic;
using System;
using Xunit;

namespace TestLogic
{
    public class ExamTests
    {
        [Fact]
        public void Constructor_ValidParameters_ShouldCreateExam()
        {
            // Arrange & Act
            var exam = new Exam("Professeur Dupont", DateTime.Now, 1.5f);

            // Assert
            Assert.Equal("Professeur Dupont", exam.Teacher);
            Assert.Equal(1.5f, exam.Coefficient);
        }

        [Fact]
        public void Constructor_InvalidTeacher_ShouldThrowArgumentException()
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentException>(() => new Exam("", DateTime.Now, 1.5f));
        }

        [Fact]
        public void Constructor_InvalidCoefficient_ShouldThrowArgumentException()
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentException>(() => new Exam("Professeur Dupont", DateTime.Now, 0));
        }

        [Fact]
        public void SetScore_ValidScore_ShouldSetScore()
        {
            // Arrange
            var exam = new Exam("Professeur Dupont", DateTime.Now, 1.5f);

            // Act
            exam.SetScore(15);

            // Assert
            Assert.Equal(15, exam.Score);
        }

        [Fact]
        public void SetScore_InvalidScore_ShouldThrowArgumentException()
        {
            // Arrange
            var exam = new Exam("Professeur Dupont", DateTime.Now, 1.5f);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => exam.SetScore(-1));
            Assert.Throws<ArgumentException>(() => exam.SetScore(21));
        }

        [Fact]
        public void MarkAsAbsent_ShouldSetScoreToZero()
        {
            // Arrange
            var exam = new Exam("Professeur Dupont", DateTime.Now, 1.5f);

            // Act
            exam.MarkAsAbsent();

            // Assert
            Assert.True(exam.IsAbsent);
            Assert.Equal(0, exam.Score);
        }
    }
}
