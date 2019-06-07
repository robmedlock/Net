using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Observer
{
    public class Observer1 : IObserver
    {
        public void Notify(object sender, EventArgs e)
        {
            Console.WriteLine("Observer Notify called");
        }
    }

}
