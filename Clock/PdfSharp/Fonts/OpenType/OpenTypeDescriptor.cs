using System;
using System.Text;
using PdfSharp.Drawing;
using PdfSharp.Pdf.Internal;

namespace PdfSharp.Fonts.OpenType
{
	// Token: 0x0200008A RID: 138
	internal sealed class OpenTypeDescriptor : FontDescriptor
	{
		// Token: 0x060006F9 RID: 1785 RVA: 0x00019CAF File Offset: 0x00017EAF
		public OpenTypeDescriptor(string fontDescriptorKey, string name, XFontStyle stlye, OpenTypeFontface fontface, XPdfFontOptions options)
			: base(fontDescriptorKey)
		{
			this.FontFace = fontface;
			base.FontName = name;
			this.Initialize();
		}

		// Token: 0x060006FA RID: 1786 RVA: 0x00019CD0 File Offset: 0x00017ED0
		public OpenTypeDescriptor(string fontDescriptorKey, XFont font)
			: base(fontDescriptorKey)
		{
			try
			{
				this.FontFace = font.GlyphTypeface.Fontface;
				base.FontName = font.Name;
				this.Initialize();
			}
			catch
			{
				base.GetType();
				throw;
			}
		}

		// Token: 0x060006FB RID: 1787 RVA: 0x00019D24 File Offset: 0x00017F24
		internal OpenTypeDescriptor(string fontDescriptorKey, string idName, byte[] fontData)
			: base(fontDescriptorKey)
		{
			try
			{
				this.FontFace = new OpenTypeFontface(fontData, idName);
				if (idName.Contains("XPS-Font-") && this.FontFace.name != null && this.FontFace.name.Name.Length != 0)
				{
					string text = string.Empty;
					if (idName.IndexOf('+') == 6)
					{
						text = idName.Substring(0, 6);
					}
					idName = text + "+" + this.FontFace.name.Name;
					if (this.FontFace.name.Style.Length != 0)
					{
						idName = idName + "," + this.FontFace.name.Style;
					}
				}
				base.FontName = idName;
				this.Initialize();
			}
			catch (Exception)
			{
				base.GetType();
				throw;
			}
		}

		// Token: 0x060006FC RID: 1788 RVA: 0x00019E10 File Offset: 0x00018010
		private void Initialize()
		{
			base.ItalicAngle = this.FontFace.post.italicAngle;
			base.XMin = (int)this.FontFace.head.xMin;
			base.YMin = (int)this.FontFace.head.yMin;
			base.XMax = (int)this.FontFace.head.xMax;
			base.YMax = (int)this.FontFace.head.yMax;
			base.UnderlinePosition = (int)this.FontFace.post.underlinePosition;
			base.UnderlineThickness = (int)this.FontFace.post.underlineThickness;
			base.StrikeoutPosition = (int)this.FontFace.os2.yStrikeoutPosition;
			base.StrikeoutSize = (int)this.FontFace.os2.yStrikeoutSize;
			base.StemV = 0;
			base.UnitsPerEm = (int)this.FontFace.head.unitsPerEm;
			bool flag = this.FontFace.os2.sTypoAscender == 0 && this.FontFace.os2.sTypoDescender == 0 && this.FontFace.os2.sTypoLineGap == 0;
			bool flag2 = (this.FontFace.os2.fsSelection & 128) != 0;
			if (!flag && flag2)
			{
				int sTypoAscender = (int)this.FontFace.os2.sTypoAscender;
				int sTypoDescender = (int)this.FontFace.os2.sTypoDescender;
				int sTypoLineGap = (int)this.FontFace.os2.sTypoLineGap;
				base.Ascender = sTypoAscender + sTypoLineGap;
				base.Descender = -sTypoDescender;
				base.LineSpacing = sTypoAscender + sTypoLineGap - sTypoDescender;
			}
			else
			{
				int ascender = (int)this.FontFace.hhea.ascender;
				int num = (int)Math.Abs(this.FontFace.hhea.descender);
				int num2 = (int)Math.Max(0, this.FontFace.hhea.lineGap);
				if (!flag)
				{
					int usWinAscent = (int)this.FontFace.os2.usWinAscent;
					int num3 = Math.Abs((int)this.FontFace.os2.usWinDescent);
					base.Ascender = usWinAscent;
					base.Descender = num3;
					base.LineSpacing = Math.Max(num2 + ascender + num, usWinAscent + num3);
				}
				else
				{
					base.Ascender = ascender;
					base.Descender = num;
					base.LineSpacing = ascender + num + num2;
				}
			}
			int num4 = base.Ascender + base.Descender;
			int unitsPerEm = base.UnitsPerEm;
			int num5 = base.LineSpacing - num4;
			base.Leading = num5;
			if (this.FontFace.os2.version >= 2 && this.FontFace.os2.sCapHeight != 0)
			{
				base.CapHeight = (int)this.FontFace.os2.sCapHeight;
			}
			else
			{
				base.CapHeight = base.Ascender;
			}
			if (this.FontFace.os2.version >= 2 && this.FontFace.os2.sxHeight != 0)
			{
				base.XHeight = (int)this.FontFace.os2.sxHeight;
			}
			else
			{
				base.XHeight = (int)(0.66 * (double)base.Ascender);
			}
			Encoding winAnsiEncoding = PdfEncoders.WinAnsiEncoding;
			Encoding unicode = Encoding.Unicode;
			byte[] array = new byte[256];
			bool symbol = this.FontFace.cmap.symbol;
			this.Widths = new int[256];
			for (int i = 0; i < 256; i++)
			{
				array[i] = (byte)i;
				char c = (char)i;
				string @string = winAnsiEncoding.GetString(array, i, 1);
				if (@string.Length != 0 && @string[0] != c)
				{
					c = @string[0];
				}
				if (symbol)
				{
					c |= (char)(this.FontFace.os2.usFirstCharIndex & 65280);
				}
				int num6 = this.CharCodeToGlyphIndex(c);
				this.Widths[i] = this.GlyphIndexToPdfWidth(num6);
			}
		}

		// Token: 0x170002F9 RID: 761
		// (get) Token: 0x060006FD RID: 1789 RVA: 0x0001A1F8 File Offset: 0x000183F8
		public override bool IsBoldFace
		{
			get
			{
				return this.FontFace.os2.IsBold;
			}
		}

		// Token: 0x170002FA RID: 762
		// (get) Token: 0x060006FE RID: 1790 RVA: 0x0001A20A File Offset: 0x0001840A
		public override bool IsItalicFace
		{
			get
			{
				return this.FontFace.os2.IsItalic;
			}
		}

		// Token: 0x060006FF RID: 1791 RVA: 0x0001A21C File Offset: 0x0001841C
		internal int DesignUnitsToPdf(double value)
		{
			return (int)Math.Round(value * 1000.0 / (double)this.FontFace.head.unitsPerEm);
		}

		// Token: 0x06000700 RID: 1792 RVA: 0x0001A244 File Offset: 0x00018444
		public int CharCodeToGlyphIndex(char value)
		{
			int num3;
			try
			{
				CMap4 cmap = this.FontFace.cmap.cmap4;
				int num = (int)(cmap.segCountX2 / 2);
				int num2 = 0;
				while (num2 < num && value > (char)cmap.endCount[num2])
				{
					num2++;
				}
				if (value < (char)cmap.startCount[num2])
				{
					num3 = 0;
				}
				else if (cmap.idRangeOffs[num2] == 0)
				{
					num3 = (int)((value + (char)cmap.idDelta[num2]) & char.MaxValue);
				}
				else
				{
					int num4 = (int)(cmap.idRangeOffs[num2] / 2 + (ushort)(value - (char)cmap.startCount[num2])) - (num - num2);
					if (cmap.glyphIdArray[num4] == 0)
					{
						num3 = 0;
					}
					else
					{
						num3 = (int)((cmap.glyphIdArray[num4] + (ushort)cmap.idDelta[num2]) & ushort.MaxValue);
					}
				}
			}
			catch
			{
				base.GetType();
				throw;
			}
			return num3;
		}

		// Token: 0x06000701 RID: 1793 RVA: 0x0001A310 File Offset: 0x00018510
		public int GlyphIndexToPdfWidth(int glyphIndex)
		{
			int num;
			try
			{
				int numberOfHMetrics = (int)this.FontFace.hhea.numberOfHMetrics;
				int unitsPerEm = (int)this.FontFace.head.unitsPerEm;
				if (glyphIndex >= numberOfHMetrics)
				{
					glyphIndex = numberOfHMetrics - 1;
				}
				int advanceWidth = (int)this.FontFace.hmtx.Metrics[glyphIndex].advanceWidth;
				if (unitsPerEm == 1000)
				{
					num = advanceWidth;
				}
				else
				{
					num = advanceWidth * 1000 / unitsPerEm;
				}
			}
			catch (Exception)
			{
				base.GetType();
				throw;
			}
			return num;
		}

		// Token: 0x06000702 RID: 1794 RVA: 0x0001A394 File Offset: 0x00018594
		public int PdfWidthFromCharCode(char ch)
		{
			int num = this.CharCodeToGlyphIndex(ch);
			return this.GlyphIndexToPdfWidth(num);
		}

		// Token: 0x06000703 RID: 1795 RVA: 0x0001A3B4 File Offset: 0x000185B4
		public double GlyphIndexToEmfWidth(int glyphIndex, double emSize)
		{
			double num;
			try
			{
				int numberOfHMetrics = (int)this.FontFace.hhea.numberOfHMetrics;
				int unitsPerEm = (int)this.FontFace.head.unitsPerEm;
				if (glyphIndex >= numberOfHMetrics)
				{
					glyphIndex = numberOfHMetrics - 1;
				}
				int advanceWidth = (int)this.FontFace.hmtx.Metrics[glyphIndex].advanceWidth;
				num = (double)advanceWidth * emSize / (double)unitsPerEm;
			}
			catch (Exception)
			{
				base.GetType();
				throw;
			}
			return num;
		}

		// Token: 0x06000704 RID: 1796 RVA: 0x0001A42C File Offset: 0x0001862C
		public int GlyphIndexToWidth(int glyphIndex)
		{
			int num;
			try
			{
				int numberOfHMetrics = (int)this.FontFace.hhea.numberOfHMetrics;
				if (glyphIndex >= numberOfHMetrics)
				{
					glyphIndex = numberOfHMetrics - 1;
				}
				int advanceWidth = (int)this.FontFace.hmtx.Metrics[glyphIndex].advanceWidth;
				num = advanceWidth;
			}
			catch (Exception)
			{
				base.GetType();
				throw;
			}
			return num;
		}

		// Token: 0x04000319 RID: 793
		internal OpenTypeFontface FontFace;

		// Token: 0x0400031A RID: 794
		public int[] Widths;
	}
}
