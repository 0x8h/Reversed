using System;
using System.Runtime.InteropServices;

namespace EducationMaterial
{
	// Token: 0x02000005 RID: 5
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct hid_device_info
	{
		// Token: 0x0400001A RID: 26
		[MarshalAs(UnmanagedType.LPStr)]
		public string path;

		// Token: 0x0400001B RID: 27
		public ushort vendor_id;

		// Token: 0x0400001C RID: 28
		public ushort product_id;

		// Token: 0x0400001D RID: 29
		[MarshalAs(UnmanagedType.LPWStr)]
		public string serial_number;

		// Token: 0x0400001E RID: 30
		public ushort release_number;

		// Token: 0x0400001F RID: 31
		[MarshalAs(UnmanagedType.LPWStr)]
		public string manufacturer_string;

		// Token: 0x04000020 RID: 32
		[MarshalAs(UnmanagedType.LPWStr)]
		public string product_string;

		// Token: 0x04000021 RID: 33
		public ushort usage_page;

		// Token: 0x04000022 RID: 34
		public ushort usage;

		// Token: 0x04000023 RID: 35
		public int interface_number;

		// Token: 0x04000024 RID: 36
		public IntPtr next;
	}
}
