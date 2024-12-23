using System;
using System.Threading;
using System.Windows.Forms;

// Token: 0x02000026 RID: 38
public class GClass5
{
	// Token: 0x060000B6 RID: 182 RVA: 0x00004998 File Offset: 0x00002B98
	public void method_0()
	{
		int width = Screen.PrimaryScreen.Bounds.Width;
		int height = Screen.PrimaryScreen.Bounds.Height;
		int left = Screen.PrimaryScreen.Bounds.Left;
		int right = Screen.PrimaryScreen.Bounds.Right;
		int top = Screen.PrimaryScreen.Bounds.Top;
		int bottom = Screen.PrimaryScreen.Bounds.Bottom;
		byte[] array = new byte[(width * height + width) * 4];
		Random random;
		while (GClass4.int_0 > 270)
		{
			random = new Random();
			IntPtr dc = GClass2.GetDC(IntPtr.Zero);
			IntPtr intPtr = GClass2.CreateCompatibleDC(dc);
			IntPtr intPtr2 = GClass2.CreateCompatibleBitmap(dc, width, height);
			IntPtr intPtr3 = GClass2.SelectObject(intPtr, intPtr2);
			GClass2.BitBlt(intPtr, 0, 0, width, height, dc, 0, 0, GClass2.GEnum3.SRCCOPY);
			GClass2.GdiAlphaBlend(dc, random.Next(-2, 3), random.Next(-2, 3), width, height, intPtr, 0, 0, width, height, new GClass2.GStruct5(0, 0, 70, 0));
			GClass2.SelectObject(intPtr, intPtr3);
			GClass2.DeleteObject(intPtr3);
			GClass2.DeleteObject(intPtr2);
			GClass2.DeleteDC(intPtr);
			Thread.Sleep(100);
		}
		Thread thread = new Thread(new ThreadStart(this.method_1));
		Thread thread2 = new Thread(new ThreadStart(this.method_2));
		thread.Start();
		thread2.Start();
		GClass5.bool_1 = true;
		random = new Random();
		Thread.Sleep(300);
		GClass2.InvalidateRect(IntPtr.Zero, IntPtr.Zero, true);
		while (GClass4.int_0 > 240)
		{
			this.bool_0 = true;
			random = new Random();
			IntPtr dc2 = GClass2.GetDC(IntPtr.Zero);
			IntPtr intPtr4 = GClass2.CreateCompatibleDC(dc2);
			IntPtr intPtr5 = GClass2.CreateBitmap(width, height, 1U, 32U, array);
			GClass2.SelectObject(intPtr4, intPtr5);
			GClass2.BitBlt(intPtr4, 0, 0, width, height, dc2, 0, 0, GClass2.GEnum3.SRCCOPY);
			GClass2.GetBitmapBits(intPtr5, width * height * 4, array);
			for (int i = 0; i < array.Length; i++)
			{
				byte[] array2 = array;
				int num = i;
				byte b = array2[num];
				byte[] array3 = array;
				int num2 = 1;
				byte b2 = array3[num2];
				byte[] array4 = array;
				int num3 = width;
				array2[num] = b + (array3[num2] = b2 + (array4[num3] += 1));
			}
			GClass2.SetBitmapBits(intPtr5, width * height * 4, array);
			GClass2.BitBlt(dc2, 0, 0, width, height, intPtr4, 0, 0, GClass2.GEnum3.SRCCOPY);
			GClass2.DeleteObject(intPtr5);
			GClass2.DeleteObject(intPtr4);
			GClass2.DeleteObject(dc2);
			GClass2.DeleteDC(dc2);
			Thread.Sleep(10);
			if (random.Next(10) == 1)
			{
				GClass2.InvalidateRect(IntPtr.Zero, IntPtr.Zero, true);
			}
		}
		this.bool_0 = false;
		Thread.Sleep(100);
		GClass2.InvalidateRect(IntPtr.Zero, IntPtr.Zero, true);
		while (GClass4.int_0 > 210)
		{
			random = new Random();
			IntPtr dc3 = GClass2.GetDC(IntPtr.Zero);
			byte[] array5 = new byte[] { byte.MaxValue, byte.MaxValue, 195, 195, 195, 195, byte.MaxValue, byte.MaxValue };
			IntPtr intPtr6 = GClass2.CreateBitmap(random.Next(20), random.Next(20), 1U, 1U, array5);
			IntPtr intPtr7 = GClass2.CreatePatternBrush(intPtr6);
			GClass2.SetBkColor(dc3, (uint)random.Next(1073741824));
			GClass2.SelectObject(dc3, intPtr7);
			GClass2.PatBlt(dc3, 0, 0, width, height, GClass2.GEnum3.PATINVERT);
			GClass2.DeleteObject(intPtr6);
			GClass2.DeleteObject(intPtr7);
			GClass2.DeleteDC(dc3);
			if (random.Next(15) == 1)
			{
				GClass2.InvalidateRect(IntPtr.Zero, IntPtr.Zero, true);
			}
			Thread.Sleep(10);
		}
		Thread.Sleep(300);
		GClass2.InvalidateRect(IntPtr.Zero, IntPtr.Zero, true);
		while (GClass4.int_0 > 180)
		{
			this.bool_0 = true;
			random = new Random();
			IntPtr dc4 = GClass2.GetDC(IntPtr.Zero);
			IntPtr intPtr8 = GClass2.CreateCompatibleDC(dc4);
			IntPtr intPtr9 = GClass2.CreateBitmap(width, height, 1U, 32U, array);
			GClass2.SelectObject(intPtr8, intPtr9);
			GClass2.BitBlt(intPtr8, 0, 0, width, height, dc4, 0, 0, GClass2.GEnum3.SRCCOPY);
			GClass2.GetBitmapBits(intPtr9, width * height * 4, array);
			for (int j = 0; j < array.Length; j++)
			{
				byte[] array6 = array;
				int num4 = j;
				array6[num4] += 30;
			}
			GClass2.SetBitmapBits(intPtr9, width * height * 4, array);
			GClass2.BitBlt(dc4, 0, 0, width, height, intPtr8, 0, 0, GClass2.GEnum3.SRCCOPY);
			GClass2.DeleteObject(intPtr9);
			GClass2.DeleteObject(intPtr8);
			GClass2.DeleteObject(dc4);
			GClass2.DeleteDC(dc4);
			Thread.Sleep(10);
			if (random.Next(10) == 1)
			{
				GClass2.InvalidateRect(IntPtr.Zero, IntPtr.Zero, true);
			}
		}
		this.bool_0 = false;
		Thread.Sleep(100);
		GClass2.InvalidateRect(IntPtr.Zero, IntPtr.Zero, true);
		while (GClass4.int_0 > 150)
		{
			IntPtr dc5 = GClass2.GetDC(IntPtr.Zero);
			IntPtr intPtr10 = GClass2.CreateCompatibleDC(dc5);
			IntPtr intPtr11 = GClass2.CreateCompatibleBitmap(dc5, width, height);
			IntPtr intPtr12 = GClass2.SelectObject(intPtr10, intPtr11);
			GClass2.StretchBlt(intPtr10, -50, -50, width + 100, height + 100, dc5, 0, 0, width, height, GClass2.GEnum3.SRCCOPY);
			GClass2.GdiAlphaBlend(dc5, 0, 0, width, height, intPtr10, 0, 0, width, height, new GClass2.GStruct5(0, 0, 50, 0));
			GClass2.SelectObject(intPtr10, intPtr11);
			GClass2.DeleteObject(intPtr12);
			GClass2.DeleteObject(intPtr11);
			GClass2.DeleteDC(intPtr10);
			GClass2.DeleteDC(dc5);
			Thread.Sleep(5);
		}
		Thread.Sleep(100);
		GClass2.InvalidateRect(IntPtr.Zero, IntPtr.Zero, true);
		while (GClass4.int_0 > 120)
		{
			IntPtr dc6 = GClass2.GetDC(IntPtr.Zero);
			GClass2.BitBlt(dc6, -50, 0, width, height, dc6, 0, 0, GClass2.GEnum3.SRCCOPY);
			GClass2.BitBlt(dc6, width - 50, 0, width, height, dc6, 0, 0, GClass2.GEnum3.SRCCOPY);
			GClass2.DeleteDC(dc6);
			Thread.Sleep(5);
		}
		Thread.Sleep(100);
		GClass2.InvalidateRect(IntPtr.Zero, IntPtr.Zero, true);
		while (GClass4.int_0 > 90)
		{
			this.bool_0 = true;
			random = new Random();
			IntPtr dc7 = GClass2.GetDC(IntPtr.Zero);
			IntPtr intPtr13 = GClass2.CreateCompatibleDC(dc7);
			IntPtr intPtr14 = GClass2.CreateBitmap(width, height, 1U, 32U, array);
			GClass2.SelectObject(intPtr13, intPtr14);
			GClass2.BitBlt(intPtr13, 0, 0, width, height, dc7, 0, 0, GClass2.GEnum3.SRCCOPY);
			GClass2.GetBitmapBits(intPtr14, width * height * 4, array);
			for (int k = 0; k < array.Length; k++)
			{
				byte[] array7 = array;
				int num5 = k;
				byte b3 = array7[num5];
				byte[] array8 = array;
				int num6 = k;
				byte b4 = array8[num6];
				byte[] array9 = array;
				int num7 = k;
				array7[num5] = b3 + (array8[num6] = b4 + (array9[num7] += byte.MaxValue));
			}
			GClass2.SetBitmapBits(intPtr14, width * height * 4, array);
			GClass2.BitBlt(dc7, 0, 0, width, height, intPtr13, 0, 0, GClass2.GEnum3.SRCCOPY);
			GClass2.DeleteObject(intPtr14);
			GClass2.DeleteObject(intPtr13);
			GClass2.DeleteObject(dc7);
			GClass2.DeleteDC(dc7);
			Thread.Sleep(10);
			if (random.Next(10) == 1)
			{
				GClass2.InvalidateRect(IntPtr.Zero, IntPtr.Zero, true);
			}
		}
		this.bool_0 = false;
		Thread.Sleep(100);
		GClass2.InvalidateRect(IntPtr.Zero, IntPtr.Zero, true);
		Thread.Sleep(100);
		GClass2.InvalidateRect(IntPtr.Zero, IntPtr.Zero, true);
		GClass2.GStruct4[] array10 = new GClass2.GStruct4[3];
		while (GClass4.int_0 > 60)
		{
			IntPtr dc8 = GClass2.GetDC(IntPtr.Zero);
			if (random.Next(2) != 1)
			{
				array10[0].int_0 = left - 100;
				array10[0].int_1 = top + 100;
				array10[1].int_0 = right - 100;
				array10[1].int_1 = top - 100;
				array10[2].int_0 = left + 100;
				array10[2].int_1 = bottom + 100;
			}
			else
			{
				array10[0].int_0 = left + 100;
				array10[0].int_1 = top - 100;
				array10[1].int_0 = right + 100;
				array10[1].int_1 = top + 100;
				array10[2].int_0 = left - 100;
				array10[2].int_1 = bottom - 100;
			}
			GClass2.PlgBlt(dc8, array10, dc8, left - 25, top - 25, right - left + 50, bottom - top + 50, IntPtr.Zero, 0, 0);
			GClass2.DeleteDC(dc8);
			Thread.Sleep(10);
		}
		Thread.Sleep(100);
		GClass2.InvalidateRect(IntPtr.Zero, IntPtr.Zero, true);
		for (;;)
		{
			IntPtr dc9 = GClass2.GetDC(IntPtr.Zero);
			GClass2.StretchBlt(dc9, random.Next(50), random.Next(50), width - random.Next(100), height - random.Next(100), dc9, 0, 0, width, height, GClass2.GEnum3.SRCCOPY);
			GClass2.DeleteDC(dc9);
			Thread.Sleep(2);
		}
	}

	// Token: 0x060000B7 RID: 183 RVA: 0x000052AC File Offset: 0x000034AC
	public void method_1()
	{
		for (;;)
		{
			if (!this.bool_0)
			{
				int num = Screen.PrimaryScreen.Bounds.Width;
				int num2 = Screen.PrimaryScreen.Bounds.Height;
				Random random = new Random();
				int num3 = random.Next(10);
				if (num3 != 9)
				{
					if (num3 != 8)
					{
						if (num3 != 7)
						{
							if (num3 != 6)
							{
								if (num3 != 5)
								{
									if (num3 == 4)
									{
										for (int i = 0; i < random.Next(3, 10); i++)
										{
											IntPtr dc = GClass2.GetDC(IntPtr.Zero);
											IntPtr intPtr = GClass2.CreateSolidBrush((uint)random.Next(1073741824));
											GClass2.SetBkColor(dc, (uint)random.Next(1073741824));
											GClass2.SelectObject(dc, intPtr);
											GClass2.PatBlt(dc, random.Next(-300, num), random.Next(-300, num2), random.Next(-300, num), random.Next(-300, num2), GClass2.GEnum3.PATINVERT);
											GClass2.DeleteObject(intPtr);
											GClass2.DeleteDC(dc);
											Thread.Sleep(10);
										}
									}
									else if (num3 == 3)
									{
										for (int j = 0; j < random.Next(3, 10); j++)
										{
											IntPtr dc2 = GClass2.GetDC(IntPtr.Zero);
											GClass2.BitBlt(dc2, random.Next(-300, num), random.Next(-300, num2), random.Next(-300, num), random.Next(-300, num2), dc2, 0, 0, GClass2.GEnum3.SRCINVERT);
											GClass2.DeleteDC(dc2);
											Thread.Sleep(10);
										}
									}
									else if (num3 != 2)
									{
										if (num3 == 1)
										{
											GClass2.GStruct7[] array = new GClass2.GStruct7[3];
											for (int k = 0; k < random.Next(10, 30); k++)
											{
												array[0].int_0 = num;
												array[0].int_1 = num2;
												array[0].ushort_0 = Convert.ToUInt16((random.Next(2) == 1) ? 65535 : 4369);
												array[0].ushort_1 = Convert.ToUInt16((random.Next(2) == 1) ? 65535 : 4369);
												array[0].ushort_2 = Convert.ToUInt16((random.Next(2) == 1) ? 65535 : 4369);
												array[0].ushort_3 = 0;
												array[1].int_0 = 0;
												array[1].int_1 = 0;
												array[1].ushort_0 = Convert.ToUInt16((random.Next(2) == 1) ? 39321 : 4369);
												array[1].ushort_1 = Convert.ToUInt16((random.Next(2) == 1) ? 39321 : 4369);
												array[1].ushort_2 = Convert.ToUInt16((random.Next(2) == 1) ? 39321 : 4369);
												array[1].ushort_3 = 0;
												GClass2.GStruct6[] array2 = new GClass2.GStruct6[1];
												array2[0].uint_0 = 0U;
												array2[0].uint_1 = 1U;
												IntPtr dc3 = GClass2.GetDC(IntPtr.Zero);
												IntPtr intPtr2 = GClass2.CreateCompatibleDC(dc3);
												IntPtr intPtr3 = GClass2.CreateCompatibleBitmap(dc3, num, num2);
												IntPtr intPtr4 = GClass2.SelectObject(intPtr2, intPtr3);
												GClass2.GdiGradientFill(intPtr2, array, 2U, array2, 1U, (random.Next(2) == 1) ? GClass2.GEnum4.RECT_H : GClass2.GEnum4.RECT_V);
												GClass2.GdiAlphaBlend(dc3, 0, 0, num, num2, intPtr2, 0, 0, num, num2, new GClass2.GStruct5(0, 0, 50, 0));
												GClass2.SelectObject(intPtr2, intPtr3);
												GClass2.DeleteObject(intPtr4);
												GClass2.DeleteObject(intPtr3);
												GClass2.DeleteDC(intPtr2);
												GClass2.DeleteDC(dc3);
												Thread.Sleep(1);
											}
										}
										else if (num3 == 0)
										{
											for (int l = 0; l < random.Next(50, 100); l++)
											{
												IntPtr dc4 = GClass2.GetDC(IntPtr.Zero);
												int num4 = random.Next(num);
												int num5 = random.Next(num2);
												IntPtr intPtr5 = GClass2.CreateEllipticRgn(num4 - 150, num5 - 150, num4, num5);
												GClass2.SelectClipRgn(dc4, intPtr5);
												GClass2.DeleteObject(intPtr5);
												GClass2.PatBlt(dc4, num4 - 150, num5 - 150, num4, num5, GClass2.GEnum3.PATINVERT);
												GClass2.DeleteDC(dc4);
												Thread.Sleep(1);
											}
										}
									}
									else
									{
										for (int m = 0; m < random.Next(3, 10); m++)
										{
											IntPtr dc5 = GClass2.GetDC(IntPtr.Zero);
											GClass2.BitBlt(dc5, random.Next(-500, 500), 0, 0, 0, dc5, 0, 0, GClass2.GEnum3.SRCPAINT);
											GClass2.DeleteDC(dc5);
											Thread.Sleep(10);
										}
									}
								}
								else
								{
									for (int n = 0; n < random.Next(3, 10); n++)
									{
										IntPtr dc6 = GClass2.GetDC(IntPtr.Zero);
										IntPtr intPtr6 = GClass2.CreateSolidBrush((uint)random.Next(1073741824));
										GClass2.SelectObject(dc6, intPtr6);
										GClass2.PatBlt(dc6, random.Next(-300, num), random.Next(-300, num2), random.Next(-300, num), random.Next(-300, num2), GClass2.GEnum3.PATINVERT);
										GClass2.DeleteObject(intPtr6);
										GClass2.DeleteDC(dc6);
										Thread.Sleep(10);
									}
								}
							}
							else
							{
								for (int num6 = 0; num6 < random.Next(3, 10); num6++)
								{
									IntPtr dc7 = GClass2.GetDC(IntPtr.Zero);
									GClass2.PatBlt(dc7, random.Next(-300, num), random.Next(-300, num2), random.Next(-300, num), random.Next(-300, num2), GClass2.GEnum3.PATINVERT);
									GClass2.DeleteDC(dc7);
									Thread.Sleep(10);
								}
							}
						}
						else
						{
							IntPtr dc8 = GClass2.GetDC(IntPtr.Zero);
							IntPtr intPtr7 = GClass2.CreateSolidBrush((uint)random.Next(1073741824));
							GClass2.SelectObject(dc8, intPtr7);
							GClass2.BitBlt(dc8, 0, 0, num, num2, dc8, 0, 0, GClass2.GEnum3.MERGECOPY);
							GClass2.DeleteObject(intPtr7);
							GClass2.DeleteDC(dc8);
						}
					}
					else
					{
						num = Screen.PrimaryScreen.Bounds.Width;
						num2 = Screen.PrimaryScreen.Bounds.Height;
						IntPtr dc9 = GClass2.GetDC(IntPtr.Zero);
						GClass2.StretchBlt(dc9, 0, num2, num, -num2, dc9, 0, 0, num, num2, GClass2.GEnum3.SRCCOPY);
						GClass2.DeleteDC(dc9);
					}
				}
				else
				{
					num = Screen.PrimaryScreen.Bounds.Width;
					num2 = Screen.PrimaryScreen.Bounds.Height;
					IntPtr dc10 = GClass2.GetDC(IntPtr.Zero);
					GClass2.StretchBlt(dc10, num, 0, -num, num2, dc10, 0, 0, num, num2, GClass2.GEnum3.SRCCOPY);
					GClass2.DeleteDC(dc10);
				}
				if (random.Next(10) == 1)
				{
					GClass2.InvalidateRect(IntPtr.Zero, IntPtr.Zero, true);
				}
			}
			Thread.Sleep(100);
		}
	}

	// Token: 0x060000B8 RID: 184 RVA: 0x000059A4 File Offset: 0x00003BA4
	public void method_2()
	{
		int width = Screen.PrimaryScreen.Bounds.Width;
		int height = Screen.PrimaryScreen.Bounds.Height;
		byte[] array = new byte[(width * height + width) * 4];
		for (;;)
		{
			if (!this.bool_0)
			{
				Random random = new Random();
				if (random.Next(5) == 1)
				{
					IntPtr dc = GClass2.GetDC(IntPtr.Zero);
					IntPtr intPtr = GClass2.CreateCompatibleDC(dc);
					IntPtr intPtr2 = GClass2.CreateBitmap(width, height, 1U, 32U, array);
					GClass2.SelectObject(intPtr, intPtr2);
					GClass2.BitBlt(intPtr, 0, 0, width, height, dc, 0, 0, GClass2.GEnum3.SRCCOPY);
					GClass2.GetBitmapBits(intPtr2, width * height * 4, array);
					int num = random.Next(3);
					for (int i = 0; i < array.Length; i++)
					{
						if (num == 2)
						{
							byte[] array2 = array;
							int num2 = i;
							array2[num2] += Convert.ToByte(random.Next(255));
						}
						else
						{
							byte[] array3 = array;
							int num3 = i;
							byte b = array3[num3];
							byte[] array4 = array;
							int num4 = i;
							byte b2 = array4[num4];
							byte[] array5 = array;
							int num5 = 1;
							array3[num3] = b + (array4[num4] = b2 + (array5[num5] += 1));
						}
					}
					GClass2.SetBitmapBits(intPtr2, width * height * 4, array);
					GClass2.GdiAlphaBlend(dc, 0, 0, width, height, intPtr, 0, 0, width, height, new GClass2.GStruct5(0, 0, Convert.ToByte(random.Next(100, 200)), 0));
					GClass2.DeleteObject(intPtr2);
					GClass2.DeleteObject(intPtr);
					GClass2.DeleteObject(dc);
					GClass2.DeleteDC(dc);
				}
				if (random.Next(15) == 1)
				{
					for (int j = 0; j < random.Next(1000, 5000); j++)
					{
						IntPtr dc2 = GClass2.GetDC(IntPtr.Zero);
						int num6 = random.Next(height);
						GClass2.BitBlt(dc2, random.Next(-25, 26), num6, width, random.Next(-25, 26), dc2, 0, num6, GClass2.GEnum3.SRCCOPY);
						GClass2.DeleteDC(dc2);
					}
				}
			}
			Thread.Sleep(200);
		}
	}

	// Token: 0x040000E1 RID: 225
	public bool bool_0;

	// Token: 0x040000E2 RID: 226
	public static bool bool_1;
}
