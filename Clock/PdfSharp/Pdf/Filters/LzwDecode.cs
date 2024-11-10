using System;
using System.IO;

namespace PdfSharp.Pdf.Filters
{
	// Token: 0x0200015F RID: 351
	public class LzwDecode : Filter
	{
		// Token: 0x06000B9E RID: 2974 RVA: 0x0002DE32 File Offset: 0x0002C032
		public override byte[] Encode(byte[] data)
		{
			throw new NotImplementedException("PDFsharp does not support LZW encoding.");
		}

		// Token: 0x06000B9F RID: 2975 RVA: 0x0002DE40 File Offset: 0x0002C040
		public override byte[] Decode(byte[] data, FilterParms parms)
		{
			if (data[0] == 0 && data[1] == 1)
			{
				throw new Exception("LZW flavour not supported.");
			}
			MemoryStream memoryStream = new MemoryStream();
			this.InitializeDictionary();
			this._data = data;
			this._bytePointer = 0;
			this._nextData = 0;
			this._nextBits = 0;
			int num = 0;
			int num2;
			while ((num2 = this.NextCode) != 257)
			{
				if (num2 == 256)
				{
					this.InitializeDictionary();
					num2 = this.NextCode;
					if (num2 == 257)
					{
						break;
					}
					memoryStream.Write(this._stringTable[num2], 0, this._stringTable[num2].Length);
					num = num2;
				}
				else if (num2 < this._tableIndex)
				{
					byte[] array = this._stringTable[num2];
					memoryStream.Write(array, 0, array.Length);
					this.AddEntry(this._stringTable[num], array[0]);
					num = num2;
				}
				else
				{
					byte[] array = this._stringTable[num];
					memoryStream.Write(array, 0, array.Length);
					this.AddEntry(array, array[0]);
					num = num2;
				}
			}
			if (memoryStream.Length >= 0L)
			{
				memoryStream.Capacity = (int)memoryStream.Length;
				return memoryStream.GetBuffer();
			}
			return null;
		}

		// Token: 0x06000BA0 RID: 2976 RVA: 0x0002DF54 File Offset: 0x0002C154
		private void InitializeDictionary()
		{
			this._stringTable = new byte[8192][];
			for (int i = 0; i < 256; i++)
			{
				this._stringTable[i] = new byte[1];
				this._stringTable[i][0] = (byte)i;
			}
			this._tableIndex = 258;
			this._bitsToGet = 9;
		}

		// Token: 0x06000BA1 RID: 2977 RVA: 0x0002DFB0 File Offset: 0x0002C1B0
		private void AddEntry(byte[] oldstring, byte newstring)
		{
			int num = oldstring.Length;
			byte[] array = new byte[num + 1];
			Array.Copy(oldstring, 0, array, 0, num);
			array[num] = newstring;
			this._stringTable[this._tableIndex++] = array;
			if (this._tableIndex == 511)
			{
				this._bitsToGet = 10;
				return;
			}
			if (this._tableIndex == 1023)
			{
				this._bitsToGet = 11;
				return;
			}
			if (this._tableIndex == 2047)
			{
				this._bitsToGet = 12;
			}
		}

		// Token: 0x17000424 RID: 1060
		// (get) Token: 0x06000BA2 RID: 2978 RVA: 0x0002E034 File Offset: 0x0002C234
		private int NextCode
		{
			get
			{
				int num2;
				try
				{
					this._nextData = (this._nextData << 8) | (int)(this._data[this._bytePointer++] & byte.MaxValue);
					this._nextBits += 8;
					if (this._nextBits < this._bitsToGet)
					{
						this._nextData = (this._nextData << 8) | (int)(this._data[this._bytePointer++] & byte.MaxValue);
						this._nextBits += 8;
					}
					int num = (this._nextData >> this._nextBits - this._bitsToGet) & this._andTable[this._bitsToGet - 9];
					this._nextBits -= this._bitsToGet;
					num2 = num;
				}
				catch
				{
					num2 = 257;
				}
				return num2;
			}
		}

		// Token: 0x0400072B RID: 1835
		private readonly int[] _andTable = new int[] { 511, 1023, 2047, 4095 };

		// Token: 0x0400072C RID: 1836
		private byte[][] _stringTable;

		// Token: 0x0400072D RID: 1837
		private byte[] _data;

		// Token: 0x0400072E RID: 1838
		private int _tableIndex;

		// Token: 0x0400072F RID: 1839
		private int _bitsToGet = 9;

		// Token: 0x04000730 RID: 1840
		private int _bytePointer;

		// Token: 0x04000731 RID: 1841
		private int _nextData;

		// Token: 0x04000732 RID: 1842
		private int _nextBits;
	}
}
