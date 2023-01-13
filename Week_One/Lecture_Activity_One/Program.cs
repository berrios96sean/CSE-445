using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture_Activity_One
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceReference1.CountryInfoServiceSoapTypeClient mySvr = new ServiceReference1.CountryInfoServiceSoapTypeClient("CountryInfoServiceSoap");
            String countryName;
            Console.WriteLine("Please enter a Country Name: ");
            countryName = Console.ReadLine();
            String isoCode = mySvr.CountryISOCode(countryName);
        }
    }
}
