import java.util.*;
import java.util.concurrent.*;



public class addArrayThread {
	private double[] data;
	public addArrayThread(double[] data) {
	this.data=data;

	 }



	 public void runParallel() {
		 int numWorkers = 10;
		 // Make and start all the workers, keeping them in a list.
		 List<Worker> workers = new ArrayList<Worker>();
		 System.out.println(data.length);
		 int lenOneWorker = data.length / numWorkers;
		 for (int i=0; i<numWorkers; i++) {
		 int start = i * lenOneWorker;
		 int end = (i+1) * lenOneWorker;
		 // Special case: make the last worker take up all the excess.
		 if (i==numWorkers-1) end = data.length;
		 Worker worker = new Worker(start, end, data);
		 workers.add(worker);
		 worker.start();
		 }



		 try{
		 for(int i=0; i<workers.size(); i++)
		 workers.get(i).join();
		 }catch(InterruptedException ignored)
		 {}


		 // Gather sums from workers ()
		 int sum = 0;
		 for (Worker w: workers)
			 {
			 System.out.println(w.getName());
			 System.out.println(w.getSum());
			 sum += w.getSum();
			 }

		 System.out.println("len:" + data.length + " sum:" + sum + " workers:" + numWorkers);
		 }

}
