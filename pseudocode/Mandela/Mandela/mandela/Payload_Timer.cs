using System;
using System.Threading;

namespace mandela
{
	// Token: 0x0200000A RID: 10
	public class Payload_Timer
	{
		// Token: 0x0600002F RID: 47 RVA: 0x00006134 File Offset: 0x00004334
		public void timer()
		{
			Payload_Timer.count = 0;
			for (;;)
			{
				if (Payload_Timer.count == 30)
				{
					new Thread(new ThreadStart(new Move_Events().move_mouse)).Start();
				}
				else if (Payload_Timer.count == 60)
				{
					new Thread(new ThreadStart(new Move_Events().move_window)).Start();
				}
				else if (Payload_Timer.count == 100)
				{
					Beats beats = new Beats();
					beats.stop_beat();
					beats.beat(5, 30, 2, 100);
					Payload_Timer.rapid = true;
				}
				else if (Payload_Timer.count == 200)
				{
					Environment.Exit(-1);
				}
				Thread.Sleep(1000);
				Payload_Timer.count++;
			}
		}

		// Token: 0x0400002B RID: 43
		public static int count;

		// Token: 0x0400002C RID: 44
		public static bool rapid;
	}
}
