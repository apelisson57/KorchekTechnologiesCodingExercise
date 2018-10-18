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
using KorchekTechnologiesCodingExercise;
using KorchekTechnologiesCodingExercise.Model;
using KorchekTechnologiesCodingExercise.ViewModel;
using KorchekTechnologiesCodingExercise.Views;

namespace KorchekTechnologiesCodingExercise 
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        // helper windows
        public AddWindow addWindow;
       

        public MainWindow()
        {
            InitializeComponent();
            XMLObjectViewModel viewModel = new XMLObjectViewModel();
            this.DataContext = viewModel;

            // define helper windows
            addWindow = new AddWindow();
            addWindow.DataContext = viewModel;
            
        }

        // open new window for add
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            addWindow.Show();
            
        }
        
       
    }
}
