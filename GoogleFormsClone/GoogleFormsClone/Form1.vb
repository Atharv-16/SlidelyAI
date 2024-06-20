Public Class Form1
    Private Sub btnCreateSubmission_Click(sender As Object, e As EventArgs) Handles btnCreateSubmission.Click
        Dim createForm As New CreateSubmissionForm()
        createForm.Show()
    End Sub

    Private Sub btnViewSubmissions_Click(sender As Object, e As EventArgs) Handles btnViewSubmissions.Click
        Dim viewForm As New ViewSubmissionsForm_vb()
        viewForm.Show()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Ensure the form receives key events before they are passed to the controls
        Me.KeyPreview = True
    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        ' Ctrl + N for creating a new submission
        If e.Control AndAlso e.KeyCode = Keys.C Then
            btnCreateSubmission.PerformClick()
        End If

        ' Ctrl + V for viewing submissions
        If e.Control AndAlso e.KeyCode = Keys.V Then
            btnViewSubmissions.PerformClick()
        End If

        ' Handle Ctrl + C for other purposes if needed
        If e.Control AndAlso e.KeyCode = Keys.C Then
            ' Implement custom logic here if Ctrl + C is needed for another purpose
            ' Example: MessageBox.Show("Ctrl + C pressed for another purpose.")
        End If
    End Sub
End Class
