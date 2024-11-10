using System;
using System.IO;
using System.Linq;

namespace EducationMaterial
{
	// Token: 0x02000004 RID: 4
	public class EducationMaterialController : IDisposable
	{
		// Token: 0x17000002 RID: 2
		// (get) Token: 0x0600000D RID: 13 RVA: 0x0000249C File Offset: 0x0000069C
		public EducationMaterialCommunication EmCommunication
		{
			get
			{
				return this.emc;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600000E RID: 14 RVA: 0x000024A4 File Offset: 0x000006A4
		// (set) Token: 0x0600000F RID: 15 RVA: 0x000024AC File Offset: 0x000006AC
		public ushort VenderId
		{
			get
			{
				return this.venderId;
			}
			set
			{
				this.venderId = value;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000010 RID: 16 RVA: 0x000024B5 File Offset: 0x000006B5
		// (set) Token: 0x06000011 RID: 17 RVA: 0x000024BD File Offset: 0x000006BD
		public ushort ProductId
		{
			get
			{
				return this.productId;
			}
			set
			{
				this.productId = value;
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000012 RID: 18 RVA: 0x000024C6 File Offset: 0x000006C6
		// (set) Token: 0x06000013 RID: 19 RVA: 0x000024CE File Offset: 0x000006CE
		public int WaitReadTimeout
		{
			get
			{
				return this.waitReadTimeout;
			}
			set
			{
				this.waitReadTimeout = value;
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000014 RID: 20 RVA: 0x000024D7 File Offset: 0x000006D7
		// (set) Token: 0x06000015 RID: 21 RVA: 0x000024DF File Offset: 0x000006DF
		public int WaitAckTimeout
		{
			get
			{
				return this.waitAckTimeout;
			}
			set
			{
				this.waitAckTimeout = value;
			}
		}

		// Token: 0x06000016 RID: 22 RVA: 0x000024E8 File Offset: 0x000006E8
		public EducationMaterialController()
		{
			this.venderId = 1240;
			this.productId = 63;
			this.waitReadTimeout = 3000;
			this.waitAckTimeout = 3000;
			this.tidCount = 1;
			this.emc = new EducationMaterialCommunication();
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00002536 File Offset: 0x00000736
		public void Dispose()
		{
			this.emc.Dispose();
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00002543 File Offset: 0x00000743
		public void connect()
		{
			this.emc.connect(this.venderId, this.productId);
		}

		// Token: 0x06000019 RID: 25 RVA: 0x0000255C File Offset: 0x0000075C
		public void disconnect()
		{
			this.emc.disconnect();
		}

		// Token: 0x0600001A RID: 26 RVA: 0x0000256C File Offset: 0x0000076C
		public void setTimeAndAlarm(DateTime? time, DateTime? alarm)
		{
			if (time == null && alarm == null)
			{
				throw new ArgumentException("Input is incorrect");
			}
			byte[] array = new byte[6];
			if (time != null)
			{
				array[0] = 1;
				array[1] = (byte)time.Value.Minute;
				array[2] = (byte)time.Value.Hour;
			}
			if (alarm != null)
			{
				array[3] = 1;
				array[4] = (byte)alarm.Value.Minute;
				array[5] = (byte)alarm.Value.Hour;
			}
			byte[] array2;
			this.sendCommandWaitAck(CommandCode.SET_TIME_AND_ALARM, array, out array2);
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00002610 File Offset: 0x00000810
		public void writeUserProgram(byte[] programData)
		{
			byte[] array = new byte[2];
			array = EducationMaterialController.ConvertShortToLittleEndianBytes((short)programData.Length);
			byte[] array2;
			this.sendCommandWaitAck(CommandCode.WRITE_USER_PROGRAM, array, out array2);
			this.emc.sendData(programData, this.waitAckTimeout);
		}

		// Token: 0x0600001C RID: 28 RVA: 0x0000264C File Offset: 0x0000084C
		public byte[] readUserProgram()
		{
			byte[] array;
			this.sendCommandWaitAck(CommandCode.READ_USER_PROGRAM, null, out array);
			byte[] array2 = new byte[2];
			Array.Copy(array, 0, array2, 0, 2);
			short num = EducationMaterialController.ConvertLittleEndianBytesToShort(array2);
			byte[] array3 = this.emc.recvData((int)num, this.waitReadTimeout);
			if (array3 == null || array3.Length == 0)
			{
				throw new IOException("Read Data feiled");
			}
			return array3;
		}

		// Token: 0x0600001D RID: 29 RVA: 0x000026A4 File Offset: 0x000008A4
		public void startUserProgram()
		{
			byte[] array;
			this.sendCommandWaitAck(CommandCode.START_USER_PROGRAM, null, out array);
		}

		// Token: 0x0600001E RID: 30 RVA: 0x000026BC File Offset: 0x000008BC
		public void stopUserProgram()
		{
			byte[] array;
			this.sendCommandWaitAck(CommandCode.STOP_USER_PROGRAM, null, out array);
		}

		// Token: 0x0600001F RID: 31 RVA: 0x000026D4 File Offset: 0x000008D4
		public void writeMusicData(byte[] musicData)
		{
			byte[] array = new byte[2];
			array = EducationMaterialController.ConvertShortToLittleEndianBytes((short)musicData.Length);
			byte[] array2;
			this.sendCommandWaitAck(CommandCode.WRITE_MUSIC_DATA, array, out array2);
			this.emc.sendData(musicData, this.waitAckTimeout);
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00002710 File Offset: 0x00000910
		public byte[] readMusicData()
		{
			byte[] array;
			this.sendCommandWaitAck(CommandCode.READ_MUSIC_DATA, null, out array);
			byte[] array2 = new byte[2];
			Array.Copy(array, 0, array2, 0, 2);
			short num = EducationMaterialController.ConvertLittleEndianBytesToShort(array2);
			byte[] array3 = this.emc.recvData((int)num, this.waitReadTimeout);
			if (array3 == null || array3.Length == 0)
			{
				throw new IOException("Read Data feiled");
			}
			return array3;
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00002768 File Offset: 0x00000968
		public void updateFirmware(byte[] firmwareData)
		{
			byte[] array = new byte[2];
			array = EducationMaterialController.ConvertShortToLittleEndianBytes((short)firmwareData.Length);
			byte[] array2;
			this.sendCommandWaitAck(CommandCode.UPDATE_FIRMWARE, array, out array2);
			this.emc.sendData(firmwareData, this.waitAckTimeout);
		}

		// Token: 0x06000022 RID: 34 RVA: 0x000027A3 File Offset: 0x000009A3
		public static byte[] ConvertShortToLittleEndianBytes(short inData)
		{
			if (BitConverter.IsLittleEndian)
			{
				return BitConverter.GetBytes(inData);
			}
			return BitConverter.GetBytes(inData).Reverse<byte>().ToArray<byte>();
		}

		// Token: 0x06000023 RID: 35 RVA: 0x000027C3 File Offset: 0x000009C3
		public static short ConvertLittleEndianBytesToShort(byte[] inData)
		{
			if (BitConverter.IsLittleEndian)
			{
				return BitConverter.ToInt16(inData, 0);
			}
			return BitConverter.ToInt16(inData.Reverse<byte>().ToArray<byte>(), 0);
		}

		// Token: 0x06000024 RID: 36 RVA: 0x000027E8 File Offset: 0x000009E8
		private byte GetNewTid()
		{
			byte b = this.tidCount;
			this.tidCount += 1;
			if (this.tidCount == 0)
			{
				this.tidCount = 1;
			}
			return b;
		}

		// Token: 0x06000025 RID: 37 RVA: 0x0000281C File Offset: 0x00000A1C
		private void sendCommandWaitAck(CommandCode commandCode, byte[] data, out byte[] ackData)
		{
			ackData = null;
			byte newTid = this.GetNewTid();
			this.emc.sendCommand(commandCode, newTid, data);
			bool flag;
			try
			{
				flag = this.emc.waitAck(newTid, out ackData, this.waitAckTimeout);
			}
			catch (TimeoutException)
			{
				flag = false;
			}
			if (!flag)
			{
				throw new IOException("Command Ack Recieve feiled");
			}
		}

		// Token: 0x06000026 RID: 38 RVA: 0x0000287C File Offset: 0x00000A7C
		public byte[] sendCommand(byte commandCode, byte[] data)
		{
			byte[] array = null;
			byte newTid = this.GetNewTid();
			this.emc.sendCommand(commandCode, newTid, data);
			bool flag;
			try
			{
				flag = this.emc.waitAck(newTid, out array, this.waitAckTimeout);
			}
			catch (TimeoutException)
			{
				flag = false;
			}
			if (!flag)
			{
				throw new IOException("Command Ack Recieve feiled");
			}
			return array;
		}

		// Token: 0x06000027 RID: 39 RVA: 0x000028DC File Offset: 0x00000ADC
		public void writeData(byte[] data)
		{
			this.emc.sendData(data, this.waitAckTimeout);
		}

		// Token: 0x06000028 RID: 40 RVA: 0x000028F0 File Offset: 0x00000AF0
		public byte[] readData(int size)
		{
			byte[] array = this.emc.recvData(size, this.waitReadTimeout);
			if (array == null || array.Length == 0)
			{
				throw new IOException("Read Data feiled");
			}
			return array;
		}

		// Token: 0x04000010 RID: 16
		private const ushort DEFAULT_VENDERID = 1240;

		// Token: 0x04000011 RID: 17
		private const ushort DEFAULT_PRODUCTID = 63;

		// Token: 0x04000012 RID: 18
		private const int DEFAULT_WAITREADTIMEOUT = 3000;

		// Token: 0x04000013 RID: 19
		private const int DEFAULT_WAITACKTIMEOUT = 3000;

		// Token: 0x04000014 RID: 20
		private EducationMaterialCommunication emc;

		// Token: 0x04000015 RID: 21
		private ushort venderId;

		// Token: 0x04000016 RID: 22
		private ushort productId;

		// Token: 0x04000017 RID: 23
		private int waitReadTimeout;

		// Token: 0x04000018 RID: 24
		private int waitAckTimeout;

		// Token: 0x04000019 RID: 25
		private byte tidCount;
	}
}
