Imports System.Data.Odbc
Imports DBConfig



Public Class ClsVendedor
    Public Property Id As String
    Public Property Nombre As String
    Public Property RUC As String
    Public Property TipoContrib As String
    Public Property PorcIVA As Decimal
    Public Property PorRetIVA As Decimal
    Public Property PorRetRenta As Decimal

    Public Function ObtenerDatos(ByVal Condicion As String) As ClsRespuestaReg
        Dim oNegParametro As NegParametro = New NegParametro()
        Dim oRespuesta As ClsRespuestaReg = New ClsRespuestaReg()
        Dim oNegSQLGeneral As NegSQLGeneral = New NegSQLGeneral()
        Try
            Dim connectionString As String = ""
            Dim queryVendedor As String = ""
            connectionString = oNegParametro.BuscarParametro("DBSAP")
            queryVendedor = oNegParametro.BuscarParametro("DataSetVendedor")
            queryVendedor = oNegSQLGeneral.CombinarQueryCondicion(queryVendedor, Condicion)
            Dim conn As OdbcConnection = New OdbcConnection(connectionString)
            conn.ConnectionTimeout = 60
            conn.Open()
            Dim sc As OdbcCommand = New OdbcCommand(queryVendedor, conn)
            Dim da As OdbcDataAdapter = New OdbcDataAdapter(sc)
            Dim ds As DataSet = New DataSet("Vendedor")
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
