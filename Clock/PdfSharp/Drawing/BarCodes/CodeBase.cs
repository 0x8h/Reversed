using System;

namespace PdfSharp.Drawing.BarCodes
{
	// Token: 0x02000004 RID: 4
	public abstract class CodeBase
	{
		// Token: 0x06000001 RID: 1 RVA: 0x000020D0 File Offset: 0x000002D0
		public CodeBase(string text, XSize size, CodeDirection direction)
		{
			this._text = text;
			this._size = size;
			this._direction = direction;
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000002 RID: 2 RVA: 0x000020ED File Offset: 0x000002ED
		// (set) Token: 0x06000003 RID: 3 RVA: 0x000020F5 File Offset: 0x000002F5
		public XSize Size
		{
			get
			{
				return this._size;
			}
			set
			{
				this._size = value;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000004 RID: 4 RVA: 0x000020FE File Offset: 0x000002FE
		// (set) Token: 0x06000005 RID: 5 RVA: 0x00002106 File Offset: 0x00000306
		public string Text
		{
			get
			{
				return this._text;
			}
			set
			{
				this.CheckCode(value);
				this._text = value;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000006 RID: 6 RVA: 0x00002116 File Offset: 0x00000316
		// (set) Token: 0x06000007 RID: 7 RVA: 0x0000211E File Offset: 0x0000031E
		public AnchorType Anchor
		{
			get
			{
				return this._anchor;
			}
			set
			{
				this._anchor = value;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000008 RID: 8 RVA: 0x00002127 File Offset: 0x00000327
		// (set) Token: 0x06000009 RID: 9 RVA: 0x0000212F File Offset: 0x0000032F
		public CodeDirection Direction
		{
			get
			{
				return this._direction;
			}
			set
			{
				this._direction = value;
			}
		}

		// Token: 0x0600000A RID: 10
		protected abstract void CheckCode(string text);

		// Token: 0x0600000B RID: 11 RVA: 0x00002138 File Offset: 0x00000338
		public static XVector CalcDistance(AnchorType oldType, AnchorType newType, XSize size)
		{
			if (oldType == newType)
			{
				return default(XVector);
			}
			CodeBase.Delta delta = CodeBase.Deltas[(int)oldType, (int)newType];
			XVector xvector = new XVector(size.Width / 2.0 * (double)delta.X, size.Height / 2.0 * (double)delta.Y);
			return xvector;
		}

		// Token: 0x0600000C RID: 12 RVA: 0x000021A4 File Offset: 0x000003A4
		// Note: this type is marked as 'beforefieldinit'.
		static CodeBase()
		{
			CodeBase.Delta[,] array = new CodeBase.Delta[9, 9];
			array[0, 0] = new CodeBase.Delta(0, 0);
			array[0, 1] = new CodeBase.Delta(1, 0);
			array[0, 2] = new CodeBase.Delta(2, 0);
			array[0, 3] = new CodeBase.Delta(0, 1);
			array[0, 4] = new CodeBase.Delta(1, 1);
			array[0, 5] = new CodeBase.Delta(2, 1);
			array[0, 6] = new CodeBase.Delta(0, 2);
			array[0, 7] = new CodeBase.Delta(1, 2);
			array[0, 8] = new CodeBase.Delta(2, 2);
			array[1, 0] = new CodeBase.Delta(-1, 0);
			array[1, 1] = new CodeBase.Delta(0, 0);
			array[1, 2] = new CodeBase.Delta(1, 0);
			array[1, 3] = new CodeBase.Delta(-1, 1);
			array[1, 4] = new CodeBase.Delta(0, 1);
			array[1, 5] = new CodeBase.Delta(1, 1);
			array[1, 6] = new CodeBase.Delta(-1, 2);
			array[1, 7] = new CodeBase.Delta(0, 2);
			array[1, 8] = new CodeBase.Delta(1, 2);
			array[2, 0] = new CodeBase.Delta(-2, 0);
			array[2, 1] = new CodeBase.Delta(-1, 0);
			array[2, 2] = new CodeBase.Delta(0, 0);
			array[2, 3] = new CodeBase.Delta(-2, 1);
			array[2, 4] = new CodeBase.Delta(-1, 1);
			array[2, 5] = new CodeBase.Delta(0, 1);
			array[2, 6] = new CodeBase.Delta(-2, 2);
			array[2, 7] = new CodeBase.Delta(-1, 2);
			array[2, 8] = new CodeBase.Delta(0, 2);
			array[3, 0] = new CodeBase.Delta(0, -1);
			array[3, 1] = new CodeBase.Delta(1, -1);
			array[3, 2] = new CodeBase.Delta(2, -1);
			array[3, 3] = new CodeBase.Delta(0, 0);
			array[3, 4] = new CodeBase.Delta(1, 0);
			array[3, 5] = new CodeBase.Delta(2, 0);
			array[3, 6] = new CodeBase.Delta(0, 1);
			array[3, 7] = new CodeBase.Delta(1, 1);
			array[3, 8] = new CodeBase.Delta(2, 1);
			array[4, 0] = new CodeBase.Delta(-1, -1);
			array[4, 1] = new CodeBase.Delta(0, -1);
			array[4, 2] = new CodeBase.Delta(1, -1);
			array[4, 3] = new CodeBase.Delta(-1, 0);
			array[4, 4] = new CodeBase.Delta(0, 0);
			array[4, 5] = new CodeBase.Delta(1, 0);
			array[4, 6] = new CodeBase.Delta(-1, 1);
			array[4, 7] = new CodeBase.Delta(0, 1);
			array[4, 8] = new CodeBase.Delta(1, 1);
			array[5, 0] = new CodeBase.Delta(-2, -1);
			array[5, 1] = new CodeBase.Delta(-1, -1);
			array[5, 2] = new CodeBase.Delta(0, -1);
			array[5, 3] = new CodeBase.Delta(-2, 0);
			array[5, 4] = new CodeBase.Delta(-1, 0);
			array[5, 5] = new CodeBase.Delta(0, 0);
			array[5, 6] = new CodeBase.Delta(-2, 1);
			array[5, 7] = new CodeBase.Delta(-1, 1);
			array[5, 8] = new CodeBase.Delta(0, 1);
			array[6, 0] = new CodeBase.Delta(0, -2);
			array[6, 1] = new CodeBase.Delta(1, -2);
			array[6, 2] = new CodeBase.Delta(2, -2);
			array[6, 3] = new CodeBase.Delta(0, -1);
			array[6, 4] = new CodeBase.Delta(1, -1);
			array[6, 5] = new CodeBase.Delta(2, -1);
			array[6, 6] = new CodeBase.Delta(0, 0);
			array[6, 7] = new CodeBase.Delta(1, 0);
			array[6, 8] = new CodeBase.Delta(2, 0);
			array[7, 0] = new CodeBase.Delta(-1, -2);
			array[7, 1] = new CodeBase.Delta(0, -2);
			array[7, 2] = new CodeBase.Delta(1, -2);
			array[7, 3] = new CodeBase.Delta(-1, -1);
			array[7, 4] = new CodeBase.Delta(0, -1);
			array[7, 5] = new CodeBase.Delta(1, -1);
			array[7, 6] = new CodeBase.Delta(-1, 0);
			array[7, 7] = new CodeBase.Delta(0, 0);
			array[7, 8] = new CodeBase.Delta(1, 0);
			array[8, 0] = new CodeBase.Delta(-2, -2);
			array[8, 1] = new CodeBase.Delta(-1, -2);
			array[8, 2] = new CodeBase.Delta(0, -2);
			array[8, 3] = new CodeBase.Delta(-2, -1);
			array[8, 4] = new CodeBase.Delta(-1, -1);
			array[8, 5] = new CodeBase.Delta(0, -1);
			array[8, 6] = new CodeBase.Delta(-2, 0);
			array[8, 7] = new CodeBase.Delta(-1, 0);
			array[8, 8] = new CodeBase.Delta(0, 0);
			CodeBase.Deltas = array;
		}

		// Token: 0x0400000B RID: 11
		private XSize _size;

		// Token: 0x0400000C RID: 12
		private string _text;

		// Token: 0x0400000D RID: 13
		private AnchorType _anchor;

		// Token: 0x0400000E RID: 14
		private CodeDirection _direction;

		// Token: 0x0400000F RID: 15
		private static readonly CodeBase.Delta[,] Deltas;

		// Token: 0x02000005 RID: 5
		private struct Delta
		{
			// Token: 0x0600000D RID: 13 RVA: 0x00002827 File Offset: 0x00000A27
			public Delta(int x, int y)
			{
				this.X = x;
				this.Y = y;
			}

			// Token: 0x04000010 RID: 16
			public readonly int X;

			// Token: 0x04000011 RID: 17
			public readonly int Y;
		}
	}
}
