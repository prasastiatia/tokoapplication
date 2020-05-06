Imports MySql.Data.MySqlClient
Public Class Form_transaksi
    Dim urutan As String
    Dim hitung As Long
    Dim ds As DataSet
    Dim mycmd As MySqlCommand
    Dim objdatareader As MySqlDataReader
    Sub KondisiAwal()
        cekkoneksi()
        TextBox1.Text = ""
        TextBox3.Text = ""
        TextBox7.Text = ""
        TextBox6.Text = ""
        TextBox5.Text = ""
        TextBox4.Text = urutan
        TextBox4.Enabled = False
    End Sub
    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If ComboBox1.Text = "" Then
            Me.Close()
        Else

            Dim str As String
            str = "insert into transaksi  (idtrans, idpel, trans_total) values ('" & TextBox4.Text & "' ,'" & ComboBox1.Text & "','" & TextBox6.Text & "');"
            str &= "insert into detail (idtrans, idbar, det_qty, det_harga) values ('" & TextBox4.Text & "','" & ComboBox2.Text & "','" & TextBox7.Text & "','" & TextBox3.Text & "');"
            Using sqlCommand As New MySqlCommand(str, sConnection)
                sqlCommand.CommandType = CommandType.Text
                sqlCommand.CommandText = str
                sqlCommand.ExecuteNonQuery()
                MessageBox.Show("Input Data Transaksi Berhasil Dilakukan")
            End Using

        End If
    End Sub

    Private Sub Form_transaksi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call KondisiAwal()
        Call Kode_Otomatis()
        Call tampilDataPelanggan()
        Call tampilDataBarang()
    End Sub

    Sub Kode_Otomatis()
        Call cekkoneksi()
        Using sqlCommand As New MySqlCommand("Select * from transaksi where idtrans in (select max(idtrans) from transaksi) ", sConnection)
            Using DR As MySqlDataReader = sqlCommand.ExecuteReader
                DR.Read()

                If DR.HasRows = 0 Then
                    TextBox4.Text = "TR-01"
                    DR.Close()

                End If
                If Not DR.HasRows Then
                    urutan = "TR-" + "01"
                    DR.Close()

                Else
                    hitung = Microsoft.VisualBasic.Right(DR.GetString(0), 1) + 1
                    urutan = "TR-" + Microsoft.VisualBasic.Right("0" & hitung, 2)
                    DR.Close()
                    TextBox4.Text = urutan
                End If
            End Using
        End Using

    End Sub
    Sub tampilDataPelanggan()
        Call cekkoneksi()
        Dim str As String
        str = "select idpel from pelanggan"
        Using sqlCommand As New MySqlCommand(str, sConnection)
            Using DR As MySqlDataReader = sqlCommand.ExecuteReader
                If DR.HasRows Then
                    Do While DR.Read
                        ComboBox1.Items.Add(DR("idpel"))
                    Loop
                    DR.Close()
                End If
            End Using
        End Using

    End Sub
    Sub tampilDataBarang()
        Call cekkoneksi()
        Dim str As String
        str = "select idbar from barang"
        Using sqlCommand As New MySqlCommand(str, sConnection)
            Using DR As MySqlDataReader = sqlCommand.ExecuteReader
                If DR.HasRows Then
                    Do While DR.Read
                        ComboBox2.Items.Add(DR("idbar"))
                    Loop
                    DR.Close()
                End If
            End Using
        End Using

    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim query As String
        Call cekkoneksi()
        query = "Select idpel, pel_nama from pelanggan where idpel='" & ComboBox1.Text & "'"
        Using sqlCommand As New MySqlCommand(query, sConnection)

            Using DR As MySqlDataReader = sqlCommand.ExecuteReader
                DR.Read()
                If DR.HasRows Then
                    TextBox1.Text = DR.Item(1)
                End If
                DR.Close()
            End Using
        End Using
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        Dim query As String
        Call cekkoneksi()
        query = "Select idbar, bar_nama, bar_harga from barang where idbar='" & ComboBox2.Text & "'"
        Using sqlCommand As New MySqlCommand(query, sConnection)

            Using DR As MySqlDataReader = sqlCommand.ExecuteReader
                DR.Read()
                If DR.HasRows Then
                    TextBox5.Text = DR.Item(1)
                    TextBox3.Text = DR.Item(2)
                End If
                DR.Close()
            End Using
        End Using
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Button1.Visible = True
        Button3.Visible = False

        Dim total_harga As New Integer
        Dim harga As New Integer
        Dim jumlah As New Integer

        harga = Val(TextBox3.Text)
        jumlah = Val(TextBox7.Text)
        total_harga = harga * jumlah
        TextBox6.Text = total_harga


    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        main_menu.Show()
        Me.Hide()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        data_transaksi.Show()
        Me.Hide()
    End Sub
End Class