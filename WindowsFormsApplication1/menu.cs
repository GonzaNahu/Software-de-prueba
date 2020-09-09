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
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
            btnmod1.Enabled = false;
            btndelete1.Enabled = false;
            button3.Enabled = false;
            button2.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            btncarr.Enabled = false;
            textBox3.Enabled = false;
            consultas.cliente_dgv(dgv1);
            dgv1.Columns["ID"].Visible = false;
            consultas.productos_dgv(dgv2);
            dgv2.Columns["ID"].Visible = false;
        }
        public static bool verf = false;
        sql consultas = new sql();
        Teclado teclas = new Teclado();
        private void btn_exit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro que quiere salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void añadirClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clientes abrir = new clientes();
            abrir.btnmod.Visible = false;
            abrir.Show();
        }

        private void añadirProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pruductos abrir = new pruductos();
            abrir.btnmod.Visible = false;
            abrir.Show();
        }

        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnmod1.Enabled = true;
            btndelete1.Enabled = true;
            button5.Enabled = Visible;
        }

        private void btnmod1_Click(object sender, EventArgs e)
        {
            clientes abrir = new clientes();
            DataGridViewRow datos = dgv1.CurrentRow;
            int ID = Convert.ToInt32(datos.Cells["ID"].Value);
            abrir.label4.Text = Convert.ToString(ID);
            abrir.txtname.Text = datos.Cells["Nombre"].Value.ToString();
            abrir.txttel.Text = datos.Cells["Telefono"].Value.ToString();
            abrir.txtmail.Text = datos.Cells["Email"].Value.ToString();
            abrir.btn_ag.Visible = false;
            abrir.btnmod.Visible = true;
            abrir.Show();
        }

        private void btnref1_Click(object sender, EventArgs e)
        {
            dgv1.DataSource = null;
            dgv1.Rows.Clear();
            consultas.cliente_dgv(dgv1);
            dgv1.Columns["ID"].Visible = false;
        }

        private void btndelete1_Click(object sender, EventArgs e)
        {
            DataGridViewRow datos = dgv1.CurrentRow;
            int ID = Convert.ToInt32(datos.Cells["ID"].Value);
            consultas.del_cliente(ID);
            dgv1.DataSource = null;
            dgv1.Rows.Clear();
            consultas.cliente_dgv(dgv1);
            dgv1.Columns["ID"].Visible = false;
        }

        private void buscar_Click(object sender, EventArgs e)
        {
            dgv1.DataSource = null;
            dgv1.Rows.Clear();
            consultas.buscarcliente_dgv(dgv1, textBox1,textBox4,textBox5);
            dgv1.Columns["ID"].Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pruductos abrir = new pruductos();
            DataGridViewRow datos = dgv2.CurrentRow;
            int ID = Convert.ToInt32(datos.Cells["ID"].Value);
            abrir.label4.Text = Convert.ToString(ID);
            abrir.txtname.Text = datos.Cells["Producto"].Value.ToString();
            abrir.txttel.Text = datos.Cells["Precio"].Value.ToString();
            abrir.txtmail.Text = datos.Cells["Categoria"].Value.ToString();
            abrir.btn_ag.Visible = false;
            abrir.btnmod.Visible = true;
            abrir.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgv2.DataSource = null;
            dgv2.Rows.Clear();
            consultas.productos_dgv(dgv2);
            dgv2.Columns["ID"].Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataGridViewRow datos = dgv2.CurrentRow;
            int ID = Convert.ToInt32(datos.Cells["ID"].Value);
            consultas.del_prod(ID);
            dgv2.DataSource = null;
            dgv2.Rows.Clear();
            consultas.productos_dgv(dgv2);
            dgv2.Columns["ID"].Visible = false;
        }

        private void dgv2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            button3.Enabled = true;
            button2.Enabled = true;
            if (verf == true)
            {
                btncarr.Enabled = true;
                textBox3.Enabled = true;
                button6.Enabled = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seleccionar cliente para proceder a hacer una venta?", "Seleccionar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DataGridViewRow datos = dgv1.CurrentRow;
                sql.ID_C = Convert.ToInt32(datos.Cells["ID"].Value);
                consultas.crear_venta(sql.ID_C);
                consultas.obtener_IDV(sql.ID_C);
                verf = true;
            }
        }

        private void btncarr_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                Error.SetError(textBox3, "ingrese un valor valido");
                textBox3.Focus();
                return;
            }
            Error.SetError(textBox3, "");
            if (Convert.ToInt32(textBox3.Text) <= 0)
            {
                Error.SetError(textBox3, "ingrese un valor valido");
                textBox3.Focus();
                return;
            }
            Error.SetError(textBox3, "");
            DataGridViewRow datos = dgv2.CurrentRow;
            int IDP = Convert.ToInt32(datos.Cells["ID"].Value);
            decimal Precio = Convert.ToDecimal(datos.Cells["Precio"].Value);
            decimal PTotal = Convert.ToDecimal(datos.Cells["Precio"].Value) * Convert.ToDecimal(textBox3.Text);

            consultas.carrito(sql.ID_V,IDP,Precio,Convert.ToInt32(textBox3.Text),PTotal);

        }

        private void button6_Click(object sender, EventArgs e)
        {
            carrito abrir = new carrito();
            abrir.Show();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            teclas.Teclado_SoloNumeros(e);
        }

        private void verHistorialDeVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ventas abrir = new ventas();
            abrir.Show();
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            teclas.Teclado_SoloNumeros(e);
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            teclas.Teclado_SoloNumeros(e);
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            teclas.Teclado_SinEspacio(e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dgv2.DataSource = null;
            dgv2.Rows.Clear();
            consultas.buscarprod_dgv(dgv2, textBox7, textBox2, textBox6);
            dgv2.Columns["ID"].Visible = false;
        }
    }
}
