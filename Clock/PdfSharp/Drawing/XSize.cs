using System;
using System.Diagnostics;
using System.Globalization;
using PdfSharp.Internal;

namespace PdfSharp.Drawing
{
	// Token: 0x0200007B RID: 123
	[DebuggerDisplay("{DebuggerDisplay}")]
	[Serializable]
	public struct XSize : IFormattable
	{
		// Token: 0x06000618 RID: 1560 RVA: 0x00017C24 File Offset: 0x00015E24
		public XSize(double width, double height)
		{
			if (width < 0.0 || height < 0.0)
			{
				throw new ArgumentException("WidthAndHeightCannotBeNegative");
			}
			this._width = width;
			this._height = height;
		}

		// Token: 0x06000619 RID: 1561 RVA: 0x00017C57 File Offset: 0x00015E57
		public static bool operator ==(XSize size1, XSize size2)
		{
			return size1.Width == size2.Width && size1.Height == size2.Height;
		}

		// Token: 0x0600061A RID: 1562 RVA: 0x00017C7B File Offset: 0x00015E7B
		public static bool operator !=(XSize size1, XSize size2)
		{
			return !(size1 == size2);
		}

		// Token: 0x0600061B RID: 1563 RVA: 0x00017C88 File Offset: 0x00015E88
		public static bool Equals(XSize size1, XSize size2)
		{
			if (size1.IsEmpty)
			{
				return size2.IsEmpty;
			}
			return size1.Width.Equals(size2.Width) && size1.Height.Equals(size2.Height);
		}

		// Token: 0x0600061C RID: 1564 RVA: 0x00017CD6 File Offset: 0x00015ED6
		public override bool Equals(object o)
		{
			return o is XSize && XSize.Equals(this, (XSize)o);
		}

		// Token: 0x0600061D RID: 1565 RVA: 0x00017CF3 File Offset: 0x00015EF3
		public bool Equals(XSize value)
		{
			return XSize.Equals(this, value);
		}

		// Token: 0x0600061E RID: 1566 RVA: 0x00017D04 File Offset: 0x00015F04
		public override int GetHashCode()
		{
			if (this.IsEmpty)
			{
				return 0;
			}
			return this.Width.GetHashCode() ^ this.Height.GetHashCode();
		}

		// Token: 0x0600061F RID: 1567 RVA: 0x00017D38 File Offset: 0x00015F38
		public static XSize Parse(string source)
		{
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			TokenizerHelper tokenizerHelper = new TokenizerHelper(source, invariantCulture);
			string text = tokenizerHelper.NextTokenRequired();
			XSize empty;
			if (text == "Empty")
			{
				empty = XSize.Empty;
			}
			else
			{
				empty = new XSize(Convert.ToDouble(text, invariantCulture), Convert.ToDouble(tokenizerHelper.NextTokenRequired(), invariantCulture));
			}
			tokenizerHelper.LastTokenRequired();
			return empty;
		}

		// Token: 0x06000620 RID: 1568 RVA: 0x00017D90 File Offset: 0x00015F90
		public XPoint ToXPoint()
		{
			return new XPoint(this._width, this._height);
		}

		// Token: 0x06000621 RID: 1569 RVA: 0x00017DA3 File Offset: 0x00015FA3
		public XVector ToXVector()
		{
			return new XVector(this._width, this._height);
		}

		// Token: 0x06000622 RID: 1570 RVA: 0x00017DB6 File Offset: 0x00015FB6
		public override string ToString()
		{
			return this.ConvertToString(null, null);
		}

		// Token: 0x06000623 RID: 1571 RVA: 0x00017DC0 File Offset: 0x00015FC0
		public string ToString(IFormatProvider provider)
		{
			return this.ConvertToString(null, provider);
		}

		// Token: 0x06000624 RID: 1572 RVA: 0x00017DCA File Offset: 0x00015FCA
		string IFormattable.ToString(string format, IFormatProvider provider)
		{
			return this.ConvertToString(format, provider);
		}

		// Token: 0x06000625 RID: 1573 RVA: 0x00017DD4 File Offset: 0x00015FD4
		internal string ConvertToString(string format, IFormatProvider provider)
		{
			if (this.IsEmpty)
			{
				return "Empty";
			}
			char numericListSeparator = TokenizerHelper.GetNumericListSeparator(provider);
			provider = provider ?? CultureInfo.InvariantCulture;
			return string.Format(provider, string.Concat(new string[] { "{1:", format, "}{0}{2:", format, "}" }), new object[] { numericListSeparator, this._width, this._height });
		}

		// Token: 0x170002B3 RID: 691
		// (get) Token: 0x06000626 RID: 1574 RVA: 0x00017E62 File Offset: 0x00016062
		public static XSize Empty
		{
			get
			{
				return XSize.s_empty;
			}
		}

		// Token: 0x170002B4 RID: 692
		// (get) Token: 0x06000627 RID: 1575 RVA: 0x00017E69 File Offset: 0x00016069
		public bool IsEmpty
		{
			get
			{
				return this._width < 0.0;
			}
		}

		// Token: 0x170002B5 RID: 693
		// (get) Token: 0x06000628 RID: 1576 RVA: 0x00017E7C File Offset: 0x0001607C
		// (set) Token: 0x06000629 RID: 1577 RVA: 0x00017E84 File Offset: 0x00016084
		public double Width
		{
			get
			{
				return this._width;
			}
			set
			{
				if (this.IsEmpty)
				{
					throw new InvalidOperationException("CannotModifyEmptySize");
				}
				if (value < 0.0)
				{
					throw new ArgumentException("WidthCannotBeNegative");
				}
				this._width = value;
			}
		}

		// Token: 0x170002B6 RID: 694
		// (get) Token: 0x0600062A RID: 1578 RVA: 0x00017EB7 File Offset: 0x000160B7
		// (set) Token: 0x0600062B RID: 1579 RVA: 0x00017EBF File Offset: 0x000160BF
		public double Height
		{
			get
			{
				return this._height;
			}
			set
			{
				if (this.IsEmpty)
				{
					throw new InvalidOperationException("CannotModifyEmptySize");
				}
				if (value < 0.0)
				{
					throw new ArgumentException("HeightCannotBeNegative");
				}
				this._height = value;
			}
		}

		// Token: 0x0600062C RID: 1580 RVA: 0x00017EF2 File Offset: 0x000160F2
		public static explicit operator XVector(XSize size)
		{
			return new XVector(size._width, size._height);
		}

		// Token: 0x0600062D RID: 1581 RVA: 0x00017F07 File Offset: 0x00016107
		public static explicit operator XPoint(XSize size)
		{
			return new XPoint(size._width, size._height);
		}

		// Token: 0x0600062E RID: 1582 RVA: 0x00017F1C File Offset: 0x0001611C
		private static XSize CreateEmptySize()
		{
			return new XSize
			{
				_width = double.NegativeInfinity,
				_height = double.NegativeInfinity
			};
		}

		// Token: 0x170002B7 RID: 695
		// (get) Token: 0x06000630 RID: 1584 RVA: 0x00017F60 File Offset: 0x00016160
		private string DebuggerDisplay
		{
			get
			{
				return string.Format(CultureInfo.InvariantCulture, "size=({2}{0:0.##########}, {1:0.##########})", new object[]
				{
					this._width,
					this._height,
					this.IsEmpty ? "Empty " : ""
				});
			}
		}

		// Token: 0x040002B3 RID: 691
		private static readonly XSize s_empty = XSize.CreateEmptySize();

		// Token: 0x040002B4 RID: 692
		private double _width;

		// Token: 0x040002B5 RID: 693
		private double _height;
	}
}
