using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Data;


namespace WindowsFormsApplication1
{
    class sql
    {
        //Varibles globales
        public static int ID_C;
        public static int ID_V;
        public static decimal T;

        public void crear_cliente(TextBox Nombre, int Telefono, TextBox Mail)
        {
            string connStr = ConfigurationManager.ConnectionStrings["bd"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            string sql = "INSERT INTO clientes(Cliente, Telefono, Correo) VALUES (@p1,@p2,@p3)";
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de Conexión");
            }
            try
            {                
                SqlCommand comand = new SqlCommand(sql, conn);
                comand.Parameters.Add(new SqlParameter("@p1", Nombre.Text));
                comand.Parameters.Add(new SqlParameter("@p2", Telefono));
                comand.Parameters.Add(new SqlParameter("@p3", Mail.Text));
                comand.ExecuteNonQuery();
                MessageBox.Show("Cliente creado");
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al crear el cliente");
            }
            conn.Close();
        }

        public void mod_cliente(int ID, TextBox Nombre, int Telefono, TextBox Mail)
        {
            string connStr = ConfigurationManager.ConnectionStrings["bd"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            string sql = "UPDATE clientes SET Cliente = @p2, Telefono = @p3, Correo = @p4 WHERE ID = @p1";
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de Conexión");
            }
            try
            {
                SqlCommand comand = new SqlCommand(sql, conn);
                comand.Parameters.Add(new SqlParameter("@p1", ID));
                comand.Parameters.Add(new SqlParameter("@p2", Nombre.Text));
                comand.Parameters.Add(new SqlParameter("@p3", Telefono));
                comand.Parameters.Add(new SqlParameter("@p4", Mail.Text));
                comand.ExecuteNonQuery();
                MessageBox.Show("Cliente modificado");
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al modificar el cliente");
            }
            conn.Close();
        }

        public void del_cliente(int ID)
        {
            string connStr = ConfigurationManager.ConnectionStrings["bd"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            string sql = "DELETE FROM clientes WHERE ID = @p1";
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de Conexión");
            }
            try
            {
                SqlCommand comand = new SqlCommand(sql, conn);
                comand.Parameters.Add(new SqlParameter("@p1", ID));
                comand.ExecuteNonQuery();
                MessageBox.Show("Cliente borrado");
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al borrar el cliente");
            }
            conn.Close();
        }

        public void crear_producto(TextBox Prod, float Precio, TextBox Categoria)
        {
            string connStr = ConfigurationManager.ConnectionStrings["bd"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            string sql = "INSERT INTO productos(Nombre, Precio, Categoria) VALUES (@p1,@p2,@p3)";
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de Conexión");
            }
            try
            {
                SqlCommand comand = new SqlCommand(sql, conn);
                comand.Parameters.Add(new SqlParameter("@p1", Prod.Text));
                comand.Parameters.Add(new SqlParameter("@p2", Precio));
                comand.Parameters.Add(new SqlParameter("@p3", Categoria.Text));
                comand.ExecuteNonQuery();
                MessageBox.Show("Producto agregado");
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al crear el producto");
            }
            conn.Close();
        }

        public void mod_prod(int ID, TextBox Nombre, int Precio, TextBox Categoria)
        {
            string connStr = ConfigurationManager.ConnectionStrings["bd"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            string sql = "UPDATE productos SET Nombre = @p2, Precio = @p3, Categoria = @p4 WHERE ID = @p1";
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de Conexión");
            }
            try
            {
                SqlCommand comand = new SqlCommand(sql, conn);
                comand.Parameters.Add(new SqlParameter("@p1", ID));
                comand.Parameters.Add(new SqlParameter("@p2", Nombre.Text));
                comand.Parameters.Add(new SqlParameter("@p3", Precio));
                comand.Parameters.Add(new SqlParameter("@p4", Categoria.Text));
                comand.ExecuteNonQuery();
                MessageBox.Show("Producto modificado");
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al modificar el Producto");
            }
            conn.Close();
        }

        public void del_prod(int ID)
        {
            string connStr = ConfigurationManager.ConnectionStrings["bd"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            string sql = "DELETE FROM productos WHERE ID = @p1";
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de Conexión");
            }
            try
            {
                SqlCommand comand = new SqlCommand(sql, conn);
                comand.Parameters.Add(new SqlParameter("@p1", ID));
                comand.ExecuteNonQuery();
                MessageBox.Show("producto borrado");
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al borrar el producto");
            }
            conn.Close();
        }

        public void cliente_dgv(DataGridView Data)
        {
            string connStr = ConfigurationManager.ConnectionStrings["bd"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            string sql = "SELECT clientes.ID AS 'ID', clientes.Cliente AS 'Nombre', clientes.Telefono AS 'Telefono', clientes.Correo AS 'Email' FROM clientes";
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de Conexión");
            }
            try
            {
                SqlCommand comand = new SqlCommand(sql, conn);
                comand.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(comand);
                DataTable dt = new DataTable();
                da.Fill(dt);
                Data.DataSource = dt;                   
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al traer la tabla");
            }
            conn.Close();
        }

        public void productos_dgv(DataGridView Data)
        {
            string connStr = ConfigurationManager.ConnectionStrings["bd"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            string sql = "SELECT productos.ID AS 'ID', productos.Nombre AS 'Producto', productos.Precio AS 'Precio', productos.Categoria AS 'Categoria' FROM productos";
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de Conexión");
            }
            try
            {
                SqlCommand comand = new SqlCommand(sql, conn);
                comand.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(comand);
                DataTable dt = new DataTable();
                da.Fill(dt);
                Data.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al traer la tabla");
            }
            conn.Close();
        }

        public void buscarcliente_dgv(DataGridView Data, TextBox Nom, TextBox Mail, TextBox Tel)
        {
            string connStr = ConfigurationManager.ConnectionStrings["bd"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            string sql = "select clientes.ID, clientes.Cliente AS 'Nombre', clientes.Correo AS 'Email', clientes.Telefono From clientes where Cliente like '%' + @p1 +'%' or Correo like '%'+@p2+'%' or Telefono like '%'+@p3+'%';";
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de Conexión");
            }
            try
            {
                SqlCommand comand = new SqlCommand(sql, conn);
                comand.Parameters.Add(new SqlParameter("@p1", Nom.Text));
                comand.Parameters.Add(new SqlParameter("@p2", Mail.Text));
                comand.Parameters.Add(new SqlParameter("@p3", Tel.Text));
                comand.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(comand);
                DataTable dt = new DataTable();
                da.Fill(dt);
                Data.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al traer la tabla");
            }
            conn.Close();
        }

        public void buscarprod_dgv(DataGridView Data, TextBox Nom, TextBox Mail, TextBox Tel)
        {
            string connStr = ConfigurationManager.ConnectionStrings["bd"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            string sql = "select productos.ID, productos.Nombre AS 'Producto', productos.Precio AS 'Precio', productos.Categoria From productos where Nombre like '%'+@p1+'%' or Precio like '%'+@p3+'%' or Categoria like '%'+@p2+'%';";
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de Conexión");
            }
            try
            {
                SqlCommand comand = new SqlCommand(sql, conn);
                comand.Parameters.Add(new SqlParameter("@p1", Nom.Text));
                comand.Parameters.Add(new SqlParameter("@p2", Mail.Text));
                comand.Parameters.Add(new SqlParameter("@p3", Tel.Text));
                comand.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(comand);
                DataTable dt = new DataTable();
                da.Fill(dt);
                Data.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al traer la tabla");
            }
            conn.Close();
        }

        public void buscarventas_dgv(DataGridView Data, TextBox Nom, String Fecha)
        {
            string connStr = ConfigurationManager.ConnectionStrings["bd"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            string sql = "select ventas.id, clientes.Cliente, ventas.Fecha, ventas.Total from ventas inner join clientes on clientes.ID = ventas.IDCliente WHERE ventas.Fecha IS NOT NULL and clientes.Cliente like '%'+@p1+'%' or ventas.Fecha like '%'+@p2+'%';";
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de Conexión");
            }
            try
            {
                SqlCommand comand = new SqlCommand(sql, conn);
                comand.Parameters.Add(new SqlParameter("@p1", Nom.Text));
                comand.Parameters.Add(new SqlParameter("@p2", Fecha));
                comand.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(comand);
                DataTable dt = new DataTable();
                da.Fill(dt);
                Data.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al traer la tabla");
            }
            conn.Close();
        }


        //VENTAS

        public void crear_venta(int IDCliente)
        {
            string connStr = ConfigurationManager.ConnectionStrings["bd"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            string sql = "INSERT INTO ventas(IDCliente) VALUES (@p1)";
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de Conexión");
            }
            try
            {
                SqlCommand comand = new SqlCommand(sql, conn);
                comand.Parameters.Add(new SqlParameter("@p1", IDCliente));
                comand.ExecuteNonQuery();
                MessageBox.Show("Venta iniciada, por favor llene el carrito"); 
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al seleccionar el cliente");
            }
            conn.Close();
        }

        public void obtener_IDV(int IDC)
        {
            string connStr = ConfigurationManager.ConnectionStrings["bd"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            string sql = "SELECT * FROM ventas WHERE IDCliente = @p1 and Total IS NULL;";
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de Conexión");
            }
            try
            {
                SqlCommand comand = new SqlCommand(sql, conn);
                comand.Parameters.Add(new SqlParameter("@p1", IDC));
                comand.ExecuteNonQuery();
                SqlDataAdapter adp = new SqlDataAdapter(comand);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                DataRow datos = dt.Rows[0];
                ID_V = Convert.ToInt32(datos["ID"]);
                MessageBox.Show("Se pudo obtener el id " + Convert.ToString(ID_V));
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al seleccionar el cliente");
            }
            conn.Close();
        }

        public void carrito(int IDVenta, int IDProd, decimal Precio, int Cantidad, decimal PrecioTotal)
        {
            string connStr = ConfigurationManager.ConnectionStrings["bd"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            string sql = "INSERT INTO ventasitems(IDVenta,IDProducto,PrecioUnitario,Cantidad,PrecioTotal) VALUES (@p1,@p2,@p3,@p4,@p5)";
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de Conexión");
            }
            try
            {
                SqlCommand comand = new SqlCommand(sql, conn);
                comand.Parameters.Add(new SqlParameter("@p1", IDVenta));
                comand.Parameters.Add(new SqlParameter("@p2", IDProd));
                comand.Parameters.Add(new SqlParameter("@p3", Precio));
                comand.Parameters.Add(new SqlParameter("@p4", Cantidad));
                comand.Parameters.Add(new SqlParameter("@p5", PrecioTotal));
                comand.ExecuteNonQuery();
                MessageBox.Show("Producto agregado al carrito");
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al agregar el producto");
            }
            conn.Close();
        }

        public void carrito_dgv(DataGridView Data, int IDV)
        {
            string connStr = ConfigurationManager.ConnectionStrings["bd"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            string sql = "SELECT ventasitems.ID, ventasitems.IDVenta, productos.Nombre, productos.Precio, ventasitems.Cantidad, ventasitems.PrecioTotal FROM ventasitems INNER JOIN productos ON productos.ID = ventasitems.IDProducto WHERE ventasitems.IDVenta = @p1;";
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de Conexión");
            }
            try
            {
                SqlCommand comand = new SqlCommand(sql, conn);
                comand.Parameters.Add(new SqlParameter("@p1", IDV));
                comand.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(comand);
                DataTable dt = new DataTable();
                da.Fill(dt);
                Data.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al traer la tabla");
            }
            conn.Close();
        }
        
        public void obtener_total(int IDV)
        {
            string connStr = ConfigurationManager.ConnectionStrings["bd"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            string sql = "SELECT SUM(ventasitems.PrecioTotal) as 'Total' FROM ventasitems WHERE ventasitems.IDVenta = @p1;";
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de Conexión");
            }
            try
            {
                SqlCommand comand = new SqlCommand(sql, conn);
                comand.Parameters.Add(new SqlParameter("@p1", IDV));
                comand.ExecuteNonQuery();
                SqlDataAdapter adp = new SqlDataAdapter(comand);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                DataRow datos = dt.Rows[0];
                T = Convert.ToInt32(datos["Total"]);
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            conn.Close();
        }

        public void del_venta(int ID)
        {
            string connStr = ConfigurationManager.ConnectionStrings["bd"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            string sql = "DELETE FROM ventasitems WHERE ID = @p1";
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de Conexión");
            }
            try
            {
                SqlCommand comand = new SqlCommand(sql, conn);
                comand.Parameters.Add(new SqlParameter("@p1", ID));
                comand.ExecuteNonQuery();
                MessageBox.Show("Cliente borrado");
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al borrar el cliente");
            }
            conn.Close();
        }

        public void concretar_venta(int ID_V, string Fecha, int Total)
        {
            string connStr = ConfigurationManager.ConnectionStrings["bd"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            string sql = "UPDATE ventas SET Fecha = @p2, Total = @p3 WHERE ID = @p1";
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de Conexión");
            }
            try
            {
                SqlCommand comand = new SqlCommand(sql, conn);
                comand.Parameters.Add(new SqlParameter("@p1", ID_V));
                comand.Parameters.Add(new SqlParameter("@p2", Fecha));
                comand.Parameters.Add(new SqlParameter("@p3", Total));
                comand.ExecuteNonQuery();
                MessageBox.Show("Venta finalizada");
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            conn.Close();
        }

        public void ventas_dgv(DataGridView Data)
        {
            string connStr = ConfigurationManager.ConnectionStrings["bd"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            string sql = "select ventas.id, clientes.Cliente, ventas.Fecha, ventas.Total from ventas inner join clientes on clientes.ID = ventas.IDCliente WHERE ventas.Fecha IS NOT NULL;";
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de Conexión");
            }
            try
            {
                SqlCommand comand = new SqlCommand(sql, conn);
                comand.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(comand);
                DataTable dt = new DataTable();
                da.Fill(dt);
                Data.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al traer la tabla");
            }
            conn.Close();
        }

        public void historial_dgv(int ID, DataGridView Data)
        {
            string connStr = ConfigurationManager.ConnectionStrings["bd"].ConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            string sql = "SELECT ventasitems.ID, ventasitems.IDVenta, productos.Nombre, productos.Precio, ventasitems.Cantidad, ventasitems.PrecioTotal FROM ventasitems INNER JOIN productos ON productos.ID = ventasitems.IDProducto WHERE ventasitems.IDVenta = @p1;";
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de Conexión");
            }
            try
            {
                SqlCommand comand = new SqlCommand(sql, conn);
                comand.Parameters.Add(new SqlParameter("@p1", ID));
                comand.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(comand);
                DataTable dt = new DataTable();
                da.Fill(dt);
                Data.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al traer la tabla");
            }
            conn.Close();
        }



    }
}
