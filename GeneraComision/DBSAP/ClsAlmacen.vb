Imports System.Data.Odbc
Imports DBConfig

Public Class ClsAlmacen

    Public Function ObtenerDatos(ByVal Condicion As String) As ClsRespuestaReg
        Dim oNegParametro As NegParametro = New NegParametro()
        Dim oRespuesta As ClsRespuestaReg = New ClsRespuestaReg()

        Try
            Dim connectionString As String = ""
            Dim queryAlmacen As String = ""
            connectionString = oNegParametro.BuscarParametro("DBSAP")
            queryAlmacen = oNegParametro.BuscarParametro("DataSetAlmacen")
            'queryProductos = oNegFiltros.CombinarQueryCondicion(queryProductos, Condicion)
            Dim conn As OdbcConnection = New OdbcConnection(connectionString)
            conn.ConnectionTimeout = 60
            conn.Open()
            Dim sc As OdbcCommand = New OdbcCommand(queryAlmacen, conn)
            Dim da As OdbcDataAdapter = New OdbcDataAdapter(sc)
            Dim ds As DataSet = New DataSet("Almacen")
            da.Fill(ds)
            oRespuesta.errCodigo = 0
            oRespuesta.errMensaje = ""
            oRespuesta.detalle = ds
            conn.Close()
            Return oRespuesta
        Catch ex As Exception
            oRespuesta.errCodigo = -1000
            oRespuesta.errMensaje = ex.Message
            Return oRespuesta
        End Try
    End Function

End Class
