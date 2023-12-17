using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CapaEntidad;
using System.Data;
using System.Windows.Forms;

namespace CapaDatos
{
    public class CD_Productos
    {
        CD_Conexion Con = new CD_Conexion();

        SqlCommand Cmd;
        SqlDataAdapter Da;
        DataTable Dt;

        //Metodo para agregar un producto a la DB
        public void AgregarProductos(CE_Productos Productos)
        {
            Cmd = new SqlCommand("AgregarProducto", Con.Abrir()); //abrir la conexion con el procedimiento almacenado
            Cmd.CommandType = CommandType.StoredProcedure; //llamar a los procedimientos almacenados
            Cmd.Parameters.Add(new SqlParameter("@CodigoBarra", Productos.CodigoBarra));
            Cmd.Parameters.Add(new SqlParameter("@Codigo", Productos.Codigo));
            Cmd.Parameters.Add(new SqlParameter("@Nombre", Productos.Nombre));
            Cmd.Parameters.Add(new SqlParameter("@Categoria", Productos.Categoria));
            Cmd.Parameters.Add(new SqlParameter("@Descripcion", Productos.Descripcion));
            Cmd.Parameters.Add(new SqlParameter("@Presentacion", Productos.Presentacion));
            Cmd.Parameters.Add(new SqlParameter("@Costo_unitario", Productos.Costo_unitario));
            Cmd.Parameters.Add(new SqlParameter("@Precio_venta", Productos.Precio_venta));
            Cmd.Parameters.Add(new SqlParameter("@Tipo_cargo", Productos.Tipo_cargo));
            //Cmd.Parameters.Add(new SqlParameter("@Borrado" , Productos.Borrado));
            Cmd.ExecuteNonQuery(); //enviamos los datos

            Con.Cerrar();
        }

        //Metodo para editar un producto a la DB
        public void EditarProductos(CE_Productos Productos)
        {
            Cmd = new SqlCommand("EditarProducto", Con.Abrir()); //abrir la conexion con el procedimiento almacenado
            Cmd.CommandType = CommandType.StoredProcedure; //llamar a los procedimientos almacenados
            Cmd.Parameters.Add(new SqlParameter("@Id_Productos", Productos.Id_Productos));
            Cmd.Parameters.Add(new SqlParameter("@CodigoBarra", Productos.CodigoBarra));
            Cmd.Parameters.Add(new SqlParameter("@Codigo", Productos.Codigo));
            Cmd.Parameters.Add(new SqlParameter("@Nombre", Productos.Nombre));
            Cmd.Parameters.Add(new SqlParameter("@Descripcion", Productos.Descripcion));
            Cmd.Parameters.Add(new SqlParameter("@Presentacion", Productos.Presentacion));
            Cmd.Parameters.Add(new SqlParameter("@Costo_unitario", Productos.Costo_unitario));
            Cmd.Parameters.Add(new SqlParameter("@Precio_venta", Productos.Precio_venta));
            Cmd.Parameters.Add(new SqlParameter("@Tipo_cargo", Productos.Tipo_cargo));
            //Cmd.Parameters.Add(new SqlParameter("@Borrado", Productos.Borrado));
            Cmd.Parameters.Add(new SqlParameter("@Categoria", Productos.Categoria));
            Cmd.ExecuteNonQuery(); //enviamos los datos

            Con.Cerrar();
        }

        //Metodo para eliminar un producto a la DB
        public void EliminarProductos(CE_Productos Productos)
        {
            int Existencia = 0;
            Cmd = new SqlCommand("select Cantidad from Inventario where Id_Invetario=" + Productos.Id_Productos + "", Con.Abrir());
            Cmd.CommandType = CommandType.Text;

            SqlDataReader Dr = Cmd.ExecuteReader();
            if (Dr.Read())
            {
                Existencia = Convert.ToInt32(Dr["Cantidad"].ToString());
            }
            Dr.Close();

            if (Existencia !=0)
            {
                MessageBox.Show("El producto contiene existencias en el inventario", "Eliminar producto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                Cmd = new SqlCommand("EliminarProducto", Con.Abrir()); //abrir la conexion con el procedimiento almacenado
                Cmd.CommandType = CommandType.StoredProcedure; //llamar a los procedimientos almacenados
                Cmd.Parameters.Add(new SqlParameter("@Id_Productos", Productos.Id_Productos));
                Cmd.ExecuteNonQuery(); //enviamos los datos

                MessageBox.Show("¡El producto fue eliminado con éxito!", "Eliminar producto", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Con.Cerrar();
            }
        }

        //Metodo para buscar un producto por el codigo
        public DataTable Buscar_producto_codigo(CE_Productos Productos)
        {
            Dt = new DataTable("Codigo");
            Cmd = new SqlCommand("Buscar_producto_codigo", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(new SqlParameter("@Buscar", Productos.Buscar));

            Da = new SqlDataAdapter(Cmd);
            Da.Fill(Dt);

            Con.Cerrar();
            return Dt;
        }

        public DataTable Buscar_producto_codigoBarra(CE_Productos Productos)
        {
            Dt = new DataTable("Codigo");
            Cmd = new SqlCommand("Buscar_producto_codigoBarra", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(new SqlParameter("@Buscar", Productos.Buscar));

            Da = new SqlDataAdapter(Cmd);
            Da.Fill(Dt);

            Con.Cerrar();
            return Dt;
        }

        //Metodo para buscar un producto por el nombre
        public DataTable Buscar_producto_nombre(CE_Productos Productos)
        {
            Dt = new DataTable("Nombre");
            Cmd = new SqlCommand("Buscar_producto_nombre", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(new SqlParameter("@Buscar", Productos.Buscar));

            Da = new SqlDataAdapter(Cmd);
            Da.Fill(Dt);

            Con.Cerrar();
            return Dt;
        }
        //Metodo para buscar un producto por el presentacion
        public DataTable Buscar_producto_presentacion(CE_Productos Productos)
        {
            Dt = new DataTable("Presentacion");
            Cmd = new SqlCommand("Buscar_producto_presentacion", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(new SqlParameter("@Buscar", Productos.Buscar));

            Da = new SqlDataAdapter(Cmd);
            Da.Fill(Dt);

            Con.Cerrar();
            return Dt;
        }

        public void Bucar_Productos_por_CodigoBarra(string Nombre, TextBox Control, string xTBox)
        {
            Cmd = new SqlCommand("Buscar_Producto_por_CodigoBarra", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(new SqlParameter("@xTBox", xTBox));
            SqlDataReader Dr = Cmd.ExecuteReader();
            if (Dr.Read())
            {
                Control.Text = Dr[Nombre].ToString();
            }
            Dr.Close();

            Con.Cerrar();
        }

        //Metodo para buscar un producto en el Inventarios por el nombre
        public DataTable Buscar_inventario_nombre(CE_Productos Productos)
        {
            Dt = new DataTable("Nombre");
            Cmd = new SqlCommand("Buscar_inventario_nombre", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(new SqlParameter("@Buscar", Productos.Buscar));

            Da = new SqlDataAdapter(Cmd);
            Da.Fill(Dt);

            Con.Cerrar();
            return Dt;
        }
    }
}
