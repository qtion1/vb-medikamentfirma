Imports System.Data.SqlClient
Public Class Main_Form
    Dim connection As SqlConnection = New SqlConnection()

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.CenterToScreen()
        '////////////////////////////////////////////////////////////////////////////
        'creates parent and child nodes with table and column names from sql database
        connection.ConnectionString = "Data Source=.\SQLEXPRESS;Initial Catalog=MedikamentFirma1;Integrated Security=True"
        connection.Open()
        Dim cmd As SqlCommand = New SqlCommand("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE'", connection)
        Dim adp As SqlDataAdapter = New SqlDataAdapter(cmd)
        Dim ds As DataSet = New DataSet()
        adp.Fill(ds)

        TreeView1.Nodes.Clear()
        For Each dr As DataRow In ds.Tables(0).Rows
            Dim tnParent As New TreeNode()
            tnParent.Text = dr("TABLE_NAME").ToString()
            tnParent.Tag = dr("TABLE_NAME").ToString()
            tnParent.Expand()
            TreeView1.Nodes.Add(tnParent)
            FillChild(tnParent, tnParent.Tag.ToString())
        Next
    End Sub
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
    '//////////////////////////////////////////////////////////////
    '/////////////////////// REFRESH BUTTON ///////////////////////
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button_Refresh.Click

        DataGridView1.DataSource = Nothing
        'creates column names for sql query
        Dim query As String = ""
        For Each n As TreeNode In GetCheck(TreeView1.Nodes)
            query = query + (n.Text + ", ")
        Next

        If GetCheck(TreeView1.Nodes).Count() < 1 Then
            MsgBox("Lütfen bir sütun seçiniz.")
        Else
            'gets table name for sql query
            Dim t As String = TreeView1.SelectedNode.Text
            'deleting last extra comma on query string
            query = Strings.Left(query, Strings.Len(query) - 2)
            'gets checked columns to dgw1

            Dim adp As SqlDataAdapter = New SqlDataAdapter("SELECT " + query + " FROM " + t + " ", connection)
            Dim ds As DataSet = New DataSet()
            adp.Fill(ds)
            DataGridView1.DataSource = ds.Tables(0)
            connection.Close()
        End If
    End Sub
    'gets the checked nodes
    Private Function GetCheck(ByVal node As TreeNodeCollection) As ArrayList
        Dim lN As New ArrayList
        For Each n As TreeNode In node
            If n.Checked Then lN.Add(n)
            lN.AddRange(GetCheck(n.Nodes))
        Next
        Return lN
    End Function
    'one-click expand
    Private Sub TreeView1_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles TreeView1.NodeMouseClick
        If e.Node.IsExpanded Then
            e.Node.TreeView.Select()
            e.Node.Collapse()
        Else
            e.Node.Expand()
            e.Node.TreeView.Select()
        End If
    End Sub
    'close other nodes except the selected node
    Private Sub TreeView1_BeforeExpand(sender As Object, e As TreeViewCancelEventArgs) Handles TreeView1.BeforeExpand
        TreeView1.CollapseAll()
        UncheckAllNodes(TreeView1.Nodes)
        ExpandPath(e.Node)
    End Sub
    Private Sub ExpandPath(ByVal SelectedNode As TreeNode)
        While (Not (SelectedNode.Parent) Is Nothing)
            SelectedNode = SelectedNode.Parent
            SelectedNode.Expand()
        End While
    End Sub
    'unchecks all nodes
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
    'designs checkboxes on children nodes and not on parent nodes
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
        SendMessage(TreeView1.Handle, TVM_SETITEM, IntPtr.Zero, tvi)
    End Sub

    Private Sub TreeView1_DrawNode(ByVal sender As Object, ByVal e As DrawTreeNodeEventArgs) Handles TreeView1.DrawNode
        If e.Node.Parent Is Nothing Then
            HideRootCheckBox(e.Node)
        End If

        e.DrawDefault = True
    End Sub
    '/////////////////////// CLEAR BUTTON ///////////////////////
    Private Sub Button_Clear_Click(sender As Object, e As EventArgs) Handles Button_Clear.Click
        'clears the checked items and dgw1
        UncheckAllNodes(TreeView1.Nodes)
        TreeView1.CollapseAll()
        DataGridView1.DataSource = Nothing
    End Sub

    Private Sub Button_Cancel_Click(sender As Object, e As EventArgs) Handles Button_Cancel.Click
        Me.Close()
    End Sub
    Private Sub Button_View_Click(sender As Object, e As EventArgs) Handles Button_View.Click
        Me.Hide()
        View_Form.Show()
    End Sub
    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        MsgBox("You can edit only ""Auftrag"" and ""Rechnung"" tables.", MsgBoxStyle.Information)
        If Panel1.Visible = True Then
            Panel1.Visible = False
        Else
            Panel1.Visible = True
        End If
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Insert_Form.Show()
    End Sub
End Class