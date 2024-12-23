using System;
using System.IO;
using System.Media;
using System.Text;
using System.Threading;

// Token: 0x0200000C RID: 12
public class GClass0
{
	// Token: 0x0600003B RID: 59 RVA: 0x000026B7 File Offset: 0x000008B7
	public byte[] method_0(string string_0)
	{
		return Encoding.ASCII.GetBytes(string_0);
	}

	// Token: 0x0600003C RID: 60 RVA: 0x00004560 File Offset: 0x00002760
	public void method_1()
	{
		Random random = new Random();
		int num = 8000;
		int num2 = 2400000;
		MemoryStream memoryStream = new MemoryStream();
		BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
		binaryWriter.Write(this.method_0("RIFF"));
		binaryWriter.Write(4800036);
		binaryWriter.Write(this.method_0("WAVE"));
		binaryWriter.Write(this.method_0("fmt"));
		binaryWriter.Write(32);
		binaryWriter.Write(16);
		binaryWriter.Write(1);
		binaryWriter.Write(1);
		binaryWriter.Write(8000);
		binaryWriter.Write(16000);
		binaryWriter.Write(2);
		binaryWriter.Write(16);
		binaryWriter.Write(this.method_0("data"));
		binaryWriter.Write(4800000);
		byte[] array = new byte[4];
		binaryWriter.Write(array);
		float[] array2 = new float[]
		{
			50f, 60f, 70f, 80f, 90f, 100f, 110f, 120f, 130f, 140f,
			150f, 160f, 170f, 180f, 190f, 200f, 210f, 220f, 230f, 240f,
			250f, 260f, 270f, 280f, 290f, 300f, 310f, 320f, 330f, 340f,
			350f
		};
		float num3 = array2[random.Next(array2.Length)];
		int num4 = 1000;
		for (int i = 0; i < num2; i++)
		{
			if (random.Next(num4) == 1)
			{
				if (num4 > 100)
				{
					num4 -= 2;
				}
				else if (num4 <= 100 && i <= 2000000)
				{
					if (random.Next(10) == 1)
					{
						num4 = 90;
					}
					else if (random.Next(10) == 1)
					{
						num4 = 85;
					}
					else if (random.Next(10) == 1)
					{
						num4 = 80;
					}
					else if (random.Next(10) == 1)
					{
						num4 = 75;
					}
					else if (random.Next(10) == 1)
					{
						num4 = 70;
					}
				}
				else if (i >= 2000000)
				{
					if (random.Next(10) != 1)
					{
						if (random.Next(10) == 1)
						{
							num4 = 40;
						}
						else if (random.Next(10) != 1)
						{
							if (random.Next(10) == 1)
							{
								num4 = 20;
							}
							else if (random.Next(10) == 1)
							{
								num4 = 15;
							}
						}
						else
						{
							num4 = 30;
						}
					}
					else
					{
						num4 = 50;
					}
				}
				num3 = array2[random.Next(array2.Length)];
			}
			binaryWriter.Write(Convert.ToInt16(32767 * Math.Sign(Math.Sin(6.2831853071795862 * (double)num3 / (double)num * (double)i))));
		}
		memoryStream.Position = 0L;
		new SoundPlayer(memoryStream).Play();
		Thread.Sleep(num2);
	}
}
