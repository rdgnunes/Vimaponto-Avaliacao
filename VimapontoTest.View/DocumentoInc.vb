Imports VimapontoTest.Model
Imports VimapontoTest.Controller.Services

Public Class DocumentoInc

    Private oDocumento As New Documento(New Tipo(), New Cliente())

    Private Sub DocumentoInc_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            CarregarComboTipo()
            CarregarComboCliente()

            lvArtigos.View = System.Windows.Forms.View.Details
            lvArtigos.LabelEdit = False
            lvArtigos.AllowColumnReorder = True
            lvArtigos.FullRowSelect = True
            lvArtigos.GridLines = True

            lvArtigos.Columns.Add("#", 20, HorizontalAlignment.Left)
            lvArtigos.Columns.Add("Artigo", 100, HorizontalAlignment.Left)
            lvArtigos.Columns.Add("Descrição", 350, HorizontalAlignment.Left)
            lvArtigos.Columns.Add("Entrega", 150, HorizontalAlignment.Left)
            lvArtigos.Columns.Add("Preço Unit.", 100, HorizontalAlignment.Left)
            lvArtigos.Columns.Add("Quantidade", 100, HorizontalAlignment.Left)
            lvArtigos.Columns.Add("Total", 100, HorizontalAlignment.Left)

            txtDocumentoId.Text = 1
            CarregarDocumento(txtDocumentoId.Text)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LimparCampos()
        CarregarDocumento(Nothing)

        'DOCUMENTO
        cbTipo.SelectedIndex = -1
        txtDescricaoDoc.Text = ""
        txtDocumentoId.Text = ""
        txtDataAlteracao.Text = ""
        txtHoraAlteracao.Text = ""

        'CLIENTE
        cbCliente.SelectedIndex = -1
        txtNome.Text = ""
        txtMorada.Text = ""
        txtContato.Text = ""

        'ITENS
        lvArtigos.Items.Clear()
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

        cbCliente.DisplayMember = "ClienteId"
        cbCliente.ValueMember = "ClienteId"
        cbCliente.DataSource = Clientes
        cbCliente.SelectedIndex = -1
    End Sub

    Private Sub CarregarListArtigo()
        lvArtigos.Items.Clear()

        For i As Integer = 0 To oDocumento.Itens.Count - 1
            Dim lvi As New ListViewItem(i + 1)
            lvi.SubItems.Add(oDocumento.Itens(i).ObjArtigo.Codigo)
            lvi.SubItems.Add(oDocumento.Itens(i).ObjArtigo.Descricao)
            lvi.SubItems.Add(oDocumento.Itens(i).DataEntrega.ToString("dd/MM/yyyy"))

            Dim PrecoUnit As String = "0"
            If oDocumento.Itens(i).Quantidade > 0 Then
                PrecoUnit = (oDocumento.Itens(i).Valor / oDocumento.Itens(i).Quantidade)
            End If

            lvi.SubItems.Add(PrecoUnit)
            lvi.SubItems.Add(oDocumento.Itens(i).Quantidade.ToString)
            lvi.SubItems.Add(oDocumento.Itens(i).Valor.ToString)

            lvArtigos.Items.Add(lvi)
        Next
        butNovoArtigo.Enabled = True
    End Sub

    Private Sub CarregarDocumento(ByVal DocumentId As String)
        Try
            If String.IsNullOrEmpty(DocumentId) Then
                oDocumento = Nothing
                Exit Sub
            End If

            oDocumento = New DocumentoService().CarregarPorId(CInt(DocumentId))

            'DOCUMENTO
            cbTipo.SelectedValue = oDocumento.ObjTipo.TipoId
            txtDescricaoDoc.Text = oDocumento.Descricao
            txtDocumentoId.Text = oDocumento.DocumentoId
            txtDataAlteracao.Text = oDocumento.DataAlteracao.ToString("dd/MM/yyyy")
            txtHoraAlteracao.Text = oDocumento.DataAlteracao.ToString("hh:MM:ss")

            'CLIENTE
            CarregarCliente(oDocumento.ObjCliente)

            'ARTIGOS
            CarregarListArtigo()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub CarregarCliente(ByVal oCliente As Cliente)
        Try
            cbCliente.SelectedValue = oCliente.ClienteId
            txtNome.Text = oCliente.Nome
            txtMorada.Text = oCliente.Morada
            txtContato.Text = oCliente.Contato
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub MoverItemList(ByVal iDirecao As Integer)
        If (lvArtigos.SelectedItems.Count = 0) Then
            Exit Sub
        End If

        Dim lvi As ListViewItem = lvArtigos.SelectedItems(0)
        Dim pos As Integer = lvArtigos.Items.IndexOf(lvi) + iDirecao
        If pos >= 0 Then
            lvArtigos.Items.Remove(lvi)
            lvArtigos.Items.Insert(pos, lvi)
        End If
    End Sub

    Private Sub btnNovo_Click(sender As Object, e As EventArgs) Handles btnNovo.Click
        LimparCampos()
        cbTipo.Enabled = True
        txtDescricaoDoc.Enabled = True
        cbCliente.Enabled = True

        btnGravar.Enabled = True
        btnEliminar.Enabled = True
    End Sub

    Private Sub butApagarArtigo_Click(sender As Object, e As EventArgs) Handles butApagarArtigo.Click
        If (lvArtigos.SelectedItems.Count = 0) Then
            Exit Sub
        End If

        Dim lvi As ListViewItem = lvArtigos.SelectedItems(0)
        Dim pos As Integer = lvArtigos.Items.IndexOf(lvi) - 1
        If pos >= 0 Then
            lvArtigos.Items.Remove(lvi)
        End If

        'Dim item As New ListViewItem
        'item = lvArtigos.SelectedItems(0)

        'Dim oItem As New Item(New Documento(New Tipo(), New Cliente()), New Artigo())
        'oItem = oDocumento.Itens.Find(Function(f) f.Ordem = Convert.ToInt32(item.SubItems(0).Text))

        'MessageBox.Show(New ItemService().Deletar(oItem))

        'oDocumento.Itens = New ItemService().ListarTodosPorDocumento(oDocumento)

        'CarregarListArtigo()
    End Sub

    Private Sub lvArtigos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvArtigos.SelectedIndexChanged
        butApagarArtigo.Enabled = True
        butCima.Enabled = (lvArtigos.Items.Count > 1)
        butBaixo.Enabled = (lvArtigos.Items.Count > 1)
    End Sub

    Private Sub cbCliente_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbCliente.SelectedValueChanged
        If (Not String.IsNullOrEmpty(cbCliente.SelectedValue) And String.IsNullOrEmpty(txtDocumentoId.Text)) Then
            CarregarCliente(New ClienteService().CarregarPorId(cbCliente.SelectedValue))
        End If
    End Sub

    Private Sub butCima_Click(sender As Object, e As EventArgs) Handles butCima.Click
        MoverItemList(-1)
    End Sub

    Private Sub butBaixo_Click(sender As Object, e As EventArgs) Handles butBaixo.Click
        MoverItemList(1)
    End Sub
End Class