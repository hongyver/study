using System;

class Program
{
	static void AccessArray(int[] array)
	{
		array[5] = 0;
	}

	static void Main(string[] args)
	{
		int [] array = new int [] {1,2,3,4,5};
		//AccessArray(array);


		try
		{
			int div = 0;
			//int a = 10/div;
			array[5] =0;
		}
		catch (System.DivideByZeroException)
		{
			Console.WriteLine("Zero exception");
		}
		catch(System.Exception e)
		{
			throw;

			Console.WriteLine("Exception");
			Console.WriteLine(e.Message);
			Console.WriteLine(e.StackTrace);
		}

		

	}

};