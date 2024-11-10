using System;

namespace PdfSharp.Pdf.Content.Objects
{
	// Token: 0x02000144 RID: 324
	public abstract class CNumber : CObject
	{
		// Token: 0x06000B08 RID: 2824 RVA: 0x0002AFB7 File Offset: 0x000291B7
		public new CNumber Clone()
		{
			return (CNumber)this.Copy();
		}

		// Token: 0x06000B09 RID: 2825 RVA: 0x0002AFC4 File Offset: 0x000291C4
		protected override CObject Copy()
		{
			return base.Copy();
		}
	}
}
