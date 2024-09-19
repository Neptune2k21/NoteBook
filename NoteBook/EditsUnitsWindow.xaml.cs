using Logic;
using System.Windows;
using System.Windows.Controls; // Nécessaire pour SelectionChangedEventArgs

namespace NoteBook
{
    public partial class EditUnitsWindow : Window
    {
        private Notebook notebook;

        public EditUnitsWindow(Notebook notebook)
        {
            InitializeComponent();
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

        private void DrawModules()
        {
            if (unitsList.SelectedItem is Unit unit)
            {
                var list = unit.ListModules();  
                modulesList.Items.Clear(); 
                foreach (Module m in list)
                {
                    modulesList.Items.Add($"{m.Name} ({m.Coefficient})");
                }
            }
        }

        private void SelectUnit(object sender, SelectionChangedEventArgs e)
        {
            DrawModules();  
        }

        private void AddUnit(object sender, RoutedEventArgs e)
        {
            Unit newUnit = new Unit("Nouvelle Unité", 1.0f); 
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
