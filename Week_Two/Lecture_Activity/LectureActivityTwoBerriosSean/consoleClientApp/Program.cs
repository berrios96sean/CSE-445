using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleClientApp
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                Console.WriteLine("Welcome to Web Service Demo!");

                if (Console.Read() == 3)
                {
                    Environment.Exit(0); 
                }
            }
        }
    }
}
