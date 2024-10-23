using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;


namespace Storage
{
    public class JsonStorage : IStorage
    {
        private const string filePath = "notebook.json";

        public Notebook Load()
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("Notebook file not found.");

            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<Notebook>(json);
        }

        public void Save(Notebook nb)
        {
            string json = JsonSerializer.Serialize(nb, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }
    }
}
