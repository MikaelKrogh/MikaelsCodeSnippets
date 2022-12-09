using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace OutlookSender {
    public class Product : INotifyPropertyChanged{
        public string Name { get; set; }
        private int amount;

        public int Amount
        {
            get { return amount; }
            set 
            {
                amount = value;
                if (value < 1)
                {
                Program.SendEmail(Program.smtpServer);

                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName) {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
