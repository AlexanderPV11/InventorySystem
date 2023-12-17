using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;
using System.Data;

namespace CapaDominio
{
    public class CDo_Detalle_Ventas
    {
        CD_Detalle_Ventas objDetalleVentas = new CD_Detalle_Ventas();

        public void AgregarDetalleVenta(CE_Detalle_Ventas DetalleVentas)
        {
            objDetalleVentas.AgregarDetalleVenta(DetalleVentas);
        }

        public void AnularDetalleVenta(CE_Detalle_Ventas DetalleVentas)
        {
            objDetalleVentas.AnularDetalleVenta(DetalleVentas);
        }

        public DataTable MostrarVentaProducto(int Id_Venta)
        {

            return objDetalleVentas.MostrarVentaProducto(Id_Venta);
        }
    }
}
