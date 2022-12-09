using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemSelected {
    public class Menneske : INotifyPropertyChanged {
        private string navn;

        public string Navn
        {
            get { return navn; }
            set { navn = value;
                NotifyPropertyChanged(nameof(Navn));
            }
        }
        private int alder;

        public int Alder
        {
            get { return alder; }
            set { alder = value;
                NotifyPropertyChanged(nameof(Alder));
            }
        }



        public Menneske(string navn, int alder) {
            Navn = navn;
            Alder = alder;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
