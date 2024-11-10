using System;
using System.Collections.Generic;

namespace PdfSharp.Pdf.IO
{
	// Token: 0x02000179 RID: 377
	internal class ShiftStack
	{
		// Token: 0x06000C6C RID: 3180 RVA: 0x00032D43 File Offset: 0x00030F43
		public ShiftStack()
		{
			this._items = new List<PdfItem>();
		}

		// Token: 0x06000C6D RID: 3181 RVA: 0x00032D58 File Offset: 0x00030F58
		public PdfItem[] ToArray(int start, int length)
		{
			PdfItem[] array = new PdfItem[length];
			int i = 0;
			int num = start;
			while (i < length)
			{
				array[i] = this._items[num];
				i++;
				num++;
			}
			return array;
		}

		// Token: 0x1700043F RID: 1087
		// (get) Token: 0x06000C6E RID: 3182 RVA: 0x00032D8E File Offset: 0x00030F8E
		public int SP
		{
			get
			{
				return this._sp;
			}
		}

		// Token: 0x17000440 RID: 1088
		public PdfItem this[int index]
		{
			get
			{
				if (index >= this._sp)
				{
					throw new ArgumentOutOfRangeException("index", index, "Value greater than stack index.");
				}
				return this._items[index];
			}
		}

		// Token: 0x06000C70 RID: 3184 RVA: 0x00032DC3 File Offset: 0x00030FC3
		public PdfItem GetItem(int relativeIndex)
		{
			if (relativeIndex >= 0 || -relativeIndex > this._sp)
			{
				throw new ArgumentOutOfRangeException("relativeIndex", relativeIndex, "Value out of stack range.");
			}
			return this._items[this._sp + relativeIndex];
		}

		// Token: 0x06000C71 RID: 3185 RVA: 0x00032DFC File Offset: 0x00030FFC
		public int GetInteger(int relativeIndex)
		{
			if (relativeIndex >= 0 || -relativeIndex > this._sp)
			{
				throw new ArgumentOutOfRangeException("relativeIndex", relativeIndex, "Value out of stack range.");
			}
			return ((PdfInteger)this._items[this._sp + relativeIndex]).Value;
		}

		// Token: 0x06000C72 RID: 3186 RVA: 0x00032E4A File Offset: 0x0003104A
		public void Shift(PdfItem item)
		{
			this._items.Add(item);
			this._sp++;
		}

		// Token: 0x06000C73 RID: 3187 RVA: 0x00032E66 File Offset: 0x00031066
		public void Reduce(int count)
		{
			if (count > this._sp)
			{
				throw new ArgumentException("count causes stack underflow.");
			}
			this._items.RemoveRange(this._sp - count, count);
			this._sp -= count;
		}

		// Token: 0x06000C74 RID: 3188 RVA: 0x00032E9E File Offset: 0x0003109E
		public void Reduce(PdfItem item, int count)
		{
			this.Reduce(count);
			this._items.Add(item);
			this._sp++;
		}

		// Token: 0x040007AE RID: 1966
		private int _sp;

		// Token: 0x040007AF RID: 1967
		private readonly List<PdfItem> _items;
	}
}
