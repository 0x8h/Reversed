using System;

namespace PdfSharp.Pdf.Advanced
{
	// Token: 0x02000116 RID: 278
	public class PdfObjectInternals
	{
		// Token: 0x06000A18 RID: 2584 RVA: 0x000287DF File Offset: 0x000269DF
		internal PdfObjectInternals(PdfObject obj)
		{
			this._obj = obj;
		}

		// Token: 0x170003BA RID: 954
		// (get) Token: 0x06000A19 RID: 2585 RVA: 0x000287EE File Offset: 0x000269EE
		public PdfObjectID ObjectID
		{
			get
			{
				return this._obj.ObjectID;
			}
		}

		// Token: 0x170003BB RID: 955
		// (get) Token: 0x06000A1A RID: 2586 RVA: 0x000287FC File Offset: 0x000269FC
		public int ObjectNumber
		{
			get
			{
				return this._obj.ObjectID.ObjectNumber;
			}
		}

		// Token: 0x170003BC RID: 956
		// (get) Token: 0x06000A1B RID: 2587 RVA: 0x0002881C File Offset: 0x00026A1C
		public int GenerationNumber
		{
			get
			{
				return this._obj.ObjectID.GenerationNumber;
			}
		}

		// Token: 0x170003BD RID: 957
		// (get) Token: 0x06000A1C RID: 2588 RVA: 0x0002883C File Offset: 0x00026A3C
		public string TypeID
		{
			get
			{
				if (this._obj is PdfArray)
				{
					return "array";
				}
				if (this._obj is PdfDictionary)
				{
					return "dictionary";
				}
				return this._obj.GetType().Name;
			}
		}

		// Token: 0x04000584 RID: 1412
		private readonly PdfObject _obj;
	}
}
