using System;

namespace PdfSharp.SharpZipLib.Zip.Compression.Streams
{
	// Token: 0x020001DA RID: 474
	internal class OutputWindow
	{
		// Token: 0x06000FD8 RID: 4056 RVA: 0x0003EE98 File Offset: 0x0003D098
		public void Write(int value)
		{
			if (this.windowFilled++ == 32768)
			{
				throw new InvalidOperationException("Window full");
			}
			this.window[this.windowEnd++] = (byte)value;
			this.windowEnd &= 32767;
		}

		// Token: 0x06000FD9 RID: 4057 RVA: 0x0003EEF4 File Offset: 0x0003D0F4
		private void SlowRepeat(int repStart, int length, int distance)
		{
			while (length-- > 0)
			{
				this.window[this.windowEnd++] = this.window[repStart++];
				this.windowEnd &= 32767;
				repStart &= 32767;
			}
		}

		// Token: 0x06000FDA RID: 4058 RVA: 0x0003EF4C File Offset: 0x0003D14C
		public void Repeat(int length, int distance)
		{
			if ((this.windowFilled += length) > 32768)
			{
				throw new InvalidOperationException("Window full");
			}
			int num = (this.windowEnd - distance) & 32767;
			int num2 = 32768 - length;
			if (num > num2 || this.windowEnd >= num2)
			{
				this.SlowRepeat(num, length, distance);
				return;
			}
			if (length <= distance)
			{
				Array.Copy(this.window, num, this.window, this.windowEnd, length);
				this.windowEnd += length;
				return;
			}
			while (length-- > 0)
			{
				this.window[this.windowEnd++] = this.window[num++];
			}
		}

		// Token: 0x06000FDB RID: 4059 RVA: 0x0003F004 File Offset: 0x0003D204
		public int CopyStored(StreamManipulator input, int length)
		{
			length = Math.Min(Math.Min(length, 32768 - this.windowFilled), input.AvailableBytes);
			int num = 32768 - this.windowEnd;
			int num2;
			if (length > num)
			{
				num2 = input.CopyBytes(this.window, this.windowEnd, num);
				if (num2 == num)
				{
					num2 += input.CopyBytes(this.window, 0, length - num);
				}
			}
			else
			{
				num2 = input.CopyBytes(this.window, this.windowEnd, length);
			}
			this.windowEnd = (this.windowEnd + num2) & 32767;
			this.windowFilled += num2;
			return num2;
		}

		// Token: 0x06000FDC RID: 4060 RVA: 0x0003F0A8 File Offset: 0x0003D2A8
		public void CopyDict(byte[] dictionary, int offset, int length)
		{
			if (dictionary == null)
			{
				throw new ArgumentNullException("dictionary");
			}
			if (this.windowFilled > 0)
			{
				throw new InvalidOperationException();
			}
			if (length > 32768)
			{
				offset += length - 32768;
				length = 32768;
			}
			Array.Copy(dictionary, offset, this.window, 0, length);
			this.windowEnd = length & 32767;
		}

		// Token: 0x06000FDD RID: 4061 RVA: 0x0003F108 File Offset: 0x0003D308
		public int GetFreeSpace()
		{
			return 32768 - this.windowFilled;
		}

		// Token: 0x06000FDE RID: 4062 RVA: 0x0003F116 File Offset: 0x0003D316
		public int GetAvailable()
		{
			return this.windowFilled;
		}

		// Token: 0x06000FDF RID: 4063 RVA: 0x0003F120 File Offset: 0x0003D320
		public int CopyOutput(byte[] output, int offset, int len)
		{
			int num = this.windowEnd;
			if (len > this.windowFilled)
			{
				len = this.windowFilled;
			}
			else
			{
				num = (this.windowEnd - this.windowFilled + len) & 32767;
			}
			int num2 = len;
			int num3 = len - num;
			if (num3 > 0)
			{
				Array.Copy(this.window, 32768 - num3, output, offset, num3);
				offset += num3;
				len = num;
			}
			Array.Copy(this.window, num - len, output, offset, len);
			this.windowFilled -= num2;
			if (this.windowFilled < 0)
			{
				throw new InvalidOperationException();
			}
			return num2;
		}

		// Token: 0x06000FE0 RID: 4064 RVA: 0x0003F1B4 File Offset: 0x0003D3B4
		public void Reset()
		{
			this.windowFilled = (this.windowEnd = 0);
		}

		// Token: 0x04000A2C RID: 2604
		private const int WindowSize = 32768;

		// Token: 0x04000A2D RID: 2605
		private const int WindowMask = 32767;

		// Token: 0x04000A2E RID: 2606
		private byte[] window = new byte[32768];

		// Token: 0x04000A2F RID: 2607
		private int windowEnd;

		// Token: 0x04000A30 RID: 2608
		private int windowFilled;
	}
}
