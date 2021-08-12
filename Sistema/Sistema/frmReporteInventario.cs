﻿using System;
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
    public partial class frmReporteInventario : Form
    {
        public frmReporteInventario()
        {
            InitializeComponent();
        }

        private void frmReporteInventario_Load(object sender, EventArgs e)
        {
            MySqlConnection cn = new MySqlConnection("server = localhost;userID=root;password=;DataBase=digitsbits");
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT idproducto,codigo,descripcion,nombreempresa,costo,stock,(SELECT SUM(IF(detalle_compras.cantidad IS NULL,0,detalle_compras.cantidad)) AS cantidad FROM detalle_compras WHERE id_producto = idproducto)-IF((SELECT SUM(IF(detalle_ventas.cantidad IS NULL,0,detalle_ventas.cantidad)) AS cantidad FROM detalle_ventas WHERE id_producto = idproducto) IS NULL,0,(SELECT SUM(IF(detalle_ventas.cantidad IS NULL,0,detalle_ventas.cantidad)) AS cantidad FROM detalle_ventas WHERE id_producto = idproducto)) AS cantidad FROM productos order by cantidad", cn);
            da.Fill(dt);

            reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource rp = new ReportDataSource("DataSet1", dt);
            reportViewer1.LocalReport.DataSources.Add(rp);
            reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }
    }
}
