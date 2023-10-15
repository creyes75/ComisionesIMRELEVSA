Imports System.Configuration
Imports System.Data.SqlClient
Imports System.IO


Public Class NegOrden
    Inherits NegClaseBase.NegClaseBase

    Public Property Accion As String
    Public Property ProductoId As String
    Public Property Orden As Decimal
    Public Property Status As String
    Public Property OrdenNivel6 As String
    Public Property IdNivel1 As String
    Public Property IdNivel2 As String
    Public Property IdNivel3 As String
    Public Property IdNivel4 As String
    Public Property IdNivel5 As String
    Public Property TipoModif As String

    Dim dtsReg As New DataSet
    Private Const StoreP As String = "SpMantOrden"
    Private con As SqlClient.SqlConnection

    Public Function ObtenerOrdenProductos() As DataSet

        Dim dtsDatos As New DataTable
        Dim dsDatos As New DataSet

        Dim con As SqlConnection = New SqlConnection()

        Dim reader = New AppSettingsReader()
        Dim stringSetting = reader.GetValue("Base", GetType(String))
        MyBase.BaseDatos = stringSetting.ToString()
        con = MyBase.Conectar()

        MyBase.LimpiarParametrosStore()
        MyBase.BaseDatos = BaseDatos
        MyBase.AgregarParametroStore("@Accion", "CON", DbType.String) 'busq registros
        'If Me.Pk <> 0 Then MyBase.AgregarParametroStore("@Pk", Me.Pk, DbType.String)
        'If Me.Empresa <> "" Then MyBase.AgregarParametroStore("@Empresa", Me.Empresa, DbType.String)

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
            dsDatos.Tables.Add(dtsDatos)
            Return dsDatos 'Me.Valor '-- 
        Catch ex As Exception
            Return dsDatos '"Err"
        End Try

    End Function

    Public Function Leer(ByVal idProducto As String) As Boolean
        Try
            Dim dtsDatos As New DataTable

            Dim con As SqlConnection = New SqlConnection()

            Dim reader = New AppSettingsReader()
            Dim stringSetting = reader.GetValue("Base", GetType(String))
            MyBase.BaseDatos = stringSetting.ToString()
            con = MyBase.Conectar()

            Me.ProductoId = idProducto

            MyBase.LimpiarParametrosStore()
            MyBase.BaseDatos = BaseDatos
            MyBase.AgregarParametroStore("@Accion", "BUS", DbType.String) 'busq registros

            If idProducto <> "" Then MyBase.AgregarParametroStore("@ProductoId", Me.ProductoId, DbType.String)

            dtsDatos = MyBase.EjecutarBusqueda(StoreP, con, True)
            Dim rowcab As DataRow
            If dtsDatos.Rows.Count > 0 Then

                rowcab = dtsDatos.Rows(0)
                If IsDBNull(rowcab("Orden")) Then
                    Me.Orden = 0
                Else
                    Me.Orden = rowcab("Orden")
                End If

                If IsDBNull(rowcab("Status")) Then
                    Me.Status = ""
                Else
                    Me.Status = rowcab("Status")
                End If

                If IsDBNull(rowcab("OrdenNivel6")) Then
                    Me.OrdenNivel6 = ""
                Else
                    Me.OrdenNivel6 = rowcab("OrdenNivel6")
                End If
                If IsDBNull(rowcab("IdNivel1")) Then
                    Me.IdNivel1 = ""
                Else
                    Me.IdNivel1 = rowcab("IdNivel1")
                End If
                If IsDBNull(rowcab("IdNivel2")) Then
                    Me.IdNivel2 = ""
                Else
                    Me.IdNivel2 = rowcab("IdNivel2")
                End If
                If IsDBNull(rowcab("IdNivel3")) Then
                    Me.IdNivel3 = ""
                Else
                    Me.IdNivel3 = rowcab("IdNivel3")
                End If
                If IsDBNull(rowcab("IdNivel4")) Then
                    Me.IdNivel4 = ""
                Else
                    Me.IdNivel4 = rowcab("IdNivel4")
                End If
                If IsDBNull(rowcab("IdNivel5")) Then
                    Me.IdNivel5 = ""
                Else
                    Me.IdNivel5 = rowcab("IdNivel5")
                End If

            End If
            MyBase.Desconectar()
            Return True '-- 
        Catch ex As Exception
            Return False

        End Try

    End Function

    Public Sub Grabar()
        Dim con As SqlClient.SqlConnection
        Dim tran As SqlClient.SqlTransaction
        Try


            con = New SqlConnection()
            'tran = New SqlTransaction()
            'tran = con.BeginTransaction

            Dim reader = New AppSettingsReader()
            Dim stringSetting = reader.GetValue("Base", GetType(String))
            MyBase.BaseDatos = stringSetting.ToString()
            con = MyBase.Conectar()

            MyBase.LimpiarParametrosStore()
            If Accion = "I" Then
                MyBase.AgregarParametroStore("@Accion", "INS", DbType.String)
            Else
                MyBase.AgregarParametroStore("@Accion", "UPD", DbType.String)
            End If
            MyBase.AgregarParametroStore("@ProductoId", ProductoId, DbType.String) ', ParameterDirection.InputOutput)
            MyBase.AgregarParametroStore("@Orden", Orden, DbType.Int32)
            MyBase.AgregarParametroStore("@OrdenNivel1", IdNivel1, DbType.String)
            MyBase.AgregarParametroStore("@OrdenNivel2", IdNivel2, DbType.String)
            MyBase.AgregarParametroStore("@OrdenNivel3", IdNivel3, DbType.String)
            MyBase.AgregarParametroStore("@OrdenNivel4", IdNivel4, DbType.String)
            MyBase.AgregarParametroStore("@OrdenNivel5", IdNivel5, DbType.String)
            MyBase.AgregarParametroStore("@OrdenNivel6", OrdenNivel6, DbType.String)
            MyBase.AgregarParametroStore("@TipoModif", TipoModif, DbType.String)


            ' ------------------------- Nombre de Procedure -------------------
            MyBase.EjecutarStoreProcedure(StoreP, con, , True)
            MyBase.Desconectar()
            'MyBase.GrabarTransaccion()
            'Pk = MyBase.ParametrosStore(1).Value
        Catch ex As Exception
            'MyBase.AnularTransaccion()
            MyBase.Desconectar()
        End Try


    End Sub

    Public Sub Anular()
        Dim con As SqlClient.SqlConnection
        Dim tran As SqlClient.SqlTransaction
        Try


            con = New SqlConnection()
            ' tran = MyBase.IniciarTransaccion()

            Dim reader = New AppSettingsReader()
            Dim stringSetting = reader.GetValue("Base", GetType(String))
            MyBase.BaseDatos = stringSetting.ToString()
            con = MyBase.Conectar()

            MyBase.LimpiarParametrosStore()
            MyBase.AgregarParametroStore("@Accion", "DEL", DbType.String)
            MyBase.AgregarParametroStore("@ProductoId", ProductoId, DbType.String) ', ParameterDirection.InputOutput)



            ' ------------------------- Nombre de Procedure -------------------
            MyBase.EjecutarStoreProcedure(StoreP, con, , True)
            MyBase.Desconectar()
            'MyBase.GrabarTransaccion()
            'Pk = MyBase.ParametrosStore(1).Value
        Catch ex As Exception
            'MyBase.AnularTransaccion()
            MyBase.Desconectar()
        End Try


    End Sub


    Public Function BuscarReg() As DataTable

        Dim dtsDatos As New DataTable
        Dim dsDatos As New DataSet

        Dim con As SqlConnection = New SqlConnection()

        Dim reader = New AppSettingsReader()
        Dim stringSetting = reader.GetValue("Base", GetType(String))
        MyBase.BaseDatos = stringSetting.ToString()
        con = MyBase.Conectar()

        MyBase.LimpiarParametrosStore()
        MyBase.BaseDatos = BaseDatos
        MyBase.AgregarParametroStore("@Accion", "BUS", DbType.String) 'busq registros
        'If Me.Pk <> 0 Then MyBase.AgregarParametroStore("@Pk", Me.Pk, DbType.String)
        'If Me.Empresa <> "" Then MyBase.AgregarParametroStore("@Empresa", Me.Empresa, DbType.String)

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
            dsDatos.Tables.Add(dtsDatos)
            Return dtsDatos 'Me.Valor '-- 
        Catch ex As Exception
            Return dtsDatos '"Err"
        End Try

    End Function
End Class
