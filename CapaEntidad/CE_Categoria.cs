using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class CE_Categoria
    {
        private int _Id_Categoria;
        private string _NombreCat;

        public int Id_Categoria { get => _Id_Categoria; set => _Id_Categoria = value; }
        public string NombreCat { get => _NombreCat; set => _NombreCat = value; }
    }
}
