using System;
using System.ComponentModel;

namespace PdfSharp.Drawing.BarCodes
{
	// Token: 0x02000006 RID: 6
	public abstract class BarCode : CodeBase
	{
		// Token: 0x0600000E RID: 14 RVA: 0x00002837 File Offset: 0x00000A37
		public BarCode(string text, XSize size, CodeDirection direction)
			: base(text, size, direction)
		{
			base.Text = text;
			base.Size = size;
			base.Direction = direction;
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00002858 File Offset: 0x00000A58
		public static BarCode FromType(CodeType type, string text, XSize size, CodeDirection direction)
		{
			switch (type)
			{
			case CodeType.Code2of5Interleaved:
				return new Code2of5Interleaved(text, size, direction);
			case CodeType.Code3of9Standard:
				return new Code3of9Standard(text, size, direction);
			default:
				throw new InvalidEnumArgumentException("type", (int)type, typeof(CodeType));
			}
		}

		// Token: 0x06000010 RID: 16 RVA: 0x0000289E File Offset: 0x00000A9E
		public static BarCode FromType(CodeType type, string text, XSize size)
		{
			return BarCode.FromType(type, text, size, CodeDirection.LeftToRight);
		}

		// Token: 0x06000011 RID: 17 RVA: 0x000028A9 File Offset: 0x00000AA9
		public static BarCode FromType(CodeType type, string text)
		{
			return BarCode.FromType(type, text, XSize.Empty, CodeDirection.LeftToRight);
		}

		// Token: 0x06000012 RID: 18 RVA: 0x000028B8 File Offset: 0x00000AB8
		public static BarCode FromType(CodeType type)
		{
			return BarCode.FromType(type, string.Empty, XSize.Empty, CodeDirection.LeftToRight);
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000013 RID: 19 RVA: 0x000028CB File Offset: 0x00000ACB
		// (set) Token: 0x06000014 RID: 20 RVA: 0x000028D6 File Offset: 0x00000AD6
		public virtual double WideNarrowRatio
		{
			get
			{
				return 0.0;
			}
			set
			{
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000015 RID: 21 RVA: 0x000028D8 File Offset: 0x00000AD8
		// (set) Token: 0x06000016 RID: 22 RVA: 0x000028E0 File Offset: 0x00000AE0
		public TextLocation TextLocation
		{
			get
			{
				return this._textLocation;
			}
			set
			{
				this._textLocation = value;
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000017 RID: 23 RVA: 0x000028E9 File Offset: 0x00000AE9
		// (set) Token: 0x06000018 RID: 24 RVA: 0x000028F1 File Offset: 0x00000AF1
		public int DataLength
		{
			get
			{
				return this._dataLength;
			}
			set
			{
				this._dataLength = value;
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000019 RID: 25 RVA: 0x000028FA File Offset: 0x00000AFA
		// (set) Token: 0x0600001A RID: 26 RVA: 0x00002902 File Offset: 0x00000B02
		public char StartChar
		{
			get
			{
				return this._startChar;
			}
			set
			{
				this._startChar = value;
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x0600001B RID: 27 RVA: 0x0000290B File Offset: 0x00000B0B
		// (set) Token: 0x0600001C RID: 28 RVA: 0x00002913 File Offset: 0x00000B13
		public char EndChar
		{
			get
			{
				return this._endChar;
			}
			set
			{
				this._endChar = value;
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x0600001D RID: 29 RVA: 0x0000291C File Offset: 0x00000B1C
		// (set) Token: 0x0600001E RID: 30 RVA: 0x00002924 File Offset: 0x00000B24
		public virtual bool TurboBit
		{
			get
			{
				return this._turboBit;
			}
			set
			{
				this._turboBit = value;
			}
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00002930 File Offset: 0x00000B30
		internal virtual void InitRendering(BarCodeRenderInfo info)
		{
			if (base.Text == null)
			{
				throw new InvalidOperationException(BcgSR.BarCodeNotSet);
			}
			if (base.Size.IsEmpty)
			{
				throw new InvalidOperationException(BcgSR.EmptyBarCodeSize);
			}
		}

		// Token: 0x06000020 RID: 32
		protected internal abstract void Render(XGraphics gfx, XBrush brush, XFont font, XPoint position);

		// Token: 0x04000012 RID: 18
		private TextLocation _textLocation;

		// Token: 0x04000013 RID: 19
		private int _dataLength;

		// Token: 0x04000014 RID: 20
		private char _startChar;

		// Token: 0x04000015 RID: 21
		private char _endChar;

		// Token: 0x04000016 RID: 22
		private bool _turboBit;
	}
}
