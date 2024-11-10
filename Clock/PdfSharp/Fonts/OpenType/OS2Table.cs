using System;

namespace PdfSharp.Fonts.OpenType
{
	// Token: 0x0200009B RID: 155
	internal class OS2Table : OpenTypeFontTable
	{
		// Token: 0x06000740 RID: 1856 RVA: 0x0001C062 File Offset: 0x0001A262
		public OS2Table(OpenTypeFontface fontData)
			: base(fontData, "OS/2")
		{
			this.Read();
		}

		// Token: 0x06000741 RID: 1857 RVA: 0x0001C078 File Offset: 0x0001A278
		public void Read()
		{
			try
			{
				this.version = this._fontData.ReadUShort();
				this.xAvgCharWidth = this._fontData.ReadShort();
				this.usWeightClass = this._fontData.ReadUShort();
				this.usWidthClass = this._fontData.ReadUShort();
				this.fsType = this._fontData.ReadUShort();
				this.ySubscriptXSize = this._fontData.ReadShort();
				this.ySubscriptYSize = this._fontData.ReadShort();
				this.ySubscriptXOffset = this._fontData.ReadShort();
				this.ySubscriptYOffset = this._fontData.ReadShort();
				this.ySuperscriptXSize = this._fontData.ReadShort();
				this.ySuperscriptYSize = this._fontData.ReadShort();
				this.ySuperscriptXOffset = this._fontData.ReadShort();
				this.ySuperscriptYOffset = this._fontData.ReadShort();
				this.yStrikeoutSize = this._fontData.ReadShort();
				this.yStrikeoutPosition = this._fontData.ReadShort();
				this.sFamilyClass = this._fontData.ReadShort();
				this.panose = this._fontData.ReadBytes(10);
				this.ulUnicodeRange1 = this._fontData.ReadULong();
				this.ulUnicodeRange2 = this._fontData.ReadULong();
				this.ulUnicodeRange3 = this._fontData.ReadULong();
				this.ulUnicodeRange4 = this._fontData.ReadULong();
				this.achVendID = this._fontData.ReadString(4);
				this.fsSelection = this._fontData.ReadUShort();
				this.usFirstCharIndex = this._fontData.ReadUShort();
				this.usLastCharIndex = this._fontData.ReadUShort();
				this.sTypoAscender = this._fontData.ReadShort();
				this.sTypoDescender = this._fontData.ReadShort();
				this.sTypoLineGap = this._fontData.ReadShort();
				this.usWinAscent = this._fontData.ReadUShort();
				this.usWinDescent = this._fontData.ReadUShort();
				if (this.version >= 1)
				{
					this.ulCodePageRange1 = this._fontData.ReadULong();
					this.ulCodePageRange2 = this._fontData.ReadULong();
					if (this.version >= 2)
					{
						this.sxHeight = this._fontData.ReadShort();
						this.sCapHeight = this._fontData.ReadShort();
						this.usDefaultChar = this._fontData.ReadUShort();
						this.usBreakChar = this._fontData.ReadUShort();
						this.usMaxContext = this._fontData.ReadUShort();
					}
				}
			}
			catch (Exception ex)
			{
				throw new InvalidOperationException(PSSR.ErrorReadingFontData, ex);
			}
		}

		// Token: 0x17000302 RID: 770
		// (get) Token: 0x06000742 RID: 1858 RVA: 0x0001C340 File Offset: 0x0001A540
		public bool IsBold
		{
			get
			{
				return (this.fsSelection & 32) != 0;
			}
		}

		// Token: 0x17000303 RID: 771
		// (get) Token: 0x06000743 RID: 1859 RVA: 0x0001C351 File Offset: 0x0001A551
		public bool IsItalic
		{
			get
			{
				return (this.fsSelection & 1) != 0;
			}
		}

		// Token: 0x040003B3 RID: 947
		public const string Tag = "OS/2";

		// Token: 0x040003B4 RID: 948
		public ushort version;

		// Token: 0x040003B5 RID: 949
		public short xAvgCharWidth;

		// Token: 0x040003B6 RID: 950
		public ushort usWeightClass;

		// Token: 0x040003B7 RID: 951
		public ushort usWidthClass;

		// Token: 0x040003B8 RID: 952
		public ushort fsType;

		// Token: 0x040003B9 RID: 953
		public short ySubscriptXSize;

		// Token: 0x040003BA RID: 954
		public short ySubscriptYSize;

		// Token: 0x040003BB RID: 955
		public short ySubscriptXOffset;

		// Token: 0x040003BC RID: 956
		public short ySubscriptYOffset;

		// Token: 0x040003BD RID: 957
		public short ySuperscriptXSize;

		// Token: 0x040003BE RID: 958
		public short ySuperscriptYSize;

		// Token: 0x040003BF RID: 959
		public short ySuperscriptXOffset;

		// Token: 0x040003C0 RID: 960
		public short ySuperscriptYOffset;

		// Token: 0x040003C1 RID: 961
		public short yStrikeoutSize;

		// Token: 0x040003C2 RID: 962
		public short yStrikeoutPosition;

		// Token: 0x040003C3 RID: 963
		public short sFamilyClass;

		// Token: 0x040003C4 RID: 964
		public byte[] panose;

		// Token: 0x040003C5 RID: 965
		public uint ulUnicodeRange1;

		// Token: 0x040003C6 RID: 966
		public uint ulUnicodeRange2;

		// Token: 0x040003C7 RID: 967
		public uint ulUnicodeRange3;

		// Token: 0x040003C8 RID: 968
		public uint ulUnicodeRange4;

		// Token: 0x040003C9 RID: 969
		public string achVendID;

		// Token: 0x040003CA RID: 970
		public ushort fsSelection;

		// Token: 0x040003CB RID: 971
		public ushort usFirstCharIndex;

		// Token: 0x040003CC RID: 972
		public ushort usLastCharIndex;

		// Token: 0x040003CD RID: 973
		public short sTypoAscender;

		// Token: 0x040003CE RID: 974
		public short sTypoDescender;

		// Token: 0x040003CF RID: 975
		public short sTypoLineGap;

		// Token: 0x040003D0 RID: 976
		public ushort usWinAscent;

		// Token: 0x040003D1 RID: 977
		public ushort usWinDescent;

		// Token: 0x040003D2 RID: 978
		public uint ulCodePageRange1;

		// Token: 0x040003D3 RID: 979
		public uint ulCodePageRange2;

		// Token: 0x040003D4 RID: 980
		public short sxHeight;

		// Token: 0x040003D5 RID: 981
		public short sCapHeight;

		// Token: 0x040003D6 RID: 982
		public ushort usDefaultChar;

		// Token: 0x040003D7 RID: 983
		public ushort usBreakChar;

		// Token: 0x040003D8 RID: 984
		public ushort usMaxContext;

		// Token: 0x0200009C RID: 156
		[Flags]
		public enum FontSelectionFlags : ushort
		{
			// Token: 0x040003DA RID: 986
			Italic = 1,
			// Token: 0x040003DB RID: 987
			Bold = 32,
			// Token: 0x040003DC RID: 988
			Regular = 64
		}
	}
}
