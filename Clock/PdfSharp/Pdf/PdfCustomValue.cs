using System;

namespace PdfSharp.Pdf
{
	// Token: 0x02000194 RID: 404
	public class PdfCustomValue : PdfDictionary
	{
		// Token: 0x06000CDA RID: 3290 RVA: 0x00034325 File Offset: 0x00032525
		public PdfCustomValue()
		{
			base.CreateStream(new byte[0]);
		}

		// Token: 0x06000CDB RID: 3291 RVA: 0x0003433A File Offset: 0x0003253A
		public PdfCustomValue(byte[] bytes)
		{
			base.CreateStream(bytes);
		}

		// Token: 0x06000CDC RID: 3292 RVA: 0x0003434A File Offset: 0x0003254A
		internal PdfCustomValue(PdfDocument document)
			: base(document)
		{
			base.CreateStream(new byte[0]);
		}

		// Token: 0x06000CDD RID: 3293 RVA: 0x00034360 File Offset: 0x00032560
		internal PdfCustomValue(PdfDictionary dict)
			: base(dict)
		{
		}

		// Token: 0x17000460 RID: 1120
		// (get) Token: 0x06000CDE RID: 3294 RVA: 0x00034369 File Offset: 0x00032569
		// (set) Token: 0x06000CDF RID: 3295 RVA: 0x00034376 File Offset: 0x00032576
		public byte[] Value
		{
			get
			{
				return base.Stream.Value;
			}
			set
			{
				base.Stream.Value = value;
			}
		}

		// Token: 0x04000843 RID: 2115
		public PdfCustomValueCompressionMode CompressionMode;
	}
}
