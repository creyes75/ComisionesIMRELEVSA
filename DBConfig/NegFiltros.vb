Imports System.Configuration
Imports System.Data.Odbc
Imports System.Data.SqlClient
Imports System.IO

Public Class NegFiltros
    Inherits NegClaseBase.NegClaseBase

    Public Property Accion As String


    Dim dtsReg As New DataSet
    Private Const StoreP As String = "SpMantFiltros"
    Private con As SqlClient.SqlConnection
    Public Function BuscarFiltros(OrigenDatos As String) As DataTable

        Dim dtsDatos As New DataTable

        Dim con As SqlConnection = New SqlConnection()

        Dim reader = New AppSettingsReader()
        Dim stringSetting = reader.GetValue("Base", GetType(String))
        MyBase.BaseDatos = stringSetting.ToString()
        con = MyBase.Conectar()


        MyBase.LimpiarParametrosStore()
        MyBase.BaseDatos = BaseDatos
        MyBase.AgregarParametroStore("@Accion", "CON", DbType.String) 'busq registros
        MyBase.AgregarParametroStore("@OrigenDatos", OrigenDatos, DbType.String) 'busq registros

        Try

            dtsDatos = MyBase.EjecutarBusqueda(StoreP, con, True)
            'Dim rowcab As DataRow
            'If dtsDatos.Rows.Count > 0 Then

            '    rowcab = dtsDatos.Rows(0)
            '    If IsDBNull(rowcab("ParametroValor")) Then
            '        Me.Valor = ""
            '    Else
            '        Me.Valor = rowcab("ParametroValor")
            '    End If

            'End If
            MyBase.Desconectar()
            Return dtsDatos '-- 
        Catch ex As Exception
            Return Nothing
        End Try

    End Function
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

        'If (Condicion!= "") Then
        '                            {
        '                    queryProductos = queryProductos.TrimEnd(';'); //elimino un posible ; al final de la cadena
        '                    String Queryproductosini="";
        '                    String Queryproductosorderby = "";
        '                    If (queryProductos.IndexOf("Order by", StringComparison.OrdinalIgnoreCase) > 0) Then
        '                                    {
        '                        Int posicionOrderby = queryProductos.IndexOf("Order by", StringComparison.OrdinalIgnoreCase);
        '                         Queryproductosini = queryProductos.Substring(1, posicionOrderby);
        '                         Queryproductosorderby = queryProductos.Substring(posicionOrderby + "Order by ".Length);
        '                    }
        '                    Else
        '                    {
        '                        Queryproductosini = queryProductos;
        '                    }

        '                    If (Queryproductosini.IndexOf("Where", StringComparison.OrdinalIgnoreCase) > 0) Then
        '                                        {
        '                        Queryproductosini = Queryproductosini + " And " + Condicion;
        '                    }
        '                    Else
        '                    {
        '                        Queryproductosini = Queryproductosini + " Where " + Condicion;
        '                    }
        '                    queryProductos = Queryproductosini + " " + Queryproductosorderby;
        '                }
    End Function

    Public Function EjecutaQuery(Query As String) As DataSet
        Dim oNegParametro As New NegParametro
        Dim ds As DataSet
        ds = New DataSet("Filtros")

        Try
            Dim connectionString As String = oNegParametro.BuscarParametro("DBSAP")
            Dim conn As OdbcConnection = New OdbcConnection(connectionString)

            conn.ConnectionTimeout = 60
            conn.Open()

            Dim sc As OdbcCommand = New OdbcCommand(Query, conn)
            Dim da As OdbcDataAdapter = New OdbcDataAdapter(sc)

            da.Fill(ds)
            '    oRespuesta.errCodigo = 0;
            'oRespuesta.errMensaje = "";
            'oRespuesta.detalle = ds;

            conn.Close()
            Return ds 'oRespuesta

        Catch ex As Exception
            'oRespuesta.errCodigo = -1000;
            'oRespuesta.errMensaje = ex.Message;
            'Return oRespuesta;
            Return ds
        End Try

    End Function
End Class
