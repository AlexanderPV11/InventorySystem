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
    public class CD_Proveedores
    {
        CD_Conexion Con = new CD_Conexion();

        SqlCommand Cmd;
        SqlDataAdapter Da;
        DataTable Dt;

        //Metodo para agregar un proveedor a la DB
        public void AgregarProveedores(CE_Proveedores Proveedores)
        {
            Cmd = new SqlCommand("AgregarProveedor", Con.Abrir()); //abrir la conexion con el procedimiento almacenado
            Cmd.CommandType = CommandType.StoredProcedure; //llamar a los procedimientos almacenados
            Cmd.Parameters.Add(new SqlParameter("@Codigo", Proveedores.Codigo));
            Cmd.Parameters.Add(new SqlParameter("@Nombre", Proveedores.Nombre));
            Cmd.Parameters.Add(new SqlParameter("@RUC_Proveedor", Proveedores.RUC_Proveedor));
            Cmd.Parameters.Add(new SqlParameter("@Direccion", Proveedores.Direccion));
            Cmd.Parameters.Add(new SqlParameter("@Telefono", Proveedores.Telefono));
            Cmd.Parameters.Add(new SqlParameter("@Email", Proveedores.Email));
            //Cmd.Parameters.Add(new SqlParameter("@Borrado" , Productos.Borrado));
            Cmd.ExecuteNonQuery(); //enviamos los datos

            Con.Cerrar();
        }

        //Metodo para editar un proveedor a la DB
        public void EditarProveedores(CE_Proveedores Proveedores)
        {
            Cmd = new SqlCommand("EditarProveedor", Con.Abrir()); //abrir la conexion con el procedimiento almacenado
            Cmd.CommandType = CommandType.StoredProcedure; //llamar a los procedimientos almacenados
            Cmd.Parameters.Add(new SqlParameter("@Id_Proveedor", Proveedores.Id_Proveedor));
            Cmd.Parameters.Add(new SqlParameter("@Codigo", Proveedores.Codigo));
            Cmd.Parameters.Add(new SqlParameter("@Nombre", Proveedores.Nombre));
            Cmd.Parameters.Add(new SqlParameter("@RUC_Proveedor", Proveedores.RUC_Proveedor));
            Cmd.Parameters.Add(new SqlParameter("@Direccion", Proveedores.Direccion));
            Cmd.Parameters.Add(new SqlParameter("@Telefono", Proveedores.Telefono));
            Cmd.Parameters.Add(new SqlParameter("@Email", Proveedores.Email));
            //Cmd.Parameters.Add(new SqlParameter("@Borrado", Productos.Borrado));
            Cmd.ExecuteNonQuery(); //enviamos los datos

            Con.Cerrar();
        }

        //Metodo para eliminar un proveedor a la DB
        public void EliminarProveedores(CE_Proveedores Proveedores)
        {
            
            
                Cmd = new SqlCommand("EliminarProveedor", Con.Abrir()); //abrir la conexion con el procedimiento almacenado
                Cmd.CommandType = CommandType.StoredProcedure; //llamar a los procedimientos almacenados
                Cmd.Parameters.Add(new SqlParameter("@Id_Proveedor", Proveedores.Id_Proveedor));
                Cmd.ExecuteNonQuery(); //enviamos los datos

                MessageBox.Show("¡El proveedor fue eliminado con éxito!", "Eliminar Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Con.Cerrar();
            
        }

        //Metodo para buscar un producto por el codigo
        public DataTable Buscar_proveedor_codigo(CE_Proveedores Proveedores)
        {
            Dt = new DataTable("Codigo");
            Cmd = new SqlCommand("Buscar_proveedor_codigo", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(new SqlParameter("@Buscar", Proveedores.Buscar));

            Da = new SqlDataAdapter(Cmd);
            Da.Fill(Dt);

            Con.Cerrar();
            return Dt;
        }

        //Metodo para buscar un producto por el nombre
        public DataTable Buscar_proveedor_nombre(CE_Proveedores Proveedores)
        {
            Dt = new DataTable("Nombre");
            Cmd = new SqlCommand("Buscar_proveedor_nombre", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(new SqlParameter("@Buscar", Proveedores.Buscar));

            Da = new SqlDataAdapter(Cmd);
            Da.Fill(Dt);

            Con.Cerrar();
            return Dt;
        }
        //Metodo para buscar un producto por el presentacion
        public DataTable Buscar_proveedores_RUC(CE_Proveedores Proveedores)
        {
            Dt = new DataTable("RUC_Proveedor");
            Cmd = new SqlCommand("Buscar_proveedor_RUC", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(new SqlParameter("@Buscar", Proveedores.Buscar));

            Da = new SqlDataAdapter(Cmd);
            Da.Fill(Dt);

            Con.Cerrar();
            return Dt;
        }
    }
}
