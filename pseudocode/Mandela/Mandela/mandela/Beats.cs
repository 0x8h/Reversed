using System;
using System.IO;
using System.Media;
using System.Text;

namespace mandela
{
	// Token: 0x02000002 RID: 2
	public class Beats
	{
		// Token: 0x06000003 RID: 3 RVA: 0x000025AA File Offset: 0x000007AA
		public byte[] getBytes(string text)
		{
			return Encoding.ASCII.GetBytes(text);
		}

		// Token: 0x06000004 RID: 4 RVA: 0x00002D90 File Offset: 0x00000F90
		public void beat(int num_of_sound, int duration, int channels, int cnt)
		{
			Random random = new Random();
			short num = (short)channels;
			int num2 = 8000;
			int num3 = (int)(8000 * num * 2);
			int num4 = 8000 * duration;
			short num5 = num * 2;
			int num6 = num4 * (int)num * 2;
			int num7 = 28 + (8 + num6);
			MemoryStream memoryStream = new MemoryStream();
			BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
			binaryWriter.Write(this.getBytes("RIFF"));
			binaryWriter.Write(num7);
			binaryWriter.Write(this.getBytes("WAVE"));
			binaryWriter.Write(this.getBytes("fmt"));
			binaryWriter.Write(32);
			binaryWriter.Write(16);
			binaryWriter.Write(1);
			binaryWriter.Write(num);
			binaryWriter.Write(8000);
			binaryWriter.Write(num3);
			binaryWriter.Write(num5);
			binaryWriter.Write(16);
			binaryWriter.Write(this.getBytes("data"));
			binaryWriter.Write(num6);
			byte[] array = new byte[4];
			binaryWriter.Write(array);
			float[] array2 = new float[] { 10f, 20f, 30f, 40f, 50f, 60f };
			float[] array3 = new float[] { 500f, 600f, 700f, 800f, 900f, 1000f };
			float num8 = array2[random.Next(array2.Length)];
			float num9 = array2[random.Next(array2.Length)];
			float num10 = array3[random.Next(array3.Length)];
			for (int i = 0; i < num4; i++)
			{
				switch (num_of_sound)
				{
				case 0:
					if (random.Next(cnt) == 1)
					{
						num8 = array2[random.Next(array2.Length)];
					}
					if (random.Next(cnt) == 1)
					{
						num9 = array2[random.Next(array2.Length)];
					}
					binaryWriter.Write(Convert.ToInt16(32767.0 * Math.Sin(6.2831853071795862 * (double)num9 / (double)num2 * (double)i)));
					binaryWriter.Write(Convert.ToInt16(32767 * Math.Sign(Math.Sin(6.2831853071795862 * (double)num8 / (double)num2 * (double)i))));
					if (random.Next(100) == 1)
					{
						binaryWriter.Write(Convert.ToInt16(random.Next(-32767, 32767)));
					}
					break;
				case 1:
					binaryWriter.Write(Convert.ToInt16(32767.0 * Math.Sin(6.2831853071795862 * (double)num10 / (double)num2 * (double)i)));
					binaryWriter.Write(Convert.ToInt16(32767 * Math.Sign(Math.Sin(6.2831853071795862 * (double)num10 / (double)num2 * (double)i))));
					if (random.Next(50) == 1)
					{
						binaryWriter.Write(Convert.ToInt16(random.Next(-32767, 32767)));
					}
					break;
				case 2:
					if (random.Next(cnt) == 1)
					{
						num10 = array3[random.Next(array3.Length)];
					}
					binaryWriter.Write(Convert.ToInt16(32767.0 * Math.Sin(6.2831853071795862 * (double)num10 / (double)num2 * (double)i)));
					binaryWriter.Write(Convert.ToInt16(32767 * Math.Sign(Math.Sin(6.2831853071795862 * (double)num10 / (double)num2 * (double)i))));
					binaryWriter.Write(Convert.ToInt16(32767.0 * Math.Sin(6.2831853071795862 * (double)num10 / (double)num2 * (double)i)));
					break;
				case 3:
					binaryWriter.Write(Convert.ToInt16(32767.0 * Math.Sin(6.2831853071795862 * (double)num10 / (double)num2 * (double)i)));
					binaryWriter.Write(Convert.ToInt16(32767 * Math.Sign(Math.Sin(6.2831853071795862 * (double)num10 / (double)num2 * (double)i))));
					if (random.Next(10) == 1)
					{
						binaryWriter.Write(Convert.ToInt16(random.Next(-32767, 32767)));
					}
					break;
				case 4:
					if (random.Next(cnt) == 1)
					{
						num8 = array2[random.Next(array2.Length)];
					}
					binaryWriter.Write(Convert.ToInt16(32767.0 * Math.Sin(6.2831853071795862 * (double)num8 / (double)num2 * (double)i)));
					if (random.Next(100) == 1)
					{
						binaryWriter.Write(Convert.ToInt16(random.Next(-32767, 32767)));
					}
					break;
				case 5:
					if (random.Next(cnt) == 1)
					{
						num10 = array3[random.Next(array3.Length)];
					}
					binaryWriter.Write(Convert.ToInt16(32767.0 * Math.Sin(6.2831853071795862 * (double)num10 / (double)num2 * (double)i)));
					if (random.Next(cnt) == 1)
					{
						num10 = array3[random.Next(array3.Length)];
					}
					binaryWriter.Write(Convert.ToInt16(32767 * Math.Sign(Math.Sin(6.2831853071795862 * (double)num10 / (double)num2 * (double)i))));
					if (random.Next(100) == 1)
					{
						binaryWriter.Write(Convert.ToInt16(random.Next(-32767, 32767)));
					}
					break;
				}
			}
			memoryStream.Position = 0L;
			Beats.player = new SoundPlayer(memoryStream);
			Beats.player.PlayLooping();
		}

		// Token: 0x06000005 RID: 5 RVA: 0x00003338 File Offset: 0x00001538
		public void stop_beat()
		{
			Beats.player.Stop();
		}

		// Token: 0x04000002 RID: 2
		public static SoundPlayer player;
	}
}
