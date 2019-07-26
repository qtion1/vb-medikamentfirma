Imports System.Data.SqlClient
Public Class Insert_Search_Form
    Dim connection As SqlConnection = New SqlConnection()
    Dim bool_DateZwischen As Boolean
    Dim bool_Alle As Boolean
    Dim bool_faelligRechnungCheck As Boolean
    Dim bool_nummerSearch As Boolean
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Text = "Datum:"
        Label2.Visible = False
        DateTimePicker2.Visible = False
        connection.ConnectionString = "Data source=.\SQLExpress;Initial Catalog=MedikamentFirma1;Integrated Security=True"
        connection.Open()
        Dim adp As SqlDataAdapter = New SqlDataAdapter("SELECT RechnungsNr, AuftragsNr, RechnungsDatum, BegleichungsDatum, Soll, Haben FROM Rechnung", connection)
        Dim ds As DataSet = New DataSet()
        adp.Fill(ds)
        DataGridView1.DataSource = ds.Tables(0)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If bool_nummerSearch = True Then
            Dim begleichung_adp As SqlDataAdapter = New SqlDataAdapter("SELECT * FROM Rechnung WHERE RechnungsNr = " + Integer.Parse(TextBox1.Text).ToString, connection)
            Dim begleichung_ds As DataSet = New DataSet()
            begleichung_adp.Fill(begleichung_ds)
            DataGridView1.DataSource = begleichung_ds.Tables(0)
        Else
            If bool_faelligRechnungCheck = False Then
                If bool_DateZwischen = True Then
                    If RadioButton1.Checked Then
                        TextBox1.Enabled = False
                        Dim rechnung_adp As SqlDataAdapter = New SqlDataAdapter("SELECT RechnungsNr, AuftragsNr, RechnungsDatum, Soll, Haben FROM Rechnung WHERE RechnungsDatum BETWEEN '" + DateTimePicker1.Value.ToString() + "' AND '" + DateTimePicker2.Value.ToString() + "' ", connection)
                        Dim rechnung_ds As DataSet = New DataSet()
                        rechnung_adp.Fill(rechnung_ds)
                        DataGridView1.DataSource = rechnung_ds.Tables(0)
                    ElseIf RadioButton2.Checked Then
                        TextBox1.Enabled = False
                        Dim begleichung_adp As SqlDataAdapter = New SqlDataAdapter("SELECT RechnungsNr, AuftragsNr, BegleichungsDatum, Soll, Haben FROM Rechnung WHERE BegleichungsDatum BETWEEN '" + DateTimePicker1.Value.ToString() + "' AND '" + DateTimePicker2.Value.ToString() + "' ", connection)
                        Dim begleichung_ds As DataSet = New DataSet()
                        begleichung_adp.Fill(begleichung_ds)
                        DataGridView1.DataSource = begleichung_ds.Tables(0)
                    Else
                        MsgBox("Lütfen Radio Button seçiniz.", MsgBoxStyle.Critical)
                    End If
                Else
                    If RadioButton1.Checked Then
                        TextBox1.Enabled = False
                        Dim rechnung_adp As SqlDataAdapter = New SqlDataAdapter("SELECT RechnungsNr, AuftragsNr, RechnungsDatum, Soll, Haben FROM Rechnung WHERE RechnungsDatum = '" + DateTimePicker1.Value.ToString() + "'", connection)
                        Dim rechnung_ds As DataSet = New DataSet()
                        rechnung_adp.Fill(rechnung_ds)
                        DataGridView1.DataSource = rechnung_ds.Tables(0)
                    ElseIf RadioButton2.Checked Then
                        TextBox1.Enabled = False
                        Dim begleichung_adp As SqlDataAdapter = New SqlDataAdapter("SELECT RechnungsNr, AuftragsNr, BegleichungsDatum, Soll, Haben FROM Rechnung WHERE BegleichungsDatum = '" + DateTimePicker1.Value.ToString() + "'", connection)
                        Dim begleichung_ds As DataSet = New DataSet()
                        begleichung_adp.Fill(begleichung_ds)
                        DataGridView1.DataSource = begleichung_ds.Tables(0)
                    Else
                        MsgBox("Lütfen Radio Button seçiniz.", MsgBoxStyle.Critical)
                    End If
                End If
            Else
                If bool_DateZwischen = True Then
                    If RadioButton2.Checked Then
                        Dim begleichung_adp As SqlDataAdapter = New SqlDataAdapter("SELECT * FROM Rechnung WHERE Soll > Haben AND (BegleichungsDatum BETWEEN '" + DateTimePicker1.Value.ToString() + "' AND '" + DateTimePicker2.Value.ToString() + "') ", connection)
                        Dim begleichung_ds As DataSet = New DataSet()
                        begleichung_adp.Fill(begleichung_ds)
                        DataGridView1.DataSource = begleichung_ds.Tables(0)
                    Else
                        MsgBox("Lütfen Radio Button seçiniz.", MsgBoxStyle.Critical)
                    End If
                Else
                    If RadioButton2.Checked Then
                        Dim begleichung_adp As SqlDataAdapter = New SqlDataAdapter("SELECT * FROM Rechnung WHERE Soll > Haben AND (BegleichungsDatum = '" + DateTimePicker1.Value.ToString() + "')", connection)
                        Dim begleichung_ds As DataSet = New DataSet()
                        begleichung_adp.Fill(begleichung_ds)
                        DataGridView1.DataSource = begleichung_ds.Tables(0)
                    Else
                        MsgBox("Lütfen Radio Button seçiniz.", MsgBoxStyle.Critical)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            bool_DateZwischen = True
            Label2.Visible = True
            DateTimePicker2.Visible = True
            Label1.Text = "Beginn:"
            TextBox1.Enabled = False
        Else
            bool_DateZwischen = False
            Label1.Text = "Datum:"
            Label2.Visible = False
            DateTimePicker2.Visible = False
            TextBox1.Enabled = True
        End If
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        If Not TextBox1.Text = "" Then
            bool_nummerSearch = True
            CheckBox1.Enabled = False
            DateTimePicker1.Enabled = False
            DateTimePicker2.Enabled = False
            RadioButton1.Enabled = False
            RadioButton2.Enabled = False
            CheckBox2.Enabled = False
            CheckBox3.Enabled = False
        Else
            bool_nummerSearch = False
            CheckBox1.Enabled = True
            DateTimePicker1.Enabled = True
            DateTimePicker2.Enabled = True
            RadioButton1.Enabled = True
            RadioButton2.Enabled = True
            CheckBox2.Enabled = True
            CheckBox3.Enabled = True
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            bool_faelligRechnungCheck = True
            TextBox1.Enabled = False
            RadioButton1.Enabled = False
            RadioButton2.Checked = True
        Else
            bool_faelligRechnungCheck = False
            TextBox1.Enabled = True
            RadioButton1.Enabled = True
            RadioButton2.Checked = False
        End If
    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged
        If CheckBox3.Checked = True Then
            bool_Alle = True
            CheckBox1.Checked = True
            CheckBox1.Enabled = False
            DateTimePicker1.Value = New Date(2000, 1, 1)
            DateTimePicker2.Value = New Date(2040, 12, 31)
        Else
            bool_Alle = False
            CheckBox1.Enabled = True
            DateTimePicker1.Value = New Date(Now.Year, Now.Month, Now.Day)
            DateTimePicker2.Value = New Date(Now.Year, Now.Month, Now.Day)
        End If
    End Sub
    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then
            TextBox1.Enabled = False
            TextBox1.Text = ""
        Else
            TextBox1.Enabled = True
            TextBox1.Text = ""
        End If
    End Sub
    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then
            TextBox1.Enabled = False
            TextBox1.Text = ""
        Else
            TextBox1.Enabled = True
            TextBox1.Text = ""
        End If
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        DataGridView1.DataSource = ""
        TextBox1.Text = ""
        TextBox1.Enabled = True
        CheckBox1.Checked = False
        CheckBox1.Enabled = True
        CheckBox3.Checked = False
        CheckBox3.Enabled = True
        DateTimePicker1.Value = New Date(Now.Year, Now.Month, Now.Day)
        DateTimePicker2.Value = New Date(Now.Year, Now.Month, Now.Day)
        RadioButton1.Checked = False
        RadioButton1.Enabled = True
        RadioButton2.Checked = False
        RadioButton2.Enabled = True
        CheckBox2.Checked = False
        CheckBox2.Enabled = True
    End Sub
End Class