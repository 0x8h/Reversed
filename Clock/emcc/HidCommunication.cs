using System;

namespace EducationMaterial
{
	// Token: 0x02000009 RID: 9
	public class HidCommunication : IDisposable
	{
		// Token: 0x06000037 RID: 55 RVA: 0x00002ADF File Offset: 0x00000CDF
		public HidCommunication(IntPtr device)
		{
			this.device = device;
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00002AEE File Offset: 0x00000CEE
		public void Dispose()
		{
			if (this.device != IntPtr.Zero)
			{
				HidApiDll.hid_close(this.device);
				this.device = IntPtr.Zero;
			}
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00002B18 File Offset: 0x00000D18
		public int writeData(byte[] data, int length)
		{
			return HidApiDll.hid_write(this.device, data, (IntPtr)length);
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00002B2C File Offset: 0x00000D2C
		public int readDataTimeout(byte[] data, int length, int milliseconds)
		{
			return HidApiDll.hid_read_timeout(this.device, data, (IntPtr)length, milliseconds);
		}

		// Token: 0x0400002F RID: 47
		private IntPtr device;
	}
}
