﻿using Logic;
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
        private Logic.Notebook notebook;        
        public ListExamsWindow(Logic.Notebook nb)
        {
            InitializeComponent();
            notebook = nb;            
            DrawExams();
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void DrawExams()
        {
            exams.Items.Clear();
            foreach(Exam e in notebook.ListExams())
            {
                exams.Items.Add(e);
            }
            scores.Items.Clear();
            foreach(AvgScore avg in notebook.ComputeScores())
            {
                scores.Items.Add(avg);
            }
        }
    }
}
