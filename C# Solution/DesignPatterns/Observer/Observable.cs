using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Observer
{
    public class Observable
    {
        private event EventHandler Event1;

        public void RegisterObserver(EventHandler handler)
        {
            Event1 += handler;
        }

        public void NotifyObservers()
        {
            Event1(this, new EventArgs());
        }
    }
}
