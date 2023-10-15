Imports System.Configuration
Imports System.Data.SqlClient
Imports System.IO
Public Class NegParametro
    Inherits NegClaseBase.NegClaseBase
    Public Property Pk As Integer
    Public Property Accion As String
    Public Property Parametro As String
    Public Property Valor As String

    Dim dtsReg As New DataSet
    Private Const StoreP As String = "SpMantParametro"
    Private con As SqlClient.SqlConnection
    Public Function BuscarParametro(ByVal Parametro As String) As String
        Dim dtsDatos As New DataTable

        Dim con As SqlConnection = New SqlConnection()

        Dim reader = New AppSettingsReader()
        Dim stringSetting = reader.GetValue("Base", GetType(String))
        MyBase.BaseDatos = stringSetting.ToString()
        con = MyBase.Conectar()
        Me.Parametro = Parametro

        MyBase.LimpiarParametrosStore()
        MyBase.BaseDatos = BaseDatos
        MyBase.AgregarParametroStore("@Accion", "PAR", DbType.String) 'busq registros

        If Me.Parametro <> "" Then MyBase.AgregarParametroStore("@Parametro", Me.Parametro, DbType.String)

        Try

            dtsDatos = MyBase.EjecutarBusqueda(StoreP, con, True)
            Dim rowcab As DataRow
            If dtsDatos.Rows.Count > 0 Then

                rowcab = dtsDatos.Rows(0)
                If IsDBNull(rowcab("ParametroValor")) Then
                    Me.Valor = ""
                Else
                    Me.Valor = rowcab("ParametroValor")
                End If

            End If
            MyBase.Desconectar()
            Return Me.Valor '-- 
        Catch ex As Exception
            Return "Err"
        End Try

    End Function


End Class
