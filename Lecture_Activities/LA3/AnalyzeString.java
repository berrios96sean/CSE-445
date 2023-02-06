import java.util.Scanner;
public class AnalyzeString
{
    public static void main(String[] args)
    {
        Scanner scan = new Scanner(System.in);
        System.out.println("Please enter a string");
        String str=scan.nextLine();
        // Create an instance of DigitCountThread
        DigitCountThread dct = new DigitCountThread(str);
        // Create an instance of upperCountThread
        upperCountThread uct = new upperCountThread(str);
        isPalindromeThread ipt = new isPalindromeThread(str);
        // Start DigitCountThread instance created above
        dct.start(); 
        uct.start();
        // Start isPalindrome instance created above
        ipt.start();
        // wait for the three threads to complete
        try
        {
            dct.join();
            uct.join();
            ipt.join();
        }
        catch (InterruptedException e)
        {
            System.out.println("Process was interupted");
        }
        // display digit count, upper count and whether the string is a palindromeor not
        System.out.println("Digits in String = "+dct.getCount());
        System.out.println("Upper case Letters in String = "+uct.getCount());
        System.out.println("is palindrome = "+ipt.isPalindrome());
    }

    static class DigitCountThread extends Thread
    {
        int count = 0; 
        String str; 
    
        // Construcort that takes the string as a parameter 
        public DigitCountThread(String str)
        {
            this.str = str; 
        }
    
        public void run()
        {
            for (int i = 0; i < str.length(); i++)
            {
                if (Character.isDigit(str.charAt(i)))
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

    static class upperCountThread extends Thread
    {
        int count = 0; 
        String str; 

        public upperCountThread(String str)
        {
            this.str = str; 
        }

        public void run()
        {
            for (int i = 0; i < str.length(); i++ )
            {
                if (Character.isUpperCase(str.charAt(i)))
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

    static class isPalindromeThread extends Thread
    {
        boolean palindrome = false; 
        String str; 

        public isPalindromeThread(String str)
        {
            this.str = str; 
        }

        public void run()
        {
            for (int i = 0; i < (str.length())/2;i++)
            {
                if (str.charAt(i) == str.charAt(str.length()-i-1))
                {
                    palindrome = true; 
                    break; 
                }
            }
        }

        public boolean isPalindrome()
        {
            return this.palindrome; 
        }
    }

}