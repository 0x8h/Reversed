using System;
using System.Drawing;
using PdfSharp.Fonts;
using PdfSharp.Fonts.OpenType;

namespace PdfSharp.Drawing
{
	// Token: 0x0200005E RID: 94
	public sealed class XFontFamily
	{
		// Token: 0x06000350 RID: 848 RVA: 0x0000FAC7 File Offset: 0x0000DCC7
		public XFontFamily(string familyName)
		{
			this.FamilyInternal = FontFamilyInternal.GetOrCreateFromName(familyName, true);
		}

		// Token: 0x06000351 RID: 849 RVA: 0x0000FADC File Offset: 0x0000DCDC
		internal XFontFamily(string familyName, bool createPlatformObjects)
		{
			this.FamilyInternal = FontFamilyInternal.GetOrCreateFromName(familyName, createPlatformObjects);
		}

		// Token: 0x06000352 RID: 850 RVA: 0x0000FAF1 File Offset: 0x0000DCF1
		private XFontFamily(FontFamilyInternal fontFamilyInternal)
		{
			this.FamilyInternal = fontFamilyInternal;
		}

		// Token: 0x06000353 RID: 851 RVA: 0x0000FB00 File Offset: 0x0000DD00
		internal static XFontFamily CreateFromName_not_used(string name, bool createPlatformFamily)
		{
			return new XFontFamily(name);
		}

		// Token: 0x06000354 RID: 852 RVA: 0x0000FB18 File Offset: 0x0000DD18
		internal static XFontFamily CreateSolitary(string name)
		{
			FontFamilyInternal fontFamilyInternal = FontFamilyCache.GetFamilyByName(name);
			if (fontFamilyInternal == null)
			{
				fontFamilyInternal = FontFamilyInternal.GetOrCreateFromName(name, false);
				fontFamilyInternal = FontFamilyCache.CacheOrGetFontFamily(fontFamilyInternal);
			}
			return new XFontFamily(fontFamilyInternal);
		}

		// Token: 0x06000355 RID: 853 RVA: 0x0000FB44 File Offset: 0x0000DD44
		internal static XFontFamily GetOrCreateFromGdi(Font font)
		{
			FontFamilyInternal orCreateFromGdi = FontFamilyInternal.GetOrCreateFromGdi(font.FontFamily);
			return new XFontFamily(orCreateFromGdi);
		}

		// Token: 0x1700019F RID: 415
		// (get) Token: 0x06000356 RID: 854 RVA: 0x0000FB63 File Offset: 0x0000DD63
		public string Name
		{
			get
			{
				return this.FamilyInternal.Name;
			}
		}

		// Token: 0x06000357 RID: 855 RVA: 0x0000FB70 File Offset: 0x0000DD70
		public int GetCellAscent(XFontStyle style)
		{
			OpenTypeDescriptor openTypeDescriptor = (OpenTypeDescriptor)FontDescriptorCache.GetOrCreateDescriptor(this.Name, style);
			return openTypeDescriptor.Ascender;
		}

		// Token: 0x06000358 RID: 856 RVA: 0x0000FB98 File Offset: 0x0000DD98
		public int GetCellDescent(XFontStyle style)
		{
			OpenTypeDescriptor openTypeDescriptor = (OpenTypeDescriptor)FontDescriptorCache.GetOrCreateDescriptor(this.Name, style);
			return openTypeDescriptor.Descender;
		}

		// Token: 0x06000359 RID: 857 RVA: 0x0000FBC0 File Offset: 0x0000DDC0
		public int GetEmHeight(XFontStyle style)
		{
			OpenTypeDescriptor openTypeDescriptor = (OpenTypeDescriptor)FontDescriptorCache.GetOrCreateDescriptor(this.Name, style);
			return openTypeDescriptor.UnitsPerEm;
		}

		// Token: 0x0600035A RID: 858 RVA: 0x0000FBE8 File Offset: 0x0000DDE8
		public int GetLineSpacing(XFontStyle style)
		{
			OpenTypeDescriptor openTypeDescriptor = (OpenTypeDescriptor)FontDescriptorCache.GetOrCreateDescriptor(this.Name, style);
			return openTypeDescriptor.LineSpacing;
		}

		// Token: 0x0600035B RID: 859 RVA: 0x0000FC0F File Offset: 0x0000DE0F
		public bool IsStyleAvailable(XFontStyle style)
		{
			throw new InvalidOperationException("In CORE build it is the responsibility of the developer to provide all required font faces.");
		}

		// Token: 0x170001A0 RID: 416
		// (get) Token: 0x0600035C RID: 860 RVA: 0x0000FC1B File Offset: 0x0000DE1B
		[Obsolete("Use platform API directly.")]
		public static XFontFamily[] Families
		{
			get
			{
				throw new InvalidOperationException("Obsolete and not implemted any more.");
			}
		}

		// Token: 0x0600035D RID: 861 RVA: 0x0000FC27 File Offset: 0x0000DE27
		[Obsolete("Use platform API directly.")]
		public static XFontFamily[] GetFamilies(XGraphics graphics)
		{
			throw new InvalidOperationException("Obsolete and not implemted any more.");
		}

		// Token: 0x04000221 RID: 545
		internal FontFamilyInternal FamilyInternal;
	}
}
