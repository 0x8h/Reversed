using System;
using System.Diagnostics;
using System.Globalization;
using PdfSharp.Internal;

namespace PdfSharp.Drawing
{
	// Token: 0x02000078 RID: 120
	[DebuggerDisplay("{DebuggerDisplay}")]
	[Serializable]
	public struct XPoint : IFormattable
	{
		// Token: 0x060005AD RID: 1453 RVA: 0x00016A08 File Offset: 0x00014C08
		public XPoint(double x, double y)
		{
			this._x = x;
			this._y = y;
		}

		// Token: 0x060005AE RID: 1454 RVA: 0x00016A18 File Offset: 0x00014C18
		public static bool operator ==(XPoint point1, XPoint point2)
		{
			return point1._x == point2._x && point1._y == point2._y;
		}

		// Token: 0x060005AF RID: 1455 RVA: 0x00016A3C File Offset: 0x00014C3C
		public static bool operator !=(XPoint point1, XPoint point2)
		{
			return !(point1 == point2);
		}

		// Token: 0x060005B0 RID: 1456 RVA: 0x00016A48 File Offset: 0x00014C48
		public static bool Equals(XPoint point1, XPoint point2)
		{
			return point1.X.Equals(point2.X) && point1.Y.Equals(point2.Y);
		}

		// Token: 0x060005B1 RID: 1457 RVA: 0x00016A85 File Offset: 0x00014C85
		public override bool Equals(object o)
		{
			return o is XPoint && XPoint.Equals(this, (XPoint)o);
		}

		// Token: 0x060005B2 RID: 1458 RVA: 0x00016AA2 File Offset: 0x00014CA2
		public bool Equals(XPoint value)
		{
			return XPoint.Equals(this, value);
		}

		// Token: 0x060005B3 RID: 1459 RVA: 0x00016AB0 File Offset: 0x00014CB0
		public override int GetHashCode()
		{
			return this.X.GetHashCode() ^ this.Y.GetHashCode();
		}

		// Token: 0x060005B4 RID: 1460 RVA: 0x00016ADC File Offset: 0x00014CDC
		public static XPoint Parse(string source)
		{
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			TokenizerHelper tokenizerHelper = new TokenizerHelper(source, invariantCulture);
			string text = tokenizerHelper.NextTokenRequired();
			XPoint xpoint = new XPoint(Convert.ToDouble(text, invariantCulture), Convert.ToDouble(tokenizerHelper.NextTokenRequired(), invariantCulture));
			tokenizerHelper.LastTokenRequired();
			return xpoint;
		}

		// Token: 0x060005B5 RID: 1461 RVA: 0x00016B20 File Offset: 0x00014D20
		public static XPoint[] ParsePoints(string value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			string[] array = value.Split(new char[] { ' ' });
			int num = array.Length;
			XPoint[] array2 = new XPoint[num];
			for (int i = 0; i < num; i++)
			{
				array2[i] = XPoint.Parse(array[i]);
			}
			return array2;
		}

		// Token: 0x1700029D RID: 669
		// (get) Token: 0x060005B6 RID: 1462 RVA: 0x00016B7E File Offset: 0x00014D7E
		// (set) Token: 0x060005B7 RID: 1463 RVA: 0x00016B86 File Offset: 0x00014D86
		public double X
		{
			get
			{
				return this._x;
			}
			set
			{
				this._x = value;
			}
		}

		// Token: 0x1700029E RID: 670
		// (get) Token: 0x060005B8 RID: 1464 RVA: 0x00016B8F File Offset: 0x00014D8F
		// (set) Token: 0x060005B9 RID: 1465 RVA: 0x00016B97 File Offset: 0x00014D97
		public double Y
		{
			get
			{
				return this._y;
			}
			set
			{
				this._y = value;
			}
		}

		// Token: 0x060005BA RID: 1466 RVA: 0x00016BA0 File Offset: 0x00014DA0
		public override string ToString()
		{
			return this.ConvertToString(null, null);
		}

		// Token: 0x060005BB RID: 1467 RVA: 0x00016BAA File Offset: 0x00014DAA
		public string ToString(IFormatProvider provider)
		{
			return this.ConvertToString(null, provider);
		}

		// Token: 0x060005BC RID: 1468 RVA: 0x00016BB4 File Offset: 0x00014DB4
		string IFormattable.ToString(string format, IFormatProvider provider)
		{
			return this.ConvertToString(format, provider);
		}

		// Token: 0x060005BD RID: 1469 RVA: 0x00016BC0 File Offset: 0x00014DC0
		internal string ConvertToString(string format, IFormatProvider provider)
		{
			char numericListSeparator = TokenizerHelper.GetNumericListSeparator(provider);
			provider = provider ?? CultureInfo.InvariantCulture;
			return string.Format(provider, string.Concat(new string[] { "{1:", format, "}{0}{2:", format, "}" }), new object[] { numericListSeparator, this._x, this._y });
		}

		// Token: 0x060005BE RID: 1470 RVA: 0x00016C40 File Offset: 0x00014E40
		public void Offset(double offsetX, double offsetY)
		{
			this._x += offsetX;
			this._y += offsetY;
		}

		// Token: 0x060005BF RID: 1471 RVA: 0x00016C5E File Offset: 0x00014E5E
		public static XPoint operator +(XPoint point, XVector vector)
		{
			return new XPoint(point._x + vector.X, point._y + vector.Y);
		}

		// Token: 0x060005C0 RID: 1472 RVA: 0x00016C83 File Offset: 0x00014E83
		public static XPoint operator +(XPoint point, XSize size)
		{
			return new XPoint(point._x + size.Width, point._y + size.Height);
		}

		// Token: 0x060005C1 RID: 1473 RVA: 0x00016CA8 File Offset: 0x00014EA8
		public static XPoint Add(XPoint point, XVector vector)
		{
			return new XPoint(point._x + vector.X, point._y + vector.Y);
		}

		// Token: 0x060005C2 RID: 1474 RVA: 0x00016CCD File Offset: 0x00014ECD
		public static XPoint operator -(XPoint point, XVector vector)
		{
			return new XPoint(point._x - vector.X, point._y - vector.Y);
		}

		// Token: 0x060005C3 RID: 1475 RVA: 0x00016CF2 File Offset: 0x00014EF2
		public static XPoint Subtract(XPoint point, XVector vector)
		{
			return new XPoint(point._x - vector.X, point._y - vector.Y);
		}

		// Token: 0x060005C4 RID: 1476 RVA: 0x00016D17 File Offset: 0x00014F17
		public static XVector operator -(XPoint point1, XPoint point2)
		{
			return new XVector(point1._x - point2._x, point1._y - point2._y);
		}

		// Token: 0x060005C5 RID: 1477 RVA: 0x00016D3C File Offset: 0x00014F3C
		[Obsolete("Use XVector instead of XSize as second parameter.")]
		public static XPoint operator -(XPoint point, XSize size)
		{
			return new XPoint(point._x - size.Width, point._y - size.Height);
		}

		// Token: 0x060005C6 RID: 1478 RVA: 0x00016D61 File Offset: 0x00014F61
		public static XVector Subtract(XPoint point1, XPoint point2)
		{
			return new XVector(point1._x - point2._x, point1._y - point2._y);
		}

		// Token: 0x060005C7 RID: 1479 RVA: 0x00016D86 File Offset: 0x00014F86
		public static XPoint operator *(XPoint point, XMatrix matrix)
		{
			return matrix.Transform(point);
		}

		// Token: 0x060005C8 RID: 1480 RVA: 0x00016D90 File Offset: 0x00014F90
		public static XPoint Multiply(XPoint point, XMatrix matrix)
		{
			return matrix.Transform(point);
		}

		// Token: 0x060005C9 RID: 1481 RVA: 0x00016D9A File Offset: 0x00014F9A
		public static XPoint operator *(XPoint point, double value)
		{
			return new XPoint(point._x * value, point._y * value);
		}

		// Token: 0x060005CA RID: 1482 RVA: 0x00016DB3 File Offset: 0x00014FB3
		public static XPoint operator *(double value, XPoint point)
		{
			return new XPoint(value * point._x, value * point._y);
		}

		// Token: 0x060005CB RID: 1483 RVA: 0x00016DCC File Offset: 0x00014FCC
		public static explicit operator XSize(XPoint point)
		{
			return new XSize(Math.Abs(point._x), Math.Abs(point._y));
		}

		// Token: 0x060005CC RID: 1484 RVA: 0x00016DEB File Offset: 0x00014FEB
		public static explicit operator XVector(XPoint point)
		{
			return new XVector(point._x, point._y);
		}

		// Token: 0x1700029F RID: 671
		// (get) Token: 0x060005CD RID: 1485 RVA: 0x00016E00 File Offset: 0x00015000
		private string DebuggerDisplay
		{
			get
			{
				return string.Format(CultureInfo.InvariantCulture, "point=({0:0.##########}, {1:0.##########})", new object[] { this._x, this._y });
			}
		}

		// Token: 0x040002AA RID: 682
		private double _x;

		// Token: 0x040002AB RID: 683
		private double _y;
	}
}
