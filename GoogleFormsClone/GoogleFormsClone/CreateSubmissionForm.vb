Public Class CreateSubmissionForm
    Private stopwatchTime As TimeSpan = TimeSpan.Zero
    Private stopwatchRunning As Boolean = False

    Private Sub CreateSubmissionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Ensure the form receives key events before they are passed to the controls
        Me.KeyPreview = True
    End Sub

    Private Sub btnStartStop_Click(sender As Object, e As EventArgs) Handles btnStartStop.Click
        If stopwatchRunning Then
            stopwatchTimer.Stop()
            stopwatchRunning = False
            btnStartStop.Text = "Start"
        Else
            stopwatchTimer.Start()
            stopwatchRunning = True
            btnStartStop.Text = "Stop"
        End If
    End Sub

    Private Sub stopwatchTimer_Tick(sender As Object, e As EventArgs) Handles stopwatchTimer.Tick
        stopwatchTime = stopwatchTime.Add(TimeSpan.FromSeconds(1))
        lblStopwatch.Text = stopwatchTime.ToString("hh\:mm\:ss")
    End Sub

    Private Async Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        Try
            Await ApiHelper.SubmitFormAsync(txtName.Text, txtEmail.Text, txtPhone.Text, txtGitHub.Text, stopwatchTime.ToString("hh\:mm\:ss"))
            MessageBox.Show("Submission Successful!")
            Me.Close()
        Catch ex As Exception
            MessageBox.Show($"Error submitting form: {ex.Message}")
        End Try
    End Sub

    Private Sub CreateSubmissionForm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.S Then
            btnSubmit.PerformClick()
        End If
    End Sub
End Class
