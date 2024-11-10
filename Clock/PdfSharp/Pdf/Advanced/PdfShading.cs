using System;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Pdf;
using PdfSharp.Pdf.Internal;

namespace PdfSharp.Pdf.Advanced
{
	// Token: 0x0200011F RID: 287
	public sealed class PdfShading : PdfDictionary
	{
		// Token: 0x06000A5A RID: 2650 RVA: 0x000292CF File Offset: 0x000274CF
		public PdfShading(PdfDocument document)
			: base(document)
		{
		}

		// Token: 0x06000A5B RID: 2651 RVA: 0x000292D8 File Offset: 0x000274D8
		internal void SetupFromBrush(XLinearGradientBrush brush, XGraphicsPdfRenderer renderer)
		{
			if (brush == null)
			{
				throw new ArgumentNullException("brush");
			}
			PdfColorMode colorMode = this._document.Options.ColorMode;
			XColor xcolor = ColorSpaceHelper.EnsureColorMode(colorMode, brush._color1);
			XColor xcolor2 = ColorSpaceHelper.EnsureColorMode(colorMode, brush._color2);
			PdfDictionary pdfDictionary = new PdfDictionary();
			base.Elements["/ShadingType"] = new PdfInteger(2);
			if (colorMode != PdfColorMode.Cmyk)
			{
				base.Elements["/ColorSpace"] = new PdfName("/DeviceRGB");
			}
			else
			{
				base.Elements["/ColorSpace"] = new PdfName("/DeviceCMYK");
			}
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 0.0;
			double num4 = 0.0;
			if (brush._useRect)
			{
				XPoint xpoint = renderer.WorldToView(brush._rect.TopLeft);
				XPoint xpoint2 = renderer.WorldToView(brush._rect.BottomRight);
				switch (brush._linearGradientMode)
				{
				case XLinearGradientMode.Horizontal:
					num = xpoint.X;
					num2 = xpoint.Y;
					num3 = xpoint2.X;
					num4 = xpoint.Y;
					break;
				case XLinearGradientMode.Vertical:
					num = xpoint.X;
					num2 = xpoint.Y;
					num3 = xpoint.X;
					num4 = xpoint2.Y;
					break;
				case XLinearGradientMode.ForwardDiagonal:
					num = xpoint.X;
					num2 = xpoint.Y;
					num3 = xpoint2.X;
					num4 = xpoint2.Y;
					break;
				case XLinearGradientMode.BackwardDiagonal:
					num = xpoint2.X;
					num2 = xpoint.Y;
					num3 = xpoint.X;
					num4 = xpoint2.Y;
					break;
				}
			}
			else
			{
				XPoint xpoint3 = renderer.WorldToView(brush._point1);
				XPoint xpoint4 = renderer.WorldToView(brush._point2);
				num = xpoint3.X;
				num2 = xpoint3.Y;
				num3 = xpoint4.X;
				num4 = xpoint4.Y;
			}
			base.Elements["/Coords"] = new PdfLiteral("[{0:0.###} {1:0.###} {2:0.###} {3:0.###}]", new object[] { num, num2, num3, num4 });
			base.Elements["/Function"] = pdfDictionary;
			string text = "[" + PdfEncoders.ToString(xcolor, colorMode) + "]";
			string text2 = "[" + PdfEncoders.ToString(xcolor2, colorMode) + "]";
			pdfDictionary.Elements["/FunctionType"] = new PdfInteger(2);
			pdfDictionary.Elements["/C0"] = new PdfLiteral(text);
			pdfDictionary.Elements["/C1"] = new PdfLiteral(text2);
			pdfDictionary.Elements["/Domain"] = new PdfLiteral("[0 1]");
			pdfDictionary.Elements["/N"] = new PdfInteger(1);
		}

		// Token: 0x170003D7 RID: 983
		// (get) Token: 0x06000A5C RID: 2652 RVA: 0x000295D8 File Offset: 0x000277D8
		internal override DictionaryMeta Meta
		{
			get
			{
				return PdfShading.Keys.Meta;
			}
		}

		// Token: 0x02000120 RID: 288
		internal sealed class Keys : KeysBase
		{
			// Token: 0x170003D8 RID: 984
			// (get) Token: 0x06000A5D RID: 2653 RVA: 0x000295DF File Offset: 0x000277DF
			internal static DictionaryMeta Meta
			{
				get
				{
					DictionaryMeta dictionaryMeta;
					if ((dictionaryMeta = PdfShading.Keys._meta) == null)
					{
						dictionaryMeta = (PdfShading.Keys._meta = KeysBase.CreateMeta(typeof(PdfShading.Keys)));
					}
					return dictionaryMeta;
				}
			}

			// Token: 0x040005A9 RID: 1449
			[KeyInfo(KeyType.Integer | KeyType.Required)]
			public const string ShadingType = "/ShadingType";

			// Token: 0x040005AA RID: 1450
			[KeyInfo(KeyType.NameOrArray | KeyType.Required)]
			public const string ColorSpace = "/ColorSpace";

			// Token: 0x040005AB RID: 1451
			[KeyInfo(KeyType.Array | KeyType.Optional)]
			public const string Background = "/Background";

			// Token: 0x040005AC RID: 1452
			[KeyInfo(KeyType.Name | KeyType.String | KeyType.Integer | KeyType.Optional)]
			public const string BBox = "/BBox";

			// Token: 0x040005AD RID: 1453
			[KeyInfo(KeyType.Name | KeyType.String | KeyType.Optional)]
			public const string AntiAlias = "/AntiAlias";

			// Token: 0x040005AE RID: 1454
			[KeyInfo(KeyType.Array | KeyType.Required)]
			public const string Coords = "/Coords";

			// Token: 0x040005AF RID: 1455
			[KeyInfo(KeyType.Array | KeyType.Optional)]
			public const string Domain = "/Domain";

			// Token: 0x040005B0 RID: 1456
			[KeyInfo(KeyType.Integer | KeyType.Array | KeyType.Required)]
			public const string Function = "/Function";

			// Token: 0x040005B1 RID: 1457
			[KeyInfo(KeyType.Array | KeyType.Optional)]
			public const string Extend = "/Extend";

			// Token: 0x040005B2 RID: 1458
			private static DictionaryMeta _meta;
		}
	}
}
