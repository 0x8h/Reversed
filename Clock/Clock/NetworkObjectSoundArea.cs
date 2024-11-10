using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Clock
{
	// Token: 0x02000041 RID: 65
	public class NetworkObjectSoundArea : PictureBox
	{
		// Token: 0x0600068D RID: 1677 RVA: 0x0004EA16 File Offset: 0x0004CC16
		public NetworkObjectSoundArea()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600068E RID: 1678 RVA: 0x0004EA24 File Offset: 0x0004CC24
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600068F RID: 1679 RVA: 0x0004EA43 File Offset: 0x0004CC43
		private void InitializeComponent()
		{
			this.components = new Container();
		}

		// Token: 0x040004F4 RID: 1268
		private IContainer components;
	}
}
