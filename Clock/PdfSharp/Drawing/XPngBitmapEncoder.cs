using System;
using System.Drawing.Imaging;
using System.IO;
using PdfSharp.Internal;

namespace PdfSharp.Drawing
{
	// Token: 0x02000051 RID: 81
	internal sealed class XPngBitmapEncoder : XBitmapEncoder
	{
		// Token: 0x0600019E RID: 414 RVA: 0x0000B65F File Offset: 0x0000985F
		internal XPngBitmapEncoder()
		{
		}

		// Token: 0x0600019F RID: 415 RVA: 0x0000B668 File Offset: 0x00009868
		public override void Save(Stream stream)
		{
			if (base.Source == null)
			{
				throw new InvalidOperationException("No image source.");
			}
			if (base.Source.AssociatedGraphics != null)
			{
				base.Source.DisassociateWithGraphics();
			}
			try
			{
				Lock.EnterGdiPlus();
				base.Source._gdiImage.Save(stream, ImageFormat.Png);
			}
			finally
			{
				Lock.ExitGdiPlus();
			}
		}
	}
}
