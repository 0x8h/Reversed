using System;
using PdfSharp.Internal;
using PdfSharp.Pdf;

namespace PdfSharp.Fonts
{
	// Token: 0x020000AB RID: 171
	public static class GlobalFontSettings
	{
		// Token: 0x17000315 RID: 789
		// (get) Token: 0x06000786 RID: 1926 RVA: 0x0001CE34 File Offset: 0x0001B034
		// (set) Token: 0x06000787 RID: 1927 RVA: 0x0001CE3C File Offset: 0x0001B03C
		public static IFontResolver FontResolver
		{
			get
			{
				return GlobalFontSettings._fontResolver;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException();
				}
				try
				{
					Lock.EnterFontFactory();
					if (!object.ReferenceEquals(GlobalFontSettings._fontResolver, value))
					{
						if (FontFactory.HasFontSources)
						{
							throw new InvalidOperationException("Must not change font resolver after is was once used.");
						}
						GlobalFontSettings._fontResolver = value;
					}
				}
				finally
				{
					Lock.ExitFontFactory();
				}
			}
		}

		// Token: 0x17000316 RID: 790
		// (get) Token: 0x06000788 RID: 1928 RVA: 0x0001CE98 File Offset: 0x0001B098
		// (set) Token: 0x06000789 RID: 1929 RVA: 0x0001CEAC File Offset: 0x0001B0AC
		public static PdfFontEncoding DefaultFontEncoding
		{
			get
			{
				if (!GlobalFontSettings._fontEncodingInitialized)
				{
					GlobalFontSettings.DefaultFontEncoding = PdfFontEncoding.Unicode;
				}
				return GlobalFontSettings._fontEncoding;
			}
			set
			{
				try
				{
					Lock.EnterFontFactory();
					if (GlobalFontSettings._fontEncodingInitialized)
					{
						if (GlobalFontSettings._fontEncoding != value)
						{
							throw new InvalidOperationException("Must not change DefaultFontEncoding after is was set once.");
						}
					}
					else
					{
						GlobalFontSettings._fontEncoding = value;
						GlobalFontSettings._fontEncodingInitialized = true;
					}
				}
				finally
				{
					Lock.ExitFontFactory();
				}
			}
		}

		// Token: 0x04000403 RID: 1027
		public const string DefaultFontName = "PlatformDefault";

		// Token: 0x04000404 RID: 1028
		private static IFontResolver _fontResolver;

		// Token: 0x04000405 RID: 1029
		private static PdfFontEncoding _fontEncoding;

		// Token: 0x04000406 RID: 1030
		private static bool _fontEncodingInitialized;
	}
}
