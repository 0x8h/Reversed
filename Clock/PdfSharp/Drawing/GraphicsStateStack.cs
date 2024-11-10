using System;
using System.Collections.Generic;

namespace PdfSharp.Drawing
{
	// Token: 0x02000039 RID: 57
	internal class GraphicsStateStack
	{
		// Token: 0x0600012F RID: 303 RVA: 0x0000A3A4 File Offset: 0x000085A4
		public GraphicsStateStack(XGraphics gfx)
		{
			this._current = new InternalGraphicsState(gfx);
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x06000130 RID: 304 RVA: 0x0000A3C3 File Offset: 0x000085C3
		public int Count
		{
			get
			{
				return this._stack.Count;
			}
		}

		// Token: 0x06000131 RID: 305 RVA: 0x0000A3D0 File Offset: 0x000085D0
		public void Push(InternalGraphicsState state)
		{
			this._stack.Push(state);
			state.Pushed();
		}

		// Token: 0x06000132 RID: 306 RVA: 0x0000A3E4 File Offset: 0x000085E4
		public int Restore(InternalGraphicsState state)
		{
			if (!this._stack.Contains(state))
			{
				throw new ArgumentException("State not on stack.", "state");
			}
			if (state.Invalid)
			{
				throw new ArgumentException("State already restored.", "state");
			}
			int num = 1;
			InternalGraphicsState internalGraphicsState = this._stack.Pop();
			internalGraphicsState.Popped();
			while (internalGraphicsState != state)
			{
				num++;
				state.Invalid = true;
				internalGraphicsState = this._stack.Pop();
				internalGraphicsState.Popped();
			}
			state.Invalid = true;
			return num;
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x06000133 RID: 307 RVA: 0x0000A466 File Offset: 0x00008666
		public InternalGraphicsState Current
		{
			get
			{
				if (this._stack.Count == 0)
				{
					return this._current;
				}
				return this._stack.Peek();
			}
		}

		// Token: 0x040001B1 RID: 433
		private readonly InternalGraphicsState _current;

		// Token: 0x040001B2 RID: 434
		private readonly Stack<InternalGraphicsState> _stack = new Stack<InternalGraphicsState>();
	}
}
