using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinPrintForm
{
    public partial class Form1 : Form
    {
        public Int32 DocEntry { get; set; }
        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; // Para centrarlo en la pantalla
            this.WindowState = FormWindowState.Normal; // Asegura que no se minimice
        }




        //[STAThread]
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {


                // Cargar el reporte de Crystal Report
                ReportDocument reportDocument = new ReportDocument();
                reportDocument.Load(@"C:\REPORTES\CalculoComison5.rpt");

                // Establecer los parámetros del reporte
                string mes = "04";
                reportDocument.SetParameterValue("Mes", mes);                

                // Configurar la conexión a la base de datos
                ConnectionInfo connectionInfo = new ConnectionInfo();
                connectionInfo.ServerName = "192.168.10.22";
                connectionInfo.DatabaseName = "BK_FEB2025";
                connectionInfo.UserID = "SYSTEM";
                connectionInfo.Password = "1MRH4n420";

                // Asignar la conexión a cada tabla en el reporte
                foreach (Table table in reportDocument.Database.Tables)
                {
                    TableLogOnInfo tableLogOnInfo = table.LogOnInfo;
                    tableLogOnInfo.ConnectionInfo = connectionInfo;
                    table.ApplyLogOnInfo(tableLogOnInfo);
                }

                // Establecer el ReportSource del CrystalReportViewer
                crystalReportViewer1.ReportSource = reportDocument;



                //string reportPath = @"C:\REPORTES\CalculoComison4.rpt"; // Ruta del reporte

                //// 1️ Cargar el reporte
                //ReportDocument reportDocument = new ReportDocument();
                //reportDocument.Load(reportPath);




                //// 6 Asignar el parámetro (Clave primaria de la transacción)
                //int transactionID = DocEntry; // Aquí pones el ID de la transacción que quieres mostrar
                ////reportDocument.SetParameterValue("@DocKey", Convert.ToInt32(transactionID));

                ////reportDocument.ReportOptions.EnableSaveDataWithReport = false;

                //reportDocument.DataDefinition.ParameterFields["@DocEntry"].CurrentValues.Clear(); // Limpia valores previos

                ////foreach (ParameterFieldDefinition param in reportDocument.DataDefinition.ParameterFields)
                ////{
                ////    Console.WriteLine(param.Name);
                ////    System.Diagnostics.Debug.WriteLine(param.Name);
                ////    System.Diagnostics.Debug.WriteLine(param.CurrentValues);
                ////}
                //reportDocument.SetParameterValue("@DocEntry", transactionID); // Asigna nuevo valor


                //// 2️ Configurar conexión a la BD
                //ConnectionInfo connectionInfo = new ConnectionInfo
                //{
                //    //"system", "1MRH4n420", "192.168.10.22", "ZZ_DB_TALLER"
                //    ServerName = "192.168.10.22",
                //    DatabaseName = "BK_FEB2025",
                //    UserID = "SYSTEM",
                //    Password = "1MRH4n420",
                //    Type = ConnectionInfoType.SQL
                //};

                //reportDocument.SetDatabaseLogon ("system", "1MRH4n420", "192.168.10.22", "BK_FEB2025");
                ////// 3️⃣ Aplicar conexión a todas las tablas del reporte
                ////foreach (Table table in reportDocument.Database.Tables)
                ////{
                ////    TableLogOnInfo tableLogOnInfo = table.LogOnInfo;
                ////    tableLogOnInfo.ConnectionInfo = connectionInfo;
                ////    table.ApplyLogOnInfo(tableLogOnInfo);

                ////}

                ////// 4️⃣ Aplicar conexión a los subreportes si existen
                ////foreach (Section section in reportDocument.ReportDefinition.Sections)
                ////{
                ////    foreach (ReportObject reportObject in section.ReportObjects)
                ////    {
                ////        if (reportObject.Kind == ReportObjectKind.SubreportObject)
                ////        {
                ////            SubreportObject subreportObject = (SubreportObject)reportObject;
                ////            ReportDocument subReportDocument = reportDocument.OpenSubreport(subreportObject.SubreportName);

                ////            foreach (Table subTable in subReportDocument.Database.Tables)
                ////            {
                ////                TableLogOnInfo subTableLogOnInfo = subTable.LogOnInfo;
                ////                subTableLogOnInfo.ConnectionInfo = connectionInfo;
                ////                subTable.ApplyLogOnInfo(subTableLogOnInfo);
                ////            }
                ////        }
                ////    }
                ////}



                //// 5️⃣ Verificar base de datos y refrescar reporte
                ////reportDocument.VerifyDatabase();
                ////reportDocument.Refresh();


                //// 5 Configurar el CrystalReportViewer
                //crystalReportViewer1.ReportSource = reportDocument;
                //crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
                //crystalReportViewer1.Refresh();













                //string reportPath = @"C:\REPORTES\CalculoComison.rpt"; // Actualiza con tu ruta real

                //// Configurar parámetros del reporte
                //ReportDocument reportDocument = new ReportDocument();
                //reportDocument.Load(reportPath);

                //// Pasar parámetros (si es necesario)
                //reportDocument.SetParameterValue("DocKey@", 1);
                //reportDocument.SetDatabaseLogon("system", "1MRH4n420", "192.168.10.22", "ZZ_DB_TALLER");

                //// Visualizar el reporte en Crystal Viewer
                //crystalReportViewer1.ReportSource = reportDocument;
                //crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
                //crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el reporte: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
