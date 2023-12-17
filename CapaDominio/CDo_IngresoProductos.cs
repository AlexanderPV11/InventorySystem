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
    public class CDo_IngresoProductos
    {
        CD_Ingreso_Productos ObjIngresoProductos = new CD_Ingreso_Productos();

        public void AgregarIngreso(CE_Ingreso_Productos Ingresos)
        {
            ObjIngresoProductos.AgregarIngreso(Ingresos);
        }

        public void AnularIngreso(CE_Ingreso_Productos Ingresos)
        {
            ObjIngresoProductos.AnularIngreso(Ingresos);
        }

        public DataTable MostrarIngresoProductos()
        {
            return ObjIngresoProductos.MostrarIngresoProductos();
        }
    }
}
