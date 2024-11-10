using System;
using PdfSharp.Drawing;

namespace PdfSharp.Pdf.Annotations
{
	// Token: 0x02000132 RID: 306
	public abstract class PdfAnnotation : PdfDictionary
	{
		// Token: 0x06000A8F RID: 2703 RVA: 0x0002A176 File Offset: 0x00028376
		protected PdfAnnotation()
		{
			this.Initialize();
		}

		// Token: 0x06000A90 RID: 2704 RVA: 0x0002A184 File Offset: 0x00028384
		protected PdfAnnotation(PdfDocument document)
			: base(document)
		{
			this.Initialize();
		}

		// Token: 0x06000A91 RID: 2705 RVA: 0x0002A193 File Offset: 0x00028393
		internal PdfAnnotation(PdfDictionary dict)
			: base(dict)
		{
		}

		// Token: 0x06000A92 RID: 2706 RVA: 0x0002A19C File Offset: 0x0002839C
		private void Initialize()
		{
			base.Elements.SetName("/Type", "/Annot");
			base.Elements.SetString("/NM", Guid.NewGuid().ToString("D"));
			base.Elements.SetDateTime("/M", DateTime.Now);
		}

		// Token: 0x06000A93 RID: 2707 RVA: 0x0002A1F5 File Offset: 0x000283F5
		[Obsolete("Use 'Parent.Remove(this)'")]
		public void Delete()
		{
			this.Parent.Remove(this);
		}

		// Token: 0x170003ED RID: 1005
		// (get) Token: 0x06000A94 RID: 2708 RVA: 0x0002A203 File Offset: 0x00028403
		// (set) Token: 0x06000A95 RID: 2709 RVA: 0x0002A215 File Offset: 0x00028415
		public PdfAnnotationFlags Flags
		{
			get
			{
				return (PdfAnnotationFlags)base.Elements.GetInteger("/F");
			}
			set
			{
				base.Elements.SetInteger("/F", (int)value);
				base.Elements.SetDateTime("/M", DateTime.Now);
			}
		}

		// Token: 0x170003EE RID: 1006
		// (get) Token: 0x06000A96 RID: 2710 RVA: 0x0002A23D File Offset: 0x0002843D
		// (set) Token: 0x06000A97 RID: 2711 RVA: 0x0002A245 File Offset: 0x00028445
		public PdfAnnotations Parent
		{
			get
			{
				return this._parent;
			}
			set
			{
				this._parent = value;
			}
		}

		// Token: 0x170003EF RID: 1007
		// (get) Token: 0x06000A98 RID: 2712 RVA: 0x0002A24E File Offset: 0x0002844E
		// (set) Token: 0x06000A99 RID: 2713 RVA: 0x0002A261 File Offset: 0x00028461
		public PdfRectangle Rectangle
		{
			get
			{
				return base.Elements.GetRectangle("/Rect", true);
			}
			set
			{
				base.Elements.SetRectangle("/Rect", value);
				base.Elements.SetDateTime("/M", DateTime.Now);
			}
		}

		// Token: 0x170003F0 RID: 1008
		// (get) Token: 0x06000A9A RID: 2714 RVA: 0x0002A289 File Offset: 0x00028489
		// (set) Token: 0x06000A9B RID: 2715 RVA: 0x0002A29C File Offset: 0x0002849C
		public string Title
		{
			get
			{
				return base.Elements.GetString("/T", true);
			}
			set
			{
				base.Elements.SetString("/T", value);
				base.Elements.SetDateTime("/M", DateTime.Now);
			}
		}

		// Token: 0x170003F1 RID: 1009
		// (get) Token: 0x06000A9C RID: 2716 RVA: 0x0002A2C4 File Offset: 0x000284C4
		// (set) Token: 0x06000A9D RID: 2717 RVA: 0x0002A2D7 File Offset: 0x000284D7
		public string Subject
		{
			get
			{
				return base.Elements.GetString("/Subj", true);
			}
			set
			{
				base.Elements.SetString("/Subj", value);
				base.Elements.SetDateTime("/M", DateTime.Now);
			}
		}

		// Token: 0x170003F2 RID: 1010
		// (get) Token: 0x06000A9E RID: 2718 RVA: 0x0002A2FF File Offset: 0x000284FF
		// (set) Token: 0x06000A9F RID: 2719 RVA: 0x0002A312 File Offset: 0x00028512
		public string Contents
		{
			get
			{
				return base.Elements.GetString("/Contents", true);
			}
			set
			{
				base.Elements.SetString("/Contents", value);
				base.Elements.SetDateTime("/M", DateTime.Now);
			}
		}

		// Token: 0x170003F3 RID: 1011
		// (get) Token: 0x06000AA0 RID: 2720 RVA: 0x0002A33C File Offset: 0x0002853C
		// (set) Token: 0x06000AA1 RID: 2721 RVA: 0x0002A3C4 File Offset: 0x000285C4
		public XColor Color
		{
			get
			{
				PdfItem pdfItem = base.Elements["/C"];
				PdfArray pdfArray = pdfItem as PdfArray;
				if (pdfArray != null && pdfArray.Elements.Count == 3)
				{
					return XColor.FromArgb((int)(pdfArray.Elements.GetReal(0) * 255.0), (int)(pdfArray.Elements.GetReal(1) * 255.0), (int)(pdfArray.Elements.GetReal(2) * 255.0));
				}
				return XColors.Black;
			}
			set
			{
				PdfArray pdfArray = new PdfArray(this.Owner, new PdfReal[]
				{
					new PdfReal((double)value.R / 255.0),
					new PdfReal((double)value.G / 255.0),
					new PdfReal((double)value.B / 255.0)
				});
				base.Elements["/C"] = pdfArray;
				base.Elements.SetDateTime("/M", DateTime.Now);
			}
		}

		// Token: 0x170003F4 RID: 1012
		// (get) Token: 0x06000AA2 RID: 2722 RVA: 0x0002A459 File Offset: 0x00028659
		// (set) Token: 0x06000AA3 RID: 2723 RVA: 0x0002A488 File Offset: 0x00028688
		public double Opacity
		{
			get
			{
				if (!base.Elements.ContainsKey("/CA"))
				{
					return 1.0;
				}
				return base.Elements.GetReal("/CA", true);
			}
			set
			{
				if (value < 0.0 || value > 1.0)
				{
					throw new ArgumentOutOfRangeException("value", value, "Opacity must be a value in the range from 0 to 1.");
				}
				base.Elements.SetReal("/CA", value);
				base.Elements.SetDateTime("/M", DateTime.Now);
			}
		}

		// Token: 0x04000605 RID: 1541
		private PdfAnnotations _parent;

		// Token: 0x02000133 RID: 307
		public class Keys : KeysBase
		{
			// Token: 0x04000606 RID: 1542
			[KeyInfo(KeyType.Name | KeyType.Optional, FixedValue = "Annot")]
			public const string Type = "/Type";

			// Token: 0x04000607 RID: 1543
			[KeyInfo(KeyType.Name | KeyType.Required)]
			public const string Subtype = "/Subtype";

			// Token: 0x04000608 RID: 1544
			[KeyInfo(KeyType.Name | KeyType.String | KeyType.Integer | KeyType.Required)]
			public const string Rect = "/Rect";

			// Token: 0x04000609 RID: 1545
			[KeyInfo(KeyType.Name | KeyType.Integer | KeyType.Array | KeyType.Optional)]
			public const string Contents = "/Contents";

			// Token: 0x0400060A RID: 1546
			[KeyInfo(KeyType.Name | KeyType.Integer | KeyType.Array | KeyType.Optional)]
			public const string NM = "/NM";

			// Token: 0x0400060B RID: 1547
			[KeyInfo(KeyType.String | KeyType.Integer | KeyType.Optional)]
			public const string M = "/M";

			// Token: 0x0400060C RID: 1548
			[KeyInfo("1.1", KeyType.Integer | KeyType.Optional)]
			public const string F = "/F";

			// Token: 0x0400060D RID: 1549
			[KeyInfo("1.2", KeyType.Name | KeyType.Array | KeyType.Optional)]
			public const string BS = "/BS";

			// Token: 0x0400060E RID: 1550
			[KeyInfo("1.2", KeyType.Name | KeyType.Array | KeyType.Optional)]
			public const string AP = "/AP";

			// Token: 0x0400060F RID: 1551
			[KeyInfo("1.2", KeyType.Name | KeyType.Array | KeyType.Optional)]
			public const string AS = "/AS";

			// Token: 0x04000610 RID: 1552
			[KeyInfo(KeyType.Array | KeyType.Optional)]
			public const string Border = "/Border";

			// Token: 0x04000611 RID: 1553
			[KeyInfo("1.1", KeyType.Array | KeyType.Optional)]
			public const string C = "/C";

			// Token: 0x04000612 RID: 1554
			[KeyInfo("1.1", KeyType.Name | KeyType.Array | KeyType.Optional)]
			public const string A = "/A";

			// Token: 0x04000613 RID: 1555
			[KeyInfo(KeyType.Name | KeyType.Integer | KeyType.Array | KeyType.Optional)]
			public const string T = "/T";

			// Token: 0x04000614 RID: 1556
			[KeyInfo(KeyType.Name | KeyType.Array | KeyType.Optional)]
			public const string Popup = "/Popup";

			// Token: 0x04000615 RID: 1557
			[KeyInfo(KeyType.Name | KeyType.Integer | KeyType.Optional)]
			public const string CA = "/CA";

			// Token: 0x04000616 RID: 1558
			[KeyInfo("1.5", KeyType.Name | KeyType.Integer | KeyType.Array | KeyType.Optional)]
			public const string Subj = "/Subj";
		}
	}
}
