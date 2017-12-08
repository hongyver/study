using System;
using System.Net;
using System.Net.Sockets;

class Program
{
	static void Main(string [] args)
	{
		Console.WriteLine("Hello World NET {0}", DateTime.Now);

		Console.WriteLine(Dns.GetHostName());
		
		IPHostEntry entry = Dns.GetHostEntry(Dns.GetHostName());

		foreach(IPAddress addr in entry.AddressList)
		{
			Console.WriteLine(addr);
			if(addr.AddressFamily == AddressFamily.InterNetwork)
			{
				IPEndPoint ip = new IPEndPoint(addr, 8080);
				Console.WriteLine(ip);
			}
		}


	}
};