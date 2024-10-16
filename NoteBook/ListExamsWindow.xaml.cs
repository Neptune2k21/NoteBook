using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NoteBook
{
    /// <summary>
    /// Logique d'interaction pour ListExamsWindow.xaml
    /// </summary>
    public partial class ListExamsWindow : Window
    {
        private Notebook notebook;
        public ListExamsWindow(Notebook notebook)
        {
            InitializeComponent();
            this.notebook = notebook;
            DrawExams();
        }

        private void DrawExams()
        {
            var exams = notebook.ListExams();
            ExamDataGrid.ItemsSource = exams;
        }
    }
}
