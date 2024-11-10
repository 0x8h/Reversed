using System;

namespace PdfSharp.Drawing.BarCodes
{
	// Token: 0x0200000D RID: 13
	public class CodeDataMatrix : MatrixCode
	{
		// Token: 0x0600005E RID: 94 RVA: 0x00003B42 File Offset: 0x00001D42
		public CodeDataMatrix()
			: this("", "", 26, 26, 0, XSize.Empty)
		{
		}

		// Token: 0x0600005F RID: 95 RVA: 0x00003B5E File Offset: 0x00001D5E
		public CodeDataMatrix(string code, int length)
			: this(code, "", length, length, 0, XSize.Empty)
		{
		}

		// Token: 0x06000060 RID: 96 RVA: 0x00003B74 File Offset: 0x00001D74
		public CodeDataMatrix(string code, int length, XSize size)
			: this(code, "", length, length, 0, size)
		{
		}

		// Token: 0x06000061 RID: 97 RVA: 0x00003B86 File Offset: 0x00001D86
		public CodeDataMatrix(string code, DataMatrixEncoding dmEncoding, int length, XSize size)
			: this(code, CodeDataMatrix.CreateEncoding(dmEncoding, code.Length), length, length, 0, size)
		{
		}

		// Token: 0x06000062 RID: 98 RVA: 0x00003BA0 File Offset: 0x00001DA0
		public CodeDataMatrix(string code, int rows, int columns)
			: this(code, "", rows, columns, 0, XSize.Empty)
		{
		}

		// Token: 0x06000063 RID: 99 RVA: 0x00003BB6 File Offset: 0x00001DB6
		public CodeDataMatrix(string code, int rows, int columns, XSize size)
			: this(code, "", rows, columns, 0, size)
		{
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00003BC9 File Offset: 0x00001DC9
		public CodeDataMatrix(string code, DataMatrixEncoding dmEncoding, int rows, int columns, XSize size)
			: this(code, CodeDataMatrix.CreateEncoding(dmEncoding, code.Length), rows, columns, 0, size)
		{
		}

		// Token: 0x06000065 RID: 101 RVA: 0x00003BE4 File Offset: 0x00001DE4
		public CodeDataMatrix(string code, int rows, int columns, int quietZone)
			: this(code, "", rows, columns, quietZone, XSize.Empty)
		{
		}

		// Token: 0x06000066 RID: 102 RVA: 0x00003BFB File Offset: 0x00001DFB
		public CodeDataMatrix(string code, string encoding, int rows, int columns, int quietZone, XSize size)
			: base(code, encoding, rows, columns, size)
		{
			this.QuietZone = quietZone;
		}

		// Token: 0x06000067 RID: 103 RVA: 0x00003C12 File Offset: 0x00001E12
		public void SetEncoding(DataMatrixEncoding dmEncoding)
		{
			base.Encoding = CodeDataMatrix.CreateEncoding(dmEncoding, base.Text.Length);
		}

		// Token: 0x06000068 RID: 104 RVA: 0x00003C2C File Offset: 0x00001E2C
		private static string CreateEncoding(DataMatrixEncoding dmEncoding, int length)
		{
			string text = "";
			switch (dmEncoding)
			{
			case DataMatrixEncoding.Ascii:
				text = new string('a', length);
				break;
			case DataMatrixEncoding.C40:
				text = new string('c', length);
				break;
			case DataMatrixEncoding.Text:
				text = new string('t', length);
				break;
			case DataMatrixEncoding.X12:
				text = new string('x', length);
				break;
			case DataMatrixEncoding.EDIFACT:
				text = new string('e', length);
				break;
			case DataMatrixEncoding.Base256:
				text = new string('b', length);
				break;
			}
			return text;
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000069 RID: 105 RVA: 0x00003CA2 File Offset: 0x00001EA2
		// (set) Token: 0x0600006A RID: 106 RVA: 0x00003CAA File Offset: 0x00001EAA
		public int QuietZone
		{
			get
			{
				return this._quietZone;
			}
			set
			{
				this._quietZone = value;
			}
		}

		// Token: 0x0600006B RID: 107 RVA: 0x00003CB4 File Offset: 0x00001EB4
		protected internal override void Render(XGraphics gfx, XBrush brush, XPoint position)
		{
			XGraphicsState xgraphicsState = gfx.Save();
			switch (base.Direction)
			{
			case CodeDirection.BottomToTop:
				gfx.RotateAtTransform(-90.0, position);
				break;
			case CodeDirection.RightToLeft:
				gfx.RotateAtTransform(180.0, position);
				break;
			case CodeDirection.TopToBottom:
				gfx.RotateAtTransform(90.0, position);
				break;
			}
			XPoint xpoint = position + CodeBase.CalcDistance(base.Anchor, AnchorType.TopLeft, base.Size);
			if (base.MatrixImage == null)
			{
				base.MatrixImage = DataMatrixImage.GenerateMatrixImage(base.Text, base.Encoding, base.Rows, base.Columns);
			}
			if (this.QuietZone > 0)
			{
				XSize xsize = new XSize(base.Size.Width, base.Size.Height);
				xsize.Width = xsize.Width / (double)(base.Columns + 2 * this.QuietZone) * (double)base.Columns;
				xsize.Height = xsize.Height / (double)(base.Rows + 2 * this.QuietZone) * (double)base.Rows;
				XPoint xpoint2 = new XPoint(xpoint.X, xpoint.Y);
				xpoint2.X += base.Size.Width / (double)(base.Columns + 2 * this.QuietZone) * (double)this.QuietZone;
				xpoint2.Y += base.Size.Height / (double)(base.Rows + 2 * this.QuietZone) * (double)this.QuietZone;
				gfx.DrawRectangle(XBrushes.White, xpoint.X, xpoint.Y, base.Size.Width, base.Size.Height);
				gfx.DrawImage(base.MatrixImage, xpoint2.X, xpoint2.Y, xsize.Width, xsize.Height);
			}
			else
			{
				gfx.DrawImage(base.MatrixImage, xpoint.X, xpoint.Y, base.Size.Width, base.Size.Height);
			}
			gfx.Restore(xgraphicsState);
		}

		// Token: 0x0600006C RID: 108 RVA: 0x00003F00 File Offset: 0x00002100
		protected override void CheckCode(string text)
		{
			if (text == null)
			{
				throw new ArgumentNullException("text");
			}
			DataMatrixImage dataMatrixImage = new DataMatrixImage(base.Text, base.Encoding, base.Rows, base.Columns);
			dataMatrixImage.Iec16022Ecc200(base.Columns, base.Rows, base.Encoding, base.Text.Length, base.Text, 0, 0, 0);
		}

		// Token: 0x04000026 RID: 38
		private int _quietZone;
	}
}
