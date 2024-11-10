using System;

namespace PdfSharp.Drawing
{
	// Token: 0x02000076 RID: 118
	public sealed class XPen
	{
		// Token: 0x06000509 RID: 1289 RVA: 0x00015A45 File Offset: 0x00013C45
		public XPen(XColor color)
			: this(color, 1.0, false)
		{
		}

		// Token: 0x0600050A RID: 1290 RVA: 0x00015A58 File Offset: 0x00013C58
		public XPen(XColor color, double width)
			: this(color, width, false)
		{
		}

		// Token: 0x0600050B RID: 1291 RVA: 0x00015A64 File Offset: 0x00013C64
		internal XPen(XColor color, double width, bool immutable)
		{
			this._dirty = true;
			base..ctor();
			this._color = color;
			this._width = width;
			this._lineJoin = XLineJoin.Miter;
			this._lineCap = XLineCap.Flat;
			this._dashStyle = XDashStyle.Solid;
			this._dashOffset = 0.0;
			this._immutable = immutable;
		}

		// Token: 0x0600050C RID: 1292 RVA: 0x00015AB8 File Offset: 0x00013CB8
		public XPen(XPen pen)
		{
			this._dirty = true;
			base..ctor();
			this._color = pen._color;
			this._width = pen._width;
			this._lineJoin = pen._lineJoin;
			this._lineCap = pen._lineCap;
			this._dashStyle = pen._dashStyle;
			this._dashOffset = pen._dashOffset;
			this._dashPattern = pen._dashPattern;
			if (this._dashPattern != null)
			{
				this._dashPattern = (double[])this._dashPattern.Clone();
			}
		}

		// Token: 0x0600050D RID: 1293 RVA: 0x00015B44 File Offset: 0x00013D44
		public XPen Clone()
		{
			return new XPen(this);
		}

		// Token: 0x17000207 RID: 519
		// (get) Token: 0x0600050E RID: 1294 RVA: 0x00015B4C File Offset: 0x00013D4C
		// (set) Token: 0x0600050F RID: 1295 RVA: 0x00015B54 File Offset: 0x00013D54
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
					throw new ArgumentException(PSSR.CannotChangeImmutableObject("XPen"));
				}
				this._dirty = this._dirty || this._color != value;
				this._color = value;
			}
		}

		// Token: 0x17000208 RID: 520
		// (get) Token: 0x06000510 RID: 1296 RVA: 0x00015B92 File Offset: 0x00013D92
		// (set) Token: 0x06000511 RID: 1297 RVA: 0x00015B9A File Offset: 0x00013D9A
		public double Width
		{
			get
			{
				return this._width;
			}
			set
			{
				if (this._immutable)
				{
					throw new ArgumentException(PSSR.CannotChangeImmutableObject("XPen"));
				}
				this._dirty = this._dirty || this._width != value;
				this._width = value;
			}
		}

		// Token: 0x17000209 RID: 521
		// (get) Token: 0x06000512 RID: 1298 RVA: 0x00015BD8 File Offset: 0x00013DD8
		// (set) Token: 0x06000513 RID: 1299 RVA: 0x00015BE0 File Offset: 0x00013DE0
		public XLineJoin LineJoin
		{
			get
			{
				return this._lineJoin;
			}
			set
			{
				if (this._immutable)
				{
					throw new ArgumentException(PSSR.CannotChangeImmutableObject("XPen"));
				}
				this._dirty = this._dirty || this._lineJoin != value;
				this._lineJoin = value;
			}
		}

		// Token: 0x1700020A RID: 522
		// (get) Token: 0x06000514 RID: 1300 RVA: 0x00015C1E File Offset: 0x00013E1E
		// (set) Token: 0x06000515 RID: 1301 RVA: 0x00015C26 File Offset: 0x00013E26
		public XLineCap LineCap
		{
			get
			{
				return this._lineCap;
			}
			set
			{
				if (this._immutable)
				{
					throw new ArgumentException(PSSR.CannotChangeImmutableObject("XPen"));
				}
				this._dirty = this._dirty || this._lineCap != value;
				this._lineCap = value;
			}
		}

		// Token: 0x1700020B RID: 523
		// (get) Token: 0x06000516 RID: 1302 RVA: 0x00015C64 File Offset: 0x00013E64
		// (set) Token: 0x06000517 RID: 1303 RVA: 0x00015C6C File Offset: 0x00013E6C
		public double MiterLimit
		{
			get
			{
				return this._miterLimit;
			}
			set
			{
				if (this._immutable)
				{
					throw new ArgumentException(PSSR.CannotChangeImmutableObject("XPen"));
				}
				this._dirty = this._dirty || this._miterLimit != value;
				this._miterLimit = value;
			}
		}

		// Token: 0x1700020C RID: 524
		// (get) Token: 0x06000518 RID: 1304 RVA: 0x00015CAA File Offset: 0x00013EAA
		// (set) Token: 0x06000519 RID: 1305 RVA: 0x00015CB2 File Offset: 0x00013EB2
		public XDashStyle DashStyle
		{
			get
			{
				return this._dashStyle;
			}
			set
			{
				if (this._immutable)
				{
					throw new ArgumentException(PSSR.CannotChangeImmutableObject("XPen"));
				}
				this._dirty = this._dirty || this._dashStyle != value;
				this._dashStyle = value;
			}
		}

		// Token: 0x1700020D RID: 525
		// (get) Token: 0x0600051A RID: 1306 RVA: 0x00015CF0 File Offset: 0x00013EF0
		// (set) Token: 0x0600051B RID: 1307 RVA: 0x00015CF8 File Offset: 0x00013EF8
		public double DashOffset
		{
			get
			{
				return this._dashOffset;
			}
			set
			{
				if (this._immutable)
				{
					throw new ArgumentException(PSSR.CannotChangeImmutableObject("XPen"));
				}
				this._dirty = this._dirty || this._dashOffset != value;
				this._dashOffset = value;
			}
		}

		// Token: 0x1700020E RID: 526
		// (get) Token: 0x0600051C RID: 1308 RVA: 0x00015D36 File Offset: 0x00013F36
		// (set) Token: 0x0600051D RID: 1309 RVA: 0x00015D54 File Offset: 0x00013F54
		public double[] DashPattern
		{
			get
			{
				if (this._dashPattern == null)
				{
					this._dashPattern = new double[0];
				}
				return this._dashPattern;
			}
			set
			{
				if (this._immutable)
				{
					throw new ArgumentException(PSSR.CannotChangeImmutableObject("XPen"));
				}
				int num = value.Length;
				for (int i = 0; i < num; i++)
				{
					if (value[i] <= 0.0)
					{
						throw new ArgumentException("Dash pattern value must greater than zero.");
					}
				}
				this._dirty = true;
				this._dashStyle = XDashStyle.Custom;
				this._dashPattern = (double[])value.Clone();
			}
		}

		// Token: 0x1700020F RID: 527
		// (get) Token: 0x0600051E RID: 1310 RVA: 0x00015DC1 File Offset: 0x00013FC1
		// (set) Token: 0x0600051F RID: 1311 RVA: 0x00015DC9 File Offset: 0x00013FC9
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
					throw new ArgumentException(PSSR.CannotChangeImmutableObject("XPen"));
				}
				this._overprint = value;
			}
		}

		// Token: 0x0400029F RID: 671
		internal XColor _color;

		// Token: 0x040002A0 RID: 672
		internal double _width;

		// Token: 0x040002A1 RID: 673
		internal XLineJoin _lineJoin;

		// Token: 0x040002A2 RID: 674
		internal XLineCap _lineCap;

		// Token: 0x040002A3 RID: 675
		internal double _miterLimit;

		// Token: 0x040002A4 RID: 676
		internal XDashStyle _dashStyle;

		// Token: 0x040002A5 RID: 677
		internal double _dashOffset;

		// Token: 0x040002A6 RID: 678
		internal double[] _dashPattern;

		// Token: 0x040002A7 RID: 679
		internal bool _overprint;

		// Token: 0x040002A8 RID: 680
		private bool _dirty;

		// Token: 0x040002A9 RID: 681
		private readonly bool _immutable;
	}
}
