Public Class NegSQLGeneral
    Public Function CombinarQueryCondicion(QueryOriginal As String, Condicion As String) As String
        Dim queryProductos As String
        queryProductos = QueryOriginal

        If Condicion <> "" Then
            queryProductos = queryProductos.TrimEnd(";"c)
            Dim Queryproductosini As String = ""
            Dim Queryproductosorderby As String = ""

            If queryProductos.IndexOf("Order by", StringComparison.OrdinalIgnoreCase) > 0 Then
                Dim posicionOrderby As Integer = queryProductos.IndexOf("Order by", StringComparison.OrdinalIgnoreCase)
                Queryproductosini = queryProductos.Substring(1, posicionOrderby)
                Queryproductosorderby = queryProductos.Substring(posicionOrderby + "Order by ".Length)
            Else
                Queryproductosini = queryProductos
            End If

            If Queryproductosini.IndexOf("Where", StringComparison.OrdinalIgnoreCase) > 0 Then
                Queryproductosini = Queryproductosini & " And " & Condicion
            Else
                Queryproductosini = Queryproductosini & " Where " & Condicion
            End If

            queryProductos = Queryproductosini & " " & Queryproductosorderby
        End If
        CombinarQueryCondicion = queryProductos


    End Function

End Class
