using System;

namespace PdfSharp.SharpZipLib.Checksums
{
	// Token: 0x020001C9 RID: 457
	internal sealed class Adler32 : IChecksum
	{
		// Token: 0x1700051A RID: 1306
		// (get) Token: 0x06000F0E RID: 3854 RVA: 0x0003A426 File Offset: 0x00038626
		public long Value
		{
			get
			{
				return (long)((ulong)this.checksum);
			}
		}

		// Token: 0x06000F0F RID: 3855 RVA: 0x0003A42F File Offset: 0x0003862F
		public Adler32()
		{
			this.Reset();
		}

		// Token: 0x06000F10 RID: 3856 RVA: 0x0003A43D File Offset: 0x0003863D
		public void Reset()
		{
			this.checksum = 1U;
		}

		// Token: 0x06000F11 RID: 3857 RVA: 0x0003A448 File Offset: 0x00038648
		public void Update(int value)
		{
			uint num = this.checksum & 65535U;
			uint num2 = this.checksum >> 16;
			num = (num + (uint)(value & 255)) % 65521U;
			num2 = (num + num2) % 65521U;
			this.checksum = (num2 << 16) + num;
		}

		// Token: 0x06000F12 RID: 3858 RVA: 0x0003A492 File Offset: 0x00038692
		public void Update(byte[] buffer)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			this.Update(buffer, 0, buffer.Length);
		}

		// Token: 0x06000F13 RID: 3859 RVA: 0x0003A4B0 File Offset: 0x000386B0
		public void Update(byte[] buffer, int offset, int count)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			if (offset < 0)
			{
				throw new ArgumentOutOfRangeException("offset", "cannot be negative");
			}
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count", "cannot be negative");
			}
			if (offset >= buffer.Length)
			{
				throw new ArgumentOutOfRangeException("offset", "not a valid index into buffer");
			}
			if (offset + count > buffer.Length)
			{
				throw new ArgumentOutOfRangeException("count", "exceeds buffer size");
			}
			uint num = this.checksum & 65535U;
			uint num2 = this.checksum >> 16;
			while (count > 0)
			{
				int num3 = 3800;
				if (num3 > count)
				{
					num3 = count;
				}
				count -= num3;
				while (--num3 >= 0)
				{
					num += (uint)(buffer[offset++] & byte.MaxValue);
					num2 += num;
				}
				num %= 65521U;
				num2 %= 65521U;
			}
			this.checksum = (num2 << 16) | num;
		}

		// Token: 0x0400096E RID: 2414
		private const uint BASE = 65521U;

		// Token: 0x0400096F RID: 2415
		private uint checksum;
	}
}
