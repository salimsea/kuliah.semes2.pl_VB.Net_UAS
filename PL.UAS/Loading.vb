Public Class Loading
	Private WithEvents tim As New System.Timers.Timer
	Public Delegate Sub doSub()
	Private thingToDo As doSub

	Public Sub TimeOut(d As doSub, milliseconds As Integer)
		thingToDo = d
		tim.AutoReset = False
		tim.Interval = milliseconds
		tim.Start()
	End Sub

	Private Sub tim_Elapsed(sender As Object, e As System.Timers.ElapsedEventArgs) Handles tim.Elapsed
		Invoke(thingToDo)
	End Sub

	Private Sub Loading_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		TimeOut(AddressOf Thing, 1000)
	End Sub

	Public Sub Thing()
		Me.Close()
	End Sub
End Class