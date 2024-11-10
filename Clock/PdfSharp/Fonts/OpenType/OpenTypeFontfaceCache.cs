using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using PdfSharp.Internal;

namespace PdfSharp.Fonts.OpenType
{
	// Token: 0x02000086 RID: 134
	[DebuggerDisplay("{DebuggerDisplay}")]
	internal class OpenTypeFontfaceCache
	{
		// Token: 0x060006E5 RID: 1765 RVA: 0x000195BE File Offset: 0x000177BE
		private OpenTypeFontfaceCache()
		{
			this._fontfaceCache = new Dictionary<string, OpenTypeFontface>(StringComparer.OrdinalIgnoreCase);
			this._fontfacesByCheckSum = new Dictionary<ulong, OpenTypeFontface>();
		}

		// Token: 0x060006E6 RID: 1766 RVA: 0x000195E4 File Offset: 0x000177E4
		public static bool TryGetFontface(string key, out OpenTypeFontface fontface)
		{
			bool flag2;
			try
			{
				Lock.EnterFontFactory();
				bool flag = OpenTypeFontfaceCache.Singleton._fontfaceCache.TryGetValue(key, out fontface);
				flag2 = flag;
			}
			finally
			{
				Lock.ExitFontFactory();
			}
			return flag2;
		}

		// Token: 0x060006E7 RID: 1767 RVA: 0x00019624 File Offset: 0x00017824
		public static bool TryGetFontface(ulong checkSum, out OpenTypeFontface fontface)
		{
			bool flag2;
			try
			{
				Lock.EnterFontFactory();
				bool flag = OpenTypeFontfaceCache.Singleton._fontfacesByCheckSum.TryGetValue(checkSum, out fontface);
				flag2 = flag;
			}
			finally
			{
				Lock.ExitFontFactory();
			}
			return flag2;
		}

		// Token: 0x060006E8 RID: 1768 RVA: 0x00019664 File Offset: 0x00017864
		public static OpenTypeFontface AddFontface(OpenTypeFontface fontface)
		{
			OpenTypeFontface openTypeFontface2;
			try
			{
				Lock.EnterFontFactory();
				OpenTypeFontface openTypeFontface;
				if (OpenTypeFontfaceCache.TryGetFontface(fontface.FullFaceName, out openTypeFontface))
				{
					if (openTypeFontface.CheckSum != fontface.CheckSum)
					{
						throw new InvalidOperationException("OpenTypeFontface with same signature but different bytes.");
					}
					openTypeFontface2 = openTypeFontface;
				}
				else
				{
					OpenTypeFontfaceCache.Singleton._fontfaceCache.Add(fontface.FullFaceName, fontface);
					OpenTypeFontfaceCache.Singleton._fontfacesByCheckSum.Add(fontface.CheckSum, fontface);
					openTypeFontface2 = fontface;
				}
			}
			finally
			{
				Lock.ExitFontFactory();
			}
			return openTypeFontface2;
		}

		// Token: 0x170002F6 RID: 758
		// (get) Token: 0x060006E9 RID: 1769 RVA: 0x000196EC File Offset: 0x000178EC
		private static OpenTypeFontfaceCache Singleton
		{
			get
			{
				if (OpenTypeFontfaceCache._singleton == null)
				{
					try
					{
						Lock.EnterFontFactory();
						if (OpenTypeFontfaceCache._singleton == null)
						{
							OpenTypeFontfaceCache._singleton = new OpenTypeFontfaceCache();
						}
					}
					finally
					{
						Lock.ExitFontFactory();
					}
				}
				return OpenTypeFontfaceCache._singleton;
			}
		}

		// Token: 0x060006EA RID: 1770 RVA: 0x0001973C File Offset: 0x0001793C
		internal static string GetCacheState()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("====================\n");
			stringBuilder.Append("OpenType fontfaces by name\n");
			Dictionary<string, OpenTypeFontface>.KeyCollection keys = OpenTypeFontfaceCache.Singleton._fontfaceCache.Keys;
			int count = keys.Count;
			string[] array = new string[count];
			keys.CopyTo(array, 0);
			Array.Sort<string>(array, StringComparer.OrdinalIgnoreCase);
			foreach (string text in array)
			{
				stringBuilder.AppendFormat("  {0}: {1}\n", text, OpenTypeFontfaceCache.Singleton._fontfaceCache[text].DebuggerDisplay);
			}
			stringBuilder.Append("\n");
			return stringBuilder.ToString();
		}

		// Token: 0x170002F7 RID: 759
		// (get) Token: 0x060006EB RID: 1771 RVA: 0x000197EC File Offset: 0x000179EC
		private string DebuggerDisplay
		{
			get
			{
				return string.Format(CultureInfo.InvariantCulture, "Fontfaces: {0}", new object[] { this._fontfaceCache.Count });
			}
		}

		// Token: 0x0400030F RID: 783
		private static volatile OpenTypeFontfaceCache _singleton;

		// Token: 0x04000310 RID: 784
		private readonly Dictionary<string, OpenTypeFontface> _fontfaceCache;

		// Token: 0x04000311 RID: 785
		private readonly Dictionary<ulong, OpenTypeFontface> _fontfacesByCheckSum;
	}
}
