using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Clock.Properties;

namespace Clock
{
	// Token: 0x0200003B RID: 59
	public class NetworkObjectInput : Control, NetworkObjectInterface
	{
		// Token: 0x17000042 RID: 66
		// (get) Token: 0x06000651 RID: 1617 RVA: 0x0004D708 File Offset: 0x0004B908
		// (set) Token: 0x06000652 RID: 1618 RVA: 0x0004D710 File Offset: 0x0004B910
		public bool Selected { get; set; }

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x06000653 RID: 1619 RVA: 0x0004D719 File Offset: 0x0004B919
		// (set) Token: 0x06000654 RID: 1620 RVA: 0x0004D721 File Offset: 0x0004B921
		public bool IsOn { get; set; }

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x06000655 RID: 1621 RVA: 0x0004D72A File Offset: 0x0004B92A
		// (set) Token: 0x06000656 RID: 1622 RVA: 0x0004D732 File Offset: 0x0004B932
		public GUIDE Guide { get; set; }

		// Token: 0x06000657 RID: 1623 RVA: 0x0004D73C File Offset: 0x0004B93C
		public NetworkObjectInput(NetworkWindow window, Size size)
		{
			this.InitializeComponent();
			this.BackColor = Color.FromArgb(117, 179, 179);
			this._window = window;
			base.Location = new Point(1, 1);
			base.Size = new Size(size.Width - 2, size.Height - 2);
			SplitContainer splitContainer = new SplitContainer();
			splitContainer.Size = base.Size;
			splitContainer.Dock = DockStyle.Fill;
			splitContainer.SplitterDistance = splitContainer.Width - Resources.nw_input_00.Width;
			splitContainer.SplitterWidth = 1;
			splitContainer.IsSplitterFixed = true;
			this.PlaceHolder = new NetworkObjectInput.TextBoxPlaceHolder();
			this.PlaceHolder.Dock = DockStyle.Fill;
			this.PlaceHolder.Font = new Font("メイリオ", 12f, FontStyle.Regular, GraphicsUnit.Point, 128);
			this.PlaceHolder.ReadOnly = true;
			this.PlaceHolder.MaxLength = NetworkSimulator.NetworkVariable.VARIABLE_LENGTH_MAX;
			this.PlaceHolder.MouseDown += this.objectInput_MouseDown;
			this._enterButton = new PictureBox();
			this._enterButton.Image = Resources.nw_input_00;
			this._enterButton.MouseDown += this.objectInput_MouseDown;
			this._enterButton.MouseDown += this.enterButton_MouseDown;
			this._enterButton.MouseEnter += this.enterButton_MouseEnter;
			this._enterButton.MouseLeave += this.enterButton_MouseLeave;
			this._enterButton.MouseUp += this.enterButton_MouseUp;
			splitContainer.Panel1.Controls.Add(this.PlaceHolder);
			splitContainer.Panel2.Controls.Add(this._enterButton);
			base.Controls.Add(splitContainer);
		}

		// Token: 0x06000658 RID: 1624 RVA: 0x0004D90C File Offset: 0x0004BB0C
		public void setEnable(bool enable)
		{
			if (enable)
			{
				this.PlaceHolder.ReadOnly = false;
				return;
			}
			this._enterButton.Image = Resources.nw_input_00;
			this.PlaceHolder.Text = "";
			this.PlaceHolder.ReadOnly = true;
		}

		// Token: 0x06000659 RID: 1625 RVA: 0x0004D94A File Offset: 0x0004BB4A
		protected override void OnPaint(PaintEventArgs pe)
		{
			base.OnPaint(pe);
			if (this.Selected)
			{
				base.Parent.BackColor = Color.Red;
				return;
			}
			base.Parent.BackColor = Color.White;
		}

		// Token: 0x0600065A RID: 1626 RVA: 0x0004D97C File Offset: 0x0004BB7C
		private void objectInput_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left && this._window.SimulatorWindow == null && (!NetworkWindow.Instance.isTutorial() || NetworkWindow.Instance.Tutorial == NetworkWindow.TUTORIAL.SELECT_INPUT))
			{
				this._window.changeSelectedObject(this._window.Programs.ObjectInput);
				this._window.changeFlowchartTab(NetworkFlowchartTab.TAB.OBJECT, true);
			}
		}

		// Token: 0x0600065B RID: 1627 RVA: 0x0004D9E8 File Offset: 0x0004BBE8
		private void enterButton_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left && NetworkSimulator.Instance.State == NetworkSimulator.STATE.RUN)
			{
				this._enterButton.Image = Resources.nw_input_02;
				if (NetworkWindow.Instance.Tutorial == NetworkWindow.TUTORIAL.INPUT && this.PlaceHolder.Text == "")
				{
					return;
				}
				this.IsOn = true;
				NetworkSimulator.Instance.InputVariable = this.PlaceHolder.Text;
				this.PlaceHolder.Text = "";
				NetworkWindow.Instance.SimulatorWindow.SimulatorArea.updateLabel(NetworkSimulatorArea.LABEL.CLIENT_VARIABLE);
			}
		}

		// Token: 0x0600065C RID: 1628 RVA: 0x0004DA89 File Offset: 0x0004BC89
		private void enterButton_MouseEnter(object sender, EventArgs e)
		{
			if (NetworkSimulator.Instance.State == NetworkSimulator.STATE.RUN)
			{
				this._enterButton.Image = Resources.nw_input_01;
			}
		}

		// Token: 0x0600065D RID: 1629 RVA: 0x0004DAA8 File Offset: 0x0004BCA8
		private void enterButton_MouseLeave(object sender, EventArgs e)
		{
			if (NetworkSimulator.Instance.State == NetworkSimulator.STATE.RUN)
			{
				this._enterButton.Image = Resources.nw_input_00;
			}
		}

		// Token: 0x0600065E RID: 1630 RVA: 0x0004DAC7 File Offset: 0x0004BCC7
		private void enterButton_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				if (NetworkSimulator.Instance.State == NetworkSimulator.STATE.RUN)
				{
					this._enterButton.Image = Resources.nw_input_01;
				}
				this.IsOn = false;
			}
		}

		// Token: 0x0600065F RID: 1631 RVA: 0x0004DAFA File Offset: 0x0004BCFA
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000660 RID: 1632 RVA: 0x0004DB19 File Offset: 0x0004BD19
		private void InitializeComponent()
		{
			this.components = new Container();
		}

		// Token: 0x040004DC RID: 1244
		public NetworkObjectInput.TextBoxPlaceHolder PlaceHolder;

		// Token: 0x040004DD RID: 1245
		private PictureBox _enterButton;

		// Token: 0x040004DE RID: 1246
		private NetworkWindow _window;

		// Token: 0x040004DF RID: 1247
		private IContainer components;

		// Token: 0x020000AB RID: 171
		public class TextBoxPlaceHolder : TextBox
		{
			// Token: 0x170004BC RID: 1212
			// (get) Token: 0x0600107B RID: 4219 RVA: 0x000912FE File Offset: 0x0008F4FE
			// (set) Token: 0x0600107C RID: 4220 RVA: 0x00091306 File Offset: 0x0008F506
			public string PlaceHolder
			{
				get
				{
					return this._placeHolder;
				}
				set
				{
					this._placeHolder = value;
					base.Invalidate();
				}
			}

			// Token: 0x0600107D RID: 4221 RVA: 0x00091318 File Offset: 0x0008F518
			protected override void WndProc(ref Message message)
			{
				base.WndProc(ref message);
				if (message.Msg == 15 && string.IsNullOrEmpty(this.Text) && !string.IsNullOrEmpty(this._placeHolder))
				{
					using (Graphics graphics = Graphics.FromHwnd(base.Handle))
					{
						Rectangle clientRectangle = base.ClientRectangle;
						clientRectangle.Offset(1, 1);
						TextRenderer.DrawText(graphics, this._placeHolder, NetworkObjectInput.TextBoxPlaceHolder._font, clientRectangle, SystemColors.ControlDark, TextFormatFlags.Default);
					}
				}
			}

			// Token: 0x040008AF RID: 2223
			private string _placeHolder = "ここに文字を入力";

			// Token: 0x040008B0 RID: 2224
			private static Font _font = new Font("メイリオ", 12f, FontStyle.Regular, GraphicsUnit.Point, 128);
		}
	}
}
