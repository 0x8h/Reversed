using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using PdfSharp.Fonts;
using PdfSharp.Fonts.OpenType;
using PdfSharp.Internal;
using PdfSharp.Pdf;

namespace PdfSharp.Drawing
{
	// Token: 0x0200005C RID: 92
	[DebuggerDisplay("{DebuggerDisplay}")]
	public sealed class XFont
	{
		// Token: 0x0600031C RID: 796 RVA: 0x0000F3B1 File Offset: 0x0000D5B1
		public XFont(string familyName, double emSize)
			: this(familyName, emSize, XFontStyle.Regular, new XPdfFontOptions(GlobalFontSettings.DefaultFontEncoding))
		{
		}

		// Token: 0x0600031D RID: 797 RVA: 0x0000F3C6 File Offset: 0x0000D5C6
		public XFont(string familyName, double emSize, XFontStyle style)
			: this(familyName, emSize, style, new XPdfFontOptions(GlobalFontSettings.DefaultFontEncoding))
		{
		}

		// Token: 0x0600031E RID: 798 RVA: 0x0000F3DB File Offset: 0x0000D5DB
		public XFont(string familyName, double emSize, XFontStyle style, XPdfFontOptions pdfOptions)
		{
			this._familyName = familyName;
			this._emSize = emSize;
			this._style = style;
			this._pdfOptions = pdfOptions;
			this.Initialize();
		}

		// Token: 0x0600031F RID: 799 RVA: 0x0000F406 File Offset: 0x0000D606
		internal XFont(string familyName, double emSize, XFontStyle style, XPdfFontOptions pdfOptions, XStyleSimulations styleSimulations)
		{
			this._familyName = familyName;
			this._emSize = emSize;
			this._style = style;
			this._pdfOptions = pdfOptions;
			this.OverrideStyleSimulations = true;
			this.StyleSimulations = styleSimulations;
			this.Initialize();
		}

		// Token: 0x06000320 RID: 800 RVA: 0x0000F440 File Offset: 0x0000D640
		public XFont(FontFamily fontFamily, double emSize, XFontStyle style)
			: this(fontFamily, emSize, style, new XPdfFontOptions(GlobalFontSettings.DefaultFontEncoding))
		{
		}

		// Token: 0x06000321 RID: 801 RVA: 0x0000F455 File Offset: 0x0000D655
		public XFont(FontFamily fontFamily, double emSize, XFontStyle style, XPdfFontOptions pdfOptions)
		{
			this._familyName = fontFamily.Name;
			this._gdiFontFamily = fontFamily;
			this._emSize = emSize;
			this._style = style;
			this._pdfOptions = pdfOptions;
			this.InitializeFromGdi();
		}

		// Token: 0x06000322 RID: 802 RVA: 0x0000F48C File Offset: 0x0000D68C
		public XFont(Font font)
			: this(font, new XPdfFontOptions(GlobalFontSettings.DefaultFontEncoding))
		{
		}

		// Token: 0x06000323 RID: 803 RVA: 0x0000F4A0 File Offset: 0x0000D6A0
		public XFont(Font font, XPdfFontOptions pdfOptions)
		{
			if (font.Unit != GraphicsUnit.World)
			{
				throw new ArgumentException("Font must use GraphicsUnit.World.");
			}
			this._gdiFont = font;
			this._familyName = font.Name;
			this._emSize = (double)font.Size;
			this._style = XFont.FontStyleFrom(font);
			this._pdfOptions = pdfOptions;
			this.InitializeFromGdi();
		}

		// Token: 0x06000324 RID: 804 RVA: 0x0000F500 File Offset: 0x0000D700
		private void Initialize()
		{
			FontResolvingOptions fontResolvingOptions = (this.OverrideStyleSimulations ? new FontResolvingOptions(this._style, this.StyleSimulations) : new FontResolvingOptions(this._style));
			if (StringComparer.OrdinalIgnoreCase.Compare(this._familyName, "PlatformDefault") == 0)
			{
				this._familyName = "Calibri";
			}
			this._glyphTypeface = XGlyphTypeface.GetOrCreateFrom(this._familyName, fontResolvingOptions);
			this.CreateDescriptorAndInitializeFontMetrics();
		}

		// Token: 0x06000325 RID: 805 RVA: 0x0000F570 File Offset: 0x0000D770
		private void InitializeFromGdi()
		{
			try
			{
				Lock.EnterFontFactory();
				if (this._gdiFontFamily != null)
				{
					this._gdiFont = new Font(this._gdiFontFamily, (float)this._emSize, (FontStyle)this._style, GraphicsUnit.World);
				}
				if (this._gdiFont != null)
				{
					this._familyName = this._gdiFont.FontFamily.Name;
				}
				if (this._glyphTypeface == null)
				{
					this._glyphTypeface = XGlyphTypeface.GetOrCreateFromGdi(this._gdiFont);
				}
				this.CreateDescriptorAndInitializeFontMetrics();
			}
			finally
			{
				Lock.ExitFontFactory();
			}
		}

		// Token: 0x06000326 RID: 806 RVA: 0x0000F600 File Offset: 0x0000D800
		private void CreateDescriptorAndInitializeFontMetrics()
		{
			this._descriptor = (OpenTypeDescriptor)FontDescriptorCache.GetOrCreateDescriptorFor(this);
			this._fontMetrics = new XFontMetrics(this._descriptor.FontName, this._descriptor.UnitsPerEm, this._descriptor.Ascender, this._descriptor.Descender, this._descriptor.Leading, this._descriptor.LineSpacing, this._descriptor.CapHeight, this._descriptor.XHeight, this._descriptor.StemV, 0, 0, 0, this._descriptor.UnderlinePosition, this._descriptor.UnderlineThickness, this._descriptor.StrikeoutPosition, this._descriptor.StrikeoutSize);
			XFontMetrics metrics = this.Metrics;
			this.UnitsPerEm = this._descriptor.UnitsPerEm;
			this.CellAscent = this._descriptor.Ascender;
			this.CellDescent = this._descriptor.Descender;
			this.CellSpace = this._descriptor.LineSpacing;
		}

		// Token: 0x17000185 RID: 389
		// (get) Token: 0x06000327 RID: 807 RVA: 0x0000F706 File Offset: 0x0000D906
		[Browsable(false)]
		public XFontFamily FontFamily
		{
			get
			{
				return this._glyphTypeface.FontFamily;
			}
		}

		// Token: 0x17000186 RID: 390
		// (get) Token: 0x06000328 RID: 808 RVA: 0x0000F713 File Offset: 0x0000D913
		public string Name
		{
			get
			{
				return this._glyphTypeface.FontFamily.Name;
			}
		}

		// Token: 0x17000187 RID: 391
		// (get) Token: 0x06000329 RID: 809 RVA: 0x0000F725 File Offset: 0x0000D925
		internal string FaceName
		{
			get
			{
				return this._glyphTypeface.FaceName;
			}
		}

		// Token: 0x17000188 RID: 392
		// (get) Token: 0x0600032A RID: 810 RVA: 0x0000F732 File Offset: 0x0000D932
		public double Size
		{
			get
			{
				return this._emSize;
			}
		}

		// Token: 0x17000189 RID: 393
		// (get) Token: 0x0600032B RID: 811 RVA: 0x0000F73A File Offset: 0x0000D93A
		[Browsable(false)]
		public XFontStyle Style
		{
			get
			{
				return this._style;
			}
		}

		// Token: 0x1700018A RID: 394
		// (get) Token: 0x0600032C RID: 812 RVA: 0x0000F742 File Offset: 0x0000D942
		public bool Bold
		{
			get
			{
				return (this._style & XFontStyle.Bold) == XFontStyle.Bold;
			}
		}

		// Token: 0x1700018B RID: 395
		// (get) Token: 0x0600032D RID: 813 RVA: 0x0000F74F File Offset: 0x0000D94F
		public bool Italic
		{
			get
			{
				return (this._style & XFontStyle.Italic) == XFontStyle.Italic;
			}
		}

		// Token: 0x1700018C RID: 396
		// (get) Token: 0x0600032E RID: 814 RVA: 0x0000F75C File Offset: 0x0000D95C
		public bool Strikeout
		{
			get
			{
				return (this._style & XFontStyle.Strikeout) == XFontStyle.Strikeout;
			}
		}

		// Token: 0x1700018D RID: 397
		// (get) Token: 0x0600032F RID: 815 RVA: 0x0000F769 File Offset: 0x0000D969
		public bool Underline
		{
			get
			{
				return (this._style & XFontStyle.Underline) == XFontStyle.Underline;
			}
		}

		// Token: 0x1700018E RID: 398
		// (get) Token: 0x06000330 RID: 816 RVA: 0x0000F776 File Offset: 0x0000D976
		// (set) Token: 0x06000331 RID: 817 RVA: 0x0000F77E File Offset: 0x0000D97E
		internal bool IsVertical
		{
			get
			{
				return this._isVertical;
			}
			set
			{
				this._isVertical = value;
			}
		}

		// Token: 0x1700018F RID: 399
		// (get) Token: 0x06000332 RID: 818 RVA: 0x0000F788 File Offset: 0x0000D988
		public XPdfFontOptions PdfOptions
		{
			get
			{
				XPdfFontOptions xpdfFontOptions;
				if ((xpdfFontOptions = this._pdfOptions) == null)
				{
					xpdfFontOptions = (this._pdfOptions = new XPdfFontOptions());
				}
				return xpdfFontOptions;
			}
		}

		// Token: 0x17000190 RID: 400
		// (get) Token: 0x06000333 RID: 819 RVA: 0x0000F7AD File Offset: 0x0000D9AD
		internal bool Unicode
		{
			get
			{
				return this._pdfOptions != null && this._pdfOptions.FontEncoding == PdfFontEncoding.Unicode;
			}
		}

		// Token: 0x17000191 RID: 401
		// (get) Token: 0x06000334 RID: 820 RVA: 0x0000F7C7 File Offset: 0x0000D9C7
		// (set) Token: 0x06000335 RID: 821 RVA: 0x0000F7CF File Offset: 0x0000D9CF
		public int CellSpace
		{
			get
			{
				return this._cellSpace;
			}
			internal set
			{
				this._cellSpace = value;
			}
		}

		// Token: 0x17000192 RID: 402
		// (get) Token: 0x06000336 RID: 822 RVA: 0x0000F7D8 File Offset: 0x0000D9D8
		// (set) Token: 0x06000337 RID: 823 RVA: 0x0000F7E0 File Offset: 0x0000D9E0
		public int CellAscent
		{
			get
			{
				return this._cellAscent;
			}
			internal set
			{
				this._cellAscent = value;
			}
		}

		// Token: 0x17000193 RID: 403
		// (get) Token: 0x06000338 RID: 824 RVA: 0x0000F7E9 File Offset: 0x0000D9E9
		// (set) Token: 0x06000339 RID: 825 RVA: 0x0000F7F1 File Offset: 0x0000D9F1
		public int CellDescent
		{
			get
			{
				return this._cellDescent;
			}
			internal set
			{
				this._cellDescent = value;
			}
		}

		// Token: 0x17000194 RID: 404
		// (get) Token: 0x0600033A RID: 826 RVA: 0x0000F7FA File Offset: 0x0000D9FA
		public XFontMetrics Metrics
		{
			get
			{
				return this._fontMetrics;
			}
		}

		// Token: 0x0600033B RID: 827 RVA: 0x0000F804 File Offset: 0x0000DA04
		public double GetHeight()
		{
			return (double)this.CellSpace * this._emSize / (double)this.UnitsPerEm;
		}

		// Token: 0x0600033C RID: 828 RVA: 0x0000F829 File Offset: 0x0000DA29
		[Obsolete("Use GetHeight() without parameter.")]
		public double GetHeight(XGraphics graphics)
		{
			throw new InvalidOperationException("Honestly: Use GetHeight() without parameter!");
		}

		// Token: 0x17000195 RID: 405
		// (get) Token: 0x0600033D RID: 829 RVA: 0x0000F835 File Offset: 0x0000DA35
		[Browsable(false)]
		public int Height
		{
			get
			{
				return (int)Math.Ceiling(this.GetHeight());
			}
		}

		// Token: 0x17000196 RID: 406
		// (get) Token: 0x0600033E RID: 830 RVA: 0x0000F843 File Offset: 0x0000DA43
		internal XGlyphTypeface GlyphTypeface
		{
			get
			{
				return this._glyphTypeface;
			}
		}

		// Token: 0x17000197 RID: 407
		// (get) Token: 0x0600033F RID: 831 RVA: 0x0000F84B File Offset: 0x0000DA4B
		// (set) Token: 0x06000340 RID: 832 RVA: 0x0000F853 File Offset: 0x0000DA53
		internal OpenTypeDescriptor Descriptor
		{
			get
			{
				return this._descriptor;
			}
			private set
			{
				this._descriptor = value;
			}
		}

		// Token: 0x17000198 RID: 408
		// (get) Token: 0x06000341 RID: 833 RVA: 0x0000F85C File Offset: 0x0000DA5C
		internal string FamilyName
		{
			get
			{
				return this._familyName;
			}
		}

		// Token: 0x17000199 RID: 409
		// (get) Token: 0x06000342 RID: 834 RVA: 0x0000F864 File Offset: 0x0000DA64
		// (set) Token: 0x06000343 RID: 835 RVA: 0x0000F86C File Offset: 0x0000DA6C
		internal int UnitsPerEm
		{
			get
			{
				return this._unitsPerEm;
			}
			private set
			{
				this._unitsPerEm = value;
			}
		}

		// Token: 0x1700019A RID: 410
		// (get) Token: 0x06000344 RID: 836 RVA: 0x0000F875 File Offset: 0x0000DA75
		public FontFamily GdiFontFamily
		{
			get
			{
				return this._gdiFontFamily;
			}
		}

		// Token: 0x1700019B RID: 411
		// (get) Token: 0x06000345 RID: 837 RVA: 0x0000F87D File Offset: 0x0000DA7D
		internal Font GdiFont
		{
			get
			{
				return this._gdiFont;
			}
		}

		// Token: 0x06000346 RID: 838 RVA: 0x0000F885 File Offset: 0x0000DA85
		internal static XFontStyle FontStyleFrom(Font font)
		{
			return (font.Bold ? XFontStyle.Bold : XFontStyle.Regular) | (font.Italic ? XFontStyle.Italic : XFontStyle.Regular) | (font.Strikeout ? XFontStyle.Strikeout : XFontStyle.Regular) | (font.Underline ? XFontStyle.Underline : XFontStyle.Regular);
		}

		// Token: 0x06000347 RID: 839 RVA: 0x0000F8BA File Offset: 0x0000DABA
		public static implicit operator XFont(Font font)
		{
			return new XFont(font);
		}

		// Token: 0x1700019C RID: 412
		// (get) Token: 0x06000348 RID: 840 RVA: 0x0000F8C2 File Offset: 0x0000DAC2
		// (set) Token: 0x06000349 RID: 841 RVA: 0x0000F8CA File Offset: 0x0000DACA
		internal string Selector
		{
			get
			{
				return this._selector;
			}
			set
			{
				this._selector = value;
			}
		}

		// Token: 0x1700019D RID: 413
		// (get) Token: 0x0600034A RID: 842 RVA: 0x0000F8D4 File Offset: 0x0000DAD4
		private string DebuggerDisplay
		{
			get
			{
				return string.Format(CultureInfo.InvariantCulture, "font=('{0}' {1:0.##})", new object[] { this.Name, this.Size });
			}
		}

		// Token: 0x0400020E RID: 526
		private readonly double _emSize;

		// Token: 0x0400020F RID: 527
		private readonly XFontStyle _style;

		// Token: 0x04000210 RID: 528
		private bool _isVertical;

		// Token: 0x04000211 RID: 529
		private XPdfFontOptions _pdfOptions;

		// Token: 0x04000212 RID: 530
		private int _cellSpace;

		// Token: 0x04000213 RID: 531
		private int _cellAscent;

		// Token: 0x04000214 RID: 532
		private int _cellDescent;

		// Token: 0x04000215 RID: 533
		private XFontMetrics _fontMetrics;

		// Token: 0x04000216 RID: 534
		private XGlyphTypeface _glyphTypeface;

		// Token: 0x04000217 RID: 535
		private OpenTypeDescriptor _descriptor;

		// Token: 0x04000218 RID: 536
		private string _familyName;

		// Token: 0x04000219 RID: 537
		internal int _unitsPerEm;

		// Token: 0x0400021A RID: 538
		internal bool OverrideStyleSimulations;

		// Token: 0x0400021B RID: 539
		internal XStyleSimulations StyleSimulations;

		// Token: 0x0400021C RID: 540
		private readonly FontFamily _gdiFontFamily;

		// Token: 0x0400021D RID: 541
		private Font _gdiFont;

		// Token: 0x0400021E RID: 542
		private string _selector;
	}
}
