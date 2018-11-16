using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Template_Method
{
    public class WarmClimate : AbstractClass
    {
        public override void ClimateControl()
        {
            Console.WriteLine("Air conditioning");
        }
    }
}
