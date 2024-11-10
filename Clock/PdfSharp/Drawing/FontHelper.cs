using System;
using System.Drawing;
using PdfSharp.Fonts;
using PdfSharp.Fonts.OpenType;

namespace PdfSharp.Drawing
{
	// Token: 0x02000037 RID: 55
	internal static class FontHelper
	{
		// Token: 0x06000127 RID: 295 RVA: 0x00009998 File Offset: 0x00007B98
		public static XSize MeasureString(string text, XFont font, XStringFormat stringFormat)
		{
			XSize xsize = default(XSize);
			OpenTypeDescriptor openTypeDescriptor = FontDescriptorCache.GetOrCreateDescriptorFor(font) as OpenTypeDescriptor;
			if (openTypeDescriptor != null)
			{
				xsize.Height = (double)(openTypeDescriptor.Ascender + openTypeDescriptor.Descender) * font.Size / (double)font.UnitsPerEm;
				bool symbol = openTypeDescriptor.FontFace.cmap.symbol;
				int length = text.Length;
				int num = 0;
				for (int i = 0; i < length; i++)
				{
					char c = text[i];
					if (c >= ' ')
					{
						if (symbol)
						{
							c |= (char)(openTypeDescriptor.FontFace.os2.usFirstCharIndex & 65280);
						}
						int num2 = openTypeDescriptor.CharCodeToGlyphIndex(c);
						num += openTypeDescriptor.GlyphIndexToWidth(num2);
					}
				}
				xsize.Width = (double)num * font.Size / (double)openTypeDescriptor.UnitsPerEm;
				if ((font.GlyphTypeface.StyleSimulations & XStyleSimulations.BoldSimulation) == XStyleSimulations.BoldSimulation)
				{
					xsize.Width += (double)length * font.Size * 0.02;
				}
			}
			return xsize;
		}

		// Token: 0x06000128 RID: 296 RVA: 0x00009AA0 File Offset: 0x00007CA0
		public static Font CreateFont(string familyName, double emSize, FontStyle style, out XFontSource fontSource)
		{
			fontSource = null;
			return new Font(familyName, (float)emSize, style, GraphicsUnit.World);
		}

		// Token: 0x06000129 RID: 297 RVA: 0x00009ABC File Offset: 0x00007CBC
		public static ulong CalcChecksum(byte[] buffer)
		{
			if (buffer == null)
			{
				throw new ArgumentNullException("buffer");
			}
			uint num = 0U;
			uint num2 = 0U;
			int i = buffer.Length;
			int num3 = 0;
			while (i > 0)
			{
				int num4 = 3800;
				if (num4 > i)
				{
					num4 = i;
				}
				i -= num4;
				while (--num4 >= 0)
				{
					num += (uint)buffer[num3++];
					num2 += num;
				}
				num %= 65521U;
				num2 %= 65521U;
			}
			ulong num5 = (ulong)num2 << 16;
			num5 |= (ulong)num;
			ulong num6 = (ulong)((long)buffer.Length);
			return (num5 << 32) | num6;
		}

		// Token: 0x0600012A RID: 298 RVA: 0x00009B41 File Offset: 0x00007D41
		public static XFontStyle CreateStyle(bool isBold, bool isItalic)
		{
			return (isBold ? XFontStyle.Bold : XFontStyle.Regular) | (isItalic ? XFontStyle.Italic : XFontStyle.Regular);
		}
	}
}
