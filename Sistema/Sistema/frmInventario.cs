using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema
{
    public partial class frmInventario : Form
    {
        dbProductos xx = new dbProductos();
        public frmInventario()
        {
            InitializeComponent();
            dvgInventario.DataSource = xx.getproductosFiltroInventarioI();

        }
            
        private void frmInventario_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dvgInventario.Rows)
            {
                if (Convert.ToString(row.Cells["cantidad"].Value).Trim()== string.Empty)
                {
                     row.Cells["cantidad"].Value = 0;
                }
             }


            dvgInventario.AllowUserToAddRows = false;
            foreach (DataGridViewRow row in dvgInventario.Rows)

            {
                /*string cantidad = dvgInventario.CurrentRow.Cells[5].Value.ToString();
                string stock= dvgInventario.CurrentRow.Cells[4].Value.ToString();
                decimal cantidad2 = Convert.ToDecimal(stock);
                decimal stock2 = Convert.ToDecimal(stock);
                decimal total = (cantidad2 - stock2);
                decimal total2 = (total/stock2)*(100);
                //if (Convert.ToDecimal(row.Cells["stock"].Value)< 10)*/
                if (Convert.ToDecimal(row.Cells["cantidad"].Value)<10)
                {
                    row.Cells["codigo"].Style.BackColor = Color.Red;
                    row.Cells["descripcion"].Style.BackColor = Color.Red;
                    row.Cells["nombreempresa"].Style.BackColor = Color.Red;
                    row.Cells["costo"].Style.BackColor = Color.Red;
                    row.Cells["stock"].Style.BackColor = Color.Red;
                    row.Cells["cantidad"].Style.BackColor = Color.Red;
                }



                if (Convert.ToDecimal(row.Cells["cantidad"].Value) > Convert.ToDecimal(row.Cells["stock"].Value))


                {
                    row.Cells["codigo"].Style.BackColor = Color.Green;
                    row.Cells["descripcion"].Style.BackColor = Color.Green;
                    row.Cells["nombreempresa"].Style.BackColor = Color.Green;
                    row.Cells["costo"].Style.BackColor = Color.Green;
                    row.Cells["stock"].Style.BackColor = Color.Green;
                    row.Cells["cantidad"].Style.BackColor = Color.Green;
                }


                if (Convert.ToDecimal(row.Cells["cantidad"].Value) < Convert.ToDecimal(row.Cells["stock"].Value)&& Convert.ToDecimal(row.Cells["cantidad"].Value)>10)

                {
                    row.Cells["codigo"].Style.BackColor = Color.Yellow;
                    row.Cells["descripcion"].Style.BackColor = Color.Yellow;
                    row.Cells["nombreempresa"].Style.BackColor = Color.Yellow;
                    row.Cells["costo"].Style.BackColor = Color.Yellow;
                    row.Cells["stock"].Style.BackColor = Color.Yellow;
                    row.Cells["cantidad"].Style.BackColor = Color.Yellow;
                }


            }
            /*
            foreach (DataGridViewRow row in dvgInventario.Rows)
            {

                if (Convert.ToDecimal(row.Cells["cantidad"].Value) < 10 && (Convert.ToDecimal(row.Cells["cantidad"].Value)) > 0 && Convert.ToDecimal(row.Cells["stock"].Value) > Convert.ToDecimal(row.Cells["cantidad"].Value))
                {
                    row.Cells["codigo"].Style.BackColor = Color.Red;
                    row.Cells["descripcion"].Style.BackColor = Color.Red;
                    row.Cells["nombreempresa"].Style.BackColor = Color.Red;
                    row.Cells["costo"].Style.BackColor = Color.Red;
                    row.Cells["stock"].Style.BackColor = Color.Red;                    
                    row.Cells["cantidad"].Style.BackColor = Color.Red;
                }
                if (Convert.ToDecimal(row.Cells["cantidad"].Value) > 30 && Convert.ToDecimal(row.Cells["stock"].Value) > Convert.ToDecimal(row.Cells["cantidad"].Value))
                {

                    row.Cells["codigo"].Style.BackColor = Color.Green;
                    row.Cells["descripcion"].Style.BackColor = Color.Green;
                    row.Cells["nombreempresa"].Style.BackColor = Color.Green;
                    row.Cells["costo"].Style.BackColor = Color.Green;
                    row.Cells["stock"].Style.BackColor = Color.Green;
                    row.Cells["cantidad"].Style.BackColor = Color.Green;
                }
                if (Convert.ToDecimal(row.Cells["cantidad"].Value) < 30 && (Convert.ToDecimal(row.Cells["cantidad"].Value)) > 20 && Convert.ToDecimal(row.Cells["stock"].Value) > Convert.ToDecimal(row.Cells["cantidad"].Value))
                {

                    row.Cells["codigo"].Style.BackColor = Color.Yellow;
                    row.Cells["descripcion"].Style.BackColor = Color.Yellow;
                    row.Cells["nombreempresa"].Style.BackColor = Color.Yellow;
                    row.Cells["costo"].Style.BackColor = Color.Yellow;
                    row.Cells["stock"].Style.BackColor = Color.Yellow;
                    row.Cells["cantidad"].Style.BackColor = Color.Yellow;
                }
                if (Convert.ToDecimal(row.Cells["cantidad"].Value) > Convert.ToDecimal(row.Cells["stock"].Value))
                {

                    row.Cells["codigo"].Style.BackColor = Color.Green;
                    row.Cells["descripcion"].Style.BackColor = Color.Green;
                    row.Cells["nombreempresa"].Style.BackColor = Color.Green;
                    row.Cells["costo"].Style.BackColor = Color.Green;
                    row.Cells["stock"].Style.BackColor = Color.Green;
                    row.Cells["cantidad"].Style.BackColor = Color.Green;
                }

            }
            */


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            


            dbProductos xx = new dbProductos();
            //prov.getProveedorFiltro(txtBuscar.Text);
            dvgInventario.DataSource = xx.getproductosFiltroInventarioBusqueda(txtBuscar.Text);
            foreach (DataGridViewRow row in dvgInventario.Rows)
            {
                if (Convert.ToString(row.Cells["cantidad"].Value).Trim() == string.Empty)
                {
                    row.Cells["cantidad"].Value = 0;
                }
            }
            foreach (DataGridViewRow row in dvgInventario.Rows)


            {
                if (Convert.ToDecimal(row.Cells["cantidad"].Value) < 10)
                {
                    row.Cells["codigo"].Style.BackColor = Color.Red;
                    row.Cells["descripcion"].Style.BackColor = Color.Red;
                    row.Cells["nombreempresa"].Style.BackColor = Color.Red;
                    row.Cells["costo"].Style.BackColor = Color.Red;
                    row.Cells["stock"].Style.BackColor = Color.Red;
                    row.Cells["cantidad"].Style.BackColor = Color.Red;
                }



                if (Convert.ToDecimal(row.Cells["cantidad"].Value) > Convert.ToDecimal(row.Cells["stock"].Value))


                {
                    row.Cells["codigo"].Style.BackColor = Color.Green;
                    row.Cells["descripcion"].Style.BackColor = Color.Green;
                    row.Cells["nombreempresa"].Style.BackColor = Color.Green;
                    row.Cells["costo"].Style.BackColor = Color.Green;
                    row.Cells["stock"].Style.BackColor = Color.Green;
                    row.Cells["cantidad"].Style.BackColor = Color.Green;
                }


                if (Convert.ToDecimal(row.Cells["cantidad"].Value) < Convert.ToDecimal(row.Cells["stock"].Value) && Convert.ToDecimal(row.Cells["cantidad"].Value) > 10)

                {
                    row.Cells["codigo"].Style.BackColor = Color.Yellow;
                    row.Cells["descripcion"].Style.BackColor = Color.Yellow;
                    row.Cells["nombreempresa"].Style.BackColor = Color.Yellow;
                    row.Cells["costo"].Style.BackColor = Color.Yellow;
                    row.Cells["stock"].Style.BackColor = Color.Yellow;
                    row.Cells["cantidad"].Style.BackColor = Color.Yellow;
                }






            }
            /*
                        foreach (DataGridViewRow row in dvgInventario.Rows)
                        {

                           if (Convert.ToDecimal(row.Cells["cantidad"].Value) < 10 && (Convert.ToDecimal(row.Cells["cantidad"].Value)) > 0 && Convert.ToDecimal(row.Cells["stock"].Value) > Convert.ToDecimal(row.Cells["cantidad"].Value))
                            {
                                row.Cells["codigo"].Style.BackColor = Color.Red;
                                row.Cells["descripcion"].Style.BackColor = Color.Red;
                                row.Cells["nombreempresa"].Style.BackColor = Color.Red;
                                row.Cells["costo"].Style.BackColor = Color.Red;
                                row.Cells["stock"].Style.BackColor = Color.Red;
                                row.Cells["cantidad"].Style.BackColor = Color.Red;
                            }
                            if (Convert.ToDecimal(row.Cells["cantidad"].Value) > 30 && Convert.ToDecimal(row.Cells["stock"].Value) > Convert.ToDecimal(row.Cells["cantidad"].Value))
                            {

                                row.Cells["codigo"].Style.BackColor = Color.Green;
                                row.Cells["descripcion"].Style.BackColor = Color.Green;
                                row.Cells["nombreempresa"].Style.BackColor = Color.Green;
                                row.Cells["costo"].Style.BackColor = Color.Green;
                                row.Cells["stock"].Style.BackColor = Color.Green;
                                row.Cells["cantidad"].Style.BackColor = Color.Green;
                            }
                            if (Convert.ToDecimal(row.Cells["cantidad"].Value) < 30 && (Convert.ToDecimal(row.Cells["cantidad"].Value)) > 20 && Convert.ToDecimal(row.Cells["stock"].Value) > Convert.ToDecimal(row.Cells["cantidad"].Value))
                            {

                                row.Cells["codigo"].Style.BackColor = Color.Yellow;
                                row.Cells["descripcion"].Style.BackColor = Color.Yellow;
                                row.Cells["nombreempresa"].Style.BackColor = Color.Yellow;
                                row.Cells["costo"].Style.BackColor = Color.Yellow;
                                row.Cells["stock"].Style.BackColor = Color.Yellow;
                                row.Cells["cantidad"].Style.BackColor = Color.Yellow;
                            }
                            if (Convert.ToDecimal(row.Cells["cantidad"].Value) > Convert.ToDecimal(row.Cells["stock"].Value))
                            {

                                row.Cells["codigo"].Style.BackColor = Color.Green;
                                row.Cells["descripcion"].Style.BackColor = Color.Green;
                                row.Cells["nombreempresa"].Style.BackColor = Color.Green;
                                row.Cells["costo"].Style.BackColor = Color.Green;
                                row.Cells["stock"].Style.BackColor = Color.Green;
                                row.Cells["cantidad"].Style.BackColor = Color.Green;
                            }
                        }*/
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
