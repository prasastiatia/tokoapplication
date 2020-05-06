Imports System.Data
Imports MySql.Data.MySqlClient
Module Koneksi_db
    Public server As String = "SERVER = localhost ; USERID = root; PASSWORD = ; DATABASE = toko; Convert Zero Datetime=True; Allow Zero Datetime=True;"
    Public sConnection As New MySqlConnection
    Public sqlCommand As New MySqlCommand
    Public sqlAdapter As New MySqlDataAdapter
    Public konfirmasi As MsgBoxResult
    Public DR As MySqlDataReader
    Public ds As DataSet
    Public cur As New Form

    Public Sub cekkoneksi()
        If sConnection.State = ConnectionState.Closed Then
            sConnection.ConnectionString = server
            sConnection.Open()
        End If
    End Sub

    Public Sub TutupKoneksi()
        With sConnection
            .Dispose()
            .Close()
        End With
    End Sub

End Module
