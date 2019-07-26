
Imports System.Data.SqlClient
Public Class Insert_Form
    Dim connection As SqlConnection = New SqlConnection()
    Dim mwst_betrag As Single
    Private Sub Button_Cancel_Click(sender As Object, e As EventArgs) Handles Button_Cancel.Click
        Me.Close()
        Main_Form.Show()
    End Sub
    Private Sub Button_Filter_Click(sender As Object, e As EventArgs) Handles Button_Filter.Click
        Insert_Search_Form.Show()
    End Sub
    Private Sub Insert_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        RadioButton1.Checked = True
        GroupBox2.Location = New Point(15, 58)
        GroupBox2.Width = 455
        GroupBox2.Height = 480
        Me.Width = 500
        Me.Height = 635
        Kunde_Load()
        Zahlungstyp_Load()
        Mitarbeiter_Load()
        Produkt_Load()
        NumericUpDown1.Minimum = 0
        NumericUpDown1.Maximum = 300
    End Sub
    Sub Kunde_Load()
        connection.ConnectionString = "Data Source=.\SQLEXPRESS;Initial Catalog=MedikamentFirma1;Integrated Security=True"
        connection.Open()
        Dim adp As SqlDataAdapter = New SqlDataAdapter("SELECT * FROM Kunde", connection)
        Dim ds As DataSet = New DataSet()
        adp.Fill(ds)
        ComboBox4.DataSource = ds.Tables(0)
        ComboBox4.ValueMember = "KundenNr"
        ComboBox4.DisplayMember = "FirmenTitel"
        connection.Close()
    End Sub
    Sub Zahlungstyp_Load()
        connection.ConnectionString = "Data Source=.\SQLEXPRESS;Initial Catalog=MedikamentFirma1;Integrated Security=True"
        connection.Open()
        Dim adp As SqlDataAdapter = New SqlDataAdapter("SELECT * FROM [MedikamentFirma1].[dbo].[Zahlungstyp]", connection)
        Dim ds As DataSet = New DataSet()
        adp.Fill(ds)
        ComboBox3.DataSource = ds.Tables(0)
        ComboBox3.ValueMember = "ZahlungstypID"
        ComboBox3.DisplayMember = "Zahlungstyp"
        connection.Close()
    End Sub
    Sub Mitarbeiter_Load()
        connection.ConnectionString = "Data Source=.\SQLEXPRESS;Initial Catalog=MedikamentFirma1;Integrated Security=True"
        connection.Open()
        Dim adp As SqlDataAdapter = New SqlDataAdapter("select MitarbeiterNr, Vorname + ' ' + Name as VorUndNachname from Mitarbeiter WHERE ArbeitsTitel = 'satis temsilcisi'", connection)
        Dim ds As DataSet = New DataSet()
        adp.Fill(ds)
        ComboBox2.DataSource = ds.Tables(0)
        ComboBox2.ValueMember = "MitarbeiterNr"
        ComboBox2.DisplayMember = "VorUndNachname"
        connection.Close()
    End Sub
    Sub Produkt_Load()
        connection.ConnectionString = "Data Source=.\SQLEXPRESS;Initial Catalog=MedikamentFirma1;Integrated Security=True"
        connection.Open()
        Dim adp As SqlDataAdapter = New SqlDataAdapter("SELECT ProduktNr, ProduktName FROM Produkt", connection)
        Dim ds As DataSet = New DataSet()
        adp.Fill(ds)
        ComboBox1.DataSource = ds.Tables(0)
        ComboBox1.ValueMember = "ProduktNr"
        ComboBox1.DisplayMember = "ProduktName"
        connection.Close()
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        'gets mw.steuer rate
        Dim ix As Integer = ComboBox1.SelectedIndex
        Dim dt As New DataTable()
        Dim adp As SqlDataAdapter = New SqlDataAdapter("SELECT ProduktNr, ProduktName, MwSteuerRate, ProduktEinzelPreis FROM Produkt INNER JOIN Produktart ON Produkt.ProduktArtNr = Produktart.ProduktArtNr", connection)
        Dim ds As DataSet = New DataSet()
        adp.Fill(dt)
        adp.Dispose()
        TextBox10.Text = CStr(dt.Rows(ix)("MwSteuerRate"))
        TextBox10.Text = Strings.Left(TextBox10.Text, Strings.Len(TextBox10.Text) - 5)
        TextBox2.Text = CStr(dt.Rows(ix)("ProduktEinzelPreis"))
        TextBox2.Text = Strings.Left(TextBox2.Text, Strings.Len(TextBox2.Text) - 2)
    End Sub
    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged
        Calculate_Summe()
    End Sub
    Sub Calculate_Summe()
        Dim mwstRate As Integer = Integer.Parse(TextBox10.Text)
        Dim auftragMenge As Integer = Integer.Parse(NumericUpDown1.Value)
        Dim einzelPreis As Single = Single.Parse(TextBox2.Text)
        Dim nettoSumme As Single = auftragMenge * einzelPreis
        Dim bruttoSumme As Single = nettoSumme + (nettoSumme * mwstRate / 100)
        mwst_betrag = bruttoSumme - nettoSumme
        TextBox3.Text = nettoSumme
        TextBox4.Text = bruttoSumme
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Calculate_Summe()
    End Sub
    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then
            GroupBox1.Visible = False
            GroupBox2.Visible = True
        End If
    End Sub
    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then
            GroupBox1.Visible = True
            GroupBox2.Visible = False
        End If
    End Sub
    Private Sub Button_OK_Click(sender As Object, e As EventArgs) Handles Button_OK.Click
        'insert gerçekleşsin ve dtgw'da son eklenen kısım gözüksün
        Dim cmd As New SqlCommand
        If RadioButton1.Checked = False And RadioButton2.Checked = False Then
            MsgBox("Lütfen bir seçim yapınız.")
        Else
            If RadioButton1.Checked = True Then
                Try
                    cmd.CommandType = System.Data.CommandType.Text
                    cmd.CommandText = "INSERT INTO Auftrag VALUES (" & Integer.Parse(TextBox1.Text) & "," & ComboBox4.SelectedValue & "," &
                        ComboBox3.SelectedValue & "," & ComboBox2.SelectedValue & "," & ComboBox1.SelectedValue & "," & NumericUpDown1.Value & ",'" &
                        TextBox2.Text & "','" & TextBox3.Text & "','" & mwst_betrag & "','" & DateTimePicker3.Value.ToString & "') "
                    cmd.Connection = connection
                    connection.Open()
                    cmd.ExecuteNonQuery()
                    MsgBox("Succesfully Added", MsgBoxStyle.Information, "add")
                    Me.Height = 670
                    Me.Width = 1210
                    DataGridView1.Location = New Point(480, 20)
                    DataGridView1.Width = 700
                    DataGridView1.Height = 600
                    DataGridView1.Visible = True
                    Me.CenterToScreen()
                    Dim adp As SqlDataAdapter = New SqlDataAdapter("SELECT * FROM Auftrag WHERE AuftragsNr = " + Integer.Parse(TextBox1.Text).ToString, connection)
                    Dim ds As DataSet = New DataSet()
                    adp.Fill(ds)
                    DataGridView1.DataSource = ds.Tables(0)
                    connection.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
            End If
            If RadioButton2.Checked = True Then
                Try
                    cmd.CommandType = System.Data.CommandType.Text
                    cmd.CommandText = "INSERT INTO Rechnung VALUES (" & Integer.Parse(TextBox5.Text) & "," & Integer.Parse(TextBox7.Text) & ",'" &
                        DateTimePicker1.Value.ToString & "','" & DateTimePicker2.Value.ToString & "','" & TextBox8.Text & "','" & TextBox9.Text & "') "
                    cmd.Connection = connection
                    connection.Open()
                    cmd.ExecuteNonQuery()
                    MsgBox("Succesfully Added", MsgBoxStyle.Information, "add")
                    Me.Height = 670
                    Me.Width = 1210
                    DataGridView1.Location = New Point(480, 20)
                    DataGridView1.Width = 700
                    DataGridView1.Height = 600
                    DataGridView1.Visible = True
                    Me.CenterToScreen()
                    Dim adp As SqlDataAdapter = New SqlDataAdapter("SELECT * FROM Rechnung WHERE RechnungsNr = " + Integer.Parse(TextBox5.Text).ToString, connection)
                    Dim ds As DataSet = New DataSet()
                    adp.Fill(ds)
                    DataGridView1.DataSource = ds.Tables(0)
                    connection.Close()
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
            End If
        End If
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim auftrag_Nr As Integer = Integer.Parse(TextBox7.Text)
        Dim dt As New DataTable()
        Dim adp As SqlDataAdapter = New SqlDataAdapter("SELECT * FROM Auftrag WHERE AuftragsNr = " + auftrag_Nr.ToString, connection)
        Dim ds As DataSet = New DataSet()
        adp.Fill(dt)
        adp.Dispose()
        If dt.Rows.Count < 1 Then
            MsgBox("Aradığınız AuftragsNr bulunamadı.")
            TextBox8.Clear()
            TextBox7.Clear()
        Else
            TextBox8.Text = CStr(dt.Rows(0)("SummeBrutto"))
            TextBox8.Text = Strings.Left(TextBox8.Text, Strings.Len(TextBox8.Text) - 2)
        End If
    End Sub
End Class