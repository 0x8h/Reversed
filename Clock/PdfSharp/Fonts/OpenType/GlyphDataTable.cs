using System;
using System.Collections.Generic;

namespace PdfSharp.Fonts.OpenType
{
	// Token: 0x02000085 RID: 133
	internal class GlyphDataTable : OpenTypeFontTable
	{
		// Token: 0x060006DB RID: 1755 RVA: 0x00019370 File Offset: 0x00017570
		public GlyphDataTable()
			: base(null, "glyf")
		{
			this.DirectoryEntry.Tag = "glyf";
		}

		// Token: 0x060006DC RID: 1756 RVA: 0x0001938E File Offset: 0x0001758E
		public GlyphDataTable(OpenTypeFontface fontData)
			: base(fontData, "glyf")
		{
			this.DirectoryEntry.Tag = "glyf";
			this.Read();
		}

		// Token: 0x060006DD RID: 1757 RVA: 0x000193B4 File Offset: 0x000175B4
		public void Read()
		{
		}

		// Token: 0x060006DE RID: 1758 RVA: 0x000193C4 File Offset: 0x000175C4
		public byte[] GetGlyphData(int glyph)
		{
			IndexToLocationTable loca = this._fontData.loca;
			int offset = this.GetOffset(glyph);
			int offset2 = this.GetOffset(glyph + 1);
			int num = offset2 - offset;
			byte[] array = new byte[num];
			Buffer.BlockCopy(this._fontData.FontSource.Bytes, offset, array, 0, num);
			return array;
		}

		// Token: 0x060006DF RID: 1759 RVA: 0x00019414 File Offset: 0x00017614
		public int GetGlyphSize(int glyph)
		{
			IndexToLocationTable loca = this._fontData.loca;
			return this.GetOffset(glyph + 1) - this.GetOffset(glyph);
		}

		// Token: 0x060006E0 RID: 1760 RVA: 0x00019433 File Offset: 0x00017633
		public int GetOffset(int glyph)
		{
			return this.DirectoryEntry.Offset + this._fontData.loca.LocaTable[glyph];
		}

		// Token: 0x060006E1 RID: 1761 RVA: 0x00019454 File Offset: 0x00017654
		public void CompleteGlyphClosure(Dictionary<int, object> glyphs)
		{
			int count = glyphs.Count;
			int[] array = new int[glyphs.Count];
			glyphs.Keys.CopyTo(array, 0);
			if (!glyphs.ContainsKey(0))
			{
				glyphs.Add(0, null);
			}
			for (int i = 0; i < count; i++)
			{
				this.AddCompositeGlyphs(glyphs, array[i]);
			}
		}

		// Token: 0x060006E2 RID: 1762 RVA: 0x000194A8 File Offset: 0x000176A8
		private void AddCompositeGlyphs(Dictionary<int, object> glyphs, int glyph)
		{
			int offset = this.GetOffset(glyph);
			if (offset == this.GetOffset(glyph + 1))
			{
				return;
			}
			this._fontData.Position = offset;
			int num = (int)this._fontData.ReadShort();
			if (num >= 0)
			{
				return;
			}
			this._fontData.SeekOffset(8);
			for (;;)
			{
				int num2 = (int)this._fontData.ReadUFWord();
				int num3 = (int)this._fontData.ReadUFWord();
				if (!glyphs.ContainsKey(num3))
				{
					glyphs.Add(num3, null);
				}
				if ((num2 & 32) == 0)
				{
					break;
				}
				int num4 = (((num2 & 1) == 0) ? 2 : 4);
				if ((num2 & 8) != 0)
				{
					num4 += 2;
				}
				else if ((num2 & 64) != 0)
				{
					num4 += 4;
				}
				if ((num2 & 128) != 0)
				{
					num4 += 8;
				}
				this._fontData.SeekOffset(num4);
			}
		}

		// Token: 0x060006E3 RID: 1763 RVA: 0x00019566 File Offset: 0x00017766
		public override void PrepareForCompilation()
		{
			base.PrepareForCompilation();
			if (this.DirectoryEntry.Length == 0)
			{
				this.DirectoryEntry.Length = this.GlyphTable.Length;
			}
			this.DirectoryEntry.CheckSum = OpenTypeFontTable.CalcChecksum(this.GlyphTable);
		}

		// Token: 0x060006E4 RID: 1764 RVA: 0x000195A4 File Offset: 0x000177A4
		public override void Write(OpenTypeFontWriter writer)
		{
			writer.Write(this.GlyphTable, 0, this.DirectoryEntry.PaddedLength);
		}

		// Token: 0x04000308 RID: 776
		public const string Tag = "glyf";

		// Token: 0x04000309 RID: 777
		private const int ARG_1_AND_2_ARE_WORDS = 1;

		// Token: 0x0400030A RID: 778
		private const int WE_HAVE_A_SCALE = 8;

		// Token: 0x0400030B RID: 779
		private const int MORE_COMPONENTS = 32;

		// Token: 0x0400030C RID: 780
		private const int WE_HAVE_AN_X_AND_Y_SCALE = 64;

		// Token: 0x0400030D RID: 781
		private const int WE_HAVE_A_TWO_BY_TWO = 128;

		// Token: 0x0400030E RID: 782
		internal byte[] GlyphTable;
	}
}
