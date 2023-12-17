using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class CE_Detalle_Ingresos
    {
        private int _Id_Detalle;
        private int _Id_Ingreso;
        private int _Id_Productos;
        private string _Nombre;
        private int _Cantidad;
        private decimal _Costo_Unitario;
        private decimal _Sub_Total;
        private string _Borrado;
        
        private string _Buscar;

        public int Id_Detalle { get => _Id_Detalle; set => _Id_Detalle = value; }
        public int Id_Ingreso { get => _Id_Ingreso; set => _Id_Ingreso = value; }
        public int Id_Productos { get => _Id_Productos; set => _Id_Productos = value; }
        public int Cantidad { get => _Cantidad; set => _Cantidad = value; }
        public decimal Costo_Unitario { get => _Costo_Unitario; set => _Costo_Unitario = value; }
        public decimal Sub_Total { get => _Sub_Total; set => _Sub_Total = value; }
        
        public string Buscar { get => _Buscar; set => _Buscar = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Borrado { get => _Borrado; set => _Borrado = value; }
    }
}
