using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CapaDominio
{
    public class CDo_Procedimientos
    {
        CD_Procedimientos ObjProcedimientos = new CD_Procedimientos();

        //metodo para cargar los datos de la DB a un DataGridView
        public DataTable CargarDatos(string Tabla)
        {
            return ObjProcedimientos.CargarDatos(Tabla);
        }

        //metodo para cargar los datos de la DB a un DataGridView sin bORR
        public DataTable CargarDatosSinBorr(string Tabla)
        {
            return ObjProcedimientos.CargarDatosSinBorr(Tabla);
        }

        //metodo para alternar los colores en las filas de un DataGridView
        public void AlternarColorFilaDataGridView(DataGridView Dgv)
        {
            ObjProcedimientos.AlternarColorFilaDataGridView(Dgv);
        }


        //metodo para cargar los datos de la DB a un DataGridView
        public string GenerarCodigo(string Tabla)
        {
            return ObjProcedimientos.GenerarCodigo(Tabla);
        }

        public string GenerarCodigoFactura(string Campo)
        {
            return ObjProcedimientos.GenerarCodigoFactura(Campo);
        }

        //metodo para cargar los datos de la DB a un DataGridView
        public string GenerarCodigoId(string Tabla)
        {
            return ObjProcedimientos.GenerarCodigoId(Tabla);
        }

        //metodo que permite dar formato moneda a una caja de texto
        public void FormatoMoneda(TextBox xTBox)
        {
            ObjProcedimientos.FormatoMoneda(xTBox);
        }

        //metodo que permite limpiar controles
        public void LimpiarControles(Form xForm)
        {
            ObjProcedimientos.LimpiarControles(xForm);
        }

        //metodo que permite llenar combobox
        public void LlenarComboBox(string Tabla, string Nombre, ComboBox xCBox)
        {
            ObjProcedimientos.LlenarComboBox(Tabla, Nombre, xCBox);
        }
    }
}
