using Logic;
using System;
using System.Windows;
using System.Windows.Controls;

namespace NoteBook
{
    public partial class EditExamWindow : Window
    {
        private Notebook notebook;
        private Exam exam;

        public EditExamWindow(Notebook notebook)
        {
            InitializeComponent();
            this.notebook = notebook;
            this.exam = new Exam(null);  // Création d'un objet Exam temporaire

            DrawUnits();  // Remplir la ComboBox des unités
        }

        private void DrawUnits()
        {
            var units = notebook.ListUnits();
            unitsComboBox.Items.Clear();
            foreach (var unit in units)
            {
                unitsComboBox.Items.Add(unit);
            }
        }

        private void DrawModules()
        {
            var selectedUnit = unitsComboBox.SelectedItem as Unit;
            if (selectedUnit != null)
            {
                var modules = selectedUnit.ListModules();
                modulesComboBox.Items.Clear();
                foreach (var module in modules)
                {
                    modulesComboBox.Items.Add(module);
                }
            }
        }

        private void UnitsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DrawModules();  
        }

        private void Validate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedModule = modulesComboBox.SelectedItem as Module;
                if (selectedModule == null)
                {
                    MessageBox.Show("Veuillez sélectionner un module.");
                    return;
                }

                var selectedUnit = unitsComboBox.SelectedItem as Unit;
                if (selectedUnit == null)
                {
                    MessageBox.Show("Veuillez sélectionner une unité.");
                    return;
                }

                if (!float.TryParse(coefTextBox.Text, out float coef) || coef <= 0)
                {
                    MessageBox.Show("Veuillez entrer un coefficient valide supérieur à 0.");
                    return;
                }

                if (!float.TryParse(scoreTextBox.Text, out float score) || score < 0 || score > 20)
                {
                    MessageBox.Show("Veuillez entrer un score valide entre 0 et 20.");
                    return;
                }

                exam.Module = selectedModule;
                exam.Coefficient = coef;
                exam.Score = score;
                exam.IsAbsent = absentCheckBox.IsChecked == true;

                notebook.AddExam(exam);

                DialogResult = true;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur: {ex.Message}");
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
