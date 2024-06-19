Imports System.Net.Http
Imports System.Threading.Tasks
Imports Newtonsoft.Json

Module ApiHelper
    Private ReadOnly client As New HttpClient()

    Public Async Function GetSubmissionAsync(index As Integer) As Task(Of Submission)
        Try
            Dim response As HttpResponseMessage = Await client.GetAsync($"http://localhost:3000/read?index={index}")
            response.EnsureSuccessStatusCode()
            Dim submissionJson As String = Await response.Content.ReadAsStringAsync()
            Dim submission As Submission = JsonConvert.DeserializeObject(Of Submission)(submissionJson)
            Return submission
        Catch ex As Exception
            Throw New Exception("Error retrieving submission", ex)
        End Try
    End Function

    Public Async Function SubmitFormAsync(name As String, email As String, phone As String, githubLink As String, stopwatchTime As String) As Task
        Try
            Dim data As New Dictionary(Of String, String) From {
                {"name", name},
                {"email", email},
                {"phone", phone},
                {"github_link", githubLink},
                {"stopwatch_time", stopwatchTime}
            }
            Dim content As New FormUrlEncodedContent(data)
            Dim response As HttpResponseMessage = Await client.PostAsync("http://localhost:3000/submit", content)
            response.EnsureSuccessStatusCode()
        Catch ex As Exception
            Throw New Exception("Error submitting form", ex)
        End Try
    End Function

    Public Async Function GetTotalSubmissionsAsync() As Task(Of Integer)
        Try
            Dim response As HttpResponseMessage = Await client.GetAsync("http://localhost:3000/total")
            response.EnsureSuccessStatusCode()
            Dim totalJson As String = Await response.Content.ReadAsStringAsync()
            Dim total As Integer = JsonConvert.DeserializeObject(Of Integer)(totalJson)
            Return total
        Catch ex As Exception
            Throw New Exception("Error retrieving total submissions", ex)
        End Try
    End Function
End Module

Public Class Submission
    Public Property name As String
    Public Property email As String
    Public Property phone As String
    Public Property github_link As String
    Public Property stopwatch_time As String
End Class
