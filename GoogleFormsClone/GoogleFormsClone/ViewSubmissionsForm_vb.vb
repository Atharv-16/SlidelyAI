Public Class ViewSubmissionsForm_vb
    Private currentIndex As Integer = 0
    Private totalSubmissions As Integer

    Private Async Sub ViewSubmissionsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        totalSubmissions = Await ApiHelper.GetTotalSubmissionsAsync()
        LoadSubmission()
    End Sub

    Private Async Sub LoadSubmission()
        Try
            Dim submission As Submission = Await ApiHelper.GetSubmissionAsync(currentIndex)
            lblName.Text = $"Name: {submission.name}"
            lblEmail.Text = $"Email: {submission.email}"
            lblPhone.Text = $"Phone: {submission.phone}"
            lblGitHub.Text = $"GitHub: {submission.github_link}"
            lblStopwatch.Text = $"Stopwatch: {submission.stopwatch_time}"
        Catch ex As Exception
            MessageBox.Show($"Error loading submission: {ex.Message}")
        End Try
    End Sub

    Private Sub btnPrevious_Click(sender As Object, e As EventArgs) Handles btnPrevious.Click
        If currentIndex > 0 Then
            currentIndex -= 1
            LoadSubmission()
        End If
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        If currentIndex < totalSubmissions - 1 Then
            currentIndex += 1
            LoadSubmission()
        End If
    End Sub
End Class
