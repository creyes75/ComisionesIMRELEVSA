Imports System.Configuration
Imports DBConfig

Public Class FrmComision
    Public dsComisionGeneral As New DataSet()
    Public dsComisionConsolidado As New DataSet()
    Dim oNegLogComision As NegLogComision
    Dim oComision As ClsComision = New ClsComision()
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '--------------------llena info de almacen --------------------
        Llena_Info_Almacen()
        llena_Info_Vendedor()

    End Sub
    Private Sub Llena_Info_Almacen()
        Dim onegAlmacen As New ClsAlmacen()
        Dim dsAlmacen As DataSet
        dsAlmacen = New DataSet()
        Dim oRespuesta = New ClsRespuestaReg

        oRespuesta = onegAlmacen.ObtenerDatos("")
        If oRespuesta.errCodigo = 0 Then
            dsAlmacen = oRespuesta.detalle
            CmbAlmacen.ValueMember = dsAlmacen.Tables(0).Columns(0).ColumnName.ToString()
            CmbAlmacen.DisplayMember = dsAlmacen.Tables(0).Columns(1).ColumnName.Trim()
            CmbAlmacen.DataSource = dsAlmacen.Tables(0)
        Else
            MessageBox.Show("Error en carga de informaicon de Almacenes (" + oRespuesta.errMensaje + ")", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub llena_Info_Vendedor()
        Dim onegVendedor As New ClsVendedor()
        Dim dsVendedor As DataSet
        dsVendedor = New DataSet()
        Dim oRespuesta = New ClsRespuestaReg

        oRespuesta = onegVendedor.ObtenerDatos("") '---ojo aqui falta incluir la condicion.
        If oRespuesta.errCodigo = 0 Then
            dsVendedor = oRespuesta.detalle

            LstVendedor.DataSource = dsVendedor.Tables(0)
            LstVendedor.ValueMember = dsVendedor.Tables(0).Columns(0).ColumnName.ToString()
            LstVendedor.DisplayMember = dsVendedor.Tables(0).Columns(1).ColumnName.ToString()

        Else
            MessageBox.Show("Error en carga de informaicon de Vendedores (" + oRespuesta.errMensaje + ")", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub cargaGrid()

        'Add a CheckBox Column to the DataGridView at the first position.
        Dim checkBoxColumn As New DataGridViewCheckBoxColumn()
        checkBoxColumn.HeaderText = ""
        checkBoxColumn.Width = 30
        checkBoxColumn.Name = "Incluir"
        DGV_Detalle.Columns.Insert(0, checkBoxColumn)
    End Sub

    Private Sub tSB_Save_Click(sender As Object, e As EventArgs) Handles tSB_Save.Click
        If dsComisionGeneral Is Nothing Then
            MessageBox.Show("No existe informacion para ser grabada", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        If dsComisionGeneral.Tables.Count = 0 Then
            MessageBox.Show("No existe informacion para ser grabada", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If


        Dim ofrmSave As frmSave = New frmSave()
        oComision.detalles = dsComisionGeneral
        oComision.consolidado = dsComisionConsolidado
        oComision.Anio = MskAnio.Text
        oComision.Mes = CmbMes.SelectedIndex + 1
        oComision.Almacen = CmbAlmacen.ValueMember
        oComision.Vendedor = LstVendedor.SelectedValue


        ofrmSave.oComision = oComision
        ofrmSave.ShowDialog()
        oComision = ofrmSave.oComision
        'ComisionGrabado = ofrmSave.GrabadoExitoso
    End Sub

    Private Sub tSBExit_Click(sender As Object, e As EventArgs) Handles tSBExit.Click
        End
    End Sub

    Private Sub tSB_New_Click(sender As Object, e As EventArgs) Handles tSB_New.Click
        PnlDatosGenerales.Enabled = True
        dsComisionGeneral = Nothing
        dsComisionConsolidado = Nothing
        oComision = New ClsComision

    End Sub

    Private Sub tSBOpen_Click(sender As Object, e As EventArgs) Handles tSBOpen.Click
        Dim oFrmOpen As FrmOpen = New FrmOpen()
        oFrmOpen.ShowDialog()

        If Not oFrmOpen.oProcesoCancelado Then
            dsComisionGeneral = Nothing
            dsComisionGeneral = oFrmOpen.dsComisionDetalle
            dsComisionConsolidado = oFrmOpen.dsComisionConsolidado

            Dim sourceDet As BindingSource = New BindingSource()
            sourceDet.DataSource = dsComisionGeneral.Tables(0).DefaultView
            'DGV_Detalle.AllowUserToResizeColumns = True
            DGV_Detalle.DataSource = sourceDet

            Dim sourceCons As BindingSource = New BindingSource()
            sourceCons.DataSource = dsComisionConsolidado.Tables(0).DefaultView
            'DGV_Detalle.AllowUserToResizeColumns = True
            DGV_Consolidado.DataSource = sourceCons

            oNegLogComision = oFrmOpen.oLogComision

            oComision.Pk = oNegLogComision.Pk
            oComision.NombreComision = oNegLogComision.nombreComision
            oComision.Anio = oNegLogComision.anio
            oComision.Mes = oNegLogComision.mes
            oComision.Almacen = oNegLogComision.almacen
            oComision.Vendedor = oNegLogComision.vendedor
            oComision.DescripcionComision = oNegLogComision.descripcion
            oComision.detalles = oNegLogComision.detalle
            oComision.consolidado = oNegLogComision.consolidado
        End If
    End Sub

    Private Sub tSBExcel_Click(sender As Object, e As EventArgs) Handles tSBExcel.Click
        Try
            Dim reader = New AppSettingsReader()
            Dim stringSetting = reader.GetValue("Ruta_XLS", GetType(String))
            Dim Ruta_xls As String = stringSetting.ToString()
            Dim OnegExcel As DBConfig.NegExcel = New DBConfig.NegExcel()
            Dim dsExcel As DataSet = New DataSet()
            Dim dtExcel As DataTable = New DataTable()
            Dim dtExcelConsolidado As DataTable = New DataTable()
            saveFileDialog1.Filter = "XLS files (*.xls)|*.xls|All files (*.*)|*.*"
            saveFileDialog1.DefaultExt = "xls"

            If saveFileDialog1.ShowDialog() = DialogResult.OK Then
                Ruta_xls = saveFileDialog1.FileName
                dtExcel = GeneraDataTable(DGV_Detalle)
                dtExcelConsolidado = GeneraDataTable(DGV_Consolidado)
                dsExcel.Tables.Add(dtExcel)
                dsExcel.Tables.Add(dtExcelConsolidado)

                OnegExcel.GenerarExcel_rowData(Ruta_xls, dsExcel)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Function GeneraDataTable(ByVal GridView1 As DataGridView) As DataTable
        Dim dt As DataTable = New DataTable()

        For i As Integer = 0 To GridView1.ColumnCount - 1
            dt.Columns.Add(GridView1.Columns(i).Name)
        Next

        For Each row As DataGridViewRow In GridView1.Rows
            Dim dr As DataRow
            dr = dt.NewRow()

            For i As Integer = 0 To row.Cells.Count - 1
                dr(i) = row.Cells(i).Value
            Next

            dt.Rows.Add(dr)
        Next

        Return dt
    End Function

    Private Sub btnProcesar_Click(sender As Object, e As EventArgs) Handles btnProcesar.Click
        aqui falta validar q la combinacion anio mes, bodega noexista 

        If oNegLogComision.ValidaExistenciaCatalogo(MskAnio.Text, CmbMes.SelectedIndex + 1, CmbAlmacen.SelectedValue) Then
            MessageBox.Show("La comision para este Anio/Mes/Almacen ya fue calculada previamente, por favor utilice la opcion de consulta.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else '--no existe
            'aqui se debe adicionar la llamada al calculo y carga de los grids.
        End If
    End Sub

    Private Sub tSBConfig_Click(sender As Object, e As EventArgs) Handles tSBConfig.Click

    End Sub
End Class
