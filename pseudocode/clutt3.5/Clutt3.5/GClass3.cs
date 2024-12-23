using System;
using System.Drawing;

// Token: 0x02000024 RID: 36
public class GClass3
{
	// Token: 0x060000B2 RID: 178 RVA: 0x00004958 File Offset: 0x00002B58
	public static Icon smethod_0(string string_0, int int_0, bool bool_0)
	{
		IntPtr intPtr;
		IntPtr intPtr2;
		GClass2.ExtractIconExW(string_0, int_0, out intPtr, out intPtr2, 1);
		Icon icon;
		try
		{
			icon = Icon.FromHandle(bool_0 ? intPtr : intPtr2);
		}
		catch
		{
			icon = null;
		}
		return icon;
	}
}
