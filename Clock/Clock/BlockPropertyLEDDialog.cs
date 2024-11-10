using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clock.Properties;

namespace Clock
{
	// Token: 0x0200000B RID: 11
	public partial class BlockPropertyLEDDialog : Form
	{
		// Token: 0x06000095 RID: 149 RVA: 0x0000A334 File Offset: 0x00008534
		public BlockPropertyLEDDialog(ProgramModule.BlockLED block, int costMax, bool tutorial)
		{
			this.InitializeComponent();
			this.splitContainer1.Panel1MinSize = 10;
			this.splitContainer1.SplitterDistance = 10;
			this._block = block;
			this._costMax = costMax;
			this._tutorial = tutorial;
			this.numericUpDownRed.Value = this._block.Red;
			this.numericUpDownGreen.Value = this._block.Green;
			this.numericUpDownBlue.Value = this._block.Blue;
			this.numericUpDownTime.Value = (decimal)this._block.Time;
			switch (this._block.Mode)
			{
			case ProgramModule.BlockLED.LED_MODE.ON:
				this.radioButtonLightOn.Checked = true;
				break;
			case ProgramModule.BlockLED.LED_MODE.OFF:
				this.radioButtonLightOff.Checked = true;
				break;
			case ProgramModule.BlockLED.LED_MODE.ON_TIME:
				this.radioButtonLightOnTime.Checked = true;
				break;
			}
			switch (this._block.Fade)
			{
			case ProgramModule.BlockLED.FADE.NONE:
				this.radioButtonFadeNone.Checked = true;
				break;
			case ProgramModule.BlockLED.FADE.IN:
				this.radioButtonFadeIn.Checked = true;
				break;
			case ProgramModule.BlockLED.FADE.OUT:
				this.radioButtonFadeOut.Checked = true;
				break;
			}
			if (tutorial)
			{
				this.pictureBoxButtonPreview.Enabled = false;
				this.pictureBoxButtonCancel.Enabled = false;
				this.comboBoxColor.Enabled = false;
			}
			foreach (string text in ProgramModule.BlockLED.COLOR_ITEMS)
			{
				this.comboBoxColor.Items.Add(text);
			}
		}

		// Token: 0x06000096 RID: 150 RVA: 0x0000A4CB File Offset: 0x000086CB
		private void pictureBoxButtonPreview_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left && !this._preview && !this._previewLock)
			{
				this.pictureBoxButtonPreview.Image = Resources.popup_btn_022;
			}
		}

		// Token: 0x06000097 RID: 151 RVA: 0x0000A4FA File Offset: 0x000086FA
		private void pictureBoxButtonPreview_MouseEnter(object sender, EventArgs e)
		{
			if (!this._previewLock)
			{
				this.pictureBoxButtonPreview.Image = Resources.popup_btn_021;
			}
		}

		// Token: 0x06000098 RID: 152 RVA: 0x0000A514 File Offset: 0x00008714
		private void pictureBoxButtonPreview_MouseLeave(object sender, EventArgs e)
		{
			if (!this._previewLock)
			{
				this.pictureBoxButtonPreview.Image = Resources.popup_btn_020;
			}
		}

		// Token: 0x06000099 RID: 153 RVA: 0x0000A530 File Offset: 0x00008730
		private async void pictureBoxButtonPreview_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left && !this._preview && !this._previewLock)
			{
				this.pictureBoxButtonPreview.Image = Resources.popup_btn_021;
				if (this.radioButtonLightOnTime.Checked)
				{
					this._preview = true;
					Color start = Color.Black;
					Color end = Color.Black;
					if (this.radioButtonFadeIn.Checked)
					{
						end = Color.FromArgb(this.scrollBarRed.Value, this.scrollBarGreen.Value, this.scrollBarBlue.Value);
					}
					else if (this.radioButtonFadeOut.Checked)
					{
						start = Color.FromArgb(this.scrollBarRed.Value, this.scrollBarGreen.Value, this.scrollBarBlue.Value);
					}
					else
					{
						start = Color.FromArgb(this.scrollBarRed.Value, this.scrollBarGreen.Value, this.scrollBarBlue.Value);
						end = Color.FromArgb(this.scrollBarRed.Value, this.scrollBarGreen.Value, this.scrollBarBlue.Value);
					}
					await Task.Run(delegate
					{
						int num = Environment.TickCount;
						int num2 = 0;
						int num3 = (int)(this.numericUpDownTime.Value * 1000m);
						while (this._preview && num2 <= num3)
						{
							float num4 = (float)num2 / (float)num3;
							this.pictureBoxPreview.BackColor = Color.FromArgb((int)((double)((int)((float)start.R + num4 * (float)(end.R - start.R))) * 25.5), (int)((double)((int)((float)start.G + num4 * (float)(end.G - start.G))) * 25.5), (int)((double)((int)((float)start.B + num4 * (float)(end.B - start.B))) * 25.5));
							this.pictureBoxPreview.Invalidate();
							num2 += Environment.TickCount - num;
							num = Environment.TickCount;
						}
						this.pictureBoxPreview.BackColor = Color.FromArgb((int)((double)end.R * 25.5), (int)((double)end.G * 25.5), (int)((double)end.B * 25.5));
						this.pictureBoxPreview.Invalidate();
					});
					if (this.radioButtonFadeNone.Checked)
					{
						this.pictureBoxPreview.BackColor = Color.Black;
						this.pictureBoxPreview.Invalidate();
					}
					this._preview = false;
				}
			}
		}

		// Token: 0x0600009A RID: 154 RVA: 0x0000A56F File Offset: 0x0000876F
		private void pictureBoxButtonOK_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonOK.Image = Resources.popup_btn_002;
			}
		}

		// Token: 0x0600009B RID: 155 RVA: 0x0000A58E File Offset: 0x0000878E
		private void pictureBoxButtonOK_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxButtonOK.Image = Resources.popup_btn_001;
		}

		// Token: 0x0600009C RID: 156 RVA: 0x0000A5A0 File Offset: 0x000087A0
		private void pictureBoxButtonOK_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxButtonOK.Image = Resources.popup_btn_000;
		}

		// Token: 0x0600009D RID: 157 RVA: 0x0000A5B4 File Offset: 0x000087B4
		private void pictureBoxButtonOK_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonOK.Image = Resources.popup_btn_001;
				if (this._tutorial && (!(this.numericUpDownRed.Value == 10m) || !(this.numericUpDownGreen.Value == 0m) || !(this.numericUpDownBlue.Value == 0m) || (double)(float)this.numericUpDownTime.Value != 1.0 || !this.radioButtonLightOnTime.Checked))
				{
					return;
				}
				ProgramModule.BlockLED blockLED = new ProgramModule.BlockLED();
				this.setBlockData(blockLED);
				if (blockLED.getUsedMemory() > this._costMax)
				{
					WarningDialog warningDialog = new WarningDialog();
					warningDialog.setText(ProgramModule.ERROR_ITEMS[5]);
					warningDialog.ShowDialog();
					return;
				}
				this.setBlockData(this._block);
				base.Close();
			}
		}

		// Token: 0x0600009E RID: 158 RVA: 0x0000A6A4 File Offset: 0x000088A4
		private void setBlockData(ProgramModule.BlockLED block)
		{
			block.Red = (int)this.numericUpDownRed.Value;
			block.Green = (int)this.numericUpDownGreen.Value;
			block.Blue = (int)this.numericUpDownBlue.Value;
			if ((int)(Math.Floor(this.numericUpDownTime.Value * 100m) % (Math.Floor(this.numericUpDownTime.Value * 10m) * 10m)) >= 5)
			{
				block.Time = (float)(Math.Ceiling(this.numericUpDownTime.Value * 10m) / 10m);
			}
			else
			{
				block.Time = (float)(Math.Floor(this.numericUpDownTime.Value * 10m) / 10m);
			}
			if (this.radioButtonLightOff.Checked)
			{
				block.Mode = ProgramModule.BlockLED.LED_MODE.OFF;
			}
			else if (this.radioButtonLightOn.Checked)
			{
				block.Mode = ProgramModule.BlockLED.LED_MODE.ON;
			}
			else if (this.radioButtonLightOnTime.Checked)
			{
				block.Mode = ProgramModule.BlockLED.LED_MODE.ON_TIME;
			}
			if (this.radioButtonFadeNone.Checked)
			{
				block.Fade = ProgramModule.BlockLED.FADE.NONE;
				return;
			}
			if (this.radioButtonFadeIn.Checked)
			{
				block.Fade = ProgramModule.BlockLED.FADE.IN;
				return;
			}
			if (this.radioButtonFadeOut.Checked)
			{
				block.Fade = ProgramModule.BlockLED.FADE.OUT;
			}
		}

		// Token: 0x0600009F RID: 159 RVA: 0x0000A82C File Offset: 0x00008A2C
		private void setColor(Color color)
		{
			if (color.R == 0 && color.G == 0 && color.B == 0)
			{
				this.pictureBoxPreview.Image = Resources.popup_led_010;
			}
			else
			{
				this.pictureBoxPreview.Image = null;
			}
			this.pictureBoxPreview.BackColor = color;
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x0000A87E File Offset: 0x00008A7E
		private void pictureBoxButtonCancel_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonCancel.Image = Resources.popup_btn_012;
			}
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x0000A89D File Offset: 0x00008A9D
		private void pictureBoxButtonCancel_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxButtonCancel.Image = Resources.popup_btn_011;
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x0000A8AF File Offset: 0x00008AAF
		private void pictureBoxButtonCancel_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxButtonCancel.Image = Resources.popup_btn_010;
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x0000A8C1 File Offset: 0x00008AC1
		private void pictureBoxButtonCancel_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonCancel.Image = Resources.popup_btn_011;
				base.Close();
			}
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x0000A8E8 File Offset: 0x00008AE8
		private void scrollBarRed_ValueChanged(object sender, EventArgs e)
		{
			if (this.scrollBarRed.Value != this.numericUpDownRed.Value)
			{
				this.numericUpDownRed.Value = this.scrollBarRed.Value;
			}
			if (!this.radioButtonLightOff.Checked)
			{
				Color color = Color.FromArgb((int)((double)this.scrollBarRed.Value * 25.5), (int)((double)this.scrollBarGreen.Value * 25.5), (int)((double)this.scrollBarBlue.Value * 25.5));
				this.setColor(color);
				this._preview = false;
			}
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x0000A998 File Offset: 0x00008B98
		private void scrollBarGreen_ValueChanged(object sender, EventArgs e)
		{
			if (this.scrollBarGreen.Value != this.numericUpDownGreen.Value)
			{
				this.numericUpDownGreen.Value = this.scrollBarGreen.Value;
			}
			if (!this.radioButtonLightOff.Checked)
			{
				Color color = Color.FromArgb((int)((double)this.scrollBarRed.Value * 25.5), (int)((double)this.scrollBarGreen.Value * 25.5), (int)((double)this.scrollBarBlue.Value * 25.5));
				this.setColor(color);
				this._preview = false;
			}
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x0000AA48 File Offset: 0x00008C48
		private void scrollBarBlue_ValueChanged(object sender, EventArgs e)
		{
			if (this.scrollBarBlue.Value != this.numericUpDownBlue.Value)
			{
				this.numericUpDownBlue.Value = this.scrollBarBlue.Value;
			}
			if (!this.radioButtonLightOff.Checked)
			{
				Color color = Color.FromArgb((int)((double)this.scrollBarRed.Value * 25.5), (int)((double)this.scrollBarGreen.Value * 25.5), (int)((double)this.scrollBarBlue.Value * 25.5));
				this.setColor(color);
				this._preview = false;
			}
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x0000AAF8 File Offset: 0x00008CF8
		private void numericUpDownRed_ValueChanged(object sender, EventArgs e)
		{
			if (this.scrollBarRed.Value != this.numericUpDownRed.Value)
			{
				this.scrollBarRed.Value = (int)this.numericUpDownRed.Value;
			}
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x0000AB37 File Offset: 0x00008D37
		private void numericUpDownGreen_ValueChanged(object sender, EventArgs e)
		{
			if (this.scrollBarGreen.Value != this.numericUpDownGreen.Value)
			{
				this.scrollBarGreen.Value = (int)this.numericUpDownGreen.Value;
			}
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x0000AB76 File Offset: 0x00008D76
		private void numericUpDownBlue_ValueChanged(object sender, EventArgs e)
		{
			if (this.scrollBarBlue.Value != this.numericUpDownBlue.Value)
			{
				this.scrollBarBlue.Value = (int)this.numericUpDownBlue.Value;
			}
		}

		// Token: 0x060000AA RID: 170 RVA: 0x0000ABB8 File Offset: 0x00008DB8
		private void comboBoxColor_SelectedIndexChanged(object sender, EventArgs e)
		{
			switch (this.comboBoxColor.SelectedIndex)
			{
			case 0:
				this.scrollBarRed.Value = 10;
				this.scrollBarGreen.Value = 0;
				this.scrollBarBlue.Value = 0;
				return;
			case 1:
				this.scrollBarRed.Value = 0;
				this.scrollBarGreen.Value = 10;
				this.scrollBarBlue.Value = 0;
				return;
			case 2:
				this.scrollBarRed.Value = 0;
				this.scrollBarGreen.Value = 0;
				this.scrollBarBlue.Value = 10;
				return;
			case 3:
				this.scrollBarRed.Value = 10;
				this.scrollBarGreen.Value = 10;
				this.scrollBarBlue.Value = 0;
				return;
			case 4:
				this.scrollBarRed.Value = 10;
				this.scrollBarGreen.Value = 0;
				this.scrollBarBlue.Value = 10;
				return;
			case 5:
				this.scrollBarRed.Value = 0;
				this.scrollBarGreen.Value = 10;
				this.scrollBarBlue.Value = 10;
				return;
			case 6:
				this.scrollBarRed.Value = 10;
				this.scrollBarGreen.Value = 10;
				this.scrollBarBlue.Value = 10;
				return;
			default:
				return;
			}
		}

		// Token: 0x060000AB RID: 171 RVA: 0x0000AD04 File Offset: 0x00008F04
		private void radioButtonLightOn_CheckedChanged(object sender, EventArgs e)
		{
			this.groupBoxFade.Enabled = false;
			this._previewLock = true;
			this.pictureBoxButtonPreview.Image = Resources.popup_btn_023;
			Color color = Color.FromArgb((int)((double)this.scrollBarRed.Value * 25.5), (int)((double)this.scrollBarGreen.Value * 25.5), (int)((double)this.scrollBarBlue.Value * 25.5));
			this.setColor(color);
			this._preview = false;
			this.numericUpDownTime.Enabled = false;
		}

		// Token: 0x060000AC RID: 172 RVA: 0x0000AD9C File Offset: 0x00008F9C
		private void radioButtonLightOff_CheckedChanged(object sender, EventArgs e)
		{
			this.groupBoxFade.Enabled = false;
			this._previewLock = true;
			this.pictureBoxButtonPreview.Image = Resources.popup_btn_023;
			this.setColor(Color.Black);
			this._preview = false;
			this.numericUpDownTime.Enabled = false;
		}

		// Token: 0x060000AD RID: 173 RVA: 0x0000ADEC File Offset: 0x00008FEC
		private void radioButtonLightOnTime_CheckedChanged(object sender, EventArgs e)
		{
			if (!this._tutorial)
			{
				this.groupBoxFade.Enabled = true;
				this.pictureBoxButtonPreview.Image = Resources.popup_btn_020;
			}
			this._previewLock = false;
			Color color = Color.FromArgb((int)((double)this.scrollBarRed.Value * 25.5), (int)((double)this.scrollBarGreen.Value * 25.5), (int)((double)this.scrollBarBlue.Value * 25.5));
			this.setColor(color);
			this._preview = false;
			this.numericUpDownTime.Enabled = true;
		}

		// Token: 0x060000AE RID: 174 RVA: 0x0000AE8C File Offset: 0x0000908C
		private void radioButtonFadeNone_CheckedChanged(object sender, EventArgs e)
		{
			Color color = Color.FromArgb((int)((double)this.scrollBarRed.Value * 25.5), (int)((double)this.scrollBarGreen.Value * 25.5), (int)((double)this.scrollBarBlue.Value * 25.5));
			if (!this.radioButtonLightOff.Checked)
			{
				this.pictureBoxPreview.BackColor = color;
			}
			this._preview = false;
		}

		// Token: 0x060000AF RID: 175 RVA: 0x0000AF04 File Offset: 0x00009104
		private void radioButtonFadeIn_CheckedChanged(object sender, EventArgs e)
		{
			Color color = Color.FromArgb((int)((double)this.scrollBarRed.Value * 25.5), (int)((double)this.scrollBarGreen.Value * 25.5), (int)((double)this.scrollBarBlue.Value * 25.5));
			if (!this.radioButtonLightOff.Checked)
			{
				this.pictureBoxPreview.BackColor = color;
			}
			this._preview = false;
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x0000AF7C File Offset: 0x0000917C
		private void radioButtonFadeOut_CheckedChanged(object sender, EventArgs e)
		{
			Color color = Color.FromArgb((int)((double)this.scrollBarRed.Value * 25.5), (int)((double)this.scrollBarGreen.Value * 25.5), (int)((double)this.scrollBarBlue.Value * 25.5));
			if (!this.radioButtonLightOff.Checked)
			{
				this.pictureBoxPreview.BackColor = color;
			}
			this._preview = false;
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x000024F1 File Offset: 0x000006F1
		private void BlockPropertyLEDDialog_FormClosed(object sender, FormClosedEventArgs e)
		{
			base.Dispose();
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x0000AFF4 File Offset: 0x000091F4
		private void BlockPropertyLEDDialog_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (this._tutorial && !this._block.Updated)
			{
				e.Cancel = true;
			}
		}

		// Token: 0x0400009F RID: 159
		private ProgramModule.BlockLED _block;

		// Token: 0x040000A0 RID: 160
		private int _costMax;

		// Token: 0x040000A1 RID: 161
		private bool _preview;

		// Token: 0x040000A2 RID: 162
		private bool _previewLock;

		// Token: 0x040000A3 RID: 163
		private bool _tutorial;
	}
}
