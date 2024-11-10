using System;
using System.Drawing;
using PdfSharp.Drawing;

namespace PdfSharp.Fonts
{
	// Token: 0x020000A9 RID: 169
	public static class PlatformFontResolver
	{
		// Token: 0x06000781 RID: 1921 RVA: 0x0001CD18 File Offset: 0x0001AF18
		public static FontResolverInfo ResolveTypeface(string familyName, bool isBold, bool isItalic)
		{
			FontResolvingOptions fontResolvingOptions = new FontResolvingOptions(FontHelper.CreateStyle(isBold, isItalic));
			return PlatformFontResolver.ResolveTypeface(familyName, fontResolvingOptions, XGlyphTypeface.ComputeKey(familyName, fontResolvingOptions));
		}

		// Token: 0x06000782 RID: 1922 RVA: 0x0001CD40 File Offset: 0x0001AF40
		internal static FontResolverInfo ResolveTypeface(string familyName, FontResolvingOptions fontResolvingOptions, string typefaceKey)
		{
			if (string.IsNullOrEmpty(typefaceKey))
			{
				typefaceKey = XGlyphTypeface.ComputeKey(familyName, fontResolvingOptions);
			}
			FontResolverInfo fontResolverInfo;
			if (FontFactory.TryGetFontResolverInfoByTypefaceKey(typefaceKey, out fontResolverInfo))
			{
				return fontResolverInfo;
			}
			Font font;
			XFontSource xfontSource = PlatformFontResolver.CreateFontSource(familyName, fontResolvingOptions, out font, typefaceKey);
			if (xfontSource == null)
			{
				return null;
			}
			if (fontResolvingOptions.OverrideStyleSimulations)
			{
				fontResolverInfo = new PlatformFontResolverInfo(typefaceKey, fontResolvingOptions.MustSimulateBold, fontResolvingOptions.MustSimulateItalic, font);
			}
			else
			{
				bool flag = font.Bold && !xfontSource.Fontface.os2.IsBold;
				bool flag2 = font.Italic && !xfontSource.Fontface.os2.IsItalic;
				fontResolverInfo = new PlatformFontResolverInfo(typefaceKey, flag, flag2, font);
			}
			FontFactory.CacheFontResolverInfo(typefaceKey, fontResolverInfo);
			return fontResolverInfo;
		}

		// Token: 0x06000783 RID: 1923 RVA: 0x0001CDEC File Offset: 0x0001AFEC
		internal static XFontSource CreateFontSource(string familyName, FontResolvingOptions fontResolvingOptions, out Font font, string typefaceKey)
		{
			if (string.IsNullOrEmpty(typefaceKey))
			{
				typefaceKey = XGlyphTypeface.ComputeKey(familyName, fontResolvingOptions);
			}
			FontStyle fontStyle = (FontStyle)(fontResolvingOptions.FontStyle & XFontStyle.BoldItalic);
			XFontSource orCreateFromGdi;
			font = FontHelper.CreateFont(familyName, 10.0, fontStyle, out orCreateFromGdi);
			if (orCreateFromGdi == null)
			{
				orCreateFromGdi = XFontSource.GetOrCreateFromGdi(typefaceKey, font);
			}
			return orCreateFromGdi;
		}
	}
}
