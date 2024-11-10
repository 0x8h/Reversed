using System;

namespace PdfSharp.Drawing
{
	// Token: 0x0200007C RID: 124
	public sealed class XSolidBrush : XBrush
	{
		// Token: 0x06000631 RID: 1585 RVA: 0x00017FB7 File Offset: 0x000161B7
		public XSolidBrush()
		{
		}

		// Token: 0x06000632 RID: 1586 RVA: 0x00017FBF File Offset: 0x000161BF
		public XSolidBrush(XColor color)
			: this(color, false)
		{
		}

		// Token: 0x06000633 RID: 1587 RVA: 0x00017FC9 File Offset: 0x000161C9
		internal XSolidBrush(XColor color, bool immutable)
		{
			this._color = color;
			this._immutable = immutable;
		}

		// Token: 0x06000634 RID: 1588 RVA: 0x00017FDF File Offset: 0x000161DF
		public XSolidBrush(XSolidBrush brush)
		{
			this._color = brush.Color;
		}

		// Token: 0x170002B8 RID: 696
		// (get) Token: 0x06000635 RID: 1589 RVA: 0x00017FF3 File Offset: 0x000161F3
		// (set) Token: 0x06000636 RID: 1590 RVA: 0x00017FFB File Offset: 0x000161FB
		public XColor Color
		{
			get
			{
				return this._color;
			}
			set
			{
				if (this._immutable)
				{
					throw new ArgumentException(PSSR.CannotChangeImmutableObject("XSolidBrush"));
				}
				this._color = value;
			}
		}

		// Token: 0x170002B9 RID: 697
		// (get) Token: 0x06000637 RID: 1591 RVA: 0x0001801C File Offset: 0x0001621C
		// (set) Token: 0x06000638 RID: 1592 RVA: 0x00018024 File Offset: 0x00016224
		public bool Overprint
		{
			get
			{
				return this._overprint;
			}
			set
			{
				if (this._immutable)
				{
					throw new ArgumentException(PSSR.CannotChangeImmutableObject("XSolidBrush"));
				}
				this._overprint = value;
			}
		}

		// Token: 0x040002B6 RID: 694
		internal XColor _color;

		// Token: 0x040002B7 RID: 695
		internal bool _overprint;

		// Token: 0x040002B8 RID: 696
		private readonly bool _immutable;
	}
}
