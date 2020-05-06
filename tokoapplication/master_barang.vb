Imports MySql.Data.MySqlClient
Public Class master_barang
    Dim urutan As String
    Dim hitung As Long
    Dim ds As DataSet
    Dim mycmd As MySqlCommand
    Dim objdatareader As MySqlDataReader
    Sub KondisiAwal()
        cekkoneksi()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = urutan
        TextBox4.Enabled = False
    End Sub
    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Then
            MessageBox.Show("Input Data Barang Gagal Dilakukan")
            Exit Sub
        Else

            Dim str As String
            str = "insert into barang values ('" & TextBox4.Text & "','" & TextBox1.Text & "', '" & TextBox2.Text & "', '" & TextBox3.Text & "')"
            Using sqlCommand As New MySqlCommand(str, sConnection)
                sqlCommand.ExecuteNonQuery()
                MessageBox.Show("Input Data Barang Berhasil Dilakukan")
                Call KondisiAwal()
                Call Kode_Otomatis()
                Call tampilBarang()
                Call aturDGV()
            End Using

        End If
    End Sub
    Sub tampilBarang()
        Call cekkoneksi()
        Using sqlAdapter As New MySqlDataAdapter("select idbar, bar_nama, bar_stok, bar_harga from barang", sConnection)
            Using ds As New DataSet
                sqlAdapter.Fill(ds, "barang")
                dgvDaftarBarang.DataSource = ds.Tables("barang")
            End Using
        End Using

    End Sub

    Sub aturDGV()
        Try
            dgvDaftarBarang.Columns(0).Width = 70
            dgvDaftarBarang.Columns(1).Width = 130
            dgvDaftarBarang.Columns(2).Width = 100
            dgvDaftarBarang.Columns(3).Width = 100
            dgvDaftarBarang.Columns(4).Width = 150
            dgvDaftarBarang.Columns(0).HeaderText = "ID Barang"
            dgvDaftarBarang.Columns(1).HeaderText = "Nama Barang"
            dgvDaftarBarang.Columns(2).HeaderText = "Stok"
            dgvDaftarBarang.Columns(3).HeaderText = "Harga "
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub master_barang_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call KondisiAwal()
        Call Kode_Otomatis()
        Call tampilBarang()
        Call aturDGV()
    End Sub
    Sub Kode_Otomatis()
        Call cekkoneksi()
        Using sqlCommand As New MySqlCommand("Select * from barang where idbar in (select max(idbar) from barang) ", sConnection)
            Using DR As MySqlDataReader = sqlCommand.ExecuteReader
                DR.Read()

                If DR.HasRows = 0 Then
                    TextBox4.Text = "BR-01"
                    DR.Close()

                End If
                If Not DR.HasRows Then
                    urutan = "BR-" + "01"
                    DR.Close()

                Else
                    hitung = Microsoft.VisualBasic.Right(DR.GetString(0), 1) + 1
                    urutan = "BR-" + Microsoft.VisualBasic.Right("0" & hitung, 2)
                    DR.Close()
                    TextBox4.Text = urutan
                End If
            End Using
        End Using

    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        main_menu.Show()
        Me.Hide()
    End Sub
End Class