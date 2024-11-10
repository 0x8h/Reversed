using System;
using System.Collections.Generic;
using System.Text;
using PdfSharp.Drawing;
using PdfSharp.Internal;

namespace PdfSharp.Fonts.OpenType
{
	// Token: 0x02000087 RID: 135
	internal class GlyphTypefaceCache
	{
		// Token: 0x060006EC RID: 1772 RVA: 0x00019823 File Offset: 0x00017A23
		private GlyphTypefaceCache()
		{
			this._glyphTypefacesByKey = new Dictionary<string, XGlyphTypeface>();
		}

		// Token: 0x060006ED RID: 1773 RVA: 0x00019838 File Offset: 0x00017A38
		public static bool TryGetGlyphTypeface(string key, out XGlyphTypeface glyphTypeface)
		{
			bool flag2;
			try
			{
				Lock.EnterFontFactory();
				bool flag = GlyphTypefaceCache.Singleton._glyphTypefacesByKey.TryGetValue(key, out glyphTypeface);
				flag2 = flag;
			}
			finally
			{
				Lock.ExitFontFactory();
			}
			return flag2;
		}

		// Token: 0x060006EE RID: 1774 RVA: 0x00019878 File Offset: 0x00017A78
		public static void AddGlyphTypeface(XGlyphTypeface glyphTypeface)
		{
			try
			{
				Lock.EnterFontFactory();
				GlyphTypefaceCache singleton = GlyphTypefaceCache.Singleton;
				singleton._glyphTypefacesByKey.Add(glyphTypeface.Key, glyphTypeface);
			}
			finally
			{
				Lock.ExitFontFactory();
			}
		}

		// Token: 0x170002F8 RID: 760
		// (get) Token: 0x060006EF RID: 1775 RVA: 0x000198BC File Offset: 0x00017ABC
		private static GlyphTypefaceCache Singleton
		{
			get
			{
				if (GlyphTypefaceCache._singleton == null)
				{
					try
					{
						Lock.EnterFontFactory();
						if (GlyphTypefaceCache._singleton == null)
						{
							GlyphTypefaceCache._singleton = new GlyphTypefaceCache();
						}
					}
					finally
					{
						Lock.ExitFontFactory();
					}
				}
				return GlyphTypefaceCache._singleton;
			}
		}

		// Token: 0x060006F0 RID: 1776 RVA: 0x0001990C File Offset: 0x00017B0C
		internal static string GetCacheState()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("====================\n");
			stringBuilder.Append("Glyph typefaces by name\n");
			Dictionary<string, XGlyphTypeface>.KeyCollection keys = GlyphTypefaceCache.Singleton._glyphTypefacesByKey.Keys;
			int count = keys.Count;
			string[] array = new string[count];
			keys.CopyTo(array, 0);
			Array.Sort<string>(array, StringComparer.OrdinalIgnoreCase);
			foreach (string text in array)
			{
				stringBuilder.AppendFormat("  {0}: {1}\n", text, GlyphTypefaceCache.Singleton._glyphTypefacesByKey[text].DebuggerDisplay);
			}
			stringBuilder.Append("\n");
			return stringBuilder.ToString();
		}

		// Token: 0x04000312 RID: 786
		private static volatile GlyphTypefaceCache _singleton;

		// Token: 0x04000313 RID: 787
		private readonly Dictionary<string, XGlyphTypeface> _glyphTypefacesByKey;
	}
}
