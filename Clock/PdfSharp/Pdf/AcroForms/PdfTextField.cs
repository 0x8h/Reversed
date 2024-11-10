using System;
using PdfSharp.Drawing;
using PdfSharp.Pdf.Advanced;
using PdfSharp.Pdf.Internal;

namespace PdfSharp.Pdf.AcroForms
{
	// Token: 0x020000E3 RID: 227
	public sealed class PdfTextField : PdfAcroField
	{
		// Token: 0x060008F2 RID: 2290 RVA: 0x00021920 File Offset: 0x0001FB20
		internal PdfTextField(PdfDocument document)
			: base(document)
		{
		}

		// Token: 0x060008F3 RID: 2291 RVA: 0x00021958 File Offset: 0x0001FB58
		internal PdfTextField(PdfDictionary dict)
			: base(dict)
		{
		}

		// Token: 0x17000369 RID: 873
		// (get) Token: 0x060008F4 RID: 2292 RVA: 0x00021990 File Offset: 0x0001FB90
		// (set) Token: 0x060008F5 RID: 2293 RVA: 0x000219A2 File Offset: 0x0001FBA2
		public string Text
		{
			get
			{
				return base.Elements.GetString("/V");
			}
			set
			{
				base.Elements.SetString("/V", value);
				this.RenderAppearance();
			}
		}

		// Token: 0x1700036A RID: 874
		// (get) Token: 0x060008F6 RID: 2294 RVA: 0x000219BB File Offset: 0x0001FBBB
		// (set) Token: 0x060008F7 RID: 2295 RVA: 0x000219C3 File Offset: 0x0001FBC3
		public XFont Font
		{
			get
			{
				return this._font;
			}
			set
			{
				this._font = value;
			}
		}

		// Token: 0x1700036B RID: 875
		// (get) Token: 0x060008F8 RID: 2296 RVA: 0x000219CC File Offset: 0x0001FBCC
		// (set) Token: 0x060008F9 RID: 2297 RVA: 0x000219D4 File Offset: 0x0001FBD4
		public XColor ForeColor
		{
			get
			{
				return this._foreColor;
			}
			set
			{
				this._foreColor = value;
			}
		}

		// Token: 0x1700036C RID: 876
		// (get) Token: 0x060008FA RID: 2298 RVA: 0x000219DD File Offset: 0x0001FBDD
		// (set) Token: 0x060008FB RID: 2299 RVA: 0x000219E5 File Offset: 0x0001FBE5
		public XColor BackColor
		{
			get
			{
				return this._backColor;
			}
			set
			{
				this._backColor = value;
			}
		}

		// Token: 0x1700036D RID: 877
		// (get) Token: 0x060008FC RID: 2300 RVA: 0x000219EE File Offset: 0x0001FBEE
		// (set) Token: 0x060008FD RID: 2301 RVA: 0x00021A00 File Offset: 0x0001FC00
		public int MaxLength
		{
			get
			{
				return base.Elements.GetInteger("/MaxLen");
			}
			set
			{
				base.Elements.SetInteger("/MaxLen", value);
			}
		}

		// Token: 0x1700036E RID: 878
		// (get) Token: 0x060008FE RID: 2302 RVA: 0x00021A13 File Offset: 0x0001FC13
		// (set) Token: 0x060008FF RID: 2303 RVA: 0x00021A27 File Offset: 0x0001FC27
		public bool MultiLine
		{
			get
			{
				return (base.Flags & PdfAcroFieldFlags.Multiline) != (PdfAcroFieldFlags)0;
			}
			set
			{
				if (value)
				{
					base.SetFlags |= PdfAcroFieldFlags.Multiline;
					return;
				}
				base.SetFlags &= ~PdfAcroFieldFlags.Multiline;
			}
		}

		// Token: 0x1700036F RID: 879
		// (get) Token: 0x06000900 RID: 2304 RVA: 0x00021A51 File Offset: 0x0001FC51
		// (set) Token: 0x06000901 RID: 2305 RVA: 0x00021A65 File Offset: 0x0001FC65
		public bool Password
		{
			get
			{
				return (base.Flags & PdfAcroFieldFlags.Password) != (PdfAcroFieldFlags)0;
			}
			set
			{
				if (value)
				{
					base.SetFlags |= PdfAcroFieldFlags.Password;
					return;
				}
				base.SetFlags &= ~PdfAcroFieldFlags.Password;
			}
		}

		// Token: 0x06000902 RID: 2306 RVA: 0x00021A90 File Offset: 0x0001FC90
		private void RenderAppearance()
		{
			PdfRectangle rectangle = base.Elements.GetRectangle("/Rect");
			XForm xform = new XForm(this._document, rectangle.Size);
			XGraphics xgraphics = XGraphics.FromForm(xform);
			if (this._backColor != XColor.Empty)
			{
				xgraphics.DrawRectangle(new XSolidBrush(this.BackColor), rectangle.ToXRect() - rectangle.Location);
			}
			string text = this.Text;
			if (text.Length > 0)
			{
				xgraphics.DrawString(this.Text, this.Font, new XSolidBrush(this.ForeColor), rectangle.ToXRect() - rectangle.Location + new XPoint(2.0, 0.0), XStringFormats.TopLeft);
			}
			xform.DrawingFinished();
			xform.PdfForm.Elements.Add("/FormType", new PdfLiteral("1"));
			PdfDictionary pdfDictionary = base.Elements["/AP"] as PdfDictionary;
			if (pdfDictionary == null)
			{
				pdfDictionary = new PdfDictionary(this._document);
				base.Elements["/AP"] = pdfDictionary;
			}
			pdfDictionary.Elements["/N"] = xform.PdfForm.Reference;
			PdfFormXObject pdfForm = xform.PdfForm;
			string text2 = pdfForm.Stream.ToString();
			text2 = "/Tx BMC\n" + text2 + "\nEMC";
			pdfForm.Stream.Value = new RawEncoding().GetBytes(text2);
		}

		// Token: 0x06000903 RID: 2307 RVA: 0x00021C16 File Offset: 0x0001FE16
		internal override void PrepareForSave()
		{
			base.PrepareForSave();
			this.RenderAppearance();
		}

		// Token: 0x17000370 RID: 880
		// (get) Token: 0x06000904 RID: 2308 RVA: 0x00021C24 File Offset: 0x0001FE24
		internal override DictionaryMeta Meta
		{
			get
			{
				return PdfTextField.Keys.Meta;
			}
		}

		// Token: 0x04000495 RID: 1173
		private XFont _font = new XFont("Courier New", 10.0);

		// Token: 0x04000496 RID: 1174
		private XColor _foreColor = XColors.Black;

		// Token: 0x04000497 RID: 1175
		private XColor _backColor = XColor.Empty;

		// Token: 0x020000E4 RID: 228
		public new class Keys : PdfAcroField.Keys
		{
			// Token: 0x17000371 RID: 881
			// (get) Token: 0x06000905 RID: 2309 RVA: 0x00021C2B File Offset: 0x0001FE2B
			internal static DictionaryMeta Meta
			{
				get
				{
					DictionaryMeta dictionaryMeta;
					if ((dictionaryMeta = PdfTextField.Keys._meta) == null)
					{
						dictionaryMeta = (PdfTextField.Keys._meta = KeysBase.CreateMeta(typeof(PdfTextField.Keys)));
					}
					return dictionaryMeta;
				}
			}

			// Token: 0x04000498 RID: 1176
			[KeyInfo(KeyType.Integer | KeyType.Optional)]
			public const string MaxLen = "/MaxLen";

			// Token: 0x04000499 RID: 1177
			private static DictionaryMeta _meta;
		}
	}
}
