using System;

namespace PdfSharp.Drawing.BarCodes
{
	// Token: 0x02000007 RID: 7
	internal class BarCodeRenderInfo
	{
		// Token: 0x06000021 RID: 33 RVA: 0x0000296B File Offset: 0x00000B6B
		public BarCodeRenderInfo(XGraphics gfx, XBrush brush, XFont font, XPoint position)
		{
			this.Gfx = gfx;
			this.Brush = brush;
			this.Font = font;
			this.Position = position;
		}

		// Token: 0x04000017 RID: 23
		public XGraphics Gfx;

		// Token: 0x04000018 RID: 24
		public XBrush Brush;

		// Token: 0x04000019 RID: 25
		public XFont Font;

		// Token: 0x0400001A RID: 26
		public XPoint Position;

		// Token: 0x0400001B RID: 27
		public double BarHeight;

		// Token: 0x0400001C RID: 28
		public XPoint CurrPos;

		// Token: 0x0400001D RID: 29
		public int CurrPosInString;

		// Token: 0x0400001E RID: 30
		public double ThinBarWidth;
	}
}
