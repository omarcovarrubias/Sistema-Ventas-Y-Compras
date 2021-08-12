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
    public partial class frmDetalleCompras : Form
    {
        public frmDetalleCompras()
        {
            InitializeComponent();
        }

        private void frmDetalleCompras_Load(object sender, EventArgs e)
        {
            
            MySqlConnection cn = new MySqlConnection("server = localhost;userID=root;password=;DataBase=digitsbits");
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT compras.`fecha`,compras.`folio`,detalle_compras.`id_producto`,productos.`descripcion`,detalle_compras.`cantidad`,detalle_compras.`precio`,detalle_compras.`proveedor`,detalle_compras.`vendedor`  FROM detalle_compras INNER JOIN productos ON productos.`idproducto`= detalle_compras.`id_producto` INNER JOIN compras  WHERE detalle_compras.`folio`= compras.`folio`", cn);
            da.Fill(dt);
            reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource rp = new ReportDataSource("DataSet1", dt);
            reportViewer1.LocalReport.DataSources.Add(rp);
            reportViewer1.RefreshReport();


            //MySqlDataAdapter da = new MySqlDataAdapter("SELECT compras.`fecha`,productos.`codigo`,productos.`descripcion`,productos.`costo`,(SELECT detalle_compras.`cantidad` WHERE detalle_compras.`id_producto`=productos.`idproducto`)'Cantidad Comprado', (SELECT ROUND(detalle_compras.`precio`*detalle_compras.`cantidad`, 2) WHERE detalle_compras.`folio`= compras.`folio`)AS 'Precio Total',detalle_compras.`folio`FROM productos INNER JOIN detalle_compras ON detalle_compras.`id_producto`= productos.`idproducto`INNER JOIN compras ON detalle_compras.`folio`= compras.`folio`ORDER BY detalle_compras.`folio` where fecha BETWEEN '" + dateTimePicker1.Text + "'AND'" + dateTimePicker2.Text + "'", cn);


            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection cn = new MySqlConnection("server = localhost;userID=root;password=;DataBase=digitsbits");
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT compras.`fecha`,compras.`folio`,detalle_compras.`id_producto`,productos.`descripcion`,detalle_compras.`cantidad`,detalle_compras.`precio`,detalle_compras.`proveedor`,detalle_compras.`vendedor`  FROM detalle_compras INNER JOIN productos ON productos.`idproducto`= detalle_compras.`id_producto` INNER JOIN compras  WHERE detalle_compras.`folio`= compras.`folio` AND fecha BETWEEN'" + dateTimePicker1.Text + "'AND'" + dateTimePicker2.Text + "'", cn);
            da.Fill(dt);

            reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource rp = new ReportDataSource("DataSet1", dt);
            reportViewer1.LocalReport.DataSources.Add(rp);
            reportViewer1.RefreshReport();
            //MySqlDataAdapter da = new MySqlDataAdapter("SELECT compras.`fecha`,productos.`codigo`,productos.`descripcion`,productos.`costo`,(SELECT detalle_compras.`cantidad` WHERE detalle_compras.`id_producto`=productos.`idproducto`)'Cantidad Comprado', (SELECT ROUND(detalle_compras.`precio`*detalle_compras.`cantidad`, 2) WHERE detalle_compras.`folio`= compras.`folio`)AS 'Precio Total',detalle_compras.`folio`FROM productos INNER JOIN detalle_compras ON detalle_compras.`id_producto`= productos.`idproducto`INNER JOIN compras ON detalle_compras.`folio`= compras.`folio`ORDER BY detalle_compras.`folio` where fecha BETWEEN '" + dateTimePicker1.Text + "'AND'" + dateTimePicker2.Text + "'", cn);



        }

        private void dvgDetalleCompras_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MySqlConnection cn = new MySqlConnection("server = localhost;userID=root;password=;DataBase=digitsbits");
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT compras.`fecha`,compras.`folio`,detalle_compras.`id_producto`,productos.`descripcion`,detalle_compras.`cantidad`,detalle_compras.`precio`,detalle_compras.`proveedor`,detalle_compras.`vendedor`  FROM detalle_compras INNER JOIN productos ON productos.`idproducto`= detalle_compras.`id_producto` INNER JOIN compras  WHERE detalle_compras.`folio`= compras.`folio` AND fecha BETWEEN'" + dateTimePicker1.Text + "'AND'" + dateTimePicker2.Text + "'", cn);
            da.Fill(dt);

            reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource rp = new ReportDataSource("DataSet1", dt);
            reportViewer1.LocalReport.DataSources.Add(rp);
            reportViewer1.RefreshReport();
        }

        private void btnFolio_Click(object sender, EventArgs e)
        {
            MySqlConnection cn = new MySqlConnection("server = localhost;userID=root;password=;DataBase=digitsbits");
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT compras.`fecha`,compras.`folio`,detalle_compras.`id_producto`,productos.`descripcion`,detalle_compras.`cantidad`,detalle_compras.`precio`,detalle_compras.`proveedor`,detalle_compras.`vendedor`  FROM detalle_compras INNER JOIN productos ON productos.`idproducto`= detalle_compras.`id_producto` INNER JOIN compras  WHERE detalle_compras.`folio`= compras.`folio` AND detalle_compras.`folio`='" + txtFolio.Text+"'", cn);
            da.Fill(dt);

            reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource rp = new ReportDataSource("DataSet1", dt);
            reportViewer1.LocalReport.DataSources.Add(rp);
            reportViewer1.RefreshReport();
        }

        private void txtFolio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
