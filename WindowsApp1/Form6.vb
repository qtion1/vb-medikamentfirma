Public Class Form6

    Public Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        TextBox4.Text = "0"
        TextBox5.Text = "0"
        TextBox6.Text = "0"

        Timer1.Interval = "1"
        If Button1.Text = "Start" Then
            Timer1.Enabled = True
            Button1.Text = "Stop"
        ElseIf Button1.Text = "Stop" Then
            Timer1.Enabled = False
            Button1.Text = "Start"
        End If

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        TextBox4.Text = TextBox4.Text + 1
        If TextBox4.Text = 9 Then
            TextBox4.Text = "0"
            TextBox5.Text = TextBox5.Text + 1
            If TextBox5.Text = 9 Then
                TextBox5.Text = "0"
                TextBox6.Text = TextBox6.Text + 1
                If TextBox6.Text = 9 Then

                    Timer1.Stop()
                End If

            End If
        End If





    End Sub

    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.CenterToScreen()

    End Sub
End Class