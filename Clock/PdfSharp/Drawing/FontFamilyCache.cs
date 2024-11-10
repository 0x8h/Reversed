using System;
using System.Collections.Generic;
using System.Text;
using PdfSharp.Internal;

namespace PdfSharp.Drawing
{
	// Token: 0x0200005D RID: 93
	internal sealed class FontFamilyCache
	{
		// Token: 0x0600034B RID: 843 RVA: 0x0000F90F File Offset: 0x0000DB0F
		private FontFamilyCache()
		{
			this._familiesByName = new Dictionary<string, FontFamilyInternal>(StringComparer.OrdinalIgnoreCase);
		}

		// Token: 0x0600034C RID: 844 RVA: 0x0000F928 File Offset: 0x0000DB28
		public static FontFamilyInternal GetFamilyByName(string familyName)
		{
			FontFamilyInternal fontFamilyInternal2;
			try
			{
				Lock.EnterFontFactory();
				FontFamilyInternal fontFamilyInternal;
				FontFamilyCache.Singleton._familiesByName.TryGetValue(familyName, out fontFamilyInternal);
				fontFamilyInternal2 = fontFamilyInternal;
			}
			finally
			{
				Lock.ExitFontFactory();
			}
			return fontFamilyInternal2;
		}

		// Token: 0x0600034D RID: 845 RVA: 0x0000F968 File Offset: 0x0000DB68
		public static FontFamilyInternal CacheOrGetFontFamily(FontFamilyInternal fontFamily)
		{
			FontFamilyInternal fontFamilyInternal2;
			try
			{
				Lock.EnterFontFactory();
				FontFamilyInternal fontFamilyInternal;
				if (FontFamilyCache.Singleton._familiesByName.TryGetValue(fontFamily.Name, out fontFamilyInternal))
				{
					fontFamilyInternal2 = fontFamilyInternal;
				}
				else
				{
					FontFamilyCache.Singleton._familiesByName.Add(fontFamily.Name, fontFamily);
					fontFamilyInternal2 = fontFamily;
				}
			}
			finally
			{
				Lock.ExitFontFactory();
			}
			return fontFamilyInternal2;
		}

		// Token: 0x1700019E RID: 414
		// (get) Token: 0x0600034E RID: 846 RVA: 0x0000F9C8 File Offset: 0x0000DBC8
		private static FontFamilyCache Singleton
		{
			get
			{
				if (FontFamilyCache._singleton == null)
				{
					try
					{
						Lock.EnterFontFactory();
						if (FontFamilyCache._singleton == null)
						{
							FontFamilyCache._singleton = new FontFamilyCache();
						}
					}
					finally
					{
						Lock.ExitFontFactory();
					}
				}
				return FontFamilyCache._singleton;
			}
		}

		// Token: 0x0600034F RID: 847 RVA: 0x0000FA18 File Offset: 0x0000DC18
		internal static string GetCacheState()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("====================\n");
			stringBuilder.Append("Font families by name\n");
			Dictionary<string, FontFamilyInternal>.KeyCollection keys = FontFamilyCache.Singleton._familiesByName.Keys;
			int count = keys.Count;
			string[] array = new string[count];
			keys.CopyTo(array, 0);
			Array.Sort<string>(array, StringComparer.OrdinalIgnoreCase);
			foreach (string text in array)
			{
				stringBuilder.AppendFormat("  {0}: {1}\n", text, FontFamilyCache.Singleton._familiesByName[text].DebuggerDisplay);
			}
			stringBuilder.Append("\n");
			return stringBuilder.ToString();
		}

		// Token: 0x0400021F RID: 543
		private static volatile FontFamilyCache _singleton;

		// Token: 0x04000220 RID: 544
		private readonly Dictionary<string, FontFamilyInternal> _familiesByName;
	}
}
