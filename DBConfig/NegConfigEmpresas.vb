Imports System.Data.SqlClient
Imports System.IO

Public Class NegConfigEmpresa
    Inherits NegClaseBase.NegClaseBase

    Public Property Accion As String
    Public Property Pk As Integer
    Public Property EmpresaId As String
    Public Property SoftwareId As String
    Public Property DBname As String
    Public Property DBUser As String
    Public Property DBPassword As String
    Public Property DBInstance As String

    Dim dtsReg As New DataSet
    Private Const StoreP As String = "SpMantEmpresas"
    Private con As SqlClient.SqlConnection

    Public Function BuscarReg(ByRef con As SqlClient.SqlConnection) As DataTable
        Dim dtsDatos As New DataTable
        MyBase.LimpiarParametrosStore()
        MyBase.BaseDatos = BaseDatos
        MyBase.AgregarParametroStore("@Accion", "BUS", DbType.String) 'busq registros
        If Me.Pk <> 0 Then MyBase.AgregarParametroStore("@Pk", Me.Pk, DbType.String)
        If Me.EmpresaId <> "" Then MyBase.AgregarParametroStore("@EmpresaId", Me.EmpresaId, DbType.String)
        If Me.SoftwareId <> "" Then MyBase.AgregarParametroStore("@SoftwareId", Me.SoftwareId, DbType.String)

        dtsDatos = MyBase.EjecutarBusqueda(StoreP, con, True)
        MyBase.Desconectar()
        Return dtsDatos '-- retorna un dataset para lecturas de datos masivas

    End Function
    Public Function BuscarConfBase(ByRef con As SqlClient.SqlConnection) As Boolean
        Dim dtsDatos As New DataTable
        Try


            MyBase.LimpiarParametrosStore()
            MyBase.BaseDatos = BaseDatos
            MyBase.AgregarParametroStore("@Accion", "BUS", DbType.String) 'busq registros
            If Me.Pk <> 0 Then MyBase.AgregarParametroStore("@Pk", Me.Pk, DbType.String)
            If Me.EmpresaId <> "" Then MyBase.AgregarParametroStore("@EmpresaId", Me.EmpresaId, DbType.String)
            If Me.SoftwareId <> "" Then MyBase.AgregarParametroStore("@SoftwareId", Me.SoftwareId, DbType.String)

            dtsDatos = MyBase.EjecutarBusqueda(StoreP, con, True)
            Dim rowcab As DataRow
            If dtsDatos.Rows.Count > 0 Then

                rowcab = dtsDatos.Rows(0)
                If IsDBNull(rowcab("DBname")) Then
                    Me.DBname = ""
                Else
                    Me.DBname = rowcab("DBname")
                End If
                If IsDBNull(rowcab("DBInstance")) Then
                    Me.DBInstance = ""
                Else
                    Me.DBInstance = rowcab("DBInstance")
                End If
                If IsDBNull(rowcab("DBUser")) Then
                    Me.DBUser = ""
                Else
                    Me.DBUser = rowcab("DBUser")
                End If
                If IsDBNull(rowcab("DBPassword")) Then
                    Me.DBPassword = ""
                Else
                    Me.DBPassword = rowcab("DBPassword")
                End If

            End If

            Return True '-- retorna un dataset para lecturas de datos masivas
        Catch ex As Exception
            Return False
        End Try
    End Function

    'Public Function Leer(ByVal intPk As Integer) As Boolean
    '    Try
    '        Dim rowCab As DataRow
    '        Me.LlenarDataSet(intPk)
    '        If Me.dtsReg.Tables(0).Rows.Count > 0 Then

    '            rowCab = dtsReg.Tables(0).Rows(0)

    '            'Me.Comentario = rowCab("Comentario")
    '            'Me.Fecha = rowCab("Fecha")

    '            If IsDBNull(rowCab("EmpresaId")) Then
    '                Me.EmpresaId = ""
    '            Else
    '                Me.EmpresaId = rowCab("EmpresaId")
    '            End If

    '            If IsDBNull(rowCab("SoftwareId")) Then
    '                Me.SoftwareId = ""
    '            Else
    '                Me.SoftwareId = rowCab("SoftwareId")
    '            End If

    '            If IsDBNull(rowCab("DBName")) Then
    '                Me.DBname = ""
    '            Else
    '                Me.DBname = rowCab("DBName")
    '            End If

    '            If IsDBNull(rowCab("DBuser")) Then
    '                Me.DBUser = ""
    '            Else
    '                Me.DBUser = rowCab("DBuser")
    '            End If

    '            If IsDBNull(rowCab("DBPassword")) Then
    '                Me.DBPassword = ""
    '            Else
    '                Me.DBPassword = rowCab("DBPassword")
    '            End If
    '            If IsDBNull(rowCab("DBInstance")) Then
    '                Me.DBPassword = ""
    '            Else
    '                Me.DBPassword = rowCab("DBInstance")
    '            End If

    '            Return True
    '        Else
    '            Return False
    '        End If
    '    Catch
    '        Throw
    '    End Try
    'End Function

    'Private Sub LlenarDataSet(ByVal intpk As Integer)
    '    Try
    '        Me.dtsReg.Clear()
    '        dtsReg.Tables.Clear()

    '        Dim vAnticipo As New DataTable("vConfigEmpresas")

    '        con = MyBase.Conectar()

    '        MyBase.LimpiarParametrosStore() ' CABECERA 
    '        MyBase.AgregarParametroStore("@Accion", "CPK", DbType.String)
    '        MyBase.AgregarParametroStore("@Pk", intpk, DbType.Int16)
    '        vAnticipo = MyBase.EjecutarBusqueda(StoreP, con, True)
    '        dtsReg.Tables.Add(vAnticipo)
    '        Me.Desconectar()
    '    Catch ex As Exception
    '        Throw
    '    End Try

    'End Sub


    Public Sub Anular(ByRef con As SqlClient.SqlConnection, ByVal tran As SqlClient.SqlTransaction)

        MyBase.LimpiarParametrosStore()
        MyBase.AgregarParametroStore("@Accion", "DEL", DbType.String)


        MyBase.AgregarParametroStore("@Pk", Pk, DbType.Int32, ParameterDirection.InputOutput)

        ' ------------------------- Nombre de Procedure -------------------
        MyBase.EjecutarStoreProcedure(StoreP, con, tran, True)

        Pk = MyBase.ParametrosStore(1).Value

    End Sub


    Public Sub Grabar(ByRef con As SqlClient.SqlConnection, ByVal tran As SqlClient.SqlTransaction)

        MyBase.LimpiarParametrosStore()
        If Accion = "I" Then
            MyBase.AgregarParametroStore("@Accion", "INS", DbType.String)
        Else
            MyBase.AgregarParametroStore("@Accion", "UPD", DbType.String)
        End If
        MyBase.AgregarParametroStore("@Pk", Pk, DbType.Int32, ParameterDirection.InputOutput)
        MyBase.AgregarParametroStore("@EmpresaId", EmpresaId, DbType.String)
        MyBase.AgregarParametroStore("@SoftwareId", SoftwareId, DbType.String)
        MyBase.AgregarParametroStore("@DBname", DBname, DbType.String)
        MyBase.AgregarParametroStore("@DBuser", DBname, DbType.String)
        MyBase.AgregarParametroStore("@DBpassword", DBPassword, DbType.String)
        MyBase.AgregarParametroStore("@DBInstance", DBInstance, DbType.String)

        ' ------------------------- Nombre de Procedure -------------------
        MyBase.EjecutarStoreProcedure(StoreP, con, tran, True)

        Pk = MyBase.ParametrosStore(1).Value

    End Sub


    'Public Sub CambiarEstado(ByRef con As SqlClient.SqlConnection, ByVal tran As SqlClient.SqlTransaction)
    '    MyBase.LimpiarParametrosStore()
    '    MyBase.AgregarParametroStore("@Accion", "AEC", DbType.String)
    '    MyBase.AgregarParametroStore("@ComentarioLog", "Cambio de Estado", DbType.String)
    '    MyBase.AgregarParametroStore("@Estado", Estado, DbType.String)
    '    MyBase.AgregarParametroStore("@Usr_pk", Usr_pk, DbType.Int32)
    '    MyBase.AgregarParametroStore("@Pk", Pk, DbType.Int64)

    '    ' ------------------------- Nombre de Procedure -------------------
    '    MyBase.EjecutarStoreProcedure("SpManttblMailConfiguracion", con, tran, True)

    'End Sub




End Class

