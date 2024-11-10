using System;

namespace Clock
{
	// Token: 0x0200003D RID: 61
	internal interface NetworkObjectInterface
	{
		// Token: 0x17000045 RID: 69
		// (get) Token: 0x06000661 RID: 1633
		// (set) Token: 0x06000662 RID: 1634
		bool Selected { get; set; }

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x06000663 RID: 1635
		// (set) Token: 0x06000664 RID: 1636
		GUIDE Guide { get; set; }
	}
}
