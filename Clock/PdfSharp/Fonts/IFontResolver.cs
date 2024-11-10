using System;

namespace PdfSharp.Fonts
{
	// Token: 0x020000AA RID: 170
	public interface IFontResolver
	{
		// Token: 0x06000784 RID: 1924
		FontResolverInfo ResolveTypeface(string familyName, bool isBold, bool isItalic);

		// Token: 0x06000785 RID: 1925
		byte[] GetFont(string faceName);
	}
}
