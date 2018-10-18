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

namespace KorchekTechnologiesCodingExercise.Views
{
    /// <summary>
    /// Interaction logic for AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        public AddWindow()
        {
            InitializeComponent();
            AddName.Text = "";
            AddDOB.Text = "";
            AddNumberOfWidgets.Text = "";
            AddErrorMessage.Visibility = Visibility.Hidden;
        }

        // to prevent strange behavior when closing window
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Visibility = Visibility.Hidden;
            AddName.Text = "";
            AddDOB.Text = "";
            AddNumberOfWidgets.Text = "";
        }

        private void ConfirmAddButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
