using System;
using System.Collections.Generic;

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
    }
}
