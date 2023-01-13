﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

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
            countryName = FormatString(countryName);
            String isoCode = mySvr.CountryISOCode(countryName);
            String capitolCity = mySvr.CapitalCity(isoCode);
            ServiceReference1.tCurrency curr = mySvr.CountryCurrency(isoCode);
            Console.WriteLine("ISO Code = {0}",isoCode);
            Console.WriteLine("Country Capitol = {0}", capitolCity);
            Console.WriteLine("Currency ISO Code = {0}", curr.sISOCode);
            Console.WriteLine("Currency Name = {0}",curr.sName);
        }

        // This function will format the string to capitolize the leading characted and remove any trailing whitespace 
        // so that unecessary user errors do not occur. 
        public static string FormatString(string input)
        {
            input = input.TrimEnd(); // remove trailing whitespace
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input);
        }

    }
}
