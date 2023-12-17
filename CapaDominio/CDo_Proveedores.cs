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
    public class CDo_Proveedores
    {
        CD_Proveedores ObjProveedores = new CD_Proveedores();

        //metodo para agregar un proveedor a la DB
        public void AgregarProveedor(CE_Proveedores Proveedores)
        {
            ObjProveedores.AgregarProveedores(Proveedores);
        }

        //metodo para editar un proveedor a la DB
        public void EditarProveedor(CE_Proveedores Proveedores)
        {
            ObjProveedores.EditarProveedores(Proveedores);
        }

        //metodo para eliminar un proveedor a la DB
        public void EliminarProveedor(CE_Proveedores Proveedores)
        {
            ObjProveedores.EliminarProveedores(Proveedores);
        }

        //metodo buscar un proveedor por codigo
        public DataTable Buscar_proveedor_codigo(CE_Proveedores Proveedores)
        {
            return ObjProveedores.Buscar_proveedor_codigo(Proveedores);
        }

        //metodo buscar un proveedor por nombre
        public DataTable Buscar_proveedor_nombre(CE_Proveedores Proveedores)
        {
            return ObjProveedores.Buscar_proveedor_nombre(Proveedores);
        }

        //metodo buscar un proveedor por ruc
        public DataTable Buscar_proveedor_RUC(CE_Proveedores Proveedores)
        {
            return ObjProveedores.Buscar_proveedores_RUC(Proveedores);
        }
    }
}
