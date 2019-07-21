<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ArtigoInc
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnFechar = New System.Windows.Forms.Button()
        Me.txtQuantidade = New System.Windows.Forms.TextBox()
        Me.cbArtigoId = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblValor = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblDescricao = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblArtigo = New System.Windows.Forms.Label()
        Me.btnGravar = New System.Windows.Forms.Button()
        Me.txtDataEntrega = New System.Windows.Forms.MaskedTextBox()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.txtDataEntrega)
        Me.Panel1.Controls.Add(Me.txtQuantidade)
        Me.Panel1.Controls.Add(Me.cbArtigoId)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.lblValor)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.lblDescricao)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.lblArtigo)
        Me.Panel1.Location = New System.Drawing.Point(12, 41)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(499, 163)
        Me.Panel1.TabIndex = 0
        '
        'btnFechar
        '
        Me.btnFechar.Location = New System.Drawing.Point(103, 12)
        Me.btnFechar.Name = "btnFechar"
        Me.btnFechar.Size = New System.Drawing.Size(75, 23)
        Me.btnFechar.TabIndex = 11
        Me.btnFechar.Text = "Fechar"
        Me.btnFechar.UseVisualStyleBackColor = True
        '
        'txtQuantidade
        '
        Me.txtQuantidade.Location = New System.Drawing.Point(111, 94)
        Me.txtQuantidade.Name = "txtQuantidade"
        Me.txtQuantidade.Size = New System.Drawing.Size(121, 20)
        Me.txtQuantidade.TabIndex = 8
        '
        'cbArtigoId
        '
        Me.cbArtigoId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbArtigoId.FormattingEnabled = True
        Me.cbArtigoId.Location = New System.Drawing.Point(111, 9)
        Me.cbArtigoId.Name = "cbArtigoId"
        Me.cbArtigoId.Size = New System.Drawing.Size(121, 21)
        Me.cbArtigoId.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(18, 131)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(87, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Data de entrega:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(18, 101)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Quantidade"
        '
        'lblValor
        '
        Me.lblValor.AutoSize = True
        Me.lblValor.Location = New System.Drawing.Point(108, 69)
        Me.lblValor.Name = "lblValor"
        Me.lblValor.Size = New System.Drawing.Size(28, 13)
        Me.lblValor.TabIndex = 4
        Me.lblValor.Text = "0,00"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(18, 69)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(31, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Valor"
        '
        'lblDescricao
        '
        Me.lblDescricao.AutoSize = True
        Me.lblDescricao.Location = New System.Drawing.Point(108, 43)
        Me.lblDescricao.Name = "lblDescricao"
        Me.lblDescricao.Size = New System.Drawing.Size(10, 13)
        Me.lblDescricao.TabIndex = 2
        Me.lblDescricao.Text = "-"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Descrição:"
        '
        'lblArtigo
        '
        Me.lblArtigo.AutoSize = True
        Me.lblArtigo.Location = New System.Drawing.Point(18, 17)
        Me.lblArtigo.Name = "lblArtigo"
        Me.lblArtigo.Size = New System.Drawing.Size(37, 13)
        Me.lblArtigo.TabIndex = 0
        Me.lblArtigo.Text = "Artigo:"
        '
        'btnGravar
        '
        Me.btnGravar.Location = New System.Drawing.Point(12, 12)
        Me.btnGravar.Name = "btnGravar"
        Me.btnGravar.Size = New System.Drawing.Size(75, 23)
        Me.btnGravar.TabIndex = 10
        Me.btnGravar.Text = "Gravar"
        Me.btnGravar.UseVisualStyleBackColor = True
        '
        'txtDataEntrega
        '
        Me.txtDataEntrega.Location = New System.Drawing.Point(111, 124)
        Me.txtDataEntrega.Mask = "00/00/0000"
        Me.txtDataEntrega.Name = "txtDataEntrega"
        Me.txtDataEntrega.Size = New System.Drawing.Size(121, 20)
        Me.txtDataEntrega.TabIndex = 10
        Me.txtDataEntrega.ValidatingType = GetType(Date)
        '
        'ArtigoInc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(523, 217)
        Me.Controls.Add(Me.btnFechar)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnGravar)
        Me.Name = "ArtigoInc"
        Me.Text = "ArtigoInc"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnFechar As System.Windows.Forms.Button
    Friend WithEvents txtQuantidade As System.Windows.Forms.TextBox
    Friend WithEvents cbArtigoId As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblValor As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblDescricao As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblArtigo As System.Windows.Forms.Label
    Friend WithEvents btnGravar As System.Windows.Forms.Button
    Friend WithEvents txtDataEntrega As System.Windows.Forms.MaskedTextBox
End Class
