using System;
using System.Collections.Generic;
using System.Text;
using PdfSharp.Drawing;
using PdfSharp.Fonts.OpenType;
using PdfSharp.Internal;

namespace PdfSharp.Fonts
{
	// Token: 0x020000AD RID: 173
	internal static class FontFactory
	{
		// Token: 0x06000790 RID: 1936 RVA: 0x0001D0E8 File Offset: 0x0001B2E8
		public static FontResolverInfo ResolveTypeface(string familyName, FontResolvingOptions fontResolvingOptions, string typefaceKey)
		{
			if (string.IsNullOrEmpty(typefaceKey))
			{
				typefaceKey = XGlyphTypeface.ComputeKey(familyName, fontResolvingOptions);
			}
			FontResolverInfo fontResolverInfo2;
			try
			{
				Lock.EnterFontFactory();
				FontResolverInfo fontResolverInfo;
				if (FontFactory.FontResolverInfosByName.TryGetValue(typefaceKey, out fontResolverInfo))
				{
					fontResolverInfo2 = fontResolverInfo;
				}
				else
				{
					IFontResolver fontResolver = GlobalFontSettings.FontResolver;
					if (fontResolver != null)
					{
						fontResolverInfo = fontResolver.ResolveTypeface(familyName, fontResolvingOptions.IsBold, fontResolvingOptions.IsItalic);
						if (fontResolverInfo != null && !(fontResolverInfo is PlatformFontResolverInfo))
						{
							string key = fontResolverInfo.Key;
							FontResolverInfo fontResolverInfo3;
							if (FontFactory.FontResolverInfosByName.TryGetValue(key, out fontResolverInfo3))
							{
								fontResolverInfo = fontResolverInfo3;
								FontFactory.FontResolverInfosByName.Add(typefaceKey, fontResolverInfo);
							}
							else
							{
								FontFactory.FontResolverInfosByName.Add(typefaceKey, fontResolverInfo);
								FontFactory.FontResolverInfosByName.Add(key, fontResolverInfo);
								XFontSource xfontSource;
								if (!FontFactory.FontSourcesByName.TryGetValue(fontResolverInfo.FaceName, out xfontSource))
								{
									byte[] font = fontResolver.GetFont(fontResolverInfo.FaceName);
									XFontSource orCreateFrom = XFontSource.GetOrCreateFrom(font);
									if (string.Compare(fontResolverInfo.FaceName, orCreateFrom.FontName, StringComparison.OrdinalIgnoreCase) != 0)
									{
										FontFactory.FontSourcesByName.Add(fontResolverInfo.FaceName, orCreateFrom);
									}
								}
							}
						}
					}
					else
					{
						fontResolverInfo = PlatformFontResolver.ResolveTypeface(familyName, fontResolvingOptions, typefaceKey);
					}
					fontResolverInfo2 = fontResolverInfo;
				}
			}
			finally
			{
				Lock.ExitFontFactory();
			}
			return fontResolverInfo2;
		}

		// Token: 0x06000791 RID: 1937 RVA: 0x0001D20C File Offset: 0x0001B40C
		public static XFontSource GetFontSourceByFontName(string fontName)
		{
			XFontSource xfontSource;
			if (FontFactory.FontSourcesByName.TryGetValue(fontName, out xfontSource))
			{
				return xfontSource;
			}
			return null;
		}

		// Token: 0x06000792 RID: 1938 RVA: 0x0001D22C File Offset: 0x0001B42C
		public static XFontSource GetFontSourceByTypefaceKey(string typefaceKey)
		{
			XFontSource xfontSource;
			if (FontFactory.FontSourcesByName.TryGetValue(typefaceKey, out xfontSource))
			{
				return xfontSource;
			}
			return null;
		}

		// Token: 0x06000793 RID: 1939 RVA: 0x0001D24B File Offset: 0x0001B44B
		public static bool TryGetFontSourceByKey(ulong key, out XFontSource fontSource)
		{
			return FontFactory.FontSourcesByKey.TryGetValue(key, out fontSource);
		}

		// Token: 0x17000318 RID: 792
		// (get) Token: 0x06000794 RID: 1940 RVA: 0x0001D259 File Offset: 0x0001B459
		public static bool HasFontSources
		{
			get
			{
				return FontFactory.FontSourcesByName.Count > 0;
			}
		}

		// Token: 0x06000795 RID: 1941 RVA: 0x0001D268 File Offset: 0x0001B468
		public static bool TryGetFontResolverInfoByTypefaceKey(string typeFaceKey, out FontResolverInfo info)
		{
			return FontFactory.FontResolverInfosByName.TryGetValue(typeFaceKey, out info);
		}

		// Token: 0x06000796 RID: 1942 RVA: 0x0001D276 File Offset: 0x0001B476
		public static bool TryGetFontSourceByTypefaceKey(string typefaceKey, out XFontSource source)
		{
			return FontFactory.FontSourcesByName.TryGetValue(typefaceKey, out source);
		}

		// Token: 0x06000797 RID: 1943 RVA: 0x0001D284 File Offset: 0x0001B484
		internal static void CacheFontResolverInfo(string typefaceKey, FontResolverInfo fontResolverInfo)
		{
			FontResolverInfo fontResolverInfo2;
			if (FontFactory.FontResolverInfosByName.TryGetValue(typefaceKey, out fontResolverInfo2))
			{
				throw new InvalidOperationException(string.Format("A font file with different content already exists with the specified face name '{0}'.", typefaceKey));
			}
			if (FontFactory.FontResolverInfosByName.TryGetValue(fontResolverInfo.Key, out fontResolverInfo2))
			{
				throw new InvalidOperationException(string.Format("A font resolver already exists with the specified key '{0}'.", fontResolverInfo.Key));
			}
			FontFactory.FontResolverInfosByName.Add(typefaceKey, fontResolverInfo);
			FontFactory.FontResolverInfosByName.Add(fontResolverInfo.Key, fontResolverInfo);
		}

		// Token: 0x06000798 RID: 1944 RVA: 0x0001D2F8 File Offset: 0x0001B4F8
		public static XFontSource CacheFontSource(XFontSource fontSource)
		{
			XFontSource xfontSource2;
			try
			{
				Lock.EnterFontFactory();
				XFontSource xfontSource;
				if (FontFactory.FontSourcesByKey.TryGetValue(fontSource.Key, out xfontSource))
				{
					xfontSource2 = xfontSource;
				}
				else
				{
					if (fontSource.Fontface == null)
					{
						fontSource.Fontface = new OpenTypeFontface(fontSource);
					}
					FontFactory.FontSourcesByKey.Add(fontSource.Key, fontSource);
					FontFactory.FontSourcesByName.Add(fontSource.FontName, fontSource);
					xfontSource2 = fontSource;
				}
			}
			finally
			{
				Lock.ExitFontFactory();
			}
			return xfontSource2;
		}

		// Token: 0x06000799 RID: 1945 RVA: 0x0001D378 File Offset: 0x0001B578
		public static XFontSource CacheNewFontSource(string typefaceKey, XFontSource fontSource)
		{
			XFontSource xfontSource;
			if (FontFactory.FontSourcesByKey.TryGetValue(fontSource.Key, out xfontSource))
			{
				return xfontSource;
			}
			if (fontSource.Fontface == null)
			{
				OpenTypeFontface openTypeFontface = new OpenTypeFontface(fontSource);
				fontSource.Fontface = openTypeFontface;
			}
			FontFactory.FontSourcesByName.Add(typefaceKey, fontSource);
			FontFactory.FontSourcesByName.Add(fontSource.FontName, fontSource);
			FontFactory.FontSourcesByKey.Add(fontSource.Key, fontSource);
			return fontSource;
		}

		// Token: 0x0600079A RID: 1946 RVA: 0x0001D3E4 File Offset: 0x0001B5E4
		public static void CacheExistingFontSourceWithNewTypefaceKey(string typefaceKey, XFontSource fontSource)
		{
			try
			{
				Lock.EnterFontFactory();
				FontFactory.FontSourcesByName.Add(typefaceKey, fontSource);
			}
			finally
			{
				Lock.ExitFontFactory();
			}
		}

		// Token: 0x0600079B RID: 1947 RVA: 0x0001D42C File Offset: 0x0001B62C
		internal static string GetFontCachesState()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("====================\n");
			stringBuilder.Append("Font resolver info by name\n");
			Dictionary<string, FontResolverInfo>.KeyCollection keys = FontFactory.FontResolverInfosByName.Keys;
			int num = keys.Count;
			string[] array = new string[num];
			keys.CopyTo(array, 0);
			Array.Sort<string>(array, StringComparer.OrdinalIgnoreCase);
			foreach (string text in array)
			{
				stringBuilder.AppendFormat("  {0}: {1}\n", text, FontFactory.FontResolverInfosByName[text].DebuggerDisplay);
			}
			stringBuilder.Append("\n");
			stringBuilder.Append("Font source by key and name\n");
			Dictionary<ulong, XFontSource>.KeyCollection keys2 = FontFactory.FontSourcesByKey.Keys;
			num = keys2.Count;
			ulong[] array3 = new ulong[num];
			keys2.CopyTo(array3, 0);
			Array.Sort<ulong>(array3, delegate(ulong x, ulong y)
			{
				if (x == y)
				{
					return 0;
				}
				if (x <= y)
				{
					return -1;
				}
				return 1;
			});
			foreach (ulong num2 in array3)
			{
				stringBuilder.AppendFormat("  {0}: {1}\n", num2, FontFactory.FontSourcesByKey[num2].DebuggerDisplay);
			}
			Dictionary<string, XFontSource>.KeyCollection keys3 = FontFactory.FontSourcesByName.Keys;
			num = keys3.Count;
			array = new string[num];
			keys3.CopyTo(array, 0);
			Array.Sort<string>(array, StringComparer.OrdinalIgnoreCase);
			foreach (string text2 in array)
			{
				stringBuilder.AppendFormat("  {0}: {1}\n", text2, FontFactory.FontSourcesByName[text2].DebuggerDisplay);
			}
			stringBuilder.Append("--------------------\n\n");
			stringBuilder.Append(FontFamilyCache.GetCacheState());
			stringBuilder.Append(GlyphTypefaceCache.GetCacheState());
			stringBuilder.Append(OpenTypeFontfaceCache.GetCacheState());
			return stringBuilder.ToString();
		}

		// Token: 0x04000409 RID: 1033
		private static readonly Dictionary<string, FontResolverInfo> FontResolverInfosByName = new Dictionary<string, FontResolverInfo>(StringComparer.OrdinalIgnoreCase);

		// Token: 0x0400040A RID: 1034
		private static readonly Dictionary<string, XFontSource> FontSourcesByName = new Dictionary<string, XFontSource>(StringComparer.OrdinalIgnoreCase);

		// Token: 0x0400040B RID: 1035
		private static readonly Dictionary<ulong, XFontSource> FontSourcesByKey = new Dictionary<ulong, XFontSource>();
	}
}
