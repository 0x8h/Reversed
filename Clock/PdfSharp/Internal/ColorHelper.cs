using System;

namespace PdfSharp.Internal
{
	// Token: 0x020000BC RID: 188
	internal static class ColorHelper
	{
		// Token: 0x060007B8 RID: 1976 RVA: 0x0001DA68 File Offset: 0x0001BC68
		public static float sRgbToScRgb(byte bval)
		{
			float num = (float)bval / 255f;
			if ((double)num <= 0.0)
			{
				return 0f;
			}
			if ((double)num <= 0.04045)
			{
				return num / 12.92f;
			}
			if (num < 1f)
			{
				return (float)Math.Pow(((double)num + 0.055) / 1.055, 2.4);
			}
			return 1f;
		}

		// Token: 0x060007B9 RID: 1977 RVA: 0x0001DADC File Offset: 0x0001BCDC
		public static byte ScRgbTosRgb(float val)
		{
			if ((double)val <= 0.0)
			{
				return 0;
			}
			if ((double)val <= 0.0031308)
			{
				return (byte)(255f * val * 12.92f + 0.5f);
			}
			if ((double)val < 1.0)
			{
				return (byte)(255f * (1.055f * (float)Math.Pow((double)val, 0.41666666666666669) - 0.055f) + 0.5f);
			}
			return byte.MaxValue;
		}
	}
}
