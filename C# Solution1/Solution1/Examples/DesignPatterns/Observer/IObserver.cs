﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples.DesignPatterns.Observer
{
    public interface IObserver
    {       
        void Notify(object sender, EventArgs e);
    }
}
