using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using PdfSharp.Fonts;
using PdfSharp.Fonts.OpenType;

namespace PdfSharp.Drawing
{
	// Token: 0x02000065 RID: 101
	[DebuggerDisplay("{DebuggerDisplay}")]
	internal sealed class XGlyphTypeface
	{
		// Token: 0x060003A8 RID: 936 RVA: 0x0001037A File Offset: 0x0000E57A
		private XGlyphTypeface(string key, XFontFamily fontFamily, XFontSource fontSource, XStyleSimulations styleSimulations, Font gdiFont)
		{
			this._key = key;
			this._fontFamily = fontFamily;
			this._fontSource = fontSource;
			this._fontface = OpenTypeFontface.CetOrCreateFrom(fontSource);
			this._gdiFont = gdiFont;
			this._styleSimulations = styleSimulations;
			this.Initialize();
		}

		// Token: 0x060003A9 RID: 937 RVA: 0x000103BC File Offset: 0x0000E5BC
		public static XGlyphTypeface GetOrCreateFrom(string familyName, FontResolvingOptions fontResolvingOptions)
		{
			string text = XGlyphTypeface.ComputeKey(familyName, fontResolvingOptions);
			XGlyphTypeface xglyphTypeface;
			if (GlyphTypefaceCache.TryGetGlyphTypeface(text, out xglyphTypeface))
			{
				return xglyphTypeface;
			}
			FontResolverInfo fontResolverInfo = FontFactory.ResolveTypeface(familyName, fontResolvingOptions, text);
			if (fontResolverInfo == null)
			{
				throw new InvalidOperationException("No appropriate font found.");
			}
			Font font = null;
			PlatformFontResolverInfo platformFontResolverInfo = fontResolverInfo as PlatformFontResolverInfo;
			XFontFamily xfontFamily;
			if (platformFontResolverInfo != null)
			{
				font = platformFontResolverInfo.GdiFont;
				xfontFamily = XFontFamily.GetOrCreateFromGdi(font);
			}
			else
			{
				xfontFamily = XFontFamily.CreateSolitary(fontResolverInfo.FaceName);
			}
			XFontSource fontSourceByFontName = FontFactory.GetFontSourceByFontName(fontResolverInfo.FaceName);
			xglyphTypeface = new XGlyphTypeface(text, xfontFamily, fontSourceByFontName, fontResolverInfo.StyleSimulations, font);
			GlyphTypefaceCache.AddGlyphTypeface(xglyphTypeface);
			return xglyphTypeface;
		}

		// Token: 0x060003AA RID: 938 RVA: 0x00010448 File Offset: 0x0000E648
		public static XGlyphTypeface GetOrCreateFromGdi(Font gdiFont)
		{
			string text = XGlyphTypeface.ComputeKey(gdiFont);
			XGlyphTypeface xglyphTypeface;
			if (GlyphTypefaceCache.TryGetGlyphTypeface(text, out xglyphTypeface))
			{
				return xglyphTypeface;
			}
			XFontFamily orCreateFromGdi = XFontFamily.GetOrCreateFromGdi(gdiFont);
			XFontSource orCreateFromGdi2 = XFontSource.GetOrCreateFromGdi(text, gdiFont);
			XStyleSimulations xstyleSimulations = XStyleSimulations.None;
			if (gdiFont.Bold && !orCreateFromGdi2.Fontface.os2.IsBold)
			{
				xstyleSimulations |= XStyleSimulations.BoldSimulation;
			}
			if (gdiFont.Italic && !orCreateFromGdi2.Fontface.os2.IsItalic)
			{
				xstyleSimulations |= XStyleSimulations.ItalicSimulation;
			}
			xglyphTypeface = new XGlyphTypeface(text, orCreateFromGdi, orCreateFromGdi2, xstyleSimulations, gdiFont);
			GlyphTypefaceCache.AddGlyphTypeface(xglyphTypeface);
			return xglyphTypeface;
		}

		// Token: 0x170001C9 RID: 457
		// (get) Token: 0x060003AB RID: 939 RVA: 0x000104CD File Offset: 0x0000E6CD
		public XFontFamily FontFamily
		{
			get
			{
				return this._fontFamily;
			}
		}

		// Token: 0x170001CA RID: 458
		// (get) Token: 0x060003AC RID: 940 RVA: 0x000104D5 File Offset: 0x0000E6D5
		internal OpenTypeFontface Fontface
		{
			get
			{
				return this._fontface;
			}
		}

		// Token: 0x170001CB RID: 459
		// (get) Token: 0x060003AD RID: 941 RVA: 0x000104DD File Offset: 0x0000E6DD
		public XFontSource FontSource
		{
			get
			{
				return this._fontSource;
			}
		}

		// Token: 0x060003AE RID: 942 RVA: 0x000104E8 File Offset: 0x0000E6E8
		private void Initialize()
		{
			this._familyName = this._fontface.name.Name;
			if (string.IsNullOrEmpty(this._faceName) || this._faceName.StartsWith("?"))
			{
				this._faceName = this._familyName;
			}
			this._styleName = this._fontface.name.Style;
			this._displayName = this._fontface.name.FullFontName;
			if (string.IsNullOrEmpty(this._displayName))
			{
				this._displayName = this._familyName;
				if (string.IsNullOrEmpty(this._styleName))
				{
					this._displayName = this._displayName + " (" + this._styleName + ")";
				}
			}
			this._isBold = this._fontface.os2.IsBold;
			this._isItalic = this._fontface.os2.IsItalic;
		}

		// Token: 0x170001CC RID: 460
		// (get) Token: 0x060003AF RID: 943 RVA: 0x000105D5 File Offset: 0x0000E7D5
		internal string FaceName
		{
			get
			{
				return this._faceName;
			}
		}

		// Token: 0x170001CD RID: 461
		// (get) Token: 0x060003B0 RID: 944 RVA: 0x000105DD File Offset: 0x0000E7DD
		public string FamilyName
		{
			get
			{
				return this._familyName;
			}
		}

		// Token: 0x170001CE RID: 462
		// (get) Token: 0x060003B1 RID: 945 RVA: 0x000105E5 File Offset: 0x0000E7E5
		public string StyleName
		{
			get
			{
				return this._styleName;
			}
		}

		// Token: 0x170001CF RID: 463
		// (get) Token: 0x060003B2 RID: 946 RVA: 0x000105ED File Offset: 0x0000E7ED
		public string DisplayName
		{
			get
			{
				return this._displayName;
			}
		}

		// Token: 0x170001D0 RID: 464
		// (get) Token: 0x060003B3 RID: 947 RVA: 0x000105F5 File Offset: 0x0000E7F5
		public bool IsBold
		{
			get
			{
				return this._isBold;
			}
		}

		// Token: 0x170001D1 RID: 465
		// (get) Token: 0x060003B4 RID: 948 RVA: 0x000105FD File Offset: 0x0000E7FD
		public bool IsItalic
		{
			get
			{
				return this._isItalic;
			}
		}

		// Token: 0x170001D2 RID: 466
		// (get) Token: 0x060003B5 RID: 949 RVA: 0x00010605 File Offset: 0x0000E805
		public XStyleSimulations StyleSimulations
		{
			get
			{
				return this._styleSimulations;
			}
		}

		// Token: 0x060003B6 RID: 950 RVA: 0x0001060D File Offset: 0x0000E80D
		private string GetFaceNameSuffix()
		{
			if (this.IsBold)
			{
				if (!this.IsItalic)
				{
					return ",Bold";
				}
				return ",BoldItalic";
			}
			else
			{
				if (!this.IsItalic)
				{
					return "";
				}
				return ",Italic";
			}
		}

		// Token: 0x060003B7 RID: 951 RVA: 0x00010640 File Offset: 0x0000E840
		internal string GetBaseName()
		{
			string text = this.DisplayName;
			int num = text.IndexOf("bold", StringComparison.OrdinalIgnoreCase);
			if (num > 0)
			{
				text = text.Substring(0, num) + text.Substring(num + 4, text.Length - num - 4);
			}
			num = text.IndexOf("italic", StringComparison.OrdinalIgnoreCase);
			if (num > 0)
			{
				text = text.Substring(0, num) + text.Substring(num + 6, text.Length - num - 6);
			}
			text = text.Trim();
			return text + this.GetFaceNameSuffix();
		}

		// Token: 0x060003B8 RID: 952 RVA: 0x000106D0 File Offset: 0x0000E8D0
		internal static string ComputeKey(string familyName, FontResolvingOptions fontResolvingOptions)
		{
			string text = "";
			if (fontResolvingOptions.OverrideStyleSimulations)
			{
				switch (fontResolvingOptions.StyleSimulations)
				{
				case XStyleSimulations.None:
					break;
				case XStyleSimulations.BoldSimulation:
					text = "|b+/i-";
					break;
				case XStyleSimulations.ItalicSimulation:
					text = "|b-/i+";
					break;
				case XStyleSimulations.BoldItalicSimulation:
					text = "|b+/i+";
					break;
				default:
					throw new ArgumentOutOfRangeException();
				}
			}
			return string.Concat(new string[]
			{
				"tk:",
				familyName.ToLowerInvariant(),
				fontResolvingOptions.IsItalic ? "/i" : "/n",
				fontResolvingOptions.IsBold ? "/700" : "/400",
				"/5",
				text
			});
		}

		// Token: 0x060003B9 RID: 953 RVA: 0x00010782 File Offset: 0x0000E982
		internal static string ComputeKey(string familyName, bool isBold, bool isItalic)
		{
			return XGlyphTypeface.ComputeKey(familyName, new FontResolvingOptions(FontHelper.CreateStyle(isBold, isItalic)));
		}

		// Token: 0x060003BA RID: 954 RVA: 0x00010798 File Offset: 0x0000E998
		internal static string ComputeKey(Font gdiFont)
		{
			string name = gdiFont.Name;
			string originalFontName = gdiFont.OriginalFontName;
			string systemFontName = gdiFont.SystemFontName;
			string text = name;
			FontStyle style = gdiFont.Style;
			return string.Concat(new string[]
			{
				"tk:",
				text.ToLowerInvariant(),
				((style & FontStyle.Italic) == FontStyle.Italic) ? "/i" : "/n",
				((style & FontStyle.Bold) == FontStyle.Bold) ? "/700" : "/400",
				"/5"
			});
		}

		// Token: 0x170001D3 RID: 467
		// (get) Token: 0x060003BB RID: 955 RVA: 0x0001081C File Offset: 0x0000EA1C
		public string Key
		{
			get
			{
				return this._key;
			}
		}

		// Token: 0x170001D4 RID: 468
		// (get) Token: 0x060003BC RID: 956 RVA: 0x00010824 File Offset: 0x0000EA24
		internal Font GdiFont
		{
			get
			{
				return this._gdiFont;
			}
		}

		// Token: 0x170001D5 RID: 469
		// (get) Token: 0x060003BD RID: 957 RVA: 0x0001082C File Offset: 0x0000EA2C
		internal string DebuggerDisplay
		{
			get
			{
				return string.Format(CultureInfo.InvariantCulture, "{0} - {1} ({2})", new object[] { this.FamilyName, this.StyleName, this.FaceName });
			}
		}

		// Token: 0x0400024F RID: 591
		private const string KeyPrefix = "tk:";

		// Token: 0x04000250 RID: 592
		private readonly XFontFamily _fontFamily;

		// Token: 0x04000251 RID: 593
		private readonly OpenTypeFontface _fontface;

		// Token: 0x04000252 RID: 594
		private readonly XFontSource _fontSource;

		// Token: 0x04000253 RID: 595
		private string _faceName;

		// Token: 0x04000254 RID: 596
		private string _familyName;

		// Token: 0x04000255 RID: 597
		private string _styleName;

		// Token: 0x04000256 RID: 598
		private string _displayName;

		// Token: 0x04000257 RID: 599
		private bool _isBold;

		// Token: 0x04000258 RID: 600
		private bool _isItalic;

		// Token: 0x04000259 RID: 601
		private XStyleSimulations _styleSimulations;

		// Token: 0x0400025A RID: 602
		private readonly string _key;

		// Token: 0x0400025B RID: 603
		private readonly Font _gdiFont;
	}
}
