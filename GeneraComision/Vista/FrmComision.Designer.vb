<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmComision
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmComision))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.PnlDatosGenerales = New System.Windows.Forms.Panel()
        Me.LstVendedor = New System.Windows.Forms.CheckedListBox()
        Me.btnProcesar = New System.Windows.Forms.Button()
        Me.CmbAlmacen = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CmbMes = New System.Windows.Forms.ComboBox()
        Me.MskAnio = New System.Windows.Forms.MaskedTextBox()
        Me.DGV_Consolidado = New System.Windows.Forms.DataGridView()
        Me.DGV_Detalle = New System.Windows.Forms.DataGridView()
        Me.toolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tSB_Save = New System.Windows.Forms.ToolStripButton()
        Me.tSB_New = New System.Windows.Forms.ToolStripButton()
        Me.tSBOpen = New System.Windows.Forms.ToolStripButton()
        Me.tSBExcel = New System.Windows.Forms.ToolStripButton()
        Me.tSBConfig = New System.Windows.Forms.ToolStripButton()
        Me.tSBExit = New System.Windows.Forms.ToolStripButton()
        Me.tSLDetalles = New System.Windows.Forms.ToolStripLabel()
        Me.saveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.PnlDatosGenerales.SuspendLayout()
        CType(Me.DGV_Consolidado, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV_Detalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.toolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.Location = New System.Drawing.Point(7, 60)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.PnlDatosGenerales)
        Me.SplitContainer1.Panel1.Controls.Add(Me.DGV_Consolidado)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.DGV_Detalle)
        Me.SplitContainer1.Size = New System.Drawing.Size(778, 404)
        Me.SplitContainer1.SplitterDistance = 180
        Me.SplitContainer1.TabIndex = 12
        '
        'PnlDatosGenerales
        '
        Me.PnlDatosGenerales.Controls.Add(Me.LstVendedor)
        Me.PnlDatosGenerales.Controls.Add(Me.btnProcesar)
        Me.PnlDatosGenerales.Controls.Add(Me.CmbAlmacen)
        Me.PnlDatosGenerales.Controls.Add(Me.Label4)
        Me.PnlDatosGenerales.Controls.Add(Me.Label3)
        Me.PnlDatosGenerales.Controls.Add(Me.Label2)
        Me.PnlDatosGenerales.Controls.Add(Me.Label1)
        Me.PnlDatosGenerales.Controls.Add(Me.CmbMes)
        Me.PnlDatosGenerales.Controls.Add(Me.MskAnio)
        Me.PnlDatosGenerales.Enabled = False
        Me.PnlDatosGenerales.Location = New System.Drawing.Point(8, 8)
        Me.PnlDatosGenerales.Name = "PnlDatosGenerales"
        Me.PnlDatosGenerales.Size = New System.Drawing.Size(263, 160)
        Me.PnlDatosGenerales.TabIndex = 12
        '
        'LstVendedor
        '
        Me.LstVendedor.FormattingEnabled = True
        Me.LstVendedor.Location = New System.Drawing.Point(78, 92)
        Me.LstVendedor.Name = "LstVendedor"
        Me.LstVendedor.Size = New System.Drawing.Size(168, 64)
        Me.LstVendedor.TabIndex = 18
        Me.LstVendedor.UseCompatibleTextRendering = True
        '
        'btnProcesar
        '
        Me.btnProcesar.Location = New System.Drawing.Point(194, 14)
        Me.btnProcesar.Name = "btnProcesar"
        Me.btnProcesar.Size = New System.Drawing.Size(66, 33)
        Me.btnProcesar.TabIndex = 17
        Me.btnProcesar.Text = "Procesar"
        Me.btnProcesar.UseVisualStyleBackColor = True
        '
        'CmbAlmacen
        '
        Me.CmbAlmacen.FormattingEnabled = True
        Me.CmbAlmacen.Location = New System.Drawing.Point(79, 65)
        Me.CmbAlmacen.Name = "CmbAlmacen"
        Me.CmbAlmacen.Size = New System.Drawing.Size(116, 21)
        Me.CmbAlmacen.TabIndex = 15
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 62)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 13)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Almacen :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 91)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 13)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Vendedor :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 13)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Mes :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Año :"
        '
        'CmbMes
        '
        Me.CmbMes.FormattingEnabled = True
        Me.CmbMes.Items.AddRange(New Object() {"Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"})
        Me.CmbMes.Location = New System.Drawing.Point(79, 38)
        Me.CmbMes.Name = "CmbMes"
        Me.CmbMes.Size = New System.Drawing.Size(100, 21)
        Me.CmbMes.TabIndex = 10
        '
        'MskAnio
        '
        Me.MskAnio.Location = New System.Drawing.Point(79, 14)
        Me.MskAnio.Mask = "0000"
        Me.MskAnio.Name = "MskAnio"
        Me.MskAnio.Size = New System.Drawing.Size(44, 20)
        Me.MskAnio.TabIndex = 9
        '
        'DGV_Consolidado
        '
        Me.DGV_Consolidado.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGV_Consolidado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_Consolidado.Location = New System.Drawing.Point(290, 8)
        Me.DGV_Consolidado.Name = "DGV_Consolidado"
        Me.DGV_Consolidado.Size = New System.Drawing.Size(480, 162)
        Me.DGV_Consolidado.TabIndex = 11
        '
        'DGV_Detalle
        '
        Me.DGV_Detalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGV_Detalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_Detalle.Location = New System.Drawing.Point(8, 10)
        Me.DGV_Detalle.Name = "DGV_Detalle"
        Me.DGV_Detalle.Size = New System.Drawing.Size(762, 200)
        Me.DGV_Detalle.TabIndex = 12
        '
        'toolStrip1
        '
        Me.toolStrip1.ImageScalingSize = New System.Drawing.Size(50, 50)
        Me.toolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tSB_Save, Me.tSB_New, Me.tSBOpen, Me.tSBExcel, Me.tSBConfig, Me.tSBExit, Me.tSLDetalles})
        Me.toolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.toolStrip1.Name = "toolStrip1"
        Me.toolStrip1.Size = New System.Drawing.Size(797, 57)
        Me.toolStrip1.TabIndex = 13
        Me.toolStrip1.Text = "toolStrip1"
        '
        'tSB_Save
        '
        Me.tSB_Save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tSB_Save.Image = CType(resources.GetObject("tSB_Save.Image"), System.Drawing.Image)
        Me.tSB_Save.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tSB_Save.Name = "tSB_Save"
        Me.tSB_Save.Size = New System.Drawing.Size(54, 54)
        Me.tSB_Save.Text = "tSB_Save"
        Me.tSB_Save.ToolTipText = "Guardar Comision"
        '
        'tSB_New
        '
        Me.tSB_New.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tSB_New.Image = CType(resources.GetObject("tSB_New.Image"), System.Drawing.Image)
        Me.tSB_New.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tSB_New.Name = "tSB_New"
        Me.tSB_New.Size = New System.Drawing.Size(54, 54)
        Me.tSB_New.ToolTipText = "Nuevo Comision"
        '
        'tSBOpen
        '
        Me.tSBOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tSBOpen.Image = CType(resources.GetObject("tSBOpen.Image"), System.Drawing.Image)
        Me.tSBOpen.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tSBOpen.Name = "tSBOpen"
        Me.tSBOpen.Size = New System.Drawing.Size(54, 54)
        Me.tSBOpen.ToolTipText = "Abrir Comision"
        '
        'tSBExcel
        '
        Me.tSBExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tSBExcel.Image = CType(resources.GetObject("tSBExcel.Image"), System.Drawing.Image)
        Me.tSBExcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tSBExcel.Name = "tSBExcel"
        Me.tSBExcel.Size = New System.Drawing.Size(54, 54)
        Me.tSBExcel.ToolTipText = "Exportar EXCEL"
        '
        'tSBConfig
        '
        Me.tSBConfig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tSBConfig.Image = CType(resources.GetObject("tSBConfig.Image"), System.Drawing.Image)
        Me.tSBConfig.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tSBConfig.Name = "tSBConfig"
        Me.tSBConfig.Size = New System.Drawing.Size(54, 54)
        Me.tSBConfig.ToolTipText = "Configuracion"
        '
        'tSBExit
        '
        Me.tSBExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tSBExit.Image = CType(resources.GetObject("tSBExit.Image"), System.Drawing.Image)
        Me.tSBExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tSBExit.Name = "tSBExit"
        Me.tSBExit.Size = New System.Drawing.Size(54, 54)
        Me.tSBExit.ToolTipText = "Salir"
        '
        'tSLDetalles
        '
        Me.tSLDetalles.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tSLDetalles.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tSLDetalles.Name = "tSLDetalles"
        Me.tSLDetalles.Size = New System.Drawing.Size(0, 54)
        '
        'FrmComision
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(797, 476)
        Me.Controls.Add(Me.toolStrip1)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "FrmComision"
        Me.Text = "Sistema Generacion Comisiones de Ventas"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.PnlDatosGenerales.ResumeLayout(False)
        Me.PnlDatosGenerales.PerformLayout()
        CType(Me.DGV_Consolidado, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV_Detalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.toolStrip1.ResumeLayout(False)
        Me.toolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents PnlDatosGenerales As Panel
    Friend WithEvents CmbAlmacen As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents CmbMes As ComboBox
    Friend WithEvents MskAnio As MaskedTextBox
    Friend WithEvents DGV_Consolidado As DataGridView
    Friend WithEvents DGV_Detalle As DataGridView
    Friend WithEvents btnProcesar As Button
    Private WithEvents toolStrip1 As ToolStrip
    Private WithEvents tSB_Save As ToolStripButton
    Private WithEvents tSB_New As ToolStripButton
    Private WithEvents tSBOpen As ToolStripButton
    Private WithEvents tSBExcel As ToolStripButton
    Private WithEvents tSBConfig As ToolStripButton
    Private WithEvents tSBExit As ToolStripButton
    Private WithEvents tSLDetalles As ToolStripLabel
    Friend WithEvents LstVendedor As CheckedListBox
    Private WithEvents saveFileDialog1 As SaveFileDialog
End Class
