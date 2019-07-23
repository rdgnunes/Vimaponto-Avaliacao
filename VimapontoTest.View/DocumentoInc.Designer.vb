<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DocumentoInc
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnGravar = New System.Windows.Forms.Button()
        Me.btnNovo = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnSair = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnFiltro = New System.Windows.Forms.Button()
        Me.txtHoraAlteracao = New System.Windows.Forms.TextBox()
        Me.txtDataAlteracao = New System.Windows.Forms.TextBox()
        Me.lblAlterado = New System.Windows.Forms.Label()
        Me.txtDocumentoId = New System.Windows.Forms.TextBox()
        Me.txtDescricaoDoc = New System.Windows.Forms.TextBox()
        Me.cbTipo = New System.Windows.Forms.ComboBox()
        Me.lblDocumento = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.cbCliente = New System.Windows.Forms.ComboBox()
        Me.txtContato = New System.Windows.Forms.TextBox()
        Me.txtMorada = New System.Windows.Forms.TextBox()
        Me.txtNome = New System.Windows.Forms.TextBox()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.butNovoArtigo = New System.Windows.Forms.Button()
        Me.butApagarArtigo = New System.Windows.Forms.Button()
        Me.butCima = New System.Windows.Forms.Button()
        Me.butBaixo = New System.Windows.Forms.Button()
        Me.lvArtigos = New System.Windows.Forms.ListView()
        Me.btnRelatorio = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnGravar
        '
        Me.btnGravar.Location = New System.Drawing.Point(12, 21)
        Me.btnGravar.Name = "btnGravar"
        Me.btnGravar.Size = New System.Drawing.Size(75, 23)
        Me.btnGravar.TabIndex = 0
        Me.btnGravar.Text = "Gravar"
        Me.btnGravar.UseVisualStyleBackColor = True
        '
        'btnNovo
        '
        Me.btnNovo.Location = New System.Drawing.Point(93, 21)
        Me.btnNovo.Name = "btnNovo"
        Me.btnNovo.Size = New System.Drawing.Size(75, 23)
        Me.btnNovo.TabIndex = 1
        Me.btnNovo.Text = "Novo"
        Me.btnNovo.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Enabled = False
        Me.btnEliminar.Location = New System.Drawing.Point(174, 21)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(75, 23)
        Me.btnEliminar.TabIndex = 2
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnSair
        '
        Me.btnSair.Location = New System.Drawing.Point(255, 21)
        Me.btnSair.Name = "btnSair"
        Me.btnSair.Size = New System.Drawing.Size(75, 23)
        Me.btnSair.TabIndex = 3
        Me.btnSair.Text = "Sair"
        Me.btnSair.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btnFiltro)
        Me.Panel1.Controls.Add(Me.txtHoraAlteracao)
        Me.Panel1.Controls.Add(Me.txtDataAlteracao)
        Me.Panel1.Controls.Add(Me.lblAlterado)
        Me.Panel1.Controls.Add(Me.txtDocumentoId)
        Me.Panel1.Controls.Add(Me.txtDescricaoDoc)
        Me.Panel1.Controls.Add(Me.cbTipo)
        Me.Panel1.Controls.Add(Me.lblDocumento)
        Me.Panel1.Location = New System.Drawing.Point(13, 50)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(931, 58)
        Me.Panel1.TabIndex = 4
        '
        'btnFiltro
        '
        Me.btnFiltro.Location = New System.Drawing.Point(628, 16)
        Me.btnFiltro.Name = "btnFiltro"
        Me.btnFiltro.Size = New System.Drawing.Size(20, 20)
        Me.btnFiltro.TabIndex = 7
        Me.btnFiltro.UseVisualStyleBackColor = True
        '
        'txtHoraAlteracao
        '
        Me.txtHoraAlteracao.Enabled = False
        Me.txtHoraAlteracao.Location = New System.Drawing.Point(850, 19)
        Me.txtHoraAlteracao.Name = "txtHoraAlteracao"
        Me.txtHoraAlteracao.Size = New System.Drawing.Size(66, 20)
        Me.txtHoraAlteracao.TabIndex = 6
        '
        'txtDataAlteracao
        '
        Me.txtDataAlteracao.Enabled = False
        Me.txtDataAlteracao.Location = New System.Drawing.Point(744, 19)
        Me.txtDataAlteracao.Name = "txtDataAlteracao"
        Me.txtDataAlteracao.Size = New System.Drawing.Size(100, 20)
        Me.txtDataAlteracao.TabIndex = 5
        '
        'lblAlterado
        '
        Me.lblAlterado.AutoSize = True
        Me.lblAlterado.Location = New System.Drawing.Point(672, 20)
        Me.lblAlterado.Name = "lblAlterado"
        Me.lblAlterado.Size = New System.Drawing.Size(66, 13)
        Me.lblAlterado.TabIndex = 4
        Me.lblAlterado.Text = "Alterado em:"
        '
        'txtDocumentoId
        '
        Me.txtDocumentoId.Enabled = False
        Me.txtDocumentoId.Location = New System.Drawing.Point(557, 16)
        Me.txtDocumentoId.Name = "txtDocumentoId"
        Me.txtDocumentoId.Size = New System.Drawing.Size(65, 20)
        Me.txtDocumentoId.TabIndex = 3
        '
        'txtDescricaoDoc
        '
        Me.txtDescricaoDoc.Enabled = False
        Me.txtDescricaoDoc.Location = New System.Drawing.Point(207, 16)
        Me.txtDescricaoDoc.Name = "txtDescricaoDoc"
        Me.txtDescricaoDoc.Size = New System.Drawing.Size(344, 20)
        Me.txtDescricaoDoc.TabIndex = 2
        '
        'cbTipo
        '
        Me.cbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTipo.Enabled = False
        Me.cbTipo.FormattingEnabled = True
        Me.cbTipo.ItemHeight = 13
        Me.cbTipo.Location = New System.Drawing.Point(80, 16)
        Me.cbTipo.Name = "cbTipo"
        Me.cbTipo.Size = New System.Drawing.Size(121, 21)
        Me.cbTipo.TabIndex = 1
        '
        'lblDocumento
        '
        Me.lblDocumento.AutoSize = True
        Me.lblDocumento.Location = New System.Drawing.Point(12, 19)
        Me.lblDocumento.Name = "lblDocumento"
        Me.lblDocumento.Size = New System.Drawing.Size(62, 13)
        Me.lblDocumento.TabIndex = 0
        Me.lblDocumento.Text = "Documento"
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.cbCliente)
        Me.Panel2.Controls.Add(Me.txtContato)
        Me.Panel2.Controls.Add(Me.txtMorada)
        Me.Panel2.Controls.Add(Me.txtNome)
        Me.Panel2.Controls.Add(Me.lblCliente)
        Me.Panel2.Location = New System.Drawing.Point(12, 114)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(931, 100)
        Me.Panel2.TabIndex = 5
        '
        'cbCliente
        '
        Me.cbCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCliente.Enabled = False
        Me.cbCliente.FormattingEnabled = True
        Me.cbCliente.ItemHeight = 13
        Me.cbCliente.Location = New System.Drawing.Point(80, 13)
        Me.cbCliente.Name = "cbCliente"
        Me.cbCliente.Size = New System.Drawing.Size(121, 21)
        Me.cbCliente.TabIndex = 10
        '
        'txtContato
        '
        Me.txtContato.Enabled = False
        Me.txtContato.Location = New System.Drawing.Point(81, 66)
        Me.txtContato.Name = "txtContato"
        Me.txtContato.Size = New System.Drawing.Size(836, 20)
        Me.txtContato.TabIndex = 9
        '
        'txtMorada
        '
        Me.txtMorada.Enabled = False
        Me.txtMorada.Location = New System.Drawing.Point(81, 40)
        Me.txtMorada.Name = "txtMorada"
        Me.txtMorada.Size = New System.Drawing.Size(836, 20)
        Me.txtMorada.TabIndex = 8
        '
        'txtNome
        '
        Me.txtNome.Enabled = False
        Me.txtNome.Location = New System.Drawing.Point(208, 14)
        Me.txtNome.Name = "txtNome"
        Me.txtNome.Size = New System.Drawing.Size(709, 20)
        Me.txtNome.TabIndex = 7
        '
        'lblCliente
        '
        Me.lblCliente.AutoSize = True
        Me.lblCliente.Location = New System.Drawing.Point(13, 17)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(39, 13)
        Me.lblCliente.TabIndex = 1
        Me.lblCliente.Text = "Cliente"
        '
        'butNovoArtigo
        '
        Me.butNovoArtigo.Enabled = False
        Me.butNovoArtigo.Location = New System.Drawing.Point(12, 220)
        Me.butNovoArtigo.Name = "butNovoArtigo"
        Me.butNovoArtigo.Size = New System.Drawing.Size(75, 23)
        Me.butNovoArtigo.TabIndex = 6
        Me.butNovoArtigo.Text = "Novo"
        Me.butNovoArtigo.UseVisualStyleBackColor = True
        '
        'butApagarArtigo
        '
        Me.butApagarArtigo.Enabled = False
        Me.butApagarArtigo.Location = New System.Drawing.Point(94, 220)
        Me.butApagarArtigo.Name = "butApagarArtigo"
        Me.butApagarArtigo.Size = New System.Drawing.Size(75, 23)
        Me.butApagarArtigo.TabIndex = 7
        Me.butApagarArtigo.Text = "Apagar"
        Me.butApagarArtigo.UseVisualStyleBackColor = True
        '
        'butCima
        '
        Me.butCima.Enabled = False
        Me.butCima.Location = New System.Drawing.Point(175, 220)
        Me.butCima.Name = "butCima"
        Me.butCima.Size = New System.Drawing.Size(75, 23)
        Me.butCima.TabIndex = 8
        Me.butCima.Text = "Cima"
        Me.butCima.UseVisualStyleBackColor = True
        '
        'butBaixo
        '
        Me.butBaixo.Enabled = False
        Me.butBaixo.Location = New System.Drawing.Point(256, 220)
        Me.butBaixo.Name = "butBaixo"
        Me.butBaixo.Size = New System.Drawing.Size(75, 23)
        Me.butBaixo.TabIndex = 9
        Me.butBaixo.Text = "Baixo"
        Me.butBaixo.UseVisualStyleBackColor = True
        '
        'lvArtigos
        '
        Me.lvArtigos.Location = New System.Drawing.Point(12, 249)
        Me.lvArtigos.MultiSelect = False
        Me.lvArtigos.Name = "lvArtigos"
        Me.lvArtigos.Size = New System.Drawing.Size(930, 255)
        Me.lvArtigos.TabIndex = 10
        Me.lvArtigos.UseCompatibleStateImageBehavior = False
        '
        'btnRelatorio
        '
        Me.btnRelatorio.Enabled = False
        Me.btnRelatorio.Location = New System.Drawing.Point(794, 21)
        Me.btnRelatorio.Name = "btnRelatorio"
        Me.btnRelatorio.Size = New System.Drawing.Size(150, 23)
        Me.btnRelatorio.TabIndex = 11
        Me.btnRelatorio.Text = "Exibir Relatório"
        Me.btnRelatorio.UseVisualStyleBackColor = True
        '
        'DocumentoInc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(956, 517)
        Me.Controls.Add(Me.btnRelatorio)
        Me.Controls.Add(Me.lvArtigos)
        Me.Controls.Add(Me.butBaixo)
        Me.Controls.Add(Me.butCima)
        Me.Controls.Add(Me.butApagarArtigo)
        Me.Controls.Add(Me.butNovoArtigo)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnSair)
        Me.Controls.Add(Me.btnEliminar)
        Me.Controls.Add(Me.btnNovo)
        Me.Controls.Add(Me.btnGravar)
        Me.Name = "DocumentoInc"
        Me.Text = "DocumentoInc"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnGravar As System.Windows.Forms.Button
    Friend WithEvents btnNovo As System.Windows.Forms.Button
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents btnSair As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblDocumento As System.Windows.Forms.Label
    Friend WithEvents txtDocumentoId As System.Windows.Forms.TextBox
    Friend WithEvents txtDescricaoDoc As System.Windows.Forms.TextBox
    Friend WithEvents cbTipo As System.Windows.Forms.ComboBox
    Friend WithEvents txtHoraAlteracao As System.Windows.Forms.TextBox
    Friend WithEvents txtDataAlteracao As System.Windows.Forms.TextBox
    Friend WithEvents lblAlterado As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents txtContato As System.Windows.Forms.TextBox
    Friend WithEvents txtMorada As System.Windows.Forms.TextBox
    Friend WithEvents txtNome As System.Windows.Forms.TextBox
    Friend WithEvents lblCliente As System.Windows.Forms.Label
    Friend WithEvents butNovoArtigo As System.Windows.Forms.Button
    Friend WithEvents butApagarArtigo As System.Windows.Forms.Button
    Friend WithEvents butCima As System.Windows.Forms.Button
    Friend WithEvents butBaixo As System.Windows.Forms.Button
    Friend WithEvents lvArtigos As System.Windows.Forms.ListView
    Friend WithEvents cbCliente As System.Windows.Forms.ComboBox
    Friend WithEvents btnFiltro As System.Windows.Forms.Button
    Friend WithEvents btnRelatorio As System.Windows.Forms.Button
End Class
