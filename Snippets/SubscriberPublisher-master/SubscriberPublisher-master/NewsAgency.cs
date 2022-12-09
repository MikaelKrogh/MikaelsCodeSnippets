using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriberPublisher
{
    class NewsAgency : ISubscriber
    {
        public string AgencyName { get; set; }
        public NewsAgency(string name)
        {
            this.AgencyName = name;
        }

        public void Update(IPublisher publisher)
        {
            if (publisher is WeatherStation weatherStation)
            {
            Console.WriteLine($"{AgencyName}: the current temperature reading is {weatherStation.Temp} heat units\n");
            }
        }
    }
}
