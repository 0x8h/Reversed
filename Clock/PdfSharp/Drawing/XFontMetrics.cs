using System;

namespace PdfSharp.Drawing
{
	// Token: 0x0200005F RID: 95
	public sealed class XFontMetrics
	{
		// Token: 0x0600035E RID: 862 RVA: 0x0000FC34 File Offset: 0x0000DE34
		internal XFontMetrics(string name, int unitsPerEm, int ascent, int descent, int leading, int lineSpacing, int capHeight, int xHeight, int stemV, int stemH, int averageWidth, int maxWidth, int underlinePosition, int underlineThickness, int strikethroughPosition, int strikethroughThickness)
		{
			this._name = name;
			this._unitsPerEm = unitsPerEm;
			this._ascent = ascent;
			this._descent = descent;
			this._leading = leading;
			this._lineSpacing = lineSpacing;
			this._capHeight = capHeight;
			this._xHeight = xHeight;
			this._stemV = stemV;
			this._stemH = stemH;
			this._averageWidth = averageWidth;
			this._maxWidth = maxWidth;
			this._underlinePosition = underlinePosition;
			this._underlineThickness = underlineThickness;
			this._strikethroughPosition = strikethroughPosition;
			this._strikethroughThickness = strikethroughThickness;
		}

		// Token: 0x170001A1 RID: 417
		// (get) Token: 0x0600035F RID: 863 RVA: 0x0000FCC4 File Offset: 0x0000DEC4
		public string Name
		{
			get
			{
				return this._name;
			}
		}

		// Token: 0x170001A2 RID: 418
		// (get) Token: 0x06000360 RID: 864 RVA: 0x0000FCCC File Offset: 0x0000DECC
		public int UnitsPerEm
		{
			get
			{
				return this._unitsPerEm;
			}
		}

		// Token: 0x170001A3 RID: 419
		// (get) Token: 0x06000361 RID: 865 RVA: 0x0000FCD4 File Offset: 0x0000DED4
		public int Ascent
		{
			get
			{
				return this._ascent;
			}
		}

		// Token: 0x170001A4 RID: 420
		// (get) Token: 0x06000362 RID: 866 RVA: 0x0000FCDC File Offset: 0x0000DEDC
		public int Descent
		{
			get
			{
				return this._descent;
			}
		}

		// Token: 0x170001A5 RID: 421
		// (get) Token: 0x06000363 RID: 867 RVA: 0x0000FCE4 File Offset: 0x0000DEE4
		public int AverageWidth
		{
			get
			{
				return this._averageWidth;
			}
		}

		// Token: 0x170001A6 RID: 422
		// (get) Token: 0x06000364 RID: 868 RVA: 0x0000FCEC File Offset: 0x0000DEEC
		public int CapHeight
		{
			get
			{
				return this._capHeight;
			}
		}

		// Token: 0x170001A7 RID: 423
		// (get) Token: 0x06000365 RID: 869 RVA: 0x0000FCF4 File Offset: 0x0000DEF4
		public int Leading
		{
			get
			{
				return this._leading;
			}
		}

		// Token: 0x170001A8 RID: 424
		// (get) Token: 0x06000366 RID: 870 RVA: 0x0000FCFC File Offset: 0x0000DEFC
		public int LineSpacing
		{
			get
			{
				return this._lineSpacing;
			}
		}

		// Token: 0x170001A9 RID: 425
		// (get) Token: 0x06000367 RID: 871 RVA: 0x0000FD04 File Offset: 0x0000DF04
		public int MaxWidth
		{
			get
			{
				return this._maxWidth;
			}
		}

		// Token: 0x170001AA RID: 426
		// (get) Token: 0x06000368 RID: 872 RVA: 0x0000FD0C File Offset: 0x0000DF0C
		public int StemH
		{
			get
			{
				return this._stemH;
			}
		}

		// Token: 0x170001AB RID: 427
		// (get) Token: 0x06000369 RID: 873 RVA: 0x0000FD14 File Offset: 0x0000DF14
		public int StemV
		{
			get
			{
				return this._stemV;
			}
		}

		// Token: 0x170001AC RID: 428
		// (get) Token: 0x0600036A RID: 874 RVA: 0x0000FD1C File Offset: 0x0000DF1C
		public int XHeight
		{
			get
			{
				return this._xHeight;
			}
		}

		// Token: 0x170001AD RID: 429
		// (get) Token: 0x0600036B RID: 875 RVA: 0x0000FD24 File Offset: 0x0000DF24
		public int UnderlinePosition
		{
			get
			{
				return this._underlinePosition;
			}
		}

		// Token: 0x170001AE RID: 430
		// (get) Token: 0x0600036C RID: 876 RVA: 0x0000FD2C File Offset: 0x0000DF2C
		public int UnderlineThickness
		{
			get
			{
				return this._underlineThickness;
			}
		}

		// Token: 0x170001AF RID: 431
		// (get) Token: 0x0600036D RID: 877 RVA: 0x0000FD34 File Offset: 0x0000DF34
		public int StrikethroughPosition
		{
			get
			{
				return this._strikethroughPosition;
			}
		}

		// Token: 0x170001B0 RID: 432
		// (get) Token: 0x0600036E RID: 878 RVA: 0x0000FD3C File Offset: 0x0000DF3C
		public int StrikethroughThickness
		{
			get
			{
				return this._strikethroughThickness;
			}
		}

		// Token: 0x04000222 RID: 546
		private readonly string _name;

		// Token: 0x04000223 RID: 547
		private readonly int _unitsPerEm;

		// Token: 0x04000224 RID: 548
		private readonly int _ascent;

		// Token: 0x04000225 RID: 549
		private readonly int _descent;

		// Token: 0x04000226 RID: 550
		private readonly int _averageWidth;

		// Token: 0x04000227 RID: 551
		private readonly int _capHeight;

		// Token: 0x04000228 RID: 552
		private readonly int _leading;

		// Token: 0x04000229 RID: 553
		private readonly int _lineSpacing;

		// Token: 0x0400022A RID: 554
		private readonly int _maxWidth;

		// Token: 0x0400022B RID: 555
		private readonly int _stemH;

		// Token: 0x0400022C RID: 556
		private readonly int _stemV;

		// Token: 0x0400022D RID: 557
		private readonly int _xHeight;

		// Token: 0x0400022E RID: 558
		private readonly int _underlinePosition;

		// Token: 0x0400022F RID: 559
		private readonly int _underlineThickness;

		// Token: 0x04000230 RID: 560
		private readonly int _strikethroughPosition;

		// Token: 0x04000231 RID: 561
		private readonly int _strikethroughThickness;
	}
}
