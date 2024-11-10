using System;
using System.Diagnostics;
using System.Globalization;
using PdfSharp.Internal;

namespace PdfSharp.Drawing
{
	// Token: 0x0200007A RID: 122
	[DebuggerDisplay("{DebuggerDisplay}")]
	[Serializable]
	public struct XRect : IFormattable
	{
		// Token: 0x060005D5 RID: 1493 RVA: 0x00016EBC File Offset: 0x000150BC
		public XRect(double x, double y, double width, double height)
		{
			if (width < 0.0 || height < 0.0)
			{
				throw new ArgumentException("WidthAndHeightCannotBeNegative");
			}
			this._x = x;
			this._y = y;
			this._width = width;
			this._height = height;
		}

		// Token: 0x060005D6 RID: 1494 RVA: 0x00016F0C File Offset: 0x0001510C
		public XRect(XPoint point1, XPoint point2)
		{
			this._x = Math.Min(point1.X, point2.X);
			this._y = Math.Min(point1.Y, point2.Y);
			this._width = Math.Max(Math.Max(point1.X, point2.X) - this._x, 0.0);
			this._height = Math.Max(Math.Max(point1.Y, point2.Y) - this._y, 0.0);
		}

		// Token: 0x060005D7 RID: 1495 RVA: 0x00016FA7 File Offset: 0x000151A7
		public XRect(XPoint point, XVector vector)
		{
			this = new XRect(point, point + vector);
		}

		// Token: 0x060005D8 RID: 1496 RVA: 0x00016FB8 File Offset: 0x000151B8
		public XRect(XPoint location, XSize size)
		{
			if (size.IsEmpty)
			{
				this = XRect.s_empty;
				return;
			}
			this._x = location.X;
			this._y = location.Y;
			this._width = size.Width;
			this._height = size.Height;
		}

		// Token: 0x060005D9 RID: 1497 RVA: 0x00017010 File Offset: 0x00015210
		public XRect(XSize size)
		{
			if (size.IsEmpty)
			{
				this = XRect.s_empty;
				return;
			}
			this._x = (this._y = 0.0);
			this._width = size.Width;
			this._height = size.Height;
		}

		// Token: 0x060005DA RID: 1498 RVA: 0x00017064 File Offset: 0x00015264
		public static XRect FromLTRB(double left, double top, double right, double bottom)
		{
			return new XRect(left, top, right - left, bottom - top);
		}

		// Token: 0x060005DB RID: 1499 RVA: 0x00017074 File Offset: 0x00015274
		public static bool operator ==(XRect rect1, XRect rect2)
		{
			return rect1.X == rect2.X && rect1.Y == rect2.Y && rect1.Width == rect2.Width && rect1.Height == rect2.Height;
		}

		// Token: 0x060005DC RID: 1500 RVA: 0x000170C3 File Offset: 0x000152C3
		public static bool operator !=(XRect rect1, XRect rect2)
		{
			return !(rect1 == rect2);
		}

		// Token: 0x060005DD RID: 1501 RVA: 0x000170D0 File Offset: 0x000152D0
		public static bool Equals(XRect rect1, XRect rect2)
		{
			if (rect1.IsEmpty)
			{
				return rect2.IsEmpty;
			}
			return rect1.X.Equals(rect2.X) && rect1.Y.Equals(rect2.Y) && rect1.Width.Equals(rect2.Width) && rect1.Height.Equals(rect2.Height);
		}

		// Token: 0x060005DE RID: 1502 RVA: 0x0001714E File Offset: 0x0001534E
		public override bool Equals(object o)
		{
			return o is XRect && XRect.Equals(this, (XRect)o);
		}

		// Token: 0x060005DF RID: 1503 RVA: 0x0001716B File Offset: 0x0001536B
		public bool Equals(XRect value)
		{
			return XRect.Equals(this, value);
		}

		// Token: 0x060005E0 RID: 1504 RVA: 0x0001717C File Offset: 0x0001537C
		public override int GetHashCode()
		{
			if (this.IsEmpty)
			{
				return 0;
			}
			return this.X.GetHashCode() ^ this.Y.GetHashCode() ^ this.Width.GetHashCode() ^ this.Height.GetHashCode();
		}

		// Token: 0x060005E1 RID: 1505 RVA: 0x000171D0 File Offset: 0x000153D0
		public static XRect Parse(string source)
		{
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			TokenizerHelper tokenizerHelper = new TokenizerHelper(source, invariantCulture);
			string text = tokenizerHelper.NextTokenRequired();
			XRect empty;
			if (text == "Empty")
			{
				empty = XRect.Empty;
			}
			else
			{
				empty = new XRect(Convert.ToDouble(text, invariantCulture), Convert.ToDouble(tokenizerHelper.NextTokenRequired(), invariantCulture), Convert.ToDouble(tokenizerHelper.NextTokenRequired(), invariantCulture), Convert.ToDouble(tokenizerHelper.NextTokenRequired(), invariantCulture));
			}
			tokenizerHelper.LastTokenRequired();
			return empty;
		}

		// Token: 0x060005E2 RID: 1506 RVA: 0x00017240 File Offset: 0x00015440
		public override string ToString()
		{
			return this.ConvertToString(null, null);
		}

		// Token: 0x060005E3 RID: 1507 RVA: 0x0001724A File Offset: 0x0001544A
		public string ToString(IFormatProvider provider)
		{
			return this.ConvertToString(null, provider);
		}

		// Token: 0x060005E4 RID: 1508 RVA: 0x00017254 File Offset: 0x00015454
		string IFormattable.ToString(string format, IFormatProvider provider)
		{
			return this.ConvertToString(format, provider);
		}

		// Token: 0x060005E5 RID: 1509 RVA: 0x00017260 File Offset: 0x00015460
		internal string ConvertToString(string format, IFormatProvider provider)
		{
			if (this.IsEmpty)
			{
				return "Empty";
			}
			char numericListSeparator = TokenizerHelper.GetNumericListSeparator(provider);
			provider = provider ?? CultureInfo.InvariantCulture;
			return string.Format(provider, string.Concat(new string[] { "{1:", format, "}{0}{2:", format, "}{0}{3:", format, "}{0}{4:", format, "}" }), new object[] { numericListSeparator, this._x, this._y, this._width, this._height });
		}

		// Token: 0x170002A1 RID: 673
		// (get) Token: 0x060005E6 RID: 1510 RVA: 0x00017323 File Offset: 0x00015523
		public static XRect Empty
		{
			get
			{
				return XRect.s_empty;
			}
		}

		// Token: 0x170002A2 RID: 674
		// (get) Token: 0x060005E7 RID: 1511 RVA: 0x0001732A File Offset: 0x0001552A
		public bool IsEmpty
		{
			get
			{
				return this._width < 0.0;
			}
		}

		// Token: 0x170002A3 RID: 675
		// (get) Token: 0x060005E8 RID: 1512 RVA: 0x0001733D File Offset: 0x0001553D
		// (set) Token: 0x060005E9 RID: 1513 RVA: 0x00017350 File Offset: 0x00015550
		public XPoint Location
		{
			get
			{
				return new XPoint(this._x, this._y);
			}
			set
			{
				if (this.IsEmpty)
				{
					throw new InvalidOperationException("CannotModifyEmptyRect");
				}
				this._x = value.X;
				this._y = value.Y;
			}
		}

		// Token: 0x170002A4 RID: 676
		// (get) Token: 0x060005EA RID: 1514 RVA: 0x0001737F File Offset: 0x0001557F
		// (set) Token: 0x060005EB RID: 1515 RVA: 0x000173A0 File Offset: 0x000155A0
		public XSize Size
		{
			get
			{
				if (this.IsEmpty)
				{
					return XSize.Empty;
				}
				return new XSize(this._width, this._height);
			}
			set
			{
				if (value.IsEmpty)
				{
					this = XRect.s_empty;
					return;
				}
				if (this.IsEmpty)
				{
					throw new InvalidOperationException("CannotModifyEmptyRect");
				}
				this._width = value.Width;
				this._height = value.Height;
			}
		}

		// Token: 0x170002A5 RID: 677
		// (get) Token: 0x060005EC RID: 1516 RVA: 0x000173EF File Offset: 0x000155EF
		// (set) Token: 0x060005ED RID: 1517 RVA: 0x000173F7 File Offset: 0x000155F7
		public double X
		{
			get
			{
				return this._x;
			}
			set
			{
				if (this.IsEmpty)
				{
					throw new InvalidOperationException("CannotModifyEmptyRect");
				}
				this._x = value;
			}
		}

		// Token: 0x170002A6 RID: 678
		// (get) Token: 0x060005EE RID: 1518 RVA: 0x00017413 File Offset: 0x00015613
		// (set) Token: 0x060005EF RID: 1519 RVA: 0x0001741B File Offset: 0x0001561B
		public double Y
		{
			get
			{
				return this._y;
			}
			set
			{
				if (this.IsEmpty)
				{
					throw new InvalidOperationException("CannotModifyEmptyRect");
				}
				this._y = value;
			}
		}

		// Token: 0x170002A7 RID: 679
		// (get) Token: 0x060005F0 RID: 1520 RVA: 0x00017437 File Offset: 0x00015637
		// (set) Token: 0x060005F1 RID: 1521 RVA: 0x0001743F File Offset: 0x0001563F
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
					throw new InvalidOperationException("CannotModifyEmptyRect");
				}
				if (value < 0.0)
				{
					throw new ArgumentException("WidthCannotBeNegative");
				}
				this._width = value;
			}
		}

		// Token: 0x170002A8 RID: 680
		// (get) Token: 0x060005F2 RID: 1522 RVA: 0x00017472 File Offset: 0x00015672
		// (set) Token: 0x060005F3 RID: 1523 RVA: 0x0001747A File Offset: 0x0001567A
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
					throw new InvalidOperationException("CannotModifyEmptyRect");
				}
				if (value < 0.0)
				{
					throw new ArgumentException("WidthCannotBeNegative");
				}
				this._height = value;
			}
		}

		// Token: 0x170002A9 RID: 681
		// (get) Token: 0x060005F4 RID: 1524 RVA: 0x000174AD File Offset: 0x000156AD
		public double Left
		{
			get
			{
				return this._x;
			}
		}

		// Token: 0x170002AA RID: 682
		// (get) Token: 0x060005F5 RID: 1525 RVA: 0x000174B5 File Offset: 0x000156B5
		public double Top
		{
			get
			{
				return this._y;
			}
		}

		// Token: 0x170002AB RID: 683
		// (get) Token: 0x060005F6 RID: 1526 RVA: 0x000174BD File Offset: 0x000156BD
		public double Right
		{
			get
			{
				if (this.IsEmpty)
				{
					return double.NegativeInfinity;
				}
				return this._x + this._width;
			}
		}

		// Token: 0x170002AC RID: 684
		// (get) Token: 0x060005F7 RID: 1527 RVA: 0x000174DE File Offset: 0x000156DE
		public double Bottom
		{
			get
			{
				if (this.IsEmpty)
				{
					return double.NegativeInfinity;
				}
				return this._y + this._height;
			}
		}

		// Token: 0x170002AD RID: 685
		// (get) Token: 0x060005F8 RID: 1528 RVA: 0x000174FF File Offset: 0x000156FF
		public XPoint TopLeft
		{
			get
			{
				return new XPoint(this.Left, this.Top);
			}
		}

		// Token: 0x170002AE RID: 686
		// (get) Token: 0x060005F9 RID: 1529 RVA: 0x00017512 File Offset: 0x00015712
		public XPoint TopRight
		{
			get
			{
				return new XPoint(this.Right, this.Top);
			}
		}

		// Token: 0x170002AF RID: 687
		// (get) Token: 0x060005FA RID: 1530 RVA: 0x00017525 File Offset: 0x00015725
		public XPoint BottomLeft
		{
			get
			{
				return new XPoint(this.Left, this.Bottom);
			}
		}

		// Token: 0x170002B0 RID: 688
		// (get) Token: 0x060005FB RID: 1531 RVA: 0x00017538 File Offset: 0x00015738
		public XPoint BottomRight
		{
			get
			{
				return new XPoint(this.Right, this.Bottom);
			}
		}

		// Token: 0x170002B1 RID: 689
		// (get) Token: 0x060005FC RID: 1532 RVA: 0x0001754B File Offset: 0x0001574B
		public XPoint Center
		{
			get
			{
				return new XPoint(this._x + this._width / 2.0, this._y + this._height / 2.0);
			}
		}

		// Token: 0x060005FD RID: 1533 RVA: 0x00017580 File Offset: 0x00015780
		public bool Contains(XPoint point)
		{
			return this.Contains(point.X, point.Y);
		}

		// Token: 0x060005FE RID: 1534 RVA: 0x00017596 File Offset: 0x00015796
		public bool Contains(double x, double y)
		{
			return !this.IsEmpty && this.ContainsInternal(x, y);
		}

		// Token: 0x060005FF RID: 1535 RVA: 0x000175AC File Offset: 0x000157AC
		public bool Contains(XRect rect)
		{
			return !this.IsEmpty && !rect.IsEmpty && this._x <= rect._x && this._y <= rect._y && this._x + this._width >= rect._x + rect._width && this._y + this._height >= rect._y + rect._height;
		}

		// Token: 0x06000600 RID: 1536 RVA: 0x0001762C File Offset: 0x0001582C
		public bool IntersectsWith(XRect rect)
		{
			return !this.IsEmpty && !rect.IsEmpty && rect.Left <= this.Right && rect.Right >= this.Left && rect.Top <= this.Bottom && rect.Bottom >= this.Top;
		}

		// Token: 0x06000601 RID: 1537 RVA: 0x0001768C File Offset: 0x0001588C
		public void Intersect(XRect rect)
		{
			if (!this.IntersectsWith(rect))
			{
				this = XRect.Empty;
				return;
			}
			double num = Math.Max(this.Left, rect.Left);
			double num2 = Math.Max(this.Top, rect.Top);
			this._width = Math.Max(Math.Min(this.Right, rect.Right) - num, 0.0);
			this._height = Math.Max(Math.Min(this.Bottom, rect.Bottom) - num2, 0.0);
			this._x = num;
			this._y = num2;
		}

		// Token: 0x06000602 RID: 1538 RVA: 0x00017732 File Offset: 0x00015932
		public static XRect Intersect(XRect rect1, XRect rect2)
		{
			rect1.Intersect(rect2);
			return rect1;
		}

		// Token: 0x06000603 RID: 1539 RVA: 0x00017740 File Offset: 0x00015940
		public void Union(XRect rect)
		{
			if (this.IsEmpty)
			{
				this = rect;
				return;
			}
			if (!rect.IsEmpty)
			{
				double num = Math.Min(this.Left, rect.Left);
				double num2 = Math.Min(this.Top, rect.Top);
				if (rect.Width == double.PositiveInfinity || this.Width == double.PositiveInfinity)
				{
					this._width = double.PositiveInfinity;
				}
				else
				{
					double num3 = Math.Max(this.Right, rect.Right);
					this._width = Math.Max(num3 - num, 0.0);
				}
				if (rect.Height == double.PositiveInfinity || this._height == double.PositiveInfinity)
				{
					this._height = double.PositiveInfinity;
				}
				else
				{
					double num4 = Math.Max(this.Bottom, rect.Bottom);
					this._height = Math.Max(num4 - num2, 0.0);
				}
				this._x = num;
				this._y = num2;
			}
		}

		// Token: 0x06000604 RID: 1540 RVA: 0x00017859 File Offset: 0x00015A59
		public static XRect Union(XRect rect1, XRect rect2)
		{
			rect1.Union(rect2);
			return rect1;
		}

		// Token: 0x06000605 RID: 1541 RVA: 0x00017864 File Offset: 0x00015A64
		public void Union(XPoint point)
		{
			this.Union(new XRect(point, point));
		}

		// Token: 0x06000606 RID: 1542 RVA: 0x00017873 File Offset: 0x00015A73
		public static XRect Union(XRect rect, XPoint point)
		{
			rect.Union(new XRect(point, point));
			return rect;
		}

		// Token: 0x06000607 RID: 1543 RVA: 0x00017884 File Offset: 0x00015A84
		public void Offset(XVector offsetVector)
		{
			if (this.IsEmpty)
			{
				throw new InvalidOperationException("CannotCallMethod");
			}
			this._x += offsetVector.X;
			this._y += offsetVector.Y;
		}

		// Token: 0x06000608 RID: 1544 RVA: 0x000178C1 File Offset: 0x00015AC1
		public void Offset(double offsetX, double offsetY)
		{
			if (this.IsEmpty)
			{
				throw new InvalidOperationException("CannotCallMethod");
			}
			this._x += offsetX;
			this._y += offsetY;
		}

		// Token: 0x06000609 RID: 1545 RVA: 0x000178F2 File Offset: 0x00015AF2
		public static XRect Offset(XRect rect, XVector offsetVector)
		{
			rect.Offset(offsetVector.X, offsetVector.Y);
			return rect;
		}

		// Token: 0x0600060A RID: 1546 RVA: 0x0001790A File Offset: 0x00015B0A
		public static XRect Offset(XRect rect, double offsetX, double offsetY)
		{
			rect.Offset(offsetX, offsetY);
			return rect;
		}

		// Token: 0x0600060B RID: 1547 RVA: 0x00017916 File Offset: 0x00015B16
		public static XRect operator +(XRect rect, XPoint point)
		{
			return new XRect(rect._x + point.X, rect.Y + point.Y, rect._width, rect._height);
		}

		// Token: 0x0600060C RID: 1548 RVA: 0x00017949 File Offset: 0x00015B49
		public static XRect operator -(XRect rect, XPoint point)
		{
			return new XRect(rect._x - point.X, rect.Y - point.Y, rect._width, rect._height);
		}

		// Token: 0x0600060D RID: 1549 RVA: 0x0001797C File Offset: 0x00015B7C
		public void Inflate(XSize size)
		{
			this.Inflate(size.Width, size.Height);
		}

		// Token: 0x0600060E RID: 1550 RVA: 0x00017994 File Offset: 0x00015B94
		public void Inflate(double width, double height)
		{
			if (this.IsEmpty)
			{
				throw new InvalidOperationException("CannotCallMethod");
			}
			this._x -= width;
			this._y -= height;
			this._width += width;
			this._width += width;
			this._height += height;
			this._height += height;
			if (this._width < 0.0 || this._height < 0.0)
			{
				this = XRect.s_empty;
			}
		}

		// Token: 0x0600060F RID: 1551 RVA: 0x00017A35 File Offset: 0x00015C35
		public static XRect Inflate(XRect rect, XSize size)
		{
			rect.Inflate(size.Width, size.Height);
			return rect;
		}

		// Token: 0x06000610 RID: 1552 RVA: 0x00017A4D File Offset: 0x00015C4D
		public static XRect Inflate(XRect rect, double width, double height)
		{
			rect.Inflate(width, height);
			return rect;
		}

		// Token: 0x06000611 RID: 1553 RVA: 0x00017A59 File Offset: 0x00015C59
		public static XRect Transform(XRect rect, XMatrix matrix)
		{
			XMatrix.MatrixHelper.TransformRect(ref rect, ref matrix);
			return rect;
		}

		// Token: 0x06000612 RID: 1554 RVA: 0x00017A65 File Offset: 0x00015C65
		public void Transform(XMatrix matrix)
		{
			XMatrix.MatrixHelper.TransformRect(ref this, ref matrix);
		}

		// Token: 0x06000613 RID: 1555 RVA: 0x00017A70 File Offset: 0x00015C70
		public void Scale(double scaleX, double scaleY)
		{
			if (!this.IsEmpty)
			{
				this._x *= scaleX;
				this._y *= scaleY;
				this._width *= scaleX;
				this._height *= scaleY;
				if (scaleX < 0.0)
				{
					this._x += this._width;
					this._width *= -1.0;
				}
				if (scaleY < 0.0)
				{
					this._y += this._height;
					this._height *= -1.0;
				}
			}
		}

		// Token: 0x06000614 RID: 1556 RVA: 0x00017B2A File Offset: 0x00015D2A
		private bool ContainsInternal(double x, double y)
		{
			return x >= this._x && x - this._width <= this._x && y >= this._y && y - this._height <= this._y;
		}

		// Token: 0x06000615 RID: 1557 RVA: 0x00017B64 File Offset: 0x00015D64
		private static XRect CreateEmptyRect()
		{
			return new XRect
			{
				_x = double.PositiveInfinity,
				_y = double.PositiveInfinity,
				_width = double.NegativeInfinity,
				_height = double.NegativeInfinity
			};
		}

		// Token: 0x170002B2 RID: 690
		// (get) Token: 0x06000617 RID: 1559 RVA: 0x00017BC8 File Offset: 0x00015DC8
		private string DebuggerDisplay
		{
			get
			{
				return string.Format(CultureInfo.InvariantCulture, "rect=({0:0.##########}, {1:0.##########}, {2:0.##########}, {3:0.##########})", new object[] { this._x, this._y, this._width, this._height });
			}
		}

		// Token: 0x040002AE RID: 686
		private double _x;

		// Token: 0x040002AF RID: 687
		private double _y;

		// Token: 0x040002B0 RID: 688
		private double _width;

		// Token: 0x040002B1 RID: 689
		private double _height;

		// Token: 0x040002B2 RID: 690
		private static readonly XRect s_empty = XRect.CreateEmptyRect();
	}
}
