using System;

namespace PdfSharp.Drawing
{
	// Token: 0x0200003B RID: 59
	internal class InternalGraphicsState
	{
		// Token: 0x06000134 RID: 308 RVA: 0x0000A487 File Offset: 0x00008687
		public InternalGraphicsState(XGraphics gfx)
		{
			this._gfx = gfx;
		}

		// Token: 0x06000135 RID: 309 RVA: 0x0000A496 File Offset: 0x00008696
		public InternalGraphicsState(XGraphics gfx, XGraphicsState state)
		{
			this._gfx = gfx;
			this.State = state;
			this.State.InternalState = this;
		}

		// Token: 0x06000136 RID: 310 RVA: 0x0000A4B8 File Offset: 0x000086B8
		public InternalGraphicsState(XGraphics gfx, XGraphicsContainer container)
		{
			this._gfx = gfx;
			container.InternalState = this;
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x06000137 RID: 311 RVA: 0x0000A4CE File Offset: 0x000086CE
		// (set) Token: 0x06000138 RID: 312 RVA: 0x0000A4D6 File Offset: 0x000086D6
		public XMatrix Transform
		{
			get
			{
				return this._transform;
			}
			set
			{
				this._transform = value;
			}
		}

		// Token: 0x06000139 RID: 313 RVA: 0x0000A4DF File Offset: 0x000086DF
		public void Pushed()
		{
		}

		// Token: 0x0600013A RID: 314 RVA: 0x0000A4E1 File Offset: 0x000086E1
		public void Popped()
		{
			this.Invalid = true;
		}

		// Token: 0x040001B3 RID: 435
		private XMatrix _transform;

		// Token: 0x040001B4 RID: 436
		public bool Invalid;

		// Token: 0x040001B5 RID: 437
		private readonly XGraphics _gfx;

		// Token: 0x040001B6 RID: 438
		internal XGraphicsState State;
	}
}
