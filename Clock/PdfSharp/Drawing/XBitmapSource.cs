using System;
using PdfSharp.Internal;

namespace PdfSharp.Drawing
{
	// Token: 0x02000053 RID: 83
	public abstract class XBitmapSource : XImage
	{
		// Token: 0x1700005A RID: 90
		// (get) Token: 0x060001BE RID: 446 RVA: 0x0000C088 File Offset: 0x0000A288
		public override int PixelWidth
		{
			get
			{
				int width;
				try
				{
					Lock.EnterGdiPlus();
					width = this._gdiImage.Width;
				}
				finally
				{
					Lock.ExitGdiPlus();
				}
				return width;
			}
		}

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x060001BF RID: 447 RVA: 0x0000C0C0 File Offset: 0x0000A2C0
		public override int PixelHeight
		{
			get
			{
				int height;
				try
				{
					Lock.EnterGdiPlus();
					height = this._gdiImage.Height;
				}
				finally
				{
					Lock.ExitGdiPlus();
				}
				return height;
			}
		}
	}
}
