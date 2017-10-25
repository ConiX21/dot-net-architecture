using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncLibrary
{
    class Program
    {
        static void Main()
        {
            var demo = new AsyncAwaitDemo();
            demo.DoStuff();

            while (true)
            {
                Console.WriteLine("Doing Stuff on the Main Thread...................");
            }
        }
    }
}
