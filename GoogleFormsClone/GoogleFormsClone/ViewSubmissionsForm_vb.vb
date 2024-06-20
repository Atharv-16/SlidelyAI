Public Class ViewSubmissionsForm_vb
    Private currentIndex As Integer = 0
    Private totalSubmissions As Integer

    Private Sub ViewSubmissionsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        Me.Focus() ' Ensure form has focus
        LoadSubmissions()
    End Sub

    Private Async Sub LoadSubmissions()
        Try
            totalSubmissions = Await ApiHelper.GetTotalSubmissionsAsync()
            Await LoadSubmission()
        Catch ex As Exception
            MessageBox.Show($"Error loading submissions: {ex.Message}")
        End Try
    End Sub

    Private Async Function LoadSubmission() As Task
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
    End Function

    Private Sub btnPrevious_Click(sender As Object, e As EventArgs) Handles btnPrevious.Click
        PreviousSubmission()
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        NextSubmission()
    End Sub

    Private Sub PreviousSubmission()
        If currentIndex > 0 Then
            currentIndex -= 1
            LoadSubmission()
        End If
    End Sub

    Private Sub NextSubmission()
        If currentIndex < totalSubmissions - 1 Then
            currentIndex += 1
            LoadSubmission()
        End If
    End Sub

    Private Sub ViewSubmissionsForm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        ' Ctrl + P for previous submission
        If e.Control AndAlso e.KeyCode = Keys.P Then
            PreviousSubmission()
        End If

        ' Ctrl + N for next submission
        If e.Control AndAlso e.KeyCode = Keys.N Then
            NextSubmission()
        End If
    End Sub
End Class
