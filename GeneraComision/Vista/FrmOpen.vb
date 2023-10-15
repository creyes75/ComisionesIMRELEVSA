Imports System.IO
Imports System.Xml

Public Class FrmOpen
    Public Property oProcesoCancelado As Boolean
    Public Property dsComisionDetalle As DataSet
    Public Property dsComisionConsolidado As DataSet
    Public Property oLogComision As NegLogComision

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub FrmOpen_Load(ByVal sender As Object, ByVal e As EventArgs)
        Dim oLogCatalogo As NegLogComision = New NegLogComision()
        Me.dataGridView1.DataSource = oLogCatalogo.BuscarLog()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs)
        oProcesoCancelado = True
        Me.Close()
    End Sub

    Private Sub btnOK_Click(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Dim dgwr As DataGridViewRow = New DataGridViewRow()
            Dim dgrow As DataGridViewRow = dataGridView1.Rows(dataGridView1.SelectedCells(0).RowIndex)
            Dim XML As String = dgrow.Cells("detalle").Value.ToString()
            Dim XML_Consolidado As String = dgrow.Cells("consolidado").Value.ToString()

            Dim doc As XmlDocument = New XmlDocument()
            Dim doc_consolidado As XmlDocument = New XmlDocument()
            doc.Load(New StringReader(XML))
            doc_consolidado.Load(New StringReader(XML_Consolidado))
            'falta incluir ds consolodado
            Dim ds As DataSet = New DataSet()
            ds.ReadXml(New XmlNodeReader(doc))
            Dim dtComisionDet As DataTable = New DataTable()
            dtComisionDet = ds.Tables(0)

            Dim dsConsolidado As DataSet = New DataSet()
            dsConsolidado.ReadXml(New XmlNodeReader(doc_consolidado))
            Dim dtComisionCons As DataTable = New DataTable()
            dtComisionCons = dsConsolidado.Tables(0)

            'dtComisionDet.DefaultView.Sort = "OrdenNivel6 asc"
            'dtComisionDet = dtComisionDet.DefaultView.ToTable(True)
            dsComisionDetalle = ds
            dsComisionConsolidado = dsConsolidado
            oLogComision = New NegLogComision()
            oLogComision.Pk = Integer.Parse(dgrow.Cells("Pk").Value.ToString())
            oLogComision.nombreComision = dgrow.Cells("NombreComision").Value.ToString()
            oLogComision.anio = dgrow.Cells("Anio").Value.ToString()
            oLogComision.mes = dgrow.Cells("Mes").Value.ToString()
            oLogComision.almacen = dgrow.Cells("Almacen").Value.ToString()
            oLogComision.vendedor = dgrow.Cells("Vendedor").Value.ToString()
            oLogComision.descripcion = dgrow.Cells("DescripcionComision").Value.ToString()
            oProcesoCancelado = False
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.[Error])
            oProcesoCancelado = True
        End Try
    End Sub

    Private Sub btnCancel_Click_1(sender As Object, e As EventArgs) Handles btnCancel.Click
        oProcesoCancelado = True
    End Sub

    Private Sub btnOK_Click_1(sender As Object, e As EventArgs) Handles btnOK.Click
        btnOK_Click(sender, e)
    End Sub
End Class