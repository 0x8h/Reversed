using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Clock
{
	// Token: 0x02000040 RID: 64
	public class NetworkObjectPropertyArea : PictureBox
	{
		// Token: 0x0600067E RID: 1662 RVA: 0x0004DFDE File Offset: 0x0004C1DE
		public NetworkObjectPropertyArea(NetworkWindow window)
		{
			this.InitializeComponent();
			this.Dock = DockStyle.Fill;
			this._window = window;
		}

		// Token: 0x0600067F RID: 1663 RVA: 0x0004E010 File Offset: 0x0004C210
		public void changeObject(NetworkProgramModules.ObjectInfo objectInfo)
		{
			this._objectInfo = objectInfo;
			base.Controls.Clear();
			int num = 0;
			Label label = new Label();
			label.Text = objectInfo.getObjectName();
			label.Location = new Point(0, num);
			label.Size = new Size(200, 14);
			base.Controls.Add(label);
			num += label.Height;
			if (this._objectInfo != null)
			{
				if (this._objectInfo is NetworkProgramModules.ObjectButtonInfo)
				{
					this.createUICaption(ref num);
					this.createUIBackColor(ref num);
					return;
				}
				if (this._objectInfo is NetworkProgramModules.ObjectLabelInfo)
				{
					this.createUICaption(ref num);
					this.createUIBackColor(ref num);
					return;
				}
				if (!(this._objectInfo is NetworkProgramModules.ObjectListInfo) && this._objectInfo is NetworkProgramModules.ObjectInputInfo)
				{
					this.createUIPlaceHolder(ref num);
				}
			}
		}

		// Token: 0x06000680 RID: 1664 RVA: 0x0004E0E0 File Offset: 0x0004C2E0
		private void createUIBackColor(ref int y)
		{
			string[] array = new string[] { "赤", "緑", "青" };
			Color[] array2 = new Color[]
			{
				Color.Red,
				Color.Green,
				Color.Blue
			};
			EventHandler[] array3 = new EventHandler[]
			{
				new EventHandler(this.ScrollBarBackColorRed_ValueChanged),
				new EventHandler(this.ScrollBarBackColorGreen_ValueChanged),
				new EventHandler(this.ScrollBarBackColorBlue_ValueChanged)
			};
			EventHandler[] array4 = new EventHandler[]
			{
				new EventHandler(this.NumericUpDownBackColorRed_ValueChanged),
				new EventHandler(this.NumericUpDownBackColorGreen_ValueChanged),
				new EventHandler(this.NumericUpDownBackColorBlue_ValueChanged)
			};
			this._scrollBarBackColors.Clear();
			this._numericUpDownBackColors.Clear();
			for (int i = 0; i < 3; i++)
			{
				int num = 10;
				Label label = new Label();
				label.Text = array[i];
				label.ForeColor = array2[i];
				label.Location = new Point(num, y);
				label.Size = new Size(22, 14);
				base.Controls.Add(label);
				num += 36;
				HScrollBar hscrollBar = new HScrollBar();
				hscrollBar.Location = new Point(num, y);
				hscrollBar.Size = new Size(122, 19);
				hscrollBar.LargeChange = 1;
				hscrollBar.Maximum = 255;
				hscrollBar.ValueChanged += array3[i];
				base.Controls.Add(hscrollBar);
				this._scrollBarBackColors.Add(hscrollBar);
				num += 133;
				NumericUpDown numericUpDown = new NumericUpDown();
				numericUpDown.Location = new Point(num, y);
				numericUpDown.Size = new Size(38, 19);
				numericUpDown.Maximum = 255m;
				numericUpDown.ValueChanged += array4[i];
				base.Controls.Add(numericUpDown);
				this._numericUpDownBackColors.Add(numericUpDown);
				y += 30;
			}
			this._numericUpDownBackColors[0].Value = this._objectInfo.Control.BackColor.R;
			this._numericUpDownBackColors[1].Value = this._objectInfo.Control.BackColor.G;
			this._numericUpDownBackColors[2].Value = this._objectInfo.Control.BackColor.B;
		}

		// Token: 0x06000681 RID: 1665 RVA: 0x0004E380 File Offset: 0x0004C580
		private void createUICaption(ref int y)
		{
			int num = 10;
			Label label = new Label();
			label.Text = "キャプション";
			label.Location = new Point(num, y + 4);
			label.Size = new Size(60, 14);
			base.Controls.Add(label);
			num += 60;
			this._textBox = new TextBox();
			this._textBox.Location = new Point(num, y);
			this._textBox.Size = new Size(122, 19);
			this._textBox.ImeMode = ImeMode.Hiragana;
			this._textBox.TextChanged += this.TextBoxCaption_TextChanged;
			base.Controls.Add(this._textBox);
			this._textBox.MaxLength = NetworkSimulator.NetworkVariable.VARIABLE_LENGTH_MAX;
			this._textBox.Text = this._objectInfo.Control.Text;
			y += 30;
		}

		// Token: 0x06000682 RID: 1666 RVA: 0x0004E46C File Offset: 0x0004C66C
		private void createUIPlaceHolder(ref int y)
		{
			int num = 10;
			Label label = new Label();
			label.Text = "プレースホルダー";
			label.Location = new Point(num, y + 4);
			label.Size = new Size(80, 14);
			base.Controls.Add(label);
			num += 80;
			this._textBox = new TextBox();
			this._textBox.Location = new Point(num, y);
			this._textBox.Size = new Size(122, 19);
			this._textBox.ImeMode = ImeMode.Hiragana;
			this._textBox.TextChanged += this.TextBoxPlaceHolder_TextChanged;
			base.Controls.Add(this._textBox);
			this._textBox.MaxLength = NetworkSimulator.NetworkVariable.VARIABLE_LENGTH_MAX;
			this._textBox.Text = ((NetworkObjectInput)this._objectInfo.Control).PlaceHolder.PlaceHolder;
			y += 30;
		}

		// Token: 0x06000683 RID: 1667 RVA: 0x0004E560 File Offset: 0x0004C760
		private void ScrollBarBackColorRed_ValueChanged(object sender, EventArgs e)
		{
			if (this._scrollBarBackColors[0].Value != this._numericUpDownBackColors[0].Value)
			{
				this._numericUpDownBackColors[0].Value = this._scrollBarBackColors[0].Value;
				this._window.addHistory(true);
				this._window.updateLog("オブジェクトのプロパティ変更");
			}
			this._objectInfo.Control.BackColor = Color.FromArgb(this._scrollBarBackColors[0].Value, (int)this._objectInfo.Control.BackColor.G, (int)this._objectInfo.Control.BackColor.B);
		}

		// Token: 0x06000684 RID: 1668 RVA: 0x0004E634 File Offset: 0x0004C834
		private void ScrollBarBackColorGreen_ValueChanged(object sender, EventArgs e)
		{
			if (this._scrollBarBackColors[1].Value != this._numericUpDownBackColors[1].Value)
			{
				this._numericUpDownBackColors[1].Value = this._scrollBarBackColors[1].Value;
				this._window.addHistory(true);
				this._window.updateLog("オブジェクトのプロパティ変更");
			}
			this._objectInfo.Control.BackColor = Color.FromArgb((int)this._objectInfo.Control.BackColor.R, this._scrollBarBackColors[1].Value, (int)this._objectInfo.Control.BackColor.B);
		}

		// Token: 0x06000685 RID: 1669 RVA: 0x0004E708 File Offset: 0x0004C908
		private void ScrollBarBackColorBlue_ValueChanged(object sender, EventArgs e)
		{
			if (this._scrollBarBackColors[2].Value != this._numericUpDownBackColors[2].Value)
			{
				this._numericUpDownBackColors[2].Value = this._scrollBarBackColors[2].Value;
				this._window.addHistory(true);
				this._window.updateLog("オブジェクトのプロパティ変更");
			}
			this._objectInfo.Control.BackColor = Color.FromArgb((int)this._objectInfo.Control.BackColor.R, (int)this._objectInfo.Control.BackColor.G, this._scrollBarBackColors[2].Value);
		}

		// Token: 0x06000686 RID: 1670 RVA: 0x0004E7DC File Offset: 0x0004C9DC
		private void NumericUpDownBackColorRed_ValueChanged(object sender, EventArgs e)
		{
			if (this._scrollBarBackColors[0].Value != this._numericUpDownBackColors[0].Value)
			{
				this._scrollBarBackColors[0].Value = (int)this._numericUpDownBackColors[0].Value;
			}
		}

		// Token: 0x06000687 RID: 1671 RVA: 0x0004E840 File Offset: 0x0004CA40
		private void NumericUpDownBackColorGreen_ValueChanged(object sender, EventArgs e)
		{
			if (this._scrollBarBackColors[1].Value != this._numericUpDownBackColors[1].Value)
			{
				this._scrollBarBackColors[1].Value = (int)this._numericUpDownBackColors[1].Value;
			}
		}

		// Token: 0x06000688 RID: 1672 RVA: 0x0004E8A4 File Offset: 0x0004CAA4
		private void NumericUpDownBackColorBlue_ValueChanged(object sender, EventArgs e)
		{
			if (this._scrollBarBackColors[2].Value != this._numericUpDownBackColors[2].Value)
			{
				this._scrollBarBackColors[2].Value = (int)this._numericUpDownBackColors[2].Value;
			}
		}

		// Token: 0x06000689 RID: 1673 RVA: 0x0004E908 File Offset: 0x0004CB08
		private void TextBoxCaption_TextChanged(object sender, EventArgs e)
		{
			if (this._objectInfo.Control.Text != this._textBox.Text)
			{
				this._objectInfo.Control.Text = this._textBox.Text;
				this._window.addHistory(true);
				this._window.updateLog("オブジェクトのプロパティ変更");
			}
		}

		// Token: 0x0600068A RID: 1674 RVA: 0x0004E970 File Offset: 0x0004CB70
		private void TextBoxPlaceHolder_TextChanged(object sender, EventArgs e)
		{
			if (((NetworkObjectInput)this._objectInfo.Control).PlaceHolder.PlaceHolder != this._textBox.Text)
			{
				((NetworkObjectInput)this._objectInfo.Control).PlaceHolder.PlaceHolder = this._textBox.Text;
				this._window.addHistory(true);
				this._window.updateLog("オブジェクトのプロパティ変更");
			}
		}

		// Token: 0x0600068B RID: 1675 RVA: 0x0004E9EA File Offset: 0x0004CBEA
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600068C RID: 1676 RVA: 0x0004EA09 File Offset: 0x0004CC09
		private void InitializeComponent()
		{
			this.components = new Container();
		}

		// Token: 0x040004EE RID: 1262
		private NetworkWindow _window;

		// Token: 0x040004EF RID: 1263
		private NetworkProgramModules.ObjectInfo _objectInfo;

		// Token: 0x040004F0 RID: 1264
		private List<HScrollBar> _scrollBarBackColors = new List<HScrollBar>();

		// Token: 0x040004F1 RID: 1265
		private List<NumericUpDown> _numericUpDownBackColors = new List<NumericUpDown>();

		// Token: 0x040004F2 RID: 1266
		private TextBox _textBox;

		// Token: 0x040004F3 RID: 1267
		private IContainer components;
	}
}
