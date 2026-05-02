using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAPbobsCOM;
using SAPbouiCOM;
using System.Globalization;
using System.Threading;

namespace IMRAddonV2._1
{
    public class NombreCamposMatrixCxC
    {
        public string CardCode { get; set; }
        public string CardName { get; set; }
        public string DocEntryFactura { get; set; }
        public string DocNumFactura { get; set; }
        public string fechaFactura { get; set; }
        public string DocNumLetra { get; set; }
        public string fechaVencLetra { get; set; }
        public string fechaVencLetraTotal { get; set; }
        public string valorLetra { get; set; }
        public string fechaCobroLetra { get; set; }
	    //public string tipoDoc { get; set; }
        public string porcAplicado { get; set; }
        public string valorCalculado { get; set; }
        public string statusCalculo { get; set; }
        public string motivoStatus { get; set; }
        public string ComentarioAprob { get; set; }
        public string usuarioAprob { get; set; }
         public string usuarioAprob2 { get; set; }
        public string fechaAprob { get; set; }

        public string valorServicio { get; set; }
        public string valorNC { get; set; }
        public string valorIVA { get; set; }
        public string valorBaseCalculo { get; set; }
    }
    public class NombreCamposComision
    { 
        public string DocEntry { get; set; } // 18/Ene/2026 --controlar actualizacion de registros
        public string anio { get; set; }
        public string mes { get; set; }
        public string vendedor { get; set; }
        public string metaId  { get; set; }
        public string valorMeta { get; set; }
        public string valorMeta2 { get; set; }  //version 2.0
        public string valorBaseCalculoCxC { get; set; }
        public string porcPagadoCxC { get; set; }
        public string valorPagadoCxC { get; set; }
        public string valorBaseCalculoFact { get; set; }
        public string porcPagadoFact { get; set; }
        public string porcPagadoFactInf { get; set; }
        public string porcPagadoFactInt { get; set; }  //Version 2.0
        public string porcPagadoFactSup { get; set; }

        public string valorPagadoFact { get; set; }
        public string valorPagadoFactRecalc { get; set; }     
        public string valorSuperMeta { get; set; }
        public string valorFacturacionAcumSMeta { get; set; }
      

        public string matrixCxC { get; set; }
        public string matrixFact { get; set; }
        public string btnProc { get; set; }
        public string btnPrint { get; set; }
        public string ValorViaticos { get; set; }
        public string ValorOtros { get; set; }
        public string ValRetFuente { get; set; }
        public string ValRetIVA { get; set; }

    }

    public class NombreCamposMatrixFact
    {
        public string CardCode { get; set; }
        public string CardName { get; set; }
        public string DocNumFactura { get; set; }
        public string DocEntryFactura { get; set; }
        public string fechaFactura { get; set; }
        public string valorFactura { get; set; }
        public string valorServicio { get; set; }
        public string valorNC { get; set; }
        public string valorIVA { get; set; }
        public string valorBaseCalculo { get; set; }
    }
        class Validaciones
    {
        private string idFrmComisiones = "60004";//UDO_FT_CRP_COMI
        private string idFrmMeta = "UDO_FT_CRP_META";
        //private string idFrmComisionMatrix = "0_U_G";
        //private string idFrmComisionMatrixFact = "1_U_G";
   
        public NombreCamposMatrixCxC oNombresMatrixCxC = new NombreCamposMatrixCxC();
        public NombreCamposMatrixFact oNombresMatrixFact = new NombreCamposMatrixFact();
        public NombreCamposComision oNombreCamposComision = new NombreCamposComision();
        

        //private SAPbobsCOM.Company company;
        //private SAPbouiCOM.Application MyAplication;
            private SAPbouiCOM.Form oForm; //creo una variable para que manipule el formulario y sus controles
        int userId = 0;
        string userCode = "";

        public Validaciones()
        {
            Conexion.open();
            Conexion.SapAplication.ItemEvent += new _IApplicationEvents_ItemEventEventHandler(SBO_Application_ItemEvent); //manda a revisar los eventos de form
            Conexion.SapAplication.AppEvent += new _IApplicationEvents_AppEventEventHandler(SBO_Application_AppEvent); // capturo los eventos tipo Application
            Conexion.SapAplication.FormDataEvent += new _IApplicationEvents_FormDataEventEventHandler(SBO_Application_FormDataEvent);            
            Conexion.SapAplication.MenuEvent += new SAPbouiCOM._IApplicationEvents_MenuEventEventHandler(SBO_Application_MenuEvent);

        }
        public void SBO_Application_ItemEvent(string FormUID, ref ItemEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            try
            {                 
         #region CargarFormulario
                if (pVal.FormTypeEx == idFrmComisiones && pVal.EventType == BoEventTypes.et_FORM_LOAD && pVal.BeforeAction == false)
                {
                    //se llenan os nombres de las columnas del grid(matrix) de cobranzas
                    oNombresMatrixCxC.CardCode = "C_0_1";
                    oNombresMatrixCxC.CardName = "C_0_2";
                    oNombresMatrixCxC.DocEntryFactura = "C_0_4";
                    oNombresMatrixCxC.DocNumFactura = "C_0_3";
                    oNombresMatrixCxC.fechaFactura = "C_0_5";
                    oNombresMatrixCxC.DocNumLetra = "C_0_6";
                    oNombresMatrixCxC.fechaVencLetra = "C_0_7";
                    oNombresMatrixCxC.fechaVencLetraTotal = "C_0_8";
                    oNombresMatrixCxC.valorLetra = "C_0_10";
                    oNombresMatrixCxC.fechaCobroLetra = "C_0_9";
                    oNombresMatrixCxC.valorServicio = "C_0_11";
                    oNombresMatrixCxC.valorNC = "C_0_12";
                    oNombresMatrixCxC.valorIVA = "C_0_13";
                    oNombresMatrixCxC.valorBaseCalculo = "C_0_14";
                    oNombresMatrixCxC.porcAplicado = "C_0_15";
                    oNombresMatrixCxC.valorCalculado = "C_0_16";
                    oNombresMatrixCxC.statusCalculo = "C_0_17";
                    oNombresMatrixCxC.motivoStatus = "C_0_18";
                    oNombresMatrixCxC.ComentarioAprob = "C_0_19";
                    oNombresMatrixCxC.fechaAprob = "C_0_20";
                    oNombresMatrixCxC.usuarioAprob = "C_0_21";
                    oNombresMatrixCxC.usuarioAprob2 = "C_0_22"; //creyes 14/06/2025
                    //llena los campos de la matrix de facturas
                    oNombresMatrixFact.CardCode = "C_1_1";
                    oNombresMatrixFact.CardName = "C_1_2";
                    oNombresMatrixFact.DocNumFactura = "C_1_4";
                    oNombresMatrixFact.DocEntryFactura = "C_1_3";
                    oNombresMatrixFact.fechaFactura = "C_1_5";
                    oNombresMatrixFact.valorFactura = "C_1_6";
                    oNombresMatrixFact.valorIVA = "C_1_9";
                    oNombresMatrixFact.valorNC = "C_1_8";
                    oNombresMatrixFact.valorServicio = "C_1_7";
                    oNombresMatrixFact.valorBaseCalculo = "C_1_10";
                    //llena los campos de la pantalla de comisiones
                    oNombreCamposComision.DocEntry = "0_U_E";//16/Ene/2026 controlar modificacion de registros
                    oNombreCamposComision.anio = "21_U_E";
                    oNombreCamposComision.mes = "22_U_Cb";
                    oNombreCamposComision.vendedor = "20_U_E";
                    oNombreCamposComision.metaId = "23_U_E";
                    oNombreCamposComision.valorBaseCalculoCxC = "31_U_E";
                    oNombreCamposComision.porcPagadoCxC = "25_U_E";
                    oNombreCamposComision.valorPagadoCxC = "28_U_E";

                    oNombreCamposComision.valorMeta = "24_U_E";
                    oNombreCamposComision.valorMeta2 = "43_U_E";        //version 2.0 **** 40_U_E
                    oNombreCamposComision.porcPagadoFactInf = "26_U_E";
                    oNombreCamposComision.porcPagadoFactInt = "27_U_E"; //version 2.0;
                    oNombreCamposComision.porcPagadoFactSup = "44_U_E"; // ***** 62
                    oNombreCamposComision.valorBaseCalculoFact = "32_U_E";
                    oNombreCamposComision.porcPagadoFact = "35_U_E";
                    oNombreCamposComision.valorPagadoFact = "29_U_E";
                  

                    oNombreCamposComision.valorSuperMeta = "33_U_E";
                    oNombreCamposComision.valorFacturacionAcumSMeta = "34_U_E";
                    oNombreCamposComision.valorPagadoFactRecalc = "30_U_E";
                    oNombreCamposComision.ValorViaticos = "36_U_E";
                    oNombreCamposComision.ValorOtros = "41_U_E";
                    oNombreCamposComision.ValRetFuente = "38_U_E";
                    oNombreCamposComision.ValRetIVA = "39_U_E";


                    oNombreCamposComision.matrixCxC = "0_U_G";
                    oNombreCamposComision.matrixFact = "1_U_G";
                    oNombreCamposComision.btnProc = "btnProc";
                           
                    
                    oNombreCamposComision.btnPrint = "btnPrint";
                                       
                  

                    oForm = Conexion.SapAplication.Forms.Item(FormUID); //asigno a la variable el formulario activo       
                    userId = Conexion.oCompany.UserSignature;

                    //------creyes 14/06/2025
                    SAPbobsCOM.Recordset oRecordset = (SAPbobsCOM.Recordset)Conexion.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                    string query = $"SELECT USER_CODE FROM OUSR WHERE INTERNAL_K = {userId}";
                    oRecordset.DoQuery(query);

                    //string userCode = "";
                    if (!oRecordset.EoF)
                    {
                        userCode = oRecordset.Fields.Item("USER_CODE").Value.ToString(); // Esto te dará "jperez" u otro ID de dominio
                    }
                    //-----creyes 14/06/2025

                }
                #endregion

                #region Eventos GEnerales 
                //#region "Evaluar cambio status de incluido/aprobado y recalculo de totales"
                //// evento para recorrer la matrix y calcular el total de la columna de valorBaseCalculo cuando cambia el status de calculo
                //if (pVal.FormTypeEx == idFrmComisiones && pVal.ItemUID ==  oNombreCamposComision.matrixCxC && pVal.ColUID == oNombresMatrixCxC.statusCalculo  &&
                //    pVal.EventType == SAPbouiCOM.BoEventTypes.et_VALIDATE && !pVal.BeforeAction)
                //{
                //    SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item(oNombreCamposComision.matrixCxC).Specific;
                //    CalculaComisionCxC(oForm, oMatrix);
                //}
                //#endregion

                #region "evento change del campo MetaId / Cargar InfoMeta"
                if (pVal.FormTypeEx == idFrmComisiones && 
                   (pVal.ItemUID == oNombreCamposComision.metaId || pVal.ItemUID == oNombreCamposComision.anio || pVal.ItemUID == oNombreCamposComision.mes || pVal.ItemUID == oNombreCamposComision.vendedor) && 
                    pVal.EventType == SAPbouiCOM.BoEventTypes.et_VALIDATE && pVal.Before_Action == false)
                {
                    cargarInfoMeta(oForm);
                    

                }
                #endregion

                #region "Evaluar carga de formulario para adicion o busqueda "
                if (pVal.FormTypeEx == idFrmComisiones && pVal.EventType == BoEventTypes.et_FORM_ACTIVATE && pVal.BeforeAction == false)
                {
                    SAPbouiCOM.Form oForm = Conexion.SapAplication.Forms.Item(FormUID);
                    
                    if (oForm.Mode == BoFormMode.fm_ADD_MODE || oForm.Mode == BoFormMode.fm_FIND_MODE)
                    {
                        BloquearCamposCabecera(oForm, false);                        
                    }
                    else
                    {
                       
                        BloquearCamposCabecera(oForm, true);
                    }
                }
                #endregion

                #region "calculo de valoraPagarFact"
                if (pVal.FormTypeEx == idFrmComisiones && pVal.ItemUID == oNombreCamposComision.valorBaseCalculoFact && 
                    pVal.EventType == SAPbouiCOM.BoEventTypes.et_VALIDATE && !pVal.BeforeAction)

                {
                    CalculaComisionFact(oForm);
                        //probar esta validacion puse en comenteatio tofod el codigo de abajo
                    //double valorBaseCalculo = 0;
                    //double porcentajeCalculo = 0;

                    //// Obtén el valor base de cálculo
                    //string baseCalculoStr = ((SAPbouiCOM.EditText)oForm.Items.Item(oNombreCamposComision.valorBaseCalculoFact).Specific).Value; // ID del campo Base de Cálculo
                    //double parsedBase = 0;
                    //if (!string.IsNullOrEmpty(baseCalculoStr) && double.TryParse(baseCalculoStr, out  parsedBase))
                    //{
                    //    valorBaseCalculo = parsedBase;
                    //}

                    //// Obtén el porcentaje de cálculo
                    //string porcentajeStr = ((SAPbouiCOM.EditText)oForm.Items.Item(oNombreCamposComision.porcPagadoFact).Specific).Value; // ID del campo % de Cálculo
                    //double parsedPorcentaje = 0;
                    //if (!string.IsNullOrEmpty(porcentajeStr) && double.TryParse(porcentajeStr, out parsedPorcentaje))
                    //{
                    //    porcentajeCalculo = parsedPorcentaje;
                    //}

                    //// Calcula el valor calculado
                    //double valorCalculado = valorBaseCalculo * (porcentajeCalculo / 100);
                    
                    //((SAPbouiCOM.EditText)oForm.Items.Item(oNombreCamposComision.valorPagadoFact).Specific).Value = valorCalculado.ToString("F2"); // ID del campo Valor Calculado
                }
                #endregion
                #region "Aprobacion de lineas EXCLUIDAS y calculo de la comision"
                if (pVal.FormTypeEx == idFrmComisiones && pVal.ItemUID == oNombreCamposComision.matrixCxC  && pVal.ColUID == oNombresMatrixCxC.statusCalculo  && pVal.EventType == BoEventTypes.et_VALIDATE && pVal.Before_Action == false)
                {
                    oForm.Freeze(false);
                    SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item(oNombreCamposComision.matrixCxC).Specific;                    
                    int row = pVal.Row;

                    SAPbouiCOM.EditText percentageAppliedColumn = (SAPbouiCOM.EditText)oMatrix.Columns.Item(oNombresMatrixCxC.porcAplicado).Cells.Item(row).Specific;
                    SAPbouiCOM.EditText baseValueColumn = (SAPbouiCOM.EditText)oMatrix.Columns.Item(oNombresMatrixCxC.valorBaseCalculo).Cells.Item(row).Specific;
                    SAPbouiCOM.EditText commissionColumn = (SAPbouiCOM.EditText)oMatrix.Columns.Item(oNombresMatrixCxC.valorCalculado).Cells.Item(row).Specific;

                    decimal percentageApplied = string.IsNullOrEmpty(percentageAppliedColumn.Value) ? 0 : Convert.ToDecimal(percentageAppliedColumn.Value);
                    decimal baseValue = string.IsNullOrEmpty(baseValueColumn.Value) ? 0 : Convert.ToDecimal(baseValueColumn.Value);
                    decimal commission = (percentageApplied / 100) * baseValue;
                    //commissionColumn.Value = commission.ToString("F2");
                    

                    string status = oMatrix.Columns.Item(oNombresMatrixCxC.statusCalculo).Cells.Item(row).Specific.Value;
                    string motivoStatus = oMatrix.Columns.Item(oNombresMatrixCxC.motivoStatus).Cells.Item(row).Specific.Value;
                    motivoStatus = motivoStatus.Substring(0, 2).ToUpper();
                    string idUserMod = oMatrix.Columns.Item(oNombresMatrixCxC.usuarioAprob).Cells.Item(row).Specific.Value;
                    string ComentarioAprob = oMatrix.Columns.Item(oNombresMatrixCxC.ComentarioAprob).Cells.Item(row).Specific.Value;

                    if ((!string.IsNullOrEmpty(status) && (status == "APR" || status == "IN")))//&& motivoStatus == "NO"
                    {
                        ((EditText)oMatrix.Columns.Item(oNombresMatrixCxC.valorCalculado).Cells.Item(row).Specific).Value = commission.ToString("F2", CultureInfo.CurrentCulture);
                        if (idUserMod == "")
                        {
                            ((EditText)oMatrix.Columns.Item(oNombresMatrixCxC.usuarioAprob).Cells.Item(row).Specific).Value = userId.ToString();
                            ((EditText)oMatrix.Columns.Item(oNombresMatrixCxC.usuarioAprob2).Cells.Item(row).Specific).Value = userCode.ToString();//creyes 14/06/2025
                            ((EditText)oMatrix.Columns.Item(oNombresMatrixCxC.fechaAprob).Cells.Item(row).Specific).Value = System.DateTime.Today.ToString("yyyyMMdd");
                        }
                    }
                    if ((!string.IsNullOrEmpty(status) && (status == "EX" )) )
                    {
                        commission = 0;
                        ((EditText)oMatrix.Columns.Item(oNombresMatrixCxC.valorCalculado).Cells.Item(row).Specific).Value = commission.ToString("F2", CultureInfo.CurrentCulture);
                        if (motivoStatus != "NO")
                        {
                            if (idUserMod == "")
                            {
                                ((EditText)oMatrix.Columns.Item(oNombresMatrixCxC.usuarioAprob).Cells.Item(row).Specific).Value = userId.ToString();
                                ((EditText)oMatrix.Columns.Item(oNombresMatrixCxC.usuarioAprob2).Cells.Item(row).Specific).Value = userCode.ToString();//creyes 14/06/2025
                                ((EditText)oMatrix.Columns.Item(oNombresMatrixCxC.fechaAprob).Cells.Item(row).Specific).Value = System.DateTime.Today.ToString("yyyyMMdd");
                            }
                        }
                    }
                    
                    CalculaComisionCxC(oForm, oMatrix);

                    oMatrix.AutoResizeColumns();   
                   // oForm.Update(); OJO esto funciona y forza la actualizacion pero hace q las siguientes interacciones en pantalla no sean comodas

                }
                #endregion
                if (pVal.FormTypeEx == idFrmComisiones && pVal.EventType == BoEventTypes.et_ITEM_PRESSED && pVal.ItemUID == oNombreCamposComision.btnPrint && pVal.ActionSuccess)
                {
                    //string DocEntry = null;
                    string Vendedor = null;
                    string anio = null;
                    string mes = null;
                    oForm = Conexion.SapAplication.Forms.ActiveForm;
                    //ASIGNO VALOR DEL DOCENTRY AL CAMPO
                    //EditText txtDocEntry = (SAPbouiCOM.EditText)oForm.Items.Item("0_U_E").Specific;
                    //DocEntry = txtDocEntry.Value.ToString();

                    //ASIGNO VALOR DEL VENDEDOR AL CAMPO
                    EditText TxtVendedor = (SAPbouiCOM.EditText)oForm.Items.Item("20_U_E").Specific;
                    Vendedor = TxtVendedor.Value.ToString();

                    //ASIGNO VALOR DEL año AL CAMPO
                    EditText Txtanio = (SAPbouiCOM.EditText)oForm.Items.Item("21_U_E").Specific;
                    anio = Txtanio.Value.ToString();

                    //ASIGNO VALOR DEL mes AL CAMPO
                    ComboBox cmbMes = (SAPbouiCOM.ComboBox)oForm.Items.Item("22_U_Cb").Specific;
                    mes = cmbMes.Value.ToString();

                    //CargarLayout();
                    Conexion.SapAplication.ActivateMenuItem("8e412f80f54c4c2794c32b1464e2cd2e"); //actualizado 29-12-2025
                    oForm = Conexion.SapAplication.Forms.ActiveForm;
                    string FormUID1 = oForm.UniqueID.ToString();
                    //lleno el combo del año
                    SAPbouiCOM.ComboBox cmbyear = (SAPbouiCOM.ComboBox)oForm.Items.Item("1000003").Specific;
                    cmbyear.Select(anio, BoSearchKey.psk_ByValue);
                    //lleno el combo del mes
                    SAPbouiCOM.ComboBox cmbmes = (SAPbouiCOM.ComboBox)oForm.Items.Item("1000009").Specific;
                    cmbmes.Select(mes, BoSearchKey.psk_ByValue);

                    //lleno el combo del vendedor
                    SAPbouiCOM.ComboBox cmbven = (SAPbouiCOM.ComboBox)oForm.Items.Item("1000015").Specific;
                    cmbven.Select(Vendedor, BoSearchKey.psk_ByValue);

                    oForm.Items.Item("1").Click();
                    //Conexion.SapAplication.Forms.Item(FormUID1).Visible = false;

                                    // Mostrar el formulario como diálogo (bloquea la ejecución hasta que se cierre)
                    //reporteForm.ShowDialog();
                }
                #endregion

                #region "click boton procesar"
                if (pVal.FormTypeEx == idFrmComisiones && pVal.EventType == BoEventTypes.et_ITEM_PRESSED && pVal.ItemUID == oNombreCamposComision.btnProc && pVal.ActionSuccess)               
                {
                    
                    oForm = Conexion.SapAplication.Forms.Item(FormUID);

                    SAPbouiCOM.Item itemVendedor = oForm.Items.Item(oNombreCamposComision.vendedor); //aca debe ser el id del vendedor
                    SAPbouiCOM.EditText textVendedor = (SAPbouiCOM.EditText)itemVendedor.Specific;
                    string varVendedor = textVendedor.String;
                    if (varVendedor == "")
                    {
                        Conexion.SapAplication.StatusBar.SetText("Ingrese valor para el campo Vendedor.", BoMessageTime.bmt_Short, BoStatusBarMessageType.smt_Success);
                        BubbleEvent = false;
                        return;
                    }

                    SAPbouiCOM.Item itemAnio = oForm.Items.Item(oNombreCamposComision.anio); 
                    SAPbouiCOM.EditText textAnio = (SAPbouiCOM.EditText)itemAnio.Specific;
                    string varAnio = textAnio.String;
                    if (varAnio == "")
                    {
                        Conexion.SapAplication.StatusBar.SetText("Ingrese valor para el campo Anio.", BoMessageTime.bmt_Short, BoStatusBarMessageType.smt_Success);
                        BubbleEvent = false;
                        return;
                    }

                    SAPbouiCOM.Item itemMes = oForm.Items.Item(oNombreCamposComision.mes); //aca debe ser el id del mes
                    SAPbouiCOM.ComboBox textMes = (SAPbouiCOM.ComboBox)itemMes.Specific;
                    string varMes = textMes.Value;
                    if (varMes == "")
                    {
                        Conexion.SapAplication.StatusBar.SetText("Ingrese valor para el campo Mes.", BoMessageTime.bmt_Short, BoStatusBarMessageType.smt_Success);
                        BubbleEvent = false;
                        return;
                    }
                    CambiarCursor(true);
                    #region llenar matrix CxC
                    //datos cobranzas
                    //recursividad para llenar informacion periodo anterior
                    // Cálculo del mes anterior
                    int intAnio = int.Parse(varAnio);
                    int intMes = int.Parse(varMes);
                    DateTime fechaActual = new DateTime(intAnio, intMes, 1);
                    DateTime fechaAnterior = fechaActual.AddMonths(-1);

                    string anioAnt = fechaAnterior.Year.ToString();
                    string mesAnt = fechaAnterior.Month.ToString("D2");
                    
                    SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item(oNombreCamposComision.matrixCxC).Specific;                    

                    SAPbouiCOM.DBDataSource oDBDataSource = oForm.DataSources.DBDataSources.Item("@CRP_COMICXC");
                    oDBDataSource.Clear();
              
                    string[] anios = { varAnio, anioAnt };// anio actual, anio anterior
                    string[] meses = { varMes, mesAnt }; //mes actual. mes anterior
                    int[] reprocesoFlags = { 0, 1 };//proceso original, reproceso
                    DateTime fechaInicioProceso = new DateTime(2025, 11, 1); // Ajusta esta fecha según tu necesidad                
                    int limite = fechaActual <= fechaInicioProceso ? 1 : 2; //ependiendo de si es la fecha de inicio de todo el proceso se recorre 1 o 2 veces el for

                    int lineaId = 1;

                    for (int i = 0; i < limite; i++)
                    {
                        SAPbobsCOM.Recordset dsComision = Conexion.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                        string MyQuery = $"CALL CRP_CALCULOCOMISIONCxC ('{varVendedor}', '{anios[i]}', '{meses[i]}', {reprocesoFlags[i]})";
                        //string MyQuery = "CALL CRP_CALCULOCOMISIONCxC ('" + varVendedor + "', '" + varAnio + "', '" + varMes + "')";
                        dsComision.DoQuery(MyQuery);

                        while (!dsComision.EoF)
                        {
                            // Agrega un nuevo registro al DBDataSource
                            oDBDataSource.InsertRecord(oDBDataSource.Size);

                            oDBDataSource.SetValue("LineId", oDBDataSource.Size - 1, lineaId.ToString());
                            lineaId += 1; 

                            oDBDataSource.SetValue("U_CardCode", oDBDataSource.Size - 1, dsComision.Fields.Item("CardCode").Value.ToString());
                            oDBDataSource.SetValue("U_CardName", oDBDataSource.Size - 1, dsComision.Fields.Item("CardName").Value.ToString());
                            oDBDataSource.SetValue("U_DocNum", oDBDataSource.Size - 1, dsComision.Fields.Item("Folio").Value.ToString()); //-- 20250125 - Section solicita reemplazar DocNumFactura por el Folio
                            oDBDataSource.SetValue("U_DocEntry", oDBDataSource.Size - 1, dsComision.Fields.Item("DocEntryFactura").Value.ToString());
                            //oDBDataSource.SetValue("U_fechaFactura", oDBDataSource.Size - 1, Convert.ToDateTime(dsComision.Fields.Item("fechaFactura").Value.ToString()));
                            var fechaFactura = dsComision.Fields.Item("fechaFactura").Value; // Cambia por el nombre real del campo de fecha en el Recordset
                            if (fechaFactura != null)
                            {
                                DateTime parsedDate = Convert.ToDateTime(fechaFactura);
                                string sapDate = parsedDate.ToString("yyyyMMdd"); // Formato compatible con SAP
                                oDBDataSource.SetValue("U_DocDate", oDBDataSource.Size - 1, sapDate);
                            }
                            else
                            {
                                oDBDataSource.SetValue("U_DocDate", oDBDataSource.Size - 1, ""); // Fecha vacía
                            }

                            oDBDataSource.SetValue("U_DocNumL", oDBDataSource.Size - 1, dsComision.Fields.Item("DocNumLetra").Value.ToString());
                            //oDBDataSource.SetValue("U_fechaVencLetra", oDBDataSource.Size - 1, Convert.ToDateTime(dsComision.Fields.Item("fechaVencLetra").Value.ToString("dd/MM/yyyy")));
                            var U_fechaVencLetra = dsComision.Fields.Item("fechaVencLetra").Value; // Cambia por el nombre real del campo de fecha en el Recordset
                            if (U_fechaVencLetra != null)
                            {
                                DateTime parsedDate = Convert.ToDateTime(U_fechaVencLetra);
                                string sapDate = parsedDate.ToString("yyyyMMdd"); // Formato compatible con SAP
                                oDBDataSource.SetValue("U_DueDateL", oDBDataSource.Size - 1, sapDate);
                            }
                            else
                            {
                                oDBDataSource.SetValue("U_DueDateL", oDBDataSource.Size - 1, ""); // Fecha vacía
                            }

                            //oDBDataSource.SetValue("U_fechaVencLetraTotal", oDBDataSource.Size - 1, Convert.ToDateTime(dsComision.Fields.Item("fechaVencLetraTotal").Value.ToString("dd/MM/yyyy")));
                            var U_fechaVencLetraTotal = dsComision.Fields.Item("fechaVencLetraTotal").Value; // Cambia por el nombre real del campo de fecha en el Recordset
                            if (U_fechaVencLetraTotal != null)
                            {
                                DateTime parsedDate = Convert.ToDateTime(U_fechaVencLetraTotal);
                                string sapDate = parsedDate.ToString("yyyyMMdd"); // Formato compatible con SAP
                                oDBDataSource.SetValue("U_DueDateL2", oDBDataSource.Size - 1, sapDate);
                            }
                            else
                            {
                                oDBDataSource.SetValue("U_DueDateL2", oDBDataSource.Size - 1, ""); // Fecha vacía
                            }

                            oDBDataSource.SetValue("U_ValorLet", oDBDataSource.Size - 1, Convert.ToDecimal(dsComision.Fields.Item("valorLetra").Value.ToString()));
                            //oDBDataSource.SetValue("U_fechaCobroLetra", oDBDataSource.Size - 1, Convert.ToDateTime(dsComision.Fields.Item("fechaCobroLetra").Value.ToString("dd/MM/yyyy")));
                            var U_fechaCobroLetra = dsComision.Fields.Item("fechaCobroLetra").Value; // Cambia por el nombre real del campo de fecha en el Recordset
                            if (U_fechaCobroLetra != null)
                            {
                                DateTime parsedDate = Convert.ToDateTime(U_fechaCobroLetra);
                                string sapDate = parsedDate.ToString("yyyyMMdd"); // Formato compatible con SAP
                                oDBDataSource.SetValue("U_FechCobL", oDBDataSource.Size - 1, sapDate);
                            }
                            else
                            {
                                oDBDataSource.SetValue("U_FechCobL", oDBDataSource.Size - 1, ""); // Fecha vacía
                            }
                            oDBDataSource.SetValue("U_ValServ", oDBDataSource.Size - 1, Convert.ToDecimal(dsComision.Fields.Item("valorServicio").Value.ToString()));
                            oDBDataSource.SetValue("U_ValNC", oDBDataSource.Size - 1, Convert.ToDecimal(dsComision.Fields.Item("valorNC").Value.ToString()));
                            oDBDataSource.SetValue("U_ValIVA", oDBDataSource.Size - 1, Convert.ToDecimal(dsComision.Fields.Item("valorIVA").Value.ToString()));
                            oDBDataSource.SetValue("U_ValBase", oDBDataSource.Size - 1, Convert.ToDecimal(dsComision.Fields.Item("valorBaseCalculo").Value.ToString()));

                            oDBDataSource.SetValue("U_PorcCom", oDBDataSource.Size - 1, Convert.ToDecimal(dsComision.Fields.Item("porcAplicado").Value.ToString()));
                            oDBDataSource.SetValue("U_ValCom", oDBDataSource.Size - 1, Convert.ToDecimal(dsComision.Fields.Item("valorCalculado").Value.ToString()));
                            oDBDataSource.SetValue("U_Status", oDBDataSource.Size - 1, dsComision.Fields.Item("statusCalculo").Value.ToString());
                            oDBDataSource.SetValue("U_Motivo", oDBDataSource.Size - 1, dsComision.Fields.Item("motivoStatus").Value.ToString());
                            //aqi falta el status del registro apra saber si es del proceso actual o del anterior.--no esta creado en la tabla
                            oDBDataSource.SetValue("U_TProc", oDBDataSource.Size - 1, dsComision.Fields.Item("TipoProceso").Value.ToString());
                            
                            dsComision.MoveNext();
                        }
                    }
                    oMatrix.LoadFromDataSource();
                   // oMatrix.Columns.Item("#").Editable = false;
                   


                    ///recorro el grid y busco el status de la celda y procedo a bloquearlo


                    int rowCount = oMatrix.RowCount;
                   
                    for (int i = 1; i <= rowCount; i++)
                    {                        
                        SAPbouiCOM.ComboBox oComboBox = (SAPbouiCOM.ComboBox)oMatrix.Columns.Item(oNombresMatrixCxC.statusCalculo).Cells.Item(i).Specific;

                        if (oComboBox.Selected != null && oComboBox.Selected.Value == "IN")
                        {
                            oMatrix.CommonSetting.SetCellEditable(i,17, true); //20250125 se habilita siempre la columna estatus         cambiar despues de periodo de estabilizacion a false                                         
                        }
                    }
                    //LlenarNumerosDeFila(oMatrix);
                    CalculaComisionCxC(oForm, oMatrix);
                    #endregion


                    #region LlenarMatrixFact                    
                    decimal valorBaseCalculoFact = 0;
                    //decimal valorBaseCalculoCxC = 0;
                    SAPbobsCOM.Recordset dsComisionFact = Conexion.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                    string MyQueryFact = "CALL CRP_CALCULOCOMISIONFact ('" + varVendedor + "', '" + varAnio + "', '" + varMes + "')";

                    // Ejecutar la consulta
                    dsComisionFact.DoQuery(MyQueryFact);

                    // Procesar los resultados
                    SAPbouiCOM.Matrix oMatrix2 = (SAPbouiCOM.Matrix)oForm.Items.Item(oNombreCamposComision.matrixFact).Specific;
                    
                    SAPbouiCOM.DBDataSource oDBDataSource2 = oForm.DataSources.DBDataSources.Item("@CRP_COMIFACT");
                    oDBDataSource2.Clear();
                    while (!dsComisionFact.EoF)
                    {
                        // Agrega un nuevo registro al DBDataSource
                        oDBDataSource2.InsertRecord(oDBDataSource2.Size);

                        // Llena los campos del DBDataSource con los valores del Recordset
                        oDBDataSource2.SetValue("U_CardCode", oDBDataSource2.Size - 1, dsComisionFact.Fields.Item("CardCode").Value.ToString());
                        oDBDataSource2.SetValue("U_CardName", oDBDataSource2.Size - 1, dsComisionFact.Fields.Item("CardName").Value.ToString());
                        oDBDataSource2.SetValue("U_DocNum", oDBDataSource2.Size - 1,   dsComisionFact.Fields.Item("Folio").Value.ToString());
                        oDBDataSource2.SetValue("U_DocEntry", oDBDataSource2.Size - 1, dsComisionFact.Fields.Item("DocEntryFactura").Value.ToString());
                        //oDBDataSource.SetValue("U_fechaFactura", oDBDataSource.Size - 1, Convert.ToDateTime(dsComision.Fields.Item("fechaFactura").Value.ToString()));
                        var fechaFactura = dsComisionFact.Fields.Item("fechaFactura").Value; // Cambia por el nombre real del campo de fecha en el Recordset
                        if (fechaFactura != null)
                        {
                            DateTime parsedDate = Convert.ToDateTime(fechaFactura);
                            string sapDate = parsedDate.ToString("yyyyMMdd"); // Formato compatible con SAP
                            oDBDataSource2.SetValue("U_DocDate", oDBDataSource2.Size - 1, sapDate);
                        }
                        else
                        {
                            oDBDataSource2.SetValue("U_DocDate", oDBDataSource2.Size - 1, ""); // Fecha vacía
                        }                        
                        oDBDataSource2.SetValue("U_ValorFac", oDBDataSource2.Size - 1, Convert.ToDecimal(dsComisionFact.Fields.Item("valorFactura").Value.ToString()));
                        oDBDataSource2.SetValue("U_ValServ", oDBDataSource2.Size - 1, Convert.ToDecimal(dsComisionFact.Fields.Item("valorServicio").Value.ToString()));
                        oDBDataSource2.SetValue("U_ValNC", oDBDataSource2.Size - 1, Convert.ToDecimal(dsComisionFact.Fields.Item("valorNC").Value.ToString()));
                        oDBDataSource2.SetValue("U_ValIVA", oDBDataSource2.Size - 1, Convert.ToDecimal(dsComisionFact.Fields.Item("valorIVA").Value.ToString()));
                        oDBDataSource2.SetValue("U_ValBase", oDBDataSource2.Size - 1, Convert.ToDecimal(dsComisionFact.Fields.Item("valorBaseCalculo").Value.ToString()));
                        // Avanza al siguiente registro en el Recordset
                        valorBaseCalculoFact += Convert.ToDecimal(dsComisionFact.Fields.Item("valorBaseCalculo").Value);

                        dsComisionFact.MoveNext();
                    }
                    oMatrix2.LoadFromDataSource();
                                     
                    ((SAPbouiCOM.EditText)oForm.Items.Item(oNombreCamposComision.valorBaseCalculoFact).Specific).Value = valorBaseCalculoFact.ToString("F2", CultureInfo.CurrentCulture);                    
                    CalculaComisionFact(oForm);
                    CambiarCursor(false);

                    #endregion
                    
                    BloquearCamposCabecera(oForm, true);
                    Conexion.SapAplication.StatusBar.SetText("Carga de informacion calculo de comisiones", BoMessageTime.bmt_Short, BoStatusBarMessageType.smt_Success);
                    
                }
                #endregion

                #region "validacion Grabacion"
                if (pVal.FormTypeEx == idFrmComisiones && pVal.EventType == BoEventTypes.et_ITEM_PRESSED && pVal.ItemUID == "1" && pVal.BeforeAction == true) //boton grabar antes que se ejecute la logica de sap
                                                                                                                                                              // pVal.BeforeAction==false se ejecuta el codigo de usuario despues de SAP
                                                                                                                                                              // pVal.BeforeAction==true se ejecuta primero el codigo de usuario antes que el de SAP
                                                                                                                                                              // BubbleEvent = false; Detiene la ejecucion de codigo de sap
                {
                    oForm = Conexion.SapAplication.Forms.Item(FormUID);
                    if (oForm.Mode != SAPbouiCOM.BoFormMode.fm_FIND_MODE)
                    {
                        oForm = Conexion.SapAplication.Forms.Item(FormUID);
                        string varDocEntry = ((SAPbouiCOM.EditText)oForm.Items.Item(oNombreCamposComision.DocEntry).Specific).Value;
                        string varMeta = ((SAPbouiCOM.EditText)oForm.Items.Item(oNombreCamposComision.metaId).Specific).Value;
                        string varAnio = ((SAPbouiCOM.EditText)oForm.Items.Item(oNombreCamposComision.anio).Specific).Value;
                        string varMes = ((SAPbouiCOM.ComboBox)oForm.Items.Item(oNombreCamposComision.mes).Specific).Value;
                        string varVendedor = ((SAPbouiCOM.EditText)oForm.Items.Item(oNombreCamposComision.vendedor).Specific).Value;
                        if (oForm.Mode == SAPbouiCOM.BoFormMode.fm_ADD_MODE)
                        {
                            SAPbobsCOM.Recordset dsComision = Conexion.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                            string MyQuery = "select t0.\"DocNum\" from \"@CRP_COMI\" t0 " +
                                            "where t0.\"U_Vendedor\" = '" + varVendedor + "' and t0.\"U_Anio\" = '" + varAnio + "' and t0.\"U_Mes\" = '" + varMes + "' and \"Canceled\" ='N'";
                            dsComision.DoQuery(MyQuery);
                            if (dsComision.RecordCount > 0)
                            {
                                Conexion.SapAplication.StatusBar.SetText("El proceso de comision para este Vendedor/anio/mes ya existe.", BoMessageTime.bmt_Short, BoStatusBarMessageType.smt_Error);
                                BubbleEvent = false;
                                return;
                            }                           
                        }
                        else//modificar
                        {
                            SAPbobsCOM.Recordset dsComisionMod = Conexion.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                            string MyQuery = "select t0.\"DocNum\" from \"@CRP_COMI\" t0 " +
                                            "where t0.\"U_Vendedor\" = '" + varVendedor + "' and t0.\"U_Anio\" = '" + varAnio + "' and t0.\"U_Mes\" = '" + varMes + "' " +
                                            " and \"Status\" ='C' and t0.\"DocEntry\" = " + varDocEntry;//evalua si esta cerrado
                            dsComisionMod.DoQuery(MyQuery);
                            if (dsComisionMod.RecordCount > 0)
                            {
                                Conexion.SapAplication.StatusBar.SetText("El proceso de comision para este Vendedor/anio/mes esta cerrado.", BoMessageTime.bmt_Short, BoStatusBarMessageType.smt_Error);
                                BubbleEvent = false;
                                return;
                            }
                            //10-ene-2026 ajuste para que no permita cambios en modo actualizacion
                            SAPbobsCOM.Recordset dsComision = Conexion.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                            string MyQuery2 = "select t0.\"DocNum\" from \"@CRP_COMI\" t0 " +
                                            "where t0.\"U_Vendedor\" = '" + varVendedor + "' and t0.\"U_Anio\" = '" + varAnio + "' and t0.\"U_Mes\" = '" + varMes + "' " +
                                            "  and t0.\"DocEntry\" <> " + varDocEntry + " and t0.\"Canceled\" ='N'";
                            dsComision.DoQuery(MyQuery2);
                            if (dsComision.RecordCount > 0)
                            {
                                Conexion.SapAplication.StatusBar.SetText("Esta intentando actualizar los datos principales del proceso de comision: Vendedor/anio/mes, y esta combinacion ya existe", BoMessageTime.bmt_Short, BoStatusBarMessageType.smt_Error);
                                BubbleEvent = false;
                                return;
                            }


                        }
                        SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item(oNombreCamposComision.matrixCxC).Specific;
                        if (oMatrix.RowCount == 0)// Validar que haya al menos una fila
                        {
                            Conexion.SapAplication.StatusBar.SetText("El grid debe tener al menos un registro antes de guardar.", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                            BubbleEvent = false;
                            return;
                        }

                        SAPbouiCOM.EditText cellSecuencia = (SAPbouiCOM.EditText)oMatrix.Columns.Item(oNombresMatrixCxC.DocEntryFactura).Cells.Item(1).Specific;
                        if (string.IsNullOrEmpty(cellSecuencia.Value)) // Si la columna clave tiene datos
                        {
                            Conexion.SapAplication.StatusBar.SetText("El grid debe tener al menos un registro antes de guardar.", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                            BubbleEvent = false;
                            return;
                        }

                        SAPbobsCOM.Recordset dsMeta = Conexion.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                        string MyQuery1 = "select t0.\"U_valorMetaMes\", t0.\"U_valorMetaMesMin\", t0.\"U_comisionMetaSup\", t0.\"U_comisionMetaInf\", t0.\"U_comisionMetaInt\", t0.\"U_comisionCobro\", t1.\"U_ValSuperMeta\"" +
                                        " from \"@CRP_VENTAMETA_MES\" t0  join \"@CRP_VENTAMETA\" t1 on t0.\"DocEntry\" = t1.\"DocEntry\"" +
                                        " where t0.\"DocEntry\"   = '" + varMeta + "'" +
                                        "   and t0.\"U_anioMeta\" = '" + varAnio + "'" +
                                        "   and t0.\"U_mesMeta\"  = '" + varMes + "'" +
                                        "   and t1.\"U_idVendedor\" = '" + varVendedor + "'";//Version 2.0
                        dsMeta.DoQuery(MyQuery1);
                        if (dsMeta.RecordCount == 0)
                        {
                            Conexion.SapAplication.StatusBar.SetText("No existe una meta para el vendedor/anio/mes seleccionado.", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                            BubbleEvent = false;
                            return;
                        }
                        double valTotalComiFact = ObtenerValorNumericoCampo(oForm, oNombreCamposComision.valorPagadoFact);
                        if (valTotalComiFact == 0)
                        {
                            Conexion.SapAplication.StatusBar.SetText("No se calculo el valor de comision a pagar .", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                            BubbleEvent = false;
                            return;
                        }
                        //se valida q se llene campos de comentarios                        

                        // Obtener la matriz y su DataSource
                        SAPbouiCOM.Matrix oMatrixCxC = (SAPbouiCOM.Matrix)oForm.Items.Item(oNombreCamposComision.matrixCxC).Specific;

                        oMatrixCxC.FlushToDataSource();
                        SAPbouiCOM.DBDataSource oDBDataSource = oForm.DataSources.DBDataSources.Item("@CRP_COMICXC");

                        // Obtener el número de filas
                        int rowCount = oDBDataSource.Size;

                        //  1️⃣ Recorrer y procesar los datos directamente en el DataSource
                        for (int i = 0; i < rowCount; i++)  // OJO: DataSource usa índice base 0
                        {
                            oDBDataSource.Offset = i;  // Se posiciona en la fila actual

                            string status = oDBDataSource.GetValue("U_Status", i).Trim();
                            string motivoStatus = oDBDataSource.GetValue("U_Motivo", i).Trim();
                            motivoStatus = motivoStatus.Length >= 2 ? motivoStatus.Substring(0, 2).ToUpper() : motivoStatus.ToUpper();
                            string idUserMod = oDBDataSource.GetValue("U_UsrApr", i).Trim();
                            string comentarioAprob = oDBDataSource.GetValue("U_ComenApr", i).Trim();

                            if ((!string.IsNullOrEmpty(status) && (status == "APR" || status == "IN")) && motivoStatus == "NO")
                            {
                                //if (string.IsNullOrEmpty(idUserMod))
                                //{
                                //    oDBDataSource.SetValue(oNombresMatrixCxC.usuarioAprob, i, userId.ToString());
                                //    oDBDataSource.SetValue(oNombresMatrixCxC.fechaAprob, i, System.DateTime.Today.ToString("yyyyMMdd"));
                                //}

                                if (string.IsNullOrEmpty(comentarioAprob))
                                {
                                    Conexion.SapAplication.StatusBar.SetText($"No se definió un comentario para la aprobación manual de la línea {i + 1}",
                                        SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                                    BubbleEvent = false;
                                    return;
                                }
                            }

                            if ((!string.IsNullOrEmpty(status) && (status == "EX" )) && motivoStatus != "NO")
                            {                                
                                if (string.IsNullOrEmpty(comentarioAprob))
                                {
                                    Conexion.SapAplication.StatusBar.SetText($"No se definió un comentario para la exclusion manual de la línea {i + 1}",
                                        SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                                    BubbleEvent = false;
                                    return;
                                }
                            }
                            }



                        //oForm.Freeze(true);
                        //SAPbouiCOM.Matrix oMatrixCxC = (SAPbouiCOM.Matrix)oForm.Items.Item(oNombreCamposComision.matrixCxC).Specific;

                        //for (int i = 1; i <= oMatrixCxC.RowCount; i++)                        
                        //{

                        //    string status = oMatrixCxC.Columns.Item(oNombresMatrixCxC.statusCalculo).Cells.Item(i).Specific.Value;
                        //    string motivoStatus = oMatrixCxC.Columns.Item(oNombresMatrixCxC.motivoStatus).Cells.Item(i).Specific.Value;
                        //    motivoStatus = motivoStatus.Substring(0, 2).ToUpper();
                        //    string idUserMod = oMatrixCxC.Columns.Item(oNombresMatrixCxC.usuarioAprob).Cells.Item(i).Specific.Value;
                        //    string ComentarioAprob = oMatrixCxC.Columns.Item(oNombresMatrixCxC.ComentarioAprob).Cells.Item(i).Specific.Value;

                        //    if ((!string.IsNullOrEmpty(status) && (status == "APR" || status == "IN")) && motivoStatus == "NO" )
                        //    {
                        //        if (idUserMod == "")
                        //        {
                        //            ((EditText)oMatrix.Columns.Item(oNombresMatrixCxC.usuarioAprob).Cells.Item(i).Specific).Value = userId.ToString();
                        //            ((EditText)oMatrix.Columns.Item(oNombresMatrixCxC.fechaAprob).Cells.Item(i).Specific).Value = System.DateTime.Today.ToString("yyyyMMdd");
                        //        }

                        //        if (ComentarioAprob == "")
                        //        {
                        //            Conexion.SapAplication.StatusBar.SetText("No se definio un comentario para la aprobacion manual de la linea " + i, SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                        //            BubbleEvent = false;
                        //            return;
                        //        }
                        //    }
                        //}

                        //oForm.Freeze(false);


                    }
                    BloquearCamposCabecera(oForm, true);
                }
                #endregion

              

                #region "Formulario Meta"
                if (pVal.FormTypeEx == idFrmMeta && pVal.BeforeAction)
                {
                    if (pVal.EventType == BoEventTypes.et_ITEM_PRESSED && pVal.ItemUID == "1")
                    {
                        SAPbouiCOM.Form oFormM = Conexion.SapAplication.Forms.Item(pVal.FormUID);
                        if (oFormM.Mode != SAPbouiCOM.BoFormMode.fm_FIND_MODE)
                        { 
                            
                        SAPbouiCOM.DBDataSource headerDS = oFormM.DataSources.DBDataSources.Item("@CRP_VENTAMETA");
                        SAPbouiCOM.DBDataSource detailDS = oFormM.DataSources.DBDataSources.Item("@CRP_VENTAMETA_MES");
                        string tipoPeriodo = headerDS.GetValue("U_tipoMeta", 0).Trim();

                        int minLineas = 0;
                        if (tipoPeriodo.Equals("MES", StringComparison.OrdinalIgnoreCase))
                        {
                            minLineas = 1;
                        }
                        else if (tipoPeriodo.Equals("BI", StringComparison.OrdinalIgnoreCase))
                        {
                            minLineas = 2;
                        }
                        else if (tipoPeriodo.Equals("TRI", StringComparison.OrdinalIgnoreCase))
                        {
                            minLineas = 3;
                        }
                        else if (tipoPeriodo.Equals("CUA", StringComparison.OrdinalIgnoreCase))
                        {
                            minLineas = 4;
                        }
                        else if (tipoPeriodo.Equals("SEM", StringComparison.OrdinalIgnoreCase))
                        {
                            minLineas = 6;
                        }
                        else if (tipoPeriodo.Equals("ANU", StringComparison.OrdinalIgnoreCase))
                        {
                            minLineas = 12;
                        }
                        else
                        {
                            minLineas = 0;
                        }

                        // Obtener el número actual de líneas de detalle
                        int lineasDetalle = detailDS.Size;

                            // Validar que se cumpla el mínimo
                            if (minLineas > 0 && lineasDetalle != minLineas)
                            {
                                // Mostrar un mensaje de error y cancelar la acción
                                string mensaje = string.Format("El período {0} requiere al menos {1} líneas de detalle. Se encontraron {2}.",
                                    tipoPeriodo, minLineas, lineasDetalle);
                                Conexion.SapAplication.StatusBar.SetText(mensaje, SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                                BubbleEvent = false;
                                return;
                            }
                            //validacion q exista otro registro para el msmo anio/mes/vendedor
                            string vendedor = headerDS.GetValue("U_idVendedor", 0).Trim();
                            string docEntryActual = headerDS.GetValue("DocEntry", 0).Trim();
                            SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oFormM.Items.Item("0_U_G").Specific;
                            oMatrix.FlushToDataSource();

                            // Recorrer cada línea del detalle (DataSource base 0)
                            for (int i = 0; i < detailDS.Size; i++)
                            {
                                // Leer el año y el mes del detalle
                                string anioDetalle = detailDS.GetValue("U_anioMeta", i).Trim();
                                string mesDetalle = detailDS.GetValue("U_mesMeta", i).Trim();
                                if (string.IsNullOrEmpty(anioDetalle))
                                {                                    
                                    Conexion.SapAplication.StatusBar.SetText($"El campo Anio está vacío en la línea {i + 1}.", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                                    BubbleEvent = false;
                                    return;
                                }
                                if (string.IsNullOrEmpty(mesDetalle))
                                {
                                    Conexion.SapAplication.StatusBar.SetText($"El campo Mes está vacío en la línea {i + 1}.", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                                    BubbleEvent = false;
                                    return;
                                }

                                string query = $@"
                                                SELECT COUNT(*) FROM (
                                                    SELECT T0.""DocEntry""
                                                    FROM ""@CRP_VENTAMETA"" T0
                                                    INNER JOIN ""@CRP_VENTAMETA_MES"" T1 
                                                        ON T0.""DocEntry"" = T1.""DocEntry""
                                                    WHERE T0.""U_idVendedor"" = '{vendedor}'
                                                      AND T0.""DocEntry"" <> '{docEntryActual}'
                                                      AND T1.""U_anioMeta"" = '{anioDetalle}'
                                                      AND T1.""U_mesMeta"" = '{mesDetalle}'
                                                ) AS Dup";

                                // Ejecutar la consulta mediante DI API
                                SAPbobsCOM.Recordset rs = (SAPbobsCOM.Recordset)Conexion.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                                rs.DoQuery(query);

                                int count = Convert.ToInt32(rs.Fields.Item(0).Value);
                                if (count > 0)
                                {
                                    // Si se encuentra al menos un registro duplicado, mostrar mensaje y cancelar la validación
                                    Conexion.SapAplication.StatusBar.SetText(
                                        $"Ya existe una configuración para el vendedor {vendedor} en el período {anioDetalle}-{mesDetalle}.",
                                        SAPbouiCOM.BoMessageTime.bmt_Short,
                                        SAPbouiCOM.BoStatusBarMessageType.smt_Error);
                                    BubbleEvent = false;
                                    return;
                                }
                            }

                        }
                    }
                }

                #endregion
            }
            catch (Exception ex)
            {
                Conexion.SapAplication.StatusBar.SetText("Error " + ex.Message, BoMessageTime.bmt_Medium, BoStatusBarMessageType.smt_Error);
                CambiarCursor(false);
            }
        }
        #region "funciones generales"
        private void LlenarNumerosDeFila(SAPbouiCOM.Matrix oMatriz)
        {
            try
            {
                for (int i = 1; i <= oMatriz.RowCount; i++)
                {
                    oMatriz.Columns.Item("#").Cells.Item(i).Specific.Value = i.ToString(); // Asignar el número de fila
                }
            }
            catch (Exception ex)
            {
                Conexion.SapAplication.StatusBar.SetText($"Error al asignar números de fila: {ex.Message}", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            }
        }
        public static string GetCellValue(SAPbouiCOM.Matrix oMatrix, string Column, int nRow)
        {
            string value = "";
            try
            {
                value = ((SAPbouiCOM.EditText)oMatrix.Columns.Item(Column).Cells.Item(nRow).Specific).Value;
            }
            catch (Exception) { }
            return value;
        }
        private void BloquearCamposCabecera(SAPbouiCOM.Form oForm, bool bloquear)
        {
            //oForm.Freeze(true);
            try
            {
                //while (oForm.Mode == SAPbouiCOM.BoFormMode.fm_FIND_MODE)
                //{
                //    System.Threading.Thread.Sleep(50); // Esperar hasta que el formulario salga del modo de búsqueda
                //}

                //if (!oForm.Visible)  { return; }

                //System.Threading.Timer timer = null;

                if (bloquear)
                {
                
                        
                    oForm.Select();
                    string safeItem = oNombreCamposComision.ValorViaticos; // Un ítem seguro, como el botón "Cancelar"
                    if (oForm.Items.Item(safeItem) != null && oForm.Items.Item(safeItem).Enabled)
                    {
                        oForm.ActiveItem = safeItem; // Cambiar el foco
                        oForm.Update();
                        System.Threading.Thread.Sleep(50); // Esperar un poco para asegurar el cambio
                        System.Windows.Forms.Application.DoEvents();
                    }
                    
                    //else
                    //{
                    //    Conexion.SapAplication.StatusBar.SetText("No se encontró un ítem seguro para cambiar el foco.", BoMessageTime.bmt_Short, BoStatusBarMessageType.smt_Error);
                    //    return; // Evitar continuar si no hay un ítem seguro
                    //}

                }

                //if (bloquear) { oForm.ActiveItem = "2"; }

                

                //System.Windows.Forms.Application.DoEvents();
                        //oForm.Items.Item(oNombreCamposComision.btnProc).Enabled = !bloquear; // SE COMENTO ESTA LINEA HASTA SEGUNDA ORDEN 14-10-25 MA
                        oForm.Items.Item(oNombreCamposComision.anio).Enabled = !bloquear;
                
                        oForm.Items.Item(oNombreCamposComision.vendedor).Enabled = !bloquear;
                        oForm.Items.Item(oNombreCamposComision.metaId).Enabled = !bloquear;
                        oForm.Items.Item(oNombreCamposComision.mes).Enabled = !bloquear;

                //oForm.Items.Item(oNombreCamposComision.ValorViaticos).Enabled = !bloquear;
                //oForm.Items.Item(oNombreCamposComision.ValorOtros).Enabled = !bloquear;
                //oForm.Items.Item(oNombreCamposComision.ValRetFuente).Enabled = !bloquear;
                //oForm.Items.Item(oNombreCamposComision.ValRetIVA).Enabled = !bloquear;

                oForm.Refresh();
            }
            catch (Exception ex)
            {
                Conexion.SapAplication.StatusBar.SetText($"Error en BloquearCamposCabecera: {ex.Message}", BoMessageTime.bmt_Short, BoStatusBarMessageType.smt_Error);
            }
            finally
            {
              //  oForm.Freeze(false); // Descongelar el formulario
            }
        }

        private void CalculaComisionCxC(SAPbouiCOM.Form oForm, SAPbouiCOM.Matrix oMatrix)
        {
            try
            {
                oForm.Freeze(true);
                oMatrix.FlushToDataSource();

                // 🔥 Obtener el DataSource asociado a la matriz
                SAPbouiCOM.DBDataSource oDBDataSource = oForm.DataSources.DBDataSources.Item("@CRP_COMICXC");
                int rowCount = oDBDataSource.Size;

                double TotalBaseCalculo = 0;

                // 🚀 Procesar los datos directamente en el DataSource
                for (int i = 0; i < rowCount; i++)
                {
                    string status = oDBDataSource.GetValue("U_Status", i).Trim();
                    string valorString = oDBDataSource.GetValue("U_ValBase", i).Trim();
                    double valorBaseCalculo = 0;
                    double parsedValue = 0;
                    if (!string.IsNullOrEmpty(valorString) && double.TryParse(valorString, out parsedValue))
                    {
                        valorBaseCalculo = parsedValue;
                    }

                    if (!string.IsNullOrEmpty(status) && (status == "AP" || status == "IN"))
                    {
                        TotalBaseCalculo += valorBaseCalculo;
                    }
                }

                // 🔢 Asignar los valores calculados a los campos del formulario
                ((SAPbouiCOM.EditText)oForm.Items.Item(oNombreCamposComision.valorBaseCalculoCxC).Specific).Value = TotalBaseCalculo.ToString("F2", CultureInfo.CurrentCulture);

                double PorcPagadoCxC = ObtenerValorNumericoCampo(oForm, oNombreCamposComision.porcPagadoCxC);
                ((SAPbouiCOM.EditText)oForm.Items.Item(oNombreCamposComision.valorPagadoCxC).Specific).Value = (TotalBaseCalculo * PorcPagadoCxC / 100).ToString("F2", CultureInfo.CurrentCulture);

                // 🔄 Cargar nuevamente los datos al UI
                //oMatrix.LoadFromDataSource();

                // 🟢 Reactivar la UI
                oForm.Freeze(false);
            }
            catch (Exception ex)
            {
                oForm.Freeze(false); // Asegurar que la UI se reactive en caso de error
                Conexion.SapAplication.StatusBar.SetText($"Error en CalculaComisionCxC: {ex.Message}", BoMessageTime.bmt_Short, BoStatusBarMessageType.smt_Error);
            }
        }

        private void EjecutaExePreview(int transactionID)
        {
            try
            {
                string exePath = System.Configuration.ConfigurationManager.AppSettings["AppServer"];
                //string exePath = @"C:\CRP\Comisiones\ReportPreview.exe"; // Ruta del ejecutable externo
                //int transactionID = 12345; // ID de la transacción que deseas enviar

                // Construir los argumentos (parámetros que se enviarán al EXE)
                string argumentos = transactionID.ToString();

                // Crear el proceso
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = exePath,
                    Arguments = argumentos, // Enviar el ID como argumento
                    UseShellExecute = false, // Permite mejor control del proceso
                    CreateNoWindow = true // No muestra la ventana de línea de comandos
                };

                // Iniciar el proceso
                System.Diagnostics.Process proceso = System.Diagnostics.Process.Start(startInfo);

                //if (proceso != null)
                //{
                //    Console.WriteLine("Aplicación externa iniciada correctamente.");
                //}
                //else
                //{
                //    Console.WriteLine("No se pudo iniciar la aplicación externa.");
                //}
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al ejecutar el EXE: " + ex.Message);
            }
        }

        private void CalculaComisionCxC2 (SAPbouiCOM.Form oForm, SAPbouiCOM.Matrix oMatrix)
        {
            try
            {
                int rowCount = oMatrix.RowCount;
                double TotalBaseCalculo = 0;
                
                for (int i = 1; i <= rowCount; i++)
                {
                    string status = oMatrix.Columns.Item(oNombresMatrixCxC.statusCalculo).Cells.Item(i).Specific.Value;
                    double valorBaseCalculo = 0;
                    string valorString = oMatrix.Columns.Item(oNombresMatrixCxC.valorBaseCalculo).Cells.Item(i).Specific.Value;
                    double parsedValue = 0;
                    if (!string.IsNullOrEmpty(valorString) && double.TryParse(valorString, out parsedValue))
                    {
                        valorBaseCalculo = parsedValue;                  
                    }
                    if (!string.IsNullOrEmpty(status) && (status == "AP" || status == "IN"))
                    {
                        TotalBaseCalculo += valorBaseCalculo;
                    }
                }
                ((SAPbouiCOM.EditText)oForm.Items.Item(oNombreCamposComision.valorBaseCalculoCxC).Specific).Value = TotalBaseCalculo.ToString("F2", CultureInfo.CurrentCulture);
                double PorcPagadoCxC = 0;
                PorcPagadoCxC = ObtenerValorNumericoCampo(oForm, oNombreCamposComision.porcPagadoCxC);                              
                ((SAPbouiCOM.EditText)oForm.Items.Item(oNombreCamposComision.valorPagadoCxC).Specific).Value = (TotalBaseCalculo * PorcPagadoCxC / 100).ToString("F2", CultureInfo.CurrentCulture);

            }
            catch (Exception ex)
            {
                Conexion.SapAplication.StatusBar.SetText($"Error en CalculaComisionCxC: {ex.Message}", BoMessageTime.bmt_Short, BoStatusBarMessageType.smt_Error);
            }
        }

        private void CalculaComisionFact (SAPbouiCOM.Form oForm)
        {
            try
            {
                double valorBaseCalculo = 0;
                double valorAcumFact = 0;
                double valorMetaMes = 0;
                double valorMetaMesMin = 0;//Version 2.0
                double valorSuperMeta = 0;
                double porcentajeCalculo = 0;
                double porcentajeMetaInf = 0;
                double porcentajeMetaSup = 0;
                double porcentajeMetaInt = 0; //version 2.0

                // Obtén el valor base de cálculo
                valorBaseCalculo = ObtenerValorNumericoCampo(oForm, oNombreCamposComision.valorBaseCalculoFact);
                porcentajeMetaInf = ObtenerValorNumericoCampo(oForm, oNombreCamposComision.porcPagadoFactInf);
                porcentajeMetaInt = ObtenerValorNumericoCampo(oForm, oNombreCamposComision.porcPagadoFactInt);//Version 2.0
                porcentajeMetaSup = ObtenerValorNumericoCampo(oForm, oNombreCamposComision.porcPagadoFactSup);
                valorMetaMes = ObtenerValorNumericoCampo(oForm, oNombreCamposComision.valorMeta2);
                valorMetaMesMin = ObtenerValorNumericoCampo(oForm, oNombreCamposComision.valorMeta);//version 2.0
                valorSuperMeta = ObtenerValorNumericoCampo(oForm, oNombreCamposComision.valorSuperMeta);
                valorAcumFact = ObtenerValorNumericoCampo(oForm, oNombreCamposComision.valorFacturacionAcumSMeta);
                string varMeta = ((SAPbouiCOM.EditText)oForm.Items.Item(oNombreCamposComision.metaId).Specific).Value;
                string varAnio = ((SAPbouiCOM.EditText)oForm.Items.Item(oNombreCamposComision.anio).Specific).Value;
                string varMes = ((SAPbouiCOM.ComboBox)oForm.Items.Item(oNombreCamposComision.mes).Specific).Value;
                string varVendedor = ((SAPbouiCOM.EditText)oForm.Items.Item(oNombreCamposComision.vendedor).Specific).Value;
                //Version 2.0

                if (valorBaseCalculo <= valorMetaMesMin) //por debajo del minimo 
                    {porcentajeCalculo = porcentajeMetaInf;}
                if (valorBaseCalculo > valorMetaMesMin && valorBaseCalculo <= valorMetaMes) //dentro del rango de minimo  y maximo
                    {porcentajeCalculo =porcentajeMetaInt;}
                if (valorBaseCalculo > valorMetaMes)
                   { porcentajeCalculo = porcentajeMetaSup; }

                ((SAPbouiCOM.EditText)oForm.Items.Item(oNombreCamposComision.porcPagadoFact).Specific).Value = porcentajeCalculo.ToString("F2", CultureInfo.CurrentCulture);

                double valorCalculado = valorBaseCalculo * (porcentajeCalculo / 100);
                ((SAPbouiCOM.EditText)oForm.Items.Item(oNombreCamposComision.valorPagadoFact).Specific).Value = valorCalculado.ToString("F2", CultureInfo.CurrentCulture);
                
                //calculo de valor superMeta
                double valorCalculadoSuperMeta = 0;
                double porcMetaSup = 0;
                double porcComiPagado = 0;
                double valBaseMes = 0;
                string maxMes_SMeta = "";
                SAPbobsCOM.Recordset dsSMeta = Conexion.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                string MyQuerySMeta ="SELECT MAX(CONCAT(TO_NVARCHAR(\"U_anioMeta\"), TO_NVARCHAR(\"U_mesMeta\"))) as \"MaxMes\"" + 
                                     " FROM \"@CRP_VENTAMETA_MES\" where \"DocEntry\" ='" + varMeta + "'";
                dsSMeta.DoQuery(MyQuerySMeta);
                while (!dsSMeta.EoF)
                {
                    maxMes_SMeta = dsSMeta.Fields.Item("MaxMes").Value.ToString();
                    dsSMeta.MoveNext();
                }

                if (maxMes_SMeta == varAnio.ToString() + varMes.ToString()) //si el  mes evaluado es el ultimo mes de la configuracion de la supermeta
                {
                    if (valorSuperMeta <= (valorAcumFact + valorBaseCalculo))//si el valor de la supermeta es menor o igual q el acumulado de facturacion
                    {
                        SAPbobsCOM.Recordset dsMeta = Conexion.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                        string MyQuery = "select t1.\"U_comisionMetaSup\" , t1.\"U_mesMeta\", t1.\"U_anioMeta\" from \"@CRP_VENTAMETA\" t0 join \"@CRP_VENTAMETA_MES\" t1 on t0.\"DocEntry\" = t1.\"DocEntry\" " +
                                        "where t0.\"DocEntry\" = '" + varMeta + "' and t1.\"U_anioMeta\" = '" + varAnio + "' and t1.\"U_mesMeta\" <= '" + varMes + "'";//el mes deve ser difernte al actual
                        dsMeta.DoQuery(MyQuery);
                        while (!dsMeta.EoF)
                        {
                            porcMetaSup = Convert.ToDouble(dsMeta.Fields.Item("U_comisionMetaSup").Value);
                            string mesMeta = dsMeta.Fields.Item("U_mesMeta").Value.ToString();
                            if (varMes == mesMeta)
                            {
                                if (porcentajeCalculo < porcMetaSup)//calculo actual
                                {
                                    //double valorCalculado = valorBaseCalculo * (porcentajeCalculo / 100);
                                    double porcDiferencia = porcMetaSup - porcentajeCalculo;
                                    valorCalculadoSuperMeta += (valorBaseCalculo * porcDiferencia) / 100;
                                }
                            }
                           else {
                                SAPbobsCOM.Recordset dsComi = Conexion.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                                string MyQuery2 = "select t0.\"U_PorcFact\" , t0.\"U_ValBaseFac\" from \"@CRP_COMI\"  t0 " +
                                                "where t0.\"U_Vendedor\" = '" + varVendedor + "' and t0.\"U_Anio\" = '" + varAnio + "' and t0.\"U_Mes\" = '" + mesMeta + "'";
                                dsComi.DoQuery(MyQuery2);
                                while (!dsComi.EoF)
                                {
                               
                                    porcComiPagado = Convert.ToDouble(dsComi.Fields.Item("U_PorcFact").Value);//creyes 16Junio2025 -U_PorcFact
                                    valBaseMes = Convert.ToDouble(dsComi.Fields.Item("U_ValBaseFac").Value);

                                    if (porcComiPagado < porcMetaSup)
                                    {
                                        double porcDiferencia = porcMetaSup - porcComiPagado;
                                        valorCalculadoSuperMeta += (valBaseMes * porcDiferencia) / 100;
                                    }
                                    dsComi.MoveNext();
                                }
                            }


                            dsMeta.MoveNext();
                        }
                        ((SAPbouiCOM.EditText)oForm.Items.Item(oNombreCamposComision.valorPagadoFactRecalc).Specific).Value = valorCalculadoSuperMeta.ToString("F2", CultureInfo.CurrentCulture);
                    }
                }
                }
            catch (Exception ex)
            {
                Conexion.SapAplication.StatusBar.SetText($"Error en CalculaComisionFact: {ex.Message}", BoMessageTime.bmt_Short, BoStatusBarMessageType.smt_Error);
            }
        }

        public double ObtenerValorNumericoCampo(SAPbouiCOM.Form oForm, string uniqueID, double valorPredeterminado =0)
        {
            try
            {
                string valorStr = ((SAPbouiCOM.EditText)oForm.Items.Item(uniqueID).Specific).Value;
                double valorParsed = 0;
                double valorResultado = 0;
                if (!string.IsNullOrEmpty(valorStr) && double.TryParse(valorStr, out valorParsed))
                {
                    valorResultado = valorParsed;
                }
                return valorResultado;
            }
            catch (Exception ex)
            {                
                Conexion.SapAplication.StatusBar.SetText($"Error al obtener valor numérico del campo {uniqueID}: {ex.Message}", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            }

            // Retornar valor predeterminado si ocurre algún problema
            return valorPredeterminado;
        }

        private void cargarInfoMeta (SAPbouiCOM.Form oForm)
        {
            try
            {
                string varMeta = ((SAPbouiCOM.EditText)oForm.Items.Item(oNombreCamposComision.metaId).Specific).Value;
                string varAnio = ((SAPbouiCOM.EditText)oForm.Items.Item(oNombreCamposComision.anio).Specific).Value;
                string varMes = ((SAPbouiCOM.ComboBox)oForm.Items.Item(oNombreCamposComision.mes).Specific).Value;
                string varVendedor = ((SAPbouiCOM.EditText)oForm.Items.Item(oNombreCamposComision.vendedor).Specific).Value;

                if (!string.IsNullOrEmpty(varMeta) && !string.IsNullOrEmpty(varMes) && !string.IsNullOrEmpty(varAnio) && !string.IsNullOrEmpty(varVendedor))
                {
                    SAPbobsCOM.Recordset dsComision = Conexion.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                    string MyQuery = "select t0.\"U_valorMetaMes\", t0.\"U_valorMetaMesMin\", t0.\"U_comisionMetaSup\", t0.\"U_comisionMetaInf\", t0.\"U_comisionMetaInt\", t0.\"U_comisionCobro\", t1.\"U_ValSuperMeta\"" +
                                    " from \"@CRP_VENTAMETA_MES\" t0  join \"@CRP_VENTAMETA\" t1 on t0.\"DocEntry\" = t1.\"DocEntry\"" +
                                    " where t0.\"DocEntry\"   = '" + varMeta + "'" +
                                    "   and t0.\"U_anioMeta\" = '" + varAnio + "'" +
                                    "   and t0.\"U_mesMeta\"  = '" + varMes + "'" +
                                    "   and t1.\"U_idVendedor\" = '" + varVendedor + "'"; //version 2.0
                    dsComision.DoQuery(MyQuery);
                    if (dsComision.RecordCount > 0)
                    {

                        ((SAPbouiCOM.EditText)oForm.Items.Item(oNombreCamposComision.valorMeta).Specific).Value = dsComision.Fields.Item("U_valorMetaMesMin").Value.ToString("F2", CultureInfo.CurrentCulture);//version 2.0
                        ((SAPbouiCOM.EditText)oForm.Items.Item(oNombreCamposComision.valorMeta2).Specific).Value = dsComision.Fields.Item("U_valorMetaMes").Value.ToString("F2", CultureInfo.CurrentCulture);//version 2.0
                        ((SAPbouiCOM.EditText)oForm.Items.Item(oNombreCamposComision.porcPagadoCxC).Specific).Value = dsComision.Fields.Item("U_comisionCobro").Value.ToString("F2", CultureInfo.CurrentCulture);
                        ((SAPbouiCOM.EditText)oForm.Items.Item(oNombreCamposComision.porcPagadoFactInf).Specific).Value = dsComision.Fields.Item("U_comisionMetaInf").Value.ToString("F2", CultureInfo.CurrentCulture);
                        ((SAPbouiCOM.EditText)oForm.Items.Item(oNombreCamposComision.porcPagadoFactInt).Specific).Value = dsComision.Fields.Item("U_comisionMetaInt").Value.ToString("F2", CultureInfo.CurrentCulture);
                        ((SAPbouiCOM.EditText)oForm.Items.Item(oNombreCamposComision.porcPagadoFactSup).Specific).Value = dsComision.Fields.Item("U_comisionMetaSup").Value.ToString("F2", CultureInfo.CurrentCulture);                        

                        ((SAPbouiCOM.EditText)oForm.Items.Item(oNombreCamposComision.valorSuperMeta).Specific).Value = dsComision.Fields.Item("U_ValSuperMeta").Value.ToString("F2", CultureInfo.CurrentCulture);


                        double valAcumuladoFact = 0;
                        SAPbobsCOM.Recordset dsMeta = Conexion.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                        string MyQuery1 = "select t1.\"U_comisionMetaSup\" , t1.\"U_mesMeta\", t1.\"U_anioMeta\" from \"@CRP_VENTAMETA\" t0 join \"@CRP_VENTAMETA_MES\" t1 on t0.\"DocEntry\" = t1.\"DocEntry\" " +
                                        "where t0.\"DocEntry\" = '" + varMeta + "' and t1.\"U_anioMeta\" = '" + varAnio + "' and t1.\"U_mesMeta\" < '" + varMes + "'";//el mes debe ser difernte al actual
                        dsMeta.DoQuery(MyQuery1);
                        while (!dsMeta.EoF)
                        {
                            string mesMeta = dsMeta.Fields.Item("U_mesMeta").Value.ToString();
                            SAPbobsCOM.Recordset dsComi = Conexion.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                            string MyQuery2 = "select t0.\"U_PorcFact\" , t0.\"U_ValBaseFac\" from \"@CRP_COMI\" t0 " +
                                            "where t0.\"U_Vendedor\" = '" + varVendedor + "' and t0.\"U_Anio\" = '" + varAnio + "' and t0.\"U_Mes\" = '" + mesMeta + "'";
                            dsComi.DoQuery(MyQuery2);
                            while (!dsComi.EoF)
                            {
                                valAcumuladoFact += (double)dsComi.Fields.Item("U_ValBaseFac").Value;
                                dsComi.MoveNext();
                            }
                            dsMeta.MoveNext();
                        }
                        ((SAPbouiCOM.EditText)oForm.Items.Item(oNombreCamposComision.valorFacturacionAcumSMeta).Specific).Value = valAcumuladoFact.ToString("F2", CultureInfo.CurrentCulture);
                    }
                    else
                    {
                        ((SAPbouiCOM.EditText)oForm.Items.Item(oNombreCamposComision.valorMeta).Specific).Value = "0";
                        ((SAPbouiCOM.EditText)oForm.Items.Item(oNombreCamposComision.valorMeta2).Specific).Value = "0";

                        ((SAPbouiCOM.EditText)oForm.Items.Item(oNombreCamposComision.porcPagadoCxC).Specific).Value = "0";
                        ((SAPbouiCOM.EditText)oForm.Items.Item(oNombreCamposComision.porcPagadoFactInf).Specific).Value = "0";
                        ((SAPbouiCOM.EditText)oForm.Items.Item(oNombreCamposComision.porcPagadoFactInt).Specific).Value = "0";
                        ((SAPbouiCOM.EditText)oForm.Items.Item(oNombreCamposComision.porcPagadoFactSup).Specific).Value = "0";
                        ((SAPbouiCOM.EditText)oForm.Items.Item(oNombreCamposComision.valorSuperMeta).Specific).Value = "0";
                        ((SAPbouiCOM.EditText)oForm.Items.Item(oNombreCamposComision.valorFacturacionAcumSMeta).Specific).Value = "0";
                    }
                }
            }
            catch (Exception ex)
            {
                Conexion.SapAplication.StatusBar.SetText($"Error al obtener valores de la Meta: {ex.Message}", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            }

        }

        private void CambiarCursor(bool relojDeArena)
        {
            try
            {
                // Cambiar el cursor en SAP Business One
                if (relojDeArena)
                {
                    
                    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor; // Cambiar a reloj de arena
                    System.Windows.Forms.Application.DoEvents();
                    Conexion.SapAplication.StatusBar.SetText("Procesando, por favor espere...", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Warning);
                }
                else
                {
                    System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default; // Cambiar a cursor normal
                    System.Windows.Forms.Application.DoEvents();
                    //Conexion.SapAplication.StatusBar.SetText("Proceso finalizado.", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Success);
                }
            }
            catch (Exception ex)
            {
                Conexion.SapAplication.StatusBar.SetText($"Error al cambiar el cursor: {ex.Message}", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
            }
         }
        //private void cargarLayout ()
        //{
        //    SAPbobsCOM.Recordset oRS = null;
        //    SAPbobsCOM.CompanyService oCompanyService = null;
        //    //------------------------------------------------
        //    SAPbobsCOM.ReportTypesService oReportTypeService = null;
        //    SAPbobsCOM.ReportType oReportType = null;
        //    SAPbobsCOM.ReportTypeParams oReportTypeParams = null;
        //    //-------------------------------------------------
        //    SAPbobsCOM.ReportLayoutsService oReportLayoutService = null;
        //    SAPbobsCOM.ReportLayout oReportLayout = null;
        //    SAPbobsCOM.ReportLayoutParams oReportLayoutParams = null;
        //    //-------------------------------------------------
        //    SAPbobsCOM.Blob oBlob = null;
        //    SAPbobsCOM.BlobParams oBlobParams = null;
        //    SAPbobsCOM.BlobTableKeySegment oKeySegment = null;
        //    try
        //    {
        //        oRS = (SAPbobsCOM.Recordset)Conexion.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
        //        oCompanyService = Conexion.oCompany.GetCompanyService();

        //        oRS.DoQuery("SELECT CODE FROM RTYP WHERE NAME = 'CRP_COMI'");
        //        if (oRS.RecordCount == 0)
        //        {


        //            //1. ReportType
        //            oReportTypeService = (SAPbobsCOM.ReportTypesService)oCompanyService.GetBusinessService(SAPbobsCOM.ServiceTypes.ReportTypesService);
        //            oReportType = (SAPbobsCOM.ReportType)oReportTypeService.GetDataInterface(SAPbobsCOM.ReportTypesServiceDataInterfaces.rtsReportType);
        //            oReportType.AddonName = "CRP_COMI";
        //            oReportType.TypeName = "CRP_COMI";
        //            oReportType.AddonFormType = "UDO_FT_CRP_COMI";
        //            oReportType.MenuID = "47699";
        //            oReportTypeParams = oReportTypeService.AddReportType(oReportType);
        //            //2. Report Layout
        //            oReportLayoutService = (SAPbobsCOM.ReportLayoutsService)oCompanyService.GetBusinessService(SAPbobsCOM.ServiceTypes.ReportLayoutsService);
        //            oReportLayout = (SAPbobsCOM.ReportLayout)oReportLayoutService.GetDataInterface(SAPbobsCOM.ReportLayoutsServiceDataInterfaces.rlsdiReportLayout);
        //            oReportLayout.Author = "manager";
        //            oReportLayout.Category = SAPbobsCOM.ReportLayoutCategoryEnum.rlcCrystal;
        //            oReportLayout.Name = "Reporte de Comisiones";
        //            oReportLayout.TypeCode = oReportTypeParams.TypeCode;
        //            oReportLayoutParams = oReportLayoutService.AddReportLayout(oReportLayout);
        //            //3. vincular layout con el tipo de reporte
        //            oReportType = oReportTypeService.GetReportType(oReportTypeParams);
        //            oReportType.DefaultReportLayout = oReportLayoutParams.LayoutCode;
        //            oReportTypeService.UpdateReportType(oReportType);
        //            //4. realizar a carga del archivo Crystal report a SAP
        //            oBlob = (SAPbobsCOM.Blob)oCompanyService.GetDataInterface(SAPbobsCOM.CompanyServiceDataInterfaces.csdiBlob);
        //            oBlobParams = (SAPbobsCOM.BlobParams)oCompanyService.GetDataInterface(SAPbobsCOM.CompanyServiceDataInterfaces.csdiBlobParams);
        //            oBlobParams.Table = "RDOC";
        //            oBlobParams.Field = "Template";
        //            oKeySegment = oBlobParams.BlobTableKeySegments.Add();
        //            oKeySegment.Name = "DocCode";
        //            oKeySegment.Value = oReportLayoutParams.LayoutCode;
        //            oBlob.Content = Convert.ToBase64String(Properties.Resources.CRP_RPTCOMI);

        //            oCompanyService.SetBlob(oBlobParams, oBlob);
        //            //5. asignar nuestro tipo de reporte al formulario
        //            oForm.ReportType = oReportType.TypeCode;
        //        }
        //        else
        //            oForm.ReportType = oRS.Fields.Item(0).Value.ToString();
        //    }
        //    catch (Exception ex)
        //    {
        //        Conexion.SapAplication.StatusBar.SetText($"Error en proceso de vista previa: {ex.Message}", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
        //    }
        //}

       

        //private void GenerarReporteCrystal()
        //{
        //    try
        //    {
        //        // Ruta del reporte Crystal
        //        string reportPath = @"C:\REPORTES\CalculoComison.rpt"; // Actualiza con tu ruta real

        //        // Configurar parámetros del reporte
        //        ReportDocument reportDocument = new ReportDocument();
        //        reportDocument.Load(reportPath);

        //        // Pasar parámetros (si es necesario)
        //        reportDocument.SetParameterValue("DocKey@", 1);
        //        reportDocument.SetDatabaseLogon("system", "1MRH4n420", "192.168.10.22", "ZZ_DB_TALLER");

        //        //// Conexión a la base de datos
        //        //ConnectionInfo connectionInfo = new ConnectionInfo
        //        //{
        //        //    ServerName = "YOUR_SERVER_NAME",
        //        //    DatabaseName = "YOUR_DATABASE_NAME",
        //        //    UserID = "YOUR_DB_USER",
        //        //    Password = "YOUR_DB_PASSWORD",
        //        //    Type = ConnectionInfoType.SQL
        //        //};

        //        //foreach (Table table in reportDocument.Database.Tables)
        //        //{
        //        //    TableLogOnInfo logOnInfo = table.LogOnInfo;
        //        //    logOnInfo.ConnectionInfo = connectionInfo;
        //        //    table.ApplyLogOnInfo(logOnInfo);
        //        //}

        //        // Visualizar el reporte en Crystal Viewer
        //        CrystalDecisions.Windows.Forms.CrystalReportViewer viewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer
        //        {
        //            ReportSource = reportDocument,
        //            Dock = System.Windows.Forms.DockStyle.Fill
        //        };

        //        Form frm = new System.Windows.Forms.Form
        //        {
        //            Text = "Reporte de Comisiones",
        //            Width = 800,
        //            Height = 600
        //        };
        //        frm.Controls.Add(viewer);
        //        frm.ShowDialog();
        //    }
        //    catch (Exception ex)
        //    {
        //        SAPbouiCOM.Framework.Application.SBO_Application.StatusBar.SetText($"Error al generar reporte: {ex.Message}", SAPbouiCOM.BoMessageTime.bmt_Short, SAPbouiCOM.BoStatusBarMessageType.smt_Error);
        //    }
        //}



        #endregion

        private void SBO_Application_MenuEvent(ref SAPbouiCOM.MenuEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;

            // Verifica si es después de la acción y si el botón seleccionado es "Vista Previa"
            //if (!pVal.BeforeAction && pVal.MenuUID == "519") // "1287" es el UID del botón "Vista Previa"
            //{
            //    cargarLayout();
            //}
        }

        public void SBO_Application_FormDataEvent(ref SAPbouiCOM.BusinessObjectInfo BusinessObject, out bool BubbleEvent)
        {
            BubbleEvent = true;
            try
            {
                #region "Carga de datos del formulario"
                if (BusinessObject.FormTypeEx == idFrmComisiones && BusinessObject.EventType == BoEventTypes.et_FORM_DATA_LOAD && BusinessObject.BeforeAction == false)
                {
                    SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item(oNombreCamposComision.matrixCxC).Specific;

                    for (int i = 1; i <= oMatrix.RowCount; i++)
                    {
                        string statusValue = ((SAPbouiCOM.ComboBox)oMatrix.Columns.Item(oNombresMatrixCxC.statusCalculo).Cells.Item(i).Specific).Selected.Value;
                        if (statusValue == "IN") //bloqueo columna status
                        {
                            oMatrix.CommonSetting.SetCellEditable(i, 17, true); // OJO --- cambiar de true a False para habilitar el bloqueo de este campo. (despues de puesta en produccion y etapa de prueba)
                        }
                        else
                        {
                            oMatrix.CommonSetting.SetCellEditable(i, 17, true);
                        }
                    }
                    
                    BloquearCamposCabecera(oForm, true);
                }
                #endregion
            }
            catch (Exception ex)
            {
                Conexion.SapAplication.MessageBox(ex.Message);
            }
        }
        static void SBO_Application_AppEvent(BoAppEventTypes EventType)
        {
            // Verifica si el evento es un cierre de SAP Business One
            if (EventType == BoAppEventTypes.aet_ShutDown)
            {
                // Libera los recursos del addon y desconecta
                if (Conexion.oCompany != null && Conexion.oCompany.Connected)
                {
                    Conexion.oCompany.Disconnect();
                    Conexion.oCompany = null;
                }

                // Salir del addon
                Environment.Exit(0);
            }


        }

        private void CargarLayout()
        {
            SAPbobsCOM.CompanyService oCompanyService = null;
            SAPbobsCOM.ReportTypesService oReportTypesService = null;
            //-------------------------------------------------
            SAPbobsCOM.Recordset oRs = null;
            SAPbobsCOM.ReportType oReportType = null;
            SAPbobsCOM.ReportTypeParams oReportTypeParams = null;

            //-----------------------------------------------------
            SAPbobsCOM.ReportLayoutsService oReportLayoutService = null;
            SAPbobsCOM.ReportLayout oReportLayout = null;
            SAPbobsCOM.ReportLayoutParams oReportLayoutParams = null;

            //-----------------------------------------------------
            SAPbobsCOM.Blob oBlob = null;
            SAPbobsCOM.BlobParams oBlobParams = null;
            SAPbobsCOM.BlobTableKeySegment oKeySegment = null;
            //------------------------------------------------

            try
            {
                //1er paso crear el reportType
                //oRs.DoQuery("select ");
                oCompanyService = Conexion.oCompany.GetCompanyService();
                oReportTypesService = (SAPbobsCOM.ReportTypesService)oCompanyService.GetBusinessService(SAPbobsCOM.ServiceTypes.ReportTypesService);
                oRs = (SAPbobsCOM.Recordset)Conexion.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                oReportType = oReportTypesService.GetDataInterface(SAPbobsCOM.ReportTypesServiceDataInterfaces.rtsReportType);
                oReportType.AddonName = "Prueba Reporte";
                oReportType.TypeName = "pReporte";
                oReportType.AddonFormType = "CRP_COMI";
                oReportTypeParams = oReportTypesService.AddReportType(oReportType);

                // 2do paso Report Layout
                oReportLayoutService = (SAPbobsCOM.ReportLayoutsService)oCompanyService.GetBusinessService(SAPbobsCOM.ServiceTypes.ReportLayoutsService);
                oReportLayout = (SAPbobsCOM.ReportLayout)oReportLayoutService.GetDataInterface(SAPbobsCOM.ReportLayoutsServiceDataInterfaces.rlsdiReportLayout);
                oReportLayout.Author = "manager";
                oReportLayout.Category = SAPbobsCOM.ReportLayoutCategoryEnum.rlcCrystal;
                oReportLayout.Name = "CRP CALCULO COMISIONES";
                oReportLayout.TypeCode = oReportTypeParams.TypeCode;
                oReportLayoutParams = oReportLayoutService.AddReportLayout(oReportLayout);

                //3.- vincular el layout con el tipo de reporte
                oReportType = oReportTypesService.GetReportType(oReportTypeParams);
                oReportType.DefaultReportLayout = oReportLayoutParams.LayoutCode;
                oReportTypesService.UpdateReportType(oReportType);

                //4.- Realizar la carga del Artchivo crystal report a Sap 
                oBlob = (SAPbobsCOM.Blob)oCompanyService.GetDataInterface(SAPbobsCOM.CompanyServiceDataInterfaces.csdiBlob);
                oBlobParams = (SAPbobsCOM.BlobParams)oCompanyService.GetDataInterface(SAPbobsCOM.CompanyServiceDataInterfaces.csdiBlobParams);
                oBlobParams.Table = "RDOC";
                oBlobParams.Field = "Template";
                oKeySegment = oBlobParams.BlobTableKeySegments.Add();
                oKeySegment.Name = "DocCode";
                oKeySegment.Value = oReportLayoutParams.LayoutCode;
                oBlob.Content = Convert.ToBase64String(Properties.Resources.CRP_COMISIONES_RESUMIDO);

                oCompanyService.SetBlob(oBlobParams, oBlob);

                //5.- Asignar nuestro tipo de reporte al formulario
                oForm.ReportType = oReportType.TypeCode;

            }

            catch (Exception Ex)
            {
                Conexion.SapAplication.MessageBox(Ex.Message);
            }
        }
    }
}

