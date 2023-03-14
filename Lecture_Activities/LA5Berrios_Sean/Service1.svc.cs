﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace LA5Berrios_Sean
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string reverseString(String str)
        {
            String output = "";
            char[] charArr = str.ToCharArray();
            Array.Reverse(charArr);

            for (int i = 0; i < str.Length; i++)
            {
                output += charArr[i];
            }
            

            return output; 
        }

        public int sumOfDigits(String num)
        {
            int sum = 0;
            int[] intArr = new int[15];
            char[] charArr = num.ToCharArray(); 

            // get int arr 
            for (int i = 0; i < num.Length; i++)
            {
                intArr[i] = int.Parse(charArr[i].ToString());
            }

            // get sum 
            for (int i = 0; i < intArr.Length; i++)
            {
                sum += intArr[i];
            }

            return sum; 
        }

    }
}
