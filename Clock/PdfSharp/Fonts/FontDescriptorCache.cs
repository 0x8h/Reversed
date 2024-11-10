using System;
using System.Collections.Generic;
using PdfSharp.Drawing;
using PdfSharp.Fonts.OpenType;
using PdfSharp.Internal;

namespace PdfSharp.Fonts
{
	// Token: 0x020000AC RID: 172
	internal sealed class FontDescriptorCache
	{
		// Token: 0x0600078A RID: 1930 RVA: 0x0001CF00 File Offset: 0x0001B100
		private FontDescriptorCache()
		{
			this._cache = new Dictionary<string, FontDescriptor>();
		}

		// Token: 0x0600078B RID: 1931 RVA: 0x0001CF14 File Offset: 0x0001B114
		public static FontDescriptor GetOrCreateDescriptorFor(XFont font)
		{
			if (font == null)
			{
				throw new ArgumentNullException("font");
			}
			string text = FontDescriptor.ComputeKey(font);
			FontDescriptor fontDescriptor2;
			try
			{
				Lock.EnterFontFactory();
				FontDescriptor fontDescriptor;
				if (!FontDescriptorCache.Singleton._cache.TryGetValue(text, out fontDescriptor))
				{
					fontDescriptor = new OpenTypeDescriptor(text, font);
					FontDescriptorCache.Singleton._cache.Add(text, fontDescriptor);
				}
				fontDescriptor2 = fontDescriptor;
			}
			finally
			{
				Lock.ExitFontFactory();
			}
			return fontDescriptor2;
		}

		// Token: 0x0600078C RID: 1932 RVA: 0x0001CF84 File Offset: 0x0001B184
		public static FontDescriptor GetOrCreateDescriptor(string fontFamilyName, XFontStyle style)
		{
			if (string.IsNullOrEmpty(fontFamilyName))
			{
				throw new ArgumentNullException("fontFamilyName");
			}
			string text = FontDescriptor.ComputeKey(fontFamilyName, style);
			FontDescriptor fontDescriptor;
			try
			{
				Lock.EnterFontFactory();
				FontDescriptor orCreateDescriptorFor;
				if (!FontDescriptorCache.Singleton._cache.TryGetValue(text, out orCreateDescriptorFor))
				{
					XFont xfont = new XFont(fontFamilyName, 10.0, style);
					orCreateDescriptorFor = FontDescriptorCache.GetOrCreateDescriptorFor(xfont);
					if (FontDescriptorCache.Singleton._cache.ContainsKey(text))
					{
						FontDescriptorCache.Singleton.GetType();
					}
					else
					{
						FontDescriptorCache.Singleton._cache.Add(text, orCreateDescriptorFor);
					}
				}
				fontDescriptor = orCreateDescriptorFor;
			}
			finally
			{
				Lock.ExitFontFactory();
			}
			return fontDescriptor;
		}

		// Token: 0x0600078D RID: 1933 RVA: 0x0001D028 File Offset: 0x0001B228
		public static FontDescriptor GetOrCreateDescriptor(string idName, byte[] fontData)
		{
			string text = FontDescriptor.ComputeKey(idName);
			FontDescriptor fontDescriptor;
			try
			{
				Lock.EnterFontFactory();
				FontDescriptor orCreateOpenTypeDescriptor;
				if (!FontDescriptorCache.Singleton._cache.TryGetValue(text, out orCreateOpenTypeDescriptor))
				{
					orCreateOpenTypeDescriptor = FontDescriptorCache.GetOrCreateOpenTypeDescriptor(text, idName, fontData);
					FontDescriptorCache.Singleton._cache.Add(text, orCreateOpenTypeDescriptor);
				}
				fontDescriptor = orCreateOpenTypeDescriptor;
			}
			finally
			{
				Lock.ExitFontFactory();
			}
			return fontDescriptor;
		}

		// Token: 0x0600078E RID: 1934 RVA: 0x0001D08C File Offset: 0x0001B28C
		private static OpenTypeDescriptor GetOrCreateOpenTypeDescriptor(string fontDescriptorKey, string idName, byte[] fontData)
		{
			return new OpenTypeDescriptor(fontDescriptorKey, idName, fontData);
		}

		// Token: 0x17000317 RID: 791
		// (get) Token: 0x0600078F RID: 1935 RVA: 0x0001D098 File Offset: 0x0001B298
		private static FontDescriptorCache Singleton
		{
			get
			{
				if (FontDescriptorCache._singleton == null)
				{
					try
					{
						Lock.EnterFontFactory();
						if (FontDescriptorCache._singleton == null)
						{
							FontDescriptorCache._singleton = new FontDescriptorCache();
						}
					}
					finally
					{
						Lock.ExitFontFactory();
					}
				}
				return FontDescriptorCache._singleton;
			}
		}

		// Token: 0x04000407 RID: 1031
		private static volatile FontDescriptorCache _singleton;

		// Token: 0x04000408 RID: 1032
		private readonly Dictionary<string, FontDescriptor> _cache;
	}
}
