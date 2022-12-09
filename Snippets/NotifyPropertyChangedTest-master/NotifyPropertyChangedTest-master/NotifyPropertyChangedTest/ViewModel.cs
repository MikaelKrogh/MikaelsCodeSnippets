using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace NotifyPropertyChangedTest {

    public class ViewModel {       

        public ObservableCollection<Human> Humans { get; set; } = new ObservableCollection<Human>();
       
        public void UpdateHumans() {
            for (int i = 0; i < Humans.Count; i++)
            {
                Humans[i].Age += 2;
            }
        }
       
    }
}
