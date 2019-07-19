Imports VimapontoTest.Model

Public Class ArtigoInc

    Private _Item As Item()
    Public Property Item As Item
        Get
            Return _Item
        End Get
        Set(ByVal value As Item)
            _Item = value
        End Set
    End Property


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
End Class