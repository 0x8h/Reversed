using System;
using System.IO;
using System.Media;

namespace LST56
{
	// Token: 0x02000004 RID: 4
	internal class Bytebeat
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000009 RID: 9 RVA: 0x000021F0 File Offset: 0x000003F0
		// (set) Token: 0x0600000A RID: 10 RVA: 0x000021F7 File Offset: 0x000003F7
		public static Func<int, int>[] Formulas
		{
			get
			{
				return Bytebeat.formulas;
			}
			set
			{
				Bytebeat.formulas = value;
			}
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00002200 File Offset: 0x00000400
		private static byte[] GenerateBuffer(Func<int, int> formula)
		{
			byte[] array = new byte[160000];
			for (int i = 0; i < 160000; i++)
			{
				array[i] = (byte)(formula(i) & 255);
			}
			return array;
		}

		// Token: 0x0600000C RID: 12 RVA: 0x00002248 File Offset: 0x00000448
		private static void SaveWav(byte[] buffer, string filePath)
		{
			using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(fileStream))
				{
					binaryWriter.Write(new char[] { 'R', 'I', 'F', 'F' });
					binaryWriter.Write(36 + buffer.Length);
					binaryWriter.Write(new char[] { 'W', 'A', 'V', 'E' });
					binaryWriter.Write(new char[] { 'f', 'm', 't', ' ' });
					binaryWriter.Write(16);
					binaryWriter.Write(1);
					binaryWriter.Write(1);
					binaryWriter.Write(8000);
					binaryWriter.Write(8000);
					binaryWriter.Write(1);
					binaryWriter.Write(8);
					binaryWriter.Write(new char[] { 'd', 'a', 't', 'a' });
					binaryWriter.Write(buffer.Length);
					binaryWriter.Write(buffer);
				}
			}
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00002360 File Offset: 0x00000560
		private static void PlayBuffer(byte[] buffer)
		{
			string tempFileName = Path.GetTempFileName();
			Bytebeat.SaveWav(buffer, tempFileName);
			using (SoundPlayer soundPlayer = new SoundPlayer(tempFileName))
			{
				soundPlayer.PlaySync();
			}
			File.Delete(tempFileName);
		}

		// Token: 0x0600000E RID: 14 RVA: 0x000023B0 File Offset: 0x000005B0
		public static void PlayBytebeatAudio()
		{
			foreach (Func<int, int> func in Bytebeat.Formulas)
			{
				byte[] array2 = Bytebeat.GenerateBuffer(func);
				Bytebeat.PlayBuffer(array2);
			}
		}

		// Token: 0x04000006 RID: 6
		private const int SampleRate = 8000;

		// Token: 0x04000007 RID: 7
		private const int DurationSeconds = 20;

		// Token: 0x04000008 RID: 8
		private const int BufferSize = 160000;

		// Token: 0x04000009 RID: 9
		private static Func<int, int>[] formulas = new Func<int, int>[]
		{
			(int t) => ((t >> 1) & 78) * (t % 26)
		};
	}
}
