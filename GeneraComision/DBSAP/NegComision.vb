Imports System.Data.Odbc
Imports DBConfig

Public Class NegComision
    Public Function NuevaComision(Anio As Integer, mes As Integer, almacen As String, vendedor As String) As ClsRespuestaReg
        Dim oClsRespuestaReg As New ClsRespuestaReg
        Dim dsComision As New DataSet()

        Try

            Dim oNEgParametro As New NegParametro()

            Dim connectionString As String = ""
            Dim queryComision As String = ""

            connectionString = oNEgParametro.BuscarParametro("DBSAP")
            queryComision = oNEgParametro.BuscarParametro("DataSetComision")

            Using connection As New OdbcConnection(connectionString)
                Dim adapter As OdbcDataAdapter = New OdbcDataAdapter(queryComision, connection)
                adapter.SelectCommand.Parameters.Add(
                "@anio", OdbcType.Int).Value = Anio

                adapter.SelectCommand.Parameters.Add(
                "@mes", OdbcType.Int).Value = mes

                adapter.SelectCommand.Parameters.Add(
                "@almacen", OdbcType.VarChar, 4).Value = almacen

                Try
                    connection.Open()
                    adapter.Fill(dsComision)
                    oClsRespuestaReg.errCodigo = 0
                    oClsRespuestaReg.errMensaje = ""
                    oClsRespuestaReg.detalle = dsComision
                Catch ex As Exception

                    oClsRespuestaReg.errCodigo = -5000
                    oClsRespuestaReg.errMensaje = ex.Message
                    oClsRespuestaReg.detalle = dsComision
                End Try

            End Using

        Catch ex As Exception
            oClsRespuestaReg.errCodigo = -5000
            oClsRespuestaReg.errMensaje = ex.Message
            oClsRespuestaReg.detalle = dsComision
        End Try
        Return oClsRespuestaReg
    End Function



End Class
