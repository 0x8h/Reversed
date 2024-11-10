using System;
using System.Collections.Generic;
using System.IO;

namespace PdfSharp.Drawing
{
	// Token: 0x02000079 RID: 121
	public sealed class XPrivateFontCollection
	{
		// Token: 0x060005CE RID: 1486 RVA: 0x00016E40 File Offset: 0x00015040
		private XPrivateFontCollection()
		{
		}

		// Token: 0x170002A0 RID: 672
		// (get) Token: 0x060005CF RID: 1487 RVA: 0x00016E53 File Offset: 0x00015053
		internal static XPrivateFontCollection Singleton
		{
			get
			{
				return XPrivateFontCollection._singleton;
			}
		}

		// Token: 0x060005D0 RID: 1488 RVA: 0x00016E5A File Offset: 0x0001505A
		[Obsolete("Use Add(Stream stream)")]
		public static void AddFont(string filename)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060005D1 RID: 1489 RVA: 0x00016E61 File Offset: 0x00015061
		[Obsolete("Use Add(Stream stream)")]
		public static void AddFont(Stream stream, string facename)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060005D2 RID: 1490 RVA: 0x00016E68 File Offset: 0x00015068
		private static string MakeKey(string familyName, XFontStyle style)
		{
			return XPrivateFontCollection.MakeKey(familyName, (style & XFontStyle.Bold) != XFontStyle.Regular, (style & XFontStyle.Italic) != XFontStyle.Regular);
		}

		// Token: 0x060005D3 RID: 1491 RVA: 0x00016E82 File Offset: 0x00015082
		private static string MakeKey(string familyName, bool bold, bool italic)
		{
			return familyName + "#" + (bold ? "b" : "") + (italic ? "i" : "");
		}

		// Token: 0x040002AC RID: 684
		internal static XPrivateFontCollection _singleton = new XPrivateFontCollection();

		// Token: 0x040002AD RID: 685
		private readonly Dictionary<string, XGlyphTypeface> _typefaces = new Dictionary<string, XGlyphTypeface>();
	}
}
