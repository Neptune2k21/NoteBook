using System;
using System.IO;
using Logic;  
using Xunit;
using Storage;
namespace TestLogic
{
    public class JsonStorageTests
    {
        private const string TestFilePath = "test_notebook.json"; 

        [Fact]
        public void TestSaveAndLoad()
        {

            IStorage storage = new JsonStorage();
            Notebook originalNotebook = CreateSampleNotebook();

            storage.Save(originalNotebook);
            Notebook loadedNotebook = storage.Load(); 
            
            Assert.Equal(originalNotebook.ListUnits().Length, loadedNotebook.ListUnits().Length);
            Assert.Equal(originalNotebook.ListExams().Length, loadedNotebook.ListExams().Length);

            for (int i = 0; i < originalNotebook.ListUnits().Length; i++)
            {
                Assert.Equal(originalNotebook.ListUnits()[i].Name, loadedNotebook.ListUnits()[i].Name);
                
            }

            for (int i = 0; i < originalNotebook.ListExams().Length; i++)
            {
                Assert.Equal(originalNotebook.ListExams()[i].Module.Name, loadedNotebook.ListExams()[i].Module.Name);
                Assert.Equal(originalNotebook.ListExams()[i].Date.ToString("yyyy-MM-dd HH:mm:ss"), loadedNotebook.ListExams()[i].Date.ToString("yyyy-MM-dd HH:mm:ss"));
                Assert.Equal(originalNotebook.ListExams()[i].Score, loadedNotebook.ListExams()[i].Score);
            }
        }

        private Notebook CreateSampleNotebook()
        {
            var notebook = new Notebook();
            var unit = new Unit("Math", 1);
            unit.AddModule(new Module("Algebra", 1));
            notebook.AddUnit(unit);
            notebook.AddExam(new Exam { Module = unit.ListModules()[0], Date = DateTime.Now, Score = 90 });
            return notebook;
        }
    }
}
