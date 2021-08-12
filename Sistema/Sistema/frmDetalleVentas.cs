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
    public partial class frmDetalleVentas : Form
    {
        public frmDetalleVentas()
        {
            InitializeComponent();
        }

        private void frmDetalleVentas_Load(object sender, EventArgs e)
        {
            MySqlConnection cn = new MySqlConnection("server = localhost;userID=root;password=;DataBase=digitsbits");
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(" SELECT ventas.`fecha`,ventas.`folio`,detalle_ventas.`id_producto`,productos.`descripcion`,detalle_ventas.`cantidad`,detalle_ventas.`precio`  FROM detalle_ventas INNER JOIN productos ON productos.`idproducto`= detalle_ventas.`id_producto` INNER JOIN ventas  WHERE detalle_ventas.`folio`= ventas.`folio`", cn);
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
            MySqlDataAdapter da = new MySqlDataAdapter(" SELECT ventas.`fecha`,ventas.`folio`,detalle_ventas.`id_producto`,productos.`descripcion`,detalle_ventas.`cantidad`,detalle_ventas.`precio`  FROM detalle_ventas INNER JOIN productos ON productos.`idproducto`= detalle_ventas.`id_producto` INNER JOIN ventas  WHERE detalle_ventas.`folio`= ventas.`folio` AND detalle_ventas.`folio` AND fecha BETWEEN'" + dateTimePicker1.Text + "'AND'" + dateTimePicker2.Text + "'", cn);
            da.Fill(dt);
            reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource rp = new ReportDataSource("DataSet1", dt);
            reportViewer1.LocalReport.DataSources.Add(rp);
            reportViewer1.RefreshReport();
            //MySqlDataAdapter da = new MySqlDataAdapter("SELECT compras.`fecha`,productos.`codigo`,productos.`descripcion`,productos.`costo`,(SELECT detalle_compras.`cantidad` WHERE detalle_compras.`id_producto`=productos.`idproducto`)'Cantidad Comprado', (SELECT ROUND(detalle_compras.`precio`*detalle_compras.`cantidad`, 2) WHERE detalle_compras.`folio`= compras.`folio`)AS 'Precio Total',detalle_compras.`folio`FROM productos INNER JOIN detalle_compras ON detalle_compras.`id_producto`= productos.`idproducto`INNER JOIN compras ON detalle_compras.`folio`= compras.`folio`ORDER BY detalle_compras.`folio` where fecha BETWEEN '" + dateTimePicker1.Text + "'AND'" + dateTimePicker2.Text + "'", cn);

        }

        private void btnFolio_Click(object sender, EventArgs e)
        {
            MySqlConnection cn = new MySqlConnection("server = localhost;userID=root;password=;DataBase=digitsbits");
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(" SELECT ventas.`fecha`,ventas.`folio`,detalle_ventas.`id_producto`,productos.`descripcion`,detalle_ventas.`cantidad`,detalle_ventas.`precio`  FROM detalle_ventas INNER JOIN productos ON productos.`idproducto`= detalle_ventas.`id_producto` INNER JOIN ventas  WHERE detalle_ventas.`folio`= ventas.`folio` AND detalle_ventas.`folio`='" + textBox1.Text +"'", cn);
            da.Fill(dt);
            reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource rp = new ReportDataSource("DataSet1", dt);
            reportViewer1.LocalReport.DataSources.Add(rp);
            reportViewer1.RefreshReport();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
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
