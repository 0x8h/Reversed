using System;
using System.Drawing;

namespace PdfSharp.Fonts
{
	// Token: 0x020000A8 RID: 168
	internal class PlatformFontResolverInfo : FontResolverInfo
	{
		// Token: 0x0600077F RID: 1919 RVA: 0x0001CCFB File Offset: 0x0001AEFB
		public PlatformFontResolverInfo(string faceName, bool mustSimulateBold, bool mustSimulateItalic, Font gdiFont)
			: base(faceName, mustSimulateBold, mustSimulateItalic)
		{
			this._gdiFont = gdiFont;
		}

		// Token: 0x17000314 RID: 788
		// (get) Token: 0x06000780 RID: 1920 RVA: 0x0001CD0E File Offset: 0x0001AF0E
		public Font GdiFont
		{
			get
			{
				return this._gdiFont;
			}
		}

		// Token: 0x04000402 RID: 1026
		private readonly Font _gdiFont;
	}
}
