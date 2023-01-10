using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mathClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ServiceReference1.CalculatorSoapClient myClient = new ServiceReference1.CalculatorSoapClient("CalculatorSoap");
            int result = myClient.Multiply(10,10);
            Console.WriteLine(result);
        }
    }
}
