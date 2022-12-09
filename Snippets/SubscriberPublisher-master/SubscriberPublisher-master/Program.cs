using System;
using System.Collections.Generic;
using System.Threading;

namespace SubscriberPublisher
{
    class Program
    {
        static void Main(string[] args)
        {
            WeatherStation weatherStation = new WeatherStation();           //Publisher
            NewsAgency skynews = new NewsAgency("Sky News");                //Subscriber
            NewsAgency tv2News = new NewsAgency("Tv2 News");                //Subscriber
            NewsAgency rusProga = new NewsAgency("Russian Propaganda");     //Subscriber

            weatherStation.Attach(skynews);                                 //Objekter tilføjes til weatherstation listen
            weatherStation.Attach(tv2News);
            weatherStation.Attach(rusProga);

            weatherStation.Temp = 35.55;
            Thread.Sleep(200);        
            
            weatherStation.Temp = 28.56;
            Thread.Sleep(200);          
            
            weatherStation.Temp = 5.55;
            Thread.Sleep(200);   
            
            weatherStation.Temp = 5.55;
            Thread.Sleep(200);


        }
    }
}
