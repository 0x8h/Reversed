using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using PdfSharp.Internal;

namespace PdfSharp.Drawing
{
	// Token: 0x02000036 RID: 54
	[DebuggerDisplay("{DebuggerDisplay}")]
	internal class FontFamilyInternal
	{
		// Token: 0x0600011F RID: 287 RVA: 0x00009858 File Offset: 0x00007A58
		private FontFamilyInternal(string familyName, bool createPlatformObjects)
		{
			this._name = familyName;
			this._sourceName = familyName;
			if (createPlatformObjects)
			{
				this._gdiFontFamily = new FontFamily(familyName);
				this._name = this._gdiFontFamily.Name;
			}
		}

		// Token: 0x06000120 RID: 288 RVA: 0x0000989C File Offset: 0x00007A9C
		private FontFamilyInternal(FontFamily gdiFontFamily)
		{
			this._sourceName = (this._name = gdiFontFamily.Name);
			this._gdiFontFamily = gdiFontFamily;
		}

		// Token: 0x06000121 RID: 289 RVA: 0x000098CC File Offset: 0x00007ACC
		internal static FontFamilyInternal GetOrCreateFromName(string familyName, bool createPlatformObject)
		{
			FontFamilyInternal fontFamilyInternal2;
			try
			{
				Lock.EnterFontFactory();
				FontFamilyInternal fontFamilyInternal = FontFamilyCache.GetFamilyByName(familyName);
				if (fontFamilyInternal == null)
				{
					fontFamilyInternal = new FontFamilyInternal(familyName, createPlatformObject);
					fontFamilyInternal = FontFamilyCache.CacheOrGetFontFamily(fontFamilyInternal);
				}
				fontFamilyInternal2 = fontFamilyInternal;
			}
			finally
			{
				Lock.ExitFontFactory();
			}
			return fontFamilyInternal2;
		}

		// Token: 0x06000122 RID: 290 RVA: 0x00009914 File Offset: 0x00007B14
		internal static FontFamilyInternal GetOrCreateFromGdi(FontFamily gdiFontFamily)
		{
			FontFamilyInternal fontFamilyInternal2;
			try
			{
				Lock.EnterFontFactory();
				FontFamilyInternal fontFamilyInternal = new FontFamilyInternal(gdiFontFamily);
				fontFamilyInternal = FontFamilyCache.CacheOrGetFontFamily(fontFamilyInternal);
				fontFamilyInternal2 = fontFamilyInternal;
			}
			finally
			{
				Lock.ExitFontFactory();
			}
			return fontFamilyInternal2;
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x06000123 RID: 291 RVA: 0x00009950 File Offset: 0x00007B50
		public string SourceName
		{
			get
			{
				return this._sourceName;
			}
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x06000124 RID: 292 RVA: 0x00009958 File Offset: 0x00007B58
		public string Name
		{
			get
			{
				return this._name;
			}
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x06000125 RID: 293 RVA: 0x00009960 File Offset: 0x00007B60
		public FontFamily GdiFamily
		{
			get
			{
				return this._gdiFontFamily;
			}
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x06000126 RID: 294 RVA: 0x00009968 File Offset: 0x00007B68
		internal string DebuggerDisplay
		{
			get
			{
				return string.Format(CultureInfo.InvariantCulture, "FontFamiliy: '{0}'", new object[] { this.Name });
			}
		}

		// Token: 0x040001AE RID: 430
		private readonly string _sourceName;

		// Token: 0x040001AF RID: 431
		private readonly string _name;

		// Token: 0x040001B0 RID: 432
		private readonly FontFamily _gdiFontFamily;
	}
}
