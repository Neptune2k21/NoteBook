using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Notebook
    {
        private List<Unit> units;

        public Notebook()
        {
            units = new List<Unit>();
        }

        // Ajoute une unité d'enseignement
        public void AddUnit(Unit unit)
        {
            if (units.Exists(u => u.Name == unit.Name))
            {
                throw new ArgumentException("Une unité avec le même nom existe déjà.");
            }
            units.Add(unit);
        }

        // Renvoie les unités sous forme de tableau
        public Unit[] ListUnits()
        {
            return units.ToArray();
        }

        // Supprime une unité d'enseignement
        public void RemoveUnit(Unit unit)
        {
            if (!units.Contains(unit))
            {
                throw new ArgumentException("L'unité n'existe pas.");
            }
            units.Remove(unit);
        }
    }
}
