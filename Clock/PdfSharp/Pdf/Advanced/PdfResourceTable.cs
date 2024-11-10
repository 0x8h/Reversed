using System;

namespace PdfSharp.Pdf.Advanced
{
	// Token: 0x020000FE RID: 254
	public class PdfResourceTable
	{
		// Token: 0x06000993 RID: 2451 RVA: 0x00023BE3 File Offset: 0x00021DE3
		public PdfResourceTable(PdfDocument owner)
		{
			if (owner == null)
			{
				throw new ArgumentNullException("owner");
			}
			this._owner = owner;
		}

		// Token: 0x1700039F RID: 927
		// (get) Token: 0x06000994 RID: 2452 RVA: 0x00023C00 File Offset: 0x00021E00
		protected PdfDocument Owner
		{
			get
			{
				return this._owner;
			}
		}

		// Token: 0x04000513 RID: 1299
		private readonly PdfDocument _owner;
	}
}
