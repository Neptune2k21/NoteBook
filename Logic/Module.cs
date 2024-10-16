using System;

namespace Logic
{
    public class Module : EducationalElement
    {

        public Module(string name, float coefficient)
            : base(name, coefficient)
        {
        }

        public override string ToString()
        {
            return $"{Name} ({Coefficient})";
        }
        public AvgScore ComputeAverage(Exam[] exams)
        {
            var relevantExams = exams.Where(e => e.Module == this && !e.IsAbsent).ToArray();
            if (relevantExams.Length == 0)
            {
                return null;
            }

            float totalCoefficient = relevantExams.Sum(e => e.Coefficient);
            float weightedSum = relevantExams.Sum(e => e.Score * e.Coefficient);

            float average = weightedSum / totalCoefficient;

            return new AvgScore(this, average);
        }
    }
}
