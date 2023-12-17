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
    public class CDo_Usuarios
    {
        CD_Usuarios ObjUsuario = new CD_Usuarios();

        //metodo para agregar un usuarios a la DB
        public void AgregarUsuarios(CE_Usuarios Usuarios)
        {
            ObjUsuario.AgregarUsuarios(Usuarios);
        }
    }
}
