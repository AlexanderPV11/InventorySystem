using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class CE_Tipo_Comprobantes
    {
        private int _Id_Comprobante;
        private string _Nombre_Comprobante;
        private string _Tipo_Comprobante;
        private int _Correlativo;

        public int Id_Comprobante { get => _Id_Comprobante; set => _Id_Comprobante = value; }
        public string Nombre_Comprobante { get => _Nombre_Comprobante; set => _Nombre_Comprobante = value; }
        public string Tipo_Comprobante { get => _Tipo_Comprobante; set => _Tipo_Comprobante = value; }
        public int Correlativo { get => _Correlativo; set => _Correlativo = value; }
    }
}
