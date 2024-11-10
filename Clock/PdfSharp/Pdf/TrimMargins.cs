using System;
using System.Diagnostics;
using PdfSharp.Drawing;

namespace PdfSharp.Pdf
{
	// Token: 0x020001BF RID: 447
	[DebuggerDisplay("(Left={left.Millimeter}mm, Right={right.Millimeter}mm, Top={top.Millimeter}mm, Bottom={bottom.Millimeter}mm)")]
	public sealed class TrimMargins
	{
		// Token: 0x170004FB RID: 1275
		// (set) Token: 0x06000ED5 RID: 3797 RVA: 0x00039B42 File Offset: 0x00037D42
		public XUnit All
		{
			set
			{
				this._left = value;
				this._right = value;
				this._top = value;
				this._bottom = value;
			}
		}

		// Token: 0x170004FC RID: 1276
		// (get) Token: 0x06000ED6 RID: 3798 RVA: 0x00039B60 File Offset: 0x00037D60
		// (set) Token: 0x06000ED7 RID: 3799 RVA: 0x00039B68 File Offset: 0x00037D68
		public XUnit Left
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

		// Token: 0x170004FD RID: 1277
		// (get) Token: 0x06000ED8 RID: 3800 RVA: 0x00039B71 File Offset: 0x00037D71
		// (set) Token: 0x06000ED9 RID: 3801 RVA: 0x00039B79 File Offset: 0x00037D79
		public XUnit Right
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

		// Token: 0x170004FE RID: 1278
		// (get) Token: 0x06000EDA RID: 3802 RVA: 0x00039B82 File Offset: 0x00037D82
		// (set) Token: 0x06000EDB RID: 3803 RVA: 0x00039B8A File Offset: 0x00037D8A
		public XUnit Top
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

		// Token: 0x170004FF RID: 1279
		// (get) Token: 0x06000EDC RID: 3804 RVA: 0x00039B93 File Offset: 0x00037D93
		// (set) Token: 0x06000EDD RID: 3805 RVA: 0x00039B9B File Offset: 0x00037D9B
		public XUnit Bottom
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

		// Token: 0x17000500 RID: 1280
		// (get) Token: 0x06000EDE RID: 3806 RVA: 0x00039BA4 File Offset: 0x00037DA4
		public bool AreSet
		{
			get
			{
				return this._left.Value != 0.0 || this._right.Value != 0.0 || this._top.Value != 0.0 || this._bottom.Value != 0.0;
			}
		}

		// Token: 0x0400090A RID: 2314
		private XUnit _left;

		// Token: 0x0400090B RID: 2315
		private XUnit _right;

		// Token: 0x0400090C RID: 2316
		private XUnit _top;

		// Token: 0x0400090D RID: 2317
		private XUnit _bottom;
	}
}
