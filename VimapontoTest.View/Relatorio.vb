Imports VimapontoTest.Model
Imports VimapontoTest.Controller.Services
Imports Microsoft.Reporting.WinForms

Public Class Relatorio
    Private _DocumentoId As Integer

    Public Property DocumentoId As Integer
        Get
            Return _DocumentoId
        End Get
        Set(ByVal value As Integer)
            _DocumentoId = value
        End Set
    End Property

    Private Sub Relatorio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim oRelatorio = New DocumentoService().GetRelatorioDocumento(DocumentoId)

            RVDocumento.LocalReport.DataSources.Clear()
            RVDocumento.LocalReport.ReportEmbeddedResource = "VimapontoTest.View.Relatorio.rdlc"

            Dim dsRelatorio As New ReportDataSource("DSRelatorio", oRelatorio)
            RVDocumento.LocalReport.DataSources.Add(dsRelatorio)
            dsRelatorio.Value = oRelatorio

            RVDocumento.LocalReport.Refresh()
            Me.RVDocumento.RefreshReport()


        Catch ex As Exception
            Throw ex
        End Try
        Me.RVDocumento.RefreshReport()
    End Sub
End Class