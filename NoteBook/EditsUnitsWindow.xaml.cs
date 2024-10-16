using Logic;
using System.Windows;
using System.Windows.Controls;

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
                unitsList.Items.Add(unit); 
            }
        }

        private void DrawModules()
        {
            if (unitsList.SelectedItem is Unit unit)
            {
                var modules = unit.ListModules();
                modulesList.Items.Clear();
                foreach (var module in modules)
                {
                    modulesList.Items.Add(module);
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
            EditElementWindow editWindow = new EditElementWindow(newUnit);
            if (editWindow.ShowDialog() == true)
            {
                notebook.AddUnit(newUnit);
                DrawUnits();
            }
        }

        private void RemoveUnit(object sender, RoutedEventArgs e)
        {
            if (unitsList.SelectedIndex >= 0)
            {
                var unit = (Unit)unitsList.SelectedItem;
                notebook.RemoveUnit(unit);
                DrawUnits();
                modulesList.Items.Clear(); 
            }
        }

        private void EditModule(object sender, RoutedEventArgs e)
        {
            if (modulesList.SelectedIndex >= 0)
            {
                var selectedUnit = (Unit)unitsList.SelectedItem; 
                var selectedModule = selectedUnit.ListModules()[modulesList.SelectedIndex];

                EditElementWindow editWindow = new EditElementWindow(selectedModule);
                if (editWindow.ShowDialog() == true)
                {
                    DrawModules();
                }
            }
        }

        private void AddModule(object sender, RoutedEventArgs e)
        {
            if (unitsList.SelectedIndex >= 0)
            {
                var selectedUnit = (Unit)unitsList.SelectedItem;
                Module newModule = new Module("Nouveau Module", 1.0f);

                EditElementWindow editWindow = new EditElementWindow(newModule);
                if (editWindow.ShowDialog() == true)
                {
                    selectedUnit.AddModule(newModule);
                    DrawModules(); 
                }
            }
        }

        private void RemoveModule(object sender, RoutedEventArgs e)
        {
            if (modulesList.SelectedIndex >= 0)
            {
                var selectedUnit = (Unit)unitsList.SelectedItem; 
                var selectedModule = selectedUnit.ListModules()[modulesList.SelectedIndex];

                selectedUnit.RemoveModule(selectedModule);
                DrawModules(); 
            }
        }
        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
