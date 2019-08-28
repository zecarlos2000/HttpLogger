using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebRequestLogger
{
	class SocketManager
	{
		private const int MAX_CONNECTIONS = 10;
		private static ManualResetEvent allDone = new ManualResetEvent(false);

		public string RedirectUrl { get; set; }

		public delegate void NewListenerDelegate(string endpoint);
		public delegate void NewRequestDelegate(string requestContent);

		public event NewListenerDelegate OnNewListener;
		public event NewRequestDelegate OnNewRequest;

		public void StartListening()
		{
			//test:
			RedirectUrl = "http://f-eng-sandi-jav:8080/rulesengine.enterprise.service-8.2/RulesEngineService";

			Task.Run(() => StartListeningAsync());
		}

		public void StartListeningAsync()
		{
 
			IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
			IPAddress ipAddress = ipHostInfo.AddressList[0];
			IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);

			// Create a TCP/IP socket.  
			Socket socketListener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

			OnNewListener?.Invoke(localEndPoint.ToString());


			// Bind the socket to the local endpoint and listen for incoming connections.  
			try
			{
				socketListener.Bind(localEndPoint);
				socketListener.Listen(MAX_CONNECTIONS);

				while (true)
				{
					// Set the event to nonsignaled state.  
					allDone.Reset();

					// Start an asynchronous socket to listen for connections.  
					socketListener.BeginAccept(new AsyncCallback(AcceptCallback), socketListener); //todo: use AcceptAsync and get rid of ManualResetEvent

					// Wait until a connection is made before continuing.  
					allDone.WaitOne();
				}

			}
			catch (Exception e)
			{
				Console.WriteLine(e.ToString());
			}

		}

		private void AcceptCallback(IAsyncResult ar)
		{
			// Signal the main thread to continue.  
			allDone.Set();

			// Get the socket that handles the client request.  
			Socket listener = (Socket)ar.AsyncState;
			Socket handler = listener.EndAccept(ar);

			// Create the state object.  
			SocketStateObject state = new SocketStateObject();

			state.WorkSocket = handler;
			handler.BeginReceive(state.Buffer, 0, state.BufferSize, 0, new AsyncCallback(ReadCallback), state); //todo use ReceiveAsync

			//fenergo only
			handler.BeginReceive(state.Buffer, 0, state.BufferSize, 0, new AsyncCallback(ReadCallback), state); //todo use ReceiveAsync
		}

		private void ReadCallback(IAsyncResult ar)
		{
			// Retrieve the state object and the handler socket  
			// from the asynchronous state object.  
			SocketStateObject state = (SocketStateObject)ar.AsyncState;
			Socket handler = state.WorkSocket;

			// Read data from the client socket.   
			int bytesRead = handler.EndReceive(ar);

			if (bytesRead > 0)
			{
				// There  might be more data, so store the data received so far.  
				string content = Encoding.ASCII.GetString(state.Buffer, 0, bytesRead);
				OnNewRequest?.Invoke(content);

				handler.BeginReceive(state.Buffer, 0, state.BufferSize, 0, new AsyncCallback(ReadCallback), state); //todo use ReceiveAsync


				return;
				

				string response = @"HTTP/1.1 200 OK
									Date: Mon, 27 Jul 2009 12:28:53 GMT
									Server: Apache / 2.2.14(Win32)
									Last - Modified: Wed, 22 Jul 2009 19:15:56 GMT
									Content - Length: 0
									Connection: Closed
									";


				if (!String.IsNullOrEmpty(RedirectUrl))
				{
					response = GetResponseFromRedirect(content);
				}

				SendReply(handler, response);
			}
		}

		

		private void SendReply(Socket handler, string data)
		{
			// Convert the string data to byte data using ASCII encoding.  
			byte[] byteData = Encoding.ASCII.GetBytes(data);

			// Begin sending the data to the remote device.  
			//handler.BeginSend(byteData, 0, byteData.Length, 0, new AsyncCallback(SendCallback), handler); //use SendAsync

			handler.Send(byteData);
		}

		private void SendCallback(IAsyncResult ar)
		{
			// Retrieve the socket from the state object.  
			Socket handler = (Socket)ar.AsyncState;

			// Complete sending the data to the remote device.  
			int bytesSent = handler.EndSend(ar);

			handler.Shutdown(SocketShutdown.Both);
			handler.Close();
		}

		private string GetResponseFromRedirect(string content)
		{
			//HttpClient client = new HttpClient();
			//var stringContent = new StringContent(content,Encoding.UTF8, "text/xml");
			//var response = client.PostAsync(RedirectUrl, stringContent);
			//var responseString = response.Result.Content.ReadAsStringAsync();
			//return responseString.Result;

			Socket socket = new Socket( SocketType.Stream, ProtocolType.Tcp);
			string[] urlParts = RedirectUrl.Split(':');
			string portStr = string.IsNullOrEmpty(urlParts[1]) ? "80" : urlParts[1];
			int port = Convert.ToInt32(portStr);



			//IPEndPoint remoteEP = new IPEndPoint()



		   socket.Connect(urlParts[0], port);
			socket.Send(Encoding.ASCII.GetBytes(content));

			byte[] responseBytes = new byte[1024];
			int responseLenght = socket.Receive(responseBytes);
			string responseText = Encoding.ASCII.GetString(responseBytes, 0, responseLenght);
			return responseText;
		}
	}
}
