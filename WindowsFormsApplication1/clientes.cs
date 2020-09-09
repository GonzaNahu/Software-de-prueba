using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    public partial class clientes : Form
    {
        public clientes()
        {
            InitializeComponent();
        }

        Teclado teclado = new Teclado();
        sql sql = new sql();

        private void btn_exit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Esta seguro que quiere salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void txttel_KeyPress(object sender, KeyPressEventArgs e)
        {
            teclado.Teclado_SinEspacio(e);
            teclado.Teclado_SoloNumeros(e);
        }

        private void txtmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            teclado.Teclado_SinEspacio(e);
        }

        private void btn_ag_Click(object sender, EventArgs e)
        {
            if (txtname.Text == "")
            {
                Error.SetError(txtname, "Ingrese el nombre del cliente");
                txtname.Focus();
                return;
            }
            Error.SetError(txtname, "");
            if (txttel.Text == "")
            {
                Error.SetError(txttel, "Ingrese el telefono del cliente");
                txttel.Focus();
                return;
            }
            Error.SetError(txttel, "");
            if (txtmail.Text == "")
            {
                Error.SetError(txtmail, "Ingrese el mail del cliente");
                txtmail.Focus();
                return;
            }
            Error.SetError(txtmail, "");
            sql.crear_cliente(txtname, Convert.ToInt32(txttel.Text), txtmail);
            this.Close();
        }

        private void btnmod_Click(object sender, EventArgs e)
        {
            if (txtname.Text == "")
            {
                Error.SetError(txtname, "Ingrese el nombre del cliente");
                txtname.Focus();
                return;
            }
            Error.SetError(txtname, "");
            if (txttel.Text == "")
            {
                Error.SetError(txttel, "Ingrese el telefono del cliente");
                txttel.Focus();
                return;
            }
            Error.SetError(txttel, "");
            if (txtmail.Text == "")
            {
                Error.SetError(txtmail, "Ingrese el mail del cliente");
                txtmail.Focus();
                return;
            }
            Error.SetError(txtmail, "");
            sql.mod_cliente(Convert.ToInt32(label4.Text),txtname, Convert.ToInt32(txttel.Text), txtmail);
            this.Close();
        }
    }
}
