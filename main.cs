using System;

namespace TestMain
{
	class Point
	{
		int x,y;
		public Point(int x, int y)
		{
			this.x = x;
			this.y = y;
		}
		public override string ToString()
		{
			return "x: "+x+" Y: "+y + " type:"+base.ToString();
		}
	};
	class TestA
	{
			int abc = 10;

			public int test()
			{
				Console.WriteLine(this.abc);

				return 1;
			}
	};

	class Test
	{
		static void arraytest(Array intarray)
		{

			Console.WriteLine(intarray.Rank);
			Console.WriteLine(intarray.Length);

			Console.WriteLine(intarray.GetValue(intarray.Length-1));

		}

		static void Main(string[] args)
		{
			int[] intarray = new int[] {1,2,3,4,5};
			arraytest(intarray);

			TestA tt = new TestA();
			tt.test();

			Point pt = new Point(10,20);
			Console.WriteLine(pt.ToString());
//			string str1 = "test";
//			string str2 = "test";
//
//			Console.WriteLine("test");
//			Test test = new Test();
//			Test test1 = new Test();
//			Console.WriteLine(test.ToString());
//
//			Type type = test.GetType();
//			Console.WriteLine(type.FullName);
//			Console.WriteLine(test.GetType().FullName);
//			Console.WriteLine(typeof(Test));
//			Console.WriteLine(5.Equals(4));
//			Console.WriteLine(5.Equals(5));
//
//			Console.WriteLine("\nClass Equal");
//			Console.WriteLine(test.GetHashCode());
//			Console.WriteLine(test1.GetHashCode());
//			Console.WriteLine(test.Equals(test1));
//
//			Console.WriteLine("\nGet Hash Coce");
//			Console.WriteLine(str1 + str1.GetHashCode());
//			Console.WriteLine(str2 + str2.GetHashCode());
//			Console.WriteLine(str1.Equals(str2));
//
//			int n = 1;
//			int n1 = 1212;
//
//			Console.WriteLine(n.GetHashCode());
//			Console.WriteLine(n1.GetHashCode());
		}
	};
}
