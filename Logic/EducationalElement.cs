using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public abstract class EducationalElement
    {
        private string _name;
        private float _coefficient;

        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Le nom ne peut pas être vide.");
                }
                _name = value;
            }
        }

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

        public EducationalElement(string name, float coefficient)
        {
            Name = name;
            Coefficient = coefficient;
        }
    }
}
