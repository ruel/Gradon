Imports System.Text
Imports System.Security.Cryptography
Imports System.Threading


Public Class frmLogin

    Dim gds As New gradonDataSet()
    Dim users As DataTable
    Dim gDap As New gradonDataSetTableAdapters.usersTableAdapter()

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

        If txtUser.Text = "" And txtPass.Text = "" Then
            MessageBox.Show("Please complete the fields", "Incomplete", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Dim tMain As New Thread(AddressOf DoLogin)
        tMain.Start()
        DisableControls()

    End Sub

    Private Sub DisableControls()
        For Each con As Control In Me.Controls
            con.Enabled = False
        Next
    End Sub

    Private Sub EnableControls()
        For Each con As Control In Me.Controls
            con.Enabled = True
        Next
    End Sub

    Private Sub DoLogin()
        Dim md5 As String

        md5 = GenerateMD5Hash(txtPass.Text)
        users = gds.Tables("users")
        gDap.Fill(users)

        Dim dr As DataRow() = users.Select("id = '" & txtUser.Text & "' AND password = '" & md5 & "'")

        If (dr.Length = 0) Then
            MessageBox.Show("Invalid ID or password", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Invoke(New MethodInvoker(AddressOf EnableControls))
            Exit Sub
        End If

        Dim type As String = dr(0).Field(Of String)("type")

        Me.Invoke(New MethodInvoker(Sub()

                                        Me.Close()
                                    End Sub))
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Function GenerateMD5Hash(ByVal SourceText As String) As String
        Dim md5 As New MD5CryptoServiceProvider
        Dim bytesStr As Byte() = Encoding.ASCII.GetBytes(SourceText)
        Dim out As String = ""

        bytesStr = md5.ComputeHash(bytesStr)

        For Each chr As Byte In bytesStr
            out += chr.ToString("x2")
        Next

        Return out
    End Function

End Class
