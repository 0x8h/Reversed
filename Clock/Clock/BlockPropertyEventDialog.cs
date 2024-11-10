using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Clock.Properties;

namespace Clock
{
	// Token: 0x02000008 RID: 8
	public partial class BlockPropertyEventDialog : Form
	{
		// Token: 0x06000060 RID: 96 RVA: 0x00006E94 File Offset: 0x00005094
		public BlockPropertyEventDialog(ProgramModule.BlockEvent block, NetworkProgramModules programs)
		{
			this.InitializeComponent();
			this.splitContainer1.Panel1MinSize = 10;
			this.splitContainer1.SplitterDistance = 10;
			this._block = block;
			switch (this._block.ObjectType)
			{
			case ProgramModule.BlockEvent.OBJECT_TYPE.LABEL:
			case ProgramModule.BlockEvent.OBJECT_TYPE.LIST:
			case ProgramModule.BlockEvent.OBJECT_TYPE.GRAPH:
			case ProgramModule.BlockEvent.OBJECT_TYPE.STAGE:
			{
				this.comboBoxTrigger.Items.Add(ProgramModule.BlockEvent.TRIGGER_ITEMS[0]);
				this.comboBoxTrigger.Items.Add(ProgramModule.BlockEvent.TRIGGER_ITEMS[1]);
				if (programs.Level != NetworkProgramModules.LEVEL.LEVEL_1)
				{
					this.comboBoxTrigger.Items.Add(ProgramModule.BlockEvent.TRIGGER_ITEMS[2]);
				}
				for (int i = 0; i < programs.MessageNames.Count; i++)
				{
					this.comboBoxTriggerMessage.Items.Add(programs.MessageNames[i]);
				}
				this.comboBoxTriggerMessage.SelectedIndex = this._block.MessageIndex;
				this.comboBoxTriggerHardware.Items.Add(ProgramModule.BlockEvent.TRIGGER_HARDWARE_ITEMS[0]);
				this.comboBoxTriggerHardware.Items.Add(ProgramModule.BlockEvent.TRIGGER_HARDWARE_ITEMS[1]);
				this.comboBoxTriggerHardware.Items.Add(ProgramModule.BlockEvent.TRIGGER_HARDWARE_ITEMS[2]);
				this.comboBoxTriggerHardware.Items.Add(ProgramModule.BlockEvent.TRIGGER_HARDWARE_ITEMS[3]);
				if (programs.Level != NetworkProgramModules.LEVEL.LEVEL_2 && NetworkWindow.Instance.IsUsbInOutEnable)
				{
					this.comboBoxTriggerHardware.Items.Add(ProgramModule.BlockEvent.TRIGGER_HARDWARE_ITEMS[4]);
				}
				this.comboBoxTriggerHardware.SelectedIndex = (int)this._block.TriggerHardware;
				break;
			}
			case ProgramModule.BlockEvent.OBJECT_TYPE.BUTTON:
				this.comboBoxTrigger.Items.Add("(自身が)クリックされたとき");
				break;
			case ProgramModule.BlockEvent.OBJECT_TYPE.INPUT:
				this.comboBoxTrigger.Items.Add("(入力が)確定したとき");
				break;
			}
			this.comboBoxTrigger.SelectedIndex = (int)this._block.Trigger;
		}

		// Token: 0x06000061 RID: 97 RVA: 0x00007080 File Offset: 0x00005280
		private void setBlockData(ProgramModule.BlockEvent block)
		{
			block.ObjectType = this._block.ObjectType;
			block.Trigger = (ProgramModule.BlockEvent.TRIGGER)this.comboBoxTrigger.SelectedIndex;
			block.MessageIndex = this.comboBoxTriggerMessage.SelectedIndex;
			block.TriggerHardware = (ProgramModule.BlockEvent.TRIGGER_HARDWARE)Math.Max(0, this.comboBoxTriggerHardware.SelectedIndex);
		}

		// Token: 0x06000062 RID: 98 RVA: 0x000070D7 File Offset: 0x000052D7
		private void comboBoxTrigger_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.comboBoxTriggerMessage.Visible = this.comboBoxTrigger.SelectedIndex == 1;
			this.comboBoxTriggerHardware.Visible = this.comboBoxTrigger.SelectedIndex == 2;
		}

		// Token: 0x06000063 RID: 99 RVA: 0x000024F1 File Offset: 0x000006F1
		private void BlockPropertyEventDialog_FormClosed(object sender, FormClosedEventArgs e)
		{
			base.Dispose();
		}

		// Token: 0x06000064 RID: 100 RVA: 0x0000710B File Offset: 0x0000530B
		private void pictureBoxButtonOK_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonOK.Image = Resources.popup_btn_002;
			}
		}

		// Token: 0x06000065 RID: 101 RVA: 0x0000712A File Offset: 0x0000532A
		private void pictureBoxButtonOK_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxButtonOK.Image = Resources.popup_btn_001;
		}

		// Token: 0x06000066 RID: 102 RVA: 0x0000713C File Offset: 0x0000533C
		private void pictureBoxButtonOK_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxButtonOK.Image = Resources.popup_btn_000;
		}

		// Token: 0x06000067 RID: 103 RVA: 0x0000714E File Offset: 0x0000534E
		private void pictureBoxButtonOK_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonOK.Image = Resources.popup_btn_001;
				this.setBlockData(this._block);
				base.Close();
			}
		}

		// Token: 0x06000068 RID: 104 RVA: 0x0000717F File Offset: 0x0000537F
		private void pictureBoxButtonCancel_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonCancel.Image = Resources.popup_btn_012;
			}
		}

		// Token: 0x06000069 RID: 105 RVA: 0x0000719E File Offset: 0x0000539E
		private void pictureBoxButtonCancel_MouseEnter(object sender, EventArgs e)
		{
			this.pictureBoxButtonCancel.Image = Resources.popup_btn_011;
		}

		// Token: 0x0600006A RID: 106 RVA: 0x000071B0 File Offset: 0x000053B0
		private void pictureBoxButtonCancel_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBoxButtonCancel.Image = Resources.popup_btn_010;
		}

		// Token: 0x0600006B RID: 107 RVA: 0x000071C2 File Offset: 0x000053C2
		private void pictureBoxButtonCancel_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.pictureBoxButtonCancel.Image = Resources.popup_btn_011;
				base.Close();
			}
		}

		// Token: 0x0400004F RID: 79
		private ProgramModule.BlockEvent _block;
	}
}
