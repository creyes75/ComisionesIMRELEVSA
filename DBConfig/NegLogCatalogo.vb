Imports System.Configuration
Imports System.Data.SqlClient
Imports System.IO
Public Class NegLogCatalogo
    Inherits NegClaseBase.NegClaseBase
    Dim dtsReg As New DataSet
    Private Const StoreP As String = "SpMantLogCatalogo"
    Private con As SqlClient.SqlConnection

    Public Property Accion As String
    Public Property Pk As Integer
    Public Property nombreCatalogo As String
    Public Property descripcion As String
    Public Property ODA As String
    Public Property filtros As String
    Public Property filtros2 As String
    Public Property detalle As DataSet
    Public Property TipoCatalogo As String

    Public Function NuevoCatalogo() As Integer

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
            MyBase.AgregarParametroStore("@NombreCatalogo", nombreCatalogo, DbType.String)
            MyBase.AgregarParametroStore("@DescripcionCatalogo", descripcion, DbType.String)
            MyBase.AgregarParametroStore("@ODA", ODA, DbType.String)
            MyBase.AgregarParametroStore("@Filtros", filtros, DbType.Int32)
            MyBase.AgregarParametroStore("@Filtros2", filtros2, DbType.Int32)
            MyBase.AgregarParametroStore("@detalle", detalle.GetXml, DbType.String)
            MyBase.AgregarParametroStore("@TipoCatalogo", TipoCatalogo, DbType.String)

            ' ------------------------- Nombre de Procedure -------------------
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
End Class


