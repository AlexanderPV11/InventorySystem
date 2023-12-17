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
    public class CD_Categoria
    {
        CD_Conexion Con = new CD_Conexion();

        SqlCommand Cmd;
        SqlDataAdapter Da;
        DataTable Dt;

        //Metodo para agregar una categoria a la DB
        public void AgregarCategoria(CE_Categoria Categorias)
        {
            Cmd = new SqlCommand("AgregarCategoria", Con.Abrir()); //abrir la conexion con el procedimiento almacenado
            Cmd.CommandType = CommandType.StoredProcedure; //llamar a los procedimientos almacenados
            Cmd.Parameters.Add(new SqlParameter("@NombreCat", Categorias.NombreCat));
            Cmd.ExecuteNonQuery(); //enviamos los datos

            Con.Cerrar();
        }

        public void EditarCategoria(CE_Categoria Categorias)
        {
            Cmd = new SqlCommand("EditarCategoria", Con.Abrir()); //abrir la conexion con el procedimiento almacenado
            Cmd.CommandType = CommandType.StoredProcedure; //llamar a los procedimientos almacenados
            Cmd.Parameters.Add(new SqlParameter("@Id_Categoria", Categorias.Id_Categoria));
            Cmd.Parameters.Add(new SqlParameter("@NombreCat", Categorias.NombreCat));
            Cmd.ExecuteNonQuery(); //enviamos los datos

            Con.Cerrar();
        }
    }
}
