using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class CE_Detalle_Ventas
    {
        private int _Id_Detalle;
        private int _Id_Venta;
        private int _Id_Productos;
        private string _Presentacion;
        private int _Cantidad;
        private decimal _Precio_Venta;
        private decimal _Sub_Total;
        private decimal _Descuento;
        private decimal _Iva;
        private decimal _Monto_Total;

        public int Id_Detalle { get => _Id_Detalle; set => _Id_Detalle = value; }
        public int Id_Venta { get => _Id_Venta; set => _Id_Venta = value; }
        public int Id_Productos { get => _Id_Productos; set => _Id_Productos = value; }
        public string Presentacion { get => _Presentacion; set => _Presentacion = value; }
        public int Cantidad { get => _Cantidad; set => _Cantidad = value; }
        public decimal Precio_Venta { get => _Precio_Venta; set => _Precio_Venta = value; }
        public decimal Sub_Total { get => _Sub_Total; set => _Sub_Total = value; }
        public decimal Descuento { get => _Descuento; set => _Descuento = value; }
        public decimal Iva { get => _Iva; set => _Iva = value; }
        public decimal Monto_Total { get => _Monto_Total; set => _Monto_Total = value; }
    }
}
