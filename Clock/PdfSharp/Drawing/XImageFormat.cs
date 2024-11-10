using System;

namespace PdfSharp.Drawing
{
	// Token: 0x0200006F RID: 111
	public sealed class XImageFormat
	{
		// Token: 0x06000475 RID: 1141 RVA: 0x00012E22 File Offset: 0x00011022
		private XImageFormat(Guid guid)
		{
			this._guid = guid;
		}

		// Token: 0x170001E5 RID: 485
		// (get) Token: 0x06000476 RID: 1142 RVA: 0x00012E31 File Offset: 0x00011031
		internal Guid Guid
		{
			get
			{
				return this._guid;
			}
		}

		// Token: 0x06000477 RID: 1143 RVA: 0x00012E3C File Offset: 0x0001103C
		public override bool Equals(object obj)
		{
			XImageFormat ximageFormat = obj as XImageFormat;
			return ximageFormat != null && this._guid == ximageFormat._guid;
		}

		// Token: 0x06000478 RID: 1144 RVA: 0x00012E68 File Offset: 0x00011068
		public override int GetHashCode()
		{
			return this._guid.GetHashCode();
		}

		// Token: 0x170001E6 RID: 486
		// (get) Token: 0x06000479 RID: 1145 RVA: 0x00012E89 File Offset: 0x00011089
		public static XImageFormat Png
		{
			get
			{
				return XImageFormat._png;
			}
		}

		// Token: 0x170001E7 RID: 487
		// (get) Token: 0x0600047A RID: 1146 RVA: 0x00012E90 File Offset: 0x00011090
		public static XImageFormat Gif
		{
			get
			{
				return XImageFormat._gif;
			}
		}

		// Token: 0x170001E8 RID: 488
		// (get) Token: 0x0600047B RID: 1147 RVA: 0x00012E97 File Offset: 0x00011097
		public static XImageFormat Jpeg
		{
			get
			{
				return XImageFormat._jpeg;
			}
		}

		// Token: 0x170001E9 RID: 489
		// (get) Token: 0x0600047C RID: 1148 RVA: 0x00012E9E File Offset: 0x0001109E
		public static XImageFormat Tiff
		{
			get
			{
				return XImageFormat._tiff;
			}
		}

		// Token: 0x170001EA RID: 490
		// (get) Token: 0x0600047D RID: 1149 RVA: 0x00012EA5 File Offset: 0x000110A5
		public static XImageFormat Pdf
		{
			get
			{
				return XImageFormat._pdf;
			}
		}

		// Token: 0x170001EB RID: 491
		// (get) Token: 0x0600047E RID: 1150 RVA: 0x00012EAC File Offset: 0x000110AC
		public static XImageFormat Icon
		{
			get
			{
				return XImageFormat._icon;
			}
		}

		// Token: 0x0400027D RID: 637
		private readonly Guid _guid;

		// Token: 0x0400027E RID: 638
		private static readonly XImageFormat _png = new XImageFormat(new Guid("{B96B3CAF-0728-11D3-9D7B-0000F81EF32E}"));

		// Token: 0x0400027F RID: 639
		private static readonly XImageFormat _gif = new XImageFormat(new Guid("{B96B3CB0-0728-11D3-9D7B-0000F81EF32E}"));

		// Token: 0x04000280 RID: 640
		private static readonly XImageFormat _jpeg = new XImageFormat(new Guid("{B96B3CAE-0728-11D3-9D7B-0000F81EF32E}"));

		// Token: 0x04000281 RID: 641
		private static readonly XImageFormat _tiff = new XImageFormat(new Guid("{B96B3CB1-0728-11D3-9D7B-0000F81EF32E}"));

		// Token: 0x04000282 RID: 642
		private static readonly XImageFormat _icon = new XImageFormat(new Guid("{B96B3CB5-0728-11D3-9D7B-0000F81EF32E}"));

		// Token: 0x04000283 RID: 643
		private static readonly XImageFormat _pdf = new XImageFormat(new Guid("{84570158-DBF0-4C6B-8368-62D6A3CA76E0}"));
	}
}
