using System;
using System.IO;
using PdfSharp.SharpZipLib.Checksums;

namespace PdfSharp.SharpZipLib.Zip.Compression.Streams
{
	// Token: 0x020001D7 RID: 471
	internal class DeflaterOutputStream : Stream
	{
		// Token: 0x06000F91 RID: 3985 RVA: 0x0003E4F6 File Offset: 0x0003C6F6
		public DeflaterOutputStream(Stream baseOutputStream)
			: this(baseOutputStream, new Deflater(), 512)
		{
		}

		// Token: 0x06000F92 RID: 3986 RVA: 0x0003E509 File Offset: 0x0003C709
		public DeflaterOutputStream(Stream baseOutputStream, Deflater deflater)
			: this(baseOutputStream, deflater, 512)
		{
		}

		// Token: 0x06000F93 RID: 3987 RVA: 0x0003E518 File Offset: 0x0003C718
		public DeflaterOutputStream(Stream baseOutputStream, Deflater deflater, int bufferSize)
		{
			if (baseOutputStream == null)
			{
				throw new ArgumentNullException("baseOutputStream");
			}
			if (!baseOutputStream.CanWrite)
			{
				throw new ArgumentException("Must support writing", "baseOutputStream");
			}
			if (deflater == null)
			{
				throw new ArgumentNullException("deflater");
			}
			if (bufferSize < 512)
			{
				throw new ArgumentOutOfRangeException("bufferSize");
			}
			this.baseOutputStream_ = baseOutputStream;
			this.buffer_ = new byte[bufferSize];
			this.deflater_ = deflater;
		}

		// Token: 0x06000F94 RID: 3988 RVA: 0x0003E594 File Offset: 0x0003C794
		public virtual void Finish()
		{
			this.deflater_.Finish();
			while (!this.deflater_.IsFinished)
			{
				int num = this.deflater_.Deflate(this.buffer_, 0, this.buffer_.Length);
				if (num <= 0)
				{
					break;
				}
				if (this.keys != null)
				{
					this.EncryptBlock(this.buffer_, 0, num);
				}
				this.baseOutputStream_.Write(this.buffer_, 0, num);
			}
			if (!this.deflater_.IsFinished)
			{
				throw new SharpZipBaseException("Can't deflate all input?");
			}
			this.baseOutputStream_.Flush();
			if (this.keys != null)
			{
				this.keys = null;
			}
		}

		// Token: 0x1700052E RID: 1326
		// (get) Token: 0x06000F95 RID: 3989 RVA: 0x0003E635 File Offset: 0x0003C835
		// (set) Token: 0x06000F96 RID: 3990 RVA: 0x0003E63D File Offset: 0x0003C83D
		public bool IsStreamOwner
		{
			get
			{
				return this.isStreamOwner_;
			}
			set
			{
				this.isStreamOwner_ = value;
			}
		}

		// Token: 0x1700052F RID: 1327
		// (get) Token: 0x06000F97 RID: 3991 RVA: 0x0003E646 File Offset: 0x0003C846
		public bool CanPatchEntries
		{
			get
			{
				return this.baseOutputStream_.CanSeek;
			}
		}

		// Token: 0x17000530 RID: 1328
		// (get) Token: 0x06000F98 RID: 3992 RVA: 0x0003E653 File Offset: 0x0003C853
		// (set) Token: 0x06000F99 RID: 3993 RVA: 0x0003E65B File Offset: 0x0003C85B
		public string Password
		{
			get
			{
				return this.password;
			}
			set
			{
				if (value != null && value.Length == 0)
				{
					this.password = null;
					return;
				}
				this.password = value;
			}
		}

		// Token: 0x06000F9A RID: 3994 RVA: 0x0003E678 File Offset: 0x0003C878
		protected void EncryptBlock(byte[] buffer, int offset, int length)
		{
			for (int i = offset; i < offset + length; i++)
			{
				byte b = buffer[i];
				int num = i;
				buffer[num] ^= this.EncryptByte();
				this.UpdateKeys(b);
			}
		}

		// Token: 0x06000F9B RID: 3995 RVA: 0x0003E6C4 File Offset: 0x0003C8C4
		protected void InitializePassword(string password)
		{
			this.keys = new uint[] { 305419896U, 591751049U, 878082192U };
			byte[] array = ZipConstants.ConvertToArray(password);
			for (int i = 0; i < array.Length; i++)
			{
				this.UpdateKeys(array[i]);
			}
		}

		// Token: 0x06000F9C RID: 3996 RVA: 0x0003E708 File Offset: 0x0003C908
		protected byte EncryptByte()
		{
			uint num = (this.keys[2] & 65535U) | 2U;
			return (byte)(num * (num ^ 1U) >> 8);
		}

		// Token: 0x06000F9D RID: 3997 RVA: 0x0003E730 File Offset: 0x0003C930
		protected void UpdateKeys(byte ch)
		{
			this.keys[0] = Crc32.ComputeCrc32(this.keys[0], ch);
			this.keys[1] = this.keys[1] + (uint)((byte)this.keys[0]);
			this.keys[1] = this.keys[1] * 134775813U + 1U;
			this.keys[2] = Crc32.ComputeCrc32(this.keys[2], (byte)(this.keys[1] >> 24));
		}

		// Token: 0x06000F9E RID: 3998 RVA: 0x0003E7A8 File Offset: 0x0003C9A8
		protected void Deflate()
		{
			while (!this.deflater_.IsNeedingInput)
			{
				int num = this.deflater_.Deflate(this.buffer_, 0, this.buffer_.Length);
				if (num <= 0)
				{
					break;
				}
				if (this.keys != null)
				{
					this.EncryptBlock(this.buffer_, 0, num);
				}
				this.baseOutputStream_.Write(this.buffer_, 0, num);
			}
			if (!this.deflater_.IsNeedingInput)
			{
				throw new SharpZipBaseException("DeflaterOutputStream can't deflate all input?");
			}
		}

		// Token: 0x17000531 RID: 1329
		// (get) Token: 0x06000F9F RID: 3999 RVA: 0x0003E824 File Offset: 0x0003CA24
		public override bool CanRead
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000532 RID: 1330
		// (get) Token: 0x06000FA0 RID: 4000 RVA: 0x0003E827 File Offset: 0x0003CA27
		public override bool CanSeek
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000533 RID: 1331
		// (get) Token: 0x06000FA1 RID: 4001 RVA: 0x0003E82A File Offset: 0x0003CA2A
		public override bool CanWrite
		{
			get
			{
				return this.baseOutputStream_.CanWrite;
			}
		}

		// Token: 0x17000534 RID: 1332
		// (get) Token: 0x06000FA2 RID: 4002 RVA: 0x0003E837 File Offset: 0x0003CA37
		public override long Length
		{
			get
			{
				return this.baseOutputStream_.Length;
			}
		}

		// Token: 0x17000535 RID: 1333
		// (get) Token: 0x06000FA3 RID: 4003 RVA: 0x0003E844 File Offset: 0x0003CA44
		// (set) Token: 0x06000FA4 RID: 4004 RVA: 0x0003E851 File Offset: 0x0003CA51
		public override long Position
		{
			get
			{
				return this.baseOutputStream_.Position;
			}
			set
			{
				throw new NotSupportedException("Position property not supported");
			}
		}

		// Token: 0x06000FA5 RID: 4005 RVA: 0x0003E85D File Offset: 0x0003CA5D
		public override long Seek(long offset, SeekOrigin origin)
		{
			throw new NotSupportedException("DeflaterOutputStream Seek not supported");
		}

		// Token: 0x06000FA6 RID: 4006 RVA: 0x0003E869 File Offset: 0x0003CA69
		public override void SetLength(long value)
		{
			throw new NotSupportedException("DeflaterOutputStream SetLength not supported");
		}

		// Token: 0x06000FA7 RID: 4007 RVA: 0x0003E875 File Offset: 0x0003CA75
		public override int ReadByte()
		{
			throw new NotSupportedException("DeflaterOutputStream ReadByte not supported");
		}

		// Token: 0x06000FA8 RID: 4008 RVA: 0x0003E881 File Offset: 0x0003CA81
		public override int Read(byte[] buffer, int offset, int count)
		{
			throw new NotSupportedException("DeflaterOutputStream Read not supported");
		}

		// Token: 0x06000FA9 RID: 4009 RVA: 0x0003E88D File Offset: 0x0003CA8D
		public override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
		{
			throw new NotSupportedException("DeflaterOutputStream BeginRead not currently supported");
		}

		// Token: 0x06000FAA RID: 4010 RVA: 0x0003E899 File Offset: 0x0003CA99
		public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
		{
			throw new NotSupportedException("BeginWrite is not supported");
		}

		// Token: 0x06000FAB RID: 4011 RVA: 0x0003E8A5 File Offset: 0x0003CAA5
		public override void Flush()
		{
			this.deflater_.Flush();
			this.Deflate();
			this.baseOutputStream_.Flush();
		}

		// Token: 0x06000FAC RID: 4012 RVA: 0x0003E8C4 File Offset: 0x0003CAC4
		public override void Close()
		{
			if (!this.isClosed_)
			{
				this.isClosed_ = true;
				try
				{
					this.Finish();
					this.keys = null;
				}
				finally
				{
					if (this.isStreamOwner_)
					{
						this.baseOutputStream_.Close();
					}
				}
			}
		}

		// Token: 0x06000FAD RID: 4013 RVA: 0x0003E914 File Offset: 0x0003CB14
		private void GetAuthCodeIfAES()
		{
		}

		// Token: 0x06000FAE RID: 4014 RVA: 0x0003E918 File Offset: 0x0003CB18
		public override void WriteByte(byte value)
		{
			this.Write(new byte[] { value }, 0, 1);
		}

		// Token: 0x06000FAF RID: 4015 RVA: 0x0003E939 File Offset: 0x0003CB39
		public override void Write(byte[] buffer, int offset, int count)
		{
			this.deflater_.SetInput(buffer, offset, count);
			this.Deflate();
		}

		// Token: 0x04000A1A RID: 2586
		private string password;

		// Token: 0x04000A1B RID: 2587
		private uint[] keys;

		// Token: 0x04000A1C RID: 2588
		private byte[] buffer_;

		// Token: 0x04000A1D RID: 2589
		protected Deflater deflater_;

		// Token: 0x04000A1E RID: 2590
		protected Stream baseOutputStream_;

		// Token: 0x04000A1F RID: 2591
		private bool isClosed_;

		// Token: 0x04000A20 RID: 2592
		private bool isStreamOwner_ = true;
	}
}
