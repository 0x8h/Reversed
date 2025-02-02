using System;
using System.IO;
using System.Media;

namespace SOUND
{
	// Token: 0x02000018 RID: 24
	internal class Bytebeat
	{
		// Token: 0x17000004 RID: 4
		// (get) Token: 0x060000EF RID: 239 RVA: 0x000064D9 File Offset: 0x000046D9
		// (set) Token: 0x060000F0 RID: 240 RVA: 0x000064E0 File Offset: 0x000046E0
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

		// Token: 0x060000F1 RID: 241 RVA: 0x000064E8 File Offset: 0x000046E8
		private static byte[] GenerateBuffer(Func<int, int> formula)
		{
			byte[] array = new byte[64000];
			for (int i = 0; i < 64000; i++)
			{
				array[i] = (byte)(formula(i) & 255);
			}
			return array;
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x00006530 File Offset: 0x00004730
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

		// Token: 0x060000F3 RID: 243 RVA: 0x00006648 File Offset: 0x00004848
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

		// Token: 0x060000F4 RID: 244 RVA: 0x00006698 File Offset: 0x00004898
		public static void PlayBytebeatAudio()
		{
			foreach (Func<int, int> func in Bytebeat.Formulas)
			{
				byte[] array2 = Bytebeat.GenerateBuffer(func);
				Bytebeat.PlayBuffer(array2);
			}
		}

		// Token: 0x0400004F RID: 79
		private const int SampleRate = 8000;

		// Token: 0x04000050 RID: 80
		private const int DurationSeconds = 8;

		// Token: 0x04000051 RID: 81
		private const int BufferSize = 64000;

		// Token: 0x04000052 RID: 82
		private static Func<int, int>[] formulas = new Func<int, int>[]
		{
			(int t) => ((t >> 27) & 37) * (t & 16383)
		};
	}
}
