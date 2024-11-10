using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clock.Properties;

namespace Clock
{
	// Token: 0x02000013 RID: 19
	public partial class BlockPropertyOutputDialog : Form
	{
		// Token: 0x06000149 RID: 329 RVA: 0x00015978 File Offset: 0x00013B78
		public BlockPropertyOutputDialog(ProgramModule.BlockOutput block)
		{
			this.InitializeComponent();
			this.splitContainer1.Panel1MinSize = 10;
			this.splitContainer1.SplitterDistance = 10;
			this._block = block;
			for (int i = 0; i < 2; i++)
			{
				this._tabs[i] = new BlockPropertyOutputTab(this, i);
				this._tabs[i].Location = new Point(this._tabs[i].Width * i, 0);
				this.splitContainer2.Panel1.Controls.Add(this._tabs[i]);
				this._controls[i] = new List<Control>();
			}
			this._controls[0].Add(this.label1);
			this._controls[0].Add(this.label2);
			this._controls[0].Add(this.label3);
			this._controls[0].Add(this.scrollBarRed);
			this._controls[0].Add(this.scrollBarGreen);
			this._controls[0].Add(this.scrollBarBlue);
			this._controls[0].Add(this.numericUpDownRed);
			this._controls[0].Add(this.numericUpDownGreen);
			this._controls[0].Add(this.numericUpDownBlue);
			this._controls[0].Add(this.groupBoxLight);
			this._controls[0].Add(this.pictureBoxPreview);
			this._controls[0].Add(this.comboBoxColor);
			this._controls[1].Add(this.comboBoxSound);
			foreach (string text in BlockPropertyOutputDialog.SOUND_ITEMS)
			{
				this.comboBoxSound.Items.Add(text);
			}
			ProgramModule.BlockOutput.OUTPUT_TYPE outputType = block.OutputType;
			if (outputType != ProgramModule.BlockOutput.OUTPUT_TYPE.LED)
			{
				if (outputType == ProgramModule.BlockOutput.OUTPUT_TYPE.SOUND)
				{
					this.changeOutputTab(BlockPropertyOutputTab.TAB.SOUND);
				}
			}
			else
			{
				this.changeOutputTab(BlockPropertyOutputTab.TAB.LED);
			}
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
			switch (this._block.SoundMode)
			{
			case ProgramModule.BlockSound.MODE.BEEP:
				this.comboBoxSound.SelectedIndex = this._block.BeepIndex;
				return;
			case ProgramModule.BlockSound.MODE.MELODY_PLAY:
				if (this._block.Loop)
				{
					this.comboBoxSound.SelectedIndex = 3;
					return;
				}
				break;
			case ProgramModule.BlockSound.MODE.MELODY_STOP:
				this.comboBoxSound.SelectedIndex = 4;
				break;
			default:
				return;
			}
		}

		// Token: 0x0600014A RID: 330 RVA: 0x00015CDC File Offset: 0x00013EDC
		public void changeOutputTab(BlockPropertyOutputTab.TAB index)
		{
			if (this._tabIndex != index)
			{
				this._tabIndex = index;
				for (int i = 0; i < 2; i++)
				{
					this._tabs[i].setSelected(false);
					foreach (Control control in this._controls[i])
					{
						control.Visible = false;
					}
				}
				this._tabs[(int)index].setSelected(true);
				foreach (Control control2 in this._controls[(int)index])
				{
					control2.Visible = true;
				}
			}
		}

		// Token: 0x0600014B RID: 331 RVA: 0x00015DAC File Offset: 0x00013FAC
		private void setBlockData(ProgramModule.BlockOutput block)
		{
			BlockPropertyOutputTab.TAB tabIndex = this._tabIndex;
			if (tabIndex != BlockPropertyOutputTab.TAB.LED)
			{
				if (tabIndex == BlockPropertyOutputTab.TAB.SOUND)
				{
					block.OutputType = ProgramModule.BlockOutput.OUTPUT_TYPE.SOUND;
				}
			}
			else
			{
				block.OutputType = ProgramModule.BlockOutput.OUTPUT_TYPE.LED;
			}
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
			}
			else if (this.radioButtonFadeIn.Checked)
			{
				block.Fade = ProgramModule.BlockLED.FADE.IN;
			}
			else if (this.radioButtonFadeOut.Checked)
			{
				block.Fade = ProgramModule.BlockLED.FADE.OUT;
			}
			switch (this.comboBoxSound.SelectedIndex)
			{
			case 0:
			case 1:
			case 2:
				block.SoundMode = ProgramModule.BlockSound.MODE.BEEP;
				block.BeepIndex = this.comboBoxSound.SelectedIndex;
				return;
			case 3:
				block.SoundMode = ProgramModule.BlockSound.MODE.MELODY_PLAY;
				block.Loop = true;
				return;
			case 4:
				block.SoundMode = ProgramModule.BlockSound.MODE.MELODY_STOP;
				return;
			default:
				return;
			}
		}

		// Token: 0x0600014C RID: 332 RVA: 0x00015FAC File Offset: 0x000141AC
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

		// Token: 0x0600014D RID: 333 RVA: 0x000024F1 File Offset: 0x000006F1
		private void BlockPropertyOutputDialog_FormClosed(object sender, FormClosedEventArgs e)
		{
			base.Dispose();
		}

		// Token: 0x0600014E RID: 334 RVA: 0x00015FFE File Offset: 0x000141FE
		private void pictureBoxButtonOK_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonOK.Image = Resources.popup_btn_002;
			}
		}

		// Token: 0x0600014F RID: 335 RVA: 0x0001601D File Offset: 0x0001421D
		private void pictureBoxButtonOK_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxButtonOK.Image = Resources.popup_btn_001;
		}

		// Token: 0x06000150 RID: 336 RVA: 0x0001602F File Offset: 0x0001422F
		private void pictureBoxButtonOK_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxButtonOK.Image = Resources.popup_btn_000;
		}

		// Token: 0x06000151 RID: 337 RVA: 0x00016041 File Offset: 0x00014241
		private void pictureBoxButtonOK_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonOK.Image = Resources.popup_btn_001;
				this.setBlockData(this._block);
				base.Close();
			}
		}

		// Token: 0x06000152 RID: 338 RVA: 0x00016072 File Offset: 0x00014272
		private void pictureBoxButtonCancel_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonCancel.Image = Resources.popup_btn_012;
			}
		}

		// Token: 0x06000153 RID: 339 RVA: 0x00016091 File Offset: 0x00014291
		private void pictureBoxButtonCancel_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxButtonCancel.Image = Resources.popup_btn_011;
		}

		// Token: 0x06000154 RID: 340 RVA: 0x000160A3 File Offset: 0x000142A3
		private void pictureBoxButtonCancel_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxButtonCancel.Image = Resources.popup_btn_010;
		}

		// Token: 0x06000155 RID: 341 RVA: 0x000160B5 File Offset: 0x000142B5
		private void pictureBoxButtonCancel_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonCancel.Image = Resources.popup_btn_011;
				base.Close();
			}
		}

		// Token: 0x06000156 RID: 342 RVA: 0x000160DA File Offset: 0x000142DA
		private void pictureBoxButtonPreview_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left && !this._preview && !this._previewLock)
			{
				this.pictureBoxButtonPreview.Image = Resources.popup_btn_022;
			}
		}

		// Token: 0x06000157 RID: 343 RVA: 0x00016109 File Offset: 0x00014309
		private void pictureBoxButtonPreview_MouseEnter(object sender, EventArgs e)
		{
			if (!this._previewLock)
			{
				this.pictureBoxButtonPreview.Image = Resources.popup_btn_021;
			}
		}

		// Token: 0x06000158 RID: 344 RVA: 0x00016123 File Offset: 0x00014323
		private void pictureBoxButtonPreview_MouseLeave(object sender, EventArgs e)
		{
			if (!this._previewLock)
			{
				this.pictureBoxButtonPreview.Image = Resources.popup_btn_020;
			}
		}

		// Token: 0x06000159 RID: 345 RVA: 0x00016140 File Offset: 0x00014340
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

		// Token: 0x0600015A RID: 346 RVA: 0x00016180 File Offset: 0x00014380
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

		// Token: 0x0600015B RID: 347 RVA: 0x00016230 File Offset: 0x00014430
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

		// Token: 0x0600015C RID: 348 RVA: 0x000162E0 File Offset: 0x000144E0
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

		// Token: 0x0600015D RID: 349 RVA: 0x00016390 File Offset: 0x00014590
		private void numericUpDownRed_ValueChanged(object sender, EventArgs e)
		{
			if (this.scrollBarRed.Value != this.numericUpDownRed.Value)
			{
				this.scrollBarRed.Value = (int)this.numericUpDownRed.Value;
			}
		}

		// Token: 0x0600015E RID: 350 RVA: 0x000163CF File Offset: 0x000145CF
		private void numericUpDownGreen_ValueChanged(object sender, EventArgs e)
		{
			if (this.scrollBarGreen.Value != this.numericUpDownGreen.Value)
			{
				this.scrollBarGreen.Value = (int)this.numericUpDownGreen.Value;
			}
		}

		// Token: 0x0600015F RID: 351 RVA: 0x0001640E File Offset: 0x0001460E
		private void numericUpDownBlue_ValueChanged(object sender, EventArgs e)
		{
			if (this.scrollBarBlue.Value != this.numericUpDownBlue.Value)
			{
				this.scrollBarBlue.Value = (int)this.numericUpDownBlue.Value;
			}
		}

		// Token: 0x06000160 RID: 352 RVA: 0x00016450 File Offset: 0x00014650
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

		// Token: 0x06000161 RID: 353 RVA: 0x0001659C File Offset: 0x0001479C
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

		// Token: 0x06000162 RID: 354 RVA: 0x00016634 File Offset: 0x00014834
		private void radioButtonLightOff_CheckedChanged(object sender, EventArgs e)
		{
			this.groupBoxFade.Enabled = false;
			this._previewLock = true;
			this.pictureBoxButtonPreview.Image = Resources.popup_btn_023;
			this.setColor(Color.Black);
			this._preview = false;
			this.numericUpDownTime.Enabled = false;
		}

		// Token: 0x06000163 RID: 355 RVA: 0x00016684 File Offset: 0x00014884
		private void radioButtonLightOnTime_CheckedChanged(object sender, EventArgs e)
		{
			this.groupBoxFade.Enabled = true;
			this.pictureBoxButtonPreview.Image = Resources.popup_btn_020;
			this._previewLock = false;
			Color color = Color.FromArgb((int)((double)this.scrollBarRed.Value * 25.5), (int)((double)this.scrollBarGreen.Value * 25.5), (int)((double)this.scrollBarBlue.Value * 25.5));
			this.setColor(color);
			this._preview = false;
			this.numericUpDownTime.Enabled = true;
		}

		// Token: 0x06000164 RID: 356 RVA: 0x0001671C File Offset: 0x0001491C
		private void radioButtonFadeNone_CheckedChanged(object sender, EventArgs e)
		{
			Color color = Color.FromArgb((int)((double)this.scrollBarRed.Value * 25.5), (int)((double)this.scrollBarGreen.Value * 25.5), (int)((double)this.scrollBarBlue.Value * 25.5));
			if (!this.radioButtonLightOff.Checked)
			{
				this.pictureBoxPreview.BackColor = color;
			}
			this._preview = false;
		}

		// Token: 0x06000165 RID: 357 RVA: 0x00016794 File Offset: 0x00014994
		private void radioButtonFadeIn_CheckedChanged(object sender, EventArgs e)
		{
			Color color = Color.FromArgb((int)((double)this.scrollBarRed.Value * 25.5), (int)((double)this.scrollBarGreen.Value * 25.5), (int)((double)this.scrollBarBlue.Value * 25.5));
			if (!this.radioButtonLightOff.Checked)
			{
				this.pictureBoxPreview.BackColor = color;
			}
			this._preview = false;
		}

		// Token: 0x06000166 RID: 358 RVA: 0x0001680C File Offset: 0x00014A0C
		private void radioButtonFadeOut_CheckedChanged(object sender, EventArgs e)
		{
			Color color = Color.FromArgb((int)((double)this.scrollBarRed.Value * 25.5), (int)((double)this.scrollBarGreen.Value * 25.5), (int)((double)this.scrollBarBlue.Value * 25.5));
			if (!this.radioButtonLightOff.Checked)
			{
				this.pictureBoxPreview.BackColor = color;
			}
			this._preview = false;
		}

		// Token: 0x04000196 RID: 406
		public static readonly string[] SOUND_ITEMS = new string[] { "サウンド①", "サウンド②", "サウンド③", "メロディ連続", "メロディ停止" };

		// Token: 0x04000197 RID: 407
		private ProgramModule.BlockOutput _block;

		// Token: 0x04000198 RID: 408
		private bool _preview;

		// Token: 0x04000199 RID: 409
		private bool _previewLock;

		// Token: 0x0400019A RID: 410
		private BlockPropertyOutputTab[] _tabs = new BlockPropertyOutputTab[2];

		// Token: 0x0400019B RID: 411
		private BlockPropertyOutputTab.TAB _tabIndex = BlockPropertyOutputTab.TAB.INVALID;

		// Token: 0x0400019C RID: 412
		private List<Control>[] _controls = new List<Control>[2];

		// Token: 0x0200006A RID: 106
		public enum SOUND
		{
			// Token: 0x04000717 RID: 1815
			BEEP_0,
			// Token: 0x04000718 RID: 1816
			BEEP_1,
			// Token: 0x04000719 RID: 1817
			BEEP_2,
			// Token: 0x0400071A RID: 1818
			MELODY_PLAY_LOOP,
			// Token: 0x0400071B RID: 1819
			MELODY_STOP,
			// Token: 0x0400071C RID: 1820
			MAX
		}
	}
}
