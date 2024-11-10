using System;

namespace PdfSharp.Internal
{
	// Token: 0x020000B3 RID: 179
	internal static class DiagnosticsHelper
	{
		// Token: 0x060007AD RID: 1965 RVA: 0x0001D7A0 File Offset: 0x0001B9A0
		public static void HandleNotImplemented(string message)
		{
			string text = "Not implemented: " + message;
			switch (Diagnostics.NotImplementedBehaviour)
			{
			case NotImplementedBehaviour.DoNothing:
				return;
			case NotImplementedBehaviour.Log:
				Logger.Log(text, new object[0]);
				return;
			case NotImplementedBehaviour.Throw:
				DiagnosticsHelper.ThrowNotImplementedException(text);
				return;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}

		// Token: 0x060007AE RID: 1966 RVA: 0x0001D7ED File Offset: 0x0001B9ED
		public static void ThrowNotImplementedException(string message)
		{
			throw new NotImplementedException(message);
		}
	}
}
