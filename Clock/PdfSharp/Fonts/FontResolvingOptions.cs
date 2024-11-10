using System;
using PdfSharp.Drawing;

namespace PdfSharp.Fonts
{
	// Token: 0x020000A6 RID: 166
	internal class FontResolvingOptions
	{
		// Token: 0x0600076D RID: 1901 RVA: 0x0001CAFB File Offset: 0x0001ACFB
		public FontResolvingOptions(XFontStyle fontStyle)
		{
			this.FontStyle = fontStyle;
		}

		// Token: 0x0600076E RID: 1902 RVA: 0x0001CB0A File Offset: 0x0001AD0A
		public FontResolvingOptions(XFontStyle fontStyle, XStyleSimulations styleSimulations)
		{
			this.FontStyle = fontStyle;
			this.OverrideStyleSimulations = true;
			this.StyleSimulations = styleSimulations;
		}

		// Token: 0x17000308 RID: 776
		// (get) Token: 0x0600076F RID: 1903 RVA: 0x0001CB27 File Offset: 0x0001AD27
		public bool IsBold
		{
			get
			{
				return (this.FontStyle & XFontStyle.Bold) == XFontStyle.Bold;
			}
		}

		// Token: 0x17000309 RID: 777
		// (get) Token: 0x06000770 RID: 1904 RVA: 0x0001CB34 File Offset: 0x0001AD34
		public bool IsItalic
		{
			get
			{
				return (this.FontStyle & XFontStyle.Italic) == XFontStyle.Italic;
			}
		}

		// Token: 0x1700030A RID: 778
		// (get) Token: 0x06000771 RID: 1905 RVA: 0x0001CB41 File Offset: 0x0001AD41
		public bool IsBoldItalic
		{
			get
			{
				return (this.FontStyle & XFontStyle.BoldItalic) == XFontStyle.BoldItalic;
			}
		}

		// Token: 0x1700030B RID: 779
		// (get) Token: 0x06000772 RID: 1906 RVA: 0x0001CB4E File Offset: 0x0001AD4E
		public bool MustSimulateBold
		{
			get
			{
				return (this.StyleSimulations & XStyleSimulations.BoldSimulation) == XStyleSimulations.BoldSimulation;
			}
		}

		// Token: 0x1700030C RID: 780
		// (get) Token: 0x06000773 RID: 1907 RVA: 0x0001CB5B File Offset: 0x0001AD5B
		public bool MustSimulateItalic
		{
			get
			{
				return (this.StyleSimulations & XStyleSimulations.ItalicSimulation) == XStyleSimulations.ItalicSimulation;
			}
		}

		// Token: 0x040003F9 RID: 1017
		public XFontStyle FontStyle;

		// Token: 0x040003FA RID: 1018
		public bool OverrideStyleSimulations;

		// Token: 0x040003FB RID: 1019
		public XStyleSimulations StyleSimulations;
	}
}
