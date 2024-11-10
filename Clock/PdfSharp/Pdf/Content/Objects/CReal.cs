using System;
using System.Diagnostics;
using System.Globalization;

namespace PdfSharp.Pdf.Content.Objects
{
	// Token: 0x02000146 RID: 326
	[DebuggerDisplay("({Value})")]
	public class CReal : CNumber
	{
		// Token: 0x06000B12 RID: 2834 RVA: 0x0002B048 File Offset: 0x00029248
		public new CReal Clone()
		{
			return (CReal)this.Copy();
		}

		// Token: 0x06000B13 RID: 2835 RVA: 0x0002B058 File Offset: 0x00029258
		protected override CObject Copy()
		{
			return base.Copy();
		}

		// Token: 0x1700040E RID: 1038
		// (get) Token: 0x06000B14 RID: 2836 RVA: 0x0002B06D File Offset: 0x0002926D
		// (set) Token: 0x06000B15 RID: 2837 RVA: 0x0002B075 File Offset: 0x00029275
		public double Value
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

		// Token: 0x06000B16 RID: 2838 RVA: 0x0002B07E File Offset: 0x0002927E
		public override string ToString()
		{
			return this._value.ToString("0.0#########", CultureInfo.InvariantCulture);
		}

		// Token: 0x06000B17 RID: 2839 RVA: 0x0002B095 File Offset: 0x00029295
		internal override void WriteObject(ContentWriter writer)
		{
			writer.WriteRaw(this.ToString() + " ");
		}

		// Token: 0x04000632 RID: 1586
		private double _value;
	}
}
