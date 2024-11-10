using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Clock
{
	// Token: 0x02000045 RID: 69
	public class NetworkSimulator
	{
		// Token: 0x17000053 RID: 83
		// (get) Token: 0x060006CF RID: 1743 RVA: 0x0005084A File Offset: 0x0004EA4A
		public static NetworkSimulator Instance
		{
			get
			{
				return NetworkSimulator._instance;
			}
		}

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x060006D0 RID: 1744 RVA: 0x00050851 File Offset: 0x0004EA51
		// (set) Token: 0x060006D1 RID: 1745 RVA: 0x00050859 File Offset: 0x0004EA59
		[XmlIgnore]
		public int Counter
		{
			get
			{
				return this._counter;
			}
			set
			{
				this._counter = value;
			}
		}

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x060006D2 RID: 1746 RVA: 0x00050862 File Offset: 0x0004EA62
		public NetworkProgramModules Programs
		{
			get
			{
				return this._programs;
			}
		}

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x060006D3 RID: 1747 RVA: 0x0005086A File Offset: 0x0004EA6A
		public NetworkSimulator.STATE State
		{
			get
			{
				return this._state;
			}
		}

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x060006D4 RID: 1748 RVA: 0x00050872 File Offset: 0x0004EA72
		public CommunicationModule.HardwareInfo HardwareInfo
		{
			get
			{
				return this._hardwareInfo;
			}
		}

		// Token: 0x060006D5 RID: 1749 RVA: 0x0005087A File Offset: 0x0004EA7A
		private NetworkSimulator()
		{
		}

		// Token: 0x060006D6 RID: 1750 RVA: 0x000508BC File Offset: 0x0004EABC
		public double getClientVariable(int index)
		{
			double num;
			if (double.TryParse(this.ClientVariables[index].Value, out num) && -32768.0 <= num && num <= 32767.0)
			{
				return num;
			}
			return 0.0;
		}

		// Token: 0x060006D7 RID: 1751 RVA: 0x00050908 File Offset: 0x0004EB08
		public double getInputVariable()
		{
			double num;
			if (double.TryParse(this.InputVariable, out num) && -32768.0 <= num && num <= 32767.0)
			{
				return num;
			}
			return 0.0;
		}

		// Token: 0x060006D8 RID: 1752 RVA: 0x00050948 File Offset: 0x0004EB48
		public void initialize(NetworkProgramModules program)
		{
			this._programs = program;
			this._programs.clearSelectBlocks();
			this.ServerVariables.Clear();
			for (int i = 0; i < program.ServerVariableNames.Count; i++)
			{
				this.ServerVariables.Add(new NetworkSimulator.NetworkVariable("", "", ""));
			}
			this.ClientVariables.Clear();
			for (int j = 0; j < program.ClientVariableNames.Count; j++)
			{
				this.ClientVariables.Add(new NetworkSimulator.NetworkVariable("", "", ""));
			}
			this.reset();
		}

		// Token: 0x060006D9 RID: 1753 RVA: 0x000509F0 File Offset: 0x0004EBF0
		private void reset()
		{
			this._counterPlay = false;
			this._counter = 0;
			int num = this.ServerVariables.Count;
			for (int i = 0; i < num; i++)
			{
				this.ServerVariables[i] = new NetworkSimulator.NetworkVariable("", "", "");
			}
			num = this.ClientVariables.Count;
			for (int j = 0; j < num; j++)
			{
				this.ClientVariables[j] = new NetworkSimulator.NetworkVariable("", UDP.getMyIPAddress().ToString(), Server.Name);
			}
			this.InputVariable = "";
			this._programs.reset();
		}

		// Token: 0x060006DA RID: 1754 RVA: 0x00050A98 File Offset: 0x0004EC98
		public void run()
		{
			Server.StopAccept();
			this._state = NetworkSimulator.STATE.RUN;
			NetworkLog.Instance.clearLog();
			NetworkWindow.Instance.SimulatorWindow.SimulatorArea.updateLabel(NetworkSimulatorArea.LABEL.EXECUTE);
			NetworkWindow.Instance.SimulatorWindow.SimulatorArea.updateLabel(NetworkSimulatorArea.LABEL.DETAIL_MAX);
			this._programs.run();
			((NetworkObjectInput)this._programs.ObjectInput.Control).setEnable(true);
			this._timer = new System.Windows.Forms.Timer();
			this._timer.Tick += this.OnUpdateHardwareInfo;
			this._timer.Interval = NetworkSimulator.UPDATE_HARDWARE_INFO_TIME;
			this._timer.Start();
		}

		// Token: 0x060006DB RID: 1755 RVA: 0x00050B48 File Offset: 0x0004ED48
		private void OnUpdateHardwareInfo(object sender, EventArgs e)
		{
			this._hardwareInfo = CommunicationModule.Instance.getHardwareInfo();
			NetworkWindow.Instance.SimulatorWindow.SimulatorArea.updateLabel(NetworkSimulatorArea.LABEL.HARDWARE);
		}

		// Token: 0x060006DC RID: 1756 RVA: 0x00050B70 File Offset: 0x0004ED70
		public void stop(NetworkSimulator.ERROR error = NetworkSimulator.ERROR.NONE)
		{
			this._programs.ObjectInput.Control.Invoke(new MethodInvoker(delegate
			{
				((NetworkObjectInput)this._programs.ObjectInput.Control).setEnable(false);
			}));
			this._counterPlay = false;
			this._programs.stop();
			this._timer.Stop();
			this._state = NetworkSimulator.STATE.STOP;
			NetworkWindow.Instance.SimulatorWindow.SimulatorArea.updateLabel(NetworkSimulatorArea.LABEL.EXECUTE);
			NetworkLog.Instance.Save();
			CommunicationModule.Instance.stopProgram(false);
			if (error != NetworkSimulator.ERROR.NONE)
			{
				this._programs.ObjectInput.Control.Invoke(new MethodInvoker(delegate
				{
					WarningDialog warningDialog = new WarningDialog();
					warningDialog.setText(NetworkSimulator.ERROR_TEXTS[(int)error]);
					warningDialog.ShowDialog();
				}));
			}
			if (Server.isConnect())
			{
				Server.StartAccept();
			}
		}

		// Token: 0x060006DD RID: 1757 RVA: 0x00050C38 File Offset: 0x0004EE38
		public void receiveMessage(int index)
		{
			this._programs.receiveMessage(index);
		}

		// Token: 0x060006DE RID: 1758 RVA: 0x00050C46 File Offset: 0x0004EE46
		public NetworkSimulator.ERROR sendMessage(int index)
		{
			if (Client.isConnect())
			{
				return Client.send("sendMessage," + index.ToString());
			}
			return NetworkSimulator.ERROR.NONE;
		}

		// Token: 0x060006DF RID: 1759 RVA: 0x00050C68 File Offset: 0x0004EE68
		public NetworkSimulator.ERROR sendVariable(int variableIndexServer, string value)
		{
			if (Client.isConnect())
			{
				return Client.send(string.Concat(new string[]
				{
					"sendVariable,",
					variableIndexServer.ToString(),
					",",
					value,
					",",
					UDP.getMyIPAddress().ToString(),
					",",
					Server.Name
				}));
			}
			return NetworkSimulator.ERROR.NONE;
		}

		// Token: 0x060006E0 RID: 1760 RVA: 0x00050CD1 File Offset: 0x0004EED1
		public NetworkSimulator.ERROR receiveVariable(int variableIndexClient, int variableIndexServer)
		{
			if (Client.isConnect())
			{
				return Client.send("receiveVariable," + variableIndexClient.ToString() + "," + variableIndexServer.ToString());
			}
			return NetworkSimulator.ERROR.NONE;
		}

		// Token: 0x060006E1 RID: 1761 RVA: 0x00050CFE File Offset: 0x0004EEFE
		public NetworkProgramModules.ObjectInputInfo getObjectInput()
		{
			return this._programs.ObjectInput;
		}

		// Token: 0x060006E2 RID: 1762 RVA: 0x00050D0C File Offset: 0x0004EF0C
		public async void counterStart()
		{
			if (!this._counterPlay)
			{
				this._counterPlay = true;
				await Task.Run(delegate
				{
					while (this._counterPlay)
					{
						Thread.Sleep(1000);
						if (!this._counterPlay)
						{
							break;
						}
						if (this._counter < 255)
						{
							this._counter++;
						}
					}
				});
			}
		}

		// Token: 0x060006E3 RID: 1763 RVA: 0x00050D43 File Offset: 0x0004EF43
		public void counterStop()
		{
			this._counterPlay = false;
		}

		// Token: 0x060006E4 RID: 1764 RVA: 0x00050D4C File Offset: 0x0004EF4C
		public void counterReset()
		{
			this._counter = 0;
		}

		// Token: 0x04000513 RID: 1299
		private static NetworkSimulator _instance = new NetworkSimulator();

		// Token: 0x04000514 RID: 1300
		public static readonly int UPDATE_HARDWARE_INFO_TIME = 100;

		// Token: 0x04000515 RID: 1301
		private int _counter;

		// Token: 0x04000516 RID: 1302
		private bool _counterPlay;

		// Token: 0x04000517 RID: 1303
		public List<NetworkSimulator.NetworkVariable> ServerVariables = new List<NetworkSimulator.NetworkVariable>();

		// Token: 0x04000518 RID: 1304
		public List<NetworkSimulator.NetworkVariable> ClientVariables = new List<NetworkSimulator.NetworkVariable>();

		// Token: 0x04000519 RID: 1305
		public string InputVariable = "";

		// Token: 0x0400051A RID: 1306
		private NetworkProgramModules _programs;

		// Token: 0x0400051B RID: 1307
		private NetworkSimulator.STATE _state;

		// Token: 0x0400051C RID: 1308
		private Random _random = new Random();

		// Token: 0x0400051D RID: 1309
		private CommunicationModule.HardwareInfo _hardwareInfo;

		// Token: 0x0400051E RID: 1310
		private System.Windows.Forms.Timer _timer = new System.Windows.Forms.Timer();

		// Token: 0x0400051F RID: 1311
		public static string[] ERROR_TEXTS = new string[] { "", "サーバーが停止しています。", "通信処理がタイムアウトしました。" };

		// Token: 0x020000BB RID: 187
		public struct NetworkVariable
		{
			// Token: 0x060010CF RID: 4303 RVA: 0x00094E87 File Offset: 0x00093087
			public NetworkVariable(string value, string ipAddress = "", string name = "")
			{
				this.Value = value;
				this.IPAddress = ipAddress;
				this.Name = name;
			}

			// Token: 0x060010D0 RID: 4304 RVA: 0x00094EA0 File Offset: 0x000930A0
			public bool isNumber()
			{
				double num;
				return double.TryParse(this.Value, out num) && -32768.0 <= num && num <= 32767.0;
			}

			// Token: 0x040008FD RID: 2301
			public static readonly int VARIABLE_LENGTH_MAX = 32;

			// Token: 0x040008FE RID: 2302
			public string Value;

			// Token: 0x040008FF RID: 2303
			public string IPAddress;

			// Token: 0x04000900 RID: 2304
			public string Name;
		}

		// Token: 0x020000BC RID: 188
		public enum STATE
		{
			// Token: 0x04000902 RID: 2306
			STOP,
			// Token: 0x04000903 RID: 2307
			RUN
		}

		// Token: 0x020000BD RID: 189
		public enum ERROR
		{
			// Token: 0x04000905 RID: 2309
			NONE,
			// Token: 0x04000906 RID: 2310
			SERVER_STOP,
			// Token: 0x04000907 RID: 2311
			TIMEOUT,
			// Token: 0x04000908 RID: 2312
			MAX
		}
	}
}
