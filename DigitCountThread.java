package Lecture_Activities.LA3;

public class DigitCountThread extends Thread{
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
