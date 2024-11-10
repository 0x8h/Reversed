using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using PdfSharp.Drawing;

namespace PdfSharp.Fonts.OpenType
{
	// Token: 0x0200008B RID: 139
	[DebuggerDisplay("{DebuggerDisplay}")]
	internal sealed class OpenTypeFontface
	{
		// Token: 0x06000705 RID: 1797 RVA: 0x0001A48C File Offset: 0x0001868C
		private OpenTypeFontface(OpenTypeFontface fontface)
		{
			this._offsetTable = fontface._offsetTable;
			this._fullFaceName = fontface._fullFaceName;
		}

		// Token: 0x06000706 RID: 1798 RVA: 0x0001A4B8 File Offset: 0x000186B8
		public OpenTypeFontface(byte[] data, string faceName)
		{
			this._fullFaceName = faceName;
			int num = data.Length;
			Array.Copy(data, this.FontSource.Bytes, num);
			this.Read();
		}

		// Token: 0x06000707 RID: 1799 RVA: 0x0001A4F9 File Offset: 0x000186F9
		public OpenTypeFontface(XFontSource fontSource)
		{
			this.FontSource = fontSource;
			this.Read();
			this._fullFaceName = this.name.FullFontName;
		}

		// Token: 0x06000708 RID: 1800 RVA: 0x0001A52C File Offset: 0x0001872C
		public static OpenTypeFontface CetOrCreateFrom(XFontSource fontSource)
		{
			OpenTypeFontface openTypeFontface;
			if (OpenTypeFontfaceCache.TryGetFontface(fontSource.Key, out openTypeFontface))
			{
				return openTypeFontface;
			}
			openTypeFontface = OpenTypeFontfaceCache.AddFontface(fontSource.Fontface);
			return openTypeFontface;
		}

		// Token: 0x170002FB RID: 763
		// (get) Token: 0x06000709 RID: 1801 RVA: 0x0001A557 File Offset: 0x00018757
		public string FullFaceName
		{
			get
			{
				return this._fullFaceName;
			}
		}

		// Token: 0x170002FC RID: 764
		// (get) Token: 0x0600070A RID: 1802 RVA: 0x0001A55F File Offset: 0x0001875F
		public ulong CheckSum
		{
			get
			{
				if (this._checkSum == 0UL)
				{
					this._checkSum = FontHelper.CalcChecksum(this.FontSource.Bytes);
				}
				return this._checkSum;
			}
		}

		// Token: 0x170002FD RID: 765
		// (get) Token: 0x0600070B RID: 1803 RVA: 0x0001A587 File Offset: 0x00018787
		// (set) Token: 0x0600070C RID: 1804 RVA: 0x0001A58F File Offset: 0x0001878F
		public XFontSource FontSource
		{
			get
			{
				return this._fontSource;
			}
			private set
			{
				if (value == null)
				{
					throw new InvalidOperationException("Font cannot be resolved.");
				}
				this._fontSource = value;
			}
		}

		// Token: 0x170002FE RID: 766
		// (get) Token: 0x0600070D RID: 1805 RVA: 0x0001A5A6 File Offset: 0x000187A6
		public bool CanRead
		{
			get
			{
				return this.FontSource != null;
			}
		}

		// Token: 0x170002FF RID: 767
		// (get) Token: 0x0600070E RID: 1806 RVA: 0x0001A5B4 File Offset: 0x000187B4
		public bool CanWrite
		{
			get
			{
				return this.FontSource == null;
			}
		}

		// Token: 0x0600070F RID: 1807 RVA: 0x0001A5C0 File Offset: 0x000187C0
		public void AddTable(OpenTypeFontTable fontTable)
		{
			if (!this.CanWrite)
			{
				throw new InvalidOperationException("Font image cannot be modified.");
			}
			if (fontTable == null)
			{
				throw new ArgumentNullException("fontTable");
			}
			if (fontTable._fontData == null)
			{
				fontTable._fontData = this;
			}
			else
			{
				fontTable = new IRefFontTable(this, fontTable);
			}
			this.TableDictionary[fontTable.DirectoryEntry.Tag] = fontTable.DirectoryEntry;
			string tag;
			switch (tag = fontTable.DirectoryEntry.Tag)
			{
			case "cmap":
				this.cmap = fontTable as CMapTable;
				return;
			case "cvt ":
				this.cvt = fontTable as ControlValueTable;
				return;
			case "fpgm":
				this.fpgm = fontTable as FontProgram;
				return;
			case "maxp":
				this.maxp = fontTable as MaximumProfileTable;
				return;
			case "name":
				this.name = fontTable as NameTable;
				return;
			case "head":
				this.head = fontTable as FontHeaderTable;
				return;
			case "hhea":
				this.hhea = fontTable as HorizontalHeaderTable;
				return;
			case "hmtx":
				this.hmtx = fontTable as HorizontalMetricsTable;
				return;
			case "OS/2":
				this.os2 = fontTable as OS2Table;
				return;
			case "post":
				this.post = fontTable as PostScriptTable;
				return;
			case "glyf":
				this.glyf = fontTable as GlyphDataTable;
				return;
			case "loca":
				this.loca = fontTable as IndexToLocationTable;
				return;
			case "GSUB":
				this.gsub = fontTable as GlyphSubstitutionTable;
				return;
			case "prep":
				this.prep = fontTable as ControlValueProgram;
				break;

				return;
			}
		}

		// Token: 0x06000710 RID: 1808 RVA: 0x0001A808 File Offset: 0x00018A08
		internal void Read()
		{
			try
			{
				uint num = this.ReadULong();
				if (num == 1953784678U)
				{
					this._fontTechnology = FontTechnology.TrueTypeCollection;
					throw new InvalidOperationException("TrueType collection fonts are not yet supported by PDFsharp.");
				}
				this._offsetTable.Version = num;
				this._offsetTable.TableCount = (int)this.ReadUShort();
				this._offsetTable.SearchRange = this.ReadUShort();
				this._offsetTable.EntrySelector = this.ReadUShort();
				this._offsetTable.RangeShift = this.ReadUShort();
				if (this._offsetTable.Version == 1330926671U)
				{
					this._fontTechnology = FontTechnology.PostscriptOutlines;
				}
				else
				{
					this._fontTechnology = FontTechnology.TrueTypeOutlines;
				}
				for (int i = 0; i < this._offsetTable.TableCount; i++)
				{
					TableDirectoryEntry tableDirectoryEntry = TableDirectoryEntry.ReadFrom(this);
					this.TableDictionary.Add(tableDirectoryEntry.Tag, tableDirectoryEntry);
				}
				if (this.TableDictionary.ContainsKey("bhed"))
				{
					throw new NotSupportedException("Bitmap fonts are not supported by PDFsharp.");
				}
				if (this.Seek("cmap") != -1)
				{
					this.cmap = new CMapTable(this);
				}
				if (this.Seek("cvt ") != -1)
				{
					this.cvt = new ControlValueTable(this);
				}
				if (this.Seek("fpgm") != -1)
				{
					this.fpgm = new FontProgram(this);
				}
				if (this.Seek("maxp") != -1)
				{
					this.maxp = new MaximumProfileTable(this);
				}
				if (this.Seek("name") != -1)
				{
					this.name = new NameTable(this);
				}
				if (this.Seek("head") != -1)
				{
					this.head = new FontHeaderTable(this);
				}
				if (this.Seek("hhea") != -1)
				{
					this.hhea = new HorizontalHeaderTable(this);
				}
				if (this.Seek("hmtx") != -1)
				{
					this.hmtx = new HorizontalMetricsTable(this);
				}
				if (this.Seek("OS/2") != -1)
				{
					this.os2 = new OS2Table(this);
				}
				if (this.Seek("post") != -1)
				{
					this.post = new PostScriptTable(this);
				}
				if (this.Seek("glyf") != -1)
				{
					this.glyf = new GlyphDataTable(this);
				}
				if (this.Seek("loca") != -1)
				{
					this.loca = new IndexToLocationTable(this);
				}
				if (this.Seek("GSUB") != -1)
				{
					this.gsub = new GlyphSubstitutionTable(this);
				}
				if (this.Seek("prep") != -1)
				{
					this.prep = new ControlValueProgram(this);
				}
			}
			catch (Exception)
			{
				base.GetType();
				throw;
			}
		}

		// Token: 0x06000711 RID: 1809 RVA: 0x0001AA88 File Offset: 0x00018C88
		public OpenTypeFontface CreateFontSubSet(Dictionary<int, object> glyphs, bool cidFont)
		{
			OpenTypeFontface openTypeFontface = new OpenTypeFontface(this);
			IndexToLocationTable indexToLocationTable = new IndexToLocationTable();
			indexToLocationTable.ShortIndex = this.loca.ShortIndex;
			GlyphDataTable glyphDataTable = new GlyphDataTable();
			if (!cidFont)
			{
				openTypeFontface.AddTable(this.cmap);
			}
			if (this.cvt != null)
			{
				openTypeFontface.AddTable(this.cvt);
			}
			if (this.fpgm != null)
			{
				openTypeFontface.AddTable(this.fpgm);
			}
			openTypeFontface.AddTable(glyphDataTable);
			openTypeFontface.AddTable(this.head);
			openTypeFontface.AddTable(this.hhea);
			openTypeFontface.AddTable(this.hmtx);
			openTypeFontface.AddTable(indexToLocationTable);
			if (this.maxp != null)
			{
				openTypeFontface.AddTable(this.maxp);
			}
			if (this.prep != null)
			{
				openTypeFontface.AddTable(this.prep);
			}
			this.glyf.CompleteGlyphClosure(glyphs);
			int count = glyphs.Count;
			int[] array = new int[count];
			glyphs.Keys.CopyTo(array, 0);
			Array.Sort<int>(array);
			int num = 0;
			for (int i = 0; i < count; i++)
			{
				num += this.glyf.GetGlyphSize(array[i]);
			}
			glyphDataTable.DirectoryEntry.Length = num;
			int numGlyphs = (int)this.maxp.numGlyphs;
			indexToLocationTable.LocaTable = new int[numGlyphs + 1];
			glyphDataTable.GlyphTable = new byte[glyphDataTable.DirectoryEntry.PaddedLength];
			int num2 = 0;
			int num3 = 0;
			for (int j = 0; j < numGlyphs; j++)
			{
				indexToLocationTable.LocaTable[j] = num2;
				if (num3 < count && array[num3] == j)
				{
					num3++;
					byte[] glyphData = this.glyf.GetGlyphData(j);
					int num4 = glyphData.Length;
					if (num4 > 0)
					{
						Buffer.BlockCopy(glyphData, 0, glyphDataTable.GlyphTable, num2, num4);
						num2 += num4;
					}
				}
			}
			indexToLocationTable.LocaTable[numGlyphs] = num2;
			openTypeFontface.Compile();
			return openTypeFontface;
		}

		// Token: 0x06000712 RID: 1810 RVA: 0x0001AC5C File Offset: 0x00018E5C
		private void Compile()
		{
			MemoryStream memoryStream = new MemoryStream();
			OpenTypeFontWriter openTypeFontWriter = new OpenTypeFontWriter(memoryStream);
			int count = this.TableDictionary.Count;
			int num = OpenTypeFontface._entrySelectors[count];
			this._offsetTable.Version = 65536U;
			this._offsetTable.TableCount = count;
			this._offsetTable.SearchRange = (ushort)((1 << num) * 16);
			this._offsetTable.EntrySelector = (ushort)num;
			this._offsetTable.RangeShift = (ushort)((count - (1 << num)) * 16);
			this._offsetTable.Write(openTypeFontWriter);
			string[] array = new string[count];
			this.TableDictionary.Keys.CopyTo(array, 0);
			Array.Sort<string>(array, StringComparer.Ordinal);
			int num2 = 12 + 16 * count;
			for (int i = 0; i < count; i++)
			{
				TableDirectoryEntry tableDirectoryEntry = this.TableDictionary[array[i]];
				tableDirectoryEntry.FontTable.PrepareForCompilation();
				tableDirectoryEntry.Offset = num2;
				openTypeFontWriter.Position = num2;
				tableDirectoryEntry.FontTable.Write(openTypeFontWriter);
				int position = openTypeFontWriter.Position;
				num2 = position;
				openTypeFontWriter.Position = 12 + 16 * i;
				tableDirectoryEntry.Write(openTypeFontWriter);
			}
			openTypeFontWriter.Stream.Flush();
			long length = openTypeFontWriter.Stream.Length;
			this.FontSource = XFontSource.CreateCompiledFont(memoryStream.ToArray());
		}

		// Token: 0x17000300 RID: 768
		// (get) Token: 0x06000713 RID: 1811 RVA: 0x0001ADB1 File Offset: 0x00018FB1
		// (set) Token: 0x06000714 RID: 1812 RVA: 0x0001ADB9 File Offset: 0x00018FB9
		public int Position
		{
			get
			{
				return this._pos;
			}
			set
			{
				this._pos = value;
			}
		}

		// Token: 0x06000715 RID: 1813 RVA: 0x0001ADC2 File Offset: 0x00018FC2
		public int Seek(string tag)
		{
			if (this.TableDictionary.ContainsKey(tag))
			{
				this._pos = this.TableDictionary[tag].Offset;
				return this._pos;
			}
			return -1;
		}

		// Token: 0x06000716 RID: 1814 RVA: 0x0001ADF1 File Offset: 0x00018FF1
		public int SeekOffset(int offset)
		{
			this._pos += offset;
			return this._pos;
		}

		// Token: 0x06000717 RID: 1815 RVA: 0x0001AE08 File Offset: 0x00019008
		public byte ReadByte()
		{
			return this._fontSource.Bytes[this._pos++];
		}

		// Token: 0x06000718 RID: 1816 RVA: 0x0001AE34 File Offset: 0x00019034
		public short ReadShort()
		{
			int pos = this._pos;
			this._pos += 2;
			return (short)(((int)this._fontSource.Bytes[pos] << 8) | (int)this._fontSource.Bytes[pos + 1]);
		}

		// Token: 0x06000719 RID: 1817 RVA: 0x0001AE78 File Offset: 0x00019078
		public ushort ReadUShort()
		{
			int pos = this._pos;
			this._pos += 2;
			return (ushort)(((int)this._fontSource.Bytes[pos] << 8) | (int)this._fontSource.Bytes[pos + 1]);
		}

		// Token: 0x0600071A RID: 1818 RVA: 0x0001AEBC File Offset: 0x000190BC
		public int ReadLong()
		{
			int pos = this._pos;
			this._pos += 4;
			return ((int)this._fontSource.Bytes[pos] << 24) | ((int)this._fontSource.Bytes[pos + 1] << 16) | ((int)this._fontSource.Bytes[pos + 2] << 8) | (int)this._fontSource.Bytes[pos + 3];
		}

		// Token: 0x0600071B RID: 1819 RVA: 0x0001AF24 File Offset: 0x00019124
		public uint ReadULong()
		{
			int pos = this._pos;
			this._pos += 4;
			return (uint)(((int)this._fontSource.Bytes[pos] << 24) | ((int)this._fontSource.Bytes[pos + 1] << 16) | ((int)this._fontSource.Bytes[pos + 2] << 8) | (int)this._fontSource.Bytes[pos + 3]);
		}

		// Token: 0x0600071C RID: 1820 RVA: 0x0001AF8C File Offset: 0x0001918C
		public int ReadFixed()
		{
			int pos = this._pos;
			this._pos += 4;
			return ((int)this._fontSource.Bytes[pos] << 24) | ((int)this._fontSource.Bytes[pos + 1] << 16) | ((int)this._fontSource.Bytes[pos + 2] << 8) | (int)this._fontSource.Bytes[pos + 3];
		}

		// Token: 0x0600071D RID: 1821 RVA: 0x0001AFF4 File Offset: 0x000191F4
		public short ReadFWord()
		{
			int pos = this._pos;
			this._pos += 2;
			return (short)(((int)this._fontSource.Bytes[pos] << 8) | (int)this._fontSource.Bytes[pos + 1]);
		}

		// Token: 0x0600071E RID: 1822 RVA: 0x0001B038 File Offset: 0x00019238
		public ushort ReadUFWord()
		{
			int pos = this._pos;
			this._pos += 2;
			return (ushort)(((int)this._fontSource.Bytes[pos] << 8) | (int)this._fontSource.Bytes[pos + 1]);
		}

		// Token: 0x0600071F RID: 1823 RVA: 0x0001B07C File Offset: 0x0001927C
		public long ReadLongDate()
		{
			int pos = this._pos;
			this._pos += 8;
			byte[] bytes = this._fontSource.Bytes;
			return (long)(((ulong)bytes[pos] << 56) | ((ulong)bytes[pos + 1] << 48) | ((ulong)bytes[pos + 2] << 40) | ((ulong)bytes[pos + 3] << 32) | ((ulong)bytes[pos + 4] << 24) | ((ulong)bytes[pos + 5] << 16) | ((ulong)bytes[pos + 6] << 8) | (ulong)bytes[pos + 7]);
		}

		// Token: 0x06000720 RID: 1824 RVA: 0x0001B0F4 File Offset: 0x000192F4
		public string ReadString(int size)
		{
			char[] array = new char[size];
			for (int i = 0; i < size; i++)
			{
				array[i] = (char)this._fontSource.Bytes[this._pos++];
			}
			return new string(array);
		}

		// Token: 0x06000721 RID: 1825 RVA: 0x0001B13C File Offset: 0x0001933C
		public byte[] ReadBytes(int size)
		{
			byte[] array = new byte[size];
			for (int i = 0; i < size; i++)
			{
				array[i] = this._fontSource.Bytes[this._pos++];
			}
			return array;
		}

		// Token: 0x06000722 RID: 1826 RVA: 0x0001B17D File Offset: 0x0001937D
		public void Read(byte[] buffer)
		{
			this.Read(buffer, 0, buffer.Length);
		}

		// Token: 0x06000723 RID: 1827 RVA: 0x0001B18A File Offset: 0x0001938A
		public void Read(byte[] buffer, int offset, int length)
		{
			Buffer.BlockCopy(this._fontSource.Bytes, this._pos, buffer, offset, length);
			this._pos += length;
		}

		// Token: 0x06000724 RID: 1828 RVA: 0x0001B1B3 File Offset: 0x000193B3
		public string ReadTag()
		{
			return this.ReadString(4);
		}

		// Token: 0x17000301 RID: 769
		// (get) Token: 0x06000725 RID: 1829 RVA: 0x0001B1BC File Offset: 0x000193BC
		internal string DebuggerDisplay
		{
			get
			{
				return string.Format(CultureInfo.InvariantCulture, "OpenType fontfaces: {0}", new object[] { this._fullFaceName });
			}
		}

		// Token: 0x0400031B RID: 795
		private readonly string _fullFaceName;

		// Token: 0x0400031C RID: 796
		private ulong _checkSum;

		// Token: 0x0400031D RID: 797
		private XFontSource _fontSource;

		// Token: 0x0400031E RID: 798
		internal FontTechnology _fontTechnology;

		// Token: 0x0400031F RID: 799
		internal OpenTypeFontface.OffsetTable _offsetTable;

		// Token: 0x04000320 RID: 800
		internal Dictionary<string, TableDirectoryEntry> TableDictionary = new Dictionary<string, TableDirectoryEntry>();

		// Token: 0x04000321 RID: 801
		internal CMapTable cmap;

		// Token: 0x04000322 RID: 802
		internal ControlValueTable cvt;

		// Token: 0x04000323 RID: 803
		internal FontProgram fpgm;

		// Token: 0x04000324 RID: 804
		internal MaximumProfileTable maxp;

		// Token: 0x04000325 RID: 805
		internal NameTable name;

		// Token: 0x04000326 RID: 806
		internal ControlValueProgram prep;

		// Token: 0x04000327 RID: 807
		internal FontHeaderTable head;

		// Token: 0x04000328 RID: 808
		internal HorizontalHeaderTable hhea;

		// Token: 0x04000329 RID: 809
		internal HorizontalMetricsTable hmtx;

		// Token: 0x0400032A RID: 810
		internal OS2Table os2;

		// Token: 0x0400032B RID: 811
		internal PostScriptTable post;

		// Token: 0x0400032C RID: 812
		internal GlyphDataTable glyf;

		// Token: 0x0400032D RID: 813
		internal IndexToLocationTable loca;

		// Token: 0x0400032E RID: 814
		internal GlyphSubstitutionTable gsub;

		// Token: 0x0400032F RID: 815
		internal VerticalHeaderTable vhea;

		// Token: 0x04000330 RID: 816
		internal VerticalMetricsTable vmtx;

		// Token: 0x04000331 RID: 817
		private static readonly int[] _entrySelectors = new int[]
		{
			0, 0, 1, 1, 2, 2, 2, 2, 3, 3,
			3, 3, 3, 3, 3, 3, 4, 4, 4, 4,
			4, 4, 4, 4, 4, 4, 4, 4, 4, 4,
			4
		};

		// Token: 0x04000332 RID: 818
		private int _pos;

		// Token: 0x0200008C RID: 140
		internal struct OffsetTable
		{
			// Token: 0x06000727 RID: 1831 RVA: 0x0001B285 File Offset: 0x00019485
			public void Write(OpenTypeFontWriter writer)
			{
				writer.WriteUInt(this.Version);
				writer.WriteShort(this.TableCount);
				writer.WriteUShort(this.SearchRange);
				writer.WriteUShort(this.EntrySelector);
				writer.WriteUShort(this.RangeShift);
			}

			// Token: 0x04000333 RID: 819
			public uint Version;

			// Token: 0x04000334 RID: 820
			public int TableCount;

			// Token: 0x04000335 RID: 821
			public ushort SearchRange;

			// Token: 0x04000336 RID: 822
			public ushort EntrySelector;

			// Token: 0x04000337 RID: 823
			public ushort RangeShift;
		}
	}
}
