Imports VimapontoTest.Model
Imports VimapontoTest.Controller.Services

Public Class DocumentoInc

    Private oDocumento As New Documento(New Tipo(), New Cliente())
    Private flNovo As Boolean = False
    Private cboCarregada As Boolean = False
    Private RowTotal As Integer = 0

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
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
        lvArtigos.Columns.Add("ArtigoId", 0, HorizontalAlignment.Left)

        btnFiltro.Image = Image.FromFile("C:\\Particular\\VimapontoTest\\img\\filter.bmp")

        CarregarDocumento(txtDocumentoId.Text)
    End Sub

    Private Sub LimparForm()
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

        btnRelatorio.Enabled = False
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

        cboCarregada = True
    End Sub

    Private Sub CarregarListArtigo()
        lvArtigos.Items.Clear()

        For i As Integer = 0 To oDocumento.Itens.Count - 1
            Dim lvi As New ListViewItem(i + 1)
            lvi.SubItems.Add(oDocumento.Itens(i).ObjArtigo.Codigo)
            lvi.SubItems.Add(oDocumento.Itens(i).ObjArtigo.Descricao)
            lvi.SubItems.Add(oDocumento.Itens(i).DataEntrega.ToString("dd/MM/yyyy"))
            lvi.SubItems.Add(oDocumento.Itens(i).Valor.ToString("F"))
            lvi.SubItems.Add(oDocumento.Itens(i).Quantidade.ToString)

            Dim Total As String = "0,00"
            If oDocumento.Itens(i).Quantidade > 0 Then
                Total = (oDocumento.Itens(i).Valor * oDocumento.Itens(i).Quantidade).ToString("F")
            End If
            lvi.SubItems.Add(Total)
            lvi.SubItems.Add(oDocumento.Itens(i).ObjArtigo.ArtigoId.ToString)
            lvArtigos.Items.Add(lvi)
        Next

        AjustarTotalEIndex()
        butNovoArtigo.Enabled = True
    End Sub

    Public Sub AjustarTotalEIndex()
        If lvArtigos.Items.Count = 0 Then
            Exit Sub
        End If

        If lvArtigos.Items(lvArtigos.Items.Count - 1).SubItems(0).Text = "" Then
            lvArtigos.Items.RemoveAt(lvArtigos.Items.Count - 1)
        End If

        Dim QtdTotal As Integer = 0
        Dim VlrTotal As Double = 0
        For i As Integer = 0 To lvArtigos.Items.Count - 1
            lvArtigos.Items(i).SubItems(0).Text = i + 1
            If Not String.IsNullOrEmpty(lvArtigos.Items(i).SubItems(5).Text) Then
                QtdTotal += CInt(lvArtigos.Items(i).SubItems(5).Text)
            End If

            If Not String.IsNullOrEmpty(lvArtigos.Items(i).SubItems(6).Text) Then
                VlrTotal += CDbl(lvArtigos.Items(i).SubItems(6).Text)
            End If
        Next

        Dim lvi As New ListViewItem()
        lvi.SubItems.Add("")
        lvi.SubItems.Add("")
        lvi.SubItems.Add("")
        lvi.SubItems.Add("")
        lvi.SubItems.Add(QtdTotal)
        lvi.SubItems.Add(VlrTotal)
        lvArtigos.Items.Add(lvi)

        RowTotal = lvArtigos.Items.IndexOf(lvi)
    End Sub

    Private Sub CarregarDocumento(ByVal DocumentId As String)
        Try
            If String.IsNullOrEmpty(DocumentId) Then
                oDocumento = New Documento(New Tipo(), New Cliente())
                oDocumento.Itens = New List(Of Item)

                btnGravar.Enabled = False
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

            btnEliminar.Enabled = True
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

    Private Sub CarregarItensListView(ByVal pDocumento As Documento)
        oDocumento.Itens.Clear()
        For i As Integer = 0 To lvArtigos.Items.Count - 1
            If Not String.IsNullOrEmpty(lvArtigos.Items(i).SubItems(0).Text) Then
                Dim oArtigo As New Artigo()
                If Not String.IsNullOrEmpty(lvArtigos.Items(i).SubItems(0).Text) Then
                    oArtigo = New ArtigoService().CarregarPorId(CInt(lvArtigos.Items(i).SubItems(7).Text))
                End If

                Dim oItem As New Item(pDocumento, oArtigo)
                oItem.Ordem = lvArtigos.Items(i).SubItems(0).Text

                If IsDate(lvArtigos.Items(i).SubItems(3).Text) Then
                    oItem.DataEntrega = DateTime.Parse(lvArtigos.Items(i).SubItems(3).Text)
                End If

                oItem.Valor = lvArtigos.Items(i).SubItems(4).Text
                oItem.Quantidade = lvArtigos.Items(i).SubItems(5).Text

                oDocumento.Itens.Add(oItem)
            End If
        Next
    End Sub

    Private Sub MoverItemList(ByVal iDirecao As Integer)
        If (lvArtigos.SelectedItems.Count = 0) Then
            Exit Sub
        End If

        Dim lvi As ListViewItem = lvArtigos.SelectedItems(0)
        Dim pos As Integer = lvArtigos.Items.IndexOf(lvi) + iDirecao
        If pos >= 0 And pos < RowTotal Then
            lvArtigos.Items.Remove(lvi)
            lvArtigos.Items.Insert(pos, lvi)
        End If
        AjustarTotalEIndex()
    End Sub

    Private Sub lvArtigos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvArtigos.SelectedIndexChanged
        butApagarArtigo.Enabled = True
        butCima.Enabled = (lvArtigos.Items.Count > 1)
        butBaixo.Enabled = (lvArtigos.Items.Count > 1)
    End Sub

    Private Sub cbCliente_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbCliente.SelectedValueChanged
        'If (Not String.IsNullOrEmpty(cbCliente.SelectedValue) And String.IsNullOrEmpty(txtDocumentoId.Text)) Then
        If (cbCliente.SelectedIndex > -1 And cboCarregada And String.IsNullOrEmpty(txtDocumentoId.Text)) Then
            CarregarCliente(New ClienteService().CarregarPorId(cbCliente.SelectedValue))
        End If
    End Sub

#Region "Buttons"

    Private Sub btnNovo_Click(sender As Object, e As EventArgs) Handles btnNovo.Click
        LimparForm()
        cbTipo.Enabled = True
        txtDescricaoDoc.Enabled = True
        cbCliente.Enabled = True

        btnGravar.Enabled = True
        btnEliminar.Enabled = False
        btnFiltro.Enabled = True
        flNovo = True
    End Sub

    Private Sub btnGravar_Click(sender As Object, e As EventArgs) Handles btnGravar.Click
        Dim sMsg As String = ""

        If flNovo Then
            oDocumento.ObjTipo = New TipoService().CarregarPorId(CInt(cbTipo.SelectedValue))
            oDocumento.ObjCliente = New ClienteService().CarregarPorId(CInt(cbCliente.SelectedValue))
            oDocumento.DataAlteracao = DateTime.Now
            oDocumento.Descricao = txtDescricaoDoc.Text
            CarregarItensListView(oDocumento)

            sMsg = New DocumentoService().Inserir(oDocumento)
        Else
            oDocumento.DataAlteracao = DateTime.Now
            CarregarItensListView(New DocumentoService().CarregarPorId(CInt(txtDocumentoId.Text)))

            sMsg = New DocumentoService().Alterar(oDocumento)
        End If
        MessageBox.Show(sMsg)

        btnRelatorio.Enabled = True
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim sMsg As String = ""
        sMsg = New DocumentoService().Deletar(oDocumento)
        MessageBox.Show(sMsg)
        LimparForm()
    End Sub

    Private Sub btnSair_Click(sender As Object, e As EventArgs) Handles btnSair.Click
        Me.Close()
    End Sub

    Private Sub btnRelatorio_Click(sender As Object, e As EventArgs) Handles btnRelatorio.Click
        Using Relatorio As New Relatorio()
            Relatorio.DocumentoId = txtDocumentoId.Text
            Relatorio.ShowDialog()
        End Using
    End Sub

    Private Sub btnFiltro_Click(sender As Object, e As EventArgs) Handles btnFiltro.Click
        Using DocumentoLista As New DocumentoLista()
            DocumentoLista.ShowDialog()

            If DocumentoLista.DocumentoId > 0 Then
                txtDocumentoId.Text = DocumentoLista.DocumentoId
                CarregarDocumento(txtDocumentoId.Text)
                btnGravar.Enabled = True
                btnRelatorio.Enabled = True
            End If
        End Using
    End Sub

    Private Sub butNovoArtigo_Click(sender As Object, e As EventArgs) Handles butNovoArtigo.Click
        Using ArtigoInc As New ArtigoInc()
            ArtigoInc.ParamDocumento = oDocumento

            Dim oItem As New Item(New Documento(New Tipo(), New Cliente()), New Artigo())
            ArtigoInc.ShowDialog()
            oItem = ArtigoInc.ParamItem

            If oItem.Valor > 0 Then
                oDocumento.Itens.Add(oItem)
                CarregarListArtigo()
            End If
        End Using

    End Sub

    Private Sub butApagarArtigo_Click(sender As Object, e As EventArgs) Handles butApagarArtigo.Click
        If (lvArtigos.SelectedItems.Count = 0) Then
            Exit Sub
        End If

        Dim lvi As ListViewItem = lvArtigos.SelectedItems(0)
        lvArtigos.Items.Remove(lvi)

        CarregarItensListView(oDocumento)
        AjustarTotalEIndex()
    End Sub

    Private Sub butCima_Click(sender As Object, e As EventArgs) Handles butCima.Click
        MoverItemList(-1)
    End Sub

    Private Sub butBaixo_Click(sender As Object, e As EventArgs) Handles butBaixo.Click
        MoverItemList(1)
    End Sub

#End Region
End Class