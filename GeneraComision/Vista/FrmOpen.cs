using DBConfig;
using GeneraDatosCatalogo.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace GeneraDatosCatalogo.Vista
{
    public partial class FrmOpen : Form
    {
        public bool oProcesoCancelado { get; set; }

        public DataSet dsCatalogoExist { get; set; } //= new DataSet();
        public NegLogCatalogo oLogCatalogo { get; set; }

        public FrmOpen()
        {
            InitializeComponent();
        }

        private void FrmOpen_Load(object sender, EventArgs e)
        {
            NegLogCatalogo oLogCatalogo = new NegLogCatalogo();

            this.dataGridView1.DataSource = oLogCatalogo.BuscarLog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            oProcesoCancelado = true;
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        { try
            {
                DataGridViewRow dgwr = new DataGridViewRow();
                DataGridViewRow dgrow = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex];
                string XML = dgrow.Cells["detalle"].Value.ToString();

                XmlDocument doc = new XmlDocument();
                //string xmlData = "<book xmlns:bk='urn:samples'></book>";

                doc.Load(new StringReader(XML));
                DataSet ds = new DataSet();
                ds.ReadXml(new XmlNodeReader(doc));

                DataTable dtCatalogo = new DataTable();
                dtCatalogo = ds.Tables[0];
                dtCatalogo.DefaultView.Sort = "OrdenNivel6 asc";
                dtCatalogo = dtCatalogo.DefaultView.ToTable(true);

                dsCatalogoExist = ds;
                oLogCatalogo = new NegLogCatalogo();
                oLogCatalogo.Pk = int.Parse(dgrow.Cells["Pk"].Value.ToString());
                oLogCatalogo.nombreCatalogo = dgrow.Cells["NombreCatalogo"].Value.ToString();
                oLogCatalogo.descripcion = dgrow.Cells["DescripcionCatalogo"].Value.ToString();
                oLogCatalogo.filtros = dgrow.Cells["filtros"].Value.ToString();
                oLogCatalogo.filtros2 = dgrow.Cells["filtros2"].Value.ToString();
                oLogCatalogo.ODA = dgrow.Cells["ODA"].Value.ToString();

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message , Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                //this.Close();
            }

            }

    }


}
