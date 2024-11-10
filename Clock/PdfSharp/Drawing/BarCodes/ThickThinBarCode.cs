using System;

namespace PdfSharp.Drawing.BarCodes
{
	// Token: 0x02000009 RID: 9
	public abstract class ThickThinBarCode : BarCode
	{
		// Token: 0x0600002E RID: 46 RVA: 0x00002A08 File Offset: 0x00000C08
		public ThickThinBarCode(string code, XSize size, CodeDirection direction)
			: base(code, size, direction)
		{
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00002A24 File Offset: 0x00000C24
		internal override void InitRendering(BarCodeRenderInfo info)
		{
			base.InitRendering(info);
			this.CalcThinBarWidth(info);
			info.BarHeight = base.Size.Height;
			if (base.TextLocation != TextLocation.None)
			{
				info.BarHeight *= 0.8;
			}
			switch (base.Direction)
			{
			case CodeDirection.BottomToTop:
				info.Gfx.RotateAtTransform(-90.0, info.Position);
				return;
			case CodeDirection.RightToLeft:
				info.Gfx.RotateAtTransform(180.0, info.Position);
				return;
			case CodeDirection.TopToBottom:
				info.Gfx.RotateAtTransform(90.0, info.Position);
				return;
			default:
				return;
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000030 RID: 48 RVA: 0x00002ADD File Offset: 0x00000CDD
		// (set) Token: 0x06000031 RID: 49 RVA: 0x00002AE5 File Offset: 0x00000CE5
		public override double WideNarrowRatio
		{
			get
			{
				return this._wideNarrowRatio;
			}
			set
			{
				if (value > 3.0 || value < 2.0)
				{
					throw new ArgumentOutOfRangeException("value", BcgSR.Invalid2of5Relation);
				}
				this._wideNarrowRatio = value;
			}
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00002B18 File Offset: 0x00000D18
		internal void RenderBar(BarCodeRenderInfo info, bool isThick)
		{
			double barWidth = this.GetBarWidth(info, isThick);
			double num = base.Size.Height;
			double x = info.CurrPos.X;
			double num2 = info.CurrPos.Y;
			switch (base.TextLocation)
			{
			case TextLocation.AboveEmbedded:
				num -= info.Gfx.MeasureString(base.Text, info.Font).Height;
				num2 += info.Gfx.MeasureString(base.Text, info.Font).Height;
				break;
			case TextLocation.BelowEmbedded:
				num -= info.Gfx.MeasureString(base.Text, info.Font).Height;
				break;
			}
			XRect xrect = new XRect(x, num2, barWidth, num);
			info.Gfx.DrawRectangle(info.Brush, xrect);
			info.CurrPos.X = info.CurrPos.X + barWidth;
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00002C0D File Offset: 0x00000E0D
		internal void RenderGap(BarCodeRenderInfo info, bool isThick)
		{
			info.CurrPos.X = info.CurrPos.X + this.GetBarWidth(info, isThick);
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00002C2C File Offset: 0x00000E2C
		internal void RenderTurboBit(BarCodeRenderInfo info, bool startBit)
		{
			if (startBit)
			{
				info.CurrPos.X = info.CurrPos.X - (0.5 + this.GetBarWidth(info, true));
			}
			else
			{
				info.CurrPos.X = info.CurrPos.X + 0.5;
			}
			this.RenderBar(info, true);
			if (startBit)
			{
				info.CurrPos.X = info.CurrPos.X + 0.5;
			}
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00002CA4 File Offset: 0x00000EA4
		internal void RenderText(BarCodeRenderInfo info)
		{
			if (info.Font == null)
			{
				info.Font = new XFont("Courier New", base.Size.Height / 6.0);
			}
			XPoint xpoint = info.Position + CodeBase.CalcDistance(base.Anchor, AnchorType.TopLeft, base.Size);
			switch (base.TextLocation)
			{
			case TextLocation.Above:
				xpoint = new XPoint(xpoint.X, xpoint.Y - info.Gfx.MeasureString(base.Text, info.Font).Height);
				info.Gfx.DrawString(base.Text, info.Font, info.Brush, new XRect(xpoint, base.Size), XStringFormats.TopCenter);
				return;
			case TextLocation.Below:
				xpoint = new XPoint(xpoint.X, info.Gfx.MeasureString(base.Text, info.Font).Height + xpoint.Y);
				info.Gfx.DrawString(base.Text, info.Font, info.Brush, new XRect(xpoint, base.Size), XStringFormats.BottomCenter);
				return;
			case TextLocation.AboveEmbedded:
				info.Gfx.DrawString(base.Text, info.Font, info.Brush, new XRect(xpoint, base.Size), XStringFormats.TopCenter);
				return;
			case TextLocation.BelowEmbedded:
				info.Gfx.DrawString(base.Text, info.Font, info.Brush, new XRect(xpoint, base.Size), XStringFormats.BottomCenter);
				return;
			default:
				return;
			}
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00002E45 File Offset: 0x00001045
		internal double GetBarWidth(BarCodeRenderInfo info, bool isThick)
		{
			if (isThick)
			{
				return info.ThinBarWidth * this._wideNarrowRatio;
			}
			return info.ThinBarWidth;
		}

		// Token: 0x06000037 RID: 55
		internal abstract void CalcThinBarWidth(BarCodeRenderInfo info);

		// Token: 0x0400001F RID: 31
		private double _wideNarrowRatio = 2.6;
	}
}
