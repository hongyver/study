using System;

class Calc
{
	public static long Cumsum(int start, int end)
	{
		long sum = 0;
		for (int i = start ; i <= end ; i++ )
		{
			sum += i;
		}

		return sum;
	}
};

class Program
{
	public static long hsum(int start, int end)
	{
		long sum = 0;
		for (int i = start ; i <= end ; i++ )
		{
			sum += i;
		}

		return sum;
	}

	public delegate long CalcMethod(int start, int end);

	static void Main(string [] args)
	{
		CalcMethod calc = new CalcMethod(Calc.Cumsum);
		CalcMethod calc2 = new CalcMethod(hsum);

		long result = calc(1,100);
		Console.WriteLine(result);

		Console.WriteLine(hsum(1,10));

		IAsyncResult ar = calc.BeginInvoke(1, 100, null, null);
		ar.AsyncWaitHandle.WaitOne();
		Console.WriteLine(calc.EndInvoke(ar));
	}
};