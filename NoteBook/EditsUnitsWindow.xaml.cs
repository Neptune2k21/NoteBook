using Logic;
using System.Windows;

namespace NoteBook
{
    /// <summary>
    /// Logique d'interaction pour EditsUnitsWindow.xaml
    /// </summary>
    public partial class EditUnitsWindow : Window
    {
        private Notebook notebook;
        public EditUnitsWindow(Notebook notebook)
        {
            InitializeComponent(); // Ensure this method is defined in the corresponding XAML file
            this.notebook = notebook;
            DrawUnits();
        }

        private void DrawUnits()
        {
            var list = notebook.ListUnits();
            unitsList.Items.Clear();
            foreach (var unit in list)
            {
                unitsList.Items.Add($"{unit.Name} ({unit.Coefficient})");
            }
        }

        private void AddUnit(object sender, RoutedEventArgs e)
        {
            Unit newUnit = new Unit("Nouvelle Unité", 1.0f);  // Crée un nouvel objet Unit temporaire
            EditElementWindow third = new EditElementWindow(newUnit);
            if (third.ShowDialog() == true)
            {
                notebook.AddUnit(newUnit);
                DrawUnits();
            }
        }

        private void RemoveUnit(object sender, RoutedEventArgs e)
        {
            if (unitsList.SelectedIndex >= 0)
            {
                var unit = notebook.ListUnits()[unitsList.SelectedIndex];
                notebook.RemoveUnit(unit);
                DrawUnits();
            }
        }
    }
}
