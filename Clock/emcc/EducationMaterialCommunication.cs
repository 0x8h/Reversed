using System;
using System.Diagnostics;
using System.IO;

namespace EducationMaterial
{
	// Token: 0x02000003 RID: 3
	public class EducationMaterialCommunication : IDisposable
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public HidController HidController
		{
			get
			{
				return this.hidcon;
			}
		}

		// Token: 0x06000002 RID: 2 RVA: 0x00002058 File Offset: 0x00000258
		public EducationMaterialCommunication()
		{
			this.hidcon = new HidController();
			this.hid = null;
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00002072 File Offset: 0x00000272
		public void Dispose()
		{
			this.disconnect();
			this.hidcon.Dispose();
		}

		// Token: 0x06000004 RID: 4 RVA: 0x00002085 File Offset: 0x00000285
		public void connect(ushort venderid, ushort productid)
		{
			if (this.hid == null)
			{
				this.hid = this.hidcon.connectHid(venderid, productid, null);
				if (this.hid == null)
				{
					throw new IOException("HID connect feiled");
				}
			}
		}

		// Token: 0x06000005 RID: 5 RVA: 0x000020B6 File Offset: 0x000002B6
		public void disconnect()
		{
			if (this.hid != null)
			{
				this.hid.Dispose();
				this.hid = null;
			}
		}

		// Token: 0x06000006 RID: 6 RVA: 0x000020D2 File Offset: 0x000002D2
		public void sendCommand(CommandCode commandCode, byte tid, byte[] data)
		{
			this.sendCommand((byte)commandCode, tid, data);
		}

		// Token: 0x06000007 RID: 7 RVA: 0x000020E0 File Offset: 0x000002E0
		public void sendCommand(byte commandCode, byte tid, byte[] data)
		{
			if (this.hid == null)
			{
				throw new InvalidOperationException("USB unconnect");
			}
			byte[] array = new byte[65];
			array[0] = 0;
			array[1] = commandCode;
			array[2] = tid;
			if (data != null && data.Length != 0)
			{
				if (data.Length > 62)
				{
					throw new ArgumentException("data length too long");
				}
				Array.Copy(data, 0, array, 3, data.Length);
			}
			int num = this.hid.writeData(array, array.Length);
			if (num < 0)
			{
				throw new IOException("send command feiled");
			}
		}

		// Token: 0x06000008 RID: 8 RVA: 0x0000215C File Offset: 0x0000035C
		public void sendData(byte[] data, int waitAckTimeout)
		{
			if (this.hid == null)
			{
				throw new InvalidOperationException("USB unconnect");
			}
			byte[] array = new byte[65];
			array[0] = 0;
			array[1] = 208;
			int i = 0;
			int num = 0;
			while (i < data.Length)
			{
				int num2 = data.Length - i;
				byte b;
				if (num2 <= 62)
				{
					b = (byte)num2;
					array[2] = 128 | b;
				}
				else
				{
					b = 62;
					array[2] = b;
				}
				Array.Copy(data, i, array, 3, (int)b);
				for (int j = (int)(b + 3); j < 65; j++)
				{
					array[j] = 0;
				}
				int num3 = this.hid.writeData(array, array.Length);
				if (num3 < 0)
				{
					throw new IOException("send command feiled");
				}
				i += (int)b;
				num++;
				if (num % 10 != 0)
				{
					if (i < data.Length)
					{
						continue;
					}
				}
				bool flag;
				try
				{
					byte[] array2;
					flag = this.waitAck(0, out array2, waitAckTimeout);
				}
				catch (TimeoutException)
				{
					flag = false;
				}
				if (!flag)
				{
					throw new IOException("Data Ack Recieve feiled");
				}
			}
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00002254 File Offset: 0x00000454
		public byte[] recvData(int size, int timeout)
		{
			if (this.hid == null)
			{
				throw new InvalidOperationException("USB unconnect");
			}
			byte[] array = new byte[size];
			int num = 0;
			bool flag = false;
			byte[] array2 = new byte[65];
			Stopwatch stopwatch = new Stopwatch();
			IL_FC:
			while (num <= size && !flag)
			{
				stopwatch.Reset();
				int i = timeout;
				while (i > 0)
				{
					stopwatch.Start();
					int num2 = this.hid.readDataTimeout(array2, array2.Length, i);
					stopwatch.Stop();
					if (num2 > 0)
					{
						int num3 = ((num2 == 65) ? 1 : 0);
						int num4 = (int)stopwatch.ElapsedMilliseconds;
						i = timeout - num4;
						if (i < 0)
						{
							i = 0;
						}
						if (array2[num3] == 208)
						{
							byte b = array2[num3 + 1];
							if ((b & 128) != 0)
							{
								flag = true;
							}
							byte b2 = b & 127;
							if (b2 > 0 && size - num >= (int)b2)
							{
								Array.Copy(array2, num3 + 2, array, num, (int)b2);
							}
							num += (int)b2;
							goto IL_FC;
						}
					}
					else
					{
						if (num2 != 0)
						{
							throw new IOException("Data Recieve feiled");
						}
						i = 0;
					}
				}
				throw new TimeoutException("Time out error");
			}
			if (!flag)
			{
				this.sendNack(0);
				return null;
			}
			if (num != size)
			{
				this.sendNack(0);
				return null;
			}
			this.sendAck(0);
			return array;
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00002388 File Offset: 0x00000588
		public bool waitAck(byte tid, out byte[] data, int timeout)
		{
			if (this.hid == null)
			{
				throw new InvalidOperationException("USB unconnect");
			}
			bool flag = false;
			byte[] array = new byte[65];
			data = null;
			int i = timeout;
			Stopwatch stopwatch = new Stopwatch();
			while (i > 0)
			{
				stopwatch.Start();
				int num = this.hid.readDataTimeout(array, array.Length, i);
				stopwatch.Stop();
				if (num > 0)
				{
					int num2 = ((num == 65) ? 1 : 0);
					int num3 = (int)stopwatch.ElapsedMilliseconds;
					i = timeout - num3;
					if (i < 0)
					{
						i = 0;
					}
					if ((array[num2] == 240 || array[num2] == 224) && array[num2 + 1] == tid)
					{
						if (array[num2] != 224)
						{
							if (array[num2] != 240)
							{
								continue;
							}
							flag = true;
							data = new byte[62];
							Array.Copy(array, num2 + 2, data, 0, data.Length);
						}
						return flag;
					}
				}
				else
				{
					if (num != 0)
					{
						throw new IOException("Ack Recieve feiled");
					}
					i = 0;
				}
			}
			throw new TimeoutException("Time out error");
		}

		// Token: 0x0600000B RID: 11 RVA: 0x0000247E File Offset: 0x0000067E
		public void sendAck(byte tid)
		{
			this.sendCommand(CommandCode.ACK_CODE, tid, null);
		}

		// Token: 0x0600000C RID: 12 RVA: 0x0000248D File Offset: 0x0000068D
		public void sendNack(byte tid)
		{
			this.sendCommand(CommandCode.NACK_CODE, tid, null);
		}

		// Token: 0x0400000D RID: 13
		private const int FRAME_SIZE = 64;

		// Token: 0x0400000E RID: 14
		private HidCommunication hid;

		// Token: 0x0400000F RID: 15
		private HidController hidcon;
	}
}
