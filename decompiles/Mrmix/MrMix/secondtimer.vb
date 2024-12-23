Imports System

Namespace MrMix
	' Token: 0x02000002 RID: 2
	Public Class secondtimer
		' Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		Public Sub secontimer()
		End Sub

		' Token: 0x06000002 RID: 2 RVA: 0x00002052 File Offset: 0x00000252
		Public Sub initialize()
			Me.newtimeOut = True
		End Sub

		' Token: 0x06000003 RID: 3 RVA: 0x0000205C File Offset: 0x0000025C
		Public Sub start()
			If Me.newtimeOut Then
				Me.timeOut = DateTime.Now.Second + 1
				Me.newtimeOut = False
			End If
			If Me.timeOut <> 60 Then
				If DateTime.Now.Second >= Me.timeOut AndAlso Me.dyntimer <> 0 Then
					Me.dyntimer -= 1
					Me.newtimeOut = True
					Return
				End If
			Else
				Me.timeOut = 1
				Me.newtimeOut = True
			End If
		End Sub

		' Token: 0x04000001 RID: 1
		Public dyntimer As Integer = 60

		' Token: 0x04000002 RID: 2
		Public timeOut As Integer

		' Token: 0x04000003 RID: 3
		Private newtimeOut As Boolean
	End Class
End Namespace
