using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples
{
    class Streams
    {
        public static void WriteToFile(string text)
        {
            //UnauthorizedAccessException
            File.WriteAllText(@"C:\file.txt", text);
            //DirectoryNotFoundException
            File.WriteAllText(@"Z:\file.txt", text);
        }
    }
}
