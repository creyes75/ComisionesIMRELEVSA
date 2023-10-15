Public Class frmSave
    Public Property ProcesoCancelado As Boolean
    Public Property GrabadoExitoso As Boolean
    Public Property oComision As ClsComision

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        GrabadoExitoso = False
        ProcesoCancelado = True
        Me.Close()
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        Dim oNegLogComision As NegLogComision = New NegLogComision()
        oComision.NombreComision = txtNombre.Text
        oComision.DescripcionComision = txtDescripcion.Text

        oNegLogComision.nombreComision = txtNombre.Text
        oNegLogComision.descripcion = txtDescripcion.Text
        oNegLogComision.anio = oComision.Anio
        oNegLogComision.mes = oComision.Mes
        oNegLogComision.almacen = oComision.Almacen
        oNegLogComision.vendedor = oComision.Vendedor
        oNegLogComision.detalle = oComision.detalles
        oNegLogComision.consolidado = oComision.consolidado

        ProcesoCancelado = False
        If oComision.Pk = 0 Then
            oComision.Pk = oNegLogComision.NuevaComision()
        Else
            oComision.Pk = oNegLogComision.ActualizaComision
        End If

        If oComision.Pk <> -10000 Then
            MessageBox.Show("Comision " & oNegLogComision.nombreComision & " almacenada con exito", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
            GrabadoExitoso = True
        Else
            MessageBox.Show("Se presento un error al grabar una nueva comision")
            GrabadoExitoso = False
        End If

        Me.Close()
    End Sub

    Private Sub frmSave_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class