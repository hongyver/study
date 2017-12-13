using System;

namespace test
{
	class Program
	{
		static void Main(string[] args)
		{
			int i, j, sum =0;

			for (i = 1; i < 9 ; i++)
			{
				for (j=1;j < 9 ;j++ )
				{
					Console.WriteLine(i + "*" + j + "=" + i*j);
				}
			}

			for (i = 0; i < 100 ; i=i+2)
			{
				sum += i;
			}
			Console.WriteLine(sum);

			for (i = 0; i < 1000 ; i++)
			{
				if((i % 3 == 0) || (i % 5 == 0))
					sum += i;
			}
			Console.WriteLine(sum);

			Person p;
			p = new Person("홍성제");
			p.OutputYourName();

			Person p1 = new Person("홍성제1");
			p1.OutputYourName();

			int n = 4;
			int r = hongf1(n);
			Console.WriteLine(" org 2^"+ n +" = " + r);
			r = hongf(n,1);
			Console.WriteLine(" 2^"+ n +" = " + r);
		}

		static int hongf(int n, int m)
		{
			if(n == 0)
				return m;

			return hongf(n-1,2*m);
		}

		static int hongf1(int n)
		{
			if(n == 0)
				return 1;

			return 2*hongf1(n-1);
		}
	};



	class Person
	{
		string _name;

		static Person()
		{
			Console.WriteLine("static 생성자");
		}

		public Person(string name)
		{
			_name = name;
			Console.WriteLine("public 생성자");
		}

		~Person()
		{
			Console.WriteLine("public 소멸자");
		}

		public void OutputYourName()
		{
			Console.WriteLine(_name);
		}

	};
}