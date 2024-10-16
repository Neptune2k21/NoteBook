using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic
{
    public class Notebook
    {
        private List<Unit> units;
        private List<Exam> exams; 

        public Notebook()
        {
            units = new List<Unit>();
            exams = new List<Exam>(); 
        }


        public void AddUnit(Unit unit)
        {
            if (units.Exists(u => u.Name == unit.Name))
            {
                throw new ArgumentException("Une unité avec le même nom existe déjà.");
            }
            units.Add(unit);
        }

        public Unit[] ListUnits()
        {
            return units.ToArray();
        }

        public void RemoveUnit(Unit unit)
        {
            if (!units.Contains(unit))
            {
                throw new ArgumentException("L'unité n'existe pas.");
            }
            units.Remove(unit);
        }


        public Module[] ListModules()
        {
            return units.SelectMany(unit => unit.ListModules()).ToArray();
        }


        public void AddExam(Exam exam)
        {
            exams.Add(exam);
        }

        public Exam[] ListExams()
        {
            return exams.ToArray();
        }
        public AvgScore[] ComputeUnitAverages()
        {
            return units.Select(u => u.ComputeAverages(exams.ToArray())).SelectMany(avgScores => avgScores).ToArray();
        }

        public AvgScore ComputeOverallAverage()
        {
            var unitAverages = ComputeUnitAverages();
            if (unitAverages.Length == 0) return null;

            float totalCoefficient = unitAverages.Sum(avg => avg.Element.Coefficient);
            float weightedSum = unitAverages.Sum(avg => avg.Average * avg.Element.Coefficient);
            float overallAverage = weightedSum / totalCoefficient;

            var generalAverageElement = new Module("Moyenne Générale", 1);
            return new AvgScore(generalAverageElement, overallAverage);
        }
    }
}
