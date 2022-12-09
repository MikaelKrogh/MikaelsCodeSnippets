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

namespace NotifyPropertyChangedTest {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private ViewModel _vm = new ViewModel();
        public MainWindow() {
            InitializeComponent();            
            DataContext = _vm;
        }

        private void OpdateHummies_Click(object sender, RoutedEventArgs e) {
            _vm.UpdateHumans();            
        }

        private void GetHumans_Click(object sender, RoutedEventArgs e) {
            _vm.Humans.Add(new Human("Emma", 72));
            _vm.Humans.Add(new Human("Merry", 54));
            _vm.Humans.Add(new Human("Bob", 16));
            _vm.Humans.Add(new Human("John", 45));
            
        }      
    }
}
