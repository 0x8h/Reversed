using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;

namespace PdfSharp.Drawing
{
	// Token: 0x02000057 RID: 87
	[DebuggerDisplay("clr=(A={A}, R={R}, G={G}, B={B} C={C}, M={M}, Y={Y}, K={K})")]
	public struct XColor
	{
		// Token: 0x06000251 RID: 593 RVA: 0x0000C880 File Offset: 0x0000AA80
		private XColor(uint argb)
		{
			this._cs = XColorSpace.Rgb;
			this._a = (float)((byte)((argb >> 24) & 255U)) / 255f;
			this._r = (byte)((argb >> 16) & 255U);
			this._g = (byte)((argb >> 8) & 255U);
			this._b = (byte)(argb & 255U);
			this._c = 0f;
			this._m = 0f;
			this._y = 0f;
			this._k = 0f;
			this._gs = 0f;
			this.RgbChanged();
		}

		// Token: 0x06000252 RID: 594 RVA: 0x0000C918 File Offset: 0x0000AB18
		private XColor(byte alpha, byte red, byte green, byte blue)
		{
			this._cs = XColorSpace.Rgb;
			this._a = (float)alpha / 255f;
			this._r = red;
			this._g = green;
			this._b = blue;
			this._c = 0f;
			this._m = 0f;
			this._y = 0f;
			this._k = 0f;
			this._gs = 0f;
			this.RgbChanged();
		}

		// Token: 0x06000253 RID: 595 RVA: 0x0000C990 File Offset: 0x0000AB90
		private XColor(double alpha, double cyan, double magenta, double yellow, double black)
		{
			this._cs = XColorSpace.Cmyk;
			this._a = (float)((alpha > 1.0) ? 1.0 : ((alpha < 0.0) ? 0.0 : alpha));
			this._c = (float)((cyan > 1.0) ? 1.0 : ((cyan < 0.0) ? 0.0 : cyan));
			this._m = (float)((magenta > 1.0) ? 1.0 : ((magenta < 0.0) ? 0.0 : magenta));
			this._y = (float)((yellow > 1.0) ? 1.0 : ((yellow < 0.0) ? 0.0 : yellow));
			this._k = (float)((black > 1.0) ? 1.0 : ((black < 0.0) ? 0.0 : black));
			this._r = 0;
			this._g = 0;
			this._b = 0;
			this._gs = 0f;
			this.CmykChanged();
		}

		// Token: 0x06000254 RID: 596 RVA: 0x0000CADE File Offset: 0x0000ACDE
		private XColor(double cyan, double magenta, double yellow, double black)
		{
			this = new XColor(1.0, cyan, magenta, yellow, black);
		}

		// Token: 0x06000255 RID: 597 RVA: 0x0000CAF4 File Offset: 0x0000ACF4
		private XColor(double gray)
		{
			this._cs = XColorSpace.GrayScale;
			if (gray < 0.0)
			{
				this._gs = 0f;
			}
			else if (gray > 1.0)
			{
				this._gs = 1f;
			}
			this._gs = (float)gray;
			this._a = 1f;
			this._r = 0;
			this._g = 0;
			this._b = 0;
			this._c = 0f;
			this._m = 0f;
			this._y = 0f;
			this._k = 0f;
			this.GrayChanged();
		}

		// Token: 0x06000256 RID: 598 RVA: 0x0000CB92 File Offset: 0x0000AD92
		internal XColor(XKnownColor knownColor)
		{
			this = new XColor(XKnownColorTable.KnownColorToArgb(knownColor));
		}

		// Token: 0x06000257 RID: 599 RVA: 0x0000CBA0 File Offset: 0x0000ADA0
		public static XColor FromArgb(int argb)
		{
			return new XColor((byte)(argb >> 24), (byte)(argb >> 16), (byte)(argb >> 8), (byte)argb);
		}

		// Token: 0x06000258 RID: 600 RVA: 0x0000CBB7 File Offset: 0x0000ADB7
		public static XColor FromArgb(uint argb)
		{
			return new XColor((byte)(argb >> 24), (byte)(argb >> 16), (byte)(argb >> 8), (byte)argb);
		}

		// Token: 0x06000259 RID: 601 RVA: 0x0000CBCE File Offset: 0x0000ADCE
		public static XColor FromArgb(int red, int green, int blue)
		{
			XColor.CheckByte(red, "red");
			XColor.CheckByte(green, "green");
			XColor.CheckByte(blue, "blue");
			return new XColor(byte.MaxValue, (byte)red, (byte)green, (byte)blue);
		}

		// Token: 0x0600025A RID: 602 RVA: 0x0000CC01 File Offset: 0x0000AE01
		public static XColor FromArgb(int alpha, int red, int green, int blue)
		{
			XColor.CheckByte(alpha, "alpha");
			XColor.CheckByte(red, "red");
			XColor.CheckByte(green, "green");
			XColor.CheckByte(blue, "blue");
			return new XColor((byte)alpha, (byte)red, (byte)green, (byte)blue);
		}

		// Token: 0x0600025B RID: 603 RVA: 0x0000CC3C File Offset: 0x0000AE3C
		public static XColor FromArgb(int alpha, XColor color)
		{
			color.A = (double)((byte)alpha) / 255.0;
			return color;
		}

		// Token: 0x0600025C RID: 604 RVA: 0x0000CC53 File Offset: 0x0000AE53
		public static XColor FromCmyk(double cyan, double magenta, double yellow, double black)
		{
			return new XColor(cyan, magenta, yellow, black);
		}

		// Token: 0x0600025D RID: 605 RVA: 0x0000CC5E File Offset: 0x0000AE5E
		public static XColor FromCmyk(double alpha, double cyan, double magenta, double yellow, double black)
		{
			return new XColor(alpha, cyan, magenta, yellow, black);
		}

		// Token: 0x0600025E RID: 606 RVA: 0x0000CC6B File Offset: 0x0000AE6B
		public static XColor FromGrayScale(double grayScale)
		{
			return new XColor(grayScale);
		}

		// Token: 0x0600025F RID: 607 RVA: 0x0000CC73 File Offset: 0x0000AE73
		public static XColor FromKnownColor(XKnownColor color)
		{
			return new XColor(color);
		}

		// Token: 0x06000260 RID: 608 RVA: 0x0000CC7B File Offset: 0x0000AE7B
		public static XColor FromName(string name)
		{
			return XColor.Empty;
		}

		// Token: 0x170000E9 RID: 233
		// (get) Token: 0x06000261 RID: 609 RVA: 0x0000CC82 File Offset: 0x0000AE82
		// (set) Token: 0x06000262 RID: 610 RVA: 0x0000CC8A File Offset: 0x0000AE8A
		public XColorSpace ColorSpace
		{
			get
			{
				return this._cs;
			}
			set
			{
				if (!Enum.IsDefined(typeof(XColorSpace), value))
				{
					throw new InvalidEnumArgumentException("value", (int)value, typeof(XColorSpace));
				}
				this._cs = value;
			}
		}

		// Token: 0x170000EA RID: 234
		// (get) Token: 0x06000263 RID: 611 RVA: 0x0000CCC0 File Offset: 0x0000AEC0
		public bool IsEmpty
		{
			get
			{
				return this == XColor.Empty;
			}
		}

		// Token: 0x06000264 RID: 612 RVA: 0x0000CCD4 File Offset: 0x0000AED4
		public override bool Equals(object obj)
		{
			if (obj is XColor)
			{
				XColor xcolor = (XColor)obj;
				if (this._r == xcolor._r && this._g == xcolor._g && this._b == xcolor._b && this._c == xcolor._c && this._m == xcolor._m && this._y == xcolor._y && this._k == xcolor._k && this._gs == xcolor._gs)
				{
					return this._a == xcolor._a;
				}
			}
			return false;
		}

		// Token: 0x06000265 RID: 613 RVA: 0x0000CD7C File Offset: 0x0000AF7C
		public override int GetHashCode()
		{
			return (int)((byte)(this._a * 255f) ^ this._r ^ this._g ^ this._b);
		}

		// Token: 0x06000266 RID: 614 RVA: 0x0000CDA0 File Offset: 0x0000AFA0
		public static bool operator ==(XColor left, XColor right)
		{
			return left._r == right._r && left._g == right._g && left._b == right._b && left._c == right._c && left._m == right._m && left._y == right._y && left._k == right._k && left._gs == right._gs && left._a == right._a;
		}

		// Token: 0x06000267 RID: 615 RVA: 0x0000CE42 File Offset: 0x0000B042
		public static bool operator !=(XColor left, XColor right)
		{
			return !(left == right);
		}

		// Token: 0x170000EB RID: 235
		// (get) Token: 0x06000268 RID: 616 RVA: 0x0000CE4E File Offset: 0x0000B04E
		public bool IsKnownColor
		{
			get
			{
				return XKnownColorTable.IsKnownColor(this.Argb);
			}
		}

		// Token: 0x06000269 RID: 617 RVA: 0x0000CE5C File Offset: 0x0000B05C
		public double GetHue()
		{
			if (this._r == this._g && this._g == this._b)
			{
				return 0.0;
			}
			double num = (double)this._r / 255.0;
			double num2 = (double)this._g / 255.0;
			double num3 = (double)this._b / 255.0;
			double num4 = 0.0;
			double num5 = num;
			double num6 = num;
			if (num2 > num5)
			{
				num5 = num2;
			}
			if (num3 > num5)
			{
				num5 = num3;
			}
			if (num2 < num6)
			{
				num6 = num2;
			}
			if (num3 < num6)
			{
				num6 = num3;
			}
			double num7 = num5 - num6;
			if (num == num5)
			{
				num4 = (num2 - num3) / num7;
			}
			else if (num2 == num5)
			{
				num4 = 2.0 + (num3 - num) / num7;
			}
			else if (num3 == num5)
			{
				num4 = 4.0 + (num - num2) / num7;
			}
			num4 *= 60.0;
			if (num4 < 0.0)
			{
				num4 += 360.0;
			}
			return num4;
		}

		// Token: 0x0600026A RID: 618 RVA: 0x0000CF60 File Offset: 0x0000B160
		public double GetSaturation()
		{
			double num = (double)this._r / 255.0;
			double num2 = (double)this._g / 255.0;
			double num3 = (double)this._b / 255.0;
			double num4 = 0.0;
			double num5 = num;
			double num6 = num;
			if (num2 > num5)
			{
				num5 = num2;
			}
			if (num3 > num5)
			{
				num5 = num3;
			}
			if (num2 < num6)
			{
				num6 = num2;
			}
			if (num3 < num6)
			{
				num6 = num3;
			}
			if (num5 == num6)
			{
				return num4;
			}
			double num7 = (num5 + num6) / 2.0;
			if (num7 <= 0.5)
			{
				return (num5 - num6) / (num5 + num6);
			}
			return (num5 - num6) / (2.0 - num5 - num6);
		}

		// Token: 0x0600026B RID: 619 RVA: 0x0000D01C File Offset: 0x0000B21C
		public double GetBrightness()
		{
			double num = (double)this._r / 255.0;
			double num2 = (double)this._g / 255.0;
			double num3 = (double)this._b / 255.0;
			double num4 = num;
			double num5 = num;
			if (num2 > num4)
			{
				num4 = num2;
			}
			if (num3 > num4)
			{
				num4 = num3;
			}
			if (num2 < num5)
			{
				num5 = num2;
			}
			if (num3 < num5)
			{
				num5 = num3;
			}
			return (num4 + num5) / 2.0;
		}

		// Token: 0x0600026C RID: 620 RVA: 0x0000D090 File Offset: 0x0000B290
		private void RgbChanged()
		{
			this._cs = XColorSpace.Rgb;
			int num = (int)(byte.MaxValue - this._r);
			int num2 = (int)(byte.MaxValue - this._g);
			int num3 = (int)(byte.MaxValue - this._b);
			int num4 = Math.Min(num, Math.Min(num2, num3));
			if (num4 == 255)
			{
				this._c = (this._m = (this._y = 0f));
			}
			else
			{
				float num5 = 255f - (float)num4;
				this._c = (float)(num - num4) / num5;
				this._m = (float)(num2 - num4) / num5;
				this._y = (float)(num3 - num4) / num5;
			}
			this._k = (this._gs = (float)num4 / 255f);
		}

		// Token: 0x0600026D RID: 621 RVA: 0x0000D150 File Offset: 0x0000B350
		private void CmykChanged()
		{
			this._cs = XColorSpace.Cmyk;
			float num = this._k * 255f;
			float num2 = 255f - num;
			this._r = (byte)(255f - Math.Min(255f, this._c * num2 + num));
			this._g = (byte)(255f - Math.Min(255f, this._m * num2 + num));
			this._b = (byte)(255f - Math.Min(255f, this._y * num2 + num));
			this._gs = (float)(1.0 - Math.Min(1.0, (double)(0.3f * this._c + 0.59f * this._m) + 0.11 * (double)this._y + (double)this._k));
		}

		// Token: 0x0600026E RID: 622 RVA: 0x0000D230 File Offset: 0x0000B430
		private void GrayChanged()
		{
			this._cs = XColorSpace.GrayScale;
			this._r = (byte)(this._gs * 255f);
			this._g = (byte)(this._gs * 255f);
			this._b = (byte)(this._gs * 255f);
			this._c = 0f;
			this._m = 0f;
			this._y = 0f;
			this._k = 1f - this._gs;
		}

		// Token: 0x170000EC RID: 236
		// (get) Token: 0x0600026F RID: 623 RVA: 0x0000D2B0 File Offset: 0x0000B4B0
		// (set) Token: 0x06000270 RID: 624 RVA: 0x0000D2B9 File Offset: 0x0000B4B9
		public double A
		{
			get
			{
				return (double)this._a;
			}
			set
			{
				if (value < 0.0)
				{
					this._a = 0f;
					return;
				}
				if (value > 1.0)
				{
					this._a = 1f;
					return;
				}
				this._a = (float)value;
			}
		}

		// Token: 0x170000ED RID: 237
		// (get) Token: 0x06000271 RID: 625 RVA: 0x0000D2F3 File Offset: 0x0000B4F3
		// (set) Token: 0x06000272 RID: 626 RVA: 0x0000D2FB File Offset: 0x0000B4FB
		public byte R
		{
			get
			{
				return this._r;
			}
			set
			{
				this._r = value;
				this.RgbChanged();
			}
		}

		// Token: 0x170000EE RID: 238
		// (get) Token: 0x06000273 RID: 627 RVA: 0x0000D30A File Offset: 0x0000B50A
		// (set) Token: 0x06000274 RID: 628 RVA: 0x0000D312 File Offset: 0x0000B512
		public byte G
		{
			get
			{
				return this._g;
			}
			set
			{
				this._g = value;
				this.RgbChanged();
			}
		}

		// Token: 0x170000EF RID: 239
		// (get) Token: 0x06000275 RID: 629 RVA: 0x0000D321 File Offset: 0x0000B521
		// (set) Token: 0x06000276 RID: 630 RVA: 0x0000D329 File Offset: 0x0000B529
		public byte B
		{
			get
			{
				return this._b;
			}
			set
			{
				this._b = value;
				this.RgbChanged();
			}
		}

		// Token: 0x170000F0 RID: 240
		// (get) Token: 0x06000277 RID: 631 RVA: 0x0000D338 File Offset: 0x0000B538
		internal uint Rgb
		{
			get
			{
				return (uint)(((int)this._r << 16) | ((int)this._g << 8) | (int)this._b);
			}
		}

		// Token: 0x170000F1 RID: 241
		// (get) Token: 0x06000278 RID: 632 RVA: 0x0000D353 File Offset: 0x0000B553
		internal uint Argb
		{
			get
			{
				return ((uint)(this._a * 255f) << 24) | (uint)((uint)this._r << 16) | (uint)((uint)this._g << 8) | (uint)this._b;
			}
		}

		// Token: 0x170000F2 RID: 242
		// (get) Token: 0x06000279 RID: 633 RVA: 0x0000D37F File Offset: 0x0000B57F
		// (set) Token: 0x0600027A RID: 634 RVA: 0x0000D388 File Offset: 0x0000B588
		public double C
		{
			get
			{
				return (double)this._c;
			}
			set
			{
				if (value < 0.0)
				{
					this._c = 0f;
				}
				else if (value > 1.0)
				{
					this._c = 1f;
				}
				else
				{
					this._c = (float)value;
				}
				this.CmykChanged();
			}
		}

		// Token: 0x170000F3 RID: 243
		// (get) Token: 0x0600027B RID: 635 RVA: 0x0000D3D5 File Offset: 0x0000B5D5
		// (set) Token: 0x0600027C RID: 636 RVA: 0x0000D3E0 File Offset: 0x0000B5E0
		public double M
		{
			get
			{
				return (double)this._m;
			}
			set
			{
				if (value < 0.0)
				{
					this._m = 0f;
				}
				else if (value > 1.0)
				{
					this._m = 1f;
				}
				else
				{
					this._m = (float)value;
				}
				this.CmykChanged();
			}
		}

		// Token: 0x170000F4 RID: 244
		// (get) Token: 0x0600027D RID: 637 RVA: 0x0000D42D File Offset: 0x0000B62D
		// (set) Token: 0x0600027E RID: 638 RVA: 0x0000D438 File Offset: 0x0000B638
		public double Y
		{
			get
			{
				return (double)this._y;
			}
			set
			{
				if (value < 0.0)
				{
					this._y = 0f;
				}
				else if (value > 1.0)
				{
					this._y = 1f;
				}
				else
				{
					this._y = (float)value;
				}
				this.CmykChanged();
			}
		}

		// Token: 0x170000F5 RID: 245
		// (get) Token: 0x0600027F RID: 639 RVA: 0x0000D485 File Offset: 0x0000B685
		// (set) Token: 0x06000280 RID: 640 RVA: 0x0000D490 File Offset: 0x0000B690
		public double K
		{
			get
			{
				return (double)this._k;
			}
			set
			{
				if (value < 0.0)
				{
					this._k = 0f;
				}
				else if (value > 1.0)
				{
					this._k = 1f;
				}
				else
				{
					this._k = (float)value;
				}
				this.CmykChanged();
			}
		}

		// Token: 0x170000F6 RID: 246
		// (get) Token: 0x06000281 RID: 641 RVA: 0x0000D4DD File Offset: 0x0000B6DD
		// (set) Token: 0x06000282 RID: 642 RVA: 0x0000D4E8 File Offset: 0x0000B6E8
		public double GS
		{
			get
			{
				return (double)this._gs;
			}
			set
			{
				if (value < 0.0)
				{
					this._gs = 0f;
				}
				else if (value > 1.0)
				{
					this._gs = 1f;
				}
				else
				{
					this._gs = (float)value;
				}
				this.GrayChanged();
			}
		}

		// Token: 0x170000F7 RID: 247
		// (get) Token: 0x06000283 RID: 643 RVA: 0x0000D538 File Offset: 0x0000B738
		// (set) Token: 0x06000284 RID: 644 RVA: 0x0000D5DC File Offset: 0x0000B7DC
		public string RgbCmykG
		{
			get
			{
				return string.Format(CultureInfo.InvariantCulture, "{0};{1};{2};{3};{4};{5};{6};{7};{8}", new object[] { this._r, this._g, this._b, this._c, this._m, this._y, this._k, this._gs, this._a });
			}
			set
			{
				string[] array = value.Split(new char[] { ';' });
				this._r = byte.Parse(array[0], CultureInfo.InvariantCulture);
				this._g = byte.Parse(array[1], CultureInfo.InvariantCulture);
				this._b = byte.Parse(array[2], CultureInfo.InvariantCulture);
				this._c = float.Parse(array[3], CultureInfo.InvariantCulture);
				this._m = float.Parse(array[4], CultureInfo.InvariantCulture);
				this._y = float.Parse(array[5], CultureInfo.InvariantCulture);
				this._k = float.Parse(array[6], CultureInfo.InvariantCulture);
				this._gs = float.Parse(array[7], CultureInfo.InvariantCulture);
				this._a = float.Parse(array[8], CultureInfo.InvariantCulture);
			}
		}

		// Token: 0x06000285 RID: 645 RVA: 0x0000D6A8 File Offset: 0x0000B8A8
		private static void CheckByte(int val, string name)
		{
			if (val < 0 || val > 255)
			{
				throw new ArgumentException(PSSR.InvalidValue(val, name, 0, 255));
			}
		}

		// Token: 0x040001FC RID: 508
		public static XColor Empty;

		// Token: 0x040001FD RID: 509
		private XColorSpace _cs;

		// Token: 0x040001FE RID: 510
		private float _a;

		// Token: 0x040001FF RID: 511
		private byte _r;

		// Token: 0x04000200 RID: 512
		private byte _g;

		// Token: 0x04000201 RID: 513
		private byte _b;

		// Token: 0x04000202 RID: 514
		private float _c;

		// Token: 0x04000203 RID: 515
		private float _m;

		// Token: 0x04000204 RID: 516
		private float _y;

		// Token: 0x04000205 RID: 517
		private float _k;

		// Token: 0x04000206 RID: 518
		private float _gs;
	}
}
