using System;
using System.Globalization;

namespace PdfSharp.Pdf.Advanced
{
	// Token: 0x020000FC RID: 252
	public sealed class PdfExtGState : PdfDictionary
	{
		// Token: 0x06000985 RID: 2437 RVA: 0x000238E8 File Offset: 0x00021AE8
		public PdfExtGState(PdfDocument document)
			: base(document)
		{
			base.Elements.SetName("/Type", "/ExtGState");
		}

		// Token: 0x06000986 RID: 2438 RVA: 0x00023908 File Offset: 0x00021B08
		internal void SetDefault1()
		{
			base.Elements.SetBoolean("/AIS", false);
			if (base.Elements.ContainsKey("/BM"))
			{
				base.Elements.SetName("/BM", "/Normal");
			}
			this.StrokeAlpha = 1.0;
			this.NonStrokeAlpha = 1.0;
			base.Elements.SetBoolean("/op", false);
			base.Elements.SetBoolean("/OP", false);
			base.Elements.SetBoolean("/SA", true);
			base.Elements.SetName("/SMask", "/None");
		}

		// Token: 0x06000987 RID: 2439 RVA: 0x000239B4 File Offset: 0x00021BB4
		internal void SetDefault2()
		{
			base.Elements.SetBoolean("/AIS", false);
			base.Elements.SetName("/BM", "/Normal");
			this.StrokeAlpha = 1.0;
			this.NonStrokeAlpha = 1.0;
			base.Elements.SetBoolean("/op", true);
			base.Elements.SetBoolean("/OP", true);
			base.Elements.SetInteger("/OPM", 1);
			base.Elements.SetBoolean("/SA", true);
			base.Elements.SetName("/SMask", "/None");
		}

		// Token: 0x17000397 RID: 919
		// (set) Token: 0x06000988 RID: 2440 RVA: 0x00023A5E File Offset: 0x00021C5E
		public double StrokeAlpha
		{
			set
			{
				this._strokeAlpha = value;
				base.Elements.SetReal("/CA", value);
				this.UpdateKey();
			}
		}

		// Token: 0x17000398 RID: 920
		// (set) Token: 0x06000989 RID: 2441 RVA: 0x00023A7E File Offset: 0x00021C7E
		public double NonStrokeAlpha
		{
			set
			{
				this._nonStrokeAlpha = value;
				base.Elements.SetReal("/ca", value);
				this.UpdateKey();
			}
		}

		// Token: 0x17000399 RID: 921
		// (set) Token: 0x0600098A RID: 2442 RVA: 0x00023A9E File Offset: 0x00021C9E
		public bool StrokeOverprint
		{
			set
			{
				this._strokeOverprint = value;
				base.Elements.SetBoolean("/OP", value);
				this.UpdateKey();
			}
		}

		// Token: 0x1700039A RID: 922
		// (set) Token: 0x0600098B RID: 2443 RVA: 0x00023ABE File Offset: 0x00021CBE
		public bool NonStrokeOverprint
		{
			set
			{
				this._nonStrokeOverprint = value;
				base.Elements.SetBoolean("/op", value);
				this.UpdateKey();
			}
		}

		// Token: 0x1700039B RID: 923
		// (set) Token: 0x0600098C RID: 2444 RVA: 0x00023ADE File Offset: 0x00021CDE
		public PdfSoftMask SoftMask
		{
			set
			{
				base.Elements.SetReference("/SMask", value);
			}
		}

		// Token: 0x1700039C RID: 924
		// (get) Token: 0x0600098D RID: 2445 RVA: 0x00023AF1 File Offset: 0x00021CF1
		internal string Key
		{
			get
			{
				return this._key;
			}
		}

		// Token: 0x0600098E RID: 2446 RVA: 0x00023AFC File Offset: 0x00021CFC
		private void UpdateKey()
		{
			this._key = ((int)(1000.0 * this._strokeAlpha)).ToString(CultureInfo.InvariantCulture) + ((int)(1000.0 * this._nonStrokeAlpha)).ToString(CultureInfo.InvariantCulture) + (this._strokeOverprint ? "S" : "s") + (this._nonStrokeOverprint ? "N" : "n");
		}

		// Token: 0x0600098F RID: 2447 RVA: 0x00023B78 File Offset: 0x00021D78
		internal static string MakeKey(double alpha, bool overPaint)
		{
			return ((int)(1000.0 * alpha)).ToString(CultureInfo.InvariantCulture) + (overPaint ? "O" : "0");
		}

		// Token: 0x1700039D RID: 925
		// (get) Token: 0x06000990 RID: 2448 RVA: 0x00023BB4 File Offset: 0x00021DB4
		internal override DictionaryMeta Meta
		{
			get
			{
				return PdfExtGState.Keys.Meta;
			}
		}

		// Token: 0x040004F7 RID: 1271
		private double _strokeAlpha;

		// Token: 0x040004F8 RID: 1272
		private double _nonStrokeAlpha;

		// Token: 0x040004F9 RID: 1273
		private bool _strokeOverprint;

		// Token: 0x040004FA RID: 1274
		private bool _nonStrokeOverprint;

		// Token: 0x040004FB RID: 1275
		private string _key;

		// Token: 0x020000FD RID: 253
		internal sealed class Keys : KeysBase
		{
			// Token: 0x1700039E RID: 926
			// (get) Token: 0x06000991 RID: 2449 RVA: 0x00023BBB File Offset: 0x00021DBB
			internal static DictionaryMeta Meta
			{
				get
				{
					DictionaryMeta dictionaryMeta;
					if ((dictionaryMeta = PdfExtGState.Keys._meta) == null)
					{
						dictionaryMeta = (PdfExtGState.Keys._meta = KeysBase.CreateMeta(typeof(PdfExtGState.Keys)));
					}
					return dictionaryMeta;
				}
			}

			// Token: 0x040004FC RID: 1276
			[KeyInfo(KeyType.Name | KeyType.Optional)]
			public const string Type = "/Type";

			// Token: 0x040004FD RID: 1277
			[KeyInfo(KeyType.Name | KeyType.Integer | KeyType.Optional)]
			public const string LW = "/LW";

			// Token: 0x040004FE RID: 1278
			[KeyInfo(KeyType.Integer | KeyType.Optional)]
			public const string LC = "/LC";

			// Token: 0x040004FF RID: 1279
			[KeyInfo(KeyType.Integer | KeyType.Optional)]
			public const string LJ = "/LJ";

			// Token: 0x04000500 RID: 1280
			[KeyInfo(KeyType.Name | KeyType.Integer | KeyType.Optional)]
			public const string ML = "/ML";

			// Token: 0x04000501 RID: 1281
			[KeyInfo(KeyType.Array | KeyType.Optional)]
			public const string D = "/D";

			// Token: 0x04000502 RID: 1282
			[KeyInfo(KeyType.Name | KeyType.Optional)]
			public const string RI = "/RI";

			// Token: 0x04000503 RID: 1283
			[KeyInfo(KeyType.Name | KeyType.String | KeyType.Optional)]
			public const string OP = "/OP";

			// Token: 0x04000504 RID: 1284
			[KeyInfo(KeyType.Name | KeyType.String | KeyType.Optional)]
			public const string op = "/op";

			// Token: 0x04000505 RID: 1285
			[KeyInfo(KeyType.Integer | KeyType.Optional)]
			public const string OPM = "/OPM";

			// Token: 0x04000506 RID: 1286
			[KeyInfo(KeyType.Array | KeyType.Optional)]
			public const string Font = "/Font";

			// Token: 0x04000507 RID: 1287
			[KeyInfo(KeyType.Integer | KeyType.Array | KeyType.Optional)]
			public const string BG = "/BG";

			// Token: 0x04000508 RID: 1288
			[KeyInfo(KeyType.NameOrArray | KeyType.NameOrDictionary | KeyType.StreamOrArray | KeyType.Optional)]
			public const string BG2 = "/BG2";

			// Token: 0x04000509 RID: 1289
			[KeyInfo(KeyType.Integer | KeyType.Array | KeyType.Optional)]
			public const string UCR = "/UCR";

			// Token: 0x0400050A RID: 1290
			[KeyInfo(KeyType.NameOrArray | KeyType.NameOrDictionary | KeyType.StreamOrArray | KeyType.Optional)]
			public const string UCR2 = "/UCR2";

			// Token: 0x0400050B RID: 1291
			[KeyInfo(KeyType.Name | KeyType.String | KeyType.Optional)]
			public const string SA = "/SA";

			// Token: 0x0400050C RID: 1292
			[KeyInfo(KeyType.NameOrArray | KeyType.Optional)]
			public const string BM = "/BM";

			// Token: 0x0400050D RID: 1293
			[KeyInfo(KeyType.NameOrDictionary | KeyType.Optional)]
			public const string SMask = "/SMask";

			// Token: 0x0400050E RID: 1294
			[KeyInfo(KeyType.Name | KeyType.Integer | KeyType.Optional)]
			public const string CA = "/CA";

			// Token: 0x0400050F RID: 1295
			[KeyInfo(KeyType.Name | KeyType.Integer | KeyType.Optional)]
			public const string ca = "/ca";

			// Token: 0x04000510 RID: 1296
			[KeyInfo(KeyType.Name | KeyType.String | KeyType.Optional)]
			public const string AIS = "/AIS";

			// Token: 0x04000511 RID: 1297
			[KeyInfo(KeyType.Name | KeyType.String | KeyType.Optional)]
			public const string TK = "/TK";

			// Token: 0x04000512 RID: 1298
			private static DictionaryMeta _meta;
		}
	}
}
