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
    public class CD_Detalle_Ventas
    {
        CD_Conexion Con = new CD_Conexion();

        private SqlCommand Cmd;

        public void AgregarDetalleVenta(CE_Detalle_Ventas DetalleVentas)
        {
            Cmd = new SqlCommand("AgregarDetalleVenta", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(new SqlParameter("@Id_Venta", DetalleVentas.Id_Venta));
            Cmd.Parameters.Add(new SqlParameter("@Id_Productos", DetalleVentas.Id_Productos));
            Cmd.Parameters.Add(new SqlParameter("@Presentacion", DetalleVentas.Presentacion));
            Cmd.Parameters.Add(new SqlParameter("@Cantidad", DetalleVentas.Cantidad));
            Cmd.Parameters.Add(new SqlParameter("@Precio_Venta", DetalleVentas.Precio_Venta));
            Cmd.Parameters.Add(new SqlParameter("@Sub_Total", DetalleVentas.Sub_Total));
            Cmd.Parameters.Add(new SqlParameter("@Descuento", DetalleVentas.Descuento));
            Cmd.Parameters.Add(new SqlParameter("@Iva", DetalleVentas.Iva));
            Cmd.Parameters.Add(new SqlParameter("@Monto_Total", DetalleVentas.Monto_Total));

            Cmd.ExecuteNonQuery();

            Con.Cerrar();
        }

        public void AnularDetalleVenta(CE_Detalle_Ventas DetalleVentas)
        {

            string Estado = string.Empty;
            Cmd = new SqlCommand("select Estado from Ventas where Id_Venta=" + DetalleVentas.Id_Venta + "", Con.Abrir());
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
                Cmd = new SqlCommand("AnularDetalleVenta", Con.Abrir());
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.Add(new SqlParameter("@Id_Detalle", DetalleVentas.Id_Detalle));
                Cmd.Parameters.Add(new SqlParameter("@Id_Venta", DetalleVentas.Id_Venta));
                Cmd.Parameters.Add(new SqlParameter("@Id_Productos", DetalleVentas.Id_Productos));
                Cmd.Parameters.Add(new SqlParameter("@Presentacion", DetalleVentas.Presentacion));
                Cmd.Parameters.Add(new SqlParameter("@Cantidad", DetalleVentas.Cantidad));
                Cmd.Parameters.Add(new SqlParameter("@Precio_Venta", DetalleVentas.Precio_Venta));
                Cmd.Parameters.Add(new SqlParameter("@Sub_Total", DetalleVentas.Sub_Total));
                Cmd.Parameters.Add(new SqlParameter("@Descuento", DetalleVentas.Descuento));
                Cmd.Parameters.Add(new SqlParameter("@Iva", DetalleVentas.Iva));
                Cmd.Parameters.Add(new SqlParameter("@Monto_Total", DetalleVentas.Monto_Total));

                Cmd.ExecuteNonQuery();

                MessageBox.Show("¡La venta fue anulada con éxito!", "Anular Venta", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Con.Cerrar();
            }
        }

        public DataTable MostrarVentaProducto(int Id_Venta)
        {
            DataTable Dt = new DataTable("Detalle_Venta");
            Cmd = new SqlCommand("Mostrar_Detalle_Ventas", Con.Abrir());
            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.Add(new SqlParameter("@Id_Venta", Id_Venta));
            Cmd.ExecuteNonQuery();

            SqlDataReader Dr = Cmd.ExecuteReader();
            Dt.Load(Dr);

            Dr.Close();
            Con.Cerrar();
            return Dt;

        }
    }
}
