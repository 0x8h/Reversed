using System;

namespace PdfSharp.Pdf.Actions
{
	// Token: 0x020000E8 RID: 232
	public sealed class PdfGoToAction : PdfAction
	{
		// Token: 0x0600090A RID: 2314 RVA: 0x00021C96 File Offset: 0x0001FE96
		public PdfGoToAction()
		{
			this.Inititalize();
		}

		// Token: 0x0600090B RID: 2315 RVA: 0x00021CA4 File Offset: 0x0001FEA4
		public PdfGoToAction(PdfDocument document)
			: base(document)
		{
			this.Inititalize();
		}

		// Token: 0x0600090C RID: 2316 RVA: 0x00021CB3 File Offset: 0x0001FEB3
		private void Inititalize()
		{
			base.Elements.SetName("/Type", "/Action");
			base.Elements.SetName("/S", "/Goto");
		}

		// Token: 0x020000E9 RID: 233
		internal new class Keys : PdfAction.Keys
		{
			// Token: 0x040004A2 RID: 1186
			[KeyInfo(KeyType.Name | KeyType.String | KeyType.Integer | KeyType.Array | KeyType.Required)]
			public const string D = "/D";
		}
	}
}
