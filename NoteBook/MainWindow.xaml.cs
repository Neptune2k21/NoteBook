using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Logic;

namespace NoteBook
{
    public partial class MainWindow : Window
    {
        private Notebook notebook;

        public MainWindow()
        {
            InitializeComponent();
            notebook = new Notebook();
        }

        private void GoEditUnits(object sender, RoutedEventArgs e)
        {
            EditUnitsWindow second = new EditUnitsWindow(notebook);
            second.Show();
        }

        private void GoCreateExam(object sender, RoutedEventArgs e)
        {
            EditExamWindow editExamWindow = new EditExamWindow(notebook);
            if (editExamWindow.ShowDialog() == true)
            {
               
            }
        }
        private void GoListExams(object sender, RoutedEventArgs e)
        {
            ListExamsWindow listExamsWindow = new ListExamsWindow(notebook);
            listExamsWindow.Show();
        }
        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
