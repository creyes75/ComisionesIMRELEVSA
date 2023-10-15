Public Class ClsComision

    Public Property Pk As Integer
    Public Property NombreComision As String
    Public Property DescripcionComision As String
    Public Property Anio As String
    Public Property Mes As String
    Public Property Almacen As String
    Public Property Vendedor As String

    Public Property detalles As DataSet
    Public Property consolidado As DataSet
    Public Property Modificado As Boolean '//definido para identificar si este catalogo fue modificado y esta pendiente de ser almacenado.


End Class
