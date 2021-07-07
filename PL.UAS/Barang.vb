Public Class Barang
    Dim Loading As New Loading()
    Sub TampilGrid()
        Loading.ShowDialog()
        ' Code untuk seting tampilan GridView
        Dim judul() As String = {"Kode", "Nama", "Harga", "Stok"}
        Dim lebar() As String = {50, 130, 130, 130}
        Dim i As Integer
        DataGridView1.RowHeadersVisible = False
        DataGridView1.ColumnCount = 4
        DataGridView1.RowCount = 1
        DataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect
        DataGridView1.ColumnHeadersDefaultCellStyle.Font = New Font("Arial", 9)

        For i = 0 To DataGridView1.ColumnCount - 1
            DataGridView1.Columns(i).HeaderText = judul(i)
            DataGridView1.Columns(i).Width = lebar(i)
            DataGridView1.Columns(i).DefaultCellStyle.Font = New Font("Arial", 7)
            DataGridView1.Columns(i).DefaultCellStyle.BackColor = Color.AliceBlue
        Next


        ' Code untuk tampil data
        Dim no As Integer
        Me.DataGridView1.Rows.Clear()
        buka()
        rek.Open("Select * from tb_barang order by id_barang desc", kon, 3, 2)
        no = 1
        Do While Not rek.EOF

            Me.DataGridView1.Rows.Add(rek.Fields("id_barang").Value,
                                      rek.Fields("nama").Value,
                                      rek.Fields("harga").Value,
                                      rek.Fields("stok").Value)
            rek.MoveNext()
            no = no + 1
        Loop
        tutup()

    End Sub
    Sub ClearText()
        Me.txt_kd_barang.Text = ""
        Me.txt_nama.Text = ""
        Me.txt_harga.Text = ""
        Me.txt_stok.Text = ""
    End Sub
    Private Sub Barang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TampilGrid()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        txt_kd_barang.Text = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        txt_nama.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value
        txt_harga.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value
        txt_stok.Text = DataGridView1.Rows(e.RowIndex).Cells(3).Value
    End Sub



    Private Sub btn_tambah_Click(sender As Object, e As EventArgs) Handles btn_tambah.Click
        Loading.ShowDialog()
        Dim Sql As String
        buka()
        Sql = "INSERT INTO `tb_barang`(`id_barang`, `nama`, `harga`, `stok`) VALUES ('" & txt_kd_barang.Text & "',
                '" & txt_nama.Text & "','" & txt_harga.Text & "','" & txt_stok.Text & "')"
        kon.Execute(Sql)
        MessageBox.Show("Berhasil Tambah Barang", "Info")
        tutup()
        TampilGrid()
        ClearText()
    End Sub

    Private Sub btn_edit_Click(sender As Object, e As EventArgs) Handles btn_edit.Click
        Loading.ShowDialog()
        Dim Sql, Msg As String
        buka()
        Sql = String.Format("SELECT * FROM tb_barang WHERE id_barang = '{0}'", txt_kd_barang.Text)
        rek.Open(Sql, kon, 3, 2)
        If Not rek.EOF Then
            Sql = String.Format("UPDATE tb_barang SET nama = '{0}', harga = '{1}', stok = '{2}' where id_barang = {3} ", txt_nama.Text, txt_harga.Text, txt_stok.Text, txt_kd_barang.Text)
            kon.Execute(Sql)
            MsgBox("Berhasil Edit Barang", vbInformation, "Informasi")
        Else
            Msg = String.Format("Kode barang {0} tidak ada", txt_kd_barang.Text)
            MsgBox(Msg, vbInformation, "Informasi")
        End If
        tutup()
        TampilGrid()
        ClearText()
    End Sub

    Private Sub btn_hapus_Click(sender As Object, e As EventArgs) Handles btn_hapus.Click
        Loading.ShowDialog()
        Dim Sql, Msg As String
        buka()
        Sql = String.Format("SELECT * FROM tb_barang WHERE id_barang = '{0}'", txt_kd_barang.Text)
        rek.Open(Sql, kon, 3, 2)
        If Not rek.EOF Then
            Sql = String.Format("DELETE FROM tb_barang WHERE id_barang = '{0}'", txt_kd_barang.Text)
            kon.Execute(Sql)
            MsgBox("Berhasil Hapus Barang", vbInformation, "Informasi")
        Else
            Msg = String.Format("Kode barang {0} tidak ada", txt_kd_barang.Text)
            MsgBox(Msg, vbInformation, "Informasi")
        End If

        tutup()
        TampilGrid()
        ClearText()
    End Sub


End Class