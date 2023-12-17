using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CapaEntidad;
using System.Data;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Xml;

namespace CapaDatos
{
    public class CD_Detalle_Ingresos
    {
        CD_Conexion Con = new CD_Conexion();

        private SqlCommand Cmd;

        public void AgregarDetalleIngreso(CE_Detalle_Ingresos Detalle)
        {
            Cmd = new SqlCommand("Agregar_Detalle_Ingreso", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(new SqlParameter("@Id_Ingreso", Detalle.Id_Ingreso));
            Cmd.Parameters.Add(new SqlParameter("@Id_Productos", Detalle.Id_Productos));
            Cmd.Parameters.Add(new SqlParameter("@Nombre", Detalle.Nombre));
            Cmd.Parameters.Add(new SqlParameter("@Cantidad", Detalle.Cantidad));
            Cmd.Parameters.Add(new SqlParameter("@Costo_Unitario", Detalle.Costo_Unitario));
            Cmd.Parameters.Add(new SqlParameter("@Sub_Total", Detalle.Sub_Total));
            Cmd.Parameters.Add(new SqlParameter("@Borrado", Detalle.Borrado));


            Cmd.ExecuteNonQuery();

            Con.Cerrar();
        }

        public void AnularDetalleIngreso(CE_Detalle_Ingresos Detalle)
        {
            string Estado = string.Empty;
            Cmd = new SqlCommand("select Estado from Ingreso_Productos where Id_Ingreso=" + Detalle.Id_Ingreso + "", Con.Abrir());
            Cmd.CommandType = CommandType.Text;

            SqlDataReader Dr = Cmd.ExecuteReader();
            if (Dr.Read())
            {
                Estado = Dr["Estado"].ToString();
            }
            Dr.Close();

            if (Estado == "Anulado")
            {
                return;
            }
            else
            {
                Cmd = new SqlCommand("Anular_Detalle_Ingreso", Con.Abrir());
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.Add(new SqlParameter("@Id_Detalle", Detalle.Id_Detalle));
                Cmd.Parameters.Add(new SqlParameter("@Id_Ingreso", Detalle.Id_Ingreso));
                Cmd.Parameters.Add(new SqlParameter("@Id_Productos", Detalle.Id_Productos));
                Cmd.Parameters.Add(new SqlParameter("@Nombre", Detalle.Nombre));
                Cmd.Parameters.Add(new SqlParameter("@Cantidad", Detalle.Cantidad));
                Cmd.Parameters.Add(new SqlParameter("@Costo_Unitario", Detalle.Costo_Unitario));
                Cmd.Parameters.Add(new SqlParameter("@Sub_Total", Detalle.Sub_Total));
                //Cmd.Parameters.Add(new SqlParameter("@Borrado", Detalle.Borrado));

                Cmd.ExecuteNonQuery();

                Con.Cerrar();
            }

        }

        public DataTable MostrarIngresoProducto(int Id_Ingreso)
        {
            DataTable Dt = new DataTable("Detalle_Ingreso");
            Cmd = new SqlCommand("MostrarDetalleIngreso", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(new SqlParameter("@Id_Ingreso", Id_Ingreso));
            Cmd.ExecuteNonQuery();

            SqlDataAdapter Da = new SqlDataAdapter(Cmd);
            Da.Fill(Dt);
            
            Con.Cerrar();
            return Dt;
        }


    }
}
