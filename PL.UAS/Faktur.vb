Public Class Faktur
    Dim Loading As New Loading()
    Public Sub GetData()
        Loading.ShowDialog()

        ' Code untuk tampil data
        Dim no As Integer
        Dim total As Integer
        Dim jumlah As Integer

        Me.DataGridView1.Rows.Clear()
        buka()
        rek.Open("select b.id_barang, b.nama, b.harga, a.jml_beli 
        from tb_transaksi a, 
        tb_barang b 
        where a.no_faktur='" & txt_no_faktur.Text & "' 
        and a.id_barang = b.id_barang 
        order by id_transaksi desc", kon, 3, 2)
        no = 1
        total = 0
        Do While Not rek.EOF

            Me.DataGridView1.Rows.Add(rek.Fields("id_barang").Value, rek.Fields("nama").Value, rek.Fields("harga").Value, rek.Fields("jml_beli").Value, rek.Fields("harga").Value * rek.Fields("jml_beli").Value)

            no = no + 1
            jumlah = rek.Fields("harga").Value * rek.Fields("jml_beli").Value
            total = total + jumlah
            rek.MoveNext()
        Loop
        tutup()
    End Sub

    Private Sub Faktur_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Loading.ShowDialog()
        'Dim judul() As String = {"Kode", "Item", "Harga", "Banyak", "Total"}
        'Dim lebar() As String = {135, 250, 100, 100, 150}
        'Dim i As Integer
        'DataGridView1.RowHeadersVisible = False
        'DataGridView1.ColumnCount = 5
        'DataGridView1.RowCount = 1
        'DataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect
        'DataGridView1.ColumnHeadersDefaultCellStyle.Font = New Font("Arial", 11)

        'For i = 0 To DataGridView1.ColumnCount - 1
        '    DataGridView1.Columns(i).HeaderText = judul(i)
        '    DataGridView1.Columns(i).Width = lebar(i)
        '    DataGridView1.Columns(i).DefaultCellStyle.Font = New Font("Arial", 9)
        '    DataGridView1.Columns(i).DefaultCellStyle.BackColor = Color.AliceBlue
        'Next

        buka()
        rek.Open("select * from tb_pelanggan", kon, 3, 2)
        Do While Not rek.EOF
            cmb_pelanggan.Items.Add(rek.Fields("nama").Value)
            rek.MoveNext()
        Loop
        tutup()

    End Sub

    Public Sub FakturBaru()
        Loading.ShowDialog()
        txt_sub_total.Text = "0"
        lbl_total.Text = "0"
        lbl_banyak.Text = "0"
        txt_total.Text = "0"
        txt_bayar.Text = "0"
        lbl_kembali.Text = "0"

        If String.IsNullOrEmpty(cmb_pelanggan.Text) Then
            MessageBox.Show("Pilih nama pelanggan dahulu!", "Info")
            Return
        End If

        buka()
        rek.Open("Select * from tb_transaksi", kon, 3, 2)
        Me.txt_tgl_faktur.Text = DateTime.Now.ToString("yyyy-MM-dd")
        If Not rek.EOF Then
            Dim count As Integer = rek.PageCount
            rek.Close()

            rek.Open("Select max(no_faktur)+1 as struk from tb_transaksi", kon, 3, 2)
            If Not rek.EOF Then
                Me.txt_no_faktur.Text = DateTime.Now.ToString("yyyyMMddHHmmss")
            End If
        Else
            Me.txt_no_faktur.Text = DateTime.Now.ToString("yyyyMMddHHmmss")

        End If
        tutup()

        GetData()
    End Sub
    Private Sub btn_faktur_baru_Click(sender As Object, e As EventArgs) Handles btn_faktur_baru.Click
        FakturBaru()
    End Sub
    Private Sub DataGridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
    Handles DataGridView1.KeyDown
        If e.KeyCode = Keys.Tab Then
            Dim CurrentCell As DataGridViewCell = DataGridView1.CurrentCell
            Dim row As Integer = CurrentCell.RowIndex
            Dim KdBarang, NamaBarang, Harga, Jumlah, JumlahLama, JumlahRead, TotalHarga, TotalHargaLama As String

            If String.IsNullOrEmpty(txt_no_faktur.Text) Then
                MessageBox.Show("Buat nomor faktur terlebih dahulu!", "Info")
                DataGridView1.Rows(row).Cells(0).Value = ""
                DataGridView1.Rows(row).Cells(1).Value = ""
                DataGridView1.Rows(row).Cells(2).Value = ""
                DataGridView1.Rows(row).Cells(3).Value = ""
                DataGridView1.Rows(row).Cells(4).Value = ""
            End If


            If DataGridView1.Rows(row).Cells(3).Value <> Nothing Then
                KdBarang = DataGridView1.Rows(row).Cells(0).Value.ToString()
                Jumlah = DataGridView1.Rows(row).Cells(3).Value.ToString()
                JumlahRead = DataGridView1.Rows(row).Cells(3).Value.ToString()



                If DataGridView1.Rows(row).Cells(4).Value <> Nothing Then
                    Loading.ShowDialog()
                    TotalHargaLama = DataGridView1.Rows(row).Cells(4).Value.ToString()
                    buka()
                    Dim Sql As String = String.Format("SELECT * FROM tb_barang where id_barang = {0}", KdBarang)
                    rek.Open(Sql, kon, 3, 2)
                    If Not rek.EOF Then
                        NamaBarang = rek.Fields("nama").Value
                        Harga = rek.Fields("harga").Value
                        TotalHarga = rek.Fields("harga").Value * Jumlah

                        DataGridView1.Rows(row).Cells(1).Value = NamaBarang
                        DataGridView1.Rows(row).Cells(2).Value = Harga
                        DataGridView1.Rows(row).Cells(4).Value = TotalHarga

                        rek.Close()
                        Sql = String.Format("SELECT * FROM tb_transaksi where no_faktur = '{0}' AND id_barang = {1}", txt_no_faktur.Text, KdBarang)
                        rek.Open(Sql, kon, 3, 2)
                        If Not rek.EOF Then
                            JumlahLama = rek.Fields("jml_beli").Value
                        End If

                        TotalHarga = If(String.IsNullOrEmpty(txt_sub_total.Text), 0, CInt(txt_sub_total.Text)) + CInt(TotalHarga) - CInt(TotalHargaLama)
                        Jumlah = If(String.IsNullOrEmpty(lbl_banyak.Text), 0, CInt(lbl_banyak.Text)) + CInt(Jumlah) - CInt(JumlahLama)
                        txt_sub_total.Text = TotalHarga
                        txt_total.Text = TotalHarga
                        lbl_total.Text = TotalHarga
                        lbl_banyak.Text = Jumlah
                        Sql = String.Format("UPDATE tb_transaksi SET jml_beli = {0} WHERE no_faktur = '{1}' AND id_barang = {2}", JumlahRead, txt_no_faktur.Text, KdBarang)
                        kon.Execute(Sql)
                        MessageBox.Show("Berhasil Perbarui Keranjang", "Info")

                        txt_set_potongan.Text = "0"
                        txt_tot_potongan.Text = "0"
                        txt_ppn.Text = "0"
                        cbx_ppn.Checked = False
                        txt_bayar.Text = "0"
                        lbl_kembali.Text = "0"


                    End If
                    tutup()
                Else
                    buka()
                    Dim Sql As String = String.Format("SELECT * FROM tb_barang where id_barang = {0}", KdBarang)
                    rek.Open(Sql, kon, 3, 2)
                    If Not rek.EOF Then
                        Loading.ShowDialog()
                        NamaBarang = rek.Fields("nama").Value
                        Harga = rek.Fields("harga").Value
                        TotalHarga = rek.Fields("harga").Value * Jumlah

                        DataGridView1.Rows(row).Cells(1).Value = NamaBarang
                        DataGridView1.Rows(row).Cells(2).Value = Harga
                        DataGridView1.Rows(row).Cells(4).Value = TotalHarga

                        TotalHarga = If(String.IsNullOrEmpty(txt_sub_total.Text), 0, CInt(txt_sub_total.Text)) + CInt(TotalHarga)
                        Jumlah = If(String.IsNullOrEmpty(lbl_banyak.Text), 0, CInt(lbl_banyak.Text)) + CInt(Jumlah)
                        txt_sub_total.Text = TotalHarga
                        txt_total.Text = TotalHarga
                        lbl_total.Text = TotalHarga
                        lbl_banyak.Text = Jumlah

                        rek.Close()
                        Dim IdPelanggan As Integer
                        Sql = String.Format("SELECT * FROM tb_pelanggan where nama = '{0}'", cmb_pelanggan.Text)
                        rek.Open(Sql, kon, 3, 2)
                        If Not rek.EOF Then
                            IdPelanggan = rek.Fields("id_pelanggan").Value
                        End If

                        Sql = "INSERT INTO `tb_transaksi`(`id_pelanggan`, `id_barang`, `no_faktur`, `jml_beli`, `tgl_beli`) VALUES ('" & IdPelanggan & "','" & KdBarang & "','" & txt_no_faktur.Text & "','" & JumlahRead & "' ,'" & txt_tgl_faktur.Text & "')"
                        kon.Execute(Sql)
                        MessageBox.Show("Berhasil Tambah Keranjang", "Info")
                    Else
                        DataGridView1.Rows(row).Cells(0).Value = ""
                        DataGridView1.Rows(row).Cells(1).Value = ""
                        DataGridView1.Rows(row).Cells(2).Value = ""
                        DataGridView1.Rows(row).Cells(3).Value = ""
                        DataGridView1.Rows(row).Cells(4).Value = ""

                        MessageBox.Show("Barang tidak ditemukan", "Info")
                    End If

                    tutup()
                End If

            End If

            If DataGridView1.Rows(row).Cells(0).Value <> Nothing Then
                KdBarang = DataGridView1.Rows(row).Cells(0).Value.ToString()
                buka()
                Dim Sql As String = String.Format("SELECT * FROM tb_barang where id_barang = {0}", KdBarang)
                rek.Open(Sql, kon, 3, 2)
                If Not rek.EOF Then
                    NamaBarang = rek.Fields("nama").Value
                    Harga = rek.Fields("harga").Value
                    DataGridView1.Rows(row).Cells(1).Value = NamaBarang
                    DataGridView1.Rows(row).Cells(2).Value = Harga
                Else
                    DataGridView1.Rows(row).Cells(0).Value = ""
                    MessageBox.Show("Barang tidak ditemukan", "Info")
                End If

                tutup()
            End If
        End If


    End Sub

    Private Sub cmb_pelanggan_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_pelanggan.SelectedIndexChanged
        Loading.ShowDialog()
        MessageBox.Show("Pelanggan (" + cmb_pelanggan.Text + ") berhasil dipilih!", "Info")
    End Sub

    Private Sub txt_set_potongan_TextChanged(sender As Object, e As EventArgs) Handles txt_set_potongan.TextChanged
        txt_tot_potongan.Text = CInt(txt_sub_total.Text) * If(String.IsNullOrEmpty(txt_set_potongan.Text), 0, CInt(txt_set_potongan.Text)) / 100
    End Sub

    Private Sub txt_set_potongan_KeyPress(sender As Object, e As EventArgs) Handles txt_set_potongan.KeyPress
        Dim tmp As System.Windows.Forms.KeyPressEventArgs = e
        If tmp.KeyChar = ChrW(Keys.Enter) Then
            Loading.ShowDialog()
            If String.IsNullOrEmpty(txt_set_potongan.Text) = False Then
                MessageBox.Show("Potongan " + txt_set_potongan.Text + "% berhasil dipasang", "Info")
                Dim Tot As Integer = CInt(txt_sub_total.Text) - CInt(txt_tot_potongan.Text) + CInt(txt_ppn.Text)
                txt_total.Text = Tot
                lbl_total.Text = Tot
                Loading.ShowDialog()
            Else
                Dim Tot As Integer = CInt(txt_sub_total.Text) + CInt(txt_ppn.Text)
                txt_total.Text = Tot
                lbl_total.Text = Tot
            End If
        End If
    End Sub

    Private Sub cbx_ppn_CheckedChanged(sender As Object, e As EventArgs) Handles cbx_ppn.CheckedChanged
        Loading.ShowDialog()
        If cbx_ppn.Checked Then
            txt_ppn.Text = "15000"
            Dim Tot As Integer = CInt(txt_sub_total.Text) - CInt(txt_tot_potongan.Text) + CInt(txt_ppn.Text)
            txt_total.Text = Tot
            lbl_total.Text = Tot
        Else
            Dim Tot As Integer = CInt(txt_total.Text) - CInt(txt_ppn.Text)
            txt_total.Text = Tot
            lbl_total.Text = Tot
            txt_ppn.Text = "0"
        End If
    End Sub

    Private Sub txt_bayar_KeyPress(sender As Object, e As EventArgs) Handles txt_bayar.KeyPress
        Dim tmp As System.Windows.Forms.KeyPressEventArgs = e
        If tmp.KeyChar = ChrW(Keys.Enter) Then
            Loading.ShowDialog()
            If String.IsNullOrEmpty(txt_bayar.Text) = False Then
                Dim Tot As String = CInt(txt_bayar.Text) - CInt(txt_total.Text)
                MessageBox.Show("Siapkan Kembalian :  " + Tot, "Info")
                lbl_kembali.Text = Tot
            End If
        End If
    End Sub


    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim selectedRowIndex As Integer
        selectedRowIndex = e.RowIndex
        Dim row As New DataGridViewRow()

        row = DataGridView1.Rows(selectedRowIndex)
        Dim KdBarang As String
        If row.Cells(0).Value <> Nothing Then
            KdBarang = row.Cells(0).Value.ToString()
            txt_kode_barang.Text = KdBarang
        End If

    End Sub
    Public Sub HapusBaris()
        Dim Sql, KdBarang, NoFaktur, IdPelanggan As String
        KdBarang = txt_kode_barang.Text
        NoFaktur = txt_no_faktur.Text

        If KdBarang = "" Then
            MessageBox.Show("Kode barang tidak dipilih!", "Info")
        End If

        Dim result As DialogResult = MessageBox.Show("Apakah anda yakin ingin hapus kode barang (" + KdBarang + ")", "Info", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            Loading.ShowDialog()
            buka()
            Sql = String.Format("SELECT * FROM tb_pelanggan where nama = '{0}'", cmb_pelanggan.Text)
            rek.Open(Sql, kon, 3, 2)
            If Not rek.EOF Then
                IdPelanggan = rek.Fields("id_pelanggan").Value
            End If

            rek.Close()
            Sql = String.Format("SELECT a.jml_beli, b.harga FROM tb_transaksi a join tb_barang b on a.id_barang = b.id_barang  where a.id_barang = '{0}' AND a.id_pelanggan = {1} AND a.no_faktur = '{2}'", KdBarang, IdPelanggan, NoFaktur)
            rek.Open(Sql, kon, 3, 2)
            If Not rek.EOF Then
                lbl_banyak.Text = CInt(lbl_banyak.Text) - CInt(rek.Fields("jml_beli").Value)
                txt_sub_total.Text = CInt(txt_sub_total.Text) - (CInt(rek.Fields("harga").Value) * CInt(rek.Fields("jml_beli").Value))
                txt_set_potongan.Text = "0"
                txt_tot_potongan.Text = "0"
                cbx_ppn.Checked = False
                txt_ppn.Text = "0"
                txt_total.Text = txt_sub_total.Text
                lbl_total.Text = txt_sub_total.Text
                txt_bayar.Text = "0"
                lbl_kembali.Text = "0"
            End If

            Sql = "DELETE FROM tb_transaksi WHERE id_barang = '" & KdBarang & "' AND id_pelanggan = '" & IdPelanggan & "' AND no_faktur = '" & NoFaktur & "' "
            kon.Execute(Sql)
            tutup()

            GetData()
            MessageBox.Show("Data berhasil dihapus!", "Info")
            txt_kode_barang.Text = "0"
        End If
    End Sub
    Private Sub btn_hapus_baris_Click(sender As Object, e As EventArgs) Handles btn_hapus_baris.Click
        HapusBaris()
    End Sub
    Private Sub txt_kode_barang_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txt_kode_barang.KeyDown
        If e.KeyCode = Keys.F12 Then
            HapusBaris()
        End If
    End Sub

    Private Sub btn_keluar_Click(sender As Object, e As EventArgs) Handles btn_keluar.Click
        Loading.ShowDialog()
        Me.Close()
    End Sub

    Private Sub btn_refresh_Click(sender As Object, e As EventArgs) Handles btn_refresh.Click
        GetData()
    End Sub


    Private Sub btn_refresh_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles btn_refresh.KeyDown
        If e.KeyCode = Keys.F12 Then
            HapusBaris()
        End If
        If e.KeyCode = Keys.F1 Then
            GetData()
        End If
    End Sub

    Protected Overrides Function ProcessDialogKey(keyData As Keys) As Boolean
        If keyData = Keys.F12 Then
            HapusBaris()
        End If
        If keyData = Keys.F1 Then
            GetData()
        End If
        If keyData = Keys.F5 Then
            FakturBaru()
        End If
        If keyData = Keys.Escape Then
            Me.Close()
        End If
        If keyData = Keys.F2 Then
            DataGridView1.ClearSelection()
            DataGridView1.CurrentCell = DataGridView1.Item("Kode", 0)

            DataGridView1.BeginEdit(True)

        End If

        Return MyBase.ProcessDialogKey(keyData)
    End Function


    'Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_pelanggan.SelectedIndexChanged
    '    buka()
    '    rek.Open("select * from tb_pelanggan", kon, 3, 2)
    '    If Not rek.EOF Then
    '        Me.cmb_pelanggan.Text = rek.Fields("nama").Value
    '    End If
    '    tutup()
    'End Sub
End Class
