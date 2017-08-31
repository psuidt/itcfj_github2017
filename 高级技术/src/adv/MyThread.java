package adv;

import java.util.HashMap;
import java.util.Map;

public class MyThread {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		
		Map<Thread, String> Store=new HashMap<Thread, String>();
		
		for (int i = 0; i < 3; i++) {
			new Thread(
					new Runnable() {
						
						@Override
						public void run() {
							// TODO Auto-generated method stub
							String tmp=String.valueOf(Math.random());
							Store.put(Thread.currentThread(), tmp);
							System.err.println(Thread.currentThread().getName());
						}
					}
					).start();
		}
		
		
		

	}

}
