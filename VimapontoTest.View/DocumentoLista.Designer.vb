<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DocumentoLista
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
        Me.BtnUsar = New System.Windows.Forms.Button()
        Me.lvDocumento = New System.Windows.Forms.ListView()
        Me.btnSair = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnLimpar = New System.Windows.Forms.Button()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.btnFiltrar = New System.Windows.Forms.Button()
        Me.cbCliente = New System.Windows.Forms.ComboBox()
        Me.cbTipo = New System.Windows.Forms.ComboBox()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnUsar
        '
        Me.BtnUsar.Location = New System.Drawing.Point(12, 12)
        Me.BtnUsar.Name = "BtnUsar"
        Me.BtnUsar.Size = New System.Drawing.Size(75, 23)
        Me.BtnUsar.TabIndex = 0
        Me.BtnUsar.Text = "Usar"
        Me.BtnUsar.UseVisualStyleBackColor = True
        '
        'lvDocumento
        '
        Me.lvDocumento.Location = New System.Drawing.Point(13, 84)
        Me.lvDocumento.MultiSelect = False
        Me.lvDocumento.Name = "lvDocumento"
        Me.lvDocumento.Size = New System.Drawing.Size(650, 280)
        Me.lvDocumento.TabIndex = 1
        Me.lvDocumento.UseCompatibleStateImageBehavior = False
        '
        'btnSair
        '
        Me.btnSair.Location = New System.Drawing.Point(102, 12)
        Me.btnSair.Name = "btnSair"
        Me.btnSair.Size = New System.Drawing.Size(75, 23)
        Me.btnSair.TabIndex = 2
        Me.btnSair.Text = "Sair"
        Me.btnSair.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btnLimpar)
        Me.Panel1.Controls.Add(Me.lblCliente)
        Me.Panel1.Controls.Add(Me.lblTipo)
        Me.Panel1.Controls.Add(Me.btnFiltrar)
        Me.Panel1.Controls.Add(Me.cbCliente)
        Me.Panel1.Controls.Add(Me.cbTipo)
        Me.Panel1.Location = New System.Drawing.Point(13, 41)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(650, 40)
        Me.Panel1.TabIndex = 3
        '
        'btnLimpar
        '
        Me.btnLimpar.Location = New System.Drawing.Point(565, 6)
        Me.btnLimpar.Name = "btnLimpar"
        Me.btnLimpar.Size = New System.Drawing.Size(75, 23)
        Me.btnLimpar.TabIndex = 5
        Me.btnLimpar.Text = "Limpar"
        Me.btnLimpar.UseVisualStyleBackColor = True
        '
        'lblCliente
        '
        Me.lblCliente.AutoSize = True
        Me.lblCliente.Location = New System.Drawing.Point(207, 13)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(42, 13)
        Me.lblCliente.TabIndex = 4
        Me.lblCliente.Text = "Cliente:"
        '
        'lblTipo
        '
        Me.lblTipo.AutoSize = True
        Me.lblTipo.Location = New System.Drawing.Point(3, 13)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(31, 13)
        Me.lblTipo.TabIndex = 3
        Me.lblTipo.Text = "Tipo:"
        '
        'btnFiltrar
        '
        Me.btnFiltrar.Location = New System.Drawing.Point(484, 6)
        Me.btnFiltrar.Name = "btnFiltrar"
        Me.btnFiltrar.Size = New System.Drawing.Size(75, 23)
        Me.btnFiltrar.TabIndex = 2
        Me.btnFiltrar.Text = "Filtrar"
        Me.btnFiltrar.UseVisualStyleBackColor = True
        '
        'cbCliente
        '
        Me.cbCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCliente.FormattingEnabled = True
        Me.cbCliente.Location = New System.Drawing.Point(255, 8)
        Me.cbCliente.Name = "cbCliente"
        Me.cbCliente.Size = New System.Drawing.Size(223, 21)
        Me.cbCliente.TabIndex = 1
        '
        'cbTipo
        '
        Me.cbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbTipo.FormattingEnabled = True
        Me.cbTipo.Location = New System.Drawing.Point(40, 8)
        Me.cbTipo.Name = "cbTipo"
        Me.cbTipo.Size = New System.Drawing.Size(161, 21)
        Me.cbTipo.TabIndex = 0
        '
        'DocumentoLista
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(671, 376)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnSair)
        Me.Controls.Add(Me.lvDocumento)
        Me.Controls.Add(Me.BtnUsar)
        Me.Name = "DocumentoLista"
        Me.Text = "DocumentoLista"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtnUsar As System.Windows.Forms.Button
    Friend WithEvents lvDocumento As System.Windows.Forms.ListView
    Friend WithEvents btnSair As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblCliente As System.Windows.Forms.Label
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents btnFiltrar As System.Windows.Forms.Button
    Friend WithEvents cbCliente As System.Windows.Forms.ComboBox
    Friend WithEvents cbTipo As System.Windows.Forms.ComboBox
    Friend WithEvents btnLimpar As System.Windows.Forms.Button
End Class
