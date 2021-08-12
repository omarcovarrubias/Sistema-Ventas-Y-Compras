using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using MySql.Data.MySqlClient;
namespace Sistema
{
    public partial class frmReporteClientes : Form
    {
        public frmReporteClientes()
        {
            InitializeComponent();
        }

        private void frmReporteClientes_Load(object sender, EventArgs e)
        {

            MySqlConnection cn = new MySqlConnection("server = localhost;userID=root;password=;DataBase=digitsbits");
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter("select * from cliente", cn);
            //MySqlDataAdapter da = new MySqlDataAdapter("select * from t_cliente where fecha BETWEEN'" + dateTimePicker1.Text + "'AND'" + dateTimePicker2.Text + "'", cn);

            da.Fill(dt);

            reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource rp = new ReportDataSource("DataSet1", dt);
            reportViewer1.LocalReport.DataSources.Add(rp);
            reportViewer1.RefreshReport();

            this.reportViewer1.RefreshReport();
        }
    }
}
