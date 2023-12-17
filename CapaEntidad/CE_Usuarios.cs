using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class CE_Usuarios
    {
        private int _Id_Usuario;
        private string _Nombre;
        private string _Apellidos;
        private string _Usuario;
        private string _Password;

        public int Id_Usuario { get => _Id_Usuario; set => _Id_Usuario = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Apellidos { get => _Apellidos; set => _Apellidos = value; }
        public string Usuario { get => _Usuario; set => _Usuario = value; }
        public string Password { get => _Password; set => _Password = value; }
    }
}
