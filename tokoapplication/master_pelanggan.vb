Imports MySql.Data.MySqlClient
Public Class master_pelanggan
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
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        main_menu.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Then
            MessageBox.Show("Input Data Pelanggan Gagal Dilakukan")
            Exit Sub
        Else

            Dim str As String
            str = "insert into pelanggan values ('" & TextBox4.Text & "','" & TextBox1.Text & "', '" & TextBox2.Text & "', '" & TextBox3.Text & "')"
            Using sqlCommand As New MySqlCommand(str, sConnection)
                sqlCommand.ExecuteNonQuery()
                MessageBox.Show("Input Data Pelanggan Berhasil Dilakukan")
                Call KondisiAwal()
                Call Kode_Otomatis()
                Call tampilPelanggan()
                Call aturDGV()
            End Using

        End If
    End Sub

    Sub tampilPelanggan()
        Call cekkoneksi()
        Using sqlAdapter As New MySqlDataAdapter("select idpel, pel_nama, pel_alamat, pel_telp from pelanggan", sConnection)
            Using ds As New DataSet
                sqlAdapter.Fill(ds, "pelanggan")
                dgvDaftarPelanggan.DataSource = ds.Tables("pelanggan")
            End Using
        End Using

    End Sub

    Sub aturDGV()
        Try
            dgvDaftarPelanggan.Columns(0).Width = 70
            dgvDaftarPelanggan.Columns(1).Width = 130
            dgvDaftarPelanggan.Columns(2).Width = 100
            dgvDaftarPelanggan.Columns(3).Width = 100
            dgvDaftarPelanggan.Columns(4).Width = 150
            dgvDaftarPelanggan.Columns(0).HeaderText = "ID Pelanggan"
            dgvDaftarPelanggan.Columns(1).HeaderText = "Nama Pelanggan"
            dgvDaftarPelanggan.Columns(2).HeaderText = "Alamat"
            dgvDaftarPelanggan.Columns(3).HeaderText = "Telpon "
        Catch ex As Exception
        End Try
    End Sub

    Private Sub master_pelanggan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call KondisiAwal()
        Call Kode_Otomatis()
        Call tampilPelanggan()
        Call aturDGV()
    End Sub

    Sub Kode_Otomatis()
        Call cekkoneksi()
        Using sqlCommand As New MySqlCommand("Select * from pelanggan where idpel in (select max(idpel) from pelanggan) ", sConnection)
            Using DR As MySqlDataReader = sqlCommand.ExecuteReader
                DR.Read()

                If DR.HasRows = 0 Then
                    TextBox4.Text = "PL-01"
                    DR.Close()

                End If
                If Not DR.HasRows Then
                    urutan = "PL-" + "01"
                    DR.Close()

                Else
                    hitung = Microsoft.VisualBasic.Right(DR.GetString(0), 1) + 1
                    urutan = "PL-" + Microsoft.VisualBasic.Right("0" & hitung, 2)
                    DR.Close()
                    TextBox4.Text = urutan
                End If
            End Using
        End Using

    End Sub
End Class