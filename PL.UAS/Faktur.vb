Public Class Faktur
    Public Sub GetData()
        ' Code untuk tampil data
        Dim no As Integer
        Dim total As Integer
        Dim jumlah As Integer

        Me.DataGridView1.Rows.Clear()
        buka()
        rek.Open("select b.nama, b.harga, a.jml_beli 
        from tb_transaksi a, 
        tb_barang b 
        where a.no_faktur='" & txt_no_faktur.Text & "' 
        and a.id_barang = b.id_barang 
        order by id_transaksi desc", kon, 3, 2)
        no = 1
        total = 0
        Do While Not rek.EOF

            Me.DataGridView1.Rows.Add(no, rek.Fields("nama").Value, rek.Fields("harga").Value, rek.Fields("jumlah_beli").Value, rek.Fields("harga").Value * rek.Fields("jumlah_beli").Value)

            no = no + 1
            jumlah = rek.Fields("harga").Value * rek.Fields("jumlah_beli").Value
            total = total + jumlah
            rek.MoveNext()
        Loop
        tutup()
    End Sub

    Private Sub Faktur_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim judul() As String = {"Kode", "Item", "Harga", "Banyak", "Total"}
        Dim lebar() As String = {135, 250, 100, 100, 150}
        Dim i As Integer
        DataGridView1.RowHeadersVisible = False
        DataGridView1.ColumnCount = 5
        DataGridView1.RowCount = 1
        DataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect
        DataGridView1.ColumnHeadersDefaultCellStyle.Font = New Font("Arial", 11)

        For i = 0 To DataGridView1.ColumnCount - 1
            DataGridView1.Columns(i).HeaderText = judul(i)
            DataGridView1.Columns(i).Width = lebar(i)
            DataGridView1.Columns(i).DefaultCellStyle.Font = New Font("Arial", 9)
            DataGridView1.Columns(i).DefaultCellStyle.BackColor = Color.AliceBlue
        Next

        buka()
        rek.Open("select * from tb_pelanggan", kon, 3, 2)
        Do While Not rek.EOF
            cmb_pelanggan.Items.Add(rek.Fields("nama").Value)
            rek.MoveNext()
        Loop
        tutup()
    End Sub

    Private Sub btn_faktur_baru_Click(sender As Object, e As EventArgs) Handles btn_faktur_baru.Click
        txt_sub_total.Text = ""
        lbl_total.Text = ""
        lbl_banyak.Text = ""
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
    Private Sub DataGridView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
    Handles DataGridView1.KeyDown
        Dim CurrentCell As DataGridViewCell = DataGridView1.CurrentCell
        Dim row As Integer = CurrentCell.RowIndex
        Dim KdBarang, NamaBarang, Harga, Jumlah, JumlahLama, TotalHarga, TotalHargaLama As String

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


            If DataGridView1.Rows(row).Cells(4).Value <> Nothing Then
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
                    Sql = String.Format("UPDATE tb_transaksi SET jml_beli = {0} WHERE no_faktur = '{1}' AND id_barang = {2}", Jumlah, txt_no_faktur.Text, KdBarang)
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

                    Sql = "INSERT INTO `tb_transaksi`(`id_pelanggan`, `id_barang`, `no_faktur`, `jml_beli`, `tgl_beli`) VALUES ('" & IdPelanggan & "','" & KdBarang & "','" & txt_no_faktur.Text & "','" & Jumlah & "' ,'" & txt_tgl_faktur.Text & "')"
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

    End Sub

    Private Sub cmb_pelanggan_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_pelanggan.SelectedIndexChanged
        MessageBox.Show("Pelanggan (" + cmb_pelanggan.Text + ") berhasil dipilih!", "Info")
    End Sub

    Private Sub txt_set_potongan_TextChanged(sender As Object, e As EventArgs) Handles txt_set_potongan.TextChanged
        txt_tot_potongan.Text = CInt(txt_sub_total.Text) * If(String.IsNullOrEmpty(txt_set_potongan.Text), 0, CInt(txt_set_potongan.Text)) / 100
    End Sub

    Private Sub txt_set_potongan_KeyPress(sender As Object, e As EventArgs) Handles txt_set_potongan.KeyPress
        Dim tmp As System.Windows.Forms.KeyPressEventArgs = e
        If tmp.KeyChar = ChrW(Keys.Enter) Then
            If String.IsNullOrEmpty(txt_set_potongan.Text) = False Then
                MessageBox.Show("Potongan " + txt_set_potongan.Text + "% berhasil dipasang", "Info")
                Dim Tot As Integer = CInt(txt_sub_total.Text) - CInt(txt_tot_potongan.Text) + CInt(txt_ppn.Text)
                txt_total.Text = Tot
                lbl_total.Text = Tot
            Else
                Dim Tot As Integer = CInt(txt_sub_total.Text) + CInt(txt_ppn.Text)
                txt_total.Text = Tot
                lbl_total.Text = Tot
            End If
        End If
    End Sub

    Private Sub cbx_ppn_CheckedChanged(sender As Object, e As EventArgs) Handles cbx_ppn.CheckedChanged
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
            If String.IsNullOrEmpty(txt_bayar.Text) = False Then
                Dim Tot As String = CInt(txt_bayar.Text) - CInt(txt_total.Text)
                MessageBox.Show("Siapkan Kembalian :  " + Tot, "Info")
                lbl_kembali.Text = Tot
            End If
        End If
    End Sub



    'Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_pelanggan.SelectedIndexChanged
    '    buka()
    '    rek.Open("select * from tb_pelanggan", kon, 3, 2)
    '    If Not rek.EOF Then
    '        Me.cmb_pelanggan.Text = rek.Fields("nama").Value
    '    End If
    '    tutup()
    'End Sub
End Class
