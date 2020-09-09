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
    public partial class pruductos : Form
    {
        public pruductos()
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
        }

        private void btn_ag_Click(object sender, EventArgs e)
        {
            if (txtname.Text == "")
            {
                Error.SetError(txtname, "Ingrese el nombre del producto");
                txtname.Focus();
                return;
            }
            Error.SetError(txtname, "");
            if (txttel.Text == "")
            {
                Error.SetError(txttel, "Ingrese el precio del producto");
                txttel.Focus();
                return;
            }
            Error.SetError(txttel, "");
            if (txtmail.Text == "")
            {
                Error.SetError(txtmail, "Ingrese la categoria del producto");
                txtmail.Focus();
                return;
            }
            Error.SetError(txtmail, "");
            sql.crear_producto(txtname, Convert.ToInt32(txttel.Text), txtmail);
            this.Close();
        }

        private void btnmod_Click(object sender, EventArgs e)
        {
            if (txtname.Text == "")
            {
                Error.SetError(txtname, "Ingrese el nombre del producto");
                txtname.Focus();
                return;
            }
            Error.SetError(txtname, "");
            if (txttel.Text == "")
            {
                Error.SetError(txttel, "Ingrese el precio del producto");
                txttel.Focus();
                return;
            }
            Error.SetError(txttel, "");
            if (txtmail.Text == "")
            {
                Error.SetError(txtmail, "Ingrese la categoria del producto");
                txtmail.Focus();
                return;
            }
            Error.SetError(txtmail, "");
            sql.mod_prod(Convert.ToInt32(label4.Text), txtname, Convert.ToInt32(txttel.Text), txtmail);
            this.Close();
        }
    }
}
