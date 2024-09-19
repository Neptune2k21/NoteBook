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
    }
}
