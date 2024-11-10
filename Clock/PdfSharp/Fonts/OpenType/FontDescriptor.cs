using System;
using PdfSharp.Drawing;

namespace PdfSharp.Fonts.OpenType
{
	// Token: 0x02000083 RID: 131
	internal class FontDescriptor
	{
		// Token: 0x0600069E RID: 1694 RVA: 0x00019038 File Offset: 0x00017238
		protected FontDescriptor(string key)
		{
			this._key = key;
		}

		// Token: 0x170002DB RID: 731
		// (get) Token: 0x0600069F RID: 1695 RVA: 0x00019047 File Offset: 0x00017247
		public string Key
		{
			get
			{
				return this._key;
			}
		}

		// Token: 0x170002DC RID: 732
		// (get) Token: 0x060006A0 RID: 1696 RVA: 0x0001904F File Offset: 0x0001724F
		// (set) Token: 0x060006A1 RID: 1697 RVA: 0x00019057 File Offset: 0x00017257
		public string FontName
		{
			get
			{
				return this._fontName;
			}
			protected set
			{
				this._fontName = value;
			}
		}

		// Token: 0x170002DD RID: 733
		// (get) Token: 0x060006A2 RID: 1698 RVA: 0x00019060 File Offset: 0x00017260
		// (set) Token: 0x060006A3 RID: 1699 RVA: 0x00019068 File Offset: 0x00017268
		public string Weight
		{
			get
			{
				return this._weight;
			}
			private set
			{
				this._weight = value;
			}
		}

		// Token: 0x170002DE RID: 734
		// (get) Token: 0x060006A4 RID: 1700 RVA: 0x00019071 File Offset: 0x00017271
		public virtual bool IsBoldFace
		{
			get
			{
				return false;
			}
		}

		// Token: 0x170002DF RID: 735
		// (get) Token: 0x060006A5 RID: 1701 RVA: 0x00019074 File Offset: 0x00017274
		// (set) Token: 0x060006A6 RID: 1702 RVA: 0x0001907C File Offset: 0x0001727C
		public float ItalicAngle
		{
			get
			{
				return this._italicAngle;
			}
			protected set
			{
				this._italicAngle = value;
			}
		}

		// Token: 0x170002E0 RID: 736
		// (get) Token: 0x060006A7 RID: 1703 RVA: 0x00019085 File Offset: 0x00017285
		public virtual bool IsItalicFace
		{
			get
			{
				return false;
			}
		}

		// Token: 0x170002E1 RID: 737
		// (get) Token: 0x060006A8 RID: 1704 RVA: 0x00019088 File Offset: 0x00017288
		// (set) Token: 0x060006A9 RID: 1705 RVA: 0x00019090 File Offset: 0x00017290
		public int XMin
		{
			get
			{
				return this._xMin;
			}
			protected set
			{
				this._xMin = value;
			}
		}

		// Token: 0x170002E2 RID: 738
		// (get) Token: 0x060006AA RID: 1706 RVA: 0x00019099 File Offset: 0x00017299
		// (set) Token: 0x060006AB RID: 1707 RVA: 0x000190A1 File Offset: 0x000172A1
		public int YMin
		{
			get
			{
				return this._yMin;
			}
			protected set
			{
				this._yMin = value;
			}
		}

		// Token: 0x170002E3 RID: 739
		// (get) Token: 0x060006AC RID: 1708 RVA: 0x000190AA File Offset: 0x000172AA
		// (set) Token: 0x060006AD RID: 1709 RVA: 0x000190B2 File Offset: 0x000172B2
		public int XMax
		{
			get
			{
				return this._xMax;
			}
			protected set
			{
				this._xMax = value;
			}
		}

		// Token: 0x170002E4 RID: 740
		// (get) Token: 0x060006AE RID: 1710 RVA: 0x000190BB File Offset: 0x000172BB
		// (set) Token: 0x060006AF RID: 1711 RVA: 0x000190C3 File Offset: 0x000172C3
		public int YMax
		{
			get
			{
				return this._yMax;
			}
			protected set
			{
				this._yMax = value;
			}
		}

		// Token: 0x170002E5 RID: 741
		// (get) Token: 0x060006B0 RID: 1712 RVA: 0x000190CC File Offset: 0x000172CC
		// (set) Token: 0x060006B1 RID: 1713 RVA: 0x000190D4 File Offset: 0x000172D4
		public bool IsFixedPitch
		{
			get
			{
				return this._isFixedPitch;
			}
			private set
			{
				this._isFixedPitch = value;
			}
		}

		// Token: 0x170002E6 RID: 742
		// (get) Token: 0x060006B2 RID: 1714 RVA: 0x000190DD File Offset: 0x000172DD
		// (set) Token: 0x060006B3 RID: 1715 RVA: 0x000190E5 File Offset: 0x000172E5
		public int UnderlinePosition
		{
			get
			{
				return this._underlinePosition;
			}
			protected set
			{
				this._underlinePosition = value;
			}
		}

		// Token: 0x170002E7 RID: 743
		// (get) Token: 0x060006B4 RID: 1716 RVA: 0x000190EE File Offset: 0x000172EE
		// (set) Token: 0x060006B5 RID: 1717 RVA: 0x000190F6 File Offset: 0x000172F6
		public int UnderlineThickness
		{
			get
			{
				return this._underlineThickness;
			}
			protected set
			{
				this._underlineThickness = value;
			}
		}

		// Token: 0x170002E8 RID: 744
		// (get) Token: 0x060006B6 RID: 1718 RVA: 0x000190FF File Offset: 0x000172FF
		// (set) Token: 0x060006B7 RID: 1719 RVA: 0x00019107 File Offset: 0x00017307
		public int StrikeoutPosition
		{
			get
			{
				return this._strikeoutPosition;
			}
			protected set
			{
				this._strikeoutPosition = value;
			}
		}

		// Token: 0x170002E9 RID: 745
		// (get) Token: 0x060006B8 RID: 1720 RVA: 0x00019110 File Offset: 0x00017310
		// (set) Token: 0x060006B9 RID: 1721 RVA: 0x00019118 File Offset: 0x00017318
		public int StrikeoutSize
		{
			get
			{
				return this._strikeoutSize;
			}
			protected set
			{
				this._strikeoutSize = value;
			}
		}

		// Token: 0x170002EA RID: 746
		// (get) Token: 0x060006BA RID: 1722 RVA: 0x00019121 File Offset: 0x00017321
		// (set) Token: 0x060006BB RID: 1723 RVA: 0x00019129 File Offset: 0x00017329
		public string Version
		{
			get
			{
				return this._version;
			}
			private set
			{
				this._version = value;
			}
		}

		// Token: 0x170002EB RID: 747
		// (get) Token: 0x060006BC RID: 1724 RVA: 0x00019132 File Offset: 0x00017332
		// (set) Token: 0x060006BD RID: 1725 RVA: 0x0001913A File Offset: 0x0001733A
		public string EncodingScheme
		{
			get
			{
				return this._encodingScheme;
			}
			private set
			{
				this._encodingScheme = value;
			}
		}

		// Token: 0x170002EC RID: 748
		// (get) Token: 0x060006BE RID: 1726 RVA: 0x00019143 File Offset: 0x00017343
		// (set) Token: 0x060006BF RID: 1727 RVA: 0x0001914B File Offset: 0x0001734B
		public int UnitsPerEm
		{
			get
			{
				return this._unitsPerEm;
			}
			protected set
			{
				this._unitsPerEm = value;
			}
		}

		// Token: 0x170002ED RID: 749
		// (get) Token: 0x060006C0 RID: 1728 RVA: 0x00019154 File Offset: 0x00017354
		// (set) Token: 0x060006C1 RID: 1729 RVA: 0x0001915C File Offset: 0x0001735C
		public int CapHeight
		{
			get
			{
				return this._capHeight;
			}
			protected set
			{
				this._capHeight = value;
			}
		}

		// Token: 0x170002EE RID: 750
		// (get) Token: 0x060006C2 RID: 1730 RVA: 0x00019165 File Offset: 0x00017365
		// (set) Token: 0x060006C3 RID: 1731 RVA: 0x0001916D File Offset: 0x0001736D
		public int XHeight
		{
			get
			{
				return this._xHeight;
			}
			protected set
			{
				this._xHeight = value;
			}
		}

		// Token: 0x170002EF RID: 751
		// (get) Token: 0x060006C4 RID: 1732 RVA: 0x00019176 File Offset: 0x00017376
		// (set) Token: 0x060006C5 RID: 1733 RVA: 0x0001917E File Offset: 0x0001737E
		public int Ascender
		{
			get
			{
				return this._ascender;
			}
			protected set
			{
				this._ascender = value;
			}
		}

		// Token: 0x170002F0 RID: 752
		// (get) Token: 0x060006C6 RID: 1734 RVA: 0x00019187 File Offset: 0x00017387
		// (set) Token: 0x060006C7 RID: 1735 RVA: 0x0001918F File Offset: 0x0001738F
		public int Descender
		{
			get
			{
				return this._descender;
			}
			protected set
			{
				this._descender = value;
			}
		}

		// Token: 0x170002F1 RID: 753
		// (get) Token: 0x060006C8 RID: 1736 RVA: 0x00019198 File Offset: 0x00017398
		// (set) Token: 0x060006C9 RID: 1737 RVA: 0x000191A0 File Offset: 0x000173A0
		public int Leading
		{
			get
			{
				return this._leading;
			}
			protected set
			{
				this._leading = value;
			}
		}

		// Token: 0x170002F2 RID: 754
		// (get) Token: 0x060006CA RID: 1738 RVA: 0x000191A9 File Offset: 0x000173A9
		// (set) Token: 0x060006CB RID: 1739 RVA: 0x000191B1 File Offset: 0x000173B1
		public int Flags
		{
			get
			{
				return this._flags;
			}
			private set
			{
				this._flags = value;
			}
		}

		// Token: 0x170002F3 RID: 755
		// (get) Token: 0x060006CC RID: 1740 RVA: 0x000191BA File Offset: 0x000173BA
		// (set) Token: 0x060006CD RID: 1741 RVA: 0x000191C2 File Offset: 0x000173C2
		public int StemV
		{
			get
			{
				return this._stemV;
			}
			protected set
			{
				this._stemV = value;
			}
		}

		// Token: 0x170002F4 RID: 756
		// (get) Token: 0x060006CE RID: 1742 RVA: 0x000191CB File Offset: 0x000173CB
		// (set) Token: 0x060006CF RID: 1743 RVA: 0x000191D3 File Offset: 0x000173D3
		public int LineSpacing
		{
			get
			{
				return this._lineSpacing;
			}
			protected set
			{
				this._lineSpacing = value;
			}
		}

		// Token: 0x060006D0 RID: 1744 RVA: 0x000191DC File Offset: 0x000173DC
		internal static string ComputeKey(XFont font)
		{
			return font.GlyphTypeface.Key;
		}

		// Token: 0x060006D1 RID: 1745 RVA: 0x000191E9 File Offset: 0x000173E9
		internal static string ComputeKey(string name, XFontStyle style)
		{
			return FontDescriptor.ComputeKey(name, (style & XFontStyle.Bold) == XFontStyle.Bold, (style & XFontStyle.Italic) == XFontStyle.Italic);
		}

		// Token: 0x060006D2 RID: 1746 RVA: 0x00019200 File Offset: 0x00017400
		internal static string ComputeKey(string name, bool isBold, bool isItalic)
		{
			return string.Concat(new object[]
			{
				name.ToLowerInvariant(),
				'/',
				isBold ? "b" : "",
				isItalic ? "i" : ""
			});
		}

		// Token: 0x060006D3 RID: 1747 RVA: 0x00019254 File Offset: 0x00017454
		internal static string ComputeKey(string name)
		{
			return name.ToLowerInvariant();
		}

		// Token: 0x040002EE RID: 750
		private readonly string _key;

		// Token: 0x040002EF RID: 751
		private string _fontName;

		// Token: 0x040002F0 RID: 752
		private string _weight;

		// Token: 0x040002F1 RID: 753
		private float _italicAngle;

		// Token: 0x040002F2 RID: 754
		private int _xMin;

		// Token: 0x040002F3 RID: 755
		private int _yMin;

		// Token: 0x040002F4 RID: 756
		private int _xMax;

		// Token: 0x040002F5 RID: 757
		private int _yMax;

		// Token: 0x040002F6 RID: 758
		private bool _isFixedPitch;

		// Token: 0x040002F7 RID: 759
		private int _underlinePosition;

		// Token: 0x040002F8 RID: 760
		private int _underlineThickness;

		// Token: 0x040002F9 RID: 761
		private int _strikeoutPosition;

		// Token: 0x040002FA RID: 762
		private int _strikeoutSize;

		// Token: 0x040002FB RID: 763
		private string _version;

		// Token: 0x040002FC RID: 764
		private string _encodingScheme;

		// Token: 0x040002FD RID: 765
		private int _unitsPerEm;

		// Token: 0x040002FE RID: 766
		private int _capHeight;

		// Token: 0x040002FF RID: 767
		private int _xHeight;

		// Token: 0x04000300 RID: 768
		private int _ascender;

		// Token: 0x04000301 RID: 769
		private int _descender;

		// Token: 0x04000302 RID: 770
		private int _leading;

		// Token: 0x04000303 RID: 771
		private int _flags;

		// Token: 0x04000304 RID: 772
		private int _stemV;

		// Token: 0x04000305 RID: 773
		private int _lineSpacing;
	}
}
