Imports System.Threading

Public Class frmAdmin
    Private id As String
    Dim gds As New gradonDataSet()
    Dim users As DataTable
    Dim gDap As New gradonDataSetTableAdapters.usersTableAdapter()
    Public Sub New(ByVal user As String)

        ' This call is required by the designer.
        InitializeComponent()
        id = user
    End Sub
    Private Sub frmAdmin_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Init()

    End Sub
End Class
