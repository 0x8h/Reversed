using System;

namespace PdfSharp.Fonts.OpenType
{
	// Token: 0x02000098 RID: 152
	internal class MaximumProfileTable : OpenTypeFontTable
	{
		// Token: 0x0600073A RID: 1850 RVA: 0x0001BC8C File Offset: 0x00019E8C
		public MaximumProfileTable(OpenTypeFontface fontData)
			: base(fontData, "maxp")
		{
			this.Read();
		}

		// Token: 0x0600073B RID: 1851 RVA: 0x0001BCA0 File Offset: 0x00019EA0
		public void Read()
		{
			try
			{
				this.version = this._fontData.ReadFixed();
				this.numGlyphs = this._fontData.ReadUShort();
				this.maxPoints = this._fontData.ReadUShort();
				this.maxContours = this._fontData.ReadUShort();
				this.maxCompositePoints = this._fontData.ReadUShort();
				this.maxCompositeContours = this._fontData.ReadUShort();
				this.maxZones = this._fontData.ReadUShort();
				this.maxTwilightPoints = this._fontData.ReadUShort();
				this.maxStorage = this._fontData.ReadUShort();
				this.maxFunctionDefs = this._fontData.ReadUShort();
				this.maxInstructionDefs = this._fontData.ReadUShort();
				this.maxStackElements = this._fontData.ReadUShort();
				this.maxSizeOfInstructions = this._fontData.ReadUShort();
				this.maxComponentElements = this._fontData.ReadUShort();
				this.maxComponentDepth = this._fontData.ReadUShort();
			}
			catch (Exception ex)
			{
				throw new InvalidOperationException(PSSR.ErrorReadingFontData, ex);
			}
		}

		// Token: 0x04000395 RID: 917
		public const string Tag = "maxp";

		// Token: 0x04000396 RID: 918
		public int version;

		// Token: 0x04000397 RID: 919
		public ushort numGlyphs;

		// Token: 0x04000398 RID: 920
		public ushort maxPoints;

		// Token: 0x04000399 RID: 921
		public ushort maxContours;

		// Token: 0x0400039A RID: 922
		public ushort maxCompositePoints;

		// Token: 0x0400039B RID: 923
		public ushort maxCompositeContours;

		// Token: 0x0400039C RID: 924
		public ushort maxZones;

		// Token: 0x0400039D RID: 925
		public ushort maxTwilightPoints;

		// Token: 0x0400039E RID: 926
		public ushort maxStorage;

		// Token: 0x0400039F RID: 927
		public ushort maxFunctionDefs;

		// Token: 0x040003A0 RID: 928
		public ushort maxInstructionDefs;

		// Token: 0x040003A1 RID: 929
		public ushort maxStackElements;

		// Token: 0x040003A2 RID: 930
		public ushort maxSizeOfInstructions;

		// Token: 0x040003A3 RID: 931
		public ushort maxComponentElements;

		// Token: 0x040003A4 RID: 932
		public ushort maxComponentDepth;
	}
}
