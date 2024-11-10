using System;
using System.IO;

namespace PdfSharp.Drawing
{
	// Token: 0x02000050 RID: 80
	public abstract class XBitmapEncoder
	{
		// Token: 0x06000199 RID: 409 RVA: 0x0000B63F File Offset: 0x0000983F
		internal XBitmapEncoder()
		{
		}

		// Token: 0x0600019A RID: 410 RVA: 0x0000B647 File Offset: 0x00009847
		public static XBitmapEncoder GetPngEncoder()
		{
			return new XPngBitmapEncoder();
		}

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x0600019B RID: 411 RVA: 0x0000B64E File Offset: 0x0000984E
		// (set) Token: 0x0600019C RID: 412 RVA: 0x0000B656 File Offset: 0x00009856
		public XBitmapSource Source
		{
			get
			{
				return this._source;
			}
			set
			{
				this._source = value;
			}
		}

		// Token: 0x0600019D RID: 413
		public abstract void Save(Stream stream);

		// Token: 0x040001EF RID: 495
		private XBitmapSource _source;
	}
}
