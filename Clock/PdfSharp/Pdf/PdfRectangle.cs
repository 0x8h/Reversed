using System;
using System.Diagnostics;
using System.Globalization;
using PdfSharp.Drawing;
using PdfSharp.Pdf.Advanced;
using PdfSharp.Pdf.Internal;
using PdfSharp.Pdf.IO;

namespace PdfSharp.Pdf
{
	// Token: 0x020001B5 RID: 437
	[DebuggerDisplay("{DebuggerDisplay}")]
	public sealed class PdfRectangle : PdfItem
	{
		// Token: 0x06000E55 RID: 3669 RVA: 0x000385C7 File Offset: 0x000367C7
		public PdfRectangle()
		{
		}

		// Token: 0x06000E56 RID: 3670 RVA: 0x000385CF File Offset: 0x000367CF
		internal PdfRectangle(double x1, double y1, double x2, double y2)
		{
			this._x1 = x1;
			this._y1 = y1;
			this._x2 = x2;
			this._y2 = y2;
		}

		// Token: 0x06000E57 RID: 3671 RVA: 0x000385F4 File Offset: 0x000367F4
		public PdfRectangle(XPoint pt1, XPoint pt2)
		{
			this._x1 = pt1.X;
			this._y1 = pt1.Y;
			this._x2 = pt2.X;
			this._y2 = pt2.Y;
		}

		// Token: 0x06000E58 RID: 3672 RVA: 0x00038630 File Offset: 0x00036830
		public PdfRectangle(XPoint pt, XSize size)
		{
			this._x1 = pt.X;
			this._y1 = pt.Y;
			this._x2 = pt.X + size.Width;
			this._y2 = pt.Y + size.Height;
		}

		// Token: 0x06000E59 RID: 3673 RVA: 0x00038688 File Offset: 0x00036888
		public PdfRectangle(XRect rect)
		{
			this._x1 = rect.X;
			this._y1 = rect.Y;
			this._x2 = rect.X + rect.Width;
			this._y2 = rect.Y + rect.Height;
		}

		// Token: 0x06000E5A RID: 3674 RVA: 0x000386E0 File Offset: 0x000368E0
		internal PdfRectangle(PdfItem item)
		{
			if (item == null || item is PdfNull)
			{
				return;
			}
			if (item is PdfReference)
			{
				item = ((PdfReference)item).Value;
			}
			PdfArray pdfArray = item as PdfArray;
			if (pdfArray == null)
			{
				throw new InvalidOperationException(PSSR.UnexpectedTokenInPdfFile);
			}
			this._x1 = pdfArray.Elements.GetReal(0);
			this._y1 = pdfArray.Elements.GetReal(1);
			this._x2 = pdfArray.Elements.GetReal(2);
			this._y2 = pdfArray.Elements.GetReal(3);
		}

		// Token: 0x06000E5B RID: 3675 RVA: 0x00038771 File Offset: 0x00036971
		public new PdfRectangle Clone()
		{
			return (PdfRectangle)this.Copy();
		}

		// Token: 0x06000E5C RID: 3676 RVA: 0x00038780 File Offset: 0x00036980
		protected override object Copy()
		{
			return (PdfRectangle)base.Copy();
		}

		// Token: 0x170004D6 RID: 1238
		// (get) Token: 0x06000E5D RID: 3677 RVA: 0x0003879C File Offset: 0x0003699C
		public bool IsEmpty
		{
			get
			{
				return this._x1 == 0.0 && this._y1 == 0.0 && this._x2 == 0.0 && this._y2 == 0.0;
			}
		}

		// Token: 0x06000E5E RID: 3678 RVA: 0x000387F0 File Offset: 0x000369F0
		public override bool Equals(object obj)
		{
			PdfRectangle pdfRectangle = obj as PdfRectangle;
			if (pdfRectangle != null)
			{
				PdfRectangle pdfRectangle2 = pdfRectangle;
				return pdfRectangle2._x1 == this._x1 && pdfRectangle2._y1 == this._y1 && pdfRectangle2._x2 == this._x2 && pdfRectangle2._y2 == this._y2;
			}
			return false;
		}

		// Token: 0x06000E5F RID: 3679 RVA: 0x0003884C File Offset: 0x00036A4C
		public override int GetHashCode()
		{
			return (int)((uint)this._x1 ^ (((uint)this._y1 << 13) | ((uint)this._y1 >> 19)) ^ (((uint)this._x2 << 26) | ((uint)this._x2 >> 6)) ^ (((uint)this._y2 << 7) | ((uint)this._y2 >> 25)));
		}

		// Token: 0x06000E60 RID: 3680 RVA: 0x000388A0 File Offset: 0x00036AA0
		public static bool operator ==(PdfRectangle left, PdfRectangle right)
		{
			if (left != null)
			{
				return right != null && (left._x1 == right._x1 && left._y1 == right._y1 && left._x2 == right._x2) && left._y2 == right._y2;
			}
			return right == null;
		}

		// Token: 0x06000E61 RID: 3681 RVA: 0x000388F4 File Offset: 0x00036AF4
		public static bool operator !=(PdfRectangle left, PdfRectangle right)
		{
			return !(left == right);
		}

		// Token: 0x170004D7 RID: 1239
		// (get) Token: 0x06000E62 RID: 3682 RVA: 0x00038900 File Offset: 0x00036B00
		public double X1
		{
			get
			{
				return this._x1;
			}
		}

		// Token: 0x170004D8 RID: 1240
		// (get) Token: 0x06000E63 RID: 3683 RVA: 0x00038908 File Offset: 0x00036B08
		public double Y1
		{
			get
			{
				return this._y1;
			}
		}

		// Token: 0x170004D9 RID: 1241
		// (get) Token: 0x06000E64 RID: 3684 RVA: 0x00038910 File Offset: 0x00036B10
		public double X2
		{
			get
			{
				return this._x2;
			}
		}

		// Token: 0x170004DA RID: 1242
		// (get) Token: 0x06000E65 RID: 3685 RVA: 0x00038918 File Offset: 0x00036B18
		public double Y2
		{
			get
			{
				return this._y2;
			}
		}

		// Token: 0x170004DB RID: 1243
		// (get) Token: 0x06000E66 RID: 3686 RVA: 0x00038920 File Offset: 0x00036B20
		public double Width
		{
			get
			{
				return this._x2 - this._x1;
			}
		}

		// Token: 0x170004DC RID: 1244
		// (get) Token: 0x06000E67 RID: 3687 RVA: 0x0003892F File Offset: 0x00036B2F
		public double Height
		{
			get
			{
				return this._y2 - this._y1;
			}
		}

		// Token: 0x170004DD RID: 1245
		// (get) Token: 0x06000E68 RID: 3688 RVA: 0x0003893E File Offset: 0x00036B3E
		public XPoint Location
		{
			get
			{
				return new XPoint(this._x1, this._y1);
			}
		}

		// Token: 0x170004DE RID: 1246
		// (get) Token: 0x06000E69 RID: 3689 RVA: 0x00038951 File Offset: 0x00036B51
		public XSize Size
		{
			get
			{
				return new XSize(this._x2 - this._x1, this._y2 - this._y1);
			}
		}

		// Token: 0x06000E6A RID: 3690 RVA: 0x00038972 File Offset: 0x00036B72
		public bool Contains(XPoint pt)
		{
			return this.Contains(pt.X, pt.Y);
		}

		// Token: 0x06000E6B RID: 3691 RVA: 0x00038988 File Offset: 0x00036B88
		public bool Contains(double x, double y)
		{
			return this._x1 <= x && x <= this._x2 && this._y1 <= y && y <= this._y2;
		}

		// Token: 0x06000E6C RID: 3692 RVA: 0x000389B4 File Offset: 0x00036BB4
		public bool Contains(XRect rect)
		{
			return this._x1 <= rect.X && rect.X + rect.Width <= this._x2 && this._y1 <= rect.Y && rect.Y + rect.Height <= this._y2;
		}

		// Token: 0x06000E6D RID: 3693 RVA: 0x00038A12 File Offset: 0x00036C12
		public bool Contains(PdfRectangle rect)
		{
			return this._x1 <= rect._x1 && rect._x2 <= this._x2 && this._y1 <= rect._y1 && rect._y2 <= this._y2;
		}

		// Token: 0x06000E6E RID: 3694 RVA: 0x00038A51 File Offset: 0x00036C51
		public XRect ToXRect()
		{
			return new XRect(this._x1, this._y1, this.Width, this.Height);
		}

		// Token: 0x06000E6F RID: 3695 RVA: 0x00038A70 File Offset: 0x00036C70
		public override string ToString()
		{
			return PdfEncoders.Format("[{0:0.###} {1:0.###} {2:0.###} {3:0.###}]", new object[] { this._x1, this._y1, this._x2, this._y2 });
		}

		// Token: 0x06000E70 RID: 3696 RVA: 0x00038AC7 File Offset: 0x00036CC7
		internal override void WriteObject(PdfWriter writer)
		{
			writer.Write(this);
		}

		// Token: 0x170004DF RID: 1247
		// (get) Token: 0x06000E71 RID: 3697 RVA: 0x00038AD0 File Offset: 0x00036CD0
		private string DebuggerDisplay
		{
			get
			{
				return string.Format(CultureInfo.InvariantCulture, "X1={0:0.##########}, X2={1:0.##########}, Y1={2:0.##########}, Y2={3:0.##########}", new object[] { this._x1, this._y1, this.X2, this._y2 });
			}
		}

		// Token: 0x040008D7 RID: 2263
		private readonly double _x1;

		// Token: 0x040008D8 RID: 2264
		private readonly double _y1;

		// Token: 0x040008D9 RID: 2265
		private readonly double _x2;

		// Token: 0x040008DA RID: 2266
		private readonly double _y2;

		// Token: 0x040008DB RID: 2267
		public static readonly PdfRectangle Empty = new PdfRectangle();
	}
}
