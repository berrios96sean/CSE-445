 // Worker inner class to add up a section of the array. 
	 public class Worker extends Thread { 
	 int start; 
	 int end; 
	 double sum; 
	 double[] data;
	 
	 // Note the start and end indexes for this worker 
	 // in the array. Goes up to but not including end index. 
	 Worker(int start, int end, double[] d) { 
	 this.start = start; 
	 this.end = end; 
	 this.data=d;
	 sum = 0; 
	 } 


	// Computes the sum for our start..end section 
	 // in the array (client should call getSum() later). 
	 public void run() { 
	 for (int i=start; i<end; i++) { 
	 sum += data[i]; 
	 } 
	 //sync.release(); 
	 } 
	 
	 public double getSum() { 
	 return sum; 
	 } 
	 }