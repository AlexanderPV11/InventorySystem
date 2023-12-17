using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;
using System.Data;
using System.Data.SqlClient;

namespace CapaDominio
{
    public class CDo_DetalleIngresos
    {
        CD_Detalle_Ingresos objDetalleIngreso = new CD_Detalle_Ingresos();

        public void AgregarDetalleIngreso(CE_Detalle_Ingresos Detalle)
        {
            objDetalleIngreso.AgregarDetalleIngreso(Detalle);
        }

        public void AnularDetalleIngreso(CE_Detalle_Ingresos Detalle)
        {
            objDetalleIngreso.AnularDetalleIngreso(Detalle);
        }

        public DataTable MostrarIngresoProducto(int Id_Ingreso)
        {

            return objDetalleIngreso.MostrarIngresoProducto(Id_Ingreso);
        }


    }
}
