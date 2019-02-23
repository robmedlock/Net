using System;
using System.Collections.Generic;
using System.Text;

namespace Appliances.Entity
{
    public class Job
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public string Description { get; set; }
        public double PercentComplete { get; set; }
    }
}
