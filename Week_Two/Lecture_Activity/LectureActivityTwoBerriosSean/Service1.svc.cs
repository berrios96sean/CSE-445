﻿using System;
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

            return intArr[1];
        }

        public int vowelsInString(string str)
        {
            return 5; 
        }

        public int[] intArray(char[] cArr)
        {
            int[] temp = new int[cArr.Length];
            for (int i = 0; i < cArr.Length; i++)
            {
                temp[i] = cArr[i]; 
            }

            return temp; 
        }
    }
}