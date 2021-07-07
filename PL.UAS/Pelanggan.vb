Public Class Pelanggan
    Dim Loading As New Loading()
    Sub TampilGrid()
        Loading.ShowDialog()
        ' Code untuk seting tampilan GridView
        Dim judul() As String = {"Id", "Nama Pelanggan", "No Handphone"}
        Dim lebar() As String = {50, 190, 170}
        Dim i As Integer
        DataGridView1.RowHeadersVisible = False
        DataGridView1.ColumnCount = 3
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
        rek.Open("Select * from tb_pelanggan order by id_pelanggan desc", kon, 3, 2)
        no = 1
        Do While Not rek.EOF

            Me.DataGridView1.Rows.Add(rek.Fields("id_pelanggan").Value,
                                      rek.Fields("nama").Value,
                                      rek.Fields("no_hp").Value)
            rek.MoveNext()
            no = no + 1
        Loop
        tutup()

    End Sub
    Sub ClearText()
        Me.txt_id_pelanggan.Text = ""
        Me.txt_nama.Text = ""
        Me.txt_no_hp.Text = ""

    End Sub
    Private Sub Pelanggan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TampilGrid()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        txt_id_pelanggan.Text = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        txt_nama.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value
        txt_no_hp.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value
    End Sub



    Private Sub btn_tambah_Click(sender As Object, e As EventArgs) Handles btn_tambah.Click
        Loading.ShowDialog()
        Dim Sql As String
        buka()
        Sql = "INSERT INTO `tb_pelanggan`(`id_pelanggan`, `nama`, `no_hp`) VALUES ( '" & txt_id_pelanggan.Text & "','" & txt_nama.Text & "','" & txt_no_hp.Text & "')"
        kon.Execute(Sql)
        MessageBox.Show("Berhasil Tambah Pelanggan", "Info")
        tutup()
        TampilGrid()
        ClearText()
    End Sub

    Private Sub btn_edit_Click(sender As Object, e As EventArgs) Handles btn_edit.Click
        Loading.ShowDialog()
        Dim Sql, Msg As String
        buka()
        Sql = String.Format("SELECT * FROM tb_pelanggan WHERE id_pelanggan = '{0}'", txt_id_pelanggan.Text)
        rek.Open(Sql, kon, 3, 2)
        If Not rek.EOF Then
            Sql = String.Format("UPDATE tb_pelanggan SET nama = '{0}', no_hp = '{1}' where id_pelanggan = {2} ", txt_nama.Text, txt_no_hp.Text, txt_id_pelanggan.Text)
            kon.Execute(Sql)
            MsgBox("Berhasil Edit Pelanggan", vbInformation, "Informasi")
        Else
            Msg = String.Format("ID Pelanggan {0} tidak ada", txt_id_pelanggan.Text)
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
        Sql = String.Format("SELECT * FROM tb_pelanggan WHERE id_pelanggan = '{0}'", txt_id_pelanggan.Text)
        rek.Open(Sql, kon, 3, 2)
        If Not rek.EOF Then
            Sql = String.Format("DELETE FROM tb_pelanggan WHERE id_pelanggan = '{0}'", txt_id_pelanggan.Text)
            kon.Execute(Sql)
            MsgBox("Berhasil Hapus Pelanggan", vbInformation, "Informasi")
        Else
            Msg = String.Format("ID Pelanggan {0} tidak ada", txt_id_pelanggan.Text)
            MsgBox(Msg, vbInformation, "Informasi")
        End If

        tutup()
        TampilGrid()
        ClearText()
    End Sub


End Class