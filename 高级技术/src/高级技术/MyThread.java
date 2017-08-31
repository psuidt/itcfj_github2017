package 高级技术;

public class MyThread {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		
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
