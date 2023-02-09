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
            StringAnalyzer stA = new StringAnalyzer();
            // call the read string method of the string analyzer class 
            stA.anaylzeString();
            //Console.WriteLine("String is: "+stA.getInput());
            // create three threads to count digits, count uppercase and determine 
            DigitCount dct = new DigitCount(stA.getInput());
            Thread dctThread = new Thread(new ThreadStart(dct.Run));
            dctThread.Start();
            dctThread.Join();

            int count = dct.getCount();
            Console.WriteLine("Digit Count = "+count);
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

        public void anaylzeString()
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

    #region Upper Case Class
    class UpperCase
    {
        int count = 0;
        string str;

        public UpperCase(String str)
        {
            this.str = str;
        }

        public void Run()
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsUpper(str[i]))
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

    #region IsPalindrome Class 
    class isPalindrome
    {
        bool palindrome = false; 
        string str;

        public isPalindrome(String str)
        {
            this.str = str;
        }

        public void Run()
        {
            for (int i = 0; i < (str.Length)/2; i++)
            {
                if (str[i] == str[str.Length - i - 1])
                {
                    palindrome = true;
                    break; 
                }
            }
        }

        public bool result()
        {
            return this.palindrome;
        }
    }
    #endregion
}
