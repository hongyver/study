using System;
using System.Threading;

class Program
{
	static void threadfunc(object obj)
	{
		Console.WriteLine("new thread start!!! {0}", (int)obj);
		Thread.Sleep(1000 * 10); // 10 seconds
		Console.WriteLine("Terminate thread!!!");
	}

	static void Main(string [] args)
	{
		Console.WriteLine("2017-11.26");
		Console.WriteLine(DateTime.Now);

		while(true)
		{
			Console.WriteLine("time or x");
			string input = Console.ReadLine();

			if(input.Equals("x", StringComparison.OrdinalIgnoreCase) == true)
			{
				break;
			}

			Thread thread = Thread.CurrentThread;
			Console.WriteLine(thread.ThreadState);

			Thread t = new Thread(threadfunc);
			t.IsBackground = true;
			t.Start(Int32.Parse(input)

		}

		//t.Join();
		Console.WriteLine("all thread is terminated!!!");
	}
};