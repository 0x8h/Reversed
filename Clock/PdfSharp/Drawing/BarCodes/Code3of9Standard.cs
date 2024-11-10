using System;

namespace PdfSharp.Drawing.BarCodes
{
	// Token: 0x0200000B RID: 11
	public class Code3of9Standard : ThickThinBarCode
	{
		// Token: 0x06000044 RID: 68 RVA: 0x00003172 File Offset: 0x00001372
		public Code3of9Standard()
			: base("", XSize.Empty, CodeDirection.LeftToRight)
		{
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00003185 File Offset: 0x00001385
		public Code3of9Standard(string code)
			: base(code, XSize.Empty, CodeDirection.LeftToRight)
		{
		}

		// Token: 0x06000046 RID: 70 RVA: 0x00003194 File Offset: 0x00001394
		public Code3of9Standard(string code, XSize size)
			: base(code, size, CodeDirection.LeftToRight)
		{
		}

		// Token: 0x06000047 RID: 71 RVA: 0x0000319F File Offset: 0x0000139F
		public Code3of9Standard(string code, XSize size, CodeDirection direction)
			: base(code, size, direction)
		{
		}

		// Token: 0x06000048 RID: 72 RVA: 0x000031AA File Offset: 0x000013AA
		private static bool[] ThickThinLines(char ch)
		{
			return Code3of9Standard.Lines["0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ-. $/+%*".IndexOf(ch)];
		}

		// Token: 0x06000049 RID: 73 RVA: 0x000031C0 File Offset: 0x000013C0
		internal override void CalcThinBarWidth(BarCodeRenderInfo info)
		{
			double num = 13.0 + 6.0 * this.WideNarrowRatio + (3.0 * this.WideNarrowRatio + 7.0) * (double)base.Text.Length;
			info.ThinBarWidth = base.Size.Width / num;
		}

		// Token: 0x0600004A RID: 74 RVA: 0x00003228 File Offset: 0x00001428
		protected override void CheckCode(string text)
		{
			if (text == null)
			{
				throw new ArgumentNullException("text");
			}
			if (text.Length == 0)
			{
				throw new ArgumentException(BcgSR.Invalid3Of9Code(text));
			}
			foreach (char c in text)
			{
				if ("0123456789ABCDEFGHIJKLMNOP'QRSTUVWXYZ-. $/+%*".IndexOf(c) < 0)
				{
					throw new ArgumentException(BcgSR.Invalid3Of9Code(text));
				}
			}
		}

		// Token: 0x0600004B RID: 75 RVA: 0x0000328C File Offset: 0x0000148C
		protected internal override void Render(XGraphics gfx, XBrush brush, XFont font, XPoint position)
		{
			XGraphicsState xgraphicsState = gfx.Save();
			BarCodeRenderInfo barCodeRenderInfo = new BarCodeRenderInfo(gfx, brush, font, position);
			this.InitRendering(barCodeRenderInfo);
			barCodeRenderInfo.CurrPosInString = 0;
			barCodeRenderInfo.CurrPos = position - CodeBase.CalcDistance(AnchorType.TopLeft, base.Anchor, base.Size);
			if (this.TurboBit)
			{
				base.RenderTurboBit(barCodeRenderInfo, true);
			}
			this.RenderStart(barCodeRenderInfo);
			while (barCodeRenderInfo.CurrPosInString < base.Text.Length)
			{
				this.RenderNextChar(barCodeRenderInfo);
				base.RenderGap(barCodeRenderInfo, false);
			}
			this.RenderStop(barCodeRenderInfo);
			if (this.TurboBit)
			{
				base.RenderTurboBit(barCodeRenderInfo, false);
			}
			if (base.TextLocation != TextLocation.None)
			{
				base.RenderText(barCodeRenderInfo);
			}
			gfx.Restore(xgraphicsState);
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00003340 File Offset: 0x00001540
		private void RenderNextChar(BarCodeRenderInfo info)
		{
			this.RenderChar(info, base.Text[info.CurrPosInString]);
			info.CurrPosInString++;
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00003368 File Offset: 0x00001568
		private void RenderChar(BarCodeRenderInfo info, char ch)
		{
			bool[] array = Code3of9Standard.ThickThinLines(ch);
			for (int i = 0; i < 9; i += 2)
			{
				base.RenderBar(info, array[i]);
				if (i < 8)
				{
					base.RenderGap(info, array[i + 1]);
				}
			}
		}

		// Token: 0x0600004E RID: 78 RVA: 0x000033A3 File Offset: 0x000015A3
		private void RenderStart(BarCodeRenderInfo info)
		{
			this.RenderChar(info, '*');
			base.RenderGap(info, false);
		}

		// Token: 0x0600004F RID: 79 RVA: 0x000033B6 File Offset: 0x000015B6
		private void RenderStop(BarCodeRenderInfo info)
		{
			this.RenderChar(info, '*');
		}

		// Token: 0x04000021 RID: 33
		private static readonly bool[][] Lines = new bool[][]
		{
			new bool[] { false, false, false, true, true, false, true, false, false },
			new bool[] { true, false, false, true, false, false, false, false, true },
			new bool[] { false, false, true, true, false, false, false, false, true },
			new bool[] { true, false, true, true, false, false, false, false, false },
			new bool[] { false, false, false, true, true, false, false, false, true },
			new bool[] { true, false, false, true, true, false, false, false, false },
			new bool[] { false, false, true, true, true, false, false, false, false },
			new bool[] { false, false, false, true, false, false, true, false, true },
			new bool[] { true, false, false, true, false, false, true, false, false },
			new bool[] { false, false, true, true, false, false, true, false, false },
			new bool[] { true, false, false, false, false, true, false, false, true },
			new bool[] { false, false, true, false, false, true, false, false, true },
			new bool[] { true, false, true, false, false, true, false, false, false },
			new bool[] { false, false, false, false, true, true, false, false, true },
			new bool[] { true, false, false, false, true, true, false, false, false },
			new bool[] { false, false, true, false, true, true, false, false, false },
			new bool[] { false, false, false, false, false, true, true, false, true },
			new bool[] { true, false, false, false, false, true, true, false, false },
			new bool[] { false, false, true, false, false, true, true, false, false },
			new bool[] { false, false, false, false, true, true, true, false, false },
			new bool[] { true, false, false, false, false, false, false, true, true },
			new bool[] { false, false, true, false, false, false, false, true, true },
			new bool[] { true, false, true, false, false, false, false, true, false },
			new bool[] { false, false, false, false, true, false, false, true, true },
			new bool[] { true, false, false, false, true, false, false, true, false },
			new bool[] { false, false, true, false, true, false, false, true, false },
			new bool[] { false, false, false, false, false, false, true, true, true },
			new bool[] { true, false, false, false, false, false, true, true, false },
			new bool[] { false, false, true, false, false, false, true, true, false },
			new bool[] { false, false, false, false, true, false, true, true, false },
			new bool[] { true, true, false, false, false, false, false, false, true },
			new bool[] { false, true, true, false, false, false, false, false, true },
			new bool[] { true, true, true, false, false, false, false, false, false },
			new bool[] { false, true, false, false, true, false, false, false, true },
			new bool[] { true, true, false, false, true, false, false, false, false },
			new bool[] { false, true, true, false, true, false, false, false, false },
			new bool[] { false, true, false, false, false, false, true, false, true },
			new bool[] { true, true, false, false, false, false, true, false, false },
			new bool[] { false, true, true, false, false, false, true, false, false },
			new bool[] { false, true, false, true, false, true, false, false, false },
			new bool[] { false, true, false, true, false, false, false, true, false },
			new bool[] { false, true, false, false, false, true, false, true, false },
			new bool[] { false, false, false, true, false, true, false, true, false },
			new bool[] { false, true, false, false, true, false, true, false, false }
		};
	}
}
