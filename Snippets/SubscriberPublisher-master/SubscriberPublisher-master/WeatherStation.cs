using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriberPublisher
{
    class WeatherStation : IPublisher
    {
        private List<ISubscriber> subscriberList;
        public double Temp
        {
            get { return _temp; }
            set
            {
                if (_temp != value)
                {
                    _temp = value;         // er den nye value ens med dens eksisterende temperatur vil vi ikke opdatere
                    Notify();
                }
            }                               //ved setting af valuen så udføres notify metoden og notify iterere igennem subscriber listen
        }

        private double _temp;

        public WeatherStation()
        {
            subscriberList = new List<ISubscriber>();
        }

        public void Attach(ISubscriber subscriber)
        {
            subscriberList.Add(subscriber);
        }

        public void Notify()
        {
            foreach (ISubscriber subscriber in subscriberList)
            {
                subscriber.Update(this);
            }
        }
    }
}
