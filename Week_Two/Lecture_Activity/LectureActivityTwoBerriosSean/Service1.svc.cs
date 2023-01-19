using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace LectureActivityTwoBerriosSean
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public int sumOfDigits(int x)
        {
            string temp = x.ToString();
            char[] arr = temp.ToCharArray();
            int[] intArr = intArray(arr);
            int sum = sumOfArray(intArr);
            return sum;
        }

        public int vowelsInString(string str)
        {
            char[] cArr = str.ToCharArray();
            int numOfVowels = findVowels(cArr);
            return numOfVowels; 
        }

        #region sumOfDigits helper methods 
        public int[] intArray(char[] cArr)
        {
            int[] temp = new int[cArr.Length];
            for (int i = 0; i < cArr.Length; i++)
            {
                string s = cArr[i].ToString();
                Int32 x = Int32.Parse(s);
                temp[i] = x; 
            }

            return temp; 
        }

        public int sumOfArray(int[] arr)
        {
            int sum = 0; 
            for (int i = 0; i < arr.Length; i++)
            {
                sum = sum + arr[i]; 
            }
            return sum; 
        }
        #endregion

        #region vowelsInString helper methods 

        public int findVowels(char[] cArr)
        {
            int vowels = 0; 
            for (int i = 0; i < cArr.Length; i++)
            {
                string s = cArr[i].ToString();
                string lower = s.ToLower(); 
                if (lower.Equals('a') || lower.Equals('e') || lower.Equals('i') || lower.Equals('o') || lower.Equals('u'))
                {
                    vowels++; 
                }
            }

            return vowels; 
        }
        #endregion
    }
}
