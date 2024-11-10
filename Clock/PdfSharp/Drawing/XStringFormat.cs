using System;

namespace PdfSharp.Drawing
{
	// Token: 0x0200007D RID: 125
	public class XStringFormat
	{
		// Token: 0x170002BA RID: 698
		// (get) Token: 0x0600063A RID: 1594 RVA: 0x0001804D File Offset: 0x0001624D
		// (set) Token: 0x0600063B RID: 1595 RVA: 0x00018055 File Offset: 0x00016255
		public XStringAlignment Alignment
		{
			get
			{
				return this._alignment;
			}
			set
			{
				this._alignment = value;
			}
		}

		// Token: 0x170002BB RID: 699
		// (get) Token: 0x0600063C RID: 1596 RVA: 0x0001805E File Offset: 0x0001625E
		// (set) Token: 0x0600063D RID: 1597 RVA: 0x00018066 File Offset: 0x00016266
		public XLineAlignment LineAlignment
		{
			get
			{
				return this._lineAlignment;
			}
			set
			{
				this._lineAlignment = value;
			}
		}

		// Token: 0x170002BC RID: 700
		// (get) Token: 0x0600063E RID: 1598 RVA: 0x0001806F File Offset: 0x0001626F
		[Obsolete("Use XStringFormats.Default. (Note plural in class name.)")]
		public static XStringFormat Default
		{
			get
			{
				return XStringFormats.Default;
			}
		}

		// Token: 0x170002BD RID: 701
		// (get) Token: 0x0600063F RID: 1599 RVA: 0x00018076 File Offset: 0x00016276
		[Obsolete("Use XStringFormats.Default. (Note plural in class name.)")]
		public static XStringFormat TopLeft
		{
			get
			{
				return XStringFormats.TopLeft;
			}
		}

		// Token: 0x170002BE RID: 702
		// (get) Token: 0x06000640 RID: 1600 RVA: 0x0001807D File Offset: 0x0001627D
		[Obsolete("Use XStringFormats.Center. (Note plural in class name.)")]
		public static XStringFormat Center
		{
			get
			{
				return XStringFormats.Center;
			}
		}

		// Token: 0x170002BF RID: 703
		// (get) Token: 0x06000641 RID: 1601 RVA: 0x00018084 File Offset: 0x00016284
		[Obsolete("Use XStringFormats.TopCenter. (Note plural in class name.)")]
		public static XStringFormat TopCenter
		{
			get
			{
				return XStringFormats.TopCenter;
			}
		}

		// Token: 0x170002C0 RID: 704
		// (get) Token: 0x06000642 RID: 1602 RVA: 0x0001808B File Offset: 0x0001628B
		[Obsolete("Use XStringFormats.BottomCenter. (Note plural in class name.)")]
		public static XStringFormat BottomCenter
		{
			get
			{
				return XStringFormats.BottomCenter;
			}
		}

		// Token: 0x040002B9 RID: 697
		private XStringAlignment _alignment;

		// Token: 0x040002BA RID: 698
		private XLineAlignment _lineAlignment;
	}
}
