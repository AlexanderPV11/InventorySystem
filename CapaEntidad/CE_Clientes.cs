using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class CE_Clientes
    {
        private int _Id_Cliente;
        private string _Codigo;
        private string _Nombre;
        private string _Cedula;
        private string _Direccion;
        private string _Telefono;
        private string _Email;
        private string _Borrado;

        private string _Buscar;

        public int Id_Cliente { get => _Id_Cliente; set => _Id_Cliente = value; }
        public string Codigo { get => _Codigo; set => _Codigo = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Cedula { get => _Cedula; set => _Cedula = value; }
        public string Direccion { get => _Direccion; set => _Direccion = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public string Email { get => _Email; set => _Email = value; }
        public string Borrado { get => _Borrado; set => _Borrado = value; }
        public string Buscar { get => _Buscar; set => _Buscar = value; }
     
    }
}
