using System;
using System.Text;
using System.Collections.Generic;
using System.Threading;

class Person
{
	string _name;
	int _age;
	bool? _getMarried;

	public string Name { get { return _name; } set { _name = value; } }
	public int Age { get { return _age; } set { _age = value; } }
	public bool? GetMarried { get { return _getMarried; } set { _getMarried = value; } }

};

class Program
{
	static void Main(string[] args)
	{
		Console.WriteLine(DateTime.Now);

//		int[] intlist = new int[] {1,2,3,4,5};
//		List<string> strs = new List<string>();
//		strs.Add("hong");
//		strs.Add("park");
//		strs.Add("kim");

//		foreach(int i in intlist)
//		{
//			Console.WriteLine(i);
//		}
//
//		foreach(string s in strs)
//		{
//			Console.WriteLine(s);
//		}
//
//		Person p = new Person();
//		p.Name = "hong";
//		p.Age = 47;
//		p.GetMarried = true;
//
//		Console.WriteLine("{0} {1} {2}", p.Name, p.Age, p.GetMarried);
//
//		if(p.GetMarried == null)
//			Console.WriteLine("미정");

		Person p = new Person { Name = "hong", Age = 40 };
		Console.WriteLine("{0} {1} {2}", p.Name, p.Age, p.GetMarried);

		//Thread thread = new Thread(ThreadFunc);
		Thread thread = new Thread(
			//delegate(object obj)
			(Object obj) =>
			{
				string text = obj as string;
				Console.WriteLine("{0} Delegate Thread start", text);
			});

		thread.Start("Test");

		thread.Join();

		Func<int, int, int> myFunc = (a,b) => a+b;
		Console.WriteLine("{0} + {1} = {2}", 1, 2, myFunc(1,2));

		List<int> intlist = new List<int> { 1,3,2,5,7,8,11,33,55,77,98 };
		List<int> evenlist = new List<int>();

		foreach(var i in intlist)
		{
			if(i % 2 == 0)
				evenlist.Add(i);
		}
		
		List<int> evenlist1 = intlist.FindAll((i) => i % 2 ==0);

		foreach(var j in evenlist)
		{
			Console.WriteLine(j);
		}

		foreach(var j in evenlist1)
		{
			Console.WriteLine(j);
		}


	}

	static void ThreadFunc(object obj)
	{
		string text = obj as string;
		Console.WriteLine("{0} Thread!!!!!", text);
	}
};