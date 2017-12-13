using System;
using System.Collections;
using System.IO;
using System.Text;

class Program
{
	static void Main(string [] args)
	{
		Console.Write("Hello world!");

		Hashtable ht = new Hashtable();

		ht.Add("1","hello");
		ht.Add("2","world");

		Console.Write(ht);

		Console.WriteLine(ht["1"].ToString());

		SortedList sl = new SortedList();

		sl.Add("1", "1111");
		sl.Add("2", "2222");

		foreach(string key in sl.GetKeyList())
		{
			Console.WriteLine("{0} {1}", key, sl[key]);
		}

		string str = ht["1"].ToString() + @"test";
		Console.WriteLine(str);

		using ( FileStream fs = new FileStream("test.log", FileMode.Create))
		{
			StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
			sw.WriteLine("test");
			sw.WriteLine("hello filestream world");
			sw.Flush();
		}
		using ( FileStream fs = new FileStream("test2.log", FileMode.Create))
		{
			BinaryWriter bw = new BinaryWriter(fs);
			bw.Write("test" + Environment.NewLine);
			bw.Write("hello filestream world" + Environment.NewLine);
			bw.Flush();
		}

		string str1 = "aslkdfjsdfljsd;ldsfa";
		File.WriteAllText("test.log", str1);
		string text = File.ReadAllText("test.log");
		Console.WriteLine(text);

		foreach ( string drv in Directory.GetLogicalDrives())
		{
			Console.WriteLine(drv);
		}

		foreach ( string file in Directory.GetFiles("c:\\Go", "*.exe", SearchOption.AllDirectories))
		{
			Console.WriteLine(file);
		}
	}
};

