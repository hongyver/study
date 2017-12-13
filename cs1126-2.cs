using System;
using System.Threading;

class Program
{
	int num = 0;

	static void threadfunc(object obj)
	{
		Program pg = obj as Program;

		for(int i=0; i < 10000 ; i++ )
		{
//			Monitor.Enter(pg);
//			try
//			{
//				pg.num = pg.num + 1;
//			}
//			finally
//			{
//				Monitor.Exit(pg);
//			}
			lock(pg)
			{
				pg.num++;
			}
		}
	}

	static void Main(string [] args)
	{
		Program pg = new Program();

		Thread t1 = new Thread(threadfunc);
		Thread t2 = new Thread(threadfunc);

		t1.Start(pg);
		t2.Start(pg);

		t1.Join();
		t2.Join();

		Console.WriteLine("{0}", pg.num);

	}
};