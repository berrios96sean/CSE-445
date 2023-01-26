using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace A1Berrios_Sean_Part2
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public int wordCount(string str)
        {
            return str.Replace(".", " ").Split(' ').Length;
        }

        public stringStatistics analyzeStr(string str)
        {
            int upper = 0;
            int lower = 0;
            int digits = 0;
            int vowels = 0;

            for (int i = 0; i < str.Length; i++)
            {

                if (char.IsUpper(str[i]))
                {
                    upper++;
                }
                if (char.IsLower(str[i]))
                {
                    lower++;
                }
                if (char.IsDigit(str[i]))
                {
                    digits++;
                }

                if (char.IsLetter(str[i]))
                {
                    char ch = char.ToLower(str[i]);
                    if (ch.Equals('a') || ch.Equals('e') || ch.Equals('i') || ch.Equals('o') || ch.Equals('u'))
                    {
                        vowels++;
                    }
                }

            }

            return new stringStatistics { upperCaseCount = upper, lowerCaseCount = lower, digitCount = digits, vowelCount = vowels };
        }
    }
}
