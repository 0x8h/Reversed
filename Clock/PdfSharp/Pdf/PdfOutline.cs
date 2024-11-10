using System;
using System.Globalization;
using PdfSharp.Drawing;
using PdfSharp.Pdf.Advanced;
using PdfSharp.Pdf.Internal;
using PdfSharp.Pdf.IO;

namespace PdfSharp.Pdf
{
	// Token: 0x020001A9 RID: 425
	public sealed class PdfOutline : PdfDictionary
	{
		// Token: 0x06000DAA RID: 3498 RVA: 0x000358F8 File Offset: 0x00033AF8
		public PdfOutline()
		{
		}

		// Token: 0x06000DAB RID: 3499 RVA: 0x00035948 File Offset: 0x00033B48
		internal PdfOutline(PdfDocument document)
			: base(document)
		{
		}

		// Token: 0x06000DAC RID: 3500 RVA: 0x00035998 File Offset: 0x00033B98
		public PdfOutline(PdfDictionary dict)
			: base(dict)
		{
			this.Initialize();
		}

		// Token: 0x06000DAD RID: 3501 RVA: 0x000359F0 File Offset: 0x00033BF0
		public PdfOutline(string title, PdfPage destinationPage, bool opened, PdfOutlineStyle style, XColor textColor)
		{
			this.Title = title;
			this.DestinationPage = destinationPage;
			this.Opened = opened;
			this.Style = style;
			this.TextColor = textColor;
		}

		// Token: 0x06000DAE RID: 3502 RVA: 0x00035A64 File Offset: 0x00033C64
		public PdfOutline(string title, PdfPage destinationPage, bool opened, PdfOutlineStyle style)
		{
			this.Title = title;
			this.DestinationPage = destinationPage;
			this.Opened = opened;
			this.Style = style;
		}

		// Token: 0x06000DAF RID: 3503 RVA: 0x00035AD0 File Offset: 0x00033CD0
		public PdfOutline(string title, PdfPage destinationPage, bool opened)
		{
			this.Title = title;
			this.DestinationPage = destinationPage;
			this.Opened = opened;
		}

		// Token: 0x06000DB0 RID: 3504 RVA: 0x00035B34 File Offset: 0x00033D34
		public PdfOutline(string title, PdfPage destinationPage)
		{
			this.Title = title;
			this.DestinationPage = destinationPage;
		}

		// Token: 0x170004A2 RID: 1186
		// (get) Token: 0x06000DB1 RID: 3505 RVA: 0x00035B91 File Offset: 0x00033D91
		// (set) Token: 0x06000DB2 RID: 3506 RVA: 0x00035B99 File Offset: 0x00033D99
		internal int Count
		{
			get
			{
				return this._count;
			}
			set
			{
				this._count = value;
			}
		}

		// Token: 0x06000DB3 RID: 3507 RVA: 0x00035BA4 File Offset: 0x00033DA4
		internal int CountOpen()
		{
			int num = (this._opened ? 1 : 0);
			if (this._outlines != null)
			{
				num += this._outlines.CountOpen();
			}
			return num;
		}

		// Token: 0x170004A3 RID: 1187
		// (get) Token: 0x06000DB4 RID: 3508 RVA: 0x00035BD5 File Offset: 0x00033DD5
		// (set) Token: 0x06000DB5 RID: 3509 RVA: 0x00035BDD File Offset: 0x00033DDD
		public PdfOutline Parent
		{
			get
			{
				return this._parent;
			}
			internal set
			{
				this._parent = value;
			}
		}

		// Token: 0x170004A4 RID: 1188
		// (get) Token: 0x06000DB6 RID: 3510 RVA: 0x00035BE6 File Offset: 0x00033DE6
		// (set) Token: 0x06000DB7 RID: 3511 RVA: 0x00035BF8 File Offset: 0x00033DF8
		public string Title
		{
			get
			{
				return base.Elements.GetString("/Title");
			}
			set
			{
				PdfString pdfString = new PdfString(value, PdfStringEncoding.Unicode);
				base.Elements.SetValue("/Title", pdfString);
			}
		}

		// Token: 0x170004A5 RID: 1189
		// (get) Token: 0x06000DB8 RID: 3512 RVA: 0x00035C1E File Offset: 0x00033E1E
		// (set) Token: 0x06000DB9 RID: 3513 RVA: 0x00035C26 File Offset: 0x00033E26
		public PdfPage DestinationPage
		{
			get
			{
				return this._destinationPage;
			}
			set
			{
				this._destinationPage = value;
			}
		}

		// Token: 0x170004A6 RID: 1190
		// (get) Token: 0x06000DBA RID: 3514 RVA: 0x00035C2F File Offset: 0x00033E2F
		// (set) Token: 0x06000DBB RID: 3515 RVA: 0x00035C37 File Offset: 0x00033E37
		public double Left
		{
			get
			{
				return this._left;
			}
			set
			{
				this._left = value;
			}
		}

		// Token: 0x170004A7 RID: 1191
		// (get) Token: 0x06000DBC RID: 3516 RVA: 0x00035C40 File Offset: 0x00033E40
		// (set) Token: 0x06000DBD RID: 3517 RVA: 0x00035C48 File Offset: 0x00033E48
		public double Top
		{
			get
			{
				return this._top;
			}
			set
			{
				this._top = value;
			}
		}

		// Token: 0x170004A8 RID: 1192
		// (get) Token: 0x06000DBE RID: 3518 RVA: 0x00035C51 File Offset: 0x00033E51
		// (set) Token: 0x06000DBF RID: 3519 RVA: 0x00035C59 File Offset: 0x00033E59
		public double Right
		{
			get
			{
				return this._right;
			}
			set
			{
				this._right = value;
			}
		}

		// Token: 0x170004A9 RID: 1193
		// (get) Token: 0x06000DC0 RID: 3520 RVA: 0x00035C62 File Offset: 0x00033E62
		// (set) Token: 0x06000DC1 RID: 3521 RVA: 0x00035C6A File Offset: 0x00033E6A
		public double Bottom
		{
			get
			{
				return this._bottom;
			}
			set
			{
				this._bottom = value;
			}
		}

		// Token: 0x170004AA RID: 1194
		// (get) Token: 0x06000DC2 RID: 3522 RVA: 0x00035C73 File Offset: 0x00033E73
		// (set) Token: 0x06000DC3 RID: 3523 RVA: 0x00035C7B File Offset: 0x00033E7B
		public double Zoom
		{
			get
			{
				return this._zoom;
			}
			set
			{
				this._zoom = value;
			}
		}

		// Token: 0x170004AB RID: 1195
		// (get) Token: 0x06000DC4 RID: 3524 RVA: 0x00035C84 File Offset: 0x00033E84
		// (set) Token: 0x06000DC5 RID: 3525 RVA: 0x00035C8C File Offset: 0x00033E8C
		public bool Opened
		{
			get
			{
				return this._opened;
			}
			set
			{
				this._opened = value;
			}
		}

		// Token: 0x170004AC RID: 1196
		// (get) Token: 0x06000DC6 RID: 3526 RVA: 0x00035C95 File Offset: 0x00033E95
		// (set) Token: 0x06000DC7 RID: 3527 RVA: 0x00035CA7 File Offset: 0x00033EA7
		public PdfOutlineStyle Style
		{
			get
			{
				return (PdfOutlineStyle)base.Elements.GetInteger("/F");
			}
			set
			{
				base.Elements.SetInteger("/F", (int)value);
			}
		}

		// Token: 0x170004AD RID: 1197
		// (get) Token: 0x06000DC8 RID: 3528 RVA: 0x00035CBA File Offset: 0x00033EBA
		// (set) Token: 0x06000DC9 RID: 3529 RVA: 0x00035CC2 File Offset: 0x00033EC2
		public PdfPageDestinationType PageDestinationType
		{
			get
			{
				return this._pageDestinationType;
			}
			set
			{
				this._pageDestinationType = value;
			}
		}

		// Token: 0x170004AE RID: 1198
		// (get) Token: 0x06000DCA RID: 3530 RVA: 0x00035CCB File Offset: 0x00033ECB
		// (set) Token: 0x06000DCB RID: 3531 RVA: 0x00035CD3 File Offset: 0x00033ED3
		public XColor TextColor
		{
			get
			{
				return this._textColor;
			}
			set
			{
				this._textColor = value;
			}
		}

		// Token: 0x170004AF RID: 1199
		// (get) Token: 0x06000DCC RID: 3532 RVA: 0x00035CDC File Offset: 0x00033EDC
		public bool HasChildren
		{
			get
			{
				return this._outlines != null && this._outlines.Count > 0;
			}
		}

		// Token: 0x170004B0 RID: 1200
		// (get) Token: 0x06000DCD RID: 3533 RVA: 0x00035CF8 File Offset: 0x00033EF8
		public PdfOutlineCollection Outlines
		{
			get
			{
				PdfOutlineCollection pdfOutlineCollection;
				if ((pdfOutlineCollection = this._outlines) == null)
				{
					pdfOutlineCollection = (this._outlines = new PdfOutlineCollection(this.Owner, this));
				}
				return pdfOutlineCollection;
			}
		}

		// Token: 0x06000DCE RID: 3534 RVA: 0x00035D24 File Offset: 0x00033F24
		private void Initialize()
		{
			string text;
			if (base.Elements.TryGetString("/Title", out text))
			{
				this.Title = text;
			}
			PdfReference reference = base.Elements.GetReference("/Parent");
			if (reference != null)
			{
				PdfOutline pdfOutline = reference.Value as PdfOutline;
				if (pdfOutline != null)
				{
					this.Parent = pdfOutline;
				}
			}
			this.Count = base.Elements.GetInteger("/Count");
			PdfArray array = base.Elements.GetArray("/C");
			if (array != null && array.Elements.Count == 3)
			{
				double real = array.Elements.GetReal(0);
				double real2 = array.Elements.GetReal(1);
				double real3 = array.Elements.GetReal(2);
				this.TextColor = XColor.FromArgb((int)(real * 255.0), (int)(real2 * 255.0), (int)(real3 * 255.0));
			}
			PdfItem pdfItem = base.Elements.GetValue("/Dest");
			PdfItem value = base.Elements.GetValue("/A");
			if (pdfItem != null)
			{
				PdfArray pdfArray = pdfItem as PdfArray;
				if (pdfArray != null)
				{
					this.SplitDestinationPage(pdfArray);
				}
			}
			else if (value != null)
			{
				PdfDictionary pdfDictionary = value as PdfDictionary;
				if (pdfDictionary != null && pdfDictionary.Elements.GetName("/S") == "/GoTo")
				{
					pdfItem = pdfDictionary.Elements["/D"];
					PdfArray pdfArray = pdfItem as PdfArray;
					if (pdfArray == null)
					{
						throw new Exception("Destination Array expected.");
					}
					base.Elements.Remove("/A");
					base.Elements.Add("/Dest", pdfArray);
					this.SplitDestinationPage(pdfArray);
				}
			}
			this.InitializeChildren();
		}

		// Token: 0x06000DCF RID: 3535 RVA: 0x00035EE4 File Offset: 0x000340E4
		private void SplitDestinationPage(PdfArray destination)
		{
			PdfDictionary pdfDictionary = (PdfDictionary)((PdfReference)destination.Elements[0]).Value;
			PdfPage pdfPage = pdfDictionary as PdfPage;
			if (pdfPage == null)
			{
				pdfPage = new PdfPage(pdfDictionary);
			}
			this.DestinationPage = pdfPage;
			PdfName pdfName = destination.Elements[1] as PdfName;
			if (pdfName != null)
			{
				this.PageDestinationType = (PdfPageDestinationType)Enum.Parse(typeof(PdfPageDestinationType), pdfName.Value.Substring(1), true);
				switch (this.PageDestinationType)
				{
				case PdfPageDestinationType.Xyz:
					this.Left = destination.Elements.GetReal(2);
					this.Top = destination.Elements.GetReal(3);
					this.Zoom = destination.Elements.GetReal(4);
					return;
				case PdfPageDestinationType.Fit:
				case PdfPageDestinationType.FitB:
					break;
				case PdfPageDestinationType.FitH:
					this.Top = destination.Elements.GetReal(2);
					return;
				case PdfPageDestinationType.FitV:
					this.Left = destination.Elements.GetReal(2);
					return;
				case PdfPageDestinationType.FitR:
					this.Left = destination.Elements.GetReal(2);
					this.Bottom = destination.Elements.GetReal(3);
					this.Right = destination.Elements.GetReal(4);
					this.Top = destination.Elements.GetReal(5);
					return;
				case PdfPageDestinationType.FitBH:
					this.Top = destination.Elements.GetReal(2);
					return;
				case PdfPageDestinationType.FitBV:
					this.Left = destination.Elements.GetReal(2);
					return;
				default:
					throw new ArgumentOutOfRangeException();
				}
			}
		}

		// Token: 0x06000DD0 RID: 3536 RVA: 0x00036070 File Offset: 0x00034270
		private void InitializeChildren()
		{
			PdfReference reference = base.Elements.GetReference("/First");
			base.Elements.GetReference("/Last");
			PdfOutline pdfOutline;
			for (PdfReference pdfReference = reference; pdfReference != null; pdfReference = pdfOutline.Elements.GetReference("/Next"))
			{
				pdfOutline = new PdfOutline((PdfDictionary)pdfReference.Value);
				this.Outlines.Add(pdfOutline);
			}
		}

		// Token: 0x06000DD1 RID: 3537 RVA: 0x000360D4 File Offset: 0x000342D4
		internal override void PrepareForSave()
		{
			bool hasChildren = this.HasChildren;
			if (this._parent != null || hasChildren)
			{
				if (this._parent == null)
				{
					base.Elements["/First"] = this._outlines[0].Reference;
					base.Elements["/Last"] = this._outlines[this._outlines.Count - 1].Reference;
					if (this.OpenCount > 0)
					{
						base.Elements["/Count"] = new PdfInteger(this.OpenCount);
					}
				}
				else
				{
					base.Elements["/Parent"] = this._parent.Reference;
					int count = this._parent._outlines.Count;
					int num = this._parent._outlines.IndexOf(this);
					if (this.DestinationPage != null)
					{
						base.Elements["/Dest"] = this.CreateDestArray();
					}
					if (num > 0)
					{
						base.Elements["/Prev"] = this._parent._outlines[num - 1].Reference;
					}
					if (num < count - 1)
					{
						base.Elements["/Next"] = this._parent._outlines[num + 1].Reference;
					}
					if (hasChildren)
					{
						base.Elements["/First"] = this._outlines[0].Reference;
						base.Elements["/Last"] = this._outlines[this._outlines.Count - 1].Reference;
					}
					if (this.OpenCount > 0)
					{
						base.Elements["/Count"] = new PdfInteger((this._opened ? 1 : (-1)) * this.OpenCount);
					}
					if (this._textColor != XColor.Empty && this.Owner.HasVersion("1.4"))
					{
						base.Elements["/C"] = new PdfLiteral("[{0}]", new object[] { PdfEncoders.ToString(this._textColor, PdfColorMode.Rgb) });
					}
				}
				if (hasChildren)
				{
					foreach (PdfOutline pdfOutline in this._outlines)
					{
						pdfOutline.PrepareForSave();
					}
				}
			}
		}

		// Token: 0x06000DD2 RID: 3538 RVA: 0x00036350 File Offset: 0x00034550
		private PdfArray CreateDestArray()
		{
			PdfArray pdfArray;
			switch (this.PageDestinationType)
			{
			case PdfPageDestinationType.Xyz:
				pdfArray = new PdfArray(this.Owner, new PdfItem[]
				{
					this.DestinationPage.Reference,
					new PdfLiteral(string.Format("/XYZ {0} {1} {2}", this.Fd(this.Left), this.Fd(this.Top), this.Fd(this.Zoom)))
				});
				break;
			case PdfPageDestinationType.Fit:
				pdfArray = new PdfArray(this.Owner, new PdfItem[]
				{
					this.DestinationPage.Reference,
					new PdfLiteral("/Fit")
				});
				break;
			case PdfPageDestinationType.FitH:
				pdfArray = new PdfArray(this.Owner, new PdfItem[]
				{
					this.DestinationPage.Reference,
					new PdfLiteral(string.Format("/FitH {0}", this.Fd(this.Top)))
				});
				break;
			case PdfPageDestinationType.FitV:
				pdfArray = new PdfArray(this.Owner, new PdfItem[]
				{
					this.DestinationPage.Reference,
					new PdfLiteral(string.Format("/FitV {0}", this.Fd(this.Left)))
				});
				break;
			case PdfPageDestinationType.FitR:
				pdfArray = new PdfArray(this.Owner, new PdfItem[]
				{
					this.DestinationPage.Reference,
					new PdfLiteral(string.Format("/FitR {0} {1} {2} {3}", new object[]
					{
						this.Fd(this.Left),
						this.Fd(this.Bottom),
						this.Fd(this.Right),
						this.Fd(this.Top)
					}))
				});
				break;
			case PdfPageDestinationType.FitB:
				pdfArray = new PdfArray(this.Owner, new PdfItem[]
				{
					this.DestinationPage.Reference,
					new PdfLiteral("/FitB")
				});
				break;
			case PdfPageDestinationType.FitBH:
				pdfArray = new PdfArray(this.Owner, new PdfItem[]
				{
					this.DestinationPage.Reference,
					new PdfLiteral(string.Format("/FitBH {0}", this.Fd(this.Top)))
				});
				break;
			case PdfPageDestinationType.FitBV:
				pdfArray = new PdfArray(this.Owner, new PdfItem[]
				{
					this.DestinationPage.Reference,
					new PdfLiteral(string.Format("/FitBV {0}", this.Fd(this.Left)))
				});
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
			return pdfArray;
		}

		// Token: 0x06000DD3 RID: 3539 RVA: 0x00036606 File Offset: 0x00034806
		private string Fd(double value)
		{
			if (!double.IsNaN(value))
			{
				return value.ToString("#.##", CultureInfo.InvariantCulture);
			}
			return "null";
		}

		// Token: 0x06000DD4 RID: 3540 RVA: 0x00036628 File Offset: 0x00034828
		internal override void WriteObject(PdfWriter writer)
		{
			bool hasChildren = this.HasChildren;
			if (this._parent != null || hasChildren)
			{
				base.WriteObject(writer);
			}
		}

		// Token: 0x170004B1 RID: 1201
		// (get) Token: 0x06000DD5 RID: 3541 RVA: 0x0003664E File Offset: 0x0003484E
		internal override DictionaryMeta Meta
		{
			get
			{
				return PdfOutline.Keys.Meta;
			}
		}

		// Token: 0x04000881 RID: 2177
		private int _count;

		// Token: 0x04000882 RID: 2178
		internal int OpenCount;

		// Token: 0x04000883 RID: 2179
		private PdfOutline _parent;

		// Token: 0x04000884 RID: 2180
		private PdfPage _destinationPage;

		// Token: 0x04000885 RID: 2181
		private double _left = double.NaN;

		// Token: 0x04000886 RID: 2182
		private double _top = double.NaN;

		// Token: 0x04000887 RID: 2183
		private double _right = double.NaN;

		// Token: 0x04000888 RID: 2184
		private double _bottom = double.NaN;

		// Token: 0x04000889 RID: 2185
		private double _zoom;

		// Token: 0x0400088A RID: 2186
		private bool _opened;

		// Token: 0x0400088B RID: 2187
		private PdfPageDestinationType _pageDestinationType;

		// Token: 0x0400088C RID: 2188
		private XColor _textColor;

		// Token: 0x0400088D RID: 2189
		private PdfOutlineCollection _outlines;

		// Token: 0x020001AA RID: 426
		internal sealed class Keys : KeysBase
		{
			// Token: 0x170004B2 RID: 1202
			// (get) Token: 0x06000DD6 RID: 3542 RVA: 0x00036655 File Offset: 0x00034855
			public static DictionaryMeta Meta
			{
				get
				{
					DictionaryMeta dictionaryMeta;
					if ((dictionaryMeta = PdfOutline.Keys._meta) == null)
					{
						dictionaryMeta = (PdfOutline.Keys._meta = KeysBase.CreateMeta(typeof(PdfOutline.Keys)));
					}
					return dictionaryMeta;
				}
			}

			// Token: 0x0400088E RID: 2190
			[KeyInfo(KeyType.Name | KeyType.Optional, FixedValue = "Outlines")]
			public const string Type = "/Type";

			// Token: 0x0400088F RID: 2191
			[KeyInfo(KeyType.String | KeyType.Required)]
			public const string Title = "/Title";

			// Token: 0x04000890 RID: 2192
			[KeyInfo(KeyType.Name | KeyType.Array | KeyType.Required)]
			public const string Parent = "/Parent";

			// Token: 0x04000891 RID: 2193
			[KeyInfo(KeyType.Name | KeyType.Array | KeyType.Required)]
			public const string Prev = "/Prev";

			// Token: 0x04000892 RID: 2194
			[KeyInfo(KeyType.Name | KeyType.Array | KeyType.Required)]
			public const string Next = "/Next";

			// Token: 0x04000893 RID: 2195
			[KeyInfo(KeyType.Name | KeyType.Array | KeyType.Required)]
			public const string First = "/First";

			// Token: 0x04000894 RID: 2196
			[KeyInfo(KeyType.Name | KeyType.Array | KeyType.Required)]
			public const string Last = "/Last";

			// Token: 0x04000895 RID: 2197
			[KeyInfo(KeyType.Integer | KeyType.Required)]
			public const string Count = "/Count";

			// Token: 0x04000896 RID: 2198
			[KeyInfo(KeyType.NameOrDictionary | KeyType.StreamOrArray | KeyType.Optional)]
			public const string Dest = "/Dest";

			// Token: 0x04000897 RID: 2199
			[KeyInfo(KeyType.Name | KeyType.Array | KeyType.Optional)]
			public const string A = "/A";

			// Token: 0x04000898 RID: 2200
			[KeyInfo(KeyType.Name | KeyType.Array | KeyType.Optional)]
			public const string SE = "/SE";

			// Token: 0x04000899 RID: 2201
			[KeyInfo(KeyType.Array | KeyType.Optional)]
			public const string C = "/C";

			// Token: 0x0400089A RID: 2202
			[KeyInfo(KeyType.Integer | KeyType.Optional)]
			public const string F = "/F";

			// Token: 0x0400089B RID: 2203
			private static DictionaryMeta _meta;
		}
	}
}
