using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Clock
{
	// Token: 0x0200004B RID: 75
	public class ProgramTextBox : TextBox
	{
		// Token: 0x06000814 RID: 2068 RVA: 0x0005C008 File Offset: 0x0005A208
		public ProgramTextBox()
		{
			this.BackColor = Color.FromArgb(159, 217, 211);
			base.BorderStyle = BorderStyle.None;
			this.Font = new Font("メイリオ", 9f, FontStyle.Regular, GraphicsUnit.Point, 128);
			base.ScrollBars = ScrollBars.Both;
			this.Multiline = true;
			base.ReadOnly = true;
			base.WordWrap = false;
			this.Dock = DockStyle.Fill;
		}

		// Token: 0x06000815 RID: 2069 RVA: 0x0005C0A8 File Offset: 0x0005A2A8
		public void setProgram(ref List<string> codes, ref List<ProgramModule.Block> blocks)
		{
			string text = "";
			this._lines.Clear();
			for (int i = 0; i < codes.Count; i++)
			{
				text = string.Concat(new string[]
				{
					text,
					i.ToString(),
					": ",
					codes[i],
					"\r\n"
				});
				this._lines.Add((codes[i].Length - codes[i].Replace("\r\n", "").Length) / "\r\n".Length + 1);
			}
			this.Text = text;
			this._blocks = blocks;
		}

		// Token: 0x06000816 RID: 2070 RVA: 0x0005C161 File Offset: 0x0005A361
		public void setSelectBlocks(ref List<ProgramModule.Block> blocks, List<ProgramModule.Block> blockLoops = null)
		{
			this._selectBlocks = blocks;
			if (blockLoops == null)
			{
				this._selectBlockLoops.Clear();
			}
			else
			{
				this._selectBlockLoops = blockLoops;
			}
			base.Invalidate();
		}

		// Token: 0x06000817 RID: 2071
		[DllImport("USER32.DLL")]
		private static extern int GetScrollPos(IntPtr hWnd, int nBar);

		// Token: 0x06000818 RID: 2072 RVA: 0x0005C188 File Offset: 0x0005A388
		protected override void WndProc(ref Message message)
		{
			base.WndProc(ref message);
			if (message.Msg == 15)
			{
				Graphics graphics = base.CreateGraphics();
				int scrollPos = ProgramTextBox.GetScrollPos(base.Handle, 1);
				graphics.FillRectangle(new SolidBrush(this.BackColor), base.ClientRectangle);
				graphics.DrawString(this.Text, this.Font, new SolidBrush(Color.Black), new Point(0, this.Font.Height * -scrollPos));
				if (this._selectBlocks.Count > 0)
				{
					foreach (ProgramModule.Block block in this._selectBlocks)
					{
						int num = this._blocks.IndexOf(block);
						if (num >= 0)
						{
							int num2 = 0;
							for (int i = 0; i < num; i++)
							{
								num2 += this._lines[i];
							}
							graphics.FillRectangle(new SolidBrush(Color.FromArgb(128, 0, 0, 255)), new Rectangle(0, this.Font.Height * (num2 - scrollPos), base.Size.Width, this.Font.Height * this._lines[num]));
						}
					}
					foreach (ProgramModule.Block block2 in this._selectBlockLoops)
					{
						int num3 = this._blocks.IndexOf(block2);
						if (num3 >= 0)
						{
							int num4 = 0;
							for (int j = 0; j < num3; j++)
							{
								num4 += this._lines[j];
							}
							graphics.FillRectangle(new SolidBrush(Color.FromArgb(128, 255, 0, 0)), new Rectangle(0, this.Font.Height * (num4 - scrollPos), base.Size.Width, this.Font.Height * this._lines[num3]));
						}
					}
				}
			}
		}

		// Token: 0x040005D2 RID: 1490
		private const int WM_PAINT = 15;

		// Token: 0x040005D3 RID: 1491
		private List<ProgramModule.Block> _blocks = new List<ProgramModule.Block>();

		// Token: 0x040005D4 RID: 1492
		private List<ProgramModule.Block> _selectBlocks = new List<ProgramModule.Block>();

		// Token: 0x040005D5 RID: 1493
		private List<ProgramModule.Block> _selectBlockLoops = new List<ProgramModule.Block>();

		// Token: 0x040005D6 RID: 1494
		private List<int> _lines = new List<int>();
	}
}
