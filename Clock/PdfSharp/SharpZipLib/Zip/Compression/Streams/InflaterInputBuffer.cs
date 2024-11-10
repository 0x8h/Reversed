using System;
using System.IO;

namespace PdfSharp.SharpZipLib.Zip.Compression.Streams
{
	// Token: 0x020001D8 RID: 472
	internal class InflaterInputBuffer
	{
		// Token: 0x06000FB0 RID: 4016 RVA: 0x0003E94F File Offset: 0x0003CB4F
		public InflaterInputBuffer(Stream stream)
			: this(stream, 4096)
		{
		}

		// Token: 0x06000FB1 RID: 4017 RVA: 0x0003E95D File Offset: 0x0003CB5D
		public InflaterInputBuffer(Stream stream, int bufferSize)
		{
			this.inputStream = stream;
			if (bufferSize < 1024)
			{
				bufferSize = 1024;
			}
			this.rawData = new byte[bufferSize];
			this.clearText = this.rawData;
		}

		// Token: 0x17000536 RID: 1334
		// (get) Token: 0x06000FB2 RID: 4018 RVA: 0x0003E993 File Offset: 0x0003CB93
		public int RawLength
		{
			get
			{
				return this.rawLength;
			}
		}

		// Token: 0x17000537 RID: 1335
		// (get) Token: 0x06000FB3 RID: 4019 RVA: 0x0003E99B File Offset: 0x0003CB9B
		public byte[] RawData
		{
			get
			{
				return this.rawData;
			}
		}

		// Token: 0x17000538 RID: 1336
		// (get) Token: 0x06000FB4 RID: 4020 RVA: 0x0003E9A3 File Offset: 0x0003CBA3
		public int ClearTextLength
		{
			get
			{
				return this.clearTextLength;
			}
		}

		// Token: 0x17000539 RID: 1337
		// (get) Token: 0x06000FB5 RID: 4021 RVA: 0x0003E9AB File Offset: 0x0003CBAB
		public byte[] ClearText
		{
			get
			{
				return this.clearText;
			}
		}

		// Token: 0x1700053A RID: 1338
		// (get) Token: 0x06000FB6 RID: 4022 RVA: 0x0003E9B3 File Offset: 0x0003CBB3
		// (set) Token: 0x06000FB7 RID: 4023 RVA: 0x0003E9BB File Offset: 0x0003CBBB
		public int Available
		{
			get
			{
				return this.available;
			}
			set
			{
				this.available = value;
			}
		}

		// Token: 0x06000FB8 RID: 4024 RVA: 0x0003E9C4 File Offset: 0x0003CBC4
		public void SetInflaterInput(Inflater inflater)
		{
			if (this.available > 0)
			{
				inflater.SetInput(this.clearText, this.clearTextLength - this.available, this.available);
				this.available = 0;
			}
		}

		// Token: 0x06000FB9 RID: 4025 RVA: 0x0003E9F8 File Offset: 0x0003CBF8
		public void Fill()
		{
			this.rawLength = 0;
			int num;
			for (int i = this.rawData.Length; i > 0; i -= num)
			{
				num = this.inputStream.Read(this.rawData, this.rawLength, i);
				if (num <= 0)
				{
					break;
				}
				this.rawLength += num;
			}
			this.clearTextLength = this.rawLength;
			this.available = this.clearTextLength;
		}

		// Token: 0x06000FBA RID: 4026 RVA: 0x0003EA62 File Offset: 0x0003CC62
		public int ReadRawBuffer(byte[] buffer)
		{
			return this.ReadRawBuffer(buffer, 0, buffer.Length);
		}

		// Token: 0x06000FBB RID: 4027 RVA: 0x0003EA70 File Offset: 0x0003CC70
		public int ReadRawBuffer(byte[] outBuffer, int offset, int length)
		{
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			int num = offset;
			int i = length;
			while (i > 0)
			{
				if (this.available <= 0)
				{
					this.Fill();
					if (this.available <= 0)
					{
						return 0;
					}
				}
				int num2 = Math.Min(i, this.available);
				Array.Copy(this.rawData, this.rawLength - this.available, outBuffer, num, num2);
				num += num2;
				i -= num2;
				this.available -= num2;
			}
			return length;
		}

		// Token: 0x06000FBC RID: 4028 RVA: 0x0003EAF0 File Offset: 0x0003CCF0
		public int ReadClearTextBuffer(byte[] outBuffer, int offset, int length)
		{
			if (length < 0)
			{
				throw new ArgumentOutOfRangeException("length");
			}
			int num = offset;
			int i = length;
			while (i > 0)
			{
				if (this.available <= 0)
				{
					this.Fill();
					if (this.available <= 0)
					{
						return 0;
					}
				}
				int num2 = Math.Min(i, this.available);
				Array.Copy(this.clearText, this.clearTextLength - this.available, outBuffer, num, num2);
				num += num2;
				i -= num2;
				this.available -= num2;
			}
			return length;
		}

		// Token: 0x06000FBD RID: 4029 RVA: 0x0003EB70 File Offset: 0x0003CD70
		public int ReadLeByte()
		{
			if (this.available <= 0)
			{
				this.Fill();
				if (this.available <= 0)
				{
					throw new ZipException("EOF in header");
				}
			}
			byte b = this.rawData[this.rawLength - this.available];
			this.available--;
			return (int)b;
		}

		// Token: 0x06000FBE RID: 4030 RVA: 0x0003EBC4 File Offset: 0x0003CDC4
		public int ReadLeShort()
		{
			return this.ReadLeByte() | (this.ReadLeByte() << 8);
		}

		// Token: 0x06000FBF RID: 4031 RVA: 0x0003EBD5 File Offset: 0x0003CDD5
		public int ReadLeInt()
		{
			return this.ReadLeShort() | (this.ReadLeShort() << 16);
		}

		// Token: 0x06000FC0 RID: 4032 RVA: 0x0003EBE7 File Offset: 0x0003CDE7
		public long ReadLeLong()
		{
			return (long)((ulong)this.ReadLeInt() | (ulong)((ulong)((long)this.ReadLeInt()) << 32));
		}

		// Token: 0x04000A21 RID: 2593
		private int rawLength;

		// Token: 0x04000A22 RID: 2594
		private byte[] rawData;

		// Token: 0x04000A23 RID: 2595
		private int clearTextLength;

		// Token: 0x04000A24 RID: 2596
		private byte[] clearText;

		// Token: 0x04000A25 RID: 2597
		private int available;

		// Token: 0x04000A26 RID: 2598
		private Stream inputStream;
	}
}
