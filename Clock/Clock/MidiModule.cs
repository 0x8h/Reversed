using System;
using System.Runtime.InteropServices;

namespace Clock
{
	// Token: 0x02000030 RID: 48
	internal class MidiModule
	{
		// Token: 0x06000587 RID: 1415 RVA: 0x000439C7 File Offset: 0x00041BC7
		public MidiModule()
		{
			this._deviceCount = (int)MidiModule.midiOutGetNumDevs();
		}

		// Token: 0x06000588 RID: 1416 RVA: 0x000439F0 File Offset: 0x00041BF0
		~MidiModule()
		{
			this.close();
		}

		// Token: 0x06000589 RID: 1417 RVA: 0x00043A1C File Offset: 0x00041C1C
		public void open()
		{
			if (this._deviceCount > 0 && this._deviceHandle == 0U)
			{
				MidiModule.midiOutOpen(ref this._deviceHandle, 0, null, 0, 0);
			}
		}

		// Token: 0x0600058A RID: 1418 RVA: 0x00043A3F File Offset: 0x00041C3F
		public void close()
		{
			if (this._deviceHandle != 0U)
			{
				MidiModule.midiOutClose(this._deviceHandle);
				this._deviceHandle = 0U;
			}
		}

		// Token: 0x0600058B RID: 1419 RVA: 0x00043A5C File Offset: 0x00041C5C
		public void play(uint key)
		{
			if (this._deviceHandle != 0U)
			{
				uint power = this._power;
				uint channel = this._channel;
				MidiModule.midiOutShortMsg(this._deviceHandle, (this._power << 16) | (key << 8) | this._channel);
				this._previousKey = key;
			}
		}

		// Token: 0x0600058C RID: 1420 RVA: 0x00043A9B File Offset: 0x00041C9B
		public void stop()
		{
			if (this._deviceHandle != 0U)
			{
				MidiModule.midiOutShortMsg(this._deviceHandle, (this._previousKey << 8) | 128U);
			}
		}

		// Token: 0x0600058D RID: 1421 RVA: 0x00043ABF File Offset: 0x00041CBF
		public int getDeviceCount()
		{
			return this._deviceCount;
		}

		// Token: 0x0600058E RID: 1422
		[DllImport("Winmm.dll", CharSet = CharSet.Auto)]
		private static extern uint midiOutGetNumDevs();

		// Token: 0x0600058F RID: 1423
		[DllImport("Winmm.dll")]
		private static extern uint midiOutOpen(ref uint lphmo, int uDeviceID, MidiModule.MidiOutProc dwCallback, int dwCallbackInstance, int dwFlags);

		// Token: 0x06000590 RID: 1424
		[DllImport("Winmm.dll")]
		private static extern uint midiOutShortMsg(uint hmo, uint dwMsg);

		// Token: 0x06000591 RID: 1425
		[DllImport("Winmm.dll")]
		private static extern uint midiOutClose(uint hmo);

		// Token: 0x04000460 RID: 1120
		private int _deviceCount;

		// Token: 0x04000461 RID: 1121
		private uint _deviceHandle;

		// Token: 0x04000462 RID: 1122
		private uint _power = 64U;

		// Token: 0x04000463 RID: 1123
		private uint _channel = 144U;

		// Token: 0x04000464 RID: 1124
		private uint _previousKey;

		// Token: 0x020000A1 RID: 161
		// (Invoke) Token: 0x0600106F RID: 4207
		private delegate void MidiOutProc(IntPtr hmo, uint hwnd, int dwInstance, int dwParam1, int dwParam2);
	}
}
