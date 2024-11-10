using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Clock
{
	// Token: 0x02000050 RID: 80
	internal class UDP
	{
		// Token: 0x17000079 RID: 121
		// (get) Token: 0x06000888 RID: 2184 RVA: 0x00062D60 File Offset: 0x00060F60
		public static List<string> Servers
		{
			get
			{
				return UDP._servers;
			}
		}

		// Token: 0x06000889 RID: 2185 RVA: 0x00062D68 File Offset: 0x00060F68
		public static void StartRecieve()
		{
			UDP._udpReceive = new UdpClient(new IPEndPoint(IPAddress.Any, NetworkConnectionWindow.Port));
			UDP._udpReceive.BeginReceive(new AsyncCallback(UDP.ReceiveCallback), UDP._udpReceive);
			NetworkLog.Instance.addNetworkLog("", "", "UDP:受信開始");
		}

		// Token: 0x0600088A RID: 2186 RVA: 0x00062DC3 File Offset: 0x00060FC3
		public static void Stop()
		{
			if (UDP._udpReceive != null)
			{
				UDP._udpReceive.Close();
				UDP._udpReceive = null;
			}
			if (UDP._udpSend != null)
			{
				UDP._udpSend.Close();
				UDP._udpSend = null;
			}
		}

		// Token: 0x0600088B RID: 2187 RVA: 0x00062DF4 File Offset: 0x00060FF4
		public static void broadcast()
		{
			string text = string.Empty;
			if (!Server.isConnect() && Client.isConnect())
			{
				foreach (string text2 in UDP._servers)
				{
					if (text2.Split(new char[] { ',' })[1] == Client.ServerIpAddress.ToString())
					{
						text = text2;
						break;
					}
				}
			}
			UDP._servers.Clear();
			if (text != string.Empty)
			{
				UDP._servers.Add(text);
			}
			if (NetworkConnectionWindow.Instance != null)
			{
				NetworkConnectionWindow.Instance.updateServerList(UDP._servers);
			}
			byte[] bytes = Encoding.UTF8.GetBytes("check");
			IPEndPoint ipendPoint = new IPEndPoint(IPAddress.Broadcast, NetworkConnectionWindow.Port);
			UDP._udpSend = new UdpClient();
			UDP._udpSend.BeginSend(bytes, bytes.Length, ipendPoint, new AsyncCallback(UDP.SendCallback), UDP._udpSend);
			NetworkLog.Instance.addNetworkLog(UDP.getMyIPAddress().ToString(), "All", "UDP:ブロードキャスト");
		}

		// Token: 0x0600088C RID: 2188 RVA: 0x00062F20 File Offset: 0x00061120
		private static void ReceiveCallback(IAsyncResult result)
		{
			UdpClient udpClient = (UdpClient)result.AsyncState;
			IPEndPoint ipendPoint = null;
			byte[] array;
			try
			{
				array = udpClient.EndReceive(result, ref ipendPoint);
			}
			catch (SocketException ex)
			{
				NetworkLog.Instance.addNetworkLog("", "", string.Concat(new string[]
				{
					"UDP:受信エラー(",
					ex.Message,
					":",
					ex.ErrorCode.ToString(),
					")"
				}));
				return;
			}
			catch (ObjectDisposedException)
			{
				NetworkLog.Instance.addNetworkLog("", "", "UDP:切断済み");
				return;
			}
			if (!UDP.isMyIPAddress(ipendPoint.Address))
			{
				string @string = Encoding.UTF8.GetString(array);
				if (@string == "check")
				{
					if (Server.isConnect())
					{
						IPAddress address = ipendPoint.Address;
						string name = Server.Name;
						string text = ",";
						IPAddress myIPAddress = UDP.getMyIPAddress();
						UDP.reply(address, name + text + ((myIPAddress != null) ? myIPAddress.ToString() : null));
						NetworkLog.Instance.addNetworkLog(UDP.getMyIPAddress().ToString(), ipendPoint.Address.ToString(), "UDP:返信→");
					}
				}
				else
				{
					if (!UDP._servers.Contains(@string))
					{
						UDP._servers.Add(@string);
						NetworkLog.Instance.addNetworkLog(ipendPoint.Address.ToString(), UDP.getMyIPAddress().ToString(), "UDP:格納(" + @string + ")");
					}
					if (NetworkConnectionWindow.Instance != null)
					{
						NetworkConnectionWindow.Instance.Invoke(new MethodInvoker(delegate
						{
							NetworkConnectionWindow.Instance.updateServerList(UDP._servers);
						}));
					}
				}
			}
			udpClient.BeginReceive(new AsyncCallback(UDP.ReceiveCallback), udpClient);
		}

		// Token: 0x0600088D RID: 2189 RVA: 0x000630F0 File Offset: 0x000612F0
		private static bool isMyIPAddress(IPAddress ipAddress)
		{
			IPAddress[] hostAddresses = Dns.GetHostAddresses(Dns.GetHostName());
			for (int i = 0; i < hostAddresses.Length; i++)
			{
				if (hostAddresses[i].Equals(ipAddress))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600088E RID: 2190 RVA: 0x00063124 File Offset: 0x00061324
		public static IPAddress getMyIPAddress()
		{
			foreach (IPAddress ipaddress in Dns.GetHostAddresses(Dns.GetHostName()))
			{
				if (ipaddress.AddressFamily == AddressFamily.InterNetwork)
				{
					return ipaddress;
				}
			}
			return null;
		}

		// Token: 0x0600088F RID: 2191 RVA: 0x0006315C File Offset: 0x0006135C
		private static void reply(IPAddress ipAddress, string message)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(message);
			IPEndPoint ipendPoint = new IPEndPoint(ipAddress, NetworkConnectionWindow.Port);
			UDP._udpSend = new UdpClient();
			UDP._udpSend.BeginSend(bytes, bytes.Length, ipendPoint, new AsyncCallback(UDP.SendCallback), UDP._udpSend);
		}

		// Token: 0x06000890 RID: 2192 RVA: 0x000631AC File Offset: 0x000613AC
		private static void SendCallback(IAsyncResult result)
		{
			UdpClient udpClient = (UdpClient)result.AsyncState;
			try
			{
				udpClient.EndSend(result);
			}
			catch (SocketException ex)
			{
				NetworkLog.Instance.addNetworkLog("", "", string.Concat(new string[]
				{
					"UDP:送信エラー(",
					ex.Message,
					":",
					ex.ErrorCode.ToString(),
					")"
				}));
			}
			catch (ObjectDisposedException)
			{
				NetworkLog.Instance.addNetworkLog("", "", "UDP:切断済み");
			}
		}

		// Token: 0x0400064A RID: 1610
		private static List<string> _servers = new List<string>();

		// Token: 0x0400064B RID: 1611
		private static UdpClient _udpReceive = null;

		// Token: 0x0400064C RID: 1612
		private static UdpClient _udpSend = null;
	}
}
