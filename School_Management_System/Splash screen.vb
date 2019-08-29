Public Class Splash_screen
    Private Sub Splash_screen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'ProgressBar.
        BunifuProgressBar1.Value = 0
        BunifuProgressBar1.MaximumValue = 100
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        BunifuProgressBar1.Value += 1
        'BunifuProgressBar1.
        If BunifuProgressBar1.Value = 95 Then
            Label1.Text = "Welcome"
        End If
        If BunifuProgressBar1.Value = 100 Then
            Timer1.Stop()
            Me.Close()
        End If
    End Sub
End Class