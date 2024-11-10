using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using PdfSharp.Fonts;
using PdfSharp.Pdf.Filters;

namespace PdfSharp.Pdf.Advanced
{
	// Token: 0x02000127 RID: 295
	internal sealed class PdfToUnicodeMap : PdfDictionary
	{
		// Token: 0x06000A6A RID: 2666 RVA: 0x00029745 File Offset: 0x00027945
		public PdfToUnicodeMap(PdfDocument document)
			: base(document)
		{
		}

		// Token: 0x06000A6B RID: 2667 RVA: 0x0002974E File Offset: 0x0002794E
		public PdfToUnicodeMap(PdfDocument document, CMapInfo cmapInfo)
			: base(document)
		{
			this._cmapInfo = cmapInfo;
		}

		// Token: 0x170003DD RID: 989
		// (get) Token: 0x06000A6C RID: 2668 RVA: 0x0002975E File Offset: 0x0002795E
		// (set) Token: 0x06000A6D RID: 2669 RVA: 0x00029766 File Offset: 0x00027966
		public CMapInfo CMapInfo
		{
			get
			{
				return this._cmapInfo;
			}
			set
			{
				this._cmapInfo = value;
			}
		}

		// Token: 0x06000A6E RID: 2670 RVA: 0x00029770 File Offset: 0x00027970
		internal override void PrepareForSave()
		{
			base.PrepareForSave();
			string text = "/CIDInit /ProcSet findresource begin\n12 dict begin\nbegincmap\n/CIDSystemInfo << /Registry (Adobe)/Ordering (UCS)/Supplement 0>> def\n/CMapName /Adobe-Identity-UCS def /CMapType 2 def\n";
			string text2 = "endcmap CMapName currentdict /CMap defineresource pop end end";
			Dictionary<int, char> dictionary = new Dictionary<int, char>();
			int num = 65536;
			int num2 = -1;
			foreach (KeyValuePair<char, int> keyValuePair in this._cmapInfo.CharacterToGlyphIndex)
			{
				int value = keyValuePair.Value;
				num = Math.Min(num, value);
				num2 = Math.Max(num2, value);
				dictionary[value] = keyValuePair.Key;
			}
			MemoryStream memoryStream = new MemoryStream();
			StreamWriter streamWriter = new StreamWriter(memoryStream, Encoding.ASCII);
			streamWriter.Write(text);
			streamWriter.WriteLine("1 begincodespacerange");
			streamWriter.WriteLine(string.Format("<{0:X4}><{1:X4}>", num, num2));
			streamWriter.WriteLine("endcodespacerange");
			streamWriter.WriteLine(string.Format("{0} beginbfrange", dictionary.Count));
			foreach (KeyValuePair<int, char> keyValuePair2 in dictionary)
			{
				streamWriter.WriteLine(string.Format("<{0:X4}><{0:X4}><{1:X4}>", keyValuePair2.Key, (int)keyValuePair2.Value));
			}
			streamWriter.WriteLine("endbfrange");
			streamWriter.Write(text2);
			streamWriter.Close();
			byte[] array = memoryStream.ToArray();
			memoryStream.Close();
			if (this.Owner.Options.CompressContentStreams)
			{
				base.Elements.SetName("/Filter", "/FlateDecode");
				array = Filtering.FlateDecode.Encode(array, this._document.Options.FlateEncodeMode);
			}
			else
			{
				base.Elements.Remove("/Filter");
			}
			if (base.Stream == null)
			{
				base.CreateStream(array);
				return;
			}
			base.Stream.Value = array;
			base.Elements.SetInteger("/Length", base.Stream.Length);
		}

		// Token: 0x040005C8 RID: 1480
		private CMapInfo _cmapInfo;

		// Token: 0x02000128 RID: 296
		public sealed class Keys : PdfDictionary.PdfStream.Keys
		{
		}
	}
}
