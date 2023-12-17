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
    public class CD_Tipo_Comprobantes
    {
        CD_Conexion Con = new CD_Conexion();

        SqlCommand Cmd;


        //Metodo para agregar tipo de comprobante
        public void AgregarTipoComprobante(CE_Tipo_Comprobantes Tipo_Comprobante)
        {
            Cmd = new SqlCommand("AgregarTipoComprobante", Con.Abrir()); //abrir la conexion con el procedimiento almacenado
            Cmd.CommandType = CommandType.StoredProcedure; //llamar a los procedimientos almacenados
            Cmd.Parameters.Add(new SqlParameter("@Nombre", Tipo_Comprobante.Nombre_Comprobante));
            Cmd.Parameters.Add(new SqlParameter("@Tipo_Comprobante", Tipo_Comprobante.Tipo_Comprobante));
            Cmd.Parameters.Add(new SqlParameter("@Correlativo", Tipo_Comprobante.Correlativo));
            Cmd.ExecuteNonQuery(); //enviamos los datos

            Con.Cerrar();
        }

        //Metodo para editar un proveedor a la DB
        public void EditarTipoComprobante(CE_Tipo_Comprobantes Tipo_Comprobante)
        {
            Cmd = new SqlCommand("EditarTipoComprobante", Con.Abrir()); //abrir la conexion con el procedimiento almacenado
            Cmd.CommandType = CommandType.StoredProcedure; //llamar a los procedimientos almacenados
            Cmd.Parameters.Add(new SqlParameter("@Id_Comprobante", Tipo_Comprobante.Id_Comprobante));
            Cmd.Parameters.Add(new SqlParameter("@Nombre", Tipo_Comprobante.Nombre_Comprobante));
            Cmd.Parameters.Add(new SqlParameter("@Tipo_Comprobante", Tipo_Comprobante.Tipo_Comprobante));
            Cmd.Parameters.Add(new SqlParameter("@Correlativo", Tipo_Comprobante.Correlativo));
            Cmd.ExecuteNonQuery(); //enviamos los datos

            Con.Cerrar();
        }

        public void ActualizarComprobante(CE_Tipo_Comprobantes Comprobantes)
        {
            Cmd = new SqlCommand("ActualizarComprobante", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(new SqlParameter("@Correlativo", Comprobantes.Correlativo));
            Cmd.Parameters.Add(new SqlParameter("@Id_Comprobante", Comprobantes.Id_Comprobante));
            Cmd.ExecuteNonQuery();

            Con.Cerrar();
        }
    }
}
