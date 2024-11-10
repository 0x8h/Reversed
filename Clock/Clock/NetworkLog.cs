using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace Clock
{
	// Token: 0x02000037 RID: 55
	public class NetworkLog
	{
		// Token: 0x0600060D RID: 1549 RVA: 0x0004BA34 File Offset: 0x00049C34
		private NetworkLog()
		{
			if (File.Exists(NetworkLog.FILE_PATH))
			{
				try
				{
					File.Delete(NetworkLog.OLD_FILE_PATH);
					File.Move(NetworkLog.FILE_PATH, NetworkLog.OLD_FILE_PATH);
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex);
				}
			}
		}

		// Token: 0x0600060E RID: 1550 RVA: 0x0004BAB4 File Offset: 0x00049CB4
		public void addLog(NetworkLog.IMPORTANCE importance, string text)
		{
			this._mutex.WaitOne();
			if (this._logs.Count == NetworkLog.LOG_MAX)
			{
				this._logs.RemoveAt(0);
			}
			this._logs.Add("【" + importance.ToString() + "】" + text);
			this._mutex.ReleaseMutex();
		}

		// Token: 0x0600060F RID: 1551 RVA: 0x0004BB20 File Offset: 0x00049D20
		public void addNetworkLog(string from, string to, string text)
		{
			string text2 = string.Concat(new string[]
			{
				"[",
				DateTime.Now.ToString(),
				"](",
				from,
				"->",
				to,
				")",
				text
			});
			this._networkMutex.WaitOne();
			if (this._networkLogs.Count == NetworkLog.LOG_MAX)
			{
				this._networkLogs.RemoveAt(0);
			}
			this._networkLogs.Add(text2);
			this._networkMutex.ReleaseMutex();
			Console.WriteLine(text2);
		}

		// Token: 0x06000610 RID: 1552 RVA: 0x0004BBBC File Offset: 0x00049DBC
		public string getLog()
		{
			StringWriter stringWriter = new StringWriter();
			this._mutex.WaitOne();
			foreach (string text in this._logs)
			{
				stringWriter.Write(text);
				stringWriter.Write("\r\n");
			}
			this._mutex.ReleaseMutex();
			return stringWriter.ToString();
		}

		// Token: 0x06000611 RID: 1553 RVA: 0x0004BC40 File Offset: 0x00049E40
		public void clearLog()
		{
			this._mutex.WaitOne();
			this._logs.Clear();
			this._mutex.ReleaseMutex();
		}

		// Token: 0x06000612 RID: 1554 RVA: 0x0004BC64 File Offset: 0x00049E64
		public void Save()
		{
			try
			{
				using (StreamWriter streamWriter = new StreamWriter(NetworkLog.FILE_PATH, false, Encoding.GetEncoding("shift_jis")))
				{
					this._networkMutex.WaitOne();
					foreach (string text in this._networkLogs)
					{
						streamWriter.Write(text + "\r\n");
					}
					this._networkMutex.ReleaseMutex();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}
		}

		// Token: 0x040004BC RID: 1212
		private static readonly int LOG_MAX = 1000;

		// Token: 0x040004BD RID: 1213
		private static readonly string FILE_PATH = "log.txt";

		// Token: 0x040004BE RID: 1214
		private static readonly string OLD_FILE_PATH = "log_old.txt";

		// Token: 0x040004BF RID: 1215
		private List<string> _logs = new List<string>();

		// Token: 0x040004C0 RID: 1216
		private List<string> _networkLogs = new List<string>();

		// Token: 0x040004C1 RID: 1217
		private Mutex _mutex = new Mutex();

		// Token: 0x040004C2 RID: 1218
		private Mutex _networkMutex = new Mutex();

		// Token: 0x040004C3 RID: 1219
		public static NetworkLog Instance = new NetworkLog();

		// Token: 0x020000A9 RID: 169
		public enum IMPORTANCE
		{
			// Token: 0x040008A5 RID: 2213
			INFO,
			// Token: 0x040008A6 RID: 2214
			NOTICE,
			// Token: 0x040008A7 RID: 2215
			WARNING
		}
	}
}
