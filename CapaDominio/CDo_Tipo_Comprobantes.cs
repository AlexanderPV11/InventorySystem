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
    public class CDo_Tipo_Comprobantes
    {
        CD_Tipo_Comprobantes ObjTipoComprobante = new CD_Tipo_Comprobantes();
        public void AgregarTipoComprobante(CE_Tipo_Comprobantes Tipo_Comprobante)
        {
            ObjTipoComprobante.AgregarTipoComprobante(Tipo_Comprobante);
        }

        public void EditarTipoComprobante(CE_Tipo_Comprobantes Tipo_Comprobante)
        {
            ObjTipoComprobante.EditarTipoComprobante(Tipo_Comprobante);
        }

        public void ActualizarComprobante(CE_Tipo_Comprobantes Comprobantes)
        {
            ObjTipoComprobante.ActualizarComprobante(Comprobantes);
        }
    }
}
