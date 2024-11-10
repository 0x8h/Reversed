using System;
using System.Collections.Generic;

namespace PdfSharp.Pdf.Advanced
{
	// Token: 0x020000F6 RID: 246
	internal sealed class PdfCrossReferenceStream : PdfTrailer
	{
		// Token: 0x0600095F RID: 2399 RVA: 0x0002303D File Offset: 0x0002123D
		public PdfCrossReferenceStream(PdfDocument document)
			: base(document)
		{
		}

		// Token: 0x1700038E RID: 910
		// (get) Token: 0x06000960 RID: 2400 RVA: 0x00023051 File Offset: 0x00021251
		internal override DictionaryMeta Meta
		{
			get
			{
				return PdfCrossReferenceStream.Keys.Meta;
			}
		}

		// Token: 0x040004E4 RID: 1252
		public readonly List<PdfCrossReferenceStream.CrossReferenceStreamEntry> Entries = new List<PdfCrossReferenceStream.CrossReferenceStreamEntry>();

		// Token: 0x020000F7 RID: 247
		public struct CrossReferenceStreamEntry
		{
			// Token: 0x040004E5 RID: 1253
			public uint Type;

			// Token: 0x040004E6 RID: 1254
			public uint Field2;

			// Token: 0x040004E7 RID: 1255
			public uint Field3;
		}

		// Token: 0x020000F8 RID: 248
		public new class Keys : PdfTrailer.Keys
		{
			// Token: 0x1700038F RID: 911
			// (get) Token: 0x06000961 RID: 2401 RVA: 0x00023058 File Offset: 0x00021258
			public new static DictionaryMeta Meta
			{
				get
				{
					DictionaryMeta dictionaryMeta;
					if ((dictionaryMeta = PdfCrossReferenceStream.Keys._meta) == null)
					{
						dictionaryMeta = (PdfCrossReferenceStream.Keys._meta = KeysBase.CreateMeta(typeof(PdfCrossReferenceStream.Keys)));
					}
					return dictionaryMeta;
				}
			}

			// Token: 0x040004E8 RID: 1256
			[KeyInfo(KeyType.Name | KeyType.Required, FixedValue = "XRef")]
			public const string Type = "/Type";

			// Token: 0x040004E9 RID: 1257
			[KeyInfo(KeyType.Integer | KeyType.Required)]
			public new const string Size = "/Size";

			// Token: 0x040004EA RID: 1258
			[KeyInfo(KeyType.Array | KeyType.Optional)]
			public const string Index = "/Index";

			// Token: 0x040004EB RID: 1259
			[KeyInfo(KeyType.Integer | KeyType.Optional)]
			public new const string Prev = "/Prev";

			// Token: 0x040004EC RID: 1260
			[KeyInfo(KeyType.Array | KeyType.Required)]
			public const string W = "/W";

			// Token: 0x040004ED RID: 1261
			private static DictionaryMeta _meta;
		}
	}
}
