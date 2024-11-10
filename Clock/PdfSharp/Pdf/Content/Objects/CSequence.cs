using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace PdfSharp.Pdf.Content.Objects
{
	// Token: 0x02000143 RID: 323
	[DebuggerDisplay("(count={Count})")]
	public class CSequence : CObject, IList<CObject>, ICollection<CObject>, IEnumerable<CObject>, IEnumerable
	{
		// Token: 0x06000AE7 RID: 2791 RVA: 0x0002AD2E File Offset: 0x00028F2E
		public new CSequence Clone()
		{
			return (CSequence)this.Copy();
		}

		// Token: 0x06000AE8 RID: 2792 RVA: 0x0002AD3C File Offset: 0x00028F3C
		protected override CObject Copy()
		{
			CObject cobject = base.Copy();
			this._items = new List<CObject>(this._items);
			for (int i = 0; i < this._items.Count; i++)
			{
				this._items[i] = this._items[i].Clone();
			}
			return cobject;
		}

		// Token: 0x06000AE9 RID: 2793 RVA: 0x0002AD98 File Offset: 0x00028F98
		public void Add(CSequence sequence)
		{
			int count = sequence.Count;
			for (int i = 0; i < count; i++)
			{
				this._items.Add(sequence[i]);
			}
		}

		// Token: 0x06000AEA RID: 2794 RVA: 0x0002ADCA File Offset: 0x00028FCA
		public void Add(CObject value)
		{
			this._items.Add(value);
		}

		// Token: 0x06000AEB RID: 2795 RVA: 0x0002ADD8 File Offset: 0x00028FD8
		public void Clear()
		{
			this._items.Clear();
		}

		// Token: 0x06000AEC RID: 2796 RVA: 0x0002ADE5 File Offset: 0x00028FE5
		public bool Contains(CObject value)
		{
			return this._items.Contains(value);
		}

		// Token: 0x06000AED RID: 2797 RVA: 0x0002ADF3 File Offset: 0x00028FF3
		public int IndexOf(CObject value)
		{
			return this._items.IndexOf(value);
		}

		// Token: 0x06000AEE RID: 2798 RVA: 0x0002AE01 File Offset: 0x00029001
		public void Insert(int index, CObject value)
		{
			this._items.Insert(index, value);
		}

		// Token: 0x06000AEF RID: 2799 RVA: 0x0002AE10 File Offset: 0x00029010
		public bool Remove(CObject value)
		{
			return this._items.Remove(value);
		}

		// Token: 0x06000AF0 RID: 2800 RVA: 0x0002AE1E File Offset: 0x0002901E
		public void RemoveAt(int index)
		{
			this._items.RemoveAt(index);
		}

		// Token: 0x17000408 RID: 1032
		public CObject this[int index]
		{
			get
			{
				return this._items[index];
			}
			set
			{
				this._items[index] = value;
			}
		}

		// Token: 0x06000AF3 RID: 2803 RVA: 0x0002AE49 File Offset: 0x00029049
		public void CopyTo(CObject[] array, int index)
		{
			this._items.CopyTo(array, index);
		}

		// Token: 0x17000409 RID: 1033
		// (get) Token: 0x06000AF4 RID: 2804 RVA: 0x0002AE58 File Offset: 0x00029058
		public int Count
		{
			get
			{
				return this._items.Count;
			}
		}

		// Token: 0x06000AF5 RID: 2805 RVA: 0x0002AE65 File Offset: 0x00029065
		public IEnumerator<CObject> GetEnumerator()
		{
			return this._items.GetEnumerator();
		}

		// Token: 0x06000AF6 RID: 2806 RVA: 0x0002AE78 File Offset: 0x00029078
		public byte[] ToContent()
		{
			Stream stream = new MemoryStream();
			ContentWriter contentWriter = new ContentWriter(stream);
			this.WriteObject(contentWriter);
			contentWriter.Close(false);
			stream.Position = 0L;
			int num = (int)stream.Length;
			byte[] array = new byte[num];
			stream.Read(array, 0, num);
			stream.Close();
			return array;
		}

		// Token: 0x06000AF7 RID: 2807 RVA: 0x0002AEC8 File Offset: 0x000290C8
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < this._items.Count; i++)
			{
				stringBuilder.Append(this._items[i]);
			}
			return stringBuilder.ToString();
		}

		// Token: 0x06000AF8 RID: 2808 RVA: 0x0002AF0A File Offset: 0x0002910A
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Token: 0x06000AF9 RID: 2809 RVA: 0x0002AF14 File Offset: 0x00029114
		internal override void WriteObject(ContentWriter writer)
		{
			for (int i = 0; i < this._items.Count; i++)
			{
				this._items[i].WriteObject(writer);
			}
		}

		// Token: 0x06000AFA RID: 2810 RVA: 0x0002AF49 File Offset: 0x00029149
		int IList<CObject>.IndexOf(CObject item)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000AFB RID: 2811 RVA: 0x0002AF50 File Offset: 0x00029150
		void IList<CObject>.Insert(int index, CObject item)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000AFC RID: 2812 RVA: 0x0002AF57 File Offset: 0x00029157
		void IList<CObject>.RemoveAt(int index)
		{
			throw new NotImplementedException();
		}

		// Token: 0x1700040A RID: 1034
		CObject IList<CObject>.this[int index]
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x06000AFF RID: 2815 RVA: 0x0002AF6C File Offset: 0x0002916C
		void ICollection<CObject>.Add(CObject item)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000B00 RID: 2816 RVA: 0x0002AF73 File Offset: 0x00029173
		void ICollection<CObject>.Clear()
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000B01 RID: 2817 RVA: 0x0002AF7A File Offset: 0x0002917A
		bool ICollection<CObject>.Contains(CObject item)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000B02 RID: 2818 RVA: 0x0002AF81 File Offset: 0x00029181
		void ICollection<CObject>.CopyTo(CObject[] array, int arrayIndex)
		{
			throw new NotImplementedException();
		}

		// Token: 0x1700040B RID: 1035
		// (get) Token: 0x06000B03 RID: 2819 RVA: 0x0002AF88 File Offset: 0x00029188
		int ICollection<CObject>.Count
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x1700040C RID: 1036
		// (get) Token: 0x06000B04 RID: 2820 RVA: 0x0002AF8F File Offset: 0x0002918F
		bool ICollection<CObject>.IsReadOnly
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x06000B05 RID: 2821 RVA: 0x0002AF96 File Offset: 0x00029196
		bool ICollection<CObject>.Remove(CObject item)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06000B06 RID: 2822 RVA: 0x0002AF9D File Offset: 0x0002919D
		IEnumerator<CObject> IEnumerable<CObject>.GetEnumerator()
		{
			throw new NotImplementedException();
		}

		// Token: 0x04000630 RID: 1584
		private List<CObject> _items = new List<CObject>();
	}
}
