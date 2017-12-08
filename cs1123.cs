using System;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Json;

using System.Collections;

[Serializable]
class Person
{
	int age;
	string name;

	public Person(int age, string name)
	{
		this.age = age;
		this.name = name;
	}

	public override string ToString()
	{
		return string.Format("{0} {1}", this.age, this.name);
	}
};

class Program
{
	static void Main(string[] args)
	{
		Console.Write("test");

		DataContractJsonSerializer dcjs = new DataContractJsonSerializer(typeof(Person));

		MemoryStream ms = new MemoryStream();

		Person person = new Person(47,"hong");

		dcjs.WriteObject(ms, person);
		ms.Position = 0;

		Person clone = dcjs.ReadObject(ms) as Person;

		Console.WriteLine(clone);

		byte[] buf = ms.ToArray();
		Console.WriteLine(Encoding.UTF8.GetString(buf));

		ArrayList ar = new ArrayList();

		ar.Add("hello");
		ar.Add("world");

		Console.WriteLine(ar.Contains(1));
		foreach (object obj in ar)
		{
			Console.WriteLine(obj);
		}
	}
};