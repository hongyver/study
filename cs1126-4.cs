using System;
using System.Text;
using System.Net;
using System.Threading;
using System.Net.Sockets;

class Program
{
	static void Main(string [] args)
	{
		Console.WriteLine("11.26 Net");

		Thread Server = new Thread(serverfunc);
		Thread Client = new Thread(clientfunc);

		Server.IsBackground = true;
		Client.IsBackground = true;

		Server.Start();

		Thread.Sleep(500);

		Client.Start();

		Console.WriteLine("종료시 any key...");
		Console.ReadLine();
	}

	private static void serverfunc(object obj)
	{
		using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
		{
//			IPAddress ipAddress = GetCurrentIPAddress();
//			if(ipAddress == null)
//			{
//				Console.WriteLine("IPv4 bind fail");
//				return;
//			}

			IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 10200);
			socket.Bind(endPoint);

			Console.WriteLine("Bind {0}", endPoint);

			byte[] recvBytes = new byte[1024];
			EndPoint clientEP = new IPEndPoint(IPAddress.None, 0);

			while(true)
			{
				int nRecv = socket.ReceiveFrom(recvBytes, ref clientEP);
				string txt = Encoding.UTF8.GetString(recvBytes, 0, nRecv);

				byte[] sendBytes = Encoding.UTF8.GetBytes("Hello: " + txt);
				socket.SendTo(sendBytes, clientEP);
			}
		}
	}

	private static IPAddress GetCurrentIPAddress()
	{
		IPAddress [] addrs = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
		foreach( IPAddress ipAddr in addrs)
		{
			if(ipAddr.AddressFamily == AddressFamily.InterNetwork)
			{
				return ipAddr;
			}
		}

		return null;
	}

	private static void clientfunc(object obj)
	{
		Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

		EndPoint serverEP = new IPEndPoint(IPAddress.Loopback, 10200);
		EndPoint senderEP = new IPEndPoint(IPAddress.None, 0);

		//socket.Bind(serverEP);

		int nTimes = 5;

		while(nTimes-- > 0)
		{
			byte[] buf = Encoding.UTF8.GetBytes(DateTime.Now.ToString());
			socket.SendTo(buf, serverEP);

			byte[] recvBytes = new byte[1024];
			int nRecv = socket.ReceiveFrom(recvBytes, ref senderEP);
			string txt = Encoding.UTF8.GetString(recvBytes, 0, nRecv);

			Console.WriteLine(txt);
			Thread.Sleep(1000);
		}

		socket.Close();
		Console.WriteLine("UDP Client socket: Closed");
	}
};
