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
    public class CD_Clientes
    {
        CD_Conexion Con = new CD_Conexion();

        SqlCommand Cmd;
        SqlDataAdapter Da;
        DataTable Dt;

        //Metodo para agregar un cliente a la DB
        public void AgregarClientes(CE_Clientes Clientes)
        {
            Cmd = new SqlCommand("AgregarCliente", Con.Abrir()); //abrir la conexion con el procedimiento almacenado
            Cmd.CommandType = CommandType.StoredProcedure; //llamar a los procedimientos almacenados
            Cmd.Parameters.Add(new SqlParameter("@Codigo", Clientes.Codigo));
            Cmd.Parameters.Add(new SqlParameter("@Nombre", Clientes.Nombre));
            Cmd.Parameters.Add(new SqlParameter("@Cedula", Clientes.Cedula));
            Cmd.Parameters.Add(new SqlParameter("@Direccion", Clientes.Direccion));
            Cmd.Parameters.Add(new SqlParameter("@Telefono", Clientes.Telefono));
            Cmd.Parameters.Add(new SqlParameter("@Email", Clientes.Email));
            Cmd.Parameters.Add(new SqlParameter("@Borrado", Clientes.Borrado));
            //Cmd.Parameters.Add(new SqlParameter("@Borrado" , Productos.Borrado));
            Cmd.ExecuteNonQuery(); //enviamos los datos

            Con.Cerrar();
        }

        //Metodo para editar un proveedor a la DB
        public void EditarClientes(CE_Clientes Clientes)
        {
            Cmd = new SqlCommand("EditarCliente", Con.Abrir()); //abrir la conexion con el procedimiento almacenado
            Cmd.CommandType = CommandType.StoredProcedure; //llamar a los procedimientos almacenados
            Cmd.Parameters.Add(new SqlParameter("@Id_Cliente", Clientes.Id_Cliente));
            Cmd.Parameters.Add(new SqlParameter("@Codigo", Clientes.Codigo));
            Cmd.Parameters.Add(new SqlParameter("@Nombre", Clientes.Nombre));
            Cmd.Parameters.Add(new SqlParameter("@Cedula", Clientes.Cedula));
            Cmd.Parameters.Add(new SqlParameter("@Direccion", Clientes.Direccion));
            Cmd.Parameters.Add(new SqlParameter("@Telefono", Clientes.Telefono));
            Cmd.Parameters.Add(new SqlParameter("@Email", Clientes.Email));
            Cmd.Parameters.Add(new SqlParameter("@Borrado", Clientes.Borrado));
            //Cmd.Parameters.Add(new SqlParameter("@Borrado", Productos.Borrado));
            Cmd.ExecuteNonQuery(); //enviamos los datos

            Con.Cerrar();
        }

        //Metodo para eliminar un cliente a la DB
        public void EliminarClientes(CE_Clientes Clientes)
        {


            Cmd = new SqlCommand("EliminarCliente", Con.Abrir()); //abrir la conexion con el procedimiento almacenado
            Cmd.CommandType = CommandType.StoredProcedure; //llamar a los procedimientos almacenados
            Cmd.Parameters.Add(new SqlParameter("@Id_Cliente", Clientes.Id_Cliente));
            Cmd.ExecuteNonQuery(); //enviamos los datos

            MessageBox.Show("¡El Cliente fue eliminado con éxito!", "Eliminar Cliente", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Con.Cerrar();

        }

        //Metodo para buscar un cliente por el codigo
        public DataTable Buscar_cliente_codigo(CE_Clientes Clientes)
        {
            Dt = new DataTable("Codigo");
            Cmd = new SqlCommand("Buscar_cliente_codigo", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(new SqlParameter("@Buscar", Clientes.Buscar));

            Da = new SqlDataAdapter(Cmd);
            Da.Fill(Dt);

            Con.Cerrar();
            return Dt;
        }

        //Metodo para buscar un cliente por el nombre
        public DataTable Buscar_cliente_nombre(CE_Clientes Clientes)
        {
            Dt = new DataTable("Nombre");
            Cmd = new SqlCommand("Buscar_cliente_nombre", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(new SqlParameter("@Buscar", Clientes.Buscar));

            Da = new SqlDataAdapter(Cmd);
            Da.Fill(Dt);

            Con.Cerrar();
            return Dt;
        }
        //Metodo para buscar un cliente por el cedula
        public DataTable Buscar_cliente_cedula(CE_Clientes Clientes)
        {
            Dt = new DataTable("Cedula");
            Cmd = new SqlCommand("Buscar_cliente_cedula", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(new SqlParameter("@Buscar", Clientes.Buscar));

            Da = new SqlDataAdapter(Cmd);
            Da.Fill(Dt);

            Con.Cerrar();
            return Dt;
        }
    }
}
