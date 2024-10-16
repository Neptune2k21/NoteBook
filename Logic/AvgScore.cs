using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class AvgScore
    {
        public EducationalElement Element { get; private set; }
        public float Average { get; private set; }

        public AvgScore(EducationalElement element, float average)
        {
            if (element == null)
                throw new ArgumentException("L'élément pédagogique ne peut pas être null.");

            if (average < 0)
                throw new ArgumentException("La moyenne ne peut pas être inférieure à 0.");

            Element = element;
            Average = average;
        }

        public override string ToString()
        {
            return $"{Element.Name} : {Average}";
        }
    }
}
