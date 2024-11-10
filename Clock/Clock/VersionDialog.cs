using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Clock.Properties;

namespace Clock
{
	// Token: 0x0200005A RID: 90
	public partial class VersionDialog : Form
	{
		// Token: 0x0600099B RID: 2459 RVA: 0x0006C30C File Offset: 0x0006A50C
		public VersionDialog()
		{
			this.InitializeComponent();
			this.splitContainer1.Panel1MinSize = 10;
			this.splitContainer1.SplitterDistance = 10;
			this.labelText.Text = "Ver. " + VersionDialog.Version + "\r\n©2016 Topman Co., Ltd.\r\nAll rights reserved.";
		}

		// Token: 0x0600099C RID: 2460 RVA: 0x000024F1 File Offset: 0x000006F1
		private void VersionDialog_FormClosed(object sender, FormClosedEventArgs e)
		{
			base.Dispose();
		}

		// Token: 0x040006D6 RID: 1750
		public static readonly string MajorVersion = "4";

		// Token: 0x040006D7 RID: 1751
		private static readonly string MinorVersion = "0";

		// Token: 0x040006D8 RID: 1752
		public static readonly string Version = VersionDialog.MajorVersion + "." + VersionDialog.MinorVersion;
	}
}
