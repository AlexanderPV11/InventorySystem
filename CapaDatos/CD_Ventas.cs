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
    public class CD_Ventas
    {

        CD_Conexion Con = new CD_Conexion();

        private SqlCommand Cmd;

        public void AgregarVenta(CE_Ventas Ventas)
        {
            Cmd = new SqlCommand("AgregarVenta", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(new SqlParameter("@Id_Cliente", Ventas.Id_Cliente));
            Cmd.Parameters.Add(new SqlParameter("@No_Factura", Ventas.No_Factura));
            Cmd.Parameters.Add(new SqlParameter("@Fecha_Venta", Ventas.Fecha_Venta));
            Cmd.Parameters.Add(new SqlParameter("@Fecha_Validez", Ventas.Fecha_Validez));
            Cmd.Parameters.Add(new SqlParameter("@Comprobante", Ventas.Comprobante));
            Cmd.Parameters.Add(new SqlParameter("@Sub_Total", Ventas.Sub_Total));
            Cmd.Parameters.Add(new SqlParameter("@Descuento", Ventas.Descuento));
            Cmd.Parameters.Add(new SqlParameter("@Iva", Ventas.Iva));
            Cmd.Parameters.Add(new SqlParameter("@Monto_Total", Ventas.Monto_Total));
            Cmd.Parameters.Add(new SqlParameter("@Estado", Ventas.Estado));
            Cmd.Parameters.Add(new SqlParameter("@Id_Usuario", Ventas.Id_Usuario));

            Cmd.ExecuteNonQuery();

            Con.Cerrar();
        }

        public void AnularVenta(CE_Ventas Ventas)
        {

            string Estado = string.Empty;
            Cmd = new SqlCommand("select Estado from Ventas where Id_Venta=" + Ventas.Id_Venta + "", Con.Abrir());
            Cmd.CommandType = CommandType.Text;

            SqlDataReader Dr = Cmd.ExecuteReader();
            if (Dr.Read())
            {
                Estado = Dr["Estado"].ToString();
            }
            Dr.Close();

            if (Estado == "Anulado")
            {
                MessageBox.Show("La venta ya ha sido ANULADA, por favor, seleccione otra Venta", "Anular Venta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                Cmd = new SqlCommand("AnularVenta", Con.Abrir());
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.Add(new SqlParameter("@Id_Venta", Ventas.Id_Venta));
                Cmd.Parameters.Add(new SqlParameter("@Id_Cliente", Ventas.Id_Cliente));
                Cmd.Parameters.Add(new SqlParameter("@No_Factura", Ventas.No_Factura));
                Cmd.Parameters.Add(new SqlParameter("@Fecha_Venta", Ventas.Fecha_Venta));
                Cmd.Parameters.Add(new SqlParameter("@Fecha_Validez", Ventas.Fecha_Validez));
                Cmd.Parameters.Add(new SqlParameter("@Comprobante", Ventas.Comprobante));
                Cmd.Parameters.Add(new SqlParameter("@Sub_Total", Ventas.Sub_Total));
                Cmd.Parameters.Add(new SqlParameter("@Descuento", Ventas.Descuento));
                Cmd.Parameters.Add(new SqlParameter("@Iva", Ventas.Iva));
                Cmd.Parameters.Add(new SqlParameter("@Monto_Total", Ventas.Monto_Total));
                Cmd.Parameters.Add(new SqlParameter("@Estado", Ventas.Estado));
                Cmd.Parameters.Add(new SqlParameter("@Id_Usuario", Ventas.Id_Usuario));

                Cmd.ExecuteNonQuery();

                MessageBox.Show("¡La venta fue anulada con éxito!", "Anular Venta", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Con.Cerrar();
            }
        }

        public DataTable MostrarVentas()
        {
            DataTable Dt = new DataTable("Ventas");
            Cmd = new SqlCommand("MostrarVentas", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader Dr = Cmd.ExecuteReader();
            Dt.Load(Dr);

            Dr.Close();
            Con.Cerrar();
            return Dt;

        }

        public void MostrarVentasSegunFecha(string fechaInicio, string fechaFin)
        {
            Cmd = new SqlCommand("MostrarVentasSegunFecha", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(new SqlParameter("@Fecha_Venta", fechaInicio));
            Cmd.Parameters.Add(new SqlParameter("@Fecha_Hasta", fechaFin));

            Cmd.ExecuteNonQuery();

            Con.Cerrar();
        }

        public DataTable Mostrar_Productos_Ventas()
        {
            DataTable Dt = new DataTable("Mostrar Productos");
            Cmd = new SqlCommand("Mostrar_Productos_Ventas", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader Dr = Cmd.ExecuteReader();
            Dt.Load(Dr);

            Dr.Close();
            Con.Cerrar();
            return Dt;

        }
    }
}
