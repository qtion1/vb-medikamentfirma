Imports System.Data.SqlClient
Public Class View_Form
    Dim connection As SqlConnection = New SqlConnection()
    Dim bool_Nodes_Checked As Boolean
    Dim bool_nested_tables As Boolean
    Dim bool_multipleChoice As Boolean
    Dim query As String
    '////////////////////////////////////////////////////////////////////////////
    '///////////////////// fills the child nodes to parents /////////////////////
    Sub FillChild(parent As TreeNode, ParentId As String)
        Dim con As SqlConnection = New SqlConnection
        con.ConnectionString = "Data Source=.\SQLEXPRESS;Initial Catalog=MedikamentFirma1;Integrated Security=True"
        con.Open()
        Dim cmd2 As SqlCommand = New SqlCommand("SELECT TABLE_NAME, COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '" + ParentId + "' ", con)
        Dim da As SqlDataAdapter = New SqlDataAdapter(cmd2)
        Dim PDataSet As DataSet = New DataSet
        da.Fill(PDataSet)
        Dim ds As DataSet = PDataSet
        parent.Nodes.Clear()

        For Each dr As DataRow In ds.Tables(0).Rows
            Dim child As TreeNode = New TreeNode

            child.Text = dr("COLUMN_NAME").ToString().Trim()
            child.Tag = dr("COLUMN_NAME").ToString().Trim()
            If child.Nodes.Count = 0 Then
                parent.Nodes.Add(child)
            End If
        Next

    End Sub
    '///////////////////// NodeAdd SUB /////////////////////
    Sub NodeAdd()

        TreeView2.Nodes(0).Nodes(1).Nodes.Add("AbteilungsName")
        TreeView2.Nodes(0).Nodes(1).Nodes.Add("LeiterNr")

        TreeView2.Nodes(0).Nodes(2).Nodes.Add("BankID")
        TreeView2.Nodes(0).Nodes(2).Nodes(0).Nodes.Add("BankName")
        TreeView2.Nodes(0).Nodes(2).Nodes.Add("Filialnummer")
        TreeView2.Nodes(0).Nodes(2).Nodes.Add("Kontonummer")
        TreeView2.Nodes(0).Nodes(2).Nodes.Add("IBAN")
        TreeView2.Nodes(0).Nodes(10).Nodes.Add("Strasse")
        TreeView2.Nodes(0).Nodes(10).Nodes.Add("Nummer")
        TreeView2.Nodes(0).Nodes(10).Nodes.Add("Etage")
        TreeView2.Nodes(0).Nodes(10).Nodes.Add("PLZ")
        TreeView2.Nodes(0).Nodes(10).Nodes.Add("OrtID")
        TreeView2.Nodes(0).Nodes(10).Nodes(4).Nodes.Add("Ort")

        TreeView2.Nodes(3).Nodes(1).Nodes.Add("BankName")

        TreeView2.Nodes(4).Nodes(5).Nodes.Add("Ort")

        TreeView2.Nodes(6).Nodes(1).Nodes.Add("BankID")
        TreeView2.Nodes(6).Nodes(1).Nodes(0).Nodes.Add("BankName")
        TreeView2.Nodes(6).Nodes(1).Nodes.Add("Filialnummer")
        TreeView2.Nodes(6).Nodes(1).Nodes.Add("Kontonummer")
        TreeView2.Nodes(6).Nodes(1).Nodes.Add("IBAN")
        TreeView2.Nodes(6).Nodes(6).Nodes.Add("Strasse")
        TreeView2.Nodes(6).Nodes(6).Nodes.Add("Nummer")
        TreeView2.Nodes(6).Nodes(6).Nodes.Add("Etage")
        TreeView2.Nodes(6).Nodes(6).Nodes.Add("PLZ")
        TreeView2.Nodes(6).Nodes(6).Nodes.Add("OrtID")
        TreeView2.Nodes(6).Nodes(6).Nodes(4).Nodes.Add("Ort")

        TreeView2.Nodes(9).Nodes(2).Nodes.Add("Strasse")
        TreeView2.Nodes(9).Nodes(2).Nodes.Add("Nummer")
        TreeView2.Nodes(9).Nodes(2).Nodes.Add("Etage")
        TreeView2.Nodes(9).Nodes(2).Nodes.Add("PLZ")
        TreeView2.Nodes(9).Nodes(2).Nodes.Add("OrtID")
        TreeView2.Nodes(9).Nodes(2).Nodes(4).Nodes.Add("Ort")

        TreeView2.Nodes(10).Nodes(1).Nodes.Add("BankID")
        TreeView2.Nodes(10).Nodes(1).Nodes(0).Nodes.Add("BankName")
        TreeView2.Nodes(10).Nodes(1).Nodes.Add("Filialnummer")
        TreeView2.Nodes(10).Nodes(1).Nodes.Add("Kontonummer")
        TreeView2.Nodes(10).Nodes(1).Nodes.Add("IBAN")
        TreeView2.Nodes(10).Nodes(7).Nodes.Add("Strasse")
        TreeView2.Nodes(10).Nodes(7).Nodes.Add("Nummer")
        TreeView2.Nodes(10).Nodes(7).Nodes.Add("Etage")
        TreeView2.Nodes(10).Nodes(7).Nodes.Add("PLZ")
        TreeView2.Nodes(10).Nodes(7).Nodes.Add("OrtID")
        TreeView2.Nodes(10).Nodes(7).Nodes(4).Nodes.Add("Ort")

        TreeView2.Nodes(11).Nodes(1).Nodes.Add("LagerName")
        TreeView2.Nodes(11).Nodes(1).Nodes.Add("AdressID")
        TreeView2.Nodes(11).Nodes(1).Nodes(1).Nodes.Add("Strasse")
        TreeView2.Nodes(11).Nodes(1).Nodes(1).Nodes.Add("Nummer")
        TreeView2.Nodes(11).Nodes(1).Nodes(1).Nodes.Add("Etage")
        TreeView2.Nodes(11).Nodes(1).Nodes(1).Nodes.Add("PLZ")
        TreeView2.Nodes(11).Nodes(1).Nodes(1).Nodes.Add("OrtID")
        TreeView2.Nodes(11).Nodes(1).Nodes(1).Nodes(4).Nodes.Add("Ort")
        TreeView2.Nodes(11).Nodes(2).Nodes.Add("KontoID")
        TreeView2.Nodes(11).Nodes(2).Nodes(0).Nodes.Add("BankID")
        TreeView2.Nodes(11).Nodes(2).Nodes(0).Nodes(0).Nodes.Add("BankName")
        TreeView2.Nodes(11).Nodes(2).Nodes(0).Nodes.Add("Filialnummer")
        TreeView2.Nodes(11).Nodes(2).Nodes(0).Nodes.Add("Kontonummer")
        TreeView2.Nodes(11).Nodes(2).Nodes(0).Nodes.Add("IBAN")
        TreeView2.Nodes(11).Nodes(2).Nodes.Add("SteuerNr")
        TreeView2.Nodes(11).Nodes(2).Nodes.Add("FirmenTitel")
        TreeView2.Nodes(11).Nodes(2).Nodes.Add("Ansprechspartner")
        TreeView2.Nodes(11).Nodes(2).Nodes.Add("Telefon")
        TreeView2.Nodes(11).Nodes(2).Nodes.Add("Email")
        TreeView2.Nodes(11).Nodes(2).Nodes.Add("AdressID")
        TreeView2.Nodes(11).Nodes(2).Nodes(6).Nodes.Add("Strasse")
        TreeView2.Nodes(11).Nodes(2).Nodes(6).Nodes.Add("HausNr")
        TreeView2.Nodes(11).Nodes(2).Nodes(6).Nodes.Add("Etage")
        TreeView2.Nodes(11).Nodes(2).Nodes(6).Nodes.Add("PLZ")
        TreeView2.Nodes(11).Nodes(2).Nodes(6).Nodes.Add("OrtID")
        TreeView2.Nodes(11).Nodes(2).Nodes(6).Nodes(4).Nodes.Add("Ort")
        TreeView2.Nodes(11).Nodes(5).Nodes.Add("ProduktArt")
        TreeView2.Nodes(11).Nodes(5).Nodes.Add("MwSteuerRate")

        TreeView2.Nodes(12).Nodes(1).Nodes.Add("KontoID")
        TreeView2.Nodes(12).Nodes(1).Nodes(0).Nodes.Add("BankID")
        TreeView2.Nodes(12).Nodes(1).Nodes(0).Nodes(0).Nodes.Add("BankName")
        TreeView2.Nodes(12).Nodes(1).Nodes(0).Nodes.Add("Filialnummer")
        TreeView2.Nodes(12).Nodes(1).Nodes(0).Nodes.Add("Kontonummer")
        TreeView2.Nodes(12).Nodes(1).Nodes(0).Nodes.Add("IBAN")
        TreeView2.Nodes(12).Nodes(1).Nodes.Add("FirmenTitel")
        TreeView2.Nodes(12).Nodes(1).Nodes.Add("SteuerNr")
        TreeView2.Nodes(12).Nodes(1).Nodes.Add("Email")
        TreeView2.Nodes(12).Nodes(1).Nodes.Add("Telefon")
        TreeView2.Nodes(12).Nodes(1).Nodes.Add("AdressID")
        TreeView2.Nodes(12).Nodes(1).Nodes(5).Nodes.Add("Strasse")
        TreeView2.Nodes(12).Nodes(1).Nodes(5).Nodes.Add("Nummer")
        TreeView2.Nodes(12).Nodes(1).Nodes(5).Nodes.Add("Etage")
        TreeView2.Nodes(12).Nodes(1).Nodes(5).Nodes.Add("PLZ")
        TreeView2.Nodes(12).Nodes(1).Nodes(5).Nodes.Add("OrtID")
        TreeView2.Nodes(12).Nodes(1).Nodes(5).Nodes(4).Nodes.Add("Ort")
        TreeView2.Nodes(12).Nodes(2).Nodes.Add("Zahlungstyp")
        TreeView2.Nodes(12).Nodes(3).Nodes.Add("AbteilungsNr")
        TreeView2.Nodes(12).Nodes(3).Nodes(0).Nodes.Add("AbteilungsName")
        TreeView2.Nodes(12).Nodes(3).Nodes.Add("KontoID")
        TreeView2.Nodes(12).Nodes(3).Nodes(1).Nodes.Add("BankID")
        TreeView2.Nodes(12).Nodes(3).Nodes(1).Nodes(0).Nodes.Add("BankName")
        TreeView2.Nodes(12).Nodes(3).Nodes(1).Nodes.Add("Filialnummer")
        TreeView2.Nodes(12).Nodes(3).Nodes(1).Nodes.Add("Kontonummer")
        TreeView2.Nodes(12).Nodes(3).Nodes(1).Nodes.Add("IBAN")
        TreeView2.Nodes(12).Nodes(3).Nodes.Add("Vorname")
        TreeView2.Nodes(12).Nodes(3).Nodes.Add("Name")
        TreeView2.Nodes(12).Nodes(3).Nodes.Add("Geschlecht")
        TreeView2.Nodes(12).Nodes(3).Nodes.Add("ArbeitsTitel")
        TreeView2.Nodes(12).Nodes(3).Nodes.Add("GeburtsDatum")
        TreeView2.Nodes(12).Nodes(3).Nodes.Add("Email")
        TreeView2.Nodes(12).Nodes(3).Nodes.Add("Telefon")
        TreeView2.Nodes(12).Nodes(3).Nodes.Add("AdressID")
        TreeView2.Nodes(12).Nodes(3).Nodes(9).Nodes.Add("Strasse")
        TreeView2.Nodes(12).Nodes(3).Nodes(9).Nodes.Add("Nummer")
        TreeView2.Nodes(12).Nodes(3).Nodes(9).Nodes.Add("Etage")
        TreeView2.Nodes(12).Nodes(3).Nodes(9).Nodes.Add("PLZ")
        TreeView2.Nodes(12).Nodes(3).Nodes(9).Nodes.Add("OrtID")
        TreeView2.Nodes(12).Nodes(3).Nodes(9).Nodes(4).Nodes.Add("Ort")
        TreeView2.Nodes(12).Nodes(3).Nodes.Add("PersonalNr")
        TreeView2.Nodes(12).Nodes(3).Nodes.Add("Gehalt")
        TreeView2.Nodes(12).Nodes(3).Nodes.Add("EingangsDatum")
        TreeView2.Nodes(12).Nodes(4).Nodes.Add("LagerNr")
        TreeView2.Nodes(12).Nodes(4).Nodes(0).Nodes.Add("LagerName")
        TreeView2.Nodes(12).Nodes(4).Nodes(0).Nodes.Add("AdressID")
        TreeView2.Nodes(12).Nodes(4).Nodes(0).Nodes(1).Nodes.Add("Strasse")
        TreeView2.Nodes(12).Nodes(4).Nodes(0).Nodes(1).Nodes.Add("Nummer")
        TreeView2.Nodes(12).Nodes(4).Nodes(0).Nodes(1).Nodes.Add("Etage")
        TreeView2.Nodes(12).Nodes(4).Nodes(0).Nodes(1).Nodes.Add("PLZ")
        TreeView2.Nodes(12).Nodes(4).Nodes(0).Nodes(1).Nodes.Add("OrtID")
        TreeView2.Nodes(12).Nodes(4).Nodes(0).Nodes(1).Nodes(4).Nodes.Add("Ort")
        TreeView2.Nodes(12).Nodes(4).Nodes.Add("LieferantNr")
        TreeView2.Nodes(12).Nodes(4).Nodes(1).Nodes.Add("KontoID")
        TreeView2.Nodes(12).Nodes(4).Nodes(1).Nodes(0).Nodes.Add("BankID")
        TreeView2.Nodes(12).Nodes(4).Nodes(1).Nodes(0).Nodes(0).Nodes.Add("BankName")
        TreeView2.Nodes(12).Nodes(4).Nodes(1).Nodes(0).Nodes.Add("Filialnummer")
        TreeView2.Nodes(12).Nodes(4).Nodes(1).Nodes(0).Nodes.Add("Kontonummer")
        TreeView2.Nodes(12).Nodes(4).Nodes(1).Nodes(0).Nodes.Add("IBAN")
        TreeView2.Nodes(12).Nodes(4).Nodes(1).Nodes.Add("SteuerNr")
        TreeView2.Nodes(12).Nodes(4).Nodes(1).Nodes.Add("FirmenTitel")
        TreeView2.Nodes(12).Nodes(4).Nodes(1).Nodes.Add("Ansprechspartner")
        TreeView2.Nodes(12).Nodes(4).Nodes(1).Nodes.Add("Telefon")
        TreeView2.Nodes(12).Nodes(4).Nodes(1).Nodes.Add("Email")
        TreeView2.Nodes(12).Nodes(4).Nodes(1).Nodes.Add("AdressID")
        TreeView2.Nodes(12).Nodes(4).Nodes(1).Nodes(6).Nodes.Add("Strasse")
        TreeView2.Nodes(12).Nodes(4).Nodes(1).Nodes(6).Nodes.Add("Nummer")
        TreeView2.Nodes(12).Nodes(4).Nodes(1).Nodes(6).Nodes.Add("Etage")
        TreeView2.Nodes(12).Nodes(4).Nodes(1).Nodes(6).Nodes.Add("PLZ")
        TreeView2.Nodes(12).Nodes(4).Nodes(1).Nodes(6).Nodes.Add("OrtID")
        TreeView2.Nodes(12).Nodes(4).Nodes(1).Nodes(6).Nodes(4).Nodes.Add("Ort")
        TreeView2.Nodes(12).Nodes(4).Nodes.Add("ProduktName")
        TreeView2.Nodes(12).Nodes(4).Nodes.Add("ProduktMenge")
        TreeView2.Nodes(12).Nodes(4).Nodes.Add("ProduktArtNr")
        TreeView2.Nodes(12).Nodes(4).Nodes(4).Nodes.Add("ProduktArt")
        TreeView2.Nodes(12).Nodes(4).Nodes(4).Nodes.Add("MwSteuerRate")
        TreeView2.Nodes(12).Nodes(4).Nodes.Add("ProduktEinzelPreis")

        TreeView2.Nodes(13).Nodes(1).Nodes.Add("AuftragsNr")
        TreeView2.Nodes(13).Nodes(1).Nodes(0).Nodes.Add("KundenNr")
        TreeView2.Nodes(13).Nodes(1).Nodes(0).Nodes(0).Nodes.Add("KontoID")
        TreeView2.Nodes(13).Nodes(1).Nodes(0).Nodes(0).Nodes(0).Nodes.Add("BankID")
        TreeView2.Nodes(13).Nodes(1).Nodes(0).Nodes(0).Nodes(0).Nodes(0).Nodes.Add("BankName")
        TreeView2.Nodes(13).Nodes(1).Nodes(0).Nodes(0).Nodes(0).Nodes.Add("Filialnummer")
        TreeView2.Nodes(13).Nodes(1).Nodes(0).Nodes(0).Nodes(0).Nodes.Add("Kontonummer")
        TreeView2.Nodes(13).Nodes(1).Nodes(0).Nodes(0).Nodes(0).Nodes.Add("IBAN")
        TreeView2.Nodes(13).Nodes(1).Nodes(0).Nodes(0).Nodes.Add("FirmenTitel")
        TreeView2.Nodes(13).Nodes(1).Nodes(0).Nodes(0).Nodes.Add("SteuerNr")
        TreeView2.Nodes(13).Nodes(1).Nodes(0).Nodes(0).Nodes.Add("Email")
        TreeView2.Nodes(13).Nodes(1).Nodes(0).Nodes(0).Nodes.Add("Telefon")
        TreeView2.Nodes(13).Nodes(1).Nodes(0).Nodes(0).Nodes.Add("AdressID")
        TreeView2.Nodes(13).Nodes(1).Nodes(0).Nodes(0).Nodes(5).Nodes.Add("Strasse")
        TreeView2.Nodes(13).Nodes(1).Nodes(0).Nodes(0).Nodes(5).Nodes.Add("Nummer")
        TreeView2.Nodes(13).Nodes(1).Nodes(0).Nodes(0).Nodes(5).Nodes.Add("Etage")
        TreeView2.Nodes(13).Nodes(1).Nodes(0).Nodes(0).Nodes(5).Nodes.Add("PLZ")
        TreeView2.Nodes(13).Nodes(1).Nodes(0).Nodes(0).Nodes(5).Nodes.Add("OrtID")
        TreeView2.Nodes(13).Nodes(1).Nodes(0).Nodes(0).Nodes(5).Nodes(4).Nodes.Add("Ort")
        TreeView2.Nodes(13).Nodes(1).Nodes(0).Nodes.Add("ZahlungstypID")
        TreeView2.Nodes(13).Nodes(1).Nodes(0).Nodes(1).Nodes.Add("Zahlungstyp")
        TreeView2.Nodes(13).Nodes(1).Nodes(0).Nodes.Add("MitarbeiterNr")
        TreeView2.Nodes(13).Nodes(1).Nodes(0).Nodes(2).Nodes.Add("AbteilungsNr")
        TreeView2.Nodes(13).Nodes(1).Nodes(0).Nodes(2).Nodes(0).Nodes.Add("AbteilungsName")
        TreeView2.Nodes(13).Nodes(1).Nodes(0).Nodes(2).Nodes.Add("KontoID")
        TreeView2.Nodes(13).Nodes(1).Nodes(0).Nodes(2).Nodes(1).Nodes.Add("BankID")
        TreeView2.Nodes(13).Nodes(1).Nodes(0).Nodes(2).Nodes(1).Nodes(0).Nodes.Add("BankName")
        TreeView2.Nodes(13).Nodes(1).Nodes(0).Nodes(2).Nodes(1).Nodes.Add("Filialnummer")
        TreeView2.Nodes(13).Nodes(1).Nodes(0).Nodes(2).Nodes(1).Nodes.Add("Kontonummer")
        TreeView2.Nodes(13).Nodes(1).Nodes(0).Nodes(2).Nodes(1).Nodes.Add("IBAN")
        TreeView2.Nodes(13).Nodes(1).Nodes(0).Nodes(2).Nodes.Add("Vorname")
        TreeView2.Nodes(13).Nodes(1).Nodes(0).Nodes(2).Nodes.Add("Name")
        TreeView2.Nodes(13).Nodes(1).Nodes(0).Nodes(2).Nodes.Add("Geschlecht")
        TreeView2.Nodes(13).Nodes(1).Nodes(0).Nodes(2).Nodes.Add("ArbeitsTitel")
        TreeView2.Nodes(13).Nodes(1).Nodes(0).Nodes(2).Nodes.Add("GeburtsDatum")
        TreeView2.Nodes(13).Nodes(1).Nodes(0).Nodes(2).Nodes.Add("Email")
        TreeView2.Nodes(13).Nodes(1).Nodes(0).Nodes(2).Nodes.Add("Telefon")
        TreeView2.Nodes(13).Nodes(1).Nodes(0).Nodes(2).Nodes.Add("AdressID")
        TreeView2.Nodes(13).Nodes(1).Nodes(0).Nodes(2).Nodes(9).Nodes.Add("Strasse")
        TreeView2.Nodes(13).Nodes(1).Nodes(0).Nodes(2).Nodes(9).Nodes.Add("Nummer")
        TreeView2.Nodes(13).Nodes(1).Nodes(0).Nodes(2).Nodes(9).Nodes.Add("Etage")
        TreeView2.Nodes(13).Nodes(1).Nodes(0).Nodes(2).Nodes(9).Nodes.Add("PLZ")
        TreeView2.Nodes(13).Nodes(1).Nodes(0).Nodes(2).Nodes(9).Nodes.Add("OrtID")
        TreeView2.Nodes(13).Nodes(1).Nodes(0).Nodes(2).Nodes(9).Nodes(4).Nodes.Add("Ort")
        TreeView2.Nodes(13).Nodes(1).Nodes(0).Nodes(2).Nodes.Add("PersonalNr")
        TreeView2.Nodes(13).Nodes(1).Nodes(0).Nodes(2).Nodes.Add("Gehalt")
        TreeView2.Nodes(13).Nodes(1).Nodes(0).Nodes(2).Nodes.Add("EingangsDatum")
        TreeView2.Nodes(13).Nodes(1).Nodes(0).Nodes.Add("ProduktNr")
        TreeView2.Nodes(13).Nodes(1).Nodes(0).Nodes(3).Nodes.Add("LagerNr")
        TreeView2.Nodes(13).Nodes(1).Nodes(0).Nodes(3).Nodes(0).Nodes.Add("LagerName")
        TreeView2.Nodes(13).Nodes(1).Nodes(0).Nodes(3).Nodes(0).Nodes.Add("AdressID")
        TreeView2.Nodes(13).Nodes(1).Nodes(0).Nodes(3).Nodes(0).Nodes(1).Nodes.Add("Strasse")
        TreeView2.Nodes(13).Nodes(1).Nodes(0).Nodes(3).Nodes(0).Nodes(1).Nodes.Add("Nummer")
        TreeView2.Nodes(13).Nodes(1).Nodes(0).Nodes(3).Nodes(0).Nodes(1).Nodes.Add("Etage")
        TreeView2.Nodes(13).Nodes(1).Nodes(0).Nodes(3).Nodes(0).Nodes(1).Nodes.Add("PLZ")
        TreeView2.Nodes(13).Nodes(1).Nodes(0).Nodes(3).Nodes(0).Nodes(1).Nodes.Add("OrtID")
        TreeView2.Nodes(13).Nodes(1).Nodes(0).Nodes(3).Nodes(0).Nodes(1).Nodes(4).Nodes.Add("Ort")
        TreeView2.Nodes(13).Nodes(1).Nodes(0).Nodes(3).Nodes.Add("LieferantNr")
        TreeView2.Nodes(13).Nodes(1).Nodes(0).Nodes(3).Nodes(1).Nodes.Add("KontoID")
        TreeView2.Nodes(13).Nodes(1).Nodes(0).Nodes(3).Nodes(1).Nodes(0).Nodes.Add("BankID")
        TreeView2.Nodes(13).Nodes(1).Nodes(0).Nodes(3).Nodes(1).Nodes(0).Nodes(0).Nodes.Add("BankName")
        TreeView2.Nodes(13).Nodes(1).Nodes(0).Nodes(3).Nodes(1).Nodes(0).Nodes.Add("Filialnummer")
        TreeView2.Nodes(13).Nodes(1).Nodes(0).Nodes(3).Nodes(1).Nodes(0).Nodes.Add("Kontonummer")
        TreeView2.Nodes(13).Nodes(1).Nodes(0).Nodes(3).Nodes(1).Nodes(0).Nodes.Add("IBAN")
        TreeView2.Nodes(13).Nodes(1).Nodes(0).Nodes(3).Nodes(1).Nodes.Add("SteuerNr")
        TreeView2.Nodes(13).Nodes(1).Nodes(0).Nodes(3).Nodes(1).Nodes.Add("FirmenTitel")
        TreeView2.Nodes(13).Nodes(1).Nodes(0).Nodes(3).Nodes(1).Nodes.Add("Ansprechspartner")
        TreeView2.Nodes(13).Nodes(1).Nodes(0).Nodes(3).Nodes(1).Nodes.Add("Telefon")
        TreeView2.Nodes(13).Nodes(1).Nodes(0).Nodes(3).Nodes(1).Nodes.Add("Email")
        TreeView2.Nodes(13).Nodes(1).Nodes(0).Nodes(3).Nodes(1).Nodes.Add("AdressID")
        TreeView2.Nodes(13).Nodes(1).Nodes(0).Nodes(3).Nodes(1).Nodes(6).Nodes.Add("Strasse")
        TreeView2.Nodes(13).Nodes(1).Nodes(0).Nodes(3).Nodes(1).Nodes(6).Nodes.Add("Nummer")
        TreeView2.Nodes(13).Nodes(1).Nodes(0).Nodes(3).Nodes(1).Nodes(6).Nodes.Add("Etage")
        TreeView2.Nodes(13).Nodes(1).Nodes(0).Nodes(3).Nodes(1).Nodes(6).Nodes.Add("PLZ")
        TreeView2.Nodes(13).Nodes(1).Nodes(0).Nodes(3).Nodes(1).Nodes(6).Nodes.Add("OrtID")
        TreeView2.Nodes(13).Nodes(1).Nodes(0).Nodes(3).Nodes(1).Nodes(6).Nodes(4).Nodes.Add("Ort")
        TreeView2.Nodes(13).Nodes(1).Nodes(0).Nodes(3).Nodes.Add("ProduktName")
        TreeView2.Nodes(13).Nodes(1).Nodes(0).Nodes(3).Nodes.Add("ProduktMenge")
        TreeView2.Nodes(13).Nodes(1).Nodes(0).Nodes(3).Nodes.Add("ProduktArtNr")
        TreeView2.Nodes(13).Nodes(1).Nodes(0).Nodes(3).Nodes(4).Nodes.Add("ProduktArt")
        TreeView2.Nodes(13).Nodes(1).Nodes(0).Nodes(3).Nodes(4).Nodes.Add("MwSteuerRate")
        TreeView2.Nodes(13).Nodes(1).Nodes(0).Nodes(3).Nodes.Add("ProduktEinzelPreis")
        TreeView2.Nodes(13).Nodes(1).Nodes(0).Nodes.Add("AuftragMenge")
        TreeView2.Nodes(13).Nodes(1).Nodes(0).Nodes.Add("ProduktEinzelPreis")
        TreeView2.Nodes(13).Nodes(1).Nodes(0).Nodes.Add("SummeNetto")
        TreeView2.Nodes(13).Nodes(1).Nodes(0).Nodes.Add("MwSteuer")
        TreeView2.Nodes(13).Nodes(1).Nodes(0).Nodes.Add("SummeBrutto")
        TreeView2.Nodes(13).Nodes(1).Nodes(0).Nodes.Add("AuftragsDatum")
        TreeView2.Nodes(13).Nodes(1).Nodes.Add("RechnungsDatum")
        TreeView2.Nodes(13).Nodes(1).Nodes.Add("BegleichungsDatum")
        TreeView2.Nodes(13).Nodes(1).Nodes.Add("Soll")
        TreeView2.Nodes(13).Nodes(1).Nodes.Add("Haben")
        TreeView2.Nodes(13).Nodes(2).Nodes.Add("KontoID")
        TreeView2.Nodes(13).Nodes(2).Nodes(0).Nodes.Add("BankID")
        TreeView2.Nodes(13).Nodes(2).Nodes(0).Nodes(0).Nodes.Add("BankName")
        TreeView2.Nodes(13).Nodes(2).Nodes(0).Nodes.Add("Filialnummer")
        TreeView2.Nodes(13).Nodes(2).Nodes(0).Nodes.Add("Kontonummer")
        TreeView2.Nodes(13).Nodes(2).Nodes(0).Nodes.Add("IBAN")
        TreeView2.Nodes(13).Nodes(2).Nodes.Add("FirmenTitel")
        TreeView2.Nodes(13).Nodes(2).Nodes.Add("SteuerNr")
        TreeView2.Nodes(13).Nodes(2).Nodes.Add("Email")
        TreeView2.Nodes(13).Nodes(2).Nodes.Add("Telefon")
        TreeView2.Nodes(13).Nodes(2).Nodes.Add("AdressID")
        TreeView2.Nodes(13).Nodes(2).Nodes(5).Nodes.Add("Strasse")
        TreeView2.Nodes(13).Nodes(2).Nodes(5).Nodes.Add("Nummer")
        TreeView2.Nodes(13).Nodes(2).Nodes(5).Nodes.Add("Etage")
        TreeView2.Nodes(13).Nodes(2).Nodes(5).Nodes.Add("PLZ")
        TreeView2.Nodes(13).Nodes(2).Nodes(5).Nodes.Add("OrtID")
        TreeView2.Nodes(13).Nodes(2).Nodes(5).Nodes(4).Nodes.Add("Ort")

        TreeView2.Nodes(14).Nodes(1).Nodes.Add("KundenNr")
        TreeView2.Nodes(14).Nodes(1).Nodes(0).Nodes.Add("KontoID")
        TreeView2.Nodes(14).Nodes(1).Nodes(0).Nodes(0).Nodes.Add("BankID")
        TreeView2.Nodes(14).Nodes(1).Nodes(0).Nodes(0).Nodes(0).Nodes.Add("BankName")
        TreeView2.Nodes(14).Nodes(1).Nodes(0).Nodes(0).Nodes.Add("Filialnummer")
        TreeView2.Nodes(14).Nodes(1).Nodes(0).Nodes(0).Nodes.Add("Kontonummer")
        TreeView2.Nodes(14).Nodes(1).Nodes(0).Nodes(0).Nodes.Add("IBAN")
        TreeView2.Nodes(14).Nodes(1).Nodes(0).Nodes.Add("FirmenTitel")
        TreeView2.Nodes(14).Nodes(1).Nodes(0).Nodes.Add("SteuerNr")
        TreeView2.Nodes(14).Nodes(1).Nodes(0).Nodes.Add("Email")
        TreeView2.Nodes(14).Nodes(1).Nodes(0).Nodes.Add("Telefon")
        TreeView2.Nodes(14).Nodes(1).Nodes(0).Nodes.Add("AdressID")
        TreeView2.Nodes(14).Nodes(1).Nodes(0).Nodes(5).Nodes.Add("Strasse")
        TreeView2.Nodes(14).Nodes(1).Nodes(0).Nodes(5).Nodes.Add("Nummer")
        TreeView2.Nodes(14).Nodes(1).Nodes(0).Nodes(5).Nodes.Add("Etage")
        TreeView2.Nodes(14).Nodes(1).Nodes(0).Nodes(5).Nodes.Add("PLZ")
        TreeView2.Nodes(14).Nodes(1).Nodes(0).Nodes(5).Nodes.Add("OrtID")
        TreeView2.Nodes(14).Nodes(1).Nodes(0).Nodes(5).Nodes(4).Nodes.Add("Ort")
        TreeView2.Nodes(14).Nodes(1).Nodes.Add("ZahlungstypID")
        TreeView2.Nodes(14).Nodes(1).Nodes(1).Nodes.Add("Zahlungstyp")
        TreeView2.Nodes(14).Nodes(1).Nodes.Add("MitarbeiterNr")
        TreeView2.Nodes(14).Nodes(1).Nodes(2).Nodes.Add("AbteilungsNr")
        TreeView2.Nodes(14).Nodes(1).Nodes(2).Nodes(0).Nodes.Add("AbteilungsName")
        TreeView2.Nodes(14).Nodes(1).Nodes(2).Nodes.Add("KontoID")
        TreeView2.Nodes(14).Nodes(1).Nodes(2).Nodes(1).Nodes.Add("BankID")
        TreeView2.Nodes(14).Nodes(1).Nodes(2).Nodes(1).Nodes(0).Nodes.Add("BankName")
        TreeView2.Nodes(14).Nodes(1).Nodes(2).Nodes(1).Nodes.Add("Filialnummer")
        TreeView2.Nodes(14).Nodes(1).Nodes(2).Nodes(1).Nodes.Add("Kontonummer")
        TreeView2.Nodes(14).Nodes(1).Nodes(2).Nodes(1).Nodes.Add("IBAN")
        TreeView2.Nodes(14).Nodes(1).Nodes(2).Nodes.Add("Vorname")
        TreeView2.Nodes(14).Nodes(1).Nodes(2).Nodes.Add("Name")
        TreeView2.Nodes(14).Nodes(1).Nodes(2).Nodes.Add("Geschlecht")
        TreeView2.Nodes(14).Nodes(1).Nodes(2).Nodes.Add("ArbeitsTitel")
        TreeView2.Nodes(14).Nodes(1).Nodes(2).Nodes.Add("GeburtsDatum")
        TreeView2.Nodes(14).Nodes(1).Nodes(2).Nodes.Add("Email")
        TreeView2.Nodes(14).Nodes(1).Nodes(2).Nodes.Add("Telefon")
        TreeView2.Nodes(14).Nodes(1).Nodes(2).Nodes.Add("AdressID")
        TreeView2.Nodes(14).Nodes(1).Nodes(2).Nodes(9).Nodes.Add("Strasse")
        TreeView2.Nodes(14).Nodes(1).Nodes(2).Nodes(9).Nodes.Add("Nummer")
        TreeView2.Nodes(14).Nodes(1).Nodes(2).Nodes(9).Nodes.Add("Etage")
        TreeView2.Nodes(14).Nodes(1).Nodes(2).Nodes(9).Nodes.Add("PLZ")
        TreeView2.Nodes(14).Nodes(1).Nodes(2).Nodes(9).Nodes.Add("OrtID")
        TreeView2.Nodes(14).Nodes(1).Nodes(2).Nodes(9).Nodes(4).Nodes.Add("Ort")
        TreeView2.Nodes(14).Nodes(1).Nodes(2).Nodes.Add("PersonalNr")
        TreeView2.Nodes(14).Nodes(1).Nodes(2).Nodes.Add("Gehalt")
        TreeView2.Nodes(14).Nodes(1).Nodes(2).Nodes.Add("EingangsDatum")
        TreeView2.Nodes(14).Nodes(1).Nodes.Add("ProduktNr")
        TreeView2.Nodes(14).Nodes(1).Nodes(3).Nodes.Add("LagerNr")
        TreeView2.Nodes(14).Nodes(1).Nodes(3).Nodes(0).Nodes.Add("LagerName")
        TreeView2.Nodes(14).Nodes(1).Nodes(3).Nodes(0).Nodes.Add("AdressID")
        TreeView2.Nodes(14).Nodes(1).Nodes(3).Nodes(0).Nodes(1).Nodes.Add("Strasse")
        TreeView2.Nodes(14).Nodes(1).Nodes(3).Nodes(0).Nodes(1).Nodes.Add("Nummer")
        TreeView2.Nodes(14).Nodes(1).Nodes(3).Nodes(0).Nodes(1).Nodes.Add("Etage")
        TreeView2.Nodes(14).Nodes(1).Nodes(3).Nodes(0).Nodes(1).Nodes.Add("PLZ")
        TreeView2.Nodes(14).Nodes(1).Nodes(3).Nodes(0).Nodes(1).Nodes.Add("OrtID")
        TreeView2.Nodes(14).Nodes(1).Nodes(3).Nodes(0).Nodes(1).Nodes(4).Nodes.Add("Ort")
        TreeView2.Nodes(14).Nodes(1).Nodes(3).Nodes.Add("LieferantNr")
        TreeView2.Nodes(14).Nodes(1).Nodes(3).Nodes(1).Nodes.Add("KontoID")
        TreeView2.Nodes(14).Nodes(1).Nodes(3).Nodes(1).Nodes(0).Nodes.Add("BankID")
        TreeView2.Nodes(14).Nodes(1).Nodes(3).Nodes(1).Nodes(0).Nodes(0).Nodes.Add("BankName")
        TreeView2.Nodes(14).Nodes(1).Nodes(3).Nodes(1).Nodes(0).Nodes.Add("Filialnummer")
        TreeView2.Nodes(14).Nodes(1).Nodes(3).Nodes(1).Nodes(0).Nodes.Add("Kontonummer")
        TreeView2.Nodes(14).Nodes(1).Nodes(3).Nodes(1).Nodes(0).Nodes.Add("IBAN")
        TreeView2.Nodes(14).Nodes(1).Nodes(3).Nodes(1).Nodes.Add("SteuerNr")
        TreeView2.Nodes(14).Nodes(1).Nodes(3).Nodes(1).Nodes.Add("FirmenTitel")
        TreeView2.Nodes(14).Nodes(1).Nodes(3).Nodes(1).Nodes.Add("Ansprechspartner")
        TreeView2.Nodes(14).Nodes(1).Nodes(3).Nodes(1).Nodes.Add("Telefon")
        TreeView2.Nodes(14).Nodes(1).Nodes(3).Nodes(1).Nodes.Add("Email")
        TreeView2.Nodes(14).Nodes(1).Nodes(3).Nodes(1).Nodes.Add("AdressID")
        TreeView2.Nodes(14).Nodes(1).Nodes(3).Nodes(1).Nodes(6).Nodes.Add("Strasse")
        TreeView2.Nodes(14).Nodes(1).Nodes(3).Nodes(1).Nodes(6).Nodes.Add("Nummer")
        TreeView2.Nodes(14).Nodes(1).Nodes(3).Nodes(1).Nodes(6).Nodes.Add("Etage")
        TreeView2.Nodes(14).Nodes(1).Nodes(3).Nodes(1).Nodes(6).Nodes.Add("PLZ")
        TreeView2.Nodes(14).Nodes(1).Nodes(3).Nodes(1).Nodes(6).Nodes.Add("OrtID")
        TreeView2.Nodes(14).Nodes(1).Nodes(3).Nodes(1).Nodes(6).Nodes(4).Nodes.Add("Ort")
        TreeView2.Nodes(14).Nodes(1).Nodes(3).Nodes.Add("ProduktName")
        TreeView2.Nodes(14).Nodes(1).Nodes(3).Nodes.Add("ProduktMenge")
        TreeView2.Nodes(14).Nodes(1).Nodes(3).Nodes.Add("ProduktArtNr")
        TreeView2.Nodes(14).Nodes(1).Nodes(3).Nodes(4).Nodes.Add("ProduktArt")
        TreeView2.Nodes(14).Nodes(1).Nodes(3).Nodes(4).Nodes.Add("MwSteuerRate")
        TreeView2.Nodes(14).Nodes(1).Nodes(3).Nodes.Add("ProduktEinzelPreis")
        TreeView2.Nodes(14).Nodes(1).Nodes.Add("AuftragMenge")
        TreeView2.Nodes(14).Nodes(1).Nodes.Add("ProduktEinzelPreis")
        TreeView2.Nodes(14).Nodes(1).Nodes.Add("SummeNetto")
        TreeView2.Nodes(14).Nodes(1).Nodes.Add("MwSteuer")
        TreeView2.Nodes(14).Nodes(1).Nodes.Add("SummeBrutto")
        TreeView2.Nodes(14).Nodes(1).Nodes.Add("AuftragsDatum")

    End Sub

    Private Sub View_Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.CenterToScreen()
        GroupBox2.Text = ""
        GroupBox1.Text = "Join Connections:"
        ListBox1.Sorted = False
        ListBox2.Sorted = False
        ListBox3.Sorted = False
        ListBox4.Sorted = False

        'creates parent and child nodes with table and column names from sql database
        connection.ConnectionString = "Data Source=.\SQLEXPRESS;Initial Catalog=MedikamentFirma1;Integrated Security=True"
        connection.Open()
        Dim cmd As SqlCommand = New SqlCommand("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE'", connection)
        Dim adp As SqlDataAdapter = New SqlDataAdapter(cmd)
        Dim ds As DataSet = New DataSet()
        adp.Fill(ds)
        TreeView2.Nodes.Clear()
        For Each dr As DataRow In ds.Tables(0).Rows
            Dim tnParent As New TreeNode()
            tnParent.Text = dr("TABLE_NAME").ToString()
            tnParent.Tag = dr("TABLE_NAME").ToString()
            tnParent.Expand()
            TreeView2.Nodes.Add(tnParent)
            FillChild(tnParent, tnParent.Tag.ToString())
        Next
        'calls NodeAdd sub, which adds fremdkey conenctions to child nodes manually
        NodeAdd()

    End Sub

    '////////////////////////////////////////////////////////
    '///////////////////// CLEAR BUTTON /////////////////////
    Private Sub Button_Clear_Click(sender As Object, e As EventArgs) Handles Button_Clear.Click
        'clears the checked items and dgw1
        UncheckAllNodes(TreeView2.Nodes)
        TreeView2.CollapseAll()
        DataGridView1.DataSource = Nothing
        ListBox5.Items.Clear()

    End Sub
    '///////////////////// unchecks all nodes /////////////////////
    Public Sub UncheckAllNodes(ByVal nodes As TreeNodeCollection)
        For Each node As TreeNode In nodes
            node.Checked = False
            CheckChildren(node, False)
        Next
    End Sub
    Private Sub CheckChildren(ByVal rootNode As TreeNode, ByVal isChecked As Boolean)
        For Each node As TreeNode In rootNode.Nodes
            CheckChildren(node, isChecked)
            node.Checked = isChecked
        Next
    End Sub
    '/////////////////////////////////////////////////////////
    '///////////////////// CANCEL BUTTON /////////////////////
    Private Sub Button_Cancel_Click(sender As Object, e As EventArgs) Handles Button_Close.Click
        Me.Close()
        Main_Form.Show()
    End Sub
    '//////////////////////////////////////////////////////////
    '///////////////////// REFRESH BUTTON /////////////////////
    Private Sub Button_Refresh_Click(sender As Object, e As EventArgs) Handles Button_Refresh.Click

        DataGridView1.DataSource = Nothing
        'creates column names for sql query
        For i = 0 To ListBox1.Items.Count - 1
            query = query + ListBox1.Items.Item(i).ToString + ", "
        Next
        If bool_multipleChoice = True Then
            MsgBox("Lütfen tek tablo üzerinden seçim yapın.", MsgBoxStyle.Information)
        Else
            If bool_Nodes_Checked = False Then
                MsgBox("Lütfen bir sütun seçiniz.")
            Else
                Dim cmd As String = ""
                If bool_nested_tables = False Then
                    'gets table name for sql query
                    Dim table As String = ListBox5.Items.Item(0).ToString
                    'deleting last extra comma on query string
                    query = Strings.Left(query, Strings.Len(query) - 2)
                    cmd = "SELECT " + query + " FROM " + table + " "
                    Dim adp As SqlDataAdapter = New SqlDataAdapter(cmd, connection)
                    Dim ds As DataSet = New DataSet()
                    adp.Fill(ds)
                    DataGridView1.DataSource = ds.Tables(0)
                    connection.Close()
                Else
                    'deleting last extra comma on query string
                    query = Strings.Left(query, Strings.Len(query) - 2)

                    If ListBox2.Items.Count = ListBox3.Items.Count Then
                        Select Case ListBox2.Items.Count()
                            Case 1
                                Dim table1 As String = ListBox2.Items.Item(0).ToString
                                Dim key1 As String = ListBox3.Items.Item(0).ToString
                                Dim table2 As String = ListBox4.Items.Item(0).ToString
                                cmd = "SELECT " + query + " FROM " + table1 + " INNER JOIN " + table2 + " ON " + table1 + "." + key1 + " = " + table2 + "." + key1
                            Case 2
                                Dim table1 As String = ListBox2.Items.Item(0).ToString
                                Dim key1 As String = ListBox3.Items.Item(0).ToString
                                Dim table2 As String = ListBox4.Items.Item(0).ToString
                                Dim table11 As String = ListBox2.Items.Item(1).ToString
                                Dim key2 As String = ListBox3.Items.Item(1).ToString
                                Dim table22 As String = ListBox4.Items.Item(1).ToString
                                cmd = "SELECT " + query + " FROM " + table1 + " INNER JOIN " + table2 + " ON " + table1 + "." + key1 + " = " + table2 + "." + key1 &
                                    " INNER JOIN " + table22 + " ON " + table11 + "." + key2 + " = " + table22 + "." + key2
                            Case 3
                                Dim table1 As String = ListBox2.Items.Item(0).ToString
                                Dim key1 As String = ListBox3.Items.Item(0).ToString
                                Dim table2 As String = ListBox4.Items.Item(0).ToString
                                Dim table11 As String = ListBox2.Items.Item(1).ToString
                                Dim key2 As String = ListBox3.Items.Item(1).ToString
                                Dim table22 As String = ListBox4.Items.Item(1).ToString
                                Dim table111 As String = ListBox2.Items.Item(2).ToString
                                Dim key3 As String = ListBox3.Items.Item(2).ToString
                                Dim table222 As String = ListBox4.Items.Item(2).ToString
                                cmd = "SELECT " + query + " FROM " + table1 + " INNER JOIN " + table2 + " ON " + table1 + "." + key1 + " = " + table2 + "." + key1 &
                                    " INNER JOIN " + table22 + " ON " + table11 + "." + key2 + " = " + table22 + "." + key2 + " INNER JOIN " + table222 + " ON " + table111 &
                                    "." + key3 + " = " + table222 + "." + key3
                            Case 4
                                Dim table1 As String = ListBox2.Items.Item(0).ToString
                                Dim key1 As String = ListBox3.Items.Item(0).ToString
                                Dim table2 As String = ListBox4.Items.Item(0).ToString
                                Dim table11 As String = ListBox2.Items.Item(1).ToString
                                Dim key2 As String = ListBox3.Items.Item(1).ToString
                                Dim table22 As String = ListBox4.Items.Item(1).ToString
                                Dim table111 As String = ListBox2.Items.Item(2).ToString
                                Dim key3 As String = ListBox3.Items.Item(2).ToString
                                Dim table222 As String = ListBox4.Items.Item(2).ToString
                                Dim table1111 As String = ListBox2.Items.Item(3).ToString
                                Dim key4 As String = ListBox3.Items.Item(3).ToString
                                Dim table2222 As String = ListBox4.Items.Item(3).ToString
                                cmd = "SELECT " + query + " FROM " + table1 + " INNER JOIN " + table2 + " ON " + table1 + "." + key1 + " = " + table2 + "." + key1 &
                                    " INNER JOIN " + table22 + " ON " + table11 + "." + key2 + " = " + table22 + "." + key2 + " INNER JOIN " + table222 + " ON " + table111 &
                                    "." + key3 + " = " + table222 + "." + key3 + " INNER JOIN " + table2222 + " ON " + table1111 + "." + key4 + " = " + table2222 + "." &
                                    key4
                            Case 5
                                Dim table1 As String = ListBox2.Items.Item(0).ToString
                                Dim key1 As String = ListBox3.Items.Item(0).ToString
                                Dim table2 As String = ListBox4.Items.Item(0).ToString
                                Dim table11 As String = ListBox2.Items.Item(1).ToString
                                Dim key2 As String = ListBox3.Items.Item(1).ToString
                                Dim table22 As String = ListBox4.Items.Item(1).ToString
                                Dim table111 As String = ListBox2.Items.Item(2).ToString
                                Dim key3 As String = ListBox3.Items.Item(2).ToString
                                Dim table222 As String = ListBox4.Items.Item(2).ToString
                                Dim table1111 As String = ListBox2.Items.Item(3).ToString
                                Dim key4 As String = ListBox3.Items.Item(3).ToString
                                Dim table2222 As String = ListBox4.Items.Item(3).ToString
                                Dim table11111 As String = ListBox2.Items.Item(4).ToString
                                Dim key5 As String = ListBox3.Items.Item(4).ToString
                                Dim table22222 As String = ListBox4.Items.Item(4).ToString
                                cmd = "SELECT " + query + " FROM " + table1 + " INNER JOIN " + table2 + " ON " + table1 + "." + key1 + " = " + table2 + "." + key1 &
                                    " INNER JOIN " + table22 + " ON " + table11 + "." + key2 + " = " + table22 + "." + key2 + " INNER JOIN " + table222 + " ON " + table111 &
                                    "." + key3 + " = " + table222 + "." + key3 + " INNER JOIN " + table2222 + " ON " + table1111 + "." + key4 + " = " + table2222 + "." &
                                    key4 + " INNER JOIN " + table22222 + " ON " + table11111 + "." + key5 + " = " + table22222 + "." + key5
                            Case 6
                                Dim table1 As String = ListBox2.Items.Item(0).ToString
                                Dim key1 As String = ListBox3.Items.Item(0).ToString
                                Dim table2 As String = ListBox4.Items.Item(0).ToString
                                Dim table11 As String = ListBox2.Items.Item(1).ToString
                                Dim key2 As String = ListBox3.Items.Item(1).ToString
                                Dim table22 As String = ListBox4.Items.Item(1).ToString
                                Dim table111 As String = ListBox2.Items.Item(2).ToString
                                Dim key3 As String = ListBox3.Items.Item(2).ToString
                                Dim table222 As String = ListBox4.Items.Item(2).ToString
                                Dim table1111 As String = ListBox2.Items.Item(3).ToString
                                Dim key4 As String = ListBox3.Items.Item(3).ToString
                                Dim table2222 As String = ListBox4.Items.Item(3).ToString
                                Dim table11111 As String = ListBox2.Items.Item(4).ToString
                                Dim key5 As String = ListBox3.Items.Item(4).ToString
                                Dim table22222 As String = ListBox4.Items.Item(4).ToString
                                Dim table111111 As String = ListBox2.Items.Item(5).ToString
                                Dim key6 As String = ListBox3.Items.Item(5).ToString
                                Dim table222222 As String = ListBox4.Items.Item(5).ToString
                                cmd = "SELECT " + query + " FROM " + table1 + " INNER JOIN " + table2 + " ON " + table1 + "." + key1 + " = " + table2 + "." + key1 &
                                    " INNER JOIN " + table22 + " ON " + table11 + "." + key2 + " = " + table22 + "." + key2 + " INNER JOIN " + table222 + " ON " + table111 &
                                    "." + key3 + " = " + table222 + "." + key3 + " INNER JOIN " + table2222 + " ON " + table1111 + "." + key4 + " = " + table2222 + "." &
                                    key4 + " INNER JOIN " + table22222 + " ON " + table11111 + "." + key5 + " = " + table22222 + "." + key5 + " INNER JOIN " + table222222 &
                                    " ON " + table111111 + "." + key6 + " = " + table222222 + "." + key6
                        End Select
                        Dim adp As SqlDataAdapter = New SqlDataAdapter(cmd, connection)
                        Dim ds As DataSet = New DataSet()
                        adp.Fill(ds)
                        DataGridView1.DataSource = ds.Tables(0)
                        connection.Close()
                    Else
                        'ilk tabloya fazlalık olan yani 2 ve 3'teki son itemlar bağlanır.
                    End If
                End If
            End If
        End If
    End Sub

    Sub Tables_KeyDetection()
        'iç içe node'larda 0 indexli sütunlar PK olarak baz alınır
        For i = 0 To TreeView2.Nodes.Count() - 1
            For j = 0 To TreeView2.Nodes(i).Nodes.Count() - 1

                If TreeView2.Nodes(i).Nodes(j).Checked = True Then
                    bool_Nodes_Checked = True
                    'check edilen elemanlar listbox1'e eklenir
                    If Not ListBox1.Items.Contains(TreeView2.Nodes(i).Nodes(j).Text) Then
                        ListBox1.Items.Add(TreeView2.Nodes(i).Nodes(j).Text)
                    End If
                    'check edilmiş olan elemanların ait oldukları tablo isimleri listbox5'e eklenir
                    If Not ListBox5.Items.Contains(TreeView2.Nodes(i).Text) Then
                        ListBox5.Items.Add(TreeView2.Nodes(i).Text)
                    End If
                End If

                For k = 0 To TreeView2.Nodes(i).Nodes(j).Nodes.Count - 1

                    If TreeView2.Nodes(i).Nodes(j).Nodes(k).Checked = True Then
                        bool_Nodes_Checked = True

                        If Not ListBox1.Items.Contains(TreeView2.Nodes(i).Nodes(j).Nodes(k).Text) Then
                            'check edilen elemanlar listbox1'e eklenir
                            ListBox1.Items.Add(TreeView2.Nodes(i).Nodes(j).Nodes(k).Text)
                        End If
                        'seçilen iç içe tabloların bağlantı elemanlarının listbox1-2-3'e eklenebilmeleri için ana tablo isimleri ve
                        'ana tabloların 0 indexli PK isimleriyle karşılaştırılır. Böylece seçilen PK isminin hangi ana tabloya bağlı olduğu bulunur.
                        For pk = 0 To TreeView2.Nodes.Count() - 1
                            If TreeView2.Nodes(i).Nodes(j).Text = TreeView2.Nodes(pk).Nodes(0).Text Then
                                If Not ListBox2.Items.Contains(TreeView2.Nodes(i).Text) Then
                                    ListBox2.Items.Add(TreeView2.Nodes(i).Text)
                                End If
                                If Not ListBox3.Items.Contains(TreeView2.Nodes(pk).Nodes(0).Text) Then
                                    ListBox3.Items.Add(TreeView2.Nodes(pk).Nodes(0).Text)
                                End If
                                If Not ListBox4.Items.Contains(TreeView2.Nodes(pk).Text) Then
                                    ListBox4.Items.Add(TreeView2.Nodes(pk).Text)
                                End If
                            End If
                        Next
                    End If

                    For l = 0 To TreeView2.Nodes(i).Nodes(j).Nodes(k).Nodes.Count - 1

                        If TreeView2.Nodes(i).Nodes(j).Nodes(k).Nodes(l).Checked = True Then

                            bool_Nodes_Checked = True
                            If Not ListBox1.Items.Contains(TreeView2.Nodes(i).Nodes(j).Nodes(k).Nodes(l).Text) Then
                                ListBox1.Items.Add(TreeView2.Nodes(i).Nodes(j).Nodes(k).Nodes(l).Text)
                            End If
                            For pk = 0 To TreeView2.Nodes.Count() - 1
                                If TreeView2.Nodes(i).Nodes(j).Nodes(k).Text = TreeView2.Nodes(pk).Nodes(0).Text Then
                                    'iç içe tablolar olduğu için ekstra inner join yazılacak. söz konusu pk'in tablo ismi bulunmalı
                                    'iç içe tablolar için (pk_in)
                                    For pk_in = 0 To TreeView2.Nodes.Count - 1
                                        If TreeView2.Nodes(i).Nodes(j).Text = TreeView2.Nodes(pk_in).Nodes(0).Text Then
                                            If Not ListBox2.Items.Contains(TreeView2.Nodes(i).Nodes(j).Text) Then
                                                ListBox2.Items.Add(TreeView2.Nodes(pk_in).Text)
                                            End If
                                        End If
                                    Next
                                    If Not ListBox3.Items.Contains(TreeView2.Nodes(pk).Nodes(0).Text) Then
                                        ListBox3.Items.Add(TreeView2.Nodes(pk).Nodes(0).Text)
                                    End If
                                    If Not ListBox4.Items.Contains(TreeView2.Nodes(pk).Text) Then
                                        ListBox4.Items.Add(TreeView2.Nodes(pk).Text)
                                    End If
                                End If
                            Next
                        End If

                        For m = 0 To TreeView2.Nodes(i).Nodes(j).Nodes(k).Nodes(l).Nodes.Count - 1

                            If TreeView2.Nodes(i).Nodes(j).Nodes(k).Nodes(l).Nodes(m).Checked = True Then

                                bool_Nodes_Checked = True
                                If Not ListBox1.Items.Contains(TreeView2.Nodes(i).Nodes(j).Nodes(k).Nodes(l).Nodes(m).Text) Then
                                    ListBox1.Items.Add(TreeView2.Nodes(i).Nodes(j).Nodes(k).Nodes(l).Nodes(m).Text)
                                End If
                                For pk = 0 To TreeView2.Nodes.Count - 1
                                    If TreeView2.Nodes(i).Nodes(j).Nodes(k).Nodes(l).Text = TreeView2.Nodes(pk).Nodes(0).Text Then
                                        'iç içe tablolar olduğu için ekstra inner join yazılacak. söz konusu pk'in tablo ismi bulunmalı
                                        'iç içe tablolar için (pk_in)
                                        For pk_in = 0 To TreeView2.Nodes.Count - 1
                                            If TreeView2.Nodes(i).Nodes(j).Nodes(k).Text = TreeView2.Nodes(pk_in).Nodes(0).Text Then
                                                If Not ListBox2.Items.Contains(TreeView2.Nodes(i).Nodes(j).Nodes(k).Text) Then
                                                    ListBox2.Items.Add(TreeView2.Nodes(pk_in).Text)
                                                End If
                                            End If
                                        Next
                                        If Not ListBox3.Items.Contains(TreeView2.Nodes(pk).Nodes(0).Text) Then
                                            ListBox3.Items.Add(TreeView2.Nodes(pk).Nodes(0).Text)
                                        End If
                                        If Not ListBox4.Items.Contains(TreeView2.Nodes(pk).Text) Then
                                            ListBox4.Items.Add(TreeView2.Nodes(pk).Text)
                                        End If
                                    End If
                                Next
                            End If

                            For n = 0 To TreeView2.Nodes(i).Nodes(j).Nodes(k).Nodes(l).Nodes(m).Nodes.Count - 1

                                If TreeView2.Nodes(i).Nodes(j).Nodes(k).Nodes(l).Nodes(m).Nodes(n).Checked = True Then

                                    bool_Nodes_Checked = True
                                    If Not ListBox1.Items.Contains(TreeView2.Nodes(i).Nodes(j).Nodes(k).Nodes(l).Nodes(m).Nodes(n).Text) Then
                                        ListBox1.Items.Add(TreeView2.Nodes(i).Nodes(j).Nodes(k).Nodes(l).Nodes(m).Nodes(n).Text)
                                    End If
                                    For pk = 0 To TreeView2.Nodes.Count - 1
                                        If TreeView2.Nodes(i).Nodes(j).Nodes(k).Nodes(l).Nodes(m).Text = TreeView2.Nodes(pk).Nodes(0).Text Then
                                            'iç içe tablolar olduğu için ekstra inner join yazılacak. söz konusu pk'in tablo ismi bulunmalı
                                            'iç içe tablolar için (pk_in)
                                            For pk_in = 0 To TreeView2.Nodes.Count - 1
                                                If TreeView2.Nodes(i).Nodes(j).Nodes(k).Nodes(l).Text = TreeView2.Nodes(pk_in).Nodes(0).Text Then
                                                    If Not ListBox2.Items.Contains(TreeView2.Nodes(i).Nodes(j).Nodes(k).Nodes(l).Text) Then
                                                        ListBox2.Items.Add(TreeView2.Nodes(pk_in).Text)
                                                    End If
                                                End If
                                            Next
                                            If Not ListBox3.Items.Contains(TreeView2.Nodes(pk).Nodes(0).Text) Then
                                                ListBox3.Items.Add(TreeView2.Nodes(pk).Nodes(0).Text)
                                            End If
                                            If Not ListBox4.Items.Contains(TreeView2.Nodes(pk).Text) Then
                                                ListBox4.Items.Add(TreeView2.Nodes(pk).Text)
                                            End If
                                        End If
                                    Next
                                End If

                                For o = 0 To TreeView2.Nodes(i).Nodes(j).Nodes(k).Nodes(l).Nodes(m).Nodes(n).Nodes.Count - 1

                                    If TreeView2.Nodes(i).Nodes(j).Nodes(k).Nodes(l).Nodes(m).Nodes(n).Nodes(o).Checked = True Then

                                        bool_Nodes_Checked = True
                                        If Not ListBox1.Items.Contains(TreeView2.Nodes(i).Nodes(j).Nodes(k).Nodes(l).Nodes(m).Nodes(n).Nodes(o).Text) Then
                                            ListBox1.Items.Add(TreeView2.Nodes(i).Nodes(j).Nodes(k).Nodes(l).Nodes(m).Nodes(n).Nodes(o).Text)
                                        End If
                                        For pk = 0 To TreeView2.Nodes.Count - 1
                                            If TreeView2.Nodes(i).Nodes(j).Nodes(k).Nodes(l).Nodes(m).Nodes(n).Text = TreeView2.Nodes(pk).Nodes(0).Text Then
                                                'iç içe tablolar olduğu için ekstra inner join yazılacak. söz konusu pk'in tablo ismi bulunmalı
                                                'iç içe tablolar için (pk_in)
                                                For pk_in = 0 To TreeView2.Nodes.Count - 1
                                                    If TreeView2.Nodes(i).Nodes(j).Nodes(k).Nodes(l).Nodes(m).Text = TreeView2.Nodes(pk_in).Nodes(0).Text Then
                                                        If Not ListBox2.Items.Contains(TreeView2.Nodes(i).Nodes(j).Nodes(k).Nodes(l).Nodes(m).Text) Then
                                                            ListBox2.Items.Add(TreeView2.Nodes(pk_in).Text)
                                                        End If
                                                    End If
                                                Next
                                                If Not ListBox3.Items.Contains(TreeView2.Nodes(pk).Nodes(0).Text) Then
                                                    ListBox3.Items.Add(TreeView2.Nodes(pk).Nodes(0).Text)
                                                End If
                                                If Not ListBox4.Items.Contains(TreeView2.Nodes(pk).Text) Then
                                                    ListBox4.Items.Add(TreeView2.Nodes(pk).Text)
                                                End If
                                            End If
                                        Next
                                    End If
                                Next
                            Next
                        Next
                    Next
                Next
            Next
        Next
    End Sub

    Private Sub TreeView2_AfterCheck(sender As Object, e As TreeViewEventArgs) Handles TreeView2.AfterCheck
        ListBox1.Items.Clear()
        ListBox2.Items.Clear()
        ListBox3.Items.Clear()
        ListBox4.Items.Clear()
        ListBox5.Items.Clear()
        query = ""
        Tables_KeyDetection()
        If ListBox5.Items.Count > 1 Then
            bool_multipleChoice = True
        Else
            bool_multipleChoice = False
        End If

        If ListBox3.Items.Count > 0 Then
            bool_nested_tables = True
        Else
            bool_nested_tables = False
        End If
        'iç içe yapılacak olan seçimlerde birden fazla INNER JOIN kullanılmalı.
        'ON kısmında yapılan PK ve FK eşitlemelerinde kullanılan sütun isimleri SELECT'ten sonra çağrılırken yeniden düzenlenmeli
        'ÖRN: SELECT RechnungsNr, **AuftragsNr**, KundenNr FROM Rechnung INNER JOIN Auftrag ON Rechnung.AuftragsNr = Auftrag.AuftragsNr
        'ÖRN: SELECT RechnungsNr, **Rechnung.AuftragsNr**, KundenNr FROM Rechnung INNER JOIN Auftrag ON Rechnung.AuftragsNr = Auftrag.AuftragsNr
        For ix_ListBox1 = 0 To ListBox1.Items.Count - 1
            For ix_ListBox3 = 0 To ListBox2.Items.Count - 1
                If ListBox1.Items.Item(ix_ListBox1).ToString = ListBox3.Items.Item(ix_ListBox3).ToString Then
                    ListBox1.Items.Item(ix_ListBox1) = ListBox2.Items.Item(ix_ListBox3) + "." + ListBox3.Items.Item(ix_ListBox3)
                End If
            Next
        Next
    End Sub
    '////////////////////////////////////////////////////////////////////////////////////////
    '///////////// designs checkboxes on children nodes and not on parent nodes /////////////
    Private Const TVIF_STATE As Integer = &H8
    Private Const TVIS_STATEIMAGEMASK As Integer = &HF000
    Private Const TV_FIRST As Integer = &H1100
    Private Const TVM_SETITEM As Integer = TV_FIRST + 63

    Public Structure TVITEM
        Public mask As Integer
        Public hItem As IntPtr
        Public state As Integer
        Public stateMask As Integer

        Public cchTextMax As Integer
        Public iImage As Integer
        Public iSelectedImage As Integer
        Public cChildren As Integer
        Public lParam As IntPtr
    End Structure
    Private Declare Auto Function SendMessage Lib "User32.dll" (ByVal hwnd As IntPtr, ByVal msg As Integer, ByVal wParam As IntPtr, ByRef lParam As TVITEM) As Integer
    Private Sub HideRootCheckBox(ByVal node As TreeNode)
        Dim tvi As New TVITEM
        tvi.hItem = node.Handle
        tvi.mask = TVIF_STATE
        tvi.stateMask = TVIS_STATEIMAGEMASK
        tvi.state = 0
        SendMessage(TreeView2.Handle, TVM_SETITEM, IntPtr.Zero, tvi)
    End Sub

    Private Sub TreeView1_DrawNode(ByVal sender As Object, ByVal e As DrawTreeNodeEventArgs) Handles TreeView2.DrawNode
        If e.Node.Parent Is Nothing Then
            HideRootCheckBox(e.Node)
        End If
        e.DrawDefault = True
    End Sub
End Class