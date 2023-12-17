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
    public class CDo_Categoria
    {
        CD_Categoria ObjCategoria = new CD_Categoria();

        //metodo para agregar una categoria a la DB
        public void AgregarCategoria(CE_Categoria Categoria)
        {
            ObjCategoria.AgregarCategoria(Categoria);
        }

        //metodo para editar un cliente a la DB
        public void EditarCategoria(CE_Categoria Categoria)
        {
            ObjCategoria.EditarCategoria(Categoria);
        }
    }
}
