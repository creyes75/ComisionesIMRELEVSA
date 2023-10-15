Imports System.Configuration
Imports System.Data.SqlClient
Imports System.IO
Public Class NegLogComision
    Inherits NegClaseBase.NegClaseBase
    Dim dtsReg As New DataSet
    Private Const StoreP As String = "SpMantLogComision"
    Private con As SqlClient.SqlConnection

    Public Property Accion As String
    Public Property Pk As Integer
    Public Property nombreComision As String
    Public Property descripcion As String
    Public Property anio As String
    Public Property mes As String
    Public Property almacen As String
    Public Property vendedor As String
    Public Property detalle As DataSet
    Public Property consolidado As DataSet


    Public Function NuevaComision() As Integer

        Dim con As SqlConnection = New SqlConnection()

        Dim reader = New AppSettingsReader()
        Dim stringSetting = reader.GetValue("Base", GetType(String))
        MyBase.BaseDatos = stringSetting.ToString()
        con = MyBase.Conectar()
        ' Dim tran As SqlClient.SqlTransaction

        MyBase.LimpiarParametrosStore()
        MyBase.BaseDatos = BaseDatos
        Try

            MyBase.LimpiarParametrosStore()
            'If Accion = "I" Then
            MyBase.AgregarParametroStore("@Accion", "INS", DbType.String)
            'Else
            '    MyBase.AgregarParametroStore("@Accion", "UPD", DbType.String)
            'End If
            MyBase.AgregarParametroStore("@Pk", Pk, DbType.Int32, ParameterDirection.InputOutput)
            MyBase.AgregarParametroStore("@NombreComision", nombreComision, DbType.String)
            MyBase.AgregarParametroStore("@DescripcionComision", descripcion, DbType.String)
            MyBase.AgregarParametroStore("@Anio", anio, DbType.String)
            MyBase.AgregarParametroStore("@Mes", mes, DbType.String)
            MyBase.AgregarParametroStore("@Almacen", almacen, DbType.String)
            MyBase.AgregarParametroStore("@Vendedor", vendedor, DbType.String)
            MyBase.AgregarParametroStore("@detalle", detalle.GetXml, DbType.String)
            MyBase.AgregarParametroStore("@consolidado", consolidado.GetXml, DbType.String)

            MyBase.EjecutarStoreProcedure(StoreP, con, Nothing, True)

            Return MyBase.ParametrosStore(1).Value
        Catch ex As Exception
            Return -10000 '"Err"
        End Try


    End Function

    Public Function ActualizaComision() As Integer

        Dim con As SqlConnection = New SqlConnection()

        Dim reader = New AppSettingsReader()
        Dim stringSetting = reader.GetValue("Base", GetType(String))
        MyBase.BaseDatos = stringSetting.ToString()
        con = MyBase.Conectar()
        ' Dim tran As SqlClient.SqlTransaction

        MyBase.LimpiarParametrosStore()
        MyBase.BaseDatos = BaseDatos
        Try

            MyBase.LimpiarParametrosStore()
            'If Accion = "I" Then
            MyBase.AgregarParametroStore("@Accion", "UPD", DbType.String)
            'Else
            '    MyBase.AgregarParametroStore("@Accion", "UPD", DbType.String)
            'End If
            MyBase.AgregarParametroStore("@Pk", Pk, DbType.Int32, ParameterDirection.InputOutput)
            MyBase.AgregarParametroStore("@NombreComision", nombreComision, DbType.String)
            MyBase.AgregarParametroStore("@DescripcionComision", descripcion, DbType.String)
            MyBase.AgregarParametroStore("@Anio", anio, DbType.String)
            MyBase.AgregarParametroStore("@Mes", mes, DbType.String)
            MyBase.AgregarParametroStore("@Almacen", almacen, DbType.String)
            MyBase.AgregarParametroStore("@Vendedor", vendedor, DbType.String)
            MyBase.AgregarParametroStore("@detalle", detalle.GetXml, DbType.String)
            MyBase.AgregarParametroStore("@consolidado", consolidado.GetXml, DbType.String)

            MyBase.EjecutarStoreProcedure(StoreP, con, Nothing, True)

            Return MyBase.ParametrosStore(1).Value
        Catch ex As Exception
            Return -10000 '"Err"
        End Try


    End Function

    Public Function BuscarLog() As DataTable

        Dim dtsDatos As New DataTable
        Dim con As SqlConnection = New SqlConnection()

        Dim reader = New AppSettingsReader()
        Dim stringSetting = reader.GetValue("Base", GetType(String))
        MyBase.BaseDatos = stringSetting.ToString()
        con = MyBase.Conectar()

        MyBase.LimpiarParametrosStore()
        MyBase.BaseDatos = BaseDatos
        MyBase.AgregarParametroStore("@Accion", "CON", DbType.String) 'busq registros
        'MyBase.AgregarParametroStore("@OrigenDatos", OrigenDatos, DbType.String) 'busq registros

        Try
            dtsDatos = MyBase.EjecutarBusqueda(StoreP, con, True)
            MyBase.Desconectar()
            Return dtsDatos '-- 
        Catch ex As Exception
            Return Nothing
        End Try

    End Function

    Public Function ValidaExistenciaCatalogo(Anio As String, mes As String, almacen As String) As Boolean

        Dim dtsDatos As New DataTable
        Dim con As SqlConnection = New SqlConnection()

        Dim reader = New AppSettingsReader()
        Dim stringSetting = reader.GetValue("Base", GetType(String))
        MyBase.BaseDatos = stringSetting.ToString()
        con = MyBase.Conectar()

        MyBase.LimpiarParametrosStore()
        MyBase.BaseDatos = BaseDatos
        MyBase.AgregarParametroStore("@Accion", "CON", DbType.String) 'busq registros
        MyBase.AgregarParametroStore("@Anio", Anio, DbType.String)
        MyBase.AgregarParametroStore("@Mes", mes, DbType.String)
        MyBase.AgregarParametroStore("@Almacen", almacen, DbType.String)

        'MyBase.AgregarParametroStore("@OrigenDatos", OrigenDatos, DbType.String) 'busq registros

        Try
            dtsDatos = MyBase.EjecutarBusqueda(StoreP, con, True)
            MyBase.Desconectar()

            'Dim rowcab As DataRow
            If dtsDatos.Rows.Count > 0 Then
                'rowcab = dtsDatos.Rows(0)
                'If IsDBNull(rowcab("ParametroValor")) Then
                '    Me.Valor = ""
                'Else
                '    Me.Valor = rowcab("ParametroValor")
                'End If
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return True
        End Try

    End Function

End Class


