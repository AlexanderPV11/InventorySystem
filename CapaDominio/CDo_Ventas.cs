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
    public class CDo_Ventas
    {
        CD_Ventas objVentas = new CD_Ventas();

        public void AgregarVenta(CE_Ventas Ventas)
        {
            objVentas.AgregarVenta(Ventas);
        }

        public void AnularVenta(CE_Ventas Ventas)
        {
            objVentas.AnularVenta(Ventas);
        }

        public DataTable MostrarVentas()
        {

            return objVentas.MostrarVentas();
        }

        public DataTable Mostrar_Productos_Ventas()
        {
            return objVentas.Mostrar_Productos_Ventas();
        }
    }
}
