using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Clock
{
	// Token: 0x0200001E RID: 30
	public class CursorCreator
	{
		// Token: 0x0600022E RID: 558
		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetIconInfo(IntPtr hIcon, ref IconInfo pIconInfo);

		// Token: 0x0600022F RID: 559
		[DllImport("user32.dll")]
		public static extern IntPtr CreateIconIndirect(ref IconInfo icon);

		// Token: 0x06000230 RID: 560 RVA: 0x000204C8 File Offset: 0x0001E6C8
		public static Cursor CreateCursor(Bitmap bmp, int xHotSpot, int yHotSpot)
		{
			IntPtr hicon = bmp.GetHicon();
			IconInfo iconInfo = default(IconInfo);
			CursorCreator.GetIconInfo(hicon, ref iconInfo);
			iconInfo.xHotspot = xHotSpot;
			iconInfo.yHotspot = yHotSpot;
			iconInfo.fIcon = false;
			return new Cursor(CursorCreator.CreateIconIndirect(ref iconInfo));
		}
	}
}
