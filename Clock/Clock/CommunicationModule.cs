using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Timers;
using EducationMaterial;

namespace Clock
{
	// Token: 0x0200001B RID: 27
	public class CommunicationModule
	{
		// Token: 0x1700000A RID: 10
		// (get) Token: 0x060001F6 RID: 502 RVA: 0x0001EB49 File Offset: 0x0001CD49
		public static CommunicationModule Instance
		{
			get
			{
				return CommunicationModule._instance;
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x060001F7 RID: 503 RVA: 0x0001EB50 File Offset: 0x0001CD50
		public bool IsCorrectVersion
		{
			get
			{
				return this._isCorrectVersion;
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x060001F8 RID: 504 RVA: 0x0001EB58 File Offset: 0x0001CD58
		public bool Connected
		{
			get
			{
				return this._connected;
			}
		}

		// Token: 0x060001F9 RID: 505 RVA: 0x0001EB60 File Offset: 0x0001CD60
		public bool initialize()
		{
			try
			{
				this._educationalMaterialController = new EducationMaterialController();
			}
			catch (IOException)
			{
				this.showErrorDialog("通信モジュールの初期化に失敗しました");
				return false;
			}
			this._connectCheckTimer.Elapsed += delegate(object sender, ElapsedEventArgs e)
			{
				bool connected = this._connected;
				this._connected = this.isConnectUSB();
				if (!connected && this._connected)
				{
					this._isCorrectVersion = this.checkVersion();
				}
			};
			this._connectCheckTimer.Interval = 500.0;
			this._connectCheckTimer.Start();
			return true;
		}

		// Token: 0x060001FA RID: 506 RVA: 0x0001EBD4 File Offset: 0x0001CDD4
		public void terminate()
		{
			this._educationalMaterialController.Dispose();
		}

		// Token: 0x060001FB RID: 507 RVA: 0x0001EBE1 File Offset: 0x0001CDE1
		private bool isEnableId(ushort vendorId, ushort productId)
		{
			if (vendorId == 3141 && productId == 28740)
			{
				this._educationalMaterialController.VenderId = vendorId;
				this._educationalMaterialController.ProductId = productId;
				return true;
			}
			return false;
		}

		// Token: 0x060001FC RID: 508 RVA: 0x0001EC10 File Offset: 0x0001CE10
		private bool isConnectUSB()
		{
			foreach (HidInfo hidInfo in this._educationalMaterialController.EmCommunication.HidController.getHidInfo())
			{
				if (this.isEnableId(hidInfo.vendorId, hidInfo.productId))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060001FD RID: 509 RVA: 0x0001EC88 File Offset: 0x0001CE88
		private bool connect(bool error = true, CommunicationModule.VERSION_CHECK versionCheck = CommunicationModule.VERSION_CHECK.IGNORE)
		{
			if (!this.isConnectUSB())
			{
				if (error)
				{
					this.showErrorDialog("本体が接続されていません");
				}
				return false;
			}
			if (versionCheck != CommunicationModule.VERSION_CHECK.IGNORE && !this._isCorrectVersion)
			{
				if (versionCheck == CommunicationModule.VERSION_CHECK.DISPLAY)
				{
					this.showErrorDialog("コロックル本体とソフトウェアのバージョンが\n異なっています。");
				}
				return false;
			}
			try
			{
				this._educationalMaterialController.connect();
			}
			catch (IOException)
			{
				if (error)
				{
					this.showErrorDialog("本体との接続に失敗しました");
				}
				return false;
			}
			return true;
		}

		// Token: 0x060001FE RID: 510 RVA: 0x0001ED00 File Offset: 0x0001CF00
		private void disconnect()
		{
			this._educationalMaterialController.disconnect();
		}

		// Token: 0x060001FF RID: 511 RVA: 0x0001ED10 File Offset: 0x0001CF10
		public bool setTime()
		{
			DateTime now = DateTime.Now;
			return this.setTimeAndAlarm(new DateTime?(now), null);
		}

		// Token: 0x06000200 RID: 512 RVA: 0x0001ED38 File Offset: 0x0001CF38
		public bool setAlarm(int hour, int minute)
		{
			DateTime dateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hour, minute, 0);
			return this.setTimeAndAlarm(null, new DateTime?(dateTime));
		}

		// Token: 0x06000201 RID: 513 RVA: 0x0001ED8C File Offset: 0x0001CF8C
		private bool setTimeAndAlarm(DateTime? time, DateTime? alarm)
		{
			this._mutex.WaitOne();
			if (this.connect(true, CommunicationModule.VERSION_CHECK.IGNORE))
			{
				try
				{
					this._educationalMaterialController.setTimeAndAlarm(time, alarm);
				}
				catch (ArgumentException)
				{
					this.disconnect();
					this._mutex.ReleaseMutex();
					return false;
				}
				catch (IOException)
				{
					this.showErrorDialog(CommunicationModule.ERROR_COMMUNICATION);
					this.disconnect();
					this._mutex.ReleaseMutex();
					return false;
				}
				this.disconnect();
				this._mutex.ReleaseMutex();
				return true;
			}
			this._mutex.ReleaseMutex();
			return false;
		}

		// Token: 0x06000202 RID: 514 RVA: 0x0001EE34 File Offset: 0x0001D034
		public bool writeProgram(ProgramModules programs)
		{
			this._mutex.WaitOne();
			if (this.connect(true, CommunicationModule.VERSION_CHECK.DISPLAY))
			{
				byte[] array = programs.serializeBinary();
				try
				{
					this._educationalMaterialController.writeUserProgram(array);
				}
				catch (IOException)
				{
					this.showErrorDialog(CommunicationModule.ERROR_COMMUNICATION);
					this.disconnect();
					this._mutex.ReleaseMutex();
					return false;
				}
				this.disconnect();
				this._mutex.ReleaseMutex();
				return true;
			}
			this._mutex.ReleaseMutex();
			return false;
		}

		// Token: 0x06000203 RID: 515 RVA: 0x0001EEC0 File Offset: 0x0001D0C0
		public bool readProgram(ProgramModules programs, bool isIcon)
		{
			this._mutex.WaitOne();
			if (this.connect(true, CommunicationModule.VERSION_CHECK.IGNORE))
			{
				byte[] array = null;
				try
				{
					array = this._educationalMaterialController.readUserProgram();
				}
				catch (IOException)
				{
					this.showErrorDialog(CommunicationModule.ERROR_COMMUNICATION);
					this.disconnect();
					this._mutex.ReleaseMutex();
					return false;
				}
				catch (TimeoutException)
				{
					this.showErrorDialog(CommunicationModule.ERROR_TIMEOUT);
					this.disconnect();
					this._mutex.ReleaseMutex();
					return false;
				}
				ProgramModule.ERROR error = programs.deserializeBinary(array, isIcon);
				if (error != ProgramModule.ERROR.NONE)
				{
					this.showErrorDialog(ProgramModule.ERROR_ITEMS[(int)error]);
					this.disconnect();
					this._mutex.ReleaseMutex();
					return false;
				}
				this.disconnect();
				this._mutex.ReleaseMutex();
				return true;
			}
			this._mutex.ReleaseMutex();
			return false;
		}

		// Token: 0x06000204 RID: 516 RVA: 0x0001EFA4 File Offset: 0x0001D1A4
		public bool runProgram()
		{
			this._mutex.WaitOne();
			if (this.connect(true, CommunicationModule.VERSION_CHECK.IGNORE))
			{
				try
				{
					this._educationalMaterialController.startUserProgram();
				}
				catch (IOException)
				{
					this.showErrorDialog(CommunicationModule.ERROR_COMMUNICATION);
					this.disconnect();
					this._mutex.ReleaseMutex();
					return false;
				}
				this.disconnect();
				this._mutex.ReleaseMutex();
				return true;
			}
			this._mutex.ReleaseMutex();
			return false;
		}

		// Token: 0x06000205 RID: 517 RVA: 0x0001F028 File Offset: 0x0001D228
		public bool stopProgram(bool error = true)
		{
			this._mutex.WaitOne();
			if (this.connect(error, CommunicationModule.VERSION_CHECK.IGNORE))
			{
				try
				{
					this._educationalMaterialController.stopUserProgram();
				}
				catch (IOException)
				{
					if (error)
					{
						this.showErrorDialog(CommunicationModule.ERROR_COMMUNICATION);
					}
					this.disconnect();
					this._mutex.ReleaseMutex();
					return false;
				}
				this.disconnect();
				this._mutex.ReleaseMutex();
				return true;
			}
			this._mutex.ReleaseMutex();
			return false;
		}

		// Token: 0x06000206 RID: 518 RVA: 0x0001F0B0 File Offset: 0x0001D2B0
		public bool writeMelody(MelodyModule melody)
		{
			this._mutex.WaitOne();
			if (this.connect(true, CommunicationModule.VERSION_CHECK.DISPLAY))
			{
				byte[] array = melody.serializeBinary();
				try
				{
					this._educationalMaterialController.writeMusicData(array);
				}
				catch (IOException)
				{
					this.showErrorDialog(CommunicationModule.ERROR_COMMUNICATION);
					this.disconnect();
					this._mutex.ReleaseMutex();
					return false;
				}
				this.disconnect();
				this._mutex.ReleaseMutex();
				return true;
			}
			this._mutex.ReleaseMutex();
			return false;
		}

		// Token: 0x06000207 RID: 519 RVA: 0x0001F13C File Offset: 0x0001D33C
		public bool readMelody(MelodyModule melody)
		{
			this._mutex.WaitOne();
			if (this.connect(true, CommunicationModule.VERSION_CHECK.IGNORE))
			{
				byte[] array = null;
				try
				{
					array = this._educationalMaterialController.readMusicData();
				}
				catch (IOException)
				{
					this.showErrorDialog(CommunicationModule.ERROR_COMMUNICATION);
					this.disconnect();
					this._mutex.ReleaseMutex();
					return false;
				}
				catch (TimeoutException)
				{
					this.showErrorDialog(CommunicationModule.ERROR_TIMEOUT);
					this.disconnect();
					this._mutex.ReleaseMutex();
					return false;
				}
				melody.deserializeBinary(array);
				this.disconnect();
				this._mutex.ReleaseMutex();
				return true;
			}
			this._mutex.ReleaseMutex();
			return false;
		}

		// Token: 0x06000208 RID: 520 RVA: 0x0001F1F8 File Offset: 0x0001D3F8
		public bool updateFirmware(byte[] bytes)
		{
			this._mutex.WaitOne();
			if (this.connect(true, CommunicationModule.VERSION_CHECK.IGNORE))
			{
				try
				{
					this._educationalMaterialController.updateFirmware(bytes);
				}
				catch (IOException)
				{
					this.showErrorDialog(CommunicationModule.ERROR_COMMUNICATION);
					this.disconnect();
					this._mutex.ReleaseMutex();
					return false;
				}
				this.disconnect();
				this._mutex.ReleaseMutex();
				return true;
			}
			this._mutex.ReleaseMutex();
			return false;
		}

		// Token: 0x06000209 RID: 521 RVA: 0x0001F27C File Offset: 0x0001D47C
		public bool playMelody(int index, bool isLoop = false)
		{
			this._mutex.WaitOne();
			if (this.connect(true, isLoop ? CommunicationModule.VERSION_CHECK.DISPLAY : CommunicationModule.VERSION_CHECK.IGNORE))
			{
				try
				{
					if (isLoop)
					{
						byte[] array = new byte[2];
						array[0] = 40;
						this._educationalMaterialController.sendCommand(120, array);
					}
					else
					{
						byte[] array2 = new byte[] { (byte)(index + 1) };
						this._educationalMaterialController.sendCommand(115, array2);
					}
				}
				catch (IOException)
				{
					this.showErrorDialog(CommunicationModule.ERROR_COMMUNICATION);
					this.disconnect();
					this._mutex.ReleaseMutex();
					return false;
				}
				this.disconnect();
				this._mutex.ReleaseMutex();
				return true;
			}
			this._mutex.ReleaseMutex();
			return false;
		}

		// Token: 0x0600020A RID: 522 RVA: 0x0001F338 File Offset: 0x0001D538
		public bool stopMelody()
		{
			this._mutex.WaitOne();
			if (this.connect(true, CommunicationModule.VERSION_CHECK.IGNORE))
			{
				try
				{
					this._educationalMaterialController.sendCommand(116, null);
				}
				catch (IOException)
				{
					this.showErrorDialog(CommunicationModule.ERROR_COMMUNICATION);
					this.disconnect();
					this._mutex.ReleaseMutex();
					return false;
				}
				this.disconnect();
				this._mutex.ReleaseMutex();
				return true;
			}
			this._mutex.ReleaseMutex();
			return false;
		}

		// Token: 0x0600020B RID: 523 RVA: 0x0001F3C0 File Offset: 0x0001D5C0
		private void showErrorDialog(string error)
		{
			WarningDialog warningDialog = new WarningDialog();
			warningDialog.setText(error);
			warningDialog.ShowDialog();
		}

		// Token: 0x0600020C RID: 524 RVA: 0x0001F3D4 File Offset: 0x0001D5D4
		public int getLightValue()
		{
			int num = -1;
			this._mutex.WaitOne();
			if (this.connect(false, CommunicationModule.VERSION_CHECK.IGNORE))
			{
				try
				{
					num = (int)this._educationalMaterialController.sendCommand(117, null)[0];
				}
				catch (IOException)
				{
					this.disconnect();
					this._mutex.ReleaseMutex();
					return num;
				}
				catch (TimeoutException)
				{
					this.disconnect();
					this._mutex.ReleaseMutex();
					return num;
				}
				this.disconnect();
				this._mutex.ReleaseMutex();
				return num;
			}
			this._mutex.ReleaseMutex();
			return num;
		}

		// Token: 0x0600020D RID: 525 RVA: 0x0001F478 File Offset: 0x0001D678
		public int getRunningByteIndex()
		{
			int num = -1;
			this._mutex.WaitOne();
			if (this.connect(false, CommunicationModule.VERSION_CHECK.IGNORE))
			{
				try
				{
					byte[] array = this._educationalMaterialController.sendCommand(118, null);
					if (array[1] != 2 || array[2] != 0)
					{
						num = (int)array[0];
					}
				}
				catch (IOException)
				{
					this.disconnect();
					this._mutex.ReleaseMutex();
					return num;
				}
				catch (TimeoutException)
				{
					this.disconnect();
					this._mutex.ReleaseMutex();
					return num;
				}
				this.disconnect();
				this._mutex.ReleaseMutex();
				return num;
			}
			this._mutex.ReleaseMutex();
			return num;
		}

		// Token: 0x0600020E RID: 526 RVA: 0x0001F528 File Offset: 0x0001D728
		public CommunicationModule.HardwareInfo getHardwareInfo()
		{
			CommunicationModule.HardwareInfo hardwareInfo = default(CommunicationModule.HardwareInfo);
			this._mutex.WaitOne();
			if (this.connect(false, CommunicationModule.VERSION_CHECK.CHECK))
			{
				try
				{
					byte[] array = this._educationalMaterialController.sendCommand(119, null);
					hardwareInfo.IsRunning = array[0] == 1;
					hardwareInfo.IsButtonOn = array[1] == 1;
					hardwareInfo.IsBright = array[2] == 1;
					hardwareInfo.LightValue = (int)array[3];
					hardwareInfo.Temperature = (int)((sbyte)array[4]);
					hardwareInfo.IsSoundOn = array[5] == 1;
					hardwareInfo.IsUsbInOn = array[6] == 1;
				}
				catch (IOException)
				{
					this.disconnect();
					this._mutex.ReleaseMutex();
					return hardwareInfo;
				}
				catch (TimeoutException)
				{
					this.disconnect();
					this._mutex.ReleaseMutex();
					return hardwareInfo;
				}
				this.disconnect();
				this._mutex.ReleaseMutex();
				return hardwareInfo;
			}
			this._mutex.ReleaseMutex();
			return hardwareInfo;
		}

		// Token: 0x0600020F RID: 527 RVA: 0x0001F63C File Offset: 0x0001D83C
		public bool setLEDOn(Color color)
		{
			this._mutex.WaitOne();
			if (this.connect(true, CommunicationModule.VERSION_CHECK.DISPLAY))
			{
				try
				{
					byte[] array = new byte[5];
					if (color == Color.FromArgb(0, 0, 10))
					{
						array[0] = 10;
					}
					else if (color == Color.FromArgb(10, 0, 0))
					{
						array[0] = 14;
					}
					else if (color == Color.FromArgb(10, 10, 0))
					{
						array[0] = 18;
					}
					else if (color == Color.FromArgb(0, 10, 10))
					{
						array[0] = 22;
					}
					else if (color == Color.FromArgb(10, 10, 10))
					{
						array[0] = 26;
					}
					else if (color == Color.FromArgb(10, 0, 10))
					{
						array[0] = 30;
					}
					else if (color == Color.FromArgb(0, 10, 0))
					{
						array[0] = 34;
					}
					else
					{
						array[0] = 6;
						array[2] = color.R;
						array[3] = color.G;
						array[4] = color.B;
					}
					this._educationalMaterialController.sendCommand(120, array);
				}
				catch (IOException)
				{
					this.showErrorDialog(CommunicationModule.ERROR_COMMUNICATION);
					this.disconnect();
					this._mutex.ReleaseMutex();
					return false;
				}
				catch (TimeoutException)
				{
					this.showErrorDialog(CommunicationModule.ERROR_TIMEOUT);
					this.disconnect();
					this._mutex.ReleaseMutex();
					return false;
				}
				this.disconnect();
				this._mutex.ReleaseMutex();
				return true;
			}
			this._mutex.ReleaseMutex();
			return false;
		}

		// Token: 0x06000210 RID: 528 RVA: 0x0001F7D4 File Offset: 0x0001D9D4
		public bool setLEDOff()
		{
			this._mutex.WaitOne();
			if (this.connect(true, CommunicationModule.VERSION_CHECK.DISPLAY))
			{
				try
				{
					byte[] array = new byte[5];
					array[0] = 35;
					this._educationalMaterialController.sendCommand(120, array);
				}
				catch (IOException)
				{
					this.showErrorDialog(CommunicationModule.ERROR_COMMUNICATION);
					this.disconnect();
					this._mutex.ReleaseMutex();
					return false;
				}
				catch (TimeoutException)
				{
					this.showErrorDialog(CommunicationModule.ERROR_TIMEOUT);
					this.disconnect();
					this._mutex.ReleaseMutex();
					return false;
				}
				this.disconnect();
				this._mutex.ReleaseMutex();
				return true;
			}
			this._mutex.ReleaseMutex();
			return false;
		}

		// Token: 0x06000211 RID: 529 RVA: 0x0001F894 File Offset: 0x0001DA94
		public bool playSE(int index)
		{
			this._mutex.WaitOne();
			if (this.connect(true, CommunicationModule.VERSION_CHECK.DISPLAY))
			{
				try
				{
					byte[] array = new byte[2];
					array[0] = (byte)(36 + index);
					this._educationalMaterialController.sendCommand(120, array);
				}
				catch (IOException)
				{
					this.showErrorDialog(CommunicationModule.ERROR_COMMUNICATION);
					this.disconnect();
					this._mutex.ReleaseMutex();
					return false;
				}
				catch (TimeoutException)
				{
					this.showErrorDialog(CommunicationModule.ERROR_TIMEOUT);
					this.disconnect();
					this._mutex.ReleaseMutex();
					return false;
				}
				this.disconnect();
				this._mutex.ReleaseMutex();
				return true;
			}
			this._mutex.ReleaseMutex();
			return false;
		}

		// Token: 0x06000212 RID: 530 RVA: 0x0001F958 File Offset: 0x0001DB58
		public bool setUsbOutOn(int power)
		{
			this._mutex.WaitOne();
			if (this.connect(true, CommunicationModule.VERSION_CHECK.DISPLAY))
			{
				try
				{
					byte[] array = new byte[]
					{
						138,
						0,
						(byte)power
					};
					this._educationalMaterialController.sendCommand(120, array);
				}
				catch (IOException)
				{
					this.showErrorDialog(CommunicationModule.ERROR_COMMUNICATION);
					this.disconnect();
					this._mutex.ReleaseMutex();
					return false;
				}
				catch (TimeoutException)
				{
					this.showErrorDialog(CommunicationModule.ERROR_TIMEOUT);
					this.disconnect();
					this._mutex.ReleaseMutex();
					return false;
				}
				this.disconnect();
				this._mutex.ReleaseMutex();
				return true;
			}
			this._mutex.ReleaseMutex();
			return false;
		}

		// Token: 0x06000213 RID: 531 RVA: 0x0001FA20 File Offset: 0x0001DC20
		public bool setUsbOutOff()
		{
			this._mutex.WaitOne();
			if (this.connect(true, CommunicationModule.VERSION_CHECK.DISPLAY))
			{
				try
				{
					byte[] array = new byte[2];
					array[0] = 140;
					this._educationalMaterialController.sendCommand(120, array);
				}
				catch (IOException)
				{
					this.showErrorDialog(CommunicationModule.ERROR_COMMUNICATION);
					this.disconnect();
					this._mutex.ReleaseMutex();
					return false;
				}
				catch (TimeoutException)
				{
					this.showErrorDialog(CommunicationModule.ERROR_TIMEOUT);
					this.disconnect();
					this._mutex.ReleaseMutex();
					return false;
				}
				this.disconnect();
				this._mutex.ReleaseMutex();
				return true;
			}
			this._mutex.ReleaseMutex();
			return false;
		}

		// Token: 0x06000214 RID: 532 RVA: 0x0001FAE4 File Offset: 0x0001DCE4
		private string getVersionInfo()
		{
			string text = "";
			this._mutex.WaitOne();
			if (this.connect(false, CommunicationModule.VERSION_CHECK.IGNORE))
			{
				try
				{
					text = this._educationalMaterialController.sendCommand(121, null)[0].ToString();
				}
				catch (IOException)
				{
					this.showErrorDialog(CommunicationModule.ERROR_COMMUNICATION);
					this.disconnect();
					this._mutex.ReleaseMutex();
					return text;
				}
				catch (TimeoutException)
				{
					this.showErrorDialog(CommunicationModule.ERROR_TIMEOUT);
					this.disconnect();
					this._mutex.ReleaseMutex();
					return text;
				}
				this.disconnect();
				this._mutex.ReleaseMutex();
				return text;
			}
			this._mutex.ReleaseMutex();
			return text;
		}

		// Token: 0x06000215 RID: 533 RVA: 0x0001FBA8 File Offset: 0x0001DDA8
		public bool checkVersion()
		{
			if (this.isConnectUSB() && this.getVersionInfo() != VersionDialog.MajorVersion)
			{
				this.showErrorDialog("コロックル本体とソフトウェアのバージョンが\n異なっています。");
				this._isCorrectVersion = false;
				return false;
			}
			this._isCorrectVersion = true;
			return true;
		}

		// Token: 0x0400020E RID: 526
		private static readonly string ERROR_COMMUNICATION = "通信に失敗しました";

		// Token: 0x0400020F RID: 527
		private static readonly string ERROR_TIMEOUT = "タイムアウト";

		// Token: 0x04000210 RID: 528
		private static CommunicationModule _instance = new CommunicationModule();

		// Token: 0x04000211 RID: 529
		private EducationMaterialController _educationalMaterialController;

		// Token: 0x04000212 RID: 530
		private System.Timers.Timer _connectCheckTimer = new System.Timers.Timer();

		// Token: 0x04000213 RID: 531
		private bool _isCorrectVersion;

		// Token: 0x04000214 RID: 532
		private bool _connected;

		// Token: 0x04000215 RID: 533
		private Mutex _mutex = new Mutex();

		// Token: 0x0200008A RID: 138
		private enum VERSION_CHECK
		{
			// Token: 0x04000800 RID: 2048
			IGNORE,
			// Token: 0x04000801 RID: 2049
			CHECK,
			// Token: 0x04000802 RID: 2050
			DISPLAY
		}

		// Token: 0x0200008B RID: 139
		public struct HardwareInfo
		{
			// Token: 0x04000803 RID: 2051
			public bool IsRunning;

			// Token: 0x04000804 RID: 2052
			public bool IsButtonOn;

			// Token: 0x04000805 RID: 2053
			public bool IsBright;

			// Token: 0x04000806 RID: 2054
			public int LightValue;

			// Token: 0x04000807 RID: 2055
			public int Temperature;

			// Token: 0x04000808 RID: 2056
			public bool IsSoundOn;

			// Token: 0x04000809 RID: 2057
			public bool IsUsbInOn;
		}
	}
}
