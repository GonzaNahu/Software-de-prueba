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
    public partial class ventas : Form
    {
        public ventas()
        {
            InitializeComponent();
            button1.Enabled = false;
            consultas.ventas_dgv(dgv1);
            dgv1.Columns["ID"].Visible = false;
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
            DataGridViewRow datos = dgv1.CurrentRow;
            int ID = Convert.ToInt32(datos.Cells["ID"].Value);
            consultas.historial_dgv(ID,dgv2);
            dgv2.Columns["ID"].Visible = false;
            dgv2.Columns["IDVenta"].Visible = false;
        }

        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            button1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String FechaDesde = Convert.ToString(dtpFecha.Value.Year + "-" + dtpFecha.Value.Month + "-" + dtpFecha.Value.Day);
            dgv1.DataSource = null;
            dgv1.Rows.Clear();
            consultas.buscarventas_dgv(dgv1, textBox1, FechaDesde);
            dgv1.Columns["ID"].Visible = false;
        }

        private void btnref1_Click(object sender, EventArgs e)
        {
            dgv1.DataSource = null;
            dgv1.Rows.Clear();
            consultas.ventas_dgv(dgv1);
            dgv1.Columns["ID"].Visible = false;
        }
    }
}
