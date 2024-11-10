using System;
using System.IO;

namespace PdfSharp.Fonts
{
	// Token: 0x020000A2 RID: 162
	internal class FontWriter
	{
		// Token: 0x0600074E RID: 1870 RVA: 0x0001C679 File Offset: 0x0001A879
		public FontWriter(Stream stream)
		{
			this._stream = stream;
		}

		// Token: 0x0600074F RID: 1871 RVA: 0x0001C688 File Offset: 0x0001A888
		public void Close(bool closeUnderlyingStream)
		{
			if (this._stream != null && closeUnderlyingStream)
			{
				this._stream.Close();
				this._stream.Dispose();
			}
			this._stream = null;
		}

		// Token: 0x06000750 RID: 1872 RVA: 0x0001C6B2 File Offset: 0x0001A8B2
		public void Close()
		{
			this.Close(true);
		}

		// Token: 0x17000304 RID: 772
		// (get) Token: 0x06000751 RID: 1873 RVA: 0x0001C6BB File Offset: 0x0001A8BB
		// (set) Token: 0x06000752 RID: 1874 RVA: 0x0001C6C9 File Offset: 0x0001A8C9
		public int Position
		{
			get
			{
				return (int)this._stream.Position;
			}
			set
			{
				this._stream.Position = (long)value;
			}
		}

		// Token: 0x06000753 RID: 1875 RVA: 0x0001C6D8 File Offset: 0x0001A8D8
		public void WriteByte(byte value)
		{
			this._stream.WriteByte(value);
		}

		// Token: 0x06000754 RID: 1876 RVA: 0x0001C6E6 File Offset: 0x0001A8E6
		public void WriteByte(int value)
		{
			this._stream.WriteByte((byte)value);
		}

		// Token: 0x06000755 RID: 1877 RVA: 0x0001C6F5 File Offset: 0x0001A8F5
		public void WriteShort(short value)
		{
			this._stream.WriteByte((byte)(value >> 8));
			this._stream.WriteByte((byte)value);
		}

		// Token: 0x06000756 RID: 1878 RVA: 0x0001C713 File Offset: 0x0001A913
		public void WriteShort(int value)
		{
			this.WriteShort((short)value);
		}

		// Token: 0x06000757 RID: 1879 RVA: 0x0001C71D File Offset: 0x0001A91D
		public void WriteUShort(ushort value)
		{
			this._stream.WriteByte((byte)(value >> 8));
			this._stream.WriteByte((byte)value);
		}

		// Token: 0x06000758 RID: 1880 RVA: 0x0001C73B File Offset: 0x0001A93B
		public void WriteUShort(int value)
		{
			this.WriteUShort((ushort)value);
		}

		// Token: 0x06000759 RID: 1881 RVA: 0x0001C745 File Offset: 0x0001A945
		public void WriteInt(int value)
		{
			this._stream.WriteByte((byte)(value >> 24));
			this._stream.WriteByte((byte)(value >> 16));
			this._stream.WriteByte((byte)(value >> 8));
			this._stream.WriteByte((byte)value);
		}

		// Token: 0x0600075A RID: 1882 RVA: 0x0001C783 File Offset: 0x0001A983
		public void WriteUInt(uint value)
		{
			this._stream.WriteByte((byte)(value >> 24));
			this._stream.WriteByte((byte)(value >> 16));
			this._stream.WriteByte((byte)(value >> 8));
			this._stream.WriteByte((byte)value);
		}

		// Token: 0x0600075B RID: 1883 RVA: 0x0001C7C1 File Offset: 0x0001A9C1
		public void Write(byte[] buffer)
		{
			this._stream.Write(buffer, 0, buffer.Length);
		}

		// Token: 0x0600075C RID: 1884 RVA: 0x0001C7D3 File Offset: 0x0001A9D3
		public void Write(byte[] buffer, int offset, int count)
		{
			this._stream.Write(buffer, offset, count);
		}

		// Token: 0x17000305 RID: 773
		// (get) Token: 0x0600075D RID: 1885 RVA: 0x0001C7E3 File Offset: 0x0001A9E3
		internal Stream Stream
		{
			get
			{
				return this._stream;
			}
		}

		// Token: 0x040003EE RID: 1006
		private Stream _stream;
	}
}
