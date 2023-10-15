Imports System.Configuration
Imports System.Data.SqlClient
Imports System.IO
Public Class NegCatalogoCampos
    Inherits NegClaseBase.NegClaseBase
    Public Property Pk As Integer
    Public Property Accion As String
    Public Property Tabla As String
    Public Property Campo As String
    Public Property TipoDato As String
    Public Property Posicion As Int32
    Public Property TipoCatalogo As String '18abril2023

    Dim dtsReg As New DataSet
    Private Const StoreP As String = "SpMantCatalogoCampos"
    Private con As SqlClient.SqlConnection
    Public Function ObtenerCatalogoCampos() As DataSet

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
        MyBase.AgregarParametroStore("@TipoCatalogo", TipoCatalogo, DbType.String) 'busq registros

        Try

            dtsDatos = MyBase.EjecutarBusqueda(StoreP, con, True)

            MyBase.Desconectar()
            dsDatos.Tables.Add(dtsDatos)
            Return dsDatos 'Me.Valor '-- 
        Catch ex As Exception
            Return dsDatos '"Err"
        End Try

    End Function


End Class

