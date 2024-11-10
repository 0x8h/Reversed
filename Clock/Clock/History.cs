using System;

namespace Clock
{
	// Token: 0x02000024 RID: 36
	internal class History
	{
		// Token: 0x06000379 RID: 889 RVA: 0x0002EF14 File Offset: 0x0002D114
		public void initialize(string text)
		{
			this._history[0] = text;
			this._current = (this._top = (this._tail = (this._saved = 0)));
		}

		// Token: 0x0600037A RID: 890 RVA: 0x0002EF4C File Offset: 0x0002D14C
		public bool isSaved()
		{
			return this._current == this._saved;
		}

		// Token: 0x0600037B RID: 891 RVA: 0x0002EF5C File Offset: 0x0002D15C
		public void setSaved()
		{
			this._saved = this._current;
		}

		// Token: 0x0600037C RID: 892 RVA: 0x0002EF6C File Offset: 0x0002D16C
		public void addHistory(string text)
		{
			this._current = (this._current + 1) % 32;
			this._history[this._current] = text;
			this._top = this._current;
			if (this._top == this._tail)
			{
				this._tail = (this._current + 1) % 32;
			}
		}

		// Token: 0x0600037D RID: 893 RVA: 0x0002EFC3 File Offset: 0x0002D1C3
		public string getPrevious()
		{
			if (this._current != this._tail)
			{
				this._current = (this._current + 32 - 1) % 32;
				return this._history[this._current];
			}
			return null;
		}

		// Token: 0x0600037E RID: 894 RVA: 0x0002EFF6 File Offset: 0x0002D1F6
		public string getNext()
		{
			if (this._current != this._top)
			{
				this._current = (this._current + 1) % 32;
				return this._history[this._current];
			}
			return null;
		}

		// Token: 0x040002EA RID: 746
		private const int HISTORY_MAX = 32;

		// Token: 0x040002EB RID: 747
		private int _current;

		// Token: 0x040002EC RID: 748
		private int _top;

		// Token: 0x040002ED RID: 749
		private int _tail;

		// Token: 0x040002EE RID: 750
		private int _saved;

		// Token: 0x040002EF RID: 751
		private string[] _history = new string[32];
	}
}
