using System;
using System.IO;

namespace PdfSharp.SharpZipLib.Zip.Compression.Streams
{
	// Token: 0x020001D9 RID: 473
	internal class InflaterInputStream : Stream
	{
		// Token: 0x06000FC1 RID: 4033 RVA: 0x0003EBFB File Offset: 0x0003CDFB
		public InflaterInputStream(Stream baseInputStream)
			: this(baseInputStream, new Inflater(), 4096)
		{
		}

		// Token: 0x06000FC2 RID: 4034 RVA: 0x0003EC0E File Offset: 0x0003CE0E
		public InflaterInputStream(Stream baseInputStream, Inflater inf)
			: this(baseInputStream, inf, 4096)
		{
		}

		// Token: 0x06000FC3 RID: 4035 RVA: 0x0003EC20 File Offset: 0x0003CE20
		public InflaterInputStream(Stream baseInputStream, Inflater inflater, int bufferSize)
		{
			if (baseInputStream == null)
			{
				throw new ArgumentNullException("baseInputStream");
			}
			if (inflater == null)
			{
				throw new ArgumentNullException("inflater");
			}
			if (bufferSize <= 0)
			{
				throw new ArgumentOutOfRangeException("bufferSize");
			}
			this.baseInputStream = baseInputStream;
			this.inf = inflater;
			this.inputBuffer = new InflaterInputBuffer(baseInputStream, bufferSize);
		}

		// Token: 0x1700053B RID: 1339
		// (get) Token: 0x06000FC4 RID: 4036 RVA: 0x0003EC80 File Offset: 0x0003CE80
		// (set) Token: 0x06000FC5 RID: 4037 RVA: 0x0003EC88 File Offset: 0x0003CE88
		public bool IsStreamOwner
		{
			get
			{
				return this.isStreamOwner;
			}
			set
			{
				this.isStreamOwner = value;
			}
		}

		// Token: 0x06000FC6 RID: 4038 RVA: 0x0003EC94 File Offset: 0x0003CE94
		public long Skip(long count)
		{
			if (count <= 0L)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			if (this.baseInputStream.CanSeek)
			{
				this.baseInputStream.Seek(count, SeekOrigin.Current);
				return count;
			}
			int num = 2048;
			if (count < (long)num)
			{
				num = (int)count;
			}
			byte[] array = new byte[num];
			int num2 = 1;
			long num3 = count;
			while (num3 > 0L && num2 > 0)
			{
				if (num3 < (long)num)
				{
					num = (int)num3;
				}
				num2 = this.baseInputStream.Read(array, 0, num);
				num3 -= (long)num2;
			}
			return count - num3;
		}

		// Token: 0x06000FC7 RID: 4039 RVA: 0x0003ED11 File Offset: 0x0003CF11
		protected void StopDecrypting()
		{
		}

		// Token: 0x1700053C RID: 1340
		// (get) Token: 0x06000FC8 RID: 4040 RVA: 0x0003ED13 File Offset: 0x0003CF13
		public virtual int Available
		{
			get
			{
				if (!this.inf.IsFinished)
				{
					return 1;
				}
				return 0;
			}
		}

		// Token: 0x06000FC9 RID: 4041 RVA: 0x0003ED28 File Offset: 0x0003CF28
		protected void Fill()
		{
			if (this.inputBuffer.Available <= 0)
			{
				this.inputBuffer.Fill();
				if (this.inputBuffer.Available <= 0)
				{
					throw new SharpZipBaseException("Unexpected EOF");
				}
			}
			this.inputBuffer.SetInflaterInput(this.inf);
		}

		// Token: 0x1700053D RID: 1341
		// (get) Token: 0x06000FCA RID: 4042 RVA: 0x0003ED78 File Offset: 0x0003CF78
		public override bool CanRead
		{
			get
			{
				return this.baseInputStream.CanRead;
			}
		}

		// Token: 0x1700053E RID: 1342
		// (get) Token: 0x06000FCB RID: 4043 RVA: 0x0003ED85 File Offset: 0x0003CF85
		public override bool CanSeek
		{
			get
			{
				return false;
			}
		}

		// Token: 0x1700053F RID: 1343
		// (get) Token: 0x06000FCC RID: 4044 RVA: 0x0003ED88 File Offset: 0x0003CF88
		public override bool CanWrite
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000540 RID: 1344
		// (get) Token: 0x06000FCD RID: 4045 RVA: 0x0003ED8B File Offset: 0x0003CF8B
		public override long Length
		{
			get
			{
				return (long)this.inputBuffer.RawLength;
			}
		}

		// Token: 0x17000541 RID: 1345
		// (get) Token: 0x06000FCE RID: 4046 RVA: 0x0003ED99 File Offset: 0x0003CF99
		// (set) Token: 0x06000FCF RID: 4047 RVA: 0x0003EDA6 File Offset: 0x0003CFA6
		public override long Position
		{
			get
			{
				return this.baseInputStream.Position;
			}
			set
			{
				throw new NotSupportedException("InflaterInputStream Position not supported");
			}
		}

		// Token: 0x06000FD0 RID: 4048 RVA: 0x0003EDB2 File Offset: 0x0003CFB2
		public override void Flush()
		{
			this.baseInputStream.Flush();
		}

		// Token: 0x06000FD1 RID: 4049 RVA: 0x0003EDBF File Offset: 0x0003CFBF
		public override long Seek(long offset, SeekOrigin origin)
		{
			throw new NotSupportedException("Seek not supported");
		}

		// Token: 0x06000FD2 RID: 4050 RVA: 0x0003EDCB File Offset: 0x0003CFCB
		public override void SetLength(long value)
		{
			throw new NotSupportedException("InflaterInputStream SetLength not supported");
		}

		// Token: 0x06000FD3 RID: 4051 RVA: 0x0003EDD7 File Offset: 0x0003CFD7
		public override void Write(byte[] buffer, int offset, int count)
		{
			throw new NotSupportedException("InflaterInputStream Write not supported");
		}

		// Token: 0x06000FD4 RID: 4052 RVA: 0x0003EDE3 File Offset: 0x0003CFE3
		public override void WriteByte(byte value)
		{
			throw new NotSupportedException("InflaterInputStream WriteByte not supported");
		}

		// Token: 0x06000FD5 RID: 4053 RVA: 0x0003EDEF File Offset: 0x0003CFEF
		public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
		{
			throw new NotSupportedException("InflaterInputStream BeginWrite not supported");
		}

		// Token: 0x06000FD6 RID: 4054 RVA: 0x0003EDFB File Offset: 0x0003CFFB
		public override void Close()
		{
			if (!this.isClosed)
			{
				this.isClosed = true;
				if (this.isStreamOwner)
				{
					this.baseInputStream.Close();
				}
			}
		}

		// Token: 0x06000FD7 RID: 4055 RVA: 0x0003EE20 File Offset: 0x0003D020
		public override int Read(byte[] buffer, int offset, int count)
		{
			if (this.inf.IsNeedingDictionary)
			{
				throw new SharpZipBaseException("Need a dictionary");
			}
			int num = count;
			for (;;)
			{
				int num2 = this.inf.Inflate(buffer, offset, num);
				offset += num2;
				num -= num2;
				if (num == 0 || this.inf.IsFinished)
				{
					goto IL_65;
				}
				if (this.inf.IsNeedingInput)
				{
					this.Fill();
				}
				else if (num2 == 0)
				{
					break;
				}
			}
			throw new ZipException("Dont know what to do");
			IL_65:
			return count - num;
		}

		// Token: 0x04000A27 RID: 2599
		protected Inflater inf;

		// Token: 0x04000A28 RID: 2600
		protected InflaterInputBuffer inputBuffer;

		// Token: 0x04000A29 RID: 2601
		private Stream baseInputStream;

		// Token: 0x04000A2A RID: 2602
		private bool isClosed;

		// Token: 0x04000A2B RID: 2603
		private bool isStreamOwner = true;
	}
}
