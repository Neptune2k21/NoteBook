using System.IO;
using System.Windows;
using Logic;
using Storage;

namespace NoteBook
{
    public partial class MainWindow : Window
    {
        private Notebook notebook;
        private IStorage storage; 

        public MainWindow()
        {
            InitializeComponent();
            notebook = new Notebook();
            storage = new JsonStorage(); 
            LoadNotebook(); 
        }

        private void LoadNotebook()
        {
            try
            {
                notebook = storage.Load(); 
            }
            catch (FileNotFoundException)
            {
               
                notebook = new Notebook();
            }
        }

        private void GoEditUnits(object sender, RoutedEventArgs e)
        {
            EditUnitsWindow second = new EditUnitsWindow(notebook);
            second.Closed += (s, args) => SaveNotebook(); 
            second.Show();
        }

        private void GoCreateExam(object sender, RoutedEventArgs e)
        {
            EditExamWindow editExamWindow = new EditExamWindow(notebook);
            if (editExamWindow.ShowDialog() == true)
            {
                SaveNotebook(); 
            }
        }

        private void GoListExams(object sender, RoutedEventArgs e)
        {
            ListExamsWindow listExamsWindow = new ListExamsWindow(notebook);
            listExamsWindow.Show();
        }

        private void SaveNotebook()
        {
            try
            {
                storage.Save(notebook);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la sauvegarde : {ex.Message}"); 
            }
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            SaveNotebook(); 
            this.Close();
        }
    }
}
