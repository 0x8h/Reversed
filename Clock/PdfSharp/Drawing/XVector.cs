using System;
using System.Diagnostics;
using System.Globalization;
using PdfSharp.Internal;

namespace PdfSharp.Drawing
{
	// Token: 0x02000080 RID: 128
	[DebuggerDisplay("{DebuggerDisplay}")]
	[Serializable]
	public struct XVector : IFormattable
	{
		// Token: 0x06000673 RID: 1651 RVA: 0x00018AB8 File Offset: 0x00016CB8
		public XVector(double x, double y)
		{
			this._x = x;
			this._y = y;
		}

		// Token: 0x06000674 RID: 1652 RVA: 0x00018AC8 File Offset: 0x00016CC8
		public static bool operator ==(XVector vector1, XVector vector2)
		{
			return vector1._x == vector2._x && vector1._y == vector2._y;
		}

		// Token: 0x06000675 RID: 1653 RVA: 0x00018AEC File Offset: 0x00016CEC
		public static bool operator !=(XVector vector1, XVector vector2)
		{
			return vector1._x != vector2._x || vector1._y != vector2._y;
		}

		// Token: 0x06000676 RID: 1654 RVA: 0x00018B14 File Offset: 0x00016D14
		public static bool Equals(XVector vector1, XVector vector2)
		{
			return vector1.X.Equals(vector2.X) && vector1.Y.Equals(vector2.Y);
		}

		// Token: 0x06000677 RID: 1655 RVA: 0x00018B51 File Offset: 0x00016D51
		public override bool Equals(object o)
		{
			return o is XVector && XVector.Equals(this, (XVector)o);
		}

		// Token: 0x06000678 RID: 1656 RVA: 0x00018B6E File Offset: 0x00016D6E
		public bool Equals(XVector value)
		{
			return XVector.Equals(this, value);
		}

		// Token: 0x06000679 RID: 1657 RVA: 0x00018B7C File Offset: 0x00016D7C
		public override int GetHashCode()
		{
			return this._x.GetHashCode() ^ this._y.GetHashCode();
		}

		// Token: 0x0600067A RID: 1658 RVA: 0x00018B98 File Offset: 0x00016D98
		public static XVector Parse(string source)
		{
			TokenizerHelper tokenizerHelper = new TokenizerHelper(source, CultureInfo.InvariantCulture);
			string text = tokenizerHelper.NextTokenRequired();
			XVector xvector = new XVector(Convert.ToDouble(text, CultureInfo.InvariantCulture), Convert.ToDouble(tokenizerHelper.NextTokenRequired(), CultureInfo.InvariantCulture));
			tokenizerHelper.LastTokenRequired();
			return xvector;
		}

		// Token: 0x170002D6 RID: 726
		// (get) Token: 0x0600067B RID: 1659 RVA: 0x00018BE1 File Offset: 0x00016DE1
		// (set) Token: 0x0600067C RID: 1660 RVA: 0x00018BE9 File Offset: 0x00016DE9
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

		// Token: 0x170002D7 RID: 727
		// (get) Token: 0x0600067D RID: 1661 RVA: 0x00018BF2 File Offset: 0x00016DF2
		// (set) Token: 0x0600067E RID: 1662 RVA: 0x00018BFA File Offset: 0x00016DFA
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

		// Token: 0x0600067F RID: 1663 RVA: 0x00018C03 File Offset: 0x00016E03
		public override string ToString()
		{
			return this.ConvertToString(null, null);
		}

		// Token: 0x06000680 RID: 1664 RVA: 0x00018C0D File Offset: 0x00016E0D
		public string ToString(IFormatProvider provider)
		{
			return this.ConvertToString(null, provider);
		}

		// Token: 0x06000681 RID: 1665 RVA: 0x00018C17 File Offset: 0x00016E17
		string IFormattable.ToString(string format, IFormatProvider provider)
		{
			return this.ConvertToString(format, provider);
		}

		// Token: 0x06000682 RID: 1666 RVA: 0x00018C24 File Offset: 0x00016E24
		internal string ConvertToString(string format, IFormatProvider provider)
		{
			provider = provider ?? CultureInfo.InvariantCulture;
			return string.Format(provider, string.Concat(new string[] { "{1:", format, "}{0}{2:", format, "}" }), new object[] { ',', this._x, this._y });
		}

		// Token: 0x170002D8 RID: 728
		// (get) Token: 0x06000683 RID: 1667 RVA: 0x00018C9E File Offset: 0x00016E9E
		public double Length
		{
			get
			{
				return Math.Sqrt(this._x * this._x + this._y * this._y);
			}
		}

		// Token: 0x170002D9 RID: 729
		// (get) Token: 0x06000684 RID: 1668 RVA: 0x00018CC0 File Offset: 0x00016EC0
		public double LengthSquared
		{
			get
			{
				return this._x * this._x + this._y * this._y;
			}
		}

		// Token: 0x06000685 RID: 1669 RVA: 0x00018CE0 File Offset: 0x00016EE0
		public void Normalize()
		{
			this /= Math.Max(Math.Abs(this._x), Math.Abs(this._y));
			this /= this.Length;
		}

		// Token: 0x06000686 RID: 1670 RVA: 0x00018D30 File Offset: 0x00016F30
		public static double CrossProduct(XVector vector1, XVector vector2)
		{
			return vector1._x * vector2._y - vector1._y * vector2._x;
		}

		// Token: 0x06000687 RID: 1671 RVA: 0x00018D54 File Offset: 0x00016F54
		public static double AngleBetween(XVector vector1, XVector vector2)
		{
			double num = vector1._x * vector2._y - vector2._x * vector1._y;
			double num2 = vector1._x * vector2._x + vector1._y * vector2._y;
			return Math.Atan2(num, num2) * 57.295779513082323;
		}

		// Token: 0x06000688 RID: 1672 RVA: 0x00018DB2 File Offset: 0x00016FB2
		public static XVector operator -(XVector vector)
		{
			return new XVector(-vector._x, -vector._y);
		}

		// Token: 0x06000689 RID: 1673 RVA: 0x00018DC9 File Offset: 0x00016FC9
		public void Negate()
		{
			this._x = -this._x;
			this._y = -this._y;
		}

		// Token: 0x0600068A RID: 1674 RVA: 0x00018DE5 File Offset: 0x00016FE5
		public static XVector operator +(XVector vector1, XVector vector2)
		{
			return new XVector(vector1._x + vector2._x, vector1._y + vector2._y);
		}

		// Token: 0x0600068B RID: 1675 RVA: 0x00018E0A File Offset: 0x0001700A
		public static XVector Add(XVector vector1, XVector vector2)
		{
			return new XVector(vector1._x + vector2._x, vector1._y + vector2._y);
		}

		// Token: 0x0600068C RID: 1676 RVA: 0x00018E2F File Offset: 0x0001702F
		public static XVector operator -(XVector vector1, XVector vector2)
		{
			return new XVector(vector1._x - vector2._x, vector1._y - vector2._y);
		}

		// Token: 0x0600068D RID: 1677 RVA: 0x00018E54 File Offset: 0x00017054
		public static XVector Subtract(XVector vector1, XVector vector2)
		{
			return new XVector(vector1._x - vector2._x, vector1._y - vector2._y);
		}

		// Token: 0x0600068E RID: 1678 RVA: 0x00018E79 File Offset: 0x00017079
		public static XPoint operator +(XVector vector, XPoint point)
		{
			return new XPoint(point.X + vector._x, point.Y + vector._y);
		}

		// Token: 0x0600068F RID: 1679 RVA: 0x00018E9E File Offset: 0x0001709E
		public static XPoint Add(XVector vector, XPoint point)
		{
			return new XPoint(point.X + vector._x, point.Y + vector._y);
		}

		// Token: 0x06000690 RID: 1680 RVA: 0x00018EC3 File Offset: 0x000170C3
		public static XVector operator *(XVector vector, double scalar)
		{
			return new XVector(vector._x * scalar, vector._y * scalar);
		}

		// Token: 0x06000691 RID: 1681 RVA: 0x00018EDC File Offset: 0x000170DC
		public static XVector Multiply(XVector vector, double scalar)
		{
			return new XVector(vector._x * scalar, vector._y * scalar);
		}

		// Token: 0x06000692 RID: 1682 RVA: 0x00018EF5 File Offset: 0x000170F5
		public static XVector operator *(double scalar, XVector vector)
		{
			return new XVector(vector._x * scalar, vector._y * scalar);
		}

		// Token: 0x06000693 RID: 1683 RVA: 0x00018F0E File Offset: 0x0001710E
		public static XVector Multiply(double scalar, XVector vector)
		{
			return new XVector(vector._x * scalar, vector._y * scalar);
		}

		// Token: 0x06000694 RID: 1684 RVA: 0x00018F27 File Offset: 0x00017127
		public static XVector operator /(XVector vector, double scalar)
		{
			return vector * (1.0 / scalar);
		}

		// Token: 0x06000695 RID: 1685 RVA: 0x00018F3A File Offset: 0x0001713A
		public static XVector Divide(XVector vector, double scalar)
		{
			return vector * (1.0 / scalar);
		}

		// Token: 0x06000696 RID: 1686 RVA: 0x00018F4D File Offset: 0x0001714D
		public static XVector operator *(XVector vector, XMatrix matrix)
		{
			return matrix.Transform(vector);
		}

		// Token: 0x06000697 RID: 1687 RVA: 0x00018F57 File Offset: 0x00017157
		public static XVector Multiply(XVector vector, XMatrix matrix)
		{
			return matrix.Transform(vector);
		}

		// Token: 0x06000698 RID: 1688 RVA: 0x00018F61 File Offset: 0x00017161
		public static double operator *(XVector vector1, XVector vector2)
		{
			return vector1._x * vector2._x + vector1._y * vector2._y;
		}

		// Token: 0x06000699 RID: 1689 RVA: 0x00018F82 File Offset: 0x00017182
		public static double Multiply(XVector vector1, XVector vector2)
		{
			return vector1._x * vector2._x + vector1._y * vector2._y;
		}

		// Token: 0x0600069A RID: 1690 RVA: 0x00018FA3 File Offset: 0x000171A3
		public static double Determinant(XVector vector1, XVector vector2)
		{
			return vector1._x * vector2._y - vector1._y * vector2._x;
		}

		// Token: 0x0600069B RID: 1691 RVA: 0x00018FC4 File Offset: 0x000171C4
		public static explicit operator XSize(XVector vector)
		{
			return new XSize(Math.Abs(vector._x), Math.Abs(vector._y));
		}

		// Token: 0x0600069C RID: 1692 RVA: 0x00018FE3 File Offset: 0x000171E3
		public static explicit operator XPoint(XVector vector)
		{
			return new XPoint(vector._x, vector._y);
		}

		// Token: 0x170002DA RID: 730
		// (get) Token: 0x0600069D RID: 1693 RVA: 0x00018FF8 File Offset: 0x000171F8
		private string DebuggerDisplay
		{
			get
			{
				return string.Format(CultureInfo.InvariantCulture, "vector=({0:0.##########}, {1:0.##########})", new object[] { this._x, this._y });
			}
		}

		// Token: 0x040002C8 RID: 712
		private double _x;

		// Token: 0x040002C9 RID: 713
		private double _y;
	}
}
