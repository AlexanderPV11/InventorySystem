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
    public class CD_Usuarios
    {
        CD_Conexion Con = new CD_Conexion();

        SqlCommand Cmd;
        SqlDataAdapter Da;
        DataTable Dt;

        //Metodo para agregar un cliente a la DB
        public void AgregarUsuarios(CE_Usuarios Usuarios)
        {
            Cmd = new SqlCommand("SP_Agregar_Usuario", Con.Abrir()); //abrir la conexion con el procedimiento almacenado
            Cmd.CommandType = CommandType.StoredProcedure; //llamar a los procedimientos almacenados
            Cmd.Parameters.Add(new SqlParameter("@Nombre", Usuarios.Nombre));
            Cmd.Parameters.Add(new SqlParameter("@Apellidos", Usuarios.Apellidos));
            Cmd.Parameters.Add(new SqlParameter("@Usuario", Usuarios.Usuario));
            Cmd.Parameters.Add(new SqlParameter("@Password", Usuarios.Password));
            //Cmd.Parameters.Add(new SqlParameter("@Borrado" , Productos.Borrado));
            Cmd.ExecuteNonQuery(); //enviamos los datos

            Con.Cerrar();
        }
    }
}
