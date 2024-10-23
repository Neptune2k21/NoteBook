using System;

namespace Logic
{
    public class Exam
    {
        public Module Module { get; set; }
        public float Coefficient { get; set; }
        public float Score { get; set; }
        public DateTime Date { get; set; }
        public bool IsAbsent { get; set; }

        public Exam(Module module, float coefficient = 1.0f, float score = 0, DateTime? date = null, bool isAbsent = false)
        {
            if (coefficient <= 0)
                throw new ArgumentException("Le coefficient doit être > 0.");
            if (score < 0 || score > 20)
                throw new ArgumentException("Le score doit être entre 0 et 20.");

            Module = module;
            Coefficient = coefficient;
            Score = score;
            Date = date ?? DateTime.Now;
            IsAbsent = isAbsent;
        }

        public override bool Equals(object obj)
        {
            return obj is Exam exam &&
                   Module.Equals(exam.Module) &&
                   Date.ToString("yyyy-MM-dd HH:mm:ss") == exam.Date.ToString("yyyy-MM-dd HH:mm:ss") &&
                   Score == exam.Score;
        }
    }
}
