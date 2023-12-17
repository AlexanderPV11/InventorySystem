using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class CE_Ingreso_Productos
    {
        private int _Id_Ingreso;
        private string _No_Ingreso;
        private int _Id_Proveedor;
        private DateTime _Fecha_Ingreso;
        private string _Comprobante;
        private decimal _Monto_Total;
        private string _Estado;
        private string _Borrado;
        private string _Buscar;

        public int Id_Ingreso { get => _Id_Ingreso; set => _Id_Ingreso = value; }
        public int Id_Proveedor { get => _Id_Proveedor; set => _Id_Proveedor = value; }
        public DateTime Fecha_Ingreso { get => _Fecha_Ingreso; set => _Fecha_Ingreso = value; }
        public string Comprobante { get => _Comprobante; set => _Comprobante = value; }
        public decimal Monto_Total { get => _Monto_Total; set => _Monto_Total = value; }
        public string Estado { get => _Estado; set => _Estado = value; }
        public string Borrado { get => _Borrado; set => _Borrado = value; }
        public string Buscar { get => _Buscar; set => _Buscar = value; }
        public string No_Ingreso { get => _No_Ingreso; set => _No_Ingreso = value; }
    }
}
