Public Class main_menu

    Private Sub MasterBarangToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MasterBarangToolStripMenuItem.Click
        master_barang.Show()
        Me.Hide()
    End Sub

    Private Sub BarangToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BarangToolStripMenuItem.Click

    End Sub

    Private Sub MasterPelangganToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MasterPelangganToolStripMenuItem.Click
        master_pelanggan.Show()
        Me.Hide()
    End Sub

    Private Sub FormTransaksiToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FormTransaksiToolStripMenuItem.Click
        Form_transaksi.Show()
        Me.Hide()
    End Sub

    Private Sub DataTransaksiToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataTransaksiToolStripMenuItem.Click
        data_transaksi.Show()
        Me.Hide()
    End Sub
End Class
