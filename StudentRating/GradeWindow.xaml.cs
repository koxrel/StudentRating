using StudentRating.Classes.Domain;
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
using StudentRating.Classes.Interfaces;

namespace StudentRating
{
    /// <summary>
    /// Interaction logic for GradeWindow.xaml
    /// </summary>
    public partial class GradeWindow : Window
    {
        public GradeWindow()
        {
            InitializeComponent();
        }

        private void buttonOK_Click(object sender, RoutedEventArgs e)
        {   
            // Check the entered data before closing the window
            int n;
            if (!int.TryParse(textBoxMark.Text, out n))
                MessageBox.Show("Incorrect mark. Please try again.", "Value Error", MessageBoxButton.OK,
                    MessageBoxImage.Exclamation);
            else
                DialogResult = true;
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
