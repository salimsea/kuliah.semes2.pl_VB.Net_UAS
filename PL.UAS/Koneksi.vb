Module Koneksi
    Public kon As New ADODB.Connection
    Public rek As New ADODB.Recordset

    Public Sub buka()
        kon.Open("DSN=db_uas")
    End Sub

    Public Sub tutup()
        kon.Close()
    End Sub

End Module