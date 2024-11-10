using System;

namespace PdfSharp.Drawing.BarCodes
{
	// Token: 0x0200000C RID: 12
	public abstract class MatrixCode : CodeBase
	{
		// Token: 0x06000051 RID: 81 RVA: 0x00003A60 File Offset: 0x00001C60
		public MatrixCode(string text, string encoding, int rows, int columns, XSize size)
			: base(text, size, CodeDirection.LeftToRight)
		{
			this._encoding = encoding;
			if (string.IsNullOrEmpty(this._encoding))
			{
				this._encoding = new string('a', this.Text.Length);
			}
			if (columns < rows)
			{
				this._rows = columns;
				this._columns = rows;
			}
			else
			{
				this._columns = columns;
				this._rows = rows;
			}
			this.Text = text;
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000052 RID: 82 RVA: 0x00003ACF File Offset: 0x00001CCF
		// (set) Token: 0x06000053 RID: 83 RVA: 0x00003AD7 File Offset: 0x00001CD7
		public string Encoding
		{
			get
			{
				return this._encoding;
			}
			set
			{
				this._encoding = value;
				this._matrixImage = null;
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000054 RID: 84 RVA: 0x00003AE7 File Offset: 0x00001CE7
		// (set) Token: 0x06000055 RID: 85 RVA: 0x00003AEF File Offset: 0x00001CEF
		public int Columns
		{
			get
			{
				return this._columns;
			}
			set
			{
				this._columns = value;
				this._matrixImage = null;
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000056 RID: 86 RVA: 0x00003AFF File Offset: 0x00001CFF
		// (set) Token: 0x06000057 RID: 87 RVA: 0x00003B07 File Offset: 0x00001D07
		public int Rows
		{
			get
			{
				return this._rows;
			}
			set
			{
				this._rows = value;
				this._matrixImage = null;
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000058 RID: 88 RVA: 0x00003B17 File Offset: 0x00001D17
		// (set) Token: 0x06000059 RID: 89 RVA: 0x00003B1F File Offset: 0x00001D1F
		public new string Text
		{
			get
			{
				return base.Text;
			}
			set
			{
				base.Text = value;
				this._matrixImage = null;
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x0600005A RID: 90 RVA: 0x00003B2F File Offset: 0x00001D2F
		// (set) Token: 0x0600005B RID: 91 RVA: 0x00003B37 File Offset: 0x00001D37
		internal XImage MatrixImage
		{
			get
			{
				return this._matrixImage;
			}
			set
			{
				this._matrixImage = value;
			}
		}

		// Token: 0x0600005C RID: 92
		protected internal abstract void Render(XGraphics gfx, XBrush brush, XPoint center);

		// Token: 0x0600005D RID: 93 RVA: 0x00003B40 File Offset: 0x00001D40
		protected override void CheckCode(string text)
		{
		}

		// Token: 0x04000022 RID: 34
		private string _encoding;

		// Token: 0x04000023 RID: 35
		private int _columns;

		// Token: 0x04000024 RID: 36
		private int _rows;

		// Token: 0x04000025 RID: 37
		private XImage _matrixImage;
	}
}
