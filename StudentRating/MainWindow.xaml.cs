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
using System.Windows.Navigation;
using System.Windows.Shapes;
using StudentRating.Classes;
using StudentRating.Classes.Domain;
using StudentRating.Classes.Interfaces;
using StudentRating.Classes.RatingCalculators;
using StudentRating.Classes.Repositories;

namespace StudentRating
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private IRepository _repo;
        //private IRatingCalculator _calculator;

        private Factory _factory;

        public MainWindow()
        {
            InitializeComponent();
            _factory = Factory.GetFactory;

            dataGridGrades.ItemsSource = _factory.GetRepository().Grades;
            _factory.GetRepository().GradesChanged += dataGridGrades.Items.Refresh;
        }

        private void buttonRating_Click(object sender, RoutedEventArgs e)
        {
            textBlockRating.Text = String.Format("Your rating is = {0}", _factory.GetCalculator().CalculateRating(_factory.GetRepository().Grades));
        }

        private void GradeModification(object sender, RoutedEventArgs e)
        {
            GradeWindow gw = new GradeWindow
            {
                comboBoxCourses =
                {
                    ItemsSource = _factory.GetRepository().Courses,
                    SelectedIndex = 0
                }
            };

            if (gw.ShowDialog() != true)
                return;

            //Since the starting index is predetermined, the Course value cannot be null
            var newGrade = new Grade(gw.comboBoxCourses.SelectionBoxItem as Course, int.Parse(gw.textBoxMark.Text));

            try
            {
                _factory.GetRepository().AddGrade(newGrade);
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Could not add/edit the grade. Please try again.", "Null error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
            catch (ArgumentException)
            {
                _factory.GetRepository().EditGrade(newGrade);
            }
        }

        private void GradeRemoval(object sender, RoutedEventArgs e)
        {
            var removeGrade = dataGridGrades.SelectedItem as Grade;
            if (removeGrade == null)
                return;
            
            _factory.GetRepository().RemoveGrade(gr => gr.Id == removeGrade.Id);
        }
    }
}
