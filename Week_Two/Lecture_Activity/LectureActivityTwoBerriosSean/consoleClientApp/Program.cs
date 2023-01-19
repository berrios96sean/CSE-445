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
            ServiceReference1.Service1Client mySvc = new ServiceReference1.Service1Client();
            Console.WriteLine("******************************");
            Console.WriteLine("Welcome to Web Service Demo!");

            while (true)
            {
                Console.WriteLine("******************************");
                Console.WriteLine("Select the method you need to invoke:");
                Console.WriteLine("1. Sum of Digits");
                Console.WriteLine("2. Vowel Count");
                Console.WriteLine("3. EXIT"); 
                string selection = Console.ReadLine(); 

                if (selection.Equals("1"))
                {
                    Console.WriteLine("******************************");
                    Console.WriteLine("Please enter an integer number: ");
                    string intNum = Console.ReadLine();
                    int x = Convert.ToInt32(intNum);
                    int res = mySvc.sumOfDigits(x);
                    Console.WriteLine("Result = {0}",res);
                    Console.WriteLine("******************************");
                }
                if (selection.Equals("2"))
                {
                    Console.WriteLine("2 pressed");
                }
                if (selection.Equals("3"))
                {
                    break; 
                }

            }

        }
    }
}
