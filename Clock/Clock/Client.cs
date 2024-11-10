using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Clock
{
	// Token: 0x0200004E RID: 78
	internal class Client
	{
		// Token: 0x17000076 RID: 118
		// (get) Token: 0x0600086A RID: 2154 RVA: 0x00061B18 File Offset: 0x0005FD18
		// (set) Token: 0x0600086B RID: 2155 RVA: 0x00061B1F File Offset: 0x0005FD1F
		public static IPAddress ServerIpAddress { get; set; } = null;

		// Token: 0x17000077 RID: 119
		// (get) Token: 0x0600086C RID: 2156 RVA: 0x00061B27 File Offset: 0x0005FD27
		// (set) Token: 0x0600086D RID: 2157 RVA: 0x00061B2E File Offset: 0x0005FD2E
		public static string ServerName { get; set; } = "";

		// Token: 0x0600086E RID: 2158 RVA: 0x00061B36 File Offset: 0x0005FD36
		public static bool isConnect()
		{
			return Client._socket != null && Client._socket.Connected;
		}

		// Token: 0x0600086F RID: 2159 RVA: 0x00061B4C File Offset: 0x0005FD4C
		public static void Connect(IPAddress ipAddress, string name)
		{
			Client.ServerIpAddress = ipAddress;
			Client.ServerName = name;
			IPEndPoint ipendPoint = new IPEndPoint(ipAddress, NetworkConnectionWindow.Port);
			if (Client._socket == null)
			{
				Client._socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			}
			Client._socket.BeginConnect(ipendPoint, new AsyncCallback(Client.ConnectCallback), Client._socket);
			NetworkLog.Instance.addNetworkLog(UDP.getMyIPAddress().ToString(), ipAddress.ToString(), "client:接続要求");
		}

		// Token: 0x06000870 RID: 2160 RVA: 0x00061BC4 File Offset: 0x0005FDC4
		public static void Disconnect()
		{
			if (Client._socket != null)
			{
				bool flag = false;
				try
				{
					Client._socket.Disconnect(flag);
				}
				catch (SocketException)
				{
					NetworkLog.Instance.addNetworkLog("", "", "client:切断済み");
					Client._socket = null;
					return;
				}
				if (!flag)
				{
					Client._socket.Close();
					Client._socket = null;
				}
				NetworkLog.Instance.addNetworkLog("", "", "client:接続解除");
			}
		}

		// Token: 0x06000871 RID: 2161 RVA: 0x00061C48 File Offset: 0x0005FE48
		public static NetworkSimulator.ERROR send(string text)
		{
			text += ":";
			NetworkLog.Instance.addNetworkLog(UDP.getMyIPAddress().ToString(), Client.ServerIpAddress.ToString(), "client:送信:" + text);
			Client._socket.Send(Encoding.UTF8.GetBytes(text));
			Client._sending = true;
			double num = Client.TIMEOUT;
			while (Client._sending)
			{
				num -= 0.1;
				Thread.Sleep(100);
				if (num < 0.0)
				{
					Client._sending = false;
					if (NetworkWindow.Instance.StopProgramWithErrorFlag)
					{
						NetworkSimulator.Instance.stop(NetworkSimulator.ERROR.TIMEOUT);
					}
					return NetworkSimulator.ERROR.TIMEOUT;
				}
			}
			return NetworkSimulator.ERROR.NONE;
		}

		// Token: 0x06000872 RID: 2162 RVA: 0x00061CF8 File Offset: 0x0005FEF8
		private static void ConnectCallback(IAsyncResult result)
		{
			try
			{
				Socket socket = (Socket)result.AsyncState;
				socket.EndConnect(result);
				string ip = socket.RemoteEndPoint.ToString().Split(new char[] { ':' })[0];
				if (socket.Connected)
				{
					NetworkLog.Instance.addNetworkLog(Client.ServerIpAddress.ToString(), ip, "client:接続完了");
					if (NetworkConnectionWindow.Instance != null)
					{
						NetworkConnectionWindow.Instance.Invoke(new MethodInvoker(delegate
						{
							NetworkConnectionWindow.Instance.updateConnectedServer(ip);
							NetworkConnectionWindow.Instance.updateLabelWhich();
						}));
					}
					Client.AsyncStateObject asyncStateObject = new Client.AsyncStateObject(socket);
					Client.StartReceive(asyncStateObject);
					NetworkLog.Instance.addNetworkLog("", "", "client:受信開始");
					asyncStateObject.Socket.Send(Encoding.UTF8.GetBytes("clientName," + Server.Name));
				}
				else
				{
					NetworkLog.Instance.addNetworkLog(Client.ServerIpAddress.ToString(), ip, "client:接続失敗");
				}
			}
			catch (Exception ex)
			{
				NetworkLog.Instance.addNetworkLog("", "", ex.ToString());
			}
		}

		// Token: 0x06000873 RID: 2163 RVA: 0x00061E24 File Offset: 0x00060024
		private static void StartReceive(Client.AsyncStateObject stateObject)
		{
			stateObject.Socket.BeginReceive(stateObject.ReceiveBuffer, 0, stateObject.ReceiveBuffer.Length, SocketFlags.None, new AsyncCallback(Client.ReceiveDataCallback), stateObject);
		}

		// Token: 0x06000874 RID: 2164 RVA: 0x00061E50 File Offset: 0x00060050
		private static void ReceiveDataCallback(IAsyncResult result)
		{
			Client.AsyncStateObject asyncStateObject = (Client.AsyncStateObject)result.AsyncState;
			int num = 0;
			try
			{
				num = asyncStateObject.Socket.EndReceive(result);
			}
			catch (ObjectDisposedException)
			{
				Client.errorDisconnect();
				return;
			}
			catch (SocketException)
			{
				Client.errorDisconnect();
				return;
			}
			if (num <= 0)
			{
				Client.errorDisconnect();
				return;
			}
			asyncStateObject.ReceivedData.Write(asyncStateObject.ReceiveBuffer, 0, num);
			if (asyncStateObject.Socket.Available == 0)
			{
				string @string = Encoding.UTF8.GetString(asyncStateObject.ReceivedData.ToArray());
				NetworkLog.Instance.addNetworkLog(Client.ServerIpAddress.ToString(), UDP.getMyIPAddress().ToString(), "client:受信:" + @string);
				string[] array = @string.Split(new char[] { ':' });
				for (int i = 0; i < array.Length; i++)
				{
					string text = array[i];
					if (text.Length != 0)
					{
						string[] splits = text.Split(new char[] { ',' });
						string text2 = splits[0];
						uint num2 = <PrivateImplementationDetails>.ComputeStringHash(text2);
						if (num2 <= 1172766443U)
						{
							if (num2 != 269155979U)
							{
								if (num2 != 370683718U)
								{
									if (num2 == 1172766443U)
									{
										if (text2 == "disconnect")
										{
											Client.Disconnect();
											NetworkConnectionWindow.Instance.Invoke(new MethodInvoker(delegate
											{
												NetworkConnectionWindow.Instance.updateConnectedServer("");
												NetworkConnectionWindow.Instance.updateLabelWhich();
											}));
										}
									}
								}
								else if (text2 == "receiveVariable")
								{
									if (NetworkSimulator.Instance.State == NetworkSimulator.STATE.RUN)
									{
										NetworkSimulator.NetworkVariable networkVariable = NetworkSimulator.Instance.ClientVariables[int.Parse(splits[1])];
										int num3 = int.Parse(splits[1]);
										int num4 = int.Parse(splits[2]);
										networkVariable.Value = splits[3];
										networkVariable.IPAddress = splits[4];
										networkVariable.Name = splits[5];
										NetworkSimulator.Instance.ClientVariables[num3] = networkVariable;
										NetworkLog.Instance.addLog(NetworkLog.IMPORTANCE.INFO, string.Concat(new string[]
										{
											"受信：",
											NetworkWindow.Instance.Programs.ClientVariableNames[num3],
											"「",
											networkVariable.Value,
											"」 = ",
											NetworkWindow.Instance.Programs.ServerVariableNames[num4],
											"「",
											networkVariable.Value,
											"」"
										}));
										NetworkWindow.Instance.SimulatorWindow.SimulatorArea.updateLabel(NetworkSimulatorArea.LABEL.CLIENT_VARIABLE);
										NetworkWindow.Instance.SimulatorWindow.SimulatorArea.updateLabel(NetworkSimulatorArea.LABEL.DETAIL_MAX);
									}
								}
							}
							else if (text2 == "connectCheck")
							{
								if (NetworkCheckWindow.Instance != null && NetworkCheckWindow.Instance.IpAddress.ToString() != splits[1])
								{
									NetworkCheckWindow.Instance.Invoke(new MethodInvoker(delegate
									{
										NetworkCheckWindow.Instance.setLabel("受信OK", splits[1]);
									}));
								}
							}
						}
						else if (num2 <= 1671319129U)
						{
							if (num2 != 1499316702U)
							{
								if (num2 == 1671319129U)
								{
									if (text2 == "errorExecution")
									{
										if (NetworkWindow.Instance.StopProgramWithErrorFlag)
										{
											NetworkSimulator.Instance.stop(NetworkSimulator.ERROR.SERVER_STOP);
										}
										else
										{
											NetworkLog.Instance.addLog(NetworkLog.IMPORTANCE.INFO, NetworkSimulator.ERROR_TEXTS[1]);
											NetworkWindow.Instance.SimulatorWindow.SimulatorArea.updateLabel(NetworkSimulatorArea.LABEL.DETAIL_MAX);
										}
									}
								}
							}
							else if (text2 == "response")
							{
								Client._sending = false;
							}
						}
						else if (num2 != 1811346947U)
						{
							if (num2 == 2584183790U)
							{
								if (text2 == "sendMessage")
								{
									if (NetworkSimulator.Instance.State == NetworkSimulator.STATE.RUN)
									{
										NetworkSimulator.Instance.receiveMessage(int.Parse(splits[1]));
									}
								}
							}
						}
						else if (text2 == "sendVariable")
						{
							if (NetworkSimulator.Instance.State == NetworkSimulator.STATE.RUN)
							{
								NetworkSimulator.NetworkVariable networkVariable2 = NetworkSimulator.Instance.ServerVariables[int.Parse(splits[1])];
								networkVariable2.Value = splits[2];
								networkVariable2.IPAddress = splits[3];
								networkVariable2.Name = splits[4];
								NetworkSimulator.Instance.ServerVariables[int.Parse(splits[1])] = networkVariable2;
								NetworkLog.Instance.addLog(NetworkLog.IMPORTANCE.INFO, string.Concat(new string[] { "サーバ：\"", networkVariable2.Name, "(", networkVariable2.IPAddress, ")\"が送信：", networkVariable2.Value }));
								NetworkWindow.Instance.SimulatorWindow.SimulatorArea.updateLabel(NetworkSimulatorArea.LABEL.SERVER_VARIABLE);
								NetworkWindow.Instance.SimulatorWindow.SimulatorArea.updateLabel(NetworkSimulatorArea.LABEL.DETAIL_MAX);
							}
						}
					}
				}
				asyncStateObject.ReceivedData.Close();
				asyncStateObject.ReceivedData = new MemoryStream();
			}
			if (Client.isConnect())
			{
				Client.StartReceive(asyncStateObject);
			}
		}

		// Token: 0x06000875 RID: 2165 RVA: 0x000623DC File Offset: 0x000605DC
		private static void errorDisconnect()
		{
			if (NetworkConnectionWindow.Instance != null)
			{
				NetworkConnectionWindow.Instance.Invoke(new MethodInvoker(delegate
				{
					UDP.broadcast();
					NetworkConnectionWindow.Instance.updateLabelWhich();
				}));
			}
			NetworkLog.Instance.addNetworkLog("", "", "client:切断済み");
			Client.Disconnect();
		}

		// Token: 0x04000639 RID: 1593
		private static readonly double TIMEOUT = 5.0;

		// Token: 0x0400063A RID: 1594
		private static Socket _socket = null;

		// Token: 0x0400063B RID: 1595
		private static bool _sending = false;

		// Token: 0x020000CD RID: 205
		public class AsyncStateObject
		{
			// Token: 0x060010F7 RID: 4343 RVA: 0x000951DB File Offset: 0x000933DB
			public AsyncStateObject(Socket socket)
			{
				this.Socket = socket;
				this.ReceiveBuffer = new byte[1024];
				this.ReceivedData = new MemoryStream();
			}

			// Token: 0x04000956 RID: 2390
			public Socket Socket;

			// Token: 0x04000957 RID: 2391
			public byte[] ReceiveBuffer;

			// Token: 0x04000958 RID: 2392
			public MemoryStream ReceivedData;
		}
	}
}
