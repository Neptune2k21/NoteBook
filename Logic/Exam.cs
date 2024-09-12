using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Logic
    {
        public class Exam
        {
            private string _teacher;
            private float _coefficient;
            private float? _score;

            public string Teacher
            {
                get => _teacher;
                set
                {
                    if (string.IsNullOrWhiteSpace(value))
                    {
                        throw new ArgumentException("Le nom de l'enseignant ne peut pas être vide.");
                    }
                    _teacher = value;
                }
            }

            public DateTime Date { get; set; }

            public float Coefficient
            {
                get => _coefficient;
                set
                {
                    if (value <= 0)
                    {
                        throw new ArgumentException("Le coefficient doit être supérieur à 0.");
                    }
                    _coefficient = value;
                }
            }

            public float? Score
            {
                get => _score;
                set
                {
                    if (value.HasValue && (value < 0 || value > 20))
                    {
                        throw new ArgumentException("La note doit être comprise entre 0 et 20.");
                    }
                    _score = value;
                }
            }

            public bool IsAbsent { get; set; }

            public Exam(string teacher, DateTime date, float coefficient)
            {
                Teacher = teacher;
                Date = date;
                Coefficient = coefficient;
                IsAbsent = false;
            }

            public void SetScore(float score)
            {
                if (score < 0 || score > 20)
                {
                    throw new ArgumentException("La note doit être comprise entre 0 et 20.");
                }
                Score = score;
            }

            public void MarkAsAbsent()
            {
                IsAbsent = true;
                Score = 0; // La note d'absence est 0
            }
        }
    }

