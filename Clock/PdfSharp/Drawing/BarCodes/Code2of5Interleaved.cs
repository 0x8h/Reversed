using System;

namespace PdfSharp.Drawing.BarCodes
{
	// Token: 0x0200000A RID: 10
	public class Code2of5Interleaved : ThickThinBarCode
	{
		// Token: 0x06000038 RID: 56 RVA: 0x00002E5E File Offset: 0x0000105E
		public Code2of5Interleaved()
			: base("", XSize.Empty, CodeDirection.LeftToRight)
		{
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00002E71 File Offset: 0x00001071
		public Code2of5Interleaved(string code)
			: base(code, XSize.Empty, CodeDirection.LeftToRight)
		{
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00002E80 File Offset: 0x00001080
		public Code2of5Interleaved(string code, XSize size)
			: base(code, size, CodeDirection.LeftToRight)
		{
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00002E8B File Offset: 0x0000108B
		public Code2of5Interleaved(string code, XSize size, CodeDirection direction)
			: base(code, size, direction)
		{
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00002E96 File Offset: 0x00001096
		private static bool[] ThickAndThinLines(int digit)
		{
			return Code2of5Interleaved.Lines[digit];
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00002EA0 File Offset: 0x000010A0
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
				this.RenderNextPair(barCodeRenderInfo);
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

		// Token: 0x0600003E RID: 62 RVA: 0x00002F4C File Offset: 0x0000114C
		internal override void CalcThinBarWidth(BarCodeRenderInfo info)
		{
			double num = 6.0 + this.WideNarrowRatio + (2.0 * this.WideNarrowRatio + 3.0) * (double)base.Text.Length;
			info.ThinBarWidth = base.Size.Width / num;
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00002FA8 File Offset: 0x000011A8
		private void RenderStart(BarCodeRenderInfo info)
		{
			base.RenderBar(info, false);
			base.RenderGap(info, false);
			base.RenderBar(info, false);
			base.RenderGap(info, false);
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00002FCA File Offset: 0x000011CA
		private void RenderStop(BarCodeRenderInfo info)
		{
			base.RenderBar(info, true);
			base.RenderGap(info, false);
			base.RenderBar(info, false);
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00002FE4 File Offset: 0x000011E4
		private void RenderNextPair(BarCodeRenderInfo info)
		{
			int num = int.Parse(base.Text[info.CurrPosInString].ToString());
			int num2 = int.Parse(base.Text[info.CurrPosInString + 1].ToString());
			bool[] array = Code2of5Interleaved.Lines[num];
			bool[] array2 = Code2of5Interleaved.Lines[num2];
			for (int i = 0; i < 5; i++)
			{
				base.RenderBar(info, array[i]);
				base.RenderGap(info, array2[i]);
			}
			info.CurrPosInString += 2;
		}

		// Token: 0x06000042 RID: 66 RVA: 0x00003077 File Offset: 0x00001277
		protected override void CheckCode(string text)
		{
		}

		// Token: 0x06000043 RID: 67 RVA: 0x0000307C File Offset: 0x0000127C
		// Note: this type is marked as 'beforefieldinit'.
		static Code2of5Interleaved()
		{
			bool[][] array = new bool[10][];
			bool[][] array2 = array;
			int num = 0;
			bool[] array3 = new bool[5];
			array3[2] = true;
			array3[3] = true;
			array2[num] = array3;
			array[1] = new bool[]
			{
				true,
				default(bool),
				default(bool),
				default(bool),
				true
			};
			array[2] = new bool[]
			{
				default(bool),
				true,
				default(bool),
				default(bool),
				true
			};
			bool[][] array4 = array;
			int num2 = 3;
			bool[] array5 = new bool[5];
			array5[0] = true;
			array5[1] = true;
			array4[num2] = array5;
			array[4] = new bool[]
			{
				default(bool),
				default(bool),
				true,
				default(bool),
				true
			};
			bool[][] array6 = array;
			int num3 = 5;
			bool[] array7 = new bool[5];
			array7[0] = true;
			array7[2] = true;
			array6[num3] = array7;
			bool[][] array8 = array;
			int num4 = 6;
			bool[] array9 = new bool[5];
			array9[1] = true;
			array9[2] = true;
			array8[num4] = array9;
			array[7] = new bool[]
			{
				default(bool),
				default(bool),
				default(bool),
				true,
				true
			};
			bool[][] array10 = array;
			int num5 = 8;
			bool[] array11 = new bool[5];
			array11[0] = true;
			array11[3] = true;
			array10[num5] = array11;
			bool[][] array12 = array;
			int num6 = 9;
			bool[] array13 = new bool[5];
			array13[1] = true;
			array13[3] = true;
			array12[num6] = array13;
			Code2of5Interleaved.Lines = array;
		}

		// Token: 0x04000020 RID: 32
		private static bool[][] Lines;
	}
}
