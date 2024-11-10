using System;
using System.Runtime.InteropServices;

namespace EducationMaterial
{
	// Token: 0x02000006 RID: 6
	public class HidApiDll
	{
		// Token: 0x06000029 RID: 41
		[DllImport("hidapi")]
		public static extern int hid_init();

		// Token: 0x0600002A RID: 42
		[DllImport("hidapi")]
		public static extern int hid_exit();

		// Token: 0x0600002B RID: 43
		[DllImport("hidapi", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr hid_enumerate(ushort vendor_id, ushort product_id);

		// Token: 0x0600002C RID: 44
		[DllImport("hidapi", CallingConvention = CallingConvention.Cdecl)]
		public static extern void hid_free_enumeration(IntPtr devs);

		// Token: 0x0600002D RID: 45
		[DllImport("hidapi", CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr hid_open(ushort vendor_id, ushort product_id, [MarshalAs(UnmanagedType.LPWStr)] [In] string serial_number);

		// Token: 0x0600002E RID: 46
		[DllImport("hidapi", CallingConvention = CallingConvention.Cdecl)]
		public static extern void hid_close(IntPtr device);

		// Token: 0x0600002F RID: 47
		[DllImport("hidapi", CallingConvention = CallingConvention.Cdecl)]
		public static extern int hid_write(IntPtr device, [MarshalAs(UnmanagedType.LPArray)] [In] byte[] data, IntPtr length);

		// Token: 0x06000030 RID: 48
		[DllImport("hidapi", CallingConvention = CallingConvention.Cdecl)]
		public static extern int hid_read_timeout(IntPtr device, [MarshalAs(UnmanagedType.LPArray)] [Out] byte[] data, IntPtr length, int milliseconds);
	}
}
