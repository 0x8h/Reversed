using System;
using System.Diagnostics;

namespace PdfSharp.Pdf.Content.Objects
{
	// Token: 0x0200014A RID: 330
	[DebuggerDisplay("(count={Count})")]
	public class CArray : CSequence
	{
		// Token: 0x06000B2A RID: 2858 RVA: 0x0002B31D File Offset: 0x0002951D
		public new CArray Clone()
		{
			return (CArray)this.Copy();
		}

		// Token: 0x06000B2B RID: 2859 RVA: 0x0002B32C File Offset: 0x0002952C
		protected override CObject Copy()
		{
			return base.Copy();
		}

		// Token: 0x06000B2C RID: 2860 RVA: 0x0002B341 File Offset: 0x00029541
		public override string ToString()
		{
			return "[" + base.ToString() + "]";
		}

		// Token: 0x06000B2D RID: 2861 RVA: 0x0002B358 File Offset: 0x00029558
		internal override void WriteObject(ContentWriter writer)
		{
			writer.WriteRaw(this.ToString());
		}
	}
}
