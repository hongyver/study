using System;
using System.Collections;

class Program
{

	static void Main(string [] args)
	{
		int[] intArray = new int[] {1,2,3,4,5,6,7};

		Console.Write("TEst");

		foreach (int i in intArray)
		{
			Console.Write(i);
		}

//		IEnumerator enum = intArray.GetEnumerator();
//		while(enum.MoveNext())
//		{
//			Console.WriteLine(enum.Current);
//		}
	}
};
