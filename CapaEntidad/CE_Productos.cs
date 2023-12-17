using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class CE_Productos
    {
        private int _Id_Productos;
        private string _CodigoBarra;
        private string _Codigo;
        private string _Nombre;
        private string _Descripcion;
        private string _Presentacion;
        private decimal _Costo_unitario;
        private decimal _Precio_venta;
        private string _Tipo_cargo;
        //private string _Borrado;
        private string _Categoria;

        private string _Buscar;

        public int Id_Productos { get => _Id_Productos; set => _Id_Productos = value; }
        public string Codigo { get => _Codigo; set => _Codigo = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
        public string Presentacion { get => _Presentacion; set => _Presentacion = value; }
        public decimal Costo_unitario { get => _Costo_unitario; set => _Costo_unitario = value; }
        public decimal Precio_venta { get => _Precio_venta; set => _Precio_venta = value; }
        public string Tipo_cargo { get => _Tipo_cargo; set => _Tipo_cargo = value; }
        public string Buscar { get => _Buscar; set => _Buscar = value; }
        public string CodigoBarra { get => _CodigoBarra; set => _CodigoBarra = value; }
        public string Categoria { get => _Categoria; set => _Categoria = value; }
        //public string Borrado { get => _Borrado; set => _Borrado = "false"; }
    }
}
