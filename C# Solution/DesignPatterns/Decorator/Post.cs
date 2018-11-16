using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Decorator
{
    public class Post : Package
    {
        public Post(IPackage package):base(package)
        {
        }
        public override double RetailPrice
        {
            get
            {
                return package.RetailPrice + 5;
            }
        }
    }
}
