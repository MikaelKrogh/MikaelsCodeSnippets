using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace ItemSelected {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        ObservableCollection<Menneske> Mennesker { get; set; } = new ObservableCollection<Menneske>();
        public MainWindow() {
            InitializeComponent();
            ListViewet.ItemsSource = Mennesker;
        }

        private void TilfoejMennesker_Click(object sender, RoutedEventArgs e) {
            Mennesker.Add(new Menneske("Signe", 17));
            Mennesker.Add(new Menneske("Sarah", 21));
            Mennesker.Add(new Menneske("Vagner", 5));
            Mennesker.Add(new Menneske("Lars", 74));
        }

        private void RetAlderKnap_Click(object sender, RoutedEventArgs e) {
            foreach (Menneske item in Mennesker)
            {
                item.Alder += 2;
            }
        }

        private void ListViewet_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            
            Window1 popup = new Window1(Mennesker[ListViewet.SelectedIndex]);
            popup.ShowDialog();

        }
    }
}
