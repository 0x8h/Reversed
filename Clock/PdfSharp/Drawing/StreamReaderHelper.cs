using System;
using System.IO;

namespace PdfSharp.Drawing
{
	// Token: 0x0200003D RID: 61
	internal class StreamReaderHelper
	{
		// Token: 0x0600013D RID: 317 RVA: 0x0000A4EC File Offset: 0x000086EC
		internal StreamReaderHelper(Stream stream)
		{
			this._stream = stream;
			this._stream.Position = 0L;
			if (this._stream.Length > 2147483647L)
			{
				throw new ArgumentException("Stream is too large.", "stream");
			}
			this._length = (int)this._stream.Length;
			this._data = new byte[this._length];
			this._stream.Read(this._data, 0, this._length);
		}

		// Token: 0x0600013E RID: 318 RVA: 0x0000A572 File Offset: 0x00008772
		internal byte GetByte(int offset)
		{
			if (this._currentOffset + offset >= this._length)
			{
				return 0;
			}
			return this._data[this._currentOffset + offset];
		}

		// Token: 0x0600013F RID: 319 RVA: 0x0000A595 File Offset: 0x00008795
		internal ushort GetWord(int offset, bool bigEndian)
		{
			return bigEndian ? ((ushort)this.GetByte(offset) * 256 + (ushort)this.GetByte(offset + 1)) : ((ushort)this.GetByte(offset) + (ushort)this.GetByte(offset + 1) * 256);
		}

		// Token: 0x06000140 RID: 320 RVA: 0x0000A5CB File Offset: 0x000087CB
		internal uint GetDWord(int offset, bool bigEndian)
		{
			if (!bigEndian)
			{
				return (uint)this.GetWord(offset, false) + (uint)this.GetWord(offset + 2, false) * 65536U;
			}
			return (uint)this.GetWord(offset, true) * 65536U + (uint)this.GetWord(offset + 2, true);
		}

		// Token: 0x06000141 RID: 321 RVA: 0x0000A604 File Offset: 0x00008804
		private static void CopyStream(Stream input, Stream output)
		{
			byte[] array = new byte[65536];
			int num;
			while ((num = input.Read(array, 0, array.Length)) > 0)
			{
				output.Write(array, 0, num);
			}
		}

		// Token: 0x06000142 RID: 322 RVA: 0x0000A637 File Offset: 0x00008837
		public void Reset()
		{
			this._currentOffset = 0;
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x06000143 RID: 323 RVA: 0x0000A640 File Offset: 0x00008840
		public Stream OriginalStream
		{
			get
			{
				return this._stream;
			}
		}

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x06000144 RID: 324 RVA: 0x0000A648 File Offset: 0x00008848
		// (set) Token: 0x06000145 RID: 325 RVA: 0x0000A650 File Offset: 0x00008850
		internal int CurrentOffset
		{
			get
			{
				return this._currentOffset;
			}
			set
			{
				this._currentOffset = value;
			}
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x06000146 RID: 326 RVA: 0x0000A659 File Offset: 0x00008859
		public byte[] Data
		{
			get
			{
				return this._data;
			}
		}

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x06000147 RID: 327 RVA: 0x0000A661 File Offset: 0x00008861
		public int Length
		{
			get
			{
				return this._length;
			}
		}

		// Token: 0x040001B7 RID: 439
		private readonly Stream _stream;

		// Token: 0x040001B8 RID: 440
		private int _currentOffset;

		// Token: 0x040001B9 RID: 441
		private readonly byte[] _data;

		// Token: 0x040001BA RID: 442
		private readonly int _length;
	}
}
