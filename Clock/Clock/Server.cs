using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Clock
{
	// Token: 0x0200004F RID: 79
	internal class Server
	{
		// Token: 0x17000078 RID: 120
		// (get) Token: 0x06000878 RID: 2168 RVA: 0x00062464 File Offset: 0x00060664
		// (set) Token: 0x06000879 RID: 2169 RVA: 0x0006246B File Offset: 0x0006066B
		public static string Name { get; set; } = "no name";

		// Token: 0x0600087A RID: 2170 RVA: 0x00062474 File Offset: 0x00060674
		public static void Start()
		{
			if (Server._socket == null)
			{
				IPEndPoint ipendPoint = new IPEndPoint(IPAddress.Any, NetworkConnectionWindow.Port);
				Server._socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
				Server._socket.Bind(ipendPoint);
				Server._socket.Listen(100);
				Server.StartAccept();
				NetworkLog.Instance.addNetworkLog("", "", "server:開始");
				Client.Connect(UDP.getMyIPAddress(), Server.Name);
				UDP.StartRecieve();
			}
		}

		// Token: 0x0600087B RID: 2171 RVA: 0x000624F0 File Offset: 0x000606F0
		public static void Stop()
		{
			if (Server._socket != null)
			{
				UDP.Stop();
				Client.Disconnect();
				Server._mutexClients.WaitOne();
				foreach (Socket socket in Server._clients)
				{
					socket.Close();
				}
				Server._clients.Clear();
				Server._mutexClients.ReleaseMutex();
				Server.ClientsInfo.Clear();
				Server._socket.Close();
				Server._socket = null;
				NetworkLog.Instance.addNetworkLog("", "", "server:停止");
			}
		}

		// Token: 0x0600087C RID: 2172 RVA: 0x000625A8 File Offset: 0x000607A8
		public static bool isConnect()
		{
			return Server._socket != null;
		}

		// Token: 0x0600087D RID: 2173 RVA: 0x000625B2 File Offset: 0x000607B2
		public static void StartAccept()
		{
			Server._socket.BeginAccept(new AsyncCallback(Server.AcceptCallback), Server._socket);
			Server._accept = true;
		}

		// Token: 0x0600087E RID: 2174 RVA: 0x000625D6 File Offset: 0x000607D6
		public static void StopAccept()
		{
			Server._accept = false;
		}

		// Token: 0x0600087F RID: 2175 RVA: 0x000625DE File Offset: 0x000607DE
		private static void response(Socket client)
		{
			Server.send(client, "response");
		}

		// Token: 0x06000880 RID: 2176 RVA: 0x000625EC File Offset: 0x000607EC
		private static void send(Socket client, string text)
		{
			text += ":";
			NetworkLog.Instance.addNetworkLog(UDP.getMyIPAddress().ToString(), client.RemoteEndPoint.ToString().Split(new char[] { ':' })[0], "server:送信:" + text);
			client.Send(Encoding.UTF8.GetBytes(text));
		}

		// Token: 0x06000881 RID: 2177 RVA: 0x00062654 File Offset: 0x00060854
		private static void broadcast(string text)
		{
			text += ":";
			NetworkLog.Instance.addNetworkLog(UDP.getMyIPAddress().ToString(), "All", "server:全体送信:" + text);
			Server._mutexClients.WaitOne();
			foreach (Socket socket in Server._clients)
			{
				socket.Send(Encoding.UTF8.GetBytes(text));
			}
			Server._mutexClients.ReleaseMutex();
		}

		// Token: 0x06000882 RID: 2178 RVA: 0x000626F8 File Offset: 0x000608F8
		private static void AcceptCallback(IAsyncResult result)
		{
			Socket socket = null;
			try
			{
				socket = Server._socket.EndAccept(result);
			}
			catch
			{
				NetworkLog.Instance.addNetworkLog("", "", "server:切断済み");
				return;
			}
			string text = socket.RemoteEndPoint.ToString().Split(new char[] { ':' })[0];
			if (Server._accept)
			{
				Server._mutexClients.WaitOne();
				Server._clients.Add(socket);
				NetworkLog.Instance.addNetworkLog(text, UDP.getMyIPAddress().ToString(), "server:クライアント接続(" + Server._clients.Count.ToString() + "人)");
				Server._mutexClients.ReleaseMutex();
				Server.StartReceive(new Client.AsyncStateObject(socket));
				NetworkLog.Instance.addNetworkLog("", "", "server:受信開始");
				Server.StartAccept();
				return;
			}
			Server.send(socket, "disconnect");
			NetworkLog.Instance.addNetworkLog(UDP.getMyIPAddress().ToString(), text, "server:接続拒否");
			socket.Close();
			Server.StartAccept();
			Server.StopAccept();
		}

		// Token: 0x06000883 RID: 2179 RVA: 0x00062824 File Offset: 0x00060A24
		private static void StartReceive(Client.AsyncStateObject stateObject)
		{
			stateObject.Socket.BeginReceive(stateObject.ReceiveBuffer, 0, stateObject.ReceiveBuffer.Length, SocketFlags.None, new AsyncCallback(Server.ReceiveDataCallback), stateObject);
		}

		// Token: 0x06000884 RID: 2180 RVA: 0x00062850 File Offset: 0x00060A50
		private static void ReceiveDataCallback(IAsyncResult result)
		{
			Client.AsyncStateObject asyncStateObject = (Client.AsyncStateObject)result.AsyncState;
			string text = "";
			int num = 0;
			try
			{
				text = asyncStateObject.Socket.RemoteEndPoint.ToString().Split(new char[] { ':' })[0];
				num = asyncStateObject.Socket.EndReceive(result);
			}
			catch (ObjectDisposedException)
			{
				Server._mutexClients.WaitOne();
				Server._clients.Remove(asyncStateObject.Socket);
				Server._mutexClients.ReleaseMutex();
				Server.errorDisconnect(text);
				return;
			}
			catch (SocketException)
			{
				Server._mutexClients.WaitOne();
				Server._clients.Remove(asyncStateObject.Socket);
				Server._mutexClients.ReleaseMutex();
				Server.errorDisconnect(text);
				return;
			}
			if (num <= 0)
			{
				Server._mutexClients.WaitOne();
				Server._clients.Remove(asyncStateObject.Socket);
				Server._mutexClients.ReleaseMutex();
				Server.errorDisconnect(text);
				asyncStateObject.Socket.Close();
				return;
			}
			asyncStateObject.ReceivedData.Write(asyncStateObject.ReceiveBuffer, 0, num);
			if (asyncStateObject.Socket.Available == 0)
			{
				string @string = Encoding.UTF8.GetString(asyncStateObject.ReceivedData.ToArray());
				NetworkLog.Instance.addNetworkLog(text, UDP.getMyIPAddress().ToString(), "server:受信:" + @string);
				foreach (string text2 in @string.Split(new char[] { ':' }))
				{
					if (text2.Length != 0)
					{
						string[] array2 = text2.Split(new char[] { ',' });
						string text3 = array2[0];
						if (!(text3 == "clientName") && !(text3 == "connectCheck") && NetworkSimulator.Instance.State != NetworkSimulator.STATE.RUN)
						{
							Server.send(asyncStateObject.Socket, "errorExecution");
						}
						else
						{
							text3 = array2[0];
							if (!(text3 == "clientName"))
							{
								if (!(text3 == "sendMessage"))
								{
									if (!(text3 == "sendVariable"))
									{
										if (!(text3 == "receiveVariable"))
										{
											if (text3 == "connectCheck")
											{
												Server.broadcast(text2);
												Server.response(asyncStateObject.Socket);
											}
										}
										else
										{
											Server.send(asyncStateObject.Socket, string.Concat(new string[]
											{
												"receiveVariable,",
												array2[1],
												",",
												array2[2],
												",",
												NetworkSimulator.Instance.ServerVariables[int.Parse(array2[2])].Value,
												",",
												NetworkSimulator.Instance.ServerVariables[int.Parse(array2[2])].IPAddress,
												",",
												NetworkSimulator.Instance.ServerVariables[int.Parse(array2[2])].Name
											}));
											Server.response(asyncStateObject.Socket);
										}
									}
									else
									{
										NetworkSimulator.NetworkVariable networkVariable = NetworkSimulator.Instance.ServerVariables[int.Parse(array2[1])];
										networkVariable.Value = array2[2];
										networkVariable.IPAddress = array2[3];
										networkVariable.Name = array2[4];
										NetworkSimulator.Instance.ServerVariables[int.Parse(array2[1])] = networkVariable;
										NetworkWindow.Instance.SimulatorWindow.SimulatorArea.updateLabel(NetworkSimulatorArea.LABEL.SERVER_VARIABLE);
										if (NetworkWindow.Instance.ServerDataShareFlag)
										{
											Server.broadcast(text2);
										}
										Server.response(asyncStateObject.Socket);
									}
								}
								else
								{
									Server.broadcast(text2);
									Server.response(asyncStateObject.Socket);
								}
							}
							else if (!Server.ClientsInfo.ContainsKey(text))
							{
								Server.ClientsInfo.Add(text, array2[1]);
								if (NetworkConnectionWindow.Instance != null)
								{
									NetworkConnectionWindow.Instance.Invoke(new MethodInvoker(delegate
									{
										NetworkConnectionWindow.Instance.updateClientList(Server.ClientsInfo);
									}));
								}
							}
						}
					}
				}
				asyncStateObject.ReceivedData.Close();
				asyncStateObject.ReceivedData = new MemoryStream();
			}
			Server.StartReceive(asyncStateObject);
		}

		// Token: 0x06000885 RID: 2181 RVA: 0x00062C94 File Offset: 0x00060E94
		private static void errorDisconnect(string ipAddress)
		{
			Server._mutexClients.WaitOne();
			NetworkLog.Instance.addNetworkLog(ipAddress, UDP.getMyIPAddress().ToString(), "server:切断済み(" + Server._clients.Count.ToString() + "人)");
			Server._mutexClients.ReleaseMutex();
			if (Server.ClientsInfo.Remove(ipAddress) && NetworkConnectionWindow.Instance != null)
			{
				NetworkConnectionWindow.Instance.Invoke(new MethodInvoker(delegate
				{
					NetworkConnectionWindow.Instance.updateClientList(Server.ClientsInfo);
				}));
			}
		}

		// Token: 0x0400063C RID: 1596
		public static Dictionary<string, string> ClientsInfo = new Dictionary<string, string>();

		// Token: 0x0400063E RID: 1598
		public const string PROTOCOL_CLIENT_NAME = "clientName";

		// Token: 0x0400063F RID: 1599
		public const string PROTOCOL_SEND_MESSAGE = "sendMessage";

		// Token: 0x04000640 RID: 1600
		public const string PROTOCOL_SEND_VARIABLE = "sendVariable";

		// Token: 0x04000641 RID: 1601
		public const string PROTOCOL_RECEIVE_VARIABLE = "receiveVariable";

		// Token: 0x04000642 RID: 1602
		public const string PROTOCOL_DISCONNECT = "disconnect";

		// Token: 0x04000643 RID: 1603
		public const string PROTOCOL_ERROR_EXECUTION = "errorExecution";

		// Token: 0x04000644 RID: 1604
		public const string PROTOCOL_RESPONSE = "response";

		// Token: 0x04000645 RID: 1605
		public const string PROTOCOL_CONNECT_CHECK = "connectCheck";

		// Token: 0x04000646 RID: 1606
		private static Socket _socket = null;

		// Token: 0x04000647 RID: 1607
		private static List<Socket> _clients = new List<Socket>();

		// Token: 0x04000648 RID: 1608
		private static Mutex _mutexClients = new Mutex();

		// Token: 0x04000649 RID: 1609
		private static bool _accept = false;
	}
}
