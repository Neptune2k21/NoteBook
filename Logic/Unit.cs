using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic
{
    public class Unit : EducationalElement
    {

        public List<Module> Modules { get; private set; }

        public Unit(string name, float coefficient)
            : base(name, coefficient)
        {
            Modules = new List<Module>();
        }


        public void AddModule(Module module)
        {
            if (module == null)
            {
                throw new ArgumentException("Le module ne peut pas être null.");
            }
            Modules.Add(module);
        }

        public void RemoveModule(Module module)
        {
            if (!Modules.Contains(module))
            {
                throw new ArgumentException("Le module n'existe pas dans cette unité.");
            }
            Modules.Remove(module);
        }

        public Module[] ListModules()
        {
            return Modules.ToArray();
        }

        
        public override string ToString()
        {
            return $"{Name} ({Coefficient})";
        }

        public AvgScore[] ComputeAverages(Exam[] exams)
        {
            var moduleAverages = Modules.Select(m => m.ComputeAverage(exams)).Where(avg => avg != null).ToArray();
            return moduleAverages.Length == 0 ? Array.Empty<AvgScore>() : moduleAverages;
        }
    }
}
