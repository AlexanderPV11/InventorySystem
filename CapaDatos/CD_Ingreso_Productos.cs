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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace CapaDatos
{
    public class CD_Ingreso_Productos
    {
        CD_Conexion Con = new CD_Conexion();

        private SqlCommand Cmd;

        public void AgregarIngreso(CE_Ingreso_Productos Ingresos)
        {
            Cmd = new SqlCommand("Agregar_Ingreso_Productos", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(new SqlParameter("@No_Ingreso", Ingresos.No_Ingreso));
            Cmd.Parameters.Add(new SqlParameter("@Id_Proveedor", Ingresos.Id_Proveedor));
            Cmd.Parameters.Add(new SqlParameter("@Fecha_Ingreso", Ingresos.Fecha_Ingreso));
            Cmd.Parameters.Add(new SqlParameter("@Comprobante", Ingresos.Comprobante));
            Cmd.Parameters.Add(new SqlParameter("@Monto_Total", Ingresos.Monto_Total));
            Cmd.Parameters.Add(new SqlParameter("@Estado", Ingresos.Estado));
            
            Cmd.ExecuteNonQuery();

            Con.Cerrar();
        }

        public void AnularIngreso(CE_Ingreso_Productos Ingresos)
        {

            string Estado = string.Empty;
            Cmd = new SqlCommand("select Estado from Ingreso_Productos where Id_Ingreso=" + Ingresos.Id_Ingreso + "", Con.Abrir());
            Cmd.CommandType = CommandType.Text;

            SqlDataReader Dr = Cmd.ExecuteReader();
            if (Dr.Read())
            {
                Estado = Dr["Estado"].ToString();
            }
            Dr.Close();

            if (Estado == "Anulado")
            {
                MessageBox.Show("La Compra ya ha sido ANULADA, por favor, seleccione otra Compra", "Anular Compra", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                Cmd = new SqlCommand("Anular_Ingreso_Productos", Con.Abrir());
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.Add(new SqlParameter("@No_Ingreso", Ingresos.No_Ingreso));
                Cmd.Parameters.Add(new SqlParameter("@Id_Ingreso", Ingresos.Id_Ingreso));
                Cmd.Parameters.Add(new SqlParameter("@Id_Proveedor", Ingresos.Id_Proveedor));
                Cmd.Parameters.Add(new SqlParameter("@Fecha_Ingreso", Ingresos.Fecha_Ingreso));
                Cmd.Parameters.Add(new SqlParameter("@Comprobante", Ingresos.Comprobante));
                Cmd.Parameters.Add(new SqlParameter("@Monto_Total", Ingresos.Monto_Total));
                Cmd.Parameters.Add(new SqlParameter("@Estado", Ingresos.Estado));

                Cmd.ExecuteNonQuery();

                MessageBox.Show("¡La compra fue anulada con éxito!", "Anular Compra", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Con.Cerrar();
            }
        }

        public DataTable MostrarIngresoProductos()
        {
            DataTable Dt = new DataTable("Ingreso_Productos");
            Cmd = new SqlCommand("Mostrar_Ingreso", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader Dr = Cmd.ExecuteReader();
            Dt.Load(Dr);

            Dr.Close();
            Con.Cerrar();
            return Dt;
            
        }
    }
}
