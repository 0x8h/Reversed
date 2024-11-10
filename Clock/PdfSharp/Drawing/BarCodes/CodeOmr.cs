using System;

namespace PdfSharp.Drawing.BarCodes
{
	// Token: 0x0200000E RID: 14
	public class CodeOmr : BarCode
	{
		// Token: 0x0600006D RID: 109 RVA: 0x00003F66 File Offset: 0x00002166
		public CodeOmr(string text, XSize size, CodeDirection direction)
			: base(text, size, direction)
		{
		}

		// Token: 0x0600006E RID: 110 RVA: 0x00003F90 File Offset: 0x00002190
		protected internal override void Render(XGraphics gfx, XBrush brush, XFont font, XPoint position)
		{
			XGraphicsState xgraphicsState = gfx.Save();
			switch (base.Direction)
			{
			case CodeDirection.BottomToTop:
				gfx.RotateAtTransform(-90.0, position);
				break;
			case CodeDirection.RightToLeft:
				gfx.RotateAtTransform(180.0, position);
				break;
			case CodeDirection.TopToBottom:
				gfx.RotateAtTransform(90.0, position);
				break;
			}
			XPoint xpoint = position - CodeBase.CalcDistance(AnchorType.TopLeft, base.Anchor, base.Size);
			uint num;
			uint.TryParse(base.Text, out num);
			num |= 1U;
			this._synchronizeCode = true;
			if (this._synchronizeCode)
			{
				XRect xrect = new XRect(xpoint.X, xpoint.Y, this._makerThickness, base.Size.Height);
				gfx.DrawRectangle(brush, xrect);
				xpoint.X += 2.0 * this._makerDistance;
			}
			for (int i = 0; i < 32; i++)
			{
				if ((num & 1U) == 1U)
				{
					XRect xrect2 = new XRect(xpoint.X + (double)i * this._makerDistance, xpoint.Y, this._makerThickness, base.Size.Height);
					gfx.DrawRectangle(brush, xrect2);
				}
				num >>= 1;
			}
			gfx.Restore(xgraphicsState);
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x0600006F RID: 111 RVA: 0x000040E5 File Offset: 0x000022E5
		// (set) Token: 0x06000070 RID: 112 RVA: 0x000040ED File Offset: 0x000022ED
		public bool SynchronizeCode
		{
			get
			{
				return this._synchronizeCode;
			}
			set
			{
				this._synchronizeCode = value;
			}
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x06000071 RID: 113 RVA: 0x000040F6 File Offset: 0x000022F6
		// (set) Token: 0x06000072 RID: 114 RVA: 0x000040FE File Offset: 0x000022FE
		public double MakerDistance
		{
			get
			{
				return this._makerDistance;
			}
			set
			{
				this._makerDistance = value;
			}
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000073 RID: 115 RVA: 0x00004107 File Offset: 0x00002307
		// (set) Token: 0x06000074 RID: 116 RVA: 0x0000410F File Offset: 0x0000230F
		public double MakerThickness
		{
			get
			{
				return this._makerThickness;
			}
			set
			{
				this._makerThickness = value;
			}
		}

		// Token: 0x06000075 RID: 117 RVA: 0x00004118 File Offset: 0x00002318
		protected override void CheckCode(string text)
		{
		}

		// Token: 0x04000027 RID: 39
		private bool _synchronizeCode;

		// Token: 0x04000028 RID: 40
		private double _makerDistance = 12.0;

		// Token: 0x04000029 RID: 41
		private double _makerThickness = 1.0;
	}
}
