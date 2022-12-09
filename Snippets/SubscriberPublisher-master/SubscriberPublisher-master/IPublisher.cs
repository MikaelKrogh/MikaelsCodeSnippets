using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriberPublisher
{
    interface IPublisher
    {
        void Attach(ISubscriber subscriber);
        void Notify();

    }
}
