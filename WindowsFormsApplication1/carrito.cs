using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class carrito : Form
    {
        public carrito()
        {
            InitializeComponent();
            consultas.carrito_dgv(dgv1,sql.ID_V);
            dgv1.Columns["ID"].Visible = false;
            dgv1.Columns["IDVenta"].Visible = false;
            consultas.obtener_total(sql.ID_V);
            label3.Text = Convert.ToString(sql.T);
            button2.Enabled = false;
        }
        sql consultas = new sql();

        private void btn_exit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro que quiere salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            string Fecha = Convert.ToString(now);
            consultas.concretar_venta(sql.ID_V,Fecha, Convert.ToInt32(label3.Text));
            sql.ID_C = 0;
            sql.ID_V = 0;
            sql.T = 0;
            menu.verf = false;            
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataGridViewRow datos = dgv1.CurrentRow;
            int ID = Convert.ToInt32(datos.Cells["ID"].Value);
            consultas.del_venta(ID);
            dgv1.DataSource = null;
            dgv1.Rows.Clear();
            consultas.carrito_dgv(dgv1, sql.ID_V);
            consultas.obtener_total(sql.ID_V);
            label3.Text = Convert.ToString(sql.T);
            dgv1.Columns["ID"].Visible = false;
            dgv1.Columns["IDVenta"].Visible = false;
        }

        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            button2.Enabled = true;
        }
    }
}
