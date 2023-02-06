/* Reference 
 * http://web.stanford.edu/class/archive/cs/cs108/cs108.1092/
 * http://docs.oracle.com/javase/tutorial/essential/concurrency/
 */


public class runArraysum {
	public static void main(String[] args) { 
		 // command line argument: array_length 
		 int len = 10000000; 
		 double[] data = new double[len]; 
		 for (int i=0; i<len; i++) { 
		 data[i] = i*1.2;
		 }
		 
		 long startTime = System.currentTimeMillis();
		 long endTime=0;
		 addArrayThread at = new addArrayThread(data); 
		 at.runParallel(); 
		 endTime = System.currentTimeMillis();
		 
		 System.out.println("time elapsed with thread" +(endTime - startTime));
		 
		 //The following code does the same operation above without thread
		 startTime = System.currentTimeMillis();
		 
		 double[] array = new double[len]; 
		 for (int i=0; i<len; i++) { 
		 array[i] = i*1.2; 
		 } 
		 
		 double sum=0;
		 for ( int i=0; i<len; i++) { 
			 sum += array[i]; 
			 }
		  
		  endTime = System.currentTimeMillis();
		 
		  System.out.println("time elapsed without thread" +(endTime - startTime));
		 } 

		  
		} 

