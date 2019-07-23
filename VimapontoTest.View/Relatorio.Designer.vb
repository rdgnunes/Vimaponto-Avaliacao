<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Relatorio
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
        Me.components = New System.ComponentModel.Container()
        Me.DSVimapontoBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.RVDocumento = New Microsoft.Reporting.WinForms.ReportViewer()
        CType(Me.DSVimapontoBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DSVimapontoBindingSource
        '
        Me.DSVimapontoBindingSource.DataMember = "Item"
        Me.DSVimapontoBindingSource.DataSource = GetType(VimapontoTest.Controller.Data.DSVimaponto)
        '
        'RVDocumento
        '
        Me.RVDocumento.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RVDocumento.Location = New System.Drawing.Point(0, 0)
        Me.RVDocumento.Name = "RVDocumento"
        Me.RVDocumento.Size = New System.Drawing.Size(986, 384)
        Me.RVDocumento.TabIndex = 0
        '
        'Relatorio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(986, 384)
        Me.Controls.Add(Me.RVDocumento)
        Me.Name = "Relatorio"
        Me.Text = "Relatorio"
        CType(Me.DSVimapontoBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DSVimapontoBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents RVDocumento As Microsoft.Reporting.WinForms.ReportViewer
End Class
