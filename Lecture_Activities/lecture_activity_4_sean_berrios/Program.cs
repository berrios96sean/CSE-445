using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace lecture_activity_4_sean_berrios
{
    class Program
    {
        static void Main(string[] args)
        {
            // create an object instance of the string analyzer class 
            // call the read string method of the string analyzer class 
            // create three threads to count digits, count uppercase and determine 
            // if the string is a palindrome 
            // start threads 
            // wait for all the threads to complete 
            // display string analysis results 
        }
    }

    #region String analyzer class 
    class StringAnalyzer
    {
        String inputStr; 

        public void anaylzeString(String str)
        {
            Console.WriteLine("Please Enter a String");
            String input = Console.ReadLine();
            this.inputStr = input; 
        }

        public string getInput()
        {
            return this.inputStr; 
        }
        
       
    }
    #endregion

    #region Digit Count Class 
    class DigitCount  
    {
        int count = 0;
        string str; 

        public DigitCount(String str)
        {
            this.str = str; 
        }

        public void Run()
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsDigit(str[i]))
                {
                    this.count++;
                }
            }
        }

        public int getCount()
        {
            return this.count;
        }
    }
    #endregion

}
