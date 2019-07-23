Imports VimapontoTest.Model
Imports VimapontoTest.Controller.Services

Public Class DocumentoLista

    Private _DocumentoId As Integer

    Public Property DocumentoId As Integer
        Get
            Return _DocumentoId
        End Get
        Set(ByVal value As Integer)
            _DocumentoId = value
        End Set
    End Property

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        CarregarComboTipo()
        CarregarComboCliente()

        lvDocumento.View = System.Windows.Forms.View.Details
        lvDocumento.LabelEdit = False
        lvDocumento.AllowColumnReorder = True
        lvDocumento.FullRowSelect = True
        lvDocumento.GridLines = True

        lvDocumento.Columns.Add("Id", 30, HorizontalAlignment.Left)
        lvDocumento.Columns.Add("Tipo", 140, HorizontalAlignment.Left)
        lvDocumento.Columns.Add("Cliente", 200, HorizontalAlignment.Left)
        lvDocumento.Columns.Add("Descrição", 280, HorizontalAlignment.Left)

        CarregarListDocumentos(Nothing, Nothing)

    End Sub

    Private Sub CarregarListDocumentos(ByVal pTipoId As Nullable(Of Integer), _
                                       ByVal pClienteId As Nullable(Of Integer))
        lvDocumento.Items.Clear()

        Dim documentos As List(Of Documento)
        documentos = New DocumentoService().Listar(pTipoId, pClienteId)

        For i As Integer = 0 To documentos.Count - 1
            Dim lvi As New ListViewItem(documentos(i).DocumentoId)
            lvi.SubItems.Add(documentos(i).ObjTipo.Descricao)
            lvi.SubItems.Add(documentos(i).ObjCliente.Nome)
            lvi.SubItems.Add(documentos(i).Descricao)
            lvDocumento.Items.Add(lvi)
        Next
    End Sub

    Private Sub CarregarComboTipo()
        Dim tipos As New List(Of Tipo)
        tipos = New TipoService().ListarTodos()

        cbTipo.DataSource = tipos
        cbTipo.DisplayMember = "Descricao"
        cbTipo.ValueMember = "TipoId"
        cbTipo.SelectedIndex = -1
    End Sub

    Private Sub CarregarComboCliente()
        Dim Clientes As New List(Of Cliente)
        Clientes = New ClienteService().ListarTodos()

        cbCliente.DisplayMember = "Nome"
        cbCliente.ValueMember = "ClienteId"
        cbCliente.DataSource = Clientes
        cbCliente.SelectedIndex = -1
    End Sub

    Private Sub BtnUsar_Click(sender As Object, e As EventArgs) Handles BtnUsar.Click
        If (lvDocumento.SelectedItems.Count = 0) Then
            MessageBox.Show("Selecione um documento.")
            Exit Sub
        End If

        Dim lvi As ListViewItem = lvDocumento.SelectedItems(0)
        DocumentoId = lvi.SubItems(0).Text

        Me.Close()
    End Sub

    Private Sub btnFiltrar_Click(sender As Object, e As EventArgs) Handles btnFiltrar.Click
        Dim TipoId As Nullable(Of Integer)
        If cbTipo.SelectedIndex > -1 Then
            TipoId = CInt(cbTipo.SelectedValue)
        End If

        Dim ClienteId As Nullable(Of Integer)
        If cbCliente.SelectedIndex > -1 Then
            ClienteId = CInt(cbCliente.SelectedValue)
        End If

        CarregarListDocumentos(TipoId, ClienteId)
    End Sub

    Private Sub btnSair_Click(sender As Object, e As EventArgs) Handles btnSair.Click
        DocumentoId = 0
        Me.Close()
    End Sub

    Private Sub btnLimpar_Click(sender As Object, e As EventArgs) Handles btnLimpar.Click
        cbTipo.SelectedIndex = -1
        cbCliente.SelectedIndex = -1
        CarregarListDocumentos(Nothing, Nothing)
    End Sub
End Class