using System;

namespace PdfSharp.Pdf.IO
{
	// Token: 0x02000171 RID: 369
	internal static class StreamHelper
	{
		// Token: 0x06000C24 RID: 3108 RVA: 0x00031AB8 File Offset: 0x0002FCB8
		public static int WSize(int[] w)
		{
			return w[0] + w[1] + w[2];
		}

		// Token: 0x06000C25 RID: 3109 RVA: 0x00031AC8 File Offset: 0x0002FCC8
		public static uint ReadBytes(byte[] bytes, int index, int byteCount)
		{
			uint num = 0U;
			for (int i = 0; i < byteCount; i++)
			{
				num *= 256U;
				num += (uint)bytes[index + i];
			}
			return num;
		}
	}
}
