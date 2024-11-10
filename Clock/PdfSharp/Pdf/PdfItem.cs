using System;
using PdfSharp.Pdf.IO;

namespace PdfSharp.Pdf
{
	// Token: 0x020000C3 RID: 195
	public abstract class PdfItem : ICloneable
	{
		// Token: 0x060007E4 RID: 2020 RVA: 0x0001E3F0 File Offset: 0x0001C5F0
		object ICloneable.Clone()
		{
			return this.Copy();
		}

		// Token: 0x060007E5 RID: 2021 RVA: 0x0001E3F8 File Offset: 0x0001C5F8
		public PdfItem Clone()
		{
			return (PdfItem)this.Copy();
		}

		// Token: 0x060007E6 RID: 2022 RVA: 0x0001E405 File Offset: 0x0001C605
		protected virtual object Copy()
		{
			return base.MemberwiseClone();
		}

		// Token: 0x060007E7 RID: 2023
		internal abstract void WriteObject(PdfWriter writer);
	}
}
