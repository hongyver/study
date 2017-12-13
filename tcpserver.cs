using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

using System.Threading;

class Program
{
	private static void ClientSocketProcess(object obj)
	{
		Socket clientsocket = obj as Socket;

		byte [] recvBytes = new Byte[1024];
		int nRecv = clientsocket.Receive(recvBytes);
		string txt = Encoding.UTF8.GetString(recvBytes, 0, nRecv);
		Console.WriteLine("Server Received : {0}", txt);

		byte [] sendBytes = Encoding.UTF8.GetBytes("Hello:"+txt);
		clientsocket.Send(sendBytes);
		clientsocket.Close();
	}

	private static void ServerThread()
	{
		Console.WriteLine("Server Thread Start!!");
		
		using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
		{
			IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 11200);
			socket.Bind(endPoint);
			socket.Listen(10);

			while(true)
			{
				Socket clientsocket = socket.Accept();
				Console.WriteLine("Sever Client Accepted");

				ThreadPool.QueueUserWorkItem((WaitCallback)ClientSocketProcess, clientsocket);
			}

			socket.Close();
			Console.WriteLine("Server socket closed");
		}
	}

	private static void ClientThread()
	{
		Console.WriteLine("Client Thread Start!!");

		using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
		{
			IPEndPoint endPoint = new IPEndPoint(IPAddress.Loopback, 11200);

			socket.Connect(endPoint);

			byte [] buf = Encoding.UTF8.GetBytes(DateTime.Now.ToString());
			socket.Send(buf);

			byte [] recvBytes = new Byte[1024];
			int nRecv = socket.Receive(recvBytes);
			string txt = Encoding.UTF8.GetString(recvBytes, 0, nRecv);

			Console.WriteLine(txt);

			socket.Close();
			Console.WriteLine("Client Socket closed");
		}
	}

	static void Main(string [] args)
	{
		Console.WriteLine(DateTime.Now);

		Thread server = new Thread(ServerThread);
		server.IsBackground = true;
		server.Start();

		for(int i =0;i<3;i++)
		{
			Thread client = new Thread(ClientThread);
			client.IsBackground = true;
			client.Start();
		}

		Console.ReadLine();
	}
};