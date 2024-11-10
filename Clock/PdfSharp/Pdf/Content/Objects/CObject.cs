using System;

namespace PdfSharp.Pdf.Content.Objects
{
	// Token: 0x02000141 RID: 321
	public abstract class CObject : ICloneable
	{
		// Token: 0x06000ADC RID: 2780 RVA: 0x0002ACB4 File Offset: 0x00028EB4
		object ICloneable.Clone()
		{
			return this.Copy();
		}

		// Token: 0x06000ADD RID: 2781 RVA: 0x0002ACBC File Offset: 0x00028EBC
		public CObject Clone()
		{
			return this.Copy();
		}

		// Token: 0x06000ADE RID: 2782 RVA: 0x0002ACC4 File Offset: 0x00028EC4
		protected virtual CObject Copy()
		{
			return (CObject)base.MemberwiseClone();
		}

		// Token: 0x06000ADF RID: 2783
		internal abstract void WriteObject(ContentWriter writer);
	}
}
