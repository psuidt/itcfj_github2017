package adv;

public class MyThread {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		
		for (int i = 0; i < 3; i++) {
			new Thread(
					new Runnable() {
						
						@Override
						public void run() {
							// TODO Auto-generated method stub
							
							System.err.println(Thread.currentThread().getName());
						}
					}
					).start();
		}
		

	}

}
