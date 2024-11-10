using System;
using PdfSharp.Drawing.Pdf;
using PdfSharp.Pdf.Filters;
using PdfSharp.Pdf.IO;

namespace PdfSharp.Pdf.Advanced
{
	// Token: 0x020000F0 RID: 240
	public sealed class PdfContent : PdfDictionary
	{
		// Token: 0x06000936 RID: 2358 RVA: 0x00022460 File Offset: 0x00020660
		public PdfContent(PdfDocument document)
			: base(document)
		{
		}

		// Token: 0x06000937 RID: 2359 RVA: 0x00022469 File Offset: 0x00020669
		internal PdfContent(PdfPage page)
			: base((page != null) ? page.Owner : null)
		{
		}

		// Token: 0x06000938 RID: 2360 RVA: 0x0002247D File Offset: 0x0002067D
		public PdfContent(PdfDictionary dict)
			: base(dict)
		{
			this.Decode();
		}

		// Token: 0x17000383 RID: 899
		// (set) Token: 0x06000939 RID: 2361 RVA: 0x0002248C File Offset: 0x0002068C
		public bool Compressed
		{
			set
			{
				if (value && base.Elements["/Filter"] == null)
				{
					byte[] array = Filtering.FlateDecode.Encode(base.Stream.Value, this._document.Options.FlateEncodeMode);
					base.Stream.Value = array;
					base.Elements.SetInteger("/Length", base.Stream.Length);
					base.Elements.SetName("/Filter", "/FlateDecode");
				}
			}
		}

		// Token: 0x0600093A RID: 2362 RVA: 0x00022514 File Offset: 0x00020714
		private void Decode()
		{
			if (base.Stream != null && base.Stream.Value != null)
			{
				PdfItem pdfItem = base.Elements["/Filter"];
				if (pdfItem != null)
				{
					byte[] array = Filtering.Decode(base.Stream.Value, pdfItem);
					if (array != null)
					{
						base.Stream.Value = array;
						base.Elements.Remove("/Filter");
						base.Elements.SetInteger("/Length", base.Stream.Length);
					}
				}
			}
		}

		// Token: 0x0600093B RID: 2363 RVA: 0x00022598 File Offset: 0x00020798
		internal void PreserveGraphicsState()
		{
			if (base.Stream != null)
			{
				byte[] value = base.Stream.Value;
				int num = value.Length;
				if (num != 0 && (value[0] != 113 || value[1] != 10))
				{
					byte[] array = new byte[num + 2 + 3];
					array[0] = 113;
					array[1] = 10;
					Array.Copy(value, 0, array, 2, num);
					array[num + 2] = 32;
					array[num + 3] = 81;
					array[num + 4] = 10;
					base.Stream.Value = array;
					base.Elements.SetInteger("/Length", base.Stream.Length);
				}
			}
		}

		// Token: 0x0600093C RID: 2364 RVA: 0x0002262C File Offset: 0x0002082C
		internal override void WriteObject(PdfWriter writer)
		{
			if (this._pdfRenderer != null)
			{
				this._pdfRenderer.Close();
			}
			if (base.Stream != null)
			{
				if (this.Owner.Options.CompressContentStreams && base.Elements.GetName("/Filter").Length == 0)
				{
					base.Stream.Value = Filtering.FlateDecode.Encode(base.Stream.Value, this._document.Options.FlateEncodeMode);
					base.Elements.SetName("/Filter", "/FlateDecode");
				}
				base.Elements.SetInteger("/Length", base.Stream.Length);
			}
			base.WriteObject(writer);
		}

		// Token: 0x17000384 RID: 900
		// (get) Token: 0x0600093D RID: 2365 RVA: 0x000226E7 File Offset: 0x000208E7
		internal override DictionaryMeta Meta
		{
			get
			{
				return PdfContent.Keys.Meta;
			}
		}

		// Token: 0x040004D5 RID: 1237
		internal XGraphicsPdfRenderer _pdfRenderer;

		// Token: 0x020000F1 RID: 241
		internal sealed class Keys : PdfDictionary.PdfStream.Keys
		{
			// Token: 0x17000385 RID: 901
			// (get) Token: 0x0600093E RID: 2366 RVA: 0x000226EE File Offset: 0x000208EE
			public static DictionaryMeta Meta
			{
				get
				{
					DictionaryMeta dictionaryMeta;
					if ((dictionaryMeta = PdfContent.Keys._meta) == null)
					{
						dictionaryMeta = (PdfContent.Keys._meta = KeysBase.CreateMeta(typeof(PdfContent.Keys)));
					}
					return dictionaryMeta;
				}
			}

			// Token: 0x040004D6 RID: 1238
			private static DictionaryMeta _meta;
		}
	}
}
