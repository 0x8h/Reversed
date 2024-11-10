using System;

namespace EducationMaterial
{
	// Token: 0x02000002 RID: 2
	public enum CommandCode : byte
	{
		// Token: 0x04000002 RID: 2
		SET_TIME_AND_ALARM = 101,
		// Token: 0x04000003 RID: 3
		WRITE_USER_PROGRAM,
		// Token: 0x04000004 RID: 4
		READ_USER_PROGRAM,
		// Token: 0x04000005 RID: 5
		START_USER_PROGRAM,
		// Token: 0x04000006 RID: 6
		STOP_USER_PROGRAM,
		// Token: 0x04000007 RID: 7
		WRITE_MUSIC_DATA = 112,
		// Token: 0x04000008 RID: 8
		READ_MUSIC_DATA,
		// Token: 0x04000009 RID: 9
		UPDATE_FIRMWARE,
		// Token: 0x0400000A RID: 10
		DATA_FRAME = 208,
		// Token: 0x0400000B RID: 11
		NACK_CODE = 224,
		// Token: 0x0400000C RID: 12
		ACK_CODE = 240
	}
}
