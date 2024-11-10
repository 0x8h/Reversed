using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Clock.Properties;

namespace Clock
{
	// Token: 0x02000046 RID: 70
	public class NetworkSimulatorArea : Panel
	{
		// Token: 0x060006E7 RID: 1767 RVA: 0x00050DC4 File Offset: 0x0004EFC4
		public NetworkSimulatorArea(NetworkWindow window, Size size)
		{
			this.InitializeComponent();
			this._window = window;
			base.Size = size;
			this.BackColor = Color.FromArgb(247, 246, 229);
			this._pictureBoxButtonPlay.Image = Resources.sim_btn_050;
			this._pictureBoxButtonPlay.Size = this._pictureBoxButtonPlay.Image.Size;
			this._pictureBoxButtonPlay.MouseDown += this.pictureBoxButtonPlay_MouseDown;
			this._pictureBoxButtonPlay.MouseEnter += this.pictureBoxButtonPlay_MouseEnter;
			this._pictureBoxButtonPlay.MouseLeave += this.pictureBoxButtonPlay_MouseLeave;
			this._pictureBoxButtonPlay.MouseUp += this.pictureBoxButtonPlay_MouseUp;
			base.Controls.Add(this._pictureBoxButtonPlay);
			this._pictureBoxButtonStop.Image = Resources.sim_btn_060;
			this._pictureBoxButtonStop.Size = this._pictureBoxButtonStop.Image.Size;
			this._pictureBoxButtonStop.MouseDown += this.pictureBoxButtonStop_MouseDown;
			this._pictureBoxButtonStop.MouseEnter += this.pictureBoxButtonStop_MouseEnter;
			this._pictureBoxButtonStop.MouseLeave += this.pictureBoxButtonStop_MouseLeave;
			this._pictureBoxButtonStop.MouseUp += this.pictureBoxButtonStop_MouseUp;
			base.Controls.Add(this._pictureBoxButtonStop);
			Color color = Color.FromArgb(97, 54, 26);
			for (int i = 0; i < 5; i++)
			{
				this._labels[i] = new Label();
				this._labels[i].ForeColor = color;
				this._labels[i].Font = this._font;
				this._labels[i].Text = NetworkSimulatorArea.labelTexts[i];
				this._labels[i].AutoSize = true;
				base.Controls.Add(this._labels[i]);
			}
			this._labels[4].ForeColor = Color.Blue;
			this._labels[4].Font = this._fontExecute;
			for (int j = 0; j < 3; j++)
			{
				this._labelDetails[j] = new Label();
				this._labelDetails[j].ForeColor = color;
				this._labelDetails[j].Font = this._fontDetail;
				this._labelDetails[j].AutoSize = true;
				base.Controls.Add(this._labelDetails[j]);
			}
			this._textBoxLog.Size = new Size(base.Width - 50, 100);
			this._textBoxLog.Multiline = true;
			this._textBoxLog.ScrollBars = ScrollBars.Vertical;
			this._textBoxLog.HideSelection = false;
			this._textBoxLog.ReadOnly = true;
			base.Controls.Add(this._textBoxLog);
			this._timer = new Timer();
			this._timer.Tick += this.OnUpdateLabel;
			this._timer.Interval = NetworkSimulatorArea.UPDATE_LABEL_TIME;
			this._timer.Start();
			base.Disposed += delegate(object sender, EventArgs args)
			{
				this._timer.Stop();
			};
			if (NetworkWindow.Instance.isTutorial())
			{
				this._pictureBoxButtonStop.Enabled = false;
			}
		}

		// Token: 0x060006E8 RID: 1768 RVA: 0x00051198 File Offset: 0x0004F398
		public void addObjects(SplitContainer splitContainer)
		{
			NetworkSimulator.Instance.initialize(this._window.Programs);
			this._objects = splitContainer;
			base.Controls.Add(splitContainer);
			this._objects.Location = new Point((base.Width - this._objects.Width) / 2, (base.Height - this._objects.Height) / 6);
			this._pictureBoxButtonPlay.Location = new Point(this._objects.Location.X + this._objects.Width + 30, this._objects.Location.Y + this._objects.Height - this._pictureBoxButtonPlay.Height - this._pictureBoxButtonStop.Height + 10);
			this._pictureBoxButtonStop.Location = new Point(this._pictureBoxButtonPlay.Location.X, this._objects.Location.Y + this._objects.Height - this._pictureBoxButtonStop.Height + 15);
			this.updateHardwareLabel();
			this.updateServerVariableLabel();
			this.updateClientVariableLabel();
			this.updateLogLabel();
			this._labels[4].Location = new Point(this._objects.Location.X - this._labels[4].Width - 30, this._objects.Location.Y);
			this._labels[0].Location = new Point(this._objects.Location.X - this._labels[0].Width - 30, this._labels[4].Location.Y + this._labels[4].Height);
			this._labelDetails[0].Location = new Point(this._labels[0].Location.X, this._labels[0].Location.Y + this._labels[0].Height);
			this._labels[1].Location = new Point(this._objects.Location.X + this._objects.Width, this._objects.Location.Y);
			this._labelDetails[1].Location = new Point(this._labels[1].Location.X, this._labels[1].Location.Y + this._labels[1].Height);
			this._labels[2].Location = new Point(this._objects.Location.X + this._objects.Width, this._objects.Location.Y + 170);
			this._labelDetails[2].Location = new Point(this._labels[2].Location.X, this._labels[2].Location.Y + this._labels[2].Height);
			this._labels[3].Location = new Point(10, this._objects.Location.Y + this._objects.Height);
			this._textBoxLog.Location = new Point(this._labels[3].Location.X, this._labels[3].Location.Y + this._labels[3].Height);
			if (!this._window.InformationViewFlag)
			{
				this._labels[0].Visible = false;
				this._labels[1].Visible = false;
				this._labels[2].Visible = false;
				this._labels[3].Visible = false;
				this._labelDetails[0].Visible = false;
				this._labelDetails[1].Visible = false;
				this._labelDetails[2].Visible = false;
				this._textBoxLog.Visible = false;
			}
		}

		// Token: 0x060006E9 RID: 1769 RVA: 0x000515E0 File Offset: 0x0004F7E0
		public SplitContainer removeObjects()
		{
			this._objects.Location = new Point(3, 3);
			SplitContainer objects = this._objects;
			this._objects = null;
			base.Controls.Remove(objects);
			return objects;
		}

		// Token: 0x060006EA RID: 1770 RVA: 0x0005161C File Offset: 0x0004F81C
		public void run()
		{
			NetworkSimulator.Instance.initialize(this._window.Programs);
			NetworkWindow.Instance.SimulatorWindow.SimulatorArea.Invoke(new MethodInvoker(delegate
			{
				NetworkWindow.Instance.SimulatorWindow.SimulatorArea.updateServerVariableLabel();
				NetworkWindow.Instance.SimulatorWindow.SimulatorArea.updateClientVariableLabel();
			}));
			NetworkSimulator.Instance.run();
		}

		// Token: 0x060006EB RID: 1771 RVA: 0x0005167C File Offset: 0x0004F87C
		private void OnUpdateLabel(object sender, EventArgs e)
		{
			if (this._labelFlags[4])
			{
				this.updateExecuteLabel();
				this._labelFlags[4] = false;
			}
			if (this._labelFlags[0])
			{
				this.updateHardwareLabel();
				this._labelFlags[0] = false;
			}
			if (this._labelFlags[1])
			{
				this.updateServerVariableLabel();
				this._labelFlags[1] = false;
			}
			if (this._labelFlags[2])
			{
				this.updateClientVariableLabel();
				this._labelFlags[2] = false;
			}
			if (this._labelFlags[3])
			{
				this.updateLogLabel();
				this._labelFlags[3] = false;
			}
		}

		// Token: 0x060006EC RID: 1772 RVA: 0x00051706 File Offset: 0x0004F906
		public void updateLabel(NetworkSimulatorArea.LABEL label)
		{
			this._labelFlags[(int)label] = true;
		}

		// Token: 0x060006ED RID: 1773 RVA: 0x00051714 File Offset: 0x0004F914
		private void updateExecuteLabel()
		{
			this._labels[4].Visible = NetworkSimulator.Instance.State == NetworkSimulator.STATE.RUN;
			if (NetworkSimulator.Instance.State == NetworkSimulator.STATE.RUN)
			{
				this._pictureBoxButtonPlay.Image = Resources.sim_btn_053;
				this._pictureBoxButtonStop.Image = Resources.sim_btn_060;
				return;
			}
			this._pictureBoxButtonPlay.Image = Resources.sim_btn_050;
			this._pictureBoxButtonStop.Image = Resources.sim_btn_063;
		}

		// Token: 0x060006EE RID: 1774 RVA: 0x0005178C File Offset: 0x0004F98C
		private void updateHardwareLabel()
		{
			string text = string.Format("ボタン：{0}\n音センサ：{1}\n明るさ：{2}{3})\n温度：{4}", new object[]
			{
				NetworkSimulator.Instance.HardwareInfo.IsButtonOn ? "ON" : "OFF",
				NetworkSimulator.Instance.HardwareInfo.IsSoundOn ? "ON" : "OFF",
				NetworkSimulator.Instance.HardwareInfo.IsBright ? "明るい(" : "暗い(",
				NetworkSimulator.Instance.HardwareInfo.LightValue,
				NetworkSimulator.Instance.HardwareInfo.Temperature
			});
			if (this._window.IsUsbInOutEnable)
			{
				text = text + "\n外部入力：" + (NetworkSimulator.Instance.HardwareInfo.IsUsbInOn ? "あり" : "なし");
			}
			this._labelDetails[0].Text = text;
		}

		// Token: 0x060006EF RID: 1775 RVA: 0x0005187C File Offset: 0x0004FA7C
		private void updateServerVariableLabel()
		{
			this._labelDetails[1].Text = "";
			for (int i = 0; i < this._window.Programs.ServerVariableNames.Count; i++)
			{
				Label label = this._labelDetails[1];
				label.Text = string.Concat(new string[]
				{
					label.Text,
					this._window.Programs.ServerVariableNames[i],
					"：",
					NetworkSimulator.Instance.ServerVariables[i].Value,
					"\n"
				});
			}
		}

		// Token: 0x060006F0 RID: 1776 RVA: 0x00051920 File Offset: 0x0004FB20
		private void updateClientVariableLabel()
		{
			this._labelDetails[2].Text = "入力：" + NetworkSimulator.Instance.InputVariable + "\n";
			for (int i = 0; i < this._window.Programs.ClientVariableNames.Count; i++)
			{
				Label label = this._labelDetails[2];
				label.Text = string.Concat(new string[]
				{
					label.Text,
					this._window.Programs.ClientVariableNames[i],
					"：",
					NetworkSimulator.Instance.ClientVariables[i].Value,
					"\n"
				});
			}
		}

		// Token: 0x060006F1 RID: 1777 RVA: 0x000519D7 File Offset: 0x0004FBD7
		private void updateLogLabel()
		{
			this._textBoxLog.Clear();
			this._textBoxLog.AppendText(NetworkLog.Instance.getLog());
		}

		// Token: 0x060006F2 RID: 1778 RVA: 0x000519F9 File Offset: 0x0004FBF9
		private void pictureBoxButtonStop_MouseDown(object sender, MouseEventArgs e)
		{
			if (NetworkSimulator.Instance.State == NetworkSimulator.STATE.RUN && e.Button == MouseButtons.Left)
			{
				this._pictureBoxButtonStop.Image = Resources.sim_btn_062;
			}
		}

		// Token: 0x060006F3 RID: 1779 RVA: 0x00051A25 File Offset: 0x0004FC25
		private void pictureBoxButtonStop_MouseEnter(object sender, EventArgs e)
		{
			if (NetworkSimulator.Instance.State == NetworkSimulator.STATE.RUN)
			{
				this._pictureBoxButtonStop.Image = Resources.sim_btn_061;
			}
		}

		// Token: 0x060006F4 RID: 1780 RVA: 0x00051A44 File Offset: 0x0004FC44
		private void pictureBoxButtonStop_MouseLeave(object sender, EventArgs e)
		{
			if (NetworkSimulator.Instance.State == NetworkSimulator.STATE.RUN)
			{
				this._pictureBoxButtonStop.Image = Resources.sim_btn_060;
			}
		}

		// Token: 0x060006F5 RID: 1781 RVA: 0x00051A63 File Offset: 0x0004FC63
		private void pictureBoxButtonStop_MouseUp(object sender, MouseEventArgs e)
		{
			if (NetworkSimulator.Instance.State == NetworkSimulator.STATE.RUN && e.Button == MouseButtons.Left)
			{
				this._pictureBoxButtonStop.Image = Resources.sim_btn_061;
				NetworkSimulator.Instance.stop(NetworkSimulator.ERROR.NONE);
			}
		}

		// Token: 0x060006F6 RID: 1782 RVA: 0x00051A9A File Offset: 0x0004FC9A
		private void pictureBoxButtonPlay_MouseDown(object sender, MouseEventArgs e)
		{
			if (NetworkSimulator.Instance.State == NetworkSimulator.STATE.STOP && e.Button == MouseButtons.Left)
			{
				this._pictureBoxButtonPlay.Image = Resources.sim_btn_052;
			}
		}

		// Token: 0x060006F7 RID: 1783 RVA: 0x00051AC5 File Offset: 0x0004FCC5
		private void pictureBoxButtonPlay_MouseEnter(object sender, EventArgs e)
		{
			if (NetworkSimulator.Instance.State == NetworkSimulator.STATE.STOP)
			{
				this._pictureBoxButtonPlay.Image = Resources.sim_btn_051;
			}
		}

		// Token: 0x060006F8 RID: 1784 RVA: 0x00051AE3 File Offset: 0x0004FCE3
		private void pictureBoxButtonPlay_MouseLeave(object sender, EventArgs e)
		{
			if (NetworkSimulator.Instance.State == NetworkSimulator.STATE.STOP)
			{
				this._pictureBoxButtonPlay.Image = Resources.sim_btn_050;
			}
		}

		// Token: 0x060006F9 RID: 1785 RVA: 0x00051B01 File Offset: 0x0004FD01
		private void pictureBoxButtonPlay_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left && NetworkSimulator.Instance.State == NetworkSimulator.STATE.STOP)
			{
				this._pictureBoxButtonPlay.Image = Resources.sim_btn_051;
				this.run();
			}
		}

		// Token: 0x060006FA RID: 1786 RVA: 0x00051B32 File Offset: 0x0004FD32
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060006FB RID: 1787 RVA: 0x00051B51 File Offset: 0x0004FD51
		private void InitializeComponent()
		{
			this.components = new Container();
		}

		// Token: 0x04000520 RID: 1312
		public static readonly int UPDATE_LABEL_TIME = 33;

		// Token: 0x04000521 RID: 1313
		private NetworkWindow _window;

		// Token: 0x04000522 RID: 1314
		private SplitContainer _objects;

		// Token: 0x04000523 RID: 1315
		private PictureBox _pictureBoxButtonStop = new PictureBox();

		// Token: 0x04000524 RID: 1316
		private PictureBox _pictureBoxButtonPlay = new PictureBox();

		// Token: 0x04000525 RID: 1317
		private static readonly string[] labelTexts = new string[] { "コロックル", "サーバ", "クライアント", "ログ", "実行中" };

		// Token: 0x04000526 RID: 1318
		private Label[] _labels = new Label[5];

		// Token: 0x04000527 RID: 1319
		private Label[] _labelDetails = new Label[3];

		// Token: 0x04000528 RID: 1320
		private bool[] _labelFlags = new bool[5];

		// Token: 0x04000529 RID: 1321
		private TextBox _textBoxLog = new TextBox();

		// Token: 0x0400052A RID: 1322
		private Timer _timer = new Timer();

		// Token: 0x0400052B RID: 1323
		private Font _font = new Font("メイリオ", 12f, FontStyle.Regular, GraphicsUnit.Point, 128);

		// Token: 0x0400052C RID: 1324
		private Font _fontDetail = new Font("メイリオ", 9f, FontStyle.Regular, GraphicsUnit.Point, 128);

		// Token: 0x0400052D RID: 1325
		private Font _fontExecute = new Font("メイリオ", 20f, FontStyle.Regular, GraphicsUnit.Point, 128);

		// Token: 0x0400052E RID: 1326
		private IContainer components;

		// Token: 0x020000C0 RID: 192
		public enum LABEL
		{
			// Token: 0x04000910 RID: 2320
			HARDWARE,
			// Token: 0x04000911 RID: 2321
			SERVER_VARIABLE,
			// Token: 0x04000912 RID: 2322
			CLIENT_VARIABLE,
			// Token: 0x04000913 RID: 2323
			DETAIL_MAX,
			// Token: 0x04000914 RID: 2324
			LOG = 3,
			// Token: 0x04000915 RID: 2325
			EXECUTE,
			// Token: 0x04000916 RID: 2326
			MAX
		}
	}
}
