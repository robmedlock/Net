using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Examples
{
    public class ExceptionHandling
    {
        static void Main(string[] args)
        {
            //Snippet > surround with > try
            string path = @"c:\filename.txt";
            File.WriteAllText(path, "some text");
        }
    }
}
