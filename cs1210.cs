using System;
using System.Text;
using System.Collections;

public class NewStack<T>
{
	T[] _objList;
	int _pos;

	public NewStack(int size)
	{
		_objList = new T[size];
	}

	public void Push(T newValue)
	{
		_objList[_pos] = newValue;
		_pos++;
	}

	public T Pop()
	{
		_pos--;
		return _objList[_pos];
	}
};

public class Util
{
	public void Write<T>(T msg)
	{
		Console.WriteLine("{0} {1}", DateTime.Now, msg);
	}

	public T Max<T>(T t1, T t2) where T: IComparable
	{
		if (t1.CompareTo(t1) >=0 )
		{
			return t1;
		}

		return t2;
	}
}; 

class Program
{
	static void Main(string [] args)
	{
		Console.WriteLine(DateTime.Now);

		int n = 5;
		ArrayList ar = new ArrayList();

		ar.Add(n);

		NewStack<int> ns = new NewStack<int>(10);
		ns.Push(10);
		ns.Push(20);
		ns.Push(30);

		Console.WriteLine(ns.Pop());
		Console.WriteLine(ns.Pop());

		Util u = new Util();
		u.Write("test");
		u.Write(10);

		Console.WriteLine(u.Max(10,20));
		Console.WriteLine(u.Max("111","222"));

		string str = null;
		//ArrayList ll;

		Console.WriteLine(str ?? "NULL");
		//Console.WriteLine(ll ?? "NULL");
	}
};