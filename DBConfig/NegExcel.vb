Imports System.Windows.Forms
'Imports Microsoft.Office.Interop
'Imports Microsoft.Office.Interop.Excel
Imports System.Data.DataTable
Imports System.Xml
Imports System.Xml.Xsl
Imports System.IO
Imports System.Data.OleDb

Public Class NegExcel

    'Public Sub GenerarExcel(ByVal Ruta_xls As String, ByVal ds As DataSet)

    '    Dim oExcel As Excel.ApplicationClass
    '    Dim oBooks As Excel.Workbooks
    '    Dim oBook As Excel.WorkbookClass
    '    Dim oSheet As Excel.Worksheet
    '    'Dim archivo As String
    '    'Dim archivo_XLS As String

    '    Try


    '        ' Inicia Excel y abre el workbook
    '        oExcel = CreateObject("Excel.Application")
    '        'oExcel.Visible = True
    '        oBooks = oExcel.Workbooks
    '        oBook = oExcel.Workbooks.Add

    '        'oBook = oBooks.Open( _
    '        '    "C:\DevCare\DevCareExcelAutomation\Data.xls")

    '        'Const ROW_FIRST = 3
    '        Dim iRow As Int64 = 1



    '        ' Loop que almacena los datos
    '        'Dim rowCustomer As dsCustomers.CustomersRow
    '        'For Each rowCustomer In Me.DsCustomers.Customers
    '        '    Dim iCurrRow As Int64 = ROW_FIRST + iRow
    '        '    oSheet.Cells(iCurrRow, 1) = rowCustomer.CustomerID
    '        '    oSheet.Cells(iCurrRow, 2) = rowCustomer.CompanyName
    '        '    oSheet.Cells(iCurrRow, 3) = rowCustomer.ContactName
    '        '    oSheet.Cells(iCurrRow, 4) = rowCustomer.Country

    '        '    iRow += 1
    '        'Next


    '        Dim dt As Data.DataTable
    '        Dim i_NombreColumna As Integer = 0
    '        For i = 0 To ds.Tables.Count - 1
    '            oSheet = oBook.Sheets.Add
    '            ' Sheet.Name = "Datos" & i + 1
    '            dt = ds.Tables(i).Copy
    '            'NOMBRES DE LAS COLUMNAS'
    '            i_NombreColumna = 1
    '            If dt.TableName.ToString <> "TblEstado" Then
    '                For Each column In dt.Columns
    '                    'Console.WriteLine(column.ColumnName)
    '                    oSheet.Cells(1, i_NombreColumna) = column.ColumnName.ToString

    '                    i_NombreColumna = i_NombreColumna + 1
    '                Next

    '                For Filas = 0 To dt.Rows.Count - 1
    '                    Dim row As DataRow = dt.Rows(Filas)

    '                    For Columnas = 0 To dt.Columns.Count - 1
    '                        Dim valor As String
    '                        If Not IsDBNull(row(Columnas)) Then
    '                            valor = IIf(String.IsNullOrEmpty(row(Columnas)), "", CStr(row(Columnas)))
    '                        Else
    '                            valor = ""
    '                        End If
    '                        If Filas = 0 Then

    '                            Dim ty As Type = row(Columnas).GetType

    '                            If (ty.Equals(GetType(System.String))) Then
    '                                'oSheet.Cells(Filas + 2, Columnas + 1).NumberFormat = "@"
    '                                oSheet.Columns(Columnas + 1).NumberFormat = "@"
    '                            End If
    '                            If ty.Equals(GetType(System.Int32)) Then
    '                                'oSheet.Cells(Filas + 2, Columnas + 1).NumberFormat = "0"
    '                                oSheet.Columns(Columnas + 1).NumberFormat = "0"
    '                            End If
    '                            If ty.Equals(GetType(System.Decimal)) Then
    '                                'oSheet.Cells(Filas + 2, Columnas + 1).NumberFormat = "#,##0.00"
    '                                oSheet.Columns(Columnas + 1).NumberFormat = "#,##0.00"
    '                            End If
    '                            If (ty.Equals(GetType(System.DBNull))) Then
    '                                'oSheet.Cells(Filas + 2, Columnas + 1).NumberFormat = "@"
    '                                oSheet.Columns(Columnas + 1).NumberFormat = "@"
    '                            End If
    '                            If (ty.Equals(GetType(System.DateTime))) Then
    '                                'oSheet.Cells(Filas + 2, Columnas + 1).NumberFormat = "dd/mm/yyyy h:mm"
    '                                oSheet.Columns(Columnas + 1).NumberFormat = "dd/mm/yyyy h:mm"
    '                            End If
    '                        End If
    '                        oSheet.Cells(Filas + 2, Columnas + 1) = valor
    '                    Next
    '                Next
    '            End If
    '            '' Fórmula
    '            'oSheet.Cells(ROW_FIRST + iRow + 1, 1) = _
    '            '    "=counta(R" & (ROW_FIRST + 1) & "C1:R" & _
    '            '    (ROW_FIRST + iRow - 1).ToString & "C1)"
    '            ' If PBar.Value < 50 Then PBar.PerformStep()
    '            System.Windows.Forms.Application.DoEvents()
    '        Next (i)
    '        oExcel.Visible = True

    '        'oSheet.Range("A1").CopyFromRecordset( ds) ' esto puede funcionar mejor no se lo ha probado

    '        'archivo = String.Format(Now, "yyyymmddHhNnSs") ' OJO aca no se con que nombre ponerle a los archivos que se van generando lo unico que se me ocurre para que no se repita es ponerle la feha y hora.
    '        'archivo = NombreArch & "_" & Now.Year & Format(Now.Month, "0#") & Format(Now.Day, "0#") & Format(Now.Hour, "0#") & Format(Now.Minute, "0#") & Format(Now.Second, "0#")
    '        '' faltaria validar que no exsta el archivo 
    '        'archivo = NombreArch
    '        'archivo_XLS = IIf(Mid(Ruta_xls, Len(Ruta_xls), 1) = "\", Ruta_xls, Ruta_xls & "\") & archivo & ".xlsx"
    '        'oBook.SaveAs(archivo_XLS) ' , Excel.XlFileFormat.xlWorkbookNormal)

    '        oBook.SaveAs(Ruta_xls,) ' , Excel.XlFileFormat.xlWorkbookNormal)
    '        ' oBook.SaveAs("e:\prueba.xlsx", Excel.XlFileFormat.xlWorkbookNormal)

    '        '' Cierra todo 
    '        oBook.Close(True)
    '        'System.Runtime.InteropServices.Marshal. _
    '        '    ReleaseComObject(oBook)
    '        oBook = Nothing

    '        'System.Runtime.InteropServices.Marshal. _
    '        '    ReleaseComObject(oBooks)
    '        'oBooks = Nothing

    '        oExcel.Quit()
    '        'System.Runtime.InteropServices.Marshal. _
    '        '    ReleaseComObject(oExcel)
    '        oExcel = Nothing
    '        MessageBox.Show("Archivo generado exitosamente en " + Ruta_xls, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub
    'Public Sub GenerarExcelDirect(ByVal Ruta_xls As String, ByVal ds As DataSet) ', ByVal NombreArch As String)

    '    Dim oExcel As Excel.ApplicationClass
    '    Dim oBooks As Excel.Workbooks
    '    Dim oBook As Excel.WorkbookClass
    '    Dim oSheet As Excel.Worksheet
    '    Dim archivo As String
    '    Dim archivo_XLS As String

    '    Try
    '        ' Inicia Excel y abre el workbook
    '        oExcel = CreateObject("Excel.Application")
    '        oExcel.Visible = True
    '        oBooks = oExcel.Workbooks
    '        oBook = oExcel.Workbooks.Add

    '        'oBook = oBooks.Open( _
    '        '    "C:\DevCare\DevCareExcelAutomation\Data.xls")

    '        Const ROW_FIRST = 3
    '        Dim iRow As Int64 = 1


    '        'using (XLWorkbook wb = new XLWorkbook())
    '        '{
    '        '    foreach (DataTable dt in ds.Tables)
    '        '    {                            
    '        '        wb.Worksheets.Add(dt);
    '        '    } 




    '        ' Loop que almacena los datos
    '        'Dim rowCustomer As dsCustomers.CustomersRow
    '        'For Each rowCustomer In Me.DsCustomers.Customers
    '        '    Dim iCurrRow As Int64 = ROW_FIRST + iRow
    '        '    oSheet.Cells(iCurrRow, 1) = rowCustomer.CustomerID
    '        '    oSheet.Cells(iCurrRow, 2) = rowCustomer.CompanyName
    '        '    oSheet.Cells(iCurrRow, 3) = rowCustomer.ContactName
    '        '    oSheet.Cells(iCurrRow, 4) = rowCustomer.Country

    '        '    iRow += 1
    '        'Next


    '        Dim dt As Data.DataTable
    '        Dim i_NombreColumna As Integer = 0
    '        'For i = 0 To ds.Tables.Count - 1
    '        oSheet = oBook.Sheets.Add
    '        '    ' Sheet.Name = "Datos" & i + 1
    '        dt = ds.Tables(0).Copy
    '        '    'NOMBRES DE LAS COLUMNAS'
    '        '    i_NombreColumna = 1
    '        '    If dt.TableName.ToString <> "TblEstado" Then
    '        '        For Each column In dt.Columns
    '        '            'Console.WriteLine(column.ColumnName)
    '        '            oSheet.Cells(1, i_NombreColumna) = column.ColumnName.ToString
    '        '            i_NombreColumna = i_NombreColumna + 1
    '        '        Next

    '        '        For Filas = 0 To dt.Rows.Count - 1
    '        '            Dim row As DataRow = dt.Rows(Filas)

    '        '            For Columnas = 0 To dt.Columns.Count - 1
    '        '                Dim valor As String
    '        '                If Not IsDBNull(row(Columnas)) Then
    '        '                    valor = IIf(String.IsNullOrEmpty(row(Columnas)), "", CStr(row(Columnas)))
    '        '                Else
    '        '                    valor = ""
    '        '                End If


    '        '                Dim ty As Type = row(Columnas).GetType

    '        '                If (ty.Equals(GetType(System.String))) Then
    '        '                    oSheet.Cells(Filas + 2, Columnas + 1).NumberFormat = "@"
    '        '                End If
    '        '                If ty.Equals(GetType(System.Int32)) Then
    '        '                    oSheet.Cells(Filas + 2, Columnas + 1).NumberFormat = "0"
    '        '                End If
    '        '                If ty.Equals(GetType(System.Decimal)) Then
    '        '                    oSheet.Cells(Filas + 2, Columnas + 1).NumberFormat = "#,##0.00"
    '        '                End If
    '        '                If (ty.Equals(GetType(System.DBNull))) Then
    '        '                    oSheet.Cells(Filas + 2, Columnas + 1).NumberFormat = "@"
    '        '                End If
    '        '                If (ty.Equals(GetType(System.DateTime))) Then
    '        '                    oSheet.Cells(Filas + 2, Columnas + 1).NumberFormat = "dd/mm/yyyy h:mm"
    '        '                End If

    '        '                oSheet.Cells(Filas + 2, Columnas + 1) = valor
    '        '            Next
    '        '        Next
    '        '    End If
    '        '    '' Fórmula
    '        '    'oSheet.Cells(ROW_FIRST + iRow + 1, 1) = _
    '        '    '    "=counta(R" & (ROW_FIRST + 1) & "C1:R" & _
    '        '    '    (ROW_FIRST + iRow - 1).ToString & "C1)"
    '        'Next i


    '        oBook.Worksheets.Add(dt, "sheet1")


    '        oBook.Worksheets.Add(dt)

    '        oSheet.Range("A1").CopyFromRecordset(dt) ' esto puede funcionar mejor no se lo ha probado

    '        'archivo = String.Format(Now, "yyyymmddHhNnSs") ' OJO aca no se con que nombre ponerle a los archivos que se van generando lo unico que se me ocurre para que no se repita es ponerle la feha y hora.
    '        'archivo = NombreArch & "_" & Now.Year & Format(Now.Month, "0#") & Format(Now.Day, "0#") & Format(Now.Hour, "0#") & Format(Now.Minute, "0#") & Format(Now.Second, "0#")
    '        '' faltaria validar que no exsta el archivo 

    '        'archivo_XLS = IIf(Mid(Ruta_xls, Len(Ruta_xls), 1) = "\", Ruta_xls, Ruta_xls & "\") & archivo & ".xlsx"
    '        'oBook.SaveAs(archivo_XLS) ' , Excel.XlFileFormat.xlWorkbookNormal)
    '        oBook.SaveAs(Ruta_xls)

    '        '' Cierra todo 
    '        oBook.Close(True)
    '        'System.Runtime.InteropServices.Marshal. _
    '        '    ReleaseComObject(oBook)
    '        oBook = Nothing

    '        'System.Runtime.InteropServices.Marshal. _
    '        '    ReleaseComObject(oBooks)
    '        'oBooks = Nothing

    '        oExcel.Quit()
    '        'System.Runtime.InteropServices.Marshal. _
    '        '    ReleaseComObject(oExcel) 
    '        oExcel = Nothing
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub

    Public Sub GenerarExcel_rowData(ByVal Ruta_xls As String, ByVal ds As DataSet)
        Try
            Dim sheetIndex As Integer
            Dim Ex As New Object
            Dim Wb As New Object
            Dim Ws As New Object

            Ex = CreateObject("Excel.Application")
            Wb = Ex.workbooks.add

            Dim col, row As Integer

            Dim rawData(ds.Tables(0).Rows.Count, ds.Tables(0).Columns.Count - 1) As Object

            For col = 0 To ds.Tables(0).Columns.Count - 1

                rawData(0, col) = ds.Tables(0).Columns(col).ColumnName.ToString() ' creo las columnas en mayusculas

            Next

            For col = 0 To ds.Tables(0).Columns.Count - 1
                For row = 0 To ds.Tables(0).Rows.Count - 1
                    rawData(row + 1, col) = ds.Tables(0).Rows(row).Item(col) ' aqui se rellena las filas del excel
                Next
            Next

            Dim finalColLetter As String = String.Empty

            finalColLetter = ExcelColName(ds.Tables(0).Columns.Count)

            sheetIndex += 1

            Ws = Wb.Worksheets(sheetIndex)

            Dim excelRange As String = String.Format("A1:{0}{1}", finalColLetter, ds.Tables(0).Rows.Count + 1)
            Ws.Range(excelRange, Type.Missing).Value2 = rawData

            '-------------------------------------------------------------------
            'segundo dataset (consolidado)
            Ws = Nothing
            Dim rawData2(ds.Tables(1).Rows.Count, ds.Tables(1).Columns.Count - 1) As Object

            For col = 0 To ds.Tables(1).Columns.Count - 1
                rawData2(0, col) = ds.Tables(1).Columns(col).ColumnName.ToString() ' creo las columnas en mayusculas
            Next

            For col = 0 To ds.Tables(1).Columns.Count - 1
                For row = 0 To ds.Tables(1).Rows.Count - 1
                    rawData2(row + 1, col) = ds.Tables(1).Rows(row).Item(col) ' aqui se rellena las filas del excel
                Next
            Next

            Dim finalColLetter2 As String = String.Empty

            finalColLetter2 = ExcelColName(ds.Tables(1).Columns.Count)

            sheetIndex += 1

            Ws = Wb.Worksheets(sheetIndex)

            Dim excelRange2 As String = String.Format("A1:{0}{1}", finalColLetter2, ds.Tables(1).Rows.Count + 1)
            Ws.Range(excelRange2, Type.Missing).Value2 = rawData2

            '----------------------------------------------------------------------------
            If (File.Exists(Ruta_xls)) Then
                File.Delete(Ruta_xls)
            End If

            Ws = Nothing
            Wb.SaveAs(Ruta_xls)
            Wb.Close(True, Type.Missing, Type.Missing)

            Wb = Nothing ' Libero el Objeto

            Ex.Quit()

            Ex = Nothing ' limpio los no referenciados

            GC.Collect()

            MessageBox.Show("Archivo generado exitosamente en " + Ruta_xls, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try



    End Sub
    Public Function ExcelColName(ByVal Col As Integer) As String

        If Col < 0 And Col > 256 Then
            'MsgBox("Dato Invalido", MsgBoxStyle.Critical)
            Return Nothing
            Exit Function

        End If
        Dim i As Int16
        Dim r As Int16
        Dim S As String
        If Col <= 26 Then
            S = Chr(Col + 64)
        Else
            r = Col Mod 26
            i = System.Math.Floor(Col / 26)
            If r = 0 Then
                r = 26
                i = i - 1
            End If
            S = Chr(i + 64) & Chr(r + 64)
        End If
        ExcelColName = S

    End Function


    'Public Shared Sub CreateWorkbook(ByVal ds As DataSet, ByVal path As String)
    '    Dim xmlDataDoc As XmlDataDocument = New XmlDataDocument(ds)
    '    Dim xt As XslTransform = New XslTransform()
    '    Dim reader As StreamReader = New StreamReader(GetType(WorkbookEngine).Assembly.GetManifestResourceStream(GetType(WorkbookEngine), _, Excel.xsl))
    '    Dim xRdr As XmlTextReader = New XmlTextReader(reader)
    '    xt.Load(xRdr, Nothing, Nothing)
    '    Dim sw As StringWriter = New StringWriter()
    '    xt.Transform(xmlDataDoc, Nothing, sw, Nothing)
    '    Dim myWriter As StreamWriter = New StreamWriter(path + _ , Report.xls)
    '    myWriter.Write(sw.ToString())
    '    myWriter.Close()
    'End Sub

    'Public Function LeerExcel(ByVal Ruta_XLS As String) As DataSet


    '    Dim Excel As Microsoft.Office.Interop.Excel.Application
    '    Dim workbook As Workbook
    '    Excel = New Microsoft.Office.Interop.Excel.Application()
    '    workbook = Excel.Workbooks.Open(Ruta_XLS)
    '    Dim sheet As Worksheet
    '    sheet = workbook.Sheets(1)


    '    Dim rows As Integer = sheet.UsedRange.Rows.Count
    '    Dim cols As Integer = sheet.UsedRange.Columns.Count

    '    Dim dt As New Data.DataTable()
    '    Dim i As Integer
    '    Dim j As Integer

    '    Dim ds As New DataSet()

    '    For j = 1 To cols
    '        Dim valor As String = workbook.Sheets(1).Cells(1, j).Value
    '        If j = 1 Then valor = "Item" ' si la columna es la numero 1 se cambia el nombre automaticamete a ITem para poder realacionar las tablas.
    '        dt.Columns.Add(valor)
    '    Next
    '    For i = 2 To rows
    '        Dim dr As DataRow = dt.NewRow
    '        For j = 1 To cols
    '            Dim valor2 As String = sheet.Cells(i, j).Value
    '            dr(j - 1) = valor2
    '        Next
    '        dt.Rows.Add(dr)
    '    Next
    '    ds.Tables.Add(dt)
    '    Return ds


    'End Function

    Public Function CargarHojaExcel(ByVal ArchivoExcel As String) As DataSet
        Dim connectionString As String
        Dim dt As DataTable = New DataTable()
        Dim ds As New DataSet
        Try
            'If FD1.ShowDialog() = DialogResult.OK Then
            '    ArchivoExcel = FD1.FileName
            'End If
            Dim Ext As String = Path.GetExtension(ArchivoExcel)

            If Ext = ".xls" Then
                connectionString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source =" & ArchivoExcel & "; Extended Properties = 'Excel 8.0;HDR=YES'"
            ElseIf Ext = ".xlsx" Then
                connectionString = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source =" & ArchivoExcel & "; Extended Properties = 'Excel 8.0;HDR=YES'"
            End If

            Dim conn As OleDbConnection = New OleDbConnection(connectionString)
            Dim cmd As OleDbCommand = New OleDbCommand()
            Dim dataAdapter As OleDbDataAdapter = New OleDbDataAdapter()
            cmd.Connection = conn
            conn.Open()
            Dim Dt1 As DataTable
            Dt1 = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
            Dim NombreArchivo As String = Dt1.Rows(0)("TABLE_NAME").ToString()
            conn.Close()
            conn.Open()
            cmd.CommandText = "SELECT * From [" & NombreArchivo & "]"
            dataAdapter.SelectCommand = cmd
            dataAdapter.Fill(dt)

            ds.Tables.Add(dt)
            conn.Close()
        Catch ex As Exception
            Throw ex
        End Try

        Return ds
    End Function
End Class
