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
    public class CDo_Clientes
    {
        CD_Clientes ObjClientes = new CD_Clientes();

        //metodo para agregar un cliente a la DB
        public void AgregarClientes(CE_Clientes Clientes)
        {
            ObjClientes.AgregarClientes(Clientes);
        }

        //metodo para editar un cliente a la DB
        public void EditarClientes(CE_Clientes Clientes)
        {
            ObjClientes.EditarClientes(Clientes);
        }

        //metodo para eliminar un cliente a la DB
        public void EliminarClienrtes(CE_Clientes Clientes)
        {
            ObjClientes.EliminarClientes(Clientes);
        }

        //metodo buscar un cliente por codigo
        public DataTable Buscar_cliente_codigo(CE_Clientes Clientes)
        {
            return ObjClientes.Buscar_cliente_codigo(Clientes);
        }

        //metodo buscar un cliente por nombre
        public DataTable Buscar_cliente_nombre(CE_Clientes Clientes)
        {
            return ObjClientes.Buscar_cliente_nombre(Clientes);
        }

        //metodo buscar un cliente por cedula
        public DataTable Buscar_cliente_cedula(CE_Clientes Clientes)
        {
            return ObjClientes.Buscar_cliente_cedula(Clientes);
        }
    }
}
