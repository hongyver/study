using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

using System.IO;

class Program
{
	static void Main(string [] args)
	{
		Console.WriteLine(DateTime.Now);

		//StartWebServer();

		HttpWebRequest req = WebRequest.Create("http://hongyver.pe.kr") as HttpWebRequest;
		HttpWebResponse resp = req.GetResponse() as HttpWebResponse;

		using (StreamReader sr = new StreamReader(resp.GetResponseStream()))
		{
			string txt = sr.ReadToEnd();
			Console.WriteLine(txt);
			File.WriteAllText("hongyver.pe.kr.html", txt);
		}

	}

	static void StartWebServer()
	{
		using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
		{
			IPEndPoint endp = new IPEndPoint(IPAddress.Any, 80);
			
			socket.Bind(endp);

			socket.Listen(2);

			while(true)
			{
				Socket csocket = socket.Accept();
				ThreadPool.QueueUserWorkItem(RecvProcessFunc, csocket);
			}
		}
	}


	static void RecvProcessFunc(object obj)
	{
		Socket csocket = obj as Socket;
		byte[] buf =new byte[4096];

		csocket.Receive(buf);

		string header = "HTTP/1.0 200 OK\nContent-Type: text/html; charset=UTF-8\r\n\r\n";
		string body = "<html><body><h1>웹서버입니다.</h1></body></html>";

		byte [] respBuf = Encoding.UTF8.GetBytes(header+body);
		csocket.Send(respBuf);
		csocket.Close();
	}
};