using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

namespace EducationMaterial
{
	// Token: 0x02000008 RID: 8
	public class HidController : IDisposable
	{
		// Token: 0x06000033 RID: 51 RVA: 0x00002934 File Offset: 0x00000B34
		public HidController()
		{
			int num = HidApiDll.hid_init();
			Console.WriteLine("hid_init(): result=" + num);
			if (num < 0)
			{
				throw new IOException("Library initialize feiled");
			}
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00002974 File Offset: 0x00000B74
		public void Dispose()
		{
			int num = HidApiDll.hid_exit();
			Console.WriteLine("hid_exit(): result=" + num);
		}

		// Token: 0x06000035 RID: 53 RVA: 0x0000299C File Offset: 0x00000B9C
		public List<HidInfo> getHidInfo()
		{
			List<HidInfo> list = new List<HidInfo>();
			IntPtr intPtr = HidApiDll.hid_enumerate(0, 0);
			if (intPtr == IntPtr.Zero)
			{
				Console.WriteLine("Device not found.");
				return list;
			}
			IntPtr intPtr2 = intPtr;
			while (intPtr2 != IntPtr.Zero)
			{
				hid_device_info hid_device_info = (hid_device_info)Marshal.PtrToStructure(intPtr2, typeof(hid_device_info));
				list.Add(new HidInfo
				{
					path = hid_device_info.path,
					vendorId = hid_device_info.vendor_id,
					productId = hid_device_info.product_id,
					serialNumber = hid_device_info.serial_number,
					releaseNumber = hid_device_info.release_number,
					manufacturerString = hid_device_info.manufacturer_string,
					productString = hid_device_info.product_string,
					usagePage = hid_device_info.usage_page,
					usage = hid_device_info.usage,
					interfaceNumber = hid_device_info.interface_number
				});
				intPtr2 = hid_device_info.next;
			}
			HidApiDll.hid_free_enumeration(intPtr);
			return list;
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00002AA8 File Offset: 0x00000CA8
		public HidCommunication connectHid(ushort venderId, ushort productId, string serialNumber = null)
		{
			IntPtr intPtr = HidApiDll.hid_open(venderId, productId, serialNumber);
			if (intPtr == IntPtr.Zero)
			{
				Console.WriteLine("hid_open(): Open failure.");
				return null;
			}
			return new HidCommunication(intPtr);
		}
	}
}
