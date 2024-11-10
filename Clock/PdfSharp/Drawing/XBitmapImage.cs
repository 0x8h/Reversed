using System;
using System.Drawing;
using PdfSharp.Internal;

namespace PdfSharp.Drawing
{
	// Token: 0x02000054 RID: 84
	public sealed class XBitmapImage : XBitmapSource
	{
		// Token: 0x060001C1 RID: 449 RVA: 0x0000C100 File Offset: 0x0000A300
		internal XBitmapImage(int width, int height)
		{
			try
			{
				Lock.EnterGdiPlus();
				this._gdiImage = new Bitmap(width, height);
			}
			finally
			{
				Lock.ExitGdiPlus();
			}
			base.Initialize();
		}

		// Token: 0x060001C2 RID: 450 RVA: 0x0000C144 File Offset: 0x0000A344
		public static XBitmapSource CreateBitmap(int width, int height)
		{
			return new XBitmapImage(width, height);
		}
	}
}
