using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CapaDominio
{
    public class CDo_Productos
    {
        CD_Productos ObjProductos = new CD_Productos();

        //metodo para agregar un producto a la DB
        public void AgregarProductos(CE_Productos Productos)
        {
            ObjProductos.AgregarProductos(Productos);
        }

        //metodo para editar un producto a la DB
        public void EditarProductos(CE_Productos Productos)
        {
            ObjProductos.EditarProductos(Productos);
        }

        //metodo para eliminar un producto a la DB
        public void EliminarProducto(CE_Productos Productos)
        {
            ObjProductos.EliminarProductos(Productos);
        }

        //metodo buscar un producto por codigo
        public DataTable Buscar_producto_codigo(CE_Productos Productos)
        {
           return ObjProductos.Buscar_producto_codigo(Productos);
        }

        public DataTable Buscar_producto_codigoBarra(CE_Productos Productos)
        {
            return ObjProductos.Buscar_producto_codigoBarra(Productos);
        }

        //metodo buscar un producto por nombre
        public DataTable Buscar_producto_nombre(CE_Productos Productos)
        {
            return ObjProductos.Buscar_producto_nombre(Productos);
        }

        //metodo buscar un producto por presentaion
        public DataTable Buscar_producto_presentacion(CE_Productos Productos)
        {
            return ObjProductos.Buscar_producto_presentacion(Productos);
        }

        public DataTable Buscar_inventario_nombre(CE_Productos Productos)
        {
            return ObjProductos.Buscar_inventario_nombre(Productos);
        }

        public void Bucar_Productos_por_CodigoBarra(string Nombre, TextBox Control, string xTBox)
        {
            ObjProductos.Bucar_Productos_por_CodigoBarra(Nombre, Control, xTBox);
        }
    }
}
