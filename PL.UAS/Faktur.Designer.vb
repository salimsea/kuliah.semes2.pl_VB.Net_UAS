<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Faktur
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lbl_total = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lbl_banyak = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cmb_pelanggan = New System.Windows.Forms.ComboBox()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txt_kode_barang = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txt_set_potongan = New System.Windows.Forms.TextBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btn_faktur_baru = New System.Windows.Forms.Button()
        Me.btn_keluar = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.lbl_kembali = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txt_bayar = New System.Windows.Forms.TextBox()
        Me.txt_total = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_ppn = New System.Windows.Forms.TextBox()
        Me.cbx_ppn = New System.Windows.Forms.CheckBox()
        Me.txt_tot_potongan = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txt_sub_total = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.txt_tgl_faktur = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_no_faktur = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_refresh = New System.Windows.Forms.Button()
        Me.btn_hapus_baris = New System.Windows.Forms.Button()
        Me.Kode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Barang = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Harga = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Banyak = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Total = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lbl_total)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(410, 101)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Total"
        '
        'lbl_total
        '
        Me.lbl_total.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_total.ForeColor = System.Drawing.Color.Red
        Me.lbl_total.Location = New System.Drawing.Point(6, 16)
        Me.lbl_total.Name = "lbl_total"
        Me.lbl_total.Size = New System.Drawing.Size(398, 76)
        Me.lbl_total.TabIndex = 0
        Me.lbl_total.Text = "0"
        Me.lbl_total.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lbl_banyak)
        Me.GroupBox2.Location = New System.Drawing.Point(428, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(145, 101)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Banyak"
        '
        'lbl_banyak
        '
        Me.lbl_banyak.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_banyak.ForeColor = System.Drawing.Color.Red
        Me.lbl_banyak.Location = New System.Drawing.Point(6, 19)
        Me.lbl_banyak.Name = "lbl_banyak"
        Me.lbl_banyak.Size = New System.Drawing.Size(133, 73)
        Me.lbl_banyak.TabIndex = 1
        Me.lbl_banyak.Text = "0"
        Me.lbl_banyak.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cmb_pelanggan)
        Me.GroupBox3.Controls.Add(Me.Button6)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Location = New System.Drawing.Point(579, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(380, 101)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Pelanggan [Shift+F12]"
        '
        'cmb_pelanggan
        '
        Me.cmb_pelanggan.FormattingEnabled = True
        Me.cmb_pelanggan.Location = New System.Drawing.Point(70, 34)
        Me.cmb_pelanggan.Name = "cmb_pelanggan"
        Me.cmb_pelanggan.Size = New System.Drawing.Size(290, 21)
        Me.cmb_pelanggan.TabIndex = 25
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(20, 62)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(340, 23)
        Me.Button6.TabIndex = 24
        Me.Button6.Text = "Tambah Pelanggan"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(17, 37)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(35, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Nama"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Controls.Add(Me.txt_kode_barang)
        Me.GroupBox4.Controls.Add(Me.Label12)
        Me.GroupBox4.Controls.Add(Me.txt_set_potongan)
        Me.GroupBox4.Controls.Add(Me.DataGridView1)
        Me.GroupBox4.Controls.Add(Me.PictureBox2)
        Me.GroupBox4.Controls.Add(Me.PictureBox1)
        Me.GroupBox4.Controls.Add(Me.btn_faktur_baru)
        Me.GroupBox4.Controls.Add(Me.btn_keluar)
        Me.GroupBox4.Controls.Add(Me.GroupBox5)
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Controls.Add(Me.txt_bayar)
        Me.GroupBox4.Controls.Add(Me.txt_total)
        Me.GroupBox4.Controls.Add(Me.Label5)
        Me.GroupBox4.Controls.Add(Me.txt_ppn)
        Me.GroupBox4.Controls.Add(Me.cbx_ppn)
        Me.GroupBox4.Controls.Add(Me.txt_tot_potongan)
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Controls.Add(Me.txt_sub_total)
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Controls.Add(Me.Button3)
        Me.GroupBox4.Controls.Add(Me.txt_tgl_faktur)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.txt_no_faktur)
        Me.GroupBox4.Controls.Add(Me.Label1)
        Me.GroupBox4.Controls.Add(Me.btn_refresh)
        Me.GroupBox4.Controls.Add(Me.btn_hapus_baris)
        Me.GroupBox4.Location = New System.Drawing.Point(13, 120)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(946, 462)
        Me.GroupBox4.TabIndex = 1
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Faktur [F2]"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 337)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(69, 13)
        Me.Label8.TabIndex = 27
        Me.Label8.Text = "Kode Barang"
        '
        'txt_kode_barang
        '
        Me.txt_kode_barang.Location = New System.Drawing.Point(15, 358)
        Me.txt_kode_barang.Name = "txt_kode_barang"
        Me.txt_kode_barang.Size = New System.Drawing.Size(168, 20)
        Me.txt_kode_barang.TabIndex = 26
        Me.txt_kode_barang.Text = "0"
        Me.txt_kode_barang.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(598, 365)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(15, 13)
        Me.Label12.TabIndex = 25
        Me.Label12.Text = "%"
        '
        'txt_set_potongan
        '
        Me.txt_set_potongan.Location = New System.Drawing.Point(574, 362)
        Me.txt_set_potongan.MaxLength = 100
        Me.txt_set_potongan.Name = "txt_set_potongan"
        Me.txt_set_potongan.Size = New System.Drawing.Size(20, 20)
        Me.txt_set_potongan.TabIndex = 24
        '
        'DataGridView1
        '
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Kode, Me.Barang, Me.Harga, Me.Banyak, Me.Total})
        Me.DataGridView1.Location = New System.Drawing.Point(15, 29)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(742, 288)
        Me.DataGridView1.TabIndex = 23
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.PL.UAS.My.Resources.Resources.Screenshot_3
        Me.PictureBox2.Location = New System.Drawing.Point(787, 28)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(139, 99)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 22
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.PL.UAS.My.Resources.Resources.Screenshot_4
        Me.PictureBox1.Location = New System.Drawing.Point(787, 174)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(139, 111)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 21
        Me.PictureBox1.TabStop = False
        '
        'btn_faktur_baru
        '
        Me.btn_faktur_baru.Location = New System.Drawing.Point(787, 141)
        Me.btn_faktur_baru.Name = "btn_faktur_baru"
        Me.btn_faktur_baru.Size = New System.Drawing.Size(139, 23)
        Me.btn_faktur_baru.TabIndex = 20
        Me.btn_faktur_baru.Text = "[F5] - Faktur Baru"
        Me.btn_faktur_baru.UseVisualStyleBackColor = True
        '
        'btn_keluar
        '
        Me.btn_keluar.Location = New System.Drawing.Point(787, 422)
        Me.btn_keluar.Name = "btn_keluar"
        Me.btn_keluar.Size = New System.Drawing.Size(139, 23)
        Me.btn_keluar.TabIndex = 19
        Me.btn_keluar.Text = "[ESC] - Keluar"
        Me.btn_keluar.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.lbl_kembali)
        Me.GroupBox5.Location = New System.Drawing.Point(787, 358)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(139, 56)
        Me.GroupBox5.TabIndex = 2
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Kembali"
        '
        'lbl_kembali
        '
        Me.lbl_kembali.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_kembali.ForeColor = System.Drawing.Color.Red
        Me.lbl_kembali.Location = New System.Drawing.Point(3, 16)
        Me.lbl_kembali.Name = "lbl_kembali"
        Me.lbl_kembali.Size = New System.Drawing.Size(130, 28)
        Me.lbl_kembali.TabIndex = 0
        Me.lbl_kembali.Text = "0"
        Me.lbl_kembali.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(784, 367)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(0, 13)
        Me.Label7.TabIndex = 18
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(784, 303)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(34, 13)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Bayar"
        '
        'txt_bayar
        '
        Me.txt_bayar.Location = New System.Drawing.Point(787, 324)
        Me.txt_bayar.Name = "txt_bayar"
        Me.txt_bayar.Size = New System.Drawing.Size(139, 20)
        Me.txt_bayar.TabIndex = 15
        Me.txt_bayar.Text = "0"
        Me.txt_bayar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_total
        '
        Me.txt_total.Location = New System.Drawing.Point(618, 423)
        Me.txt_total.Name = "txt_total"
        Me.txt_total.Size = New System.Drawing.Size(139, 20)
        Me.txt_total.TabIndex = 14
        Me.txt_total.Text = "0"
        Me.txt_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(518, 426)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(31, 13)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Total"
        '
        'txt_ppn
        '
        Me.txt_ppn.Location = New System.Drawing.Point(618, 392)
        Me.txt_ppn.Name = "txt_ppn"
        Me.txt_ppn.Size = New System.Drawing.Size(139, 20)
        Me.txt_ppn.TabIndex = 12
        Me.txt_ppn.Text = "0"
        Me.txt_ppn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cbx_ppn
        '
        Me.cbx_ppn.AutoSize = True
        Me.cbx_ppn.Location = New System.Drawing.Point(521, 394)
        Me.cbx_ppn.Name = "cbx_ppn"
        Me.cbx_ppn.Size = New System.Drawing.Size(48, 17)
        Me.cbx_ppn.TabIndex = 11
        Me.cbx_ppn.Text = "PPN"
        Me.cbx_ppn.UseVisualStyleBackColor = True
        '
        'txt_tot_potongan
        '
        Me.txt_tot_potongan.Location = New System.Drawing.Point(618, 362)
        Me.txt_tot_potongan.Name = "txt_tot_potongan"
        Me.txt_tot_potongan.Size = New System.Drawing.Size(139, 20)
        Me.txt_tot_potongan.TabIndex = 10
        Me.txt_tot_potongan.Text = "0"
        Me.txt_tot_potongan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(518, 365)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Potongan"
        '
        'txt_sub_total
        '
        Me.txt_sub_total.Location = New System.Drawing.Point(618, 332)
        Me.txt_sub_total.Name = "txt_sub_total"
        Me.txt_sub_total.Size = New System.Drawing.Size(139, 20)
        Me.txt_sub_total.TabIndex = 8
        Me.txt_sub_total.Text = "0"
        Me.txt_sub_total.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(518, 335)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Sub Total"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(237, 394)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(236, 51)
        Me.Button3.TabIndex = 6
        Me.Button3.Text = "[F4] - Tambah Barang"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'txt_tgl_faktur
        '
        Me.txt_tgl_faktur.Location = New System.Drawing.Point(334, 364)
        Me.txt_tgl_faktur.Name = "txt_tgl_faktur"
        Me.txt_tgl_faktur.Size = New System.Drawing.Size(139, 20)
        Me.txt_tgl_faktur.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(234, 367)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Tgl. Faktur"
        '
        'txt_no_faktur
        '
        Me.txt_no_faktur.Location = New System.Drawing.Point(334, 334)
        Me.txt_no_faktur.Name = "txt_no_faktur"
        Me.txt_no_faktur.Size = New System.Drawing.Size(139, 20)
        Me.txt_no_faktur.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(234, 337)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "No. Faktur Jual"
        '
        'btn_refresh
        '
        Me.btn_refresh.Location = New System.Drawing.Point(15, 420)
        Me.btn_refresh.Name = "btn_refresh"
        Me.btn_refresh.Size = New System.Drawing.Size(168, 23)
        Me.btn_refresh.TabIndex = 1
        Me.btn_refresh.Text = "[F1] - Refresh Barang"
        Me.btn_refresh.UseVisualStyleBackColor = True
        '
        'btn_hapus_baris
        '
        Me.btn_hapus_baris.Location = New System.Drawing.Point(15, 387)
        Me.btn_hapus_baris.Name = "btn_hapus_baris"
        Me.btn_hapus_baris.Size = New System.Drawing.Size(168, 23)
        Me.btn_hapus_baris.TabIndex = 0
        Me.btn_hapus_baris.Text = "[F12] - Hapus Baris"
        Me.btn_hapus_baris.UseVisualStyleBackColor = True
        '
        'Kode
        '
        Me.Kode.HeaderText = "Kode"
        Me.Kode.Name = "Kode"
        Me.Kode.Width = 135
        '
        'Barang
        '
        Me.Barang.HeaderText = "Barang"
        Me.Barang.Name = "Barang"
        Me.Barang.Width = 180
        '
        'Harga
        '
        Me.Harga.HeaderText = "Harga"
        Me.Harga.Name = "Harga"
        Me.Harga.Width = 130
        '
        'Banyak
        '
        Me.Banyak.HeaderText = "Banyak"
        Me.Banyak.Name = "Banyak"
        '
        'Total
        '
        Me.Total.HeaderText = "Total"
        Me.Total.Name = "Total"
        Me.Total.Width = 150
        '
        'Faktur
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(974, 595)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.IsMdiContainer = True
        Me.Name = "Faktur"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CASEER"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents txt_no_faktur As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btn_refresh As Button
    Friend WithEvents btn_hapus_baris As Button
    Friend WithEvents txt_tgl_faktur As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents btn_faktur_baru As Button
    Friend WithEvents btn_keluar As Button
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txt_bayar As TextBox
    Friend WithEvents txt_total As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txt_ppn As TextBox
    Friend WithEvents cbx_ppn As CheckBox
    Friend WithEvents txt_tot_potongan As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txt_sub_total As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents lbl_total As Label
    Friend WithEvents lbl_banyak As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents cmb_pelanggan As ComboBox
    Friend WithEvents Button6 As Button
    Friend WithEvents Label10 As Label
    Friend WithEvents lbl_kembali As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents txt_set_potongan As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txt_kode_barang As TextBox
    Friend WithEvents Kode As DataGridViewTextBoxColumn
    Friend WithEvents Barang As DataGridViewTextBoxColumn
    Friend WithEvents Harga As DataGridViewTextBoxColumn
    Friend WithEvents Banyak As DataGridViewTextBoxColumn
    Friend WithEvents Total As DataGridViewTextBoxColumn
End Class
