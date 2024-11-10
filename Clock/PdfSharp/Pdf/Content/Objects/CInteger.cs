using System;
using System.Diagnostics;
using System.Globalization;

namespace PdfSharp.Pdf.Content.Objects
{
	// Token: 0x02000145 RID: 325
	[DebuggerDisplay("({Value})")]
	public class CInteger : CNumber
	{
		// Token: 0x06000B0B RID: 2827 RVA: 0x0002AFE1 File Offset: 0x000291E1
		public new CInteger Clone()
		{
			return (CInteger)this.Copy();
		}

		// Token: 0x06000B0C RID: 2828 RVA: 0x0002AFF0 File Offset: 0x000291F0
		protected override CObject Copy()
		{
			return base.Copy();
		}

		// Token: 0x1700040D RID: 1037
		// (get) Token: 0x06000B0D RID: 2829 RVA: 0x0002B005 File Offset: 0x00029205
		// (set) Token: 0x06000B0E RID: 2830 RVA: 0x0002B00D File Offset: 0x0002920D
		public int Value
		{
			get
			{
				return this._value;
			}
			set
			{
				this._value = value;
			}
		}

		// Token: 0x06000B0F RID: 2831 RVA: 0x0002B016 File Offset: 0x00029216
		public override string ToString()
		{
			return this._value.ToString(CultureInfo.InvariantCulture);
		}

		// Token: 0x06000B10 RID: 2832 RVA: 0x0002B028 File Offset: 0x00029228
		internal override void WriteObject(ContentWriter writer)
		{
			writer.WriteRaw(this.ToString() + " ");
		}

		// Token: 0x04000631 RID: 1585
		private int _value;
	}
}
