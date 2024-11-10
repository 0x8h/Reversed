using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Clock.Properties;

namespace Clock
{
	// Token: 0x0200002A RID: 42
	public partial class InformationWindow : Form
	{
		// Token: 0x0600047A RID: 1146 RVA: 0x00038198 File Offset: 0x00036398
		public InformationWindow(FlowchartWindow flowchartwindow)
		{
			this.InitializeComponent();
			this._flowchartwindow = flowchartwindow;
			this.splitContainer1.Panel1MinSize = 10;
			this.splitContainer1.SplitterDistance = 10;
			this.dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
			this.dataGridView1.Columns[1].ReadOnly = false;
			for (int i = 0; i < this._labels.GetLength(0); i++)
			{
				this.dataGridView1.Rows.Add(new object[]
				{
					this._labels[i],
					"0"
				});
			}
		}

		// Token: 0x0600047B RID: 1147 RVA: 0x0003829C File Offset: 0x0003649C
		public void updateView()
		{
			if (this._flowchartwindow.SimulatorWindow != null)
			{
				this.dataGridView1.Rows.Clear();
				string[] array = new string[]
				{
					this._flowchartwindow.SimulatorWindow.Simulator.Counter.ToString(),
					this._flowchartwindow.SimulatorWindow.Simulator.Variables[0].ToString(),
					this._flowchartwindow.SimulatorWindow.Simulator.Variables[1].ToString(),
					this._flowchartwindow.SimulatorWindow.Simulator.Variables[2].ToString(),
					this._flowchartwindow.SimulatorWindow.Simulator.Variables[3].ToString(),
					this._flowchartwindow.SimulatorWindow.Simulator.Variables[4].ToString(),
					this._flowchartwindow.SimulatorWindow.Simulator.Variables[5].ToString(),
					this._flowchartwindow.SimulatorWindow.Simulator.Variables[6].ToString(),
					this._flowchartwindow.SimulatorWindow.Simulator.Variables[7].ToString()
				};
				for (int i = 0; i < this._labels.GetLength(0); i++)
				{
					this.dataGridView1.Rows.Add(new object[]
					{
						this._labels[i],
						array[i]
					});
				}
			}
		}

		// Token: 0x0600047C RID: 1148 RVA: 0x00038448 File Offset: 0x00036648
		private void InformationWindow_FormClosed(object sender, FormClosedEventArgs e)
		{
			base.Dispose();
			if (this._flowchartwindow != null)
			{
				this._flowchartwindow.InformationWindow = null;
			}
		}

		// Token: 0x0600047D RID: 1149 RVA: 0x00038464 File Offset: 0x00036664
		private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			if (this._flowchartwindow.SimulatorWindow != null && this._flowchartwindow.SimulatorWindow.Simulator.Variables != null)
			{
				if (e.RowIndex == 0)
				{
					this._flowchartwindow.SimulatorWindow.Simulator.Counter = int.Parse((string)this.dataGridView1.Rows[e.RowIndex].Cells[1].Value);
					return;
				}
				this._flowchartwindow.SimulatorWindow.Simulator.Variables[e.RowIndex - 1] = int.Parse((string)this.dataGridView1.Rows[e.RowIndex].Cells[1].Value);
			}
		}

		// Token: 0x0600047E RID: 1150 RVA: 0x00038537 File Offset: 0x00036737
		private void buttonReset_Click(object sender, EventArgs e)
		{
			if (this._flowchartwindow.SimulatorWindow != null)
			{
				this._flowchartwindow.SimulatorWindow.Simulator.resetVariables();
				this.updateView();
			}
		}

		// Token: 0x04000394 RID: 916
		private FlowchartWindow _flowchartwindow;

		// Token: 0x04000395 RID: 917
		private string[] _labels = new string[] { "秒カウンタ", "変数a", "変数b", "変数c", "変数d", "変数e", "変数f", "変数g", "変数h" };
	}
}
