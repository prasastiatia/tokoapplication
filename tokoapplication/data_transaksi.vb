Imports MySql.Data.MySqlClient

Public Class data_transaksi

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDaftar.CellContentClick

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Form_transaksi.Show()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        main_menu.Show()
        Me.Hide()
    End Sub

    Sub tampilSeluruhTransaksi()
        Call cekkoneksi()
        Using sqlAdapter As New MySqlDataAdapter("Select * from transaksi inner join detail on detail.idtrans = transaksi.idtrans", sConnection)
            Using ds As New DataSet
                sqlAdapter.Fill(ds, "transaksi")
                dgvDaftar.DataSource = ds.Tables("transaksi")
            End Using
        End Using

    End Sub

    Sub aturDGV()
        Try
            dgvDaftar.Columns(0).Width = 70
            dgvDaftar.Columns(1).Width = 130
            dgvDaftar.Columns(2).Width = 100
            dgvDaftar.Columns(3).Width = 100
            dgvDaftar.Columns(4).Width = 150
            dgvDaftar.Columns(5).Width = 150
            dgvDaftar.Columns(0).HeaderText = "ID Transaksi"
            dgvDaftar.Columns(1).HeaderText = "ID Pelanggan"
            dgvDaftar.Columns(2).HeaderText = "Total Harga"
            dgvDaftar.Columns(3).HeaderText = "ID Detail"
            dgvDaftar.Columns(4).HeaderText = "ID Transaksi"
            dgvDaftar.Columns(5).HeaderText = "ID Barang"
            dgvDaftar.Columns(6).HeaderText = "Jumlah"
            dgvDaftar.Columns(7).HeaderText = "Harga"
        Catch ex As Exception
        End Try
    End Sub

    Private Sub data_transaksi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call tampilSeluruhTransaksi()
        Call aturDGV()


    End Sub
End Class