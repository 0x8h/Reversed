using System;

namespace PdfSharp.Drawing
{
	// Token: 0x0200007E RID: 126
	public static class XStringFormats
	{
		// Token: 0x170002C1 RID: 705
		// (get) Token: 0x06000643 RID: 1603 RVA: 0x00018092 File Offset: 0x00016292
		public static XStringFormat Default
		{
			get
			{
				return XStringFormats.BaseLineLeft;
			}
		}

		// Token: 0x170002C2 RID: 706
		// (get) Token: 0x06000644 RID: 1604 RVA: 0x0001809C File Offset: 0x0001629C
		public static XStringFormat BaseLineLeft
		{
			get
			{
				return new XStringFormat
				{
					Alignment = XStringAlignment.Near,
					LineAlignment = XLineAlignment.BaseLine
				};
			}
		}

		// Token: 0x170002C3 RID: 707
		// (get) Token: 0x06000645 RID: 1605 RVA: 0x000180C0 File Offset: 0x000162C0
		public static XStringFormat TopLeft
		{
			get
			{
				return new XStringFormat
				{
					Alignment = XStringAlignment.Near,
					LineAlignment = XLineAlignment.Near
				};
			}
		}

		// Token: 0x170002C4 RID: 708
		// (get) Token: 0x06000646 RID: 1606 RVA: 0x000180E4 File Offset: 0x000162E4
		public static XStringFormat CenterLeft
		{
			get
			{
				return new XStringFormat
				{
					Alignment = XStringAlignment.Near,
					LineAlignment = XLineAlignment.Center
				};
			}
		}

		// Token: 0x170002C5 RID: 709
		// (get) Token: 0x06000647 RID: 1607 RVA: 0x00018108 File Offset: 0x00016308
		public static XStringFormat BottomLeft
		{
			get
			{
				return new XStringFormat
				{
					Alignment = XStringAlignment.Near,
					LineAlignment = XLineAlignment.Far
				};
			}
		}

		// Token: 0x170002C6 RID: 710
		// (get) Token: 0x06000648 RID: 1608 RVA: 0x0001812C File Offset: 0x0001632C
		public static XStringFormat BaseLineCenter
		{
			get
			{
				return new XStringFormat
				{
					Alignment = XStringAlignment.Center,
					LineAlignment = XLineAlignment.BaseLine
				};
			}
		}

		// Token: 0x170002C7 RID: 711
		// (get) Token: 0x06000649 RID: 1609 RVA: 0x00018150 File Offset: 0x00016350
		public static XStringFormat TopCenter
		{
			get
			{
				return new XStringFormat
				{
					Alignment = XStringAlignment.Center,
					LineAlignment = XLineAlignment.Near
				};
			}
		}

		// Token: 0x170002C8 RID: 712
		// (get) Token: 0x0600064A RID: 1610 RVA: 0x00018174 File Offset: 0x00016374
		public static XStringFormat Center
		{
			get
			{
				return new XStringFormat
				{
					Alignment = XStringAlignment.Center,
					LineAlignment = XLineAlignment.Center
				};
			}
		}

		// Token: 0x170002C9 RID: 713
		// (get) Token: 0x0600064B RID: 1611 RVA: 0x00018198 File Offset: 0x00016398
		public static XStringFormat BottomCenter
		{
			get
			{
				return new XStringFormat
				{
					Alignment = XStringAlignment.Center,
					LineAlignment = XLineAlignment.Far
				};
			}
		}

		// Token: 0x170002CA RID: 714
		// (get) Token: 0x0600064C RID: 1612 RVA: 0x000181BC File Offset: 0x000163BC
		public static XStringFormat BaseLineRight
		{
			get
			{
				return new XStringFormat
				{
					Alignment = XStringAlignment.Far,
					LineAlignment = XLineAlignment.BaseLine
				};
			}
		}

		// Token: 0x170002CB RID: 715
		// (get) Token: 0x0600064D RID: 1613 RVA: 0x000181E0 File Offset: 0x000163E0
		public static XStringFormat TopRight
		{
			get
			{
				return new XStringFormat
				{
					Alignment = XStringAlignment.Far,
					LineAlignment = XLineAlignment.Near
				};
			}
		}

		// Token: 0x170002CC RID: 716
		// (get) Token: 0x0600064E RID: 1614 RVA: 0x00018204 File Offset: 0x00016404
		public static XStringFormat CenterRight
		{
			get
			{
				return new XStringFormat
				{
					Alignment = XStringAlignment.Far,
					LineAlignment = XLineAlignment.Center
				};
			}
		}

		// Token: 0x170002CD RID: 717
		// (get) Token: 0x0600064F RID: 1615 RVA: 0x00018228 File Offset: 0x00016428
		public static XStringFormat BottomRight
		{
			get
			{
				return new XStringFormat
				{
					Alignment = XStringAlignment.Far,
					LineAlignment = XLineAlignment.Far
				};
			}
		}
	}
}
