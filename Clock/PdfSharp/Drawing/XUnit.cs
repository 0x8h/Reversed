using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;

namespace PdfSharp.Drawing
{
	// Token: 0x0200007F RID: 127
	[DebuggerDisplay("{DebuggerDisplay}")]
	public struct XUnit : IFormattable
	{
		// Token: 0x06000650 RID: 1616 RVA: 0x0001824A File Offset: 0x0001644A
		public XUnit(double point)
		{
			this._value = point;
			this._type = XGraphicsUnit.Point;
		}

		// Token: 0x06000651 RID: 1617 RVA: 0x0001825A File Offset: 0x0001645A
		public XUnit(double value, XGraphicsUnit type)
		{
			if (!Enum.IsDefined(typeof(XGraphicsUnit), type))
			{
				throw new InvalidEnumArgumentException("type");
			}
			this._value = value;
			this._type = type;
		}

		// Token: 0x170002CE RID: 718
		// (get) Token: 0x06000652 RID: 1618 RVA: 0x0001828C File Offset: 0x0001648C
		public double Value
		{
			get
			{
				return this._value;
			}
		}

		// Token: 0x170002CF RID: 719
		// (get) Token: 0x06000653 RID: 1619 RVA: 0x00018294 File Offset: 0x00016494
		public XGraphicsUnit Type
		{
			get
			{
				return this._type;
			}
		}

		// Token: 0x170002D0 RID: 720
		// (get) Token: 0x06000654 RID: 1620 RVA: 0x0001829C File Offset: 0x0001649C
		// (set) Token: 0x06000655 RID: 1621 RVA: 0x0001833A File Offset: 0x0001653A
		public double Point
		{
			get
			{
				switch (this._type)
				{
				case XGraphicsUnit.Point:
					return this._value;
				case XGraphicsUnit.Inch:
					return this._value * 72.0;
				case XGraphicsUnit.Millimeter:
					return this._value * 72.0 / 25.4;
				case XGraphicsUnit.Centimeter:
					return this._value * 72.0 / 2.54;
				case XGraphicsUnit.Presentation:
					return this._value * 72.0 / 96.0;
				default:
					throw new InvalidCastException();
				}
			}
			set
			{
				this._value = value;
				this._type = XGraphicsUnit.Point;
			}
		}

		// Token: 0x170002D1 RID: 721
		// (get) Token: 0x06000656 RID: 1622 RVA: 0x0001834C File Offset: 0x0001654C
		// (set) Token: 0x06000657 RID: 1623 RVA: 0x000183CC File Offset: 0x000165CC
		public double Inch
		{
			get
			{
				switch (this._type)
				{
				case XGraphicsUnit.Point:
					return this._value / 72.0;
				case XGraphicsUnit.Inch:
					return this._value;
				case XGraphicsUnit.Millimeter:
					return this._value / 25.4;
				case XGraphicsUnit.Centimeter:
					return this._value / 2.54;
				case XGraphicsUnit.Presentation:
					return this._value / 96.0;
				default:
					throw new InvalidCastException();
				}
			}
			set
			{
				this._value = value;
				this._type = XGraphicsUnit.Inch;
			}
		}

		// Token: 0x170002D2 RID: 722
		// (get) Token: 0x06000658 RID: 1624 RVA: 0x000183DC File Offset: 0x000165DC
		// (set) Token: 0x06000659 RID: 1625 RVA: 0x00018470 File Offset: 0x00016670
		public double Millimeter
		{
			get
			{
				switch (this._type)
				{
				case XGraphicsUnit.Point:
					return this._value * 25.4 / 72.0;
				case XGraphicsUnit.Inch:
					return this._value * 25.4;
				case XGraphicsUnit.Millimeter:
					return this._value;
				case XGraphicsUnit.Centimeter:
					return this._value * 10.0;
				case XGraphicsUnit.Presentation:
					return this._value * 25.4 / 96.0;
				default:
					throw new InvalidCastException();
				}
			}
			set
			{
				this._value = value;
				this._type = XGraphicsUnit.Millimeter;
			}
		}

		// Token: 0x170002D3 RID: 723
		// (get) Token: 0x0600065A RID: 1626 RVA: 0x00018480 File Offset: 0x00016680
		// (set) Token: 0x0600065B RID: 1627 RVA: 0x00018514 File Offset: 0x00016714
		public double Centimeter
		{
			get
			{
				switch (this._type)
				{
				case XGraphicsUnit.Point:
					return this._value * 2.54 / 72.0;
				case XGraphicsUnit.Inch:
					return this._value * 2.54;
				case XGraphicsUnit.Millimeter:
					return this._value / 10.0;
				case XGraphicsUnit.Centimeter:
					return this._value;
				case XGraphicsUnit.Presentation:
					return this._value * 2.54 / 96.0;
				default:
					throw new InvalidCastException();
				}
			}
			set
			{
				this._value = value;
				this._type = XGraphicsUnit.Centimeter;
			}
		}

		// Token: 0x170002D4 RID: 724
		// (get) Token: 0x0600065C RID: 1628 RVA: 0x00018524 File Offset: 0x00016724
		// (set) Token: 0x0600065D RID: 1629 RVA: 0x000185C2 File Offset: 0x000167C2
		public double Presentation
		{
			get
			{
				switch (this._type)
				{
				case XGraphicsUnit.Point:
					return this._value * 96.0 / 72.0;
				case XGraphicsUnit.Inch:
					return this._value * 96.0;
				case XGraphicsUnit.Millimeter:
					return this._value * 96.0 / 25.4;
				case XGraphicsUnit.Centimeter:
					return this._value * 96.0 / 2.54;
				case XGraphicsUnit.Presentation:
					return this._value;
				default:
					throw new InvalidCastException();
				}
			}
			set
			{
				this._value = value;
				this._type = XGraphicsUnit.Point;
			}
		}

		// Token: 0x0600065E RID: 1630 RVA: 0x000185D4 File Offset: 0x000167D4
		public string ToString(IFormatProvider formatProvider)
		{
			return this._value.ToString(formatProvider) + this.GetSuffix();
		}

		// Token: 0x0600065F RID: 1631 RVA: 0x000185FC File Offset: 0x000167FC
		string IFormattable.ToString(string format, IFormatProvider formatProvider)
		{
			return this._value.ToString(format, formatProvider) + this.GetSuffix();
		}

		// Token: 0x06000660 RID: 1632 RVA: 0x00018624 File Offset: 0x00016824
		public override string ToString()
		{
			return this._value.ToString(CultureInfo.InvariantCulture) + this.GetSuffix();
		}

		// Token: 0x06000661 RID: 1633 RVA: 0x00018650 File Offset: 0x00016850
		private string GetSuffix()
		{
			switch (this._type)
			{
			case XGraphicsUnit.Point:
				return "pt";
			case XGraphicsUnit.Inch:
				return "in";
			case XGraphicsUnit.Millimeter:
				return "mm";
			case XGraphicsUnit.Centimeter:
				return "cm";
			case XGraphicsUnit.Presentation:
				return "pu";
			default:
				throw new InvalidCastException();
			}
		}

		// Token: 0x06000662 RID: 1634 RVA: 0x000186A4 File Offset: 0x000168A4
		public static XUnit FromPoint(double value)
		{
			XUnit xunit;
			xunit._value = value;
			xunit._type = XGraphicsUnit.Point;
			return xunit;
		}

		// Token: 0x06000663 RID: 1635 RVA: 0x000186C4 File Offset: 0x000168C4
		public static XUnit FromInch(double value)
		{
			XUnit xunit;
			xunit._value = value;
			xunit._type = XGraphicsUnit.Inch;
			return xunit;
		}

		// Token: 0x06000664 RID: 1636 RVA: 0x000186E4 File Offset: 0x000168E4
		public static XUnit FromMillimeter(double value)
		{
			XUnit xunit;
			xunit._value = value;
			xunit._type = XGraphicsUnit.Millimeter;
			return xunit;
		}

		// Token: 0x06000665 RID: 1637 RVA: 0x00018704 File Offset: 0x00016904
		public static XUnit FromCentimeter(double value)
		{
			XUnit xunit;
			xunit._value = value;
			xunit._type = XGraphicsUnit.Centimeter;
			return xunit;
		}

		// Token: 0x06000666 RID: 1638 RVA: 0x00018724 File Offset: 0x00016924
		public static XUnit FromPresentation(double value)
		{
			XUnit xunit;
			xunit._value = value;
			xunit._type = XGraphicsUnit.Presentation;
			return xunit;
		}

		// Token: 0x06000667 RID: 1639 RVA: 0x00018744 File Offset: 0x00016944
		public static implicit operator XUnit(string value)
		{
			value = value.Trim();
			value = value.Replace(',', '.');
			int length = value.Length;
			int i;
			for (i = 0; i < length; i++)
			{
				char c = value[i];
				if (c != '.' && c != '-' && c != '+' && !char.IsNumber(c))
				{
					break;
				}
			}
			XUnit xunit;
			try
			{
				xunit._value = double.Parse(value.Substring(0, i).Trim(), CultureInfo.InvariantCulture);
			}
			catch (Exception ex)
			{
				xunit._value = 1.0;
				string text = string.Format("String '{0}' is not a valid value for structure 'XUnit'.", value);
				throw new ArgumentException(text, ex);
			}
			string text2 = value.Substring(i).Trim().ToLower();
			xunit._type = XGraphicsUnit.Point;
			string text3;
			if ((text3 = text2) != null)
			{
				if (<PrivateImplementationDetails>{38BCE920-7A10-4305-84EF-382AE1AA8677}.$$method0x600065e-1 == null)
				{
					<PrivateImplementationDetails>{38BCE920-7A10-4305-84EF-382AE1AA8677}.$$method0x600065e-1 = new Dictionary<string, int>(6)
					{
						{ "cm", 0 },
						{ "in", 1 },
						{ "mm", 2 },
						{ "", 3 },
						{ "pt", 4 },
						{ "pu", 5 }
					};
				}
				int num;
				if (<PrivateImplementationDetails>{38BCE920-7A10-4305-84EF-382AE1AA8677}.$$method0x600065e-1.TryGetValue(text3, out num))
				{
					switch (num)
					{
					case 0:
						xunit._type = XGraphicsUnit.Centimeter;
						break;
					case 1:
						xunit._type = XGraphicsUnit.Inch;
						break;
					case 2:
						xunit._type = XGraphicsUnit.Millimeter;
						break;
					case 3:
					case 4:
						xunit._type = XGraphicsUnit.Point;
						break;
					case 5:
						xunit._type = XGraphicsUnit.Presentation;
						break;
					default:
						goto IL_177;
					}
					return xunit;
				}
			}
			IL_177:
			throw new ArgumentException("Unknown unit type: '" + text2 + "'");
		}

		// Token: 0x06000668 RID: 1640 RVA: 0x000188F0 File Offset: 0x00016AF0
		public static implicit operator XUnit(int value)
		{
			XUnit xunit;
			xunit._value = (double)value;
			xunit._type = XGraphicsUnit.Point;
			return xunit;
		}

		// Token: 0x06000669 RID: 1641 RVA: 0x00018910 File Offset: 0x00016B10
		public static implicit operator XUnit(double value)
		{
			XUnit xunit;
			xunit._value = value;
			xunit._type = XGraphicsUnit.Point;
			return xunit;
		}

		// Token: 0x0600066A RID: 1642 RVA: 0x0001892E File Offset: 0x00016B2E
		public static implicit operator double(XUnit value)
		{
			return value.Point;
		}

		// Token: 0x0600066B RID: 1643 RVA: 0x00018937 File Offset: 0x00016B37
		public static bool operator ==(XUnit value1, XUnit value2)
		{
			return value1._type == value2._type && value1._value == value2._value;
		}

		// Token: 0x0600066C RID: 1644 RVA: 0x0001895B File Offset: 0x00016B5B
		public static bool operator !=(XUnit value1, XUnit value2)
		{
			return !(value1 == value2);
		}

		// Token: 0x0600066D RID: 1645 RVA: 0x00018967 File Offset: 0x00016B67
		public override bool Equals(object obj)
		{
			return obj is XUnit && this == (XUnit)obj;
		}

		// Token: 0x0600066E RID: 1646 RVA: 0x00018984 File Offset: 0x00016B84
		public override int GetHashCode()
		{
			return this._value.GetHashCode() ^ this._type.GetHashCode();
		}

		// Token: 0x0600066F RID: 1647 RVA: 0x000189A4 File Offset: 0x00016BA4
		public static XUnit Parse(string value)
		{
			return value;
		}

		// Token: 0x06000670 RID: 1648 RVA: 0x000189BC File Offset: 0x00016BBC
		public void ConvertType(XGraphicsUnit type)
		{
			if (this._type == type)
			{
				return;
			}
			switch (type)
			{
			case XGraphicsUnit.Point:
				this._value = this.Point;
				this._type = XGraphicsUnit.Point;
				return;
			case XGraphicsUnit.Inch:
				this._value = this.Inch;
				this._type = XGraphicsUnit.Inch;
				return;
			case XGraphicsUnit.Millimeter:
				this._value = this.Millimeter;
				this._type = XGraphicsUnit.Millimeter;
				return;
			case XGraphicsUnit.Centimeter:
				this._value = this.Centimeter;
				this._type = XGraphicsUnit.Centimeter;
				return;
			case XGraphicsUnit.Presentation:
				this._value = this.Presentation;
				this._type = XGraphicsUnit.Presentation;
				return;
			default:
				throw new ArgumentException("Unknown unit type: '" + type + "'");
			}
		}

		// Token: 0x170002D5 RID: 725
		// (get) Token: 0x06000671 RID: 1649 RVA: 0x00018A70 File Offset: 0x00016C70
		private string DebuggerDisplay
		{
			get
			{
				return string.Format(CultureInfo.InvariantCulture, "unit=({0:0.##########} {1})", new object[]
				{
					this._value,
					this.GetSuffix()
				});
			}
		}

		// Token: 0x040002BB RID: 699
		internal const double PointFactor = 1.0;

		// Token: 0x040002BC RID: 700
		internal const double InchFactor = 72.0;

		// Token: 0x040002BD RID: 701
		internal const double MillimeterFactor = 2.8346456692913389;

		// Token: 0x040002BE RID: 702
		internal const double CentimeterFactor = 28.346456692913385;

		// Token: 0x040002BF RID: 703
		internal const double PresentationFactor = 0.75;

		// Token: 0x040002C0 RID: 704
		internal const double PointFactorWpf = 1.3333333333333333;

		// Token: 0x040002C1 RID: 705
		internal const double InchFactorWpf = 96.0;

		// Token: 0x040002C2 RID: 706
		internal const double MillimeterFactorWpf = 3.7795275590551185;

		// Token: 0x040002C3 RID: 707
		internal const double CentimeterFactorWpf = 37.795275590551178;

		// Token: 0x040002C4 RID: 708
		internal const double PresentationFactorWpf = 1.0;

		// Token: 0x040002C5 RID: 709
		public static readonly XUnit Zero = default(XUnit);

		// Token: 0x040002C6 RID: 710
		private double _value;

		// Token: 0x040002C7 RID: 711
		private XGraphicsUnit _type;
	}
}
