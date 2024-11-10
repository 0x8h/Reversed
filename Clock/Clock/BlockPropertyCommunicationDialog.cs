using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Clock.Properties;

namespace Clock
{
	// Token: 0x02000004 RID: 4
	public partial class BlockPropertyCommunicationDialog : Form
	{
		// Token: 0x0600001A RID: 26 RVA: 0x00003220 File Offset: 0x00001420
		public BlockPropertyCommunicationDialog(ProgramModule.BlockCommunication block, NetworkProgramModules programs)
		{
			this.InitializeComponent();
			this.splitContainer1.Panel1MinSize = 10;
			this.splitContainer1.SplitterDistance = 10;
			this._block = block;
			this._programs = programs;
			if (block.Mode == ProgramModule.BlockCommunication.COMMUNICATION_MODE.SEND)
			{
				this.radioButtonSend.Checked = true;
				this.comboBoxSource.SelectedIndex = BlockPropertyCommunicationDialog.getComboBoxIndex(block.VariableType, block.VariableIndexSource, this._programs);
			}
			else
			{
				this.radioButtonReceive.Checked = true;
				this.comboBoxSource.SelectedIndex = block.VariableIndexSource;
			}
			this.comboBoxDestination.SelectedIndex = block.VariableIndexDistination;
		}

		// Token: 0x0600001B RID: 27 RVA: 0x000032C8 File Offset: 0x000014C8
		private void setBlockData(ProgramModule.BlockCommunication block)
		{
			if (this.radioButtonSend.Checked)
			{
				block.Mode = ProgramModule.BlockCommunication.COMMUNICATION_MODE.SEND;
				block.VariableType = BlockPropertyCommunicationDialog.getVariableType(this.comboBoxSource.SelectedIndex, this._programs);
				block.VariableIndexSource = BlockPropertyCommunicationDialog.getVariableIndex(this.comboBoxSource.SelectedIndex, this._programs);
			}
			else
			{
				block.Mode = ProgramModule.BlockCommunication.COMMUNICATION_MODE.RECEIVE;
				block.VariableIndexSource = this.comboBoxSource.SelectedIndex;
			}
			block.VariableIndexDistination = this.comboBoxDestination.SelectedIndex;
		}

		// Token: 0x0600001C RID: 28 RVA: 0x0000334C File Offset: 0x0000154C
		public static int getComboBoxIndex(ProgramModule.BlockCommunication.VARIABLE_TYPE type, int variableIndex, NetworkProgramModules programs)
		{
			int num = 0;
			switch (type)
			{
			case ProgramModule.BlockCommunication.VARIABLE_TYPE.INPUT:
				num = 0;
				break;
			case ProgramModule.BlockCommunication.VARIABLE_TYPE.CLIENT:
				num = variableIndex + 1;
				break;
			case ProgramModule.BlockCommunication.VARIABLE_TYPE.LIGHT:
				num = 1 + programs.ClientVariableNames.Count;
				break;
			case ProgramModule.BlockCommunication.VARIABLE_TYPE.TEMPERATURE:
				num = 1 + programs.ClientVariableNames.Count + 1;
				break;
			case ProgramModule.BlockCommunication.VARIABLE_TYPE.HARDWARE:
				num = 1 + programs.ClientVariableNames.Count + 2 + variableIndex;
				break;
			}
			return num;
		}

		// Token: 0x0600001D RID: 29 RVA: 0x000033B6 File Offset: 0x000015B6
		public static ProgramModule.BlockCommunication.VARIABLE_TYPE getVariableType(int comboBoxIndex, NetworkProgramModules programs)
		{
			if (comboBoxIndex == 0)
			{
				return ProgramModule.BlockCommunication.VARIABLE_TYPE.INPUT;
			}
			if (comboBoxIndex < 1 + programs.ClientVariableNames.Count)
			{
				return ProgramModule.BlockCommunication.VARIABLE_TYPE.CLIENT;
			}
			if (comboBoxIndex == 1 + programs.ClientVariableNames.Count)
			{
				return ProgramModule.BlockCommunication.VARIABLE_TYPE.LIGHT;
			}
			if (comboBoxIndex == 1 + programs.ClientVariableNames.Count + 1)
			{
				return ProgramModule.BlockCommunication.VARIABLE_TYPE.TEMPERATURE;
			}
			return ProgramModule.BlockCommunication.VARIABLE_TYPE.HARDWARE;
		}

		// Token: 0x0600001E RID: 30 RVA: 0x000033F6 File Offset: 0x000015F6
		public static int getVariableIndex(int comboBoxIndex, NetworkProgramModules programs)
		{
			if (0 < comboBoxIndex && comboBoxIndex < 1 + programs.ClientVariableNames.Count)
			{
				return comboBoxIndex - 1;
			}
			if (1 + programs.ClientVariableNames.Count + 1 < comboBoxIndex)
			{
				return comboBoxIndex - (1 + programs.ClientVariableNames.Count + 2);
			}
			return 0;
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00003438 File Offset: 0x00001638
		private void radioButtonSend_CheckedChanged(object sender, EventArgs e)
		{
			this.labelDestination.Text = "サーバの";
			this.labelSource.Text = "";
			this.labelCommunication.Text = "を送信する";
			this.comboBoxDestination.Items.Clear();
			for (int i = 0; i < this._programs.ServerVariableNames.Count<string>(); i++)
			{
				this.comboBoxDestination.Items.Add("(S)" + this._programs.ServerVariableNames[i]);
			}
			this.comboBoxSource.Items.Clear();
			this.comboBoxSource.Items.Add("入力変数");
			for (int j = 0; j < this._programs.ClientVariableNames.Count<string>(); j++)
			{
				this.comboBoxSource.Items.Add("(C)" + this._programs.ClientVariableNames[j]);
			}
			if (this._programs.Level != NetworkProgramModules.LEVEL.LEVEL_1)
			{
				this.comboBoxSource.Items.Add("光センサ値");
				this.comboBoxSource.Items.Add("温度");
			}
			this.comboBoxDestination.SelectedIndex = 0;
			this.comboBoxSource.SelectedIndex = 0;
		}

		// Token: 0x06000020 RID: 32 RVA: 0x0000358C File Offset: 0x0000178C
		private void radioButtonReceive_CheckedChanged(object sender, EventArgs e)
		{
			this.labelDestination.Text = "クライアントの";
			this.labelSource.Text = "サーバの";
			this.labelCommunication.Text = "を受信する";
			this.comboBoxDestination.Items.Clear();
			for (int i = 0; i < this._programs.ClientVariableNames.Count<string>(); i++)
			{
				this.comboBoxDestination.Items.Add("(C)" + this._programs.ClientVariableNames[i]);
			}
			this.comboBoxSource.Items.Clear();
			for (int j = 0; j < this._programs.ServerVariableNames.Count<string>(); j++)
			{
				this.comboBoxSource.Items.Add("(S)" + this._programs.ServerVariableNames[j]);
			}
			this.comboBoxDestination.SelectedIndex = 0;
			this.comboBoxSource.SelectedIndex = 0;
		}

		// Token: 0x06000021 RID: 33 RVA: 0x000024F1 File Offset: 0x000006F1
		private void BlockPropertyCommunicationDialog_FormClosed(object sender, FormClosedEventArgs e)
		{
			base.Dispose();
		}

		// Token: 0x06000022 RID: 34 RVA: 0x0000368F File Offset: 0x0000188F
		private void pictureBoxButtonOK_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonOK.Image = Resources.popup_btn_002;
			}
		}

		// Token: 0x06000023 RID: 35 RVA: 0x000036AE File Offset: 0x000018AE
		private void pictureBoxButtonOK_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxButtonOK.Image = Resources.popup_btn_001;
		}

		// Token: 0x06000024 RID: 36 RVA: 0x000036C0 File Offset: 0x000018C0
		private void pictureBoxButtonOK_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxButtonOK.Image = Resources.popup_btn_000;
		}

		// Token: 0x06000025 RID: 37 RVA: 0x000036D2 File Offset: 0x000018D2
		private void pictureBoxButtonOK_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonOK.Image = Resources.popup_btn_001;
				this.setBlockData(this._block);
				base.Close();
			}
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00003703 File Offset: 0x00001903
		private void pictureBoxButtonCancel_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonCancel.Image = Resources.popup_btn_012;
			}
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00003722 File Offset: 0x00001922
		private void pictureBoxButtonCancel_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxButtonCancel.Image = Resources.popup_btn_011;
		}

		// Token: 0x06000028 RID: 40 RVA: 0x00003734 File Offset: 0x00001934
		private void pictureBoxButtonCancel_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxButtonCancel.Image = Resources.popup_btn_010;
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00003746 File Offset: 0x00001946
		private void pictureBoxButtonCancel_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonCancel.Image = Resources.popup_btn_011;
				base.Close();
			}
		}

		// Token: 0x04000014 RID: 20
		private ProgramModule.BlockCommunication _block;

		// Token: 0x04000015 RID: 21
		private NetworkProgramModules _programs;
	}
}
