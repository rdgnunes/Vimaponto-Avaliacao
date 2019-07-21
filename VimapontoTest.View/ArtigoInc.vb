Imports VimapontoTest.Model
Imports VimapontoTest.Controller.Services

Public Class ArtigoInc

    Private _ParamItem As New Item(New Documento(New Tipo(), New Cliente()), New Artigo())
    Private _ParamDocumento As New Documento(New Tipo(), New Cliente())
    Private cboCarregada As Boolean = False
    Private oArtigo As New Artigo()

    Public Property ParamItem As Item
        Get
            Return _ParamItem
        End Get
        Set(ByVal value As Item)
            _ParamItem = value
        End Set
    End Property

    Public Property ParamDocumento As Documento
        Get
            Return _ParamDocumento
        End Get
        Set(ByVal value As Documento)
            _ParamDocumento = value
        End Set
    End Property

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        CarregarComboArtigo()
    End Sub

    Private Sub CarregarComboArtigo()
        Dim artigos As New List(Of Artigo)
        artigos = New ArtigoService().ListarTodos()

        'For i As Integer = 0 To ParamDocumento.Itens.Count - 1
        '    Dim oArtigo As New Artigo()
        '    oArtigo = ParamDocumento.Itens(i).ObjArtigo
        '    artigos.Remove(oArtigo)
        'Next

        cbArtigoId.DataSource = artigos
        cbArtigoId.DisplayMember = "Codigo"
        cbArtigoId.ValueMember = "ArtigoId"
        cbArtigoId.SelectedIndex = -1

        cboCarregada = True
    End Sub

    Private Sub CarregarArtigo()
        oArtigo = New ArtigoService().CarregarPorId(cbArtigoId.SelectedValue)

        lblDescricao.Text = oArtigo.Descricao
        lblValor.Text = oArtigo.Valor.ToString("F")
        txtQuantidade.Text = ""
        txtDataEntrega.Text = ""
    End Sub

    Private Sub btnGravar_Click(sender As Object, e As EventArgs) Handles btnGravar.Click
        Dim sMsg As String = ""

        If String.IsNullOrEmpty(cbArtigoId.SelectedValue) Then
            sMsg = "Escolha um artigo!"
        End If

        If String.IsNullOrEmpty(txtQuantidade.Text) Then
            sMsg = "Informe a quantidade!"
        End If

        If Not IsDate(txtDataEntrega.Text) Then
            sMsg = "Informe a data de entrega."
        End If

        If Not String.IsNullOrEmpty(sMsg) Then
            MessageBox.Show(sMsg)
            Exit Sub
        End If

        Dim oItem As New Item(ParamDocumento, oArtigo)
        oItem.Quantidade = txtQuantidade.Text
        oItem.DataEntrega = DateTime.Parse(txtDataEntrega.Text)
        oItem.Valor = oArtigo.Valor.ToString("F")

        ParamItem = oItem

        Me.Close()
    End Sub

    Private Sub btnFechar_Click(sender As Object, e As EventArgs) Handles btnFechar.Click
        Me.Close()
    End Sub

    Private Sub cbCodigo_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbArtigoId.SelectedValueChanged
        If (cbArtigoId.SelectedIndex > -1 And cboCarregada) Then
            CarregarArtigo()
        End If
    End Sub

    Private Sub txtDataEntrega_TypeValidationCompleted(sender As Object, e As TypeValidationEventArgs) Handles txtDataEntrega.TypeValidationCompleted
        If Not e.IsValidInput Then
            MessageBox.Show("Data inválida")
            txtDataEntrega.Text = ""
        End If
    End Sub
End Class