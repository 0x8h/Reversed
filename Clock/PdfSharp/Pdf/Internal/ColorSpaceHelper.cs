using System;
using PdfSharp.Drawing;

namespace PdfSharp.Pdf.Internal
{
	// Token: 0x02000161 RID: 353
	internal static class ColorSpaceHelper
	{
		// Token: 0x06000BAE RID: 2990 RVA: 0x0002E7FC File Offset: 0x0002C9FC
		public static XColor EnsureColorMode(PdfColorMode colorMode, XColor color)
		{
			if (colorMode == PdfColorMode.Rgb && color.ColorSpace != XColorSpace.Rgb)
			{
				return XColor.FromArgb((int)(color.A * 255.0), (int)color.R, (int)color.G, (int)color.B);
			}
			if (colorMode == PdfColorMode.Cmyk && color.ColorSpace != XColorSpace.Cmyk)
			{
				return XColor.FromCmyk(color.A, color.C, color.M, color.Y, color.K);
			}
			return color;
		}

		// Token: 0x06000BAF RID: 2991 RVA: 0x0002E87B File Offset: 0x0002CA7B
		public static XColor EnsureColorMode(PdfDocument document, XColor color)
		{
			if (document == null)
			{
				throw new ArgumentNullException("document");
			}
			return ColorSpaceHelper.EnsureColorMode(document.Options.ColorMode, color);
		}

		// Token: 0x06000BB0 RID: 2992 RVA: 0x0002E89C File Offset: 0x0002CA9C
		public static bool IsEqualCmyk(XColor x, XColor y)
		{
			return x.ColorSpace == XColorSpace.Cmyk && y.ColorSpace == XColorSpace.Cmyk && (x.C == y.C && x.M == y.M && x.Y == y.Y) && x.K == y.K;
		}
	}
}
