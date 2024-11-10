using System;
using System.Collections.Generic;

namespace PdfSharp.Drawing.Layout
{
	// Token: 0x02000017 RID: 23
	public class XTextFormatter
	{
		// Token: 0x0600008D RID: 141 RVA: 0x000056AC File Offset: 0x000038AC
		public XTextFormatter(XGraphics gfx)
		{
			if (gfx == null)
			{
				throw new ArgumentNullException("gfx");
			}
			this._gfx = gfx;
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x0600008E RID: 142 RVA: 0x000056DB File Offset: 0x000038DB
		// (set) Token: 0x0600008F RID: 143 RVA: 0x000056E3 File Offset: 0x000038E3
		public string Text
		{
			get
			{
				return this._text;
			}
			set
			{
				this._text = value;
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x06000090 RID: 144 RVA: 0x000056EC File Offset: 0x000038EC
		// (set) Token: 0x06000091 RID: 145 RVA: 0x000056F4 File Offset: 0x000038F4
		public XFont Font
		{
			get
			{
				return this._font;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("Font");
				}
				this._font = value;
				this._lineSpace = this._font.GetHeight();
				this._cyAscent = this._lineSpace * (double)this._font.CellAscent / (double)this._font.CellSpace;
				this._cyDescent = this._lineSpace * (double)this._font.CellDescent / (double)this._font.CellSpace;
				this._spaceWidth = this._gfx.MeasureString("x\uf8f0x", value).Width;
				this._spaceWidth -= this._gfx.MeasureString("xx", value).Width;
			}
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x06000092 RID: 146 RVA: 0x000057B8 File Offset: 0x000039B8
		// (set) Token: 0x06000093 RID: 147 RVA: 0x000057C0 File Offset: 0x000039C0
		public XRect LayoutRectangle
		{
			get
			{
				return this._layoutRectangle;
			}
			set
			{
				this._layoutRectangle = value;
			}
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000094 RID: 148 RVA: 0x000057C9 File Offset: 0x000039C9
		// (set) Token: 0x06000095 RID: 149 RVA: 0x000057D1 File Offset: 0x000039D1
		public XParagraphAlignment Alignment
		{
			get
			{
				return this._alignment;
			}
			set
			{
				this._alignment = value;
			}
		}

		// Token: 0x06000096 RID: 150 RVA: 0x000057DA File Offset: 0x000039DA
		public void DrawString(string text, XFont font, XBrush brush, XRect layoutRectangle)
		{
			this.DrawString(text, font, brush, layoutRectangle, XStringFormats.TopLeft);
		}

		// Token: 0x06000097 RID: 151 RVA: 0x000057EC File Offset: 0x000039EC
		public void DrawString(string text, XFont font, XBrush brush, XRect layoutRectangle, XStringFormat format)
		{
			if (text == null)
			{
				throw new ArgumentNullException("text");
			}
			if (font == null)
			{
				throw new ArgumentNullException("font");
			}
			if (brush == null)
			{
				throw new ArgumentNullException("brush");
			}
			if (format.Alignment != XStringAlignment.Near || format.LineAlignment != XLineAlignment.Near)
			{
				throw new ArgumentException("Only TopLeft alignment is currently implemented.");
			}
			this.Text = text;
			this.Font = font;
			this.LayoutRectangle = layoutRectangle;
			if (text.Length == 0)
			{
				return;
			}
			this.CreateBlocks();
			this.CreateLayout();
			double x = layoutRectangle.Location.X;
			double num = layoutRectangle.Location.Y + this._cyAscent;
			int count = this._blocks.Count;
			for (int i = 0; i < count; i++)
			{
				XTextFormatter.Block block = this._blocks[i];
				if (block.Stop)
				{
					return;
				}
				if (block.Type != XTextFormatter.BlockType.LineBreak)
				{
					this._gfx.DrawString(block.Text, font, brush, x + block.Location.X, num + block.Location.Y);
				}
			}
		}

		// Token: 0x06000098 RID: 152 RVA: 0x00005900 File Offset: 0x00003B00
		private void CreateBlocks()
		{
			this._blocks.Clear();
			int length = this._text.Length;
			bool flag = false;
			int num = 0;
			int num2 = 0;
			for (int i = 0; i < length; i++)
			{
				char c = this._text[i];
				if (c == '\r')
				{
					if (i < length - 1 && this._text[i + 1] == '\n')
					{
						i++;
					}
					c = '\n';
				}
				if (c == '\n')
				{
					if (num2 != 0)
					{
						string text = this._text.Substring(num, num2);
						this._blocks.Add(new XTextFormatter.Block(text, XTextFormatter.BlockType.Text, this._gfx.MeasureString(text, this._font).Width));
					}
					num = i + 1;
					num2 = 0;
					this._blocks.Add(new XTextFormatter.Block(XTextFormatter.BlockType.LineBreak));
				}
				else if (char.IsWhiteSpace(c))
				{
					if (flag)
					{
						string text2 = this._text.Substring(num, num2);
						this._blocks.Add(new XTextFormatter.Block(text2, XTextFormatter.BlockType.Text, this._gfx.MeasureString(text2, this._font).Width));
						num = i + 1;
						num2 = 0;
					}
					else
					{
						num2++;
					}
				}
				else
				{
					flag = true;
					num2++;
				}
			}
			if (num2 != 0)
			{
				string text3 = this._text.Substring(num, num2);
				this._blocks.Add(new XTextFormatter.Block(text3, XTextFormatter.BlockType.Text, this._gfx.MeasureString(text3, this._font).Width));
			}
		}

		// Token: 0x06000099 RID: 153 RVA: 0x00005A7C File Offset: 0x00003C7C
		private void CreateLayout()
		{
			double width = this._layoutRectangle.Width;
			double num = this._layoutRectangle.Height - this._cyAscent - this._cyDescent;
			int num2 = 0;
			double num3 = 0.0;
			double num4 = 0.0;
			int count = this._blocks.Count;
			for (int i = 0; i < count; i++)
			{
				XTextFormatter.Block block = this._blocks[i];
				if (block.Type == XTextFormatter.BlockType.LineBreak)
				{
					if (this.Alignment == XParagraphAlignment.Justify)
					{
						this._blocks[num2].Alignment = XParagraphAlignment.Left;
					}
					this.AlignLine(num2, i - 1, width);
					num2 = i + 1;
					num3 = 0.0;
					num4 += this._lineSpace;
					if (num4 > num)
					{
						block.Stop = true;
						break;
					}
				}
				else
				{
					double width2 = block.Width;
					if ((num3 + width2 <= width || num3 == 0.0) && block.Type != XTextFormatter.BlockType.LineBreak)
					{
						block.Location = new XPoint(num3, num4);
						num3 += width2 + this._spaceWidth;
					}
					else
					{
						this.AlignLine(num2, i - 1, width);
						num2 = i;
						num4 += this._lineSpace;
						if (num4 > num)
						{
							block.Stop = true;
							break;
						}
						block.Location = new XPoint(0.0, num4);
						num3 = width2 + this._spaceWidth;
					}
				}
			}
			if (num2 < count && this.Alignment != XParagraphAlignment.Justify)
			{
				this.AlignLine(num2, count - 1, width);
			}
		}

		// Token: 0x0600009A RID: 154 RVA: 0x00005C00 File Offset: 0x00003E00
		private void AlignLine(int firstIndex, int lastIndex, double layoutWidth)
		{
			XParagraphAlignment alignment = this._blocks[firstIndex].Alignment;
			if (this._alignment == XParagraphAlignment.Left || alignment == XParagraphAlignment.Left)
			{
				return;
			}
			int num = lastIndex - firstIndex + 1;
			if (num == 0)
			{
				return;
			}
			double num2 = -this._spaceWidth;
			for (int i = firstIndex; i <= lastIndex; i++)
			{
				num2 += this._blocks[i].Width + this._spaceWidth;
			}
			double num3 = Math.Max(layoutWidth - num2, 0.0);
			if (this._alignment != XParagraphAlignment.Justify)
			{
				if (this._alignment == XParagraphAlignment.Center)
				{
					num3 /= 2.0;
				}
				for (int j = firstIndex; j <= lastIndex; j++)
				{
					XTextFormatter.Block block = this._blocks[j];
					block.Location += new XSize(num3, 0.0);
				}
				return;
			}
			if (num > 1)
			{
				num3 /= (double)(num - 1);
				int k = firstIndex + 1;
				int num4 = 1;
				while (k <= lastIndex)
				{
					XTextFormatter.Block block2 = this._blocks[k];
					block2.Location += new XSize(num3 * (double)num4, 0.0);
					k++;
					num4++;
				}
			}
		}

		// Token: 0x04000064 RID: 100
		private readonly XGraphics _gfx;

		// Token: 0x04000065 RID: 101
		private string _text;

		// Token: 0x04000066 RID: 102
		private XFont _font;

		// Token: 0x04000067 RID: 103
		private double _lineSpace;

		// Token: 0x04000068 RID: 104
		private double _cyAscent;

		// Token: 0x04000069 RID: 105
		private double _cyDescent;

		// Token: 0x0400006A RID: 106
		private double _spaceWidth;

		// Token: 0x0400006B RID: 107
		private XRect _layoutRectangle;

		// Token: 0x0400006C RID: 108
		private XParagraphAlignment _alignment = XParagraphAlignment.Left;

		// Token: 0x0400006D RID: 109
		private readonly List<XTextFormatter.Block> _blocks = new List<XTextFormatter.Block>();

		// Token: 0x02000018 RID: 24
		private enum BlockType
		{
			// Token: 0x0400006F RID: 111
			Text,
			// Token: 0x04000070 RID: 112
			Space,
			// Token: 0x04000071 RID: 113
			Hyphen,
			// Token: 0x04000072 RID: 114
			LineBreak
		}

		// Token: 0x02000019 RID: 25
		private class Block
		{
			// Token: 0x0600009B RID: 155 RVA: 0x00005D38 File Offset: 0x00003F38
			public Block(string text, XTextFormatter.BlockType type, double width)
			{
				this.Text = text;
				this.Type = type;
				this.Width = width;
			}

			// Token: 0x0600009C RID: 156 RVA: 0x00005D55 File Offset: 0x00003F55
			public Block(XTextFormatter.BlockType type)
			{
				this.Type = type;
			}

			// Token: 0x04000073 RID: 115
			public readonly string Text;

			// Token: 0x04000074 RID: 116
			public readonly XTextFormatter.BlockType Type;

			// Token: 0x04000075 RID: 117
			public readonly double Width;

			// Token: 0x04000076 RID: 118
			public XPoint Location;

			// Token: 0x04000077 RID: 119
			public XParagraphAlignment Alignment;

			// Token: 0x04000078 RID: 120
			public bool Stop;
		}
	}
}
