using System;
using System.Collections;
using System.Collections.Generic;
using PdfSharp.Drawing;

namespace PdfSharp.Pdf
{
	// Token: 0x020001AB RID: 427
	public class PdfOutlineCollection : PdfObject, IList<PdfOutline>, ICollection<PdfOutline>, IEnumerable<PdfOutline>, IEnumerable
	{
		// Token: 0x06000DD8 RID: 3544 RVA: 0x0003667D File Offset: 0x0003487D
		internal PdfOutlineCollection(PdfDocument document, PdfOutline parent)
			: base(document)
		{
			this._parent = parent;
		}

		// Token: 0x170004B3 RID: 1203
		// (get) Token: 0x06000DD9 RID: 3545 RVA: 0x00036698 File Offset: 0x00034898
		[Obsolete("Use 'Count > 0' - HasOutline will throw exception.")]
		public bool HasOutline
		{
			get
			{
				throw new InvalidOperationException("Use 'Count > 0'");
			}
		}

		// Token: 0x06000DDA RID: 3546 RVA: 0x000366A4 File Offset: 0x000348A4
		public bool Remove(PdfOutline item)
		{
			if (this._outlines.Remove(item))
			{
				this.RemoveFromOutlinesTree(item);
				return true;
			}
			return false;
		}

		// Token: 0x170004B4 RID: 1204
		// (get) Token: 0x06000DDB RID: 3547 RVA: 0x000366BE File Offset: 0x000348BE
		public int Count
		{
			get
			{
				return this._outlines.Count;
			}
		}

		// Token: 0x170004B5 RID: 1205
		// (get) Token: 0x06000DDC RID: 3548 RVA: 0x000366CB File Offset: 0x000348CB
		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		// Token: 0x06000DDD RID: 3549 RVA: 0x000366D0 File Offset: 0x000348D0
		public void Add(PdfOutline outline)
		{
			if (outline == null)
			{
				throw new ArgumentNullException("outline");
			}
			if (outline.DestinationPage != null && !object.ReferenceEquals(this.Owner, outline.DestinationPage.Owner))
			{
				throw new ArgumentException("Destination page must belong to this document.");
			}
			this.AddToOutlinesTree(outline);
			this._outlines.Add(outline);
			if (outline.Opened)
			{
				for (outline = this._parent; outline != null; outline = outline.Parent)
				{
					outline.OpenCount++;
				}
			}
		}

		// Token: 0x06000DDE RID: 3550 RVA: 0x00036754 File Offset: 0x00034954
		public void Clear()
		{
			if (this.Count > 0)
			{
				PdfOutline[] array = new PdfOutline[this.Count];
				this._outlines.CopyTo(array);
				this._outlines.Clear();
				foreach (PdfOutline pdfOutline in array)
				{
					this.RemoveFromOutlinesTree(pdfOutline);
				}
			}
		}

		// Token: 0x06000DDF RID: 3551 RVA: 0x000367A8 File Offset: 0x000349A8
		public bool Contains(PdfOutline item)
		{
			return this._outlines.Contains(item);
		}

		// Token: 0x06000DE0 RID: 3552 RVA: 0x000367B6 File Offset: 0x000349B6
		public void CopyTo(PdfOutline[] array, int arrayIndex)
		{
			this._outlines.CopyTo(array, arrayIndex);
		}

		// Token: 0x06000DE1 RID: 3553 RVA: 0x000367C8 File Offset: 0x000349C8
		public PdfOutline Add(string title, PdfPage destinationPage, bool opened, PdfOutlineStyle style, XColor textColor)
		{
			PdfOutline pdfOutline = new PdfOutline(title, destinationPage, opened, style, textColor);
			this.Add(pdfOutline);
			return pdfOutline;
		}

		// Token: 0x06000DE2 RID: 3554 RVA: 0x000367EC File Offset: 0x000349EC
		public PdfOutline Add(string title, PdfPage destinationPage, bool opened, PdfOutlineStyle style)
		{
			PdfOutline pdfOutline = new PdfOutline(title, destinationPage, opened, style);
			this.Add(pdfOutline);
			return pdfOutline;
		}

		// Token: 0x06000DE3 RID: 3555 RVA: 0x0003680C File Offset: 0x00034A0C
		public PdfOutline Add(string title, PdfPage destinationPage, bool opened)
		{
			PdfOutline pdfOutline = new PdfOutline(title, destinationPage, opened);
			this.Add(pdfOutline);
			return pdfOutline;
		}

		// Token: 0x06000DE4 RID: 3556 RVA: 0x0003682C File Offset: 0x00034A2C
		public PdfOutline Add(string title, PdfPage destinationPage)
		{
			PdfOutline pdfOutline = new PdfOutline(title, destinationPage);
			this.Add(pdfOutline);
			return pdfOutline;
		}

		// Token: 0x06000DE5 RID: 3557 RVA: 0x00036849 File Offset: 0x00034A49
		public int IndexOf(PdfOutline item)
		{
			return this._outlines.IndexOf(item);
		}

		// Token: 0x06000DE6 RID: 3558 RVA: 0x00036858 File Offset: 0x00034A58
		public void Insert(int index, PdfOutline outline)
		{
			if (outline == null)
			{
				throw new ArgumentNullException("outline");
			}
			if (index < 0 || index >= this._outlines.Count)
			{
				throw new ArgumentOutOfRangeException("index", index, PSSR.OutlineIndexOutOfRange);
			}
			this.AddToOutlinesTree(outline);
			this._outlines.Insert(index, outline);
		}

		// Token: 0x06000DE7 RID: 3559 RVA: 0x000368B0 File Offset: 0x00034AB0
		public void RemoveAt(int index)
		{
			PdfOutline pdfOutline = this._outlines[index];
			this._outlines.RemoveAt(index);
			this.RemoveFromOutlinesTree(pdfOutline);
		}

		// Token: 0x170004B6 RID: 1206
		public PdfOutline this[int index]
		{
			get
			{
				if (index < 0 || index >= this._outlines.Count)
				{
					throw new ArgumentOutOfRangeException("index", index, PSSR.OutlineIndexOutOfRange);
				}
				return this._outlines[index];
			}
			set
			{
				if (index < 0 || index >= this._outlines.Count)
				{
					throw new ArgumentOutOfRangeException("index", index, PSSR.OutlineIndexOutOfRange);
				}
				if (value == null)
				{
					throw new ArgumentOutOfRangeException("value", null, PSSR.SetValueMustNotBeNull);
				}
				this.AddToOutlinesTree(value);
				this._outlines[index] = value;
			}
		}

		// Token: 0x06000DEA RID: 3562 RVA: 0x00036971 File Offset: 0x00034B71
		public IEnumerator<PdfOutline> GetEnumerator()
		{
			return this._outlines.GetEnumerator();
		}

		// Token: 0x06000DEB RID: 3563 RVA: 0x00036983 File Offset: 0x00034B83
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Token: 0x06000DEC RID: 3564 RVA: 0x0003698C File Offset: 0x00034B8C
		internal int CountOpen()
		{
			return 0;
		}

		// Token: 0x06000DED RID: 3565 RVA: 0x0003699C File Offset: 0x00034B9C
		private void AddToOutlinesTree(PdfOutline outline)
		{
			if (outline == null)
			{
				throw new ArgumentNullException("outline");
			}
			if (outline.DestinationPage != null && !object.ReferenceEquals(this.Owner, outline.DestinationPage.Owner))
			{
				throw new ArgumentException("Destination page must belong to this document.");
			}
			outline.Document = this.Owner;
			outline.Parent = this._parent;
			if (!this.Owner._irefTable.Contains(outline.ObjectID))
			{
				this.Owner._irefTable.Add(outline);
				return;
			}
			outline.GetType();
		}

		// Token: 0x06000DEE RID: 3566 RVA: 0x00036A2B File Offset: 0x00034C2B
		private void RemoveFromOutlinesTree(PdfOutline outline)
		{
			if (outline == null)
			{
				throw new ArgumentNullException("outline");
			}
			outline.Parent = null;
			this.Owner._irefTable.Remove(outline.Reference);
		}

		// Token: 0x0400089C RID: 2204
		private readonly PdfOutline _parent;

		// Token: 0x0400089D RID: 2205
		private readonly List<PdfOutline> _outlines = new List<PdfOutline>();
	}
}
