using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CapaDatos
{
    public class CD_Procedimientos
    {
        CD_Conexion Con = new CD_Conexion();
        
        //para comandos y consultas a la DB
        SqlCommand Cmd; 
        SqlDataReader Dr;
        DataTable Dt;

        //metodo para cargar los datos de la DB a un DataGridView
        public DataTable CargarDatos(string Tabla)
        {
            int borr = 0;
            Dt = new DataTable("CargarDatos");
            Cmd= new SqlCommand("Select * from  " + Tabla + " where " + " Borrado " + " = " + borr, Con.Abrir());
            Cmd.CommandType = CommandType.Text;
            
            Dr = Cmd.ExecuteReader();
            Dt.Load(Dr);
            Dr.Close();

            Con.Cerrar();

            return Dt;
        }

        //metodo para cargar los datos de la DB a un DataGridView sin BORRADO
        public DataTable CargarDatosSinBorr(string Tabla)
        {
            Dt = new DataTable("CargarDatosSinBorr");
            Cmd = new SqlCommand("Select * from  " + Tabla, Con.Abrir());
            Cmd.CommandType = CommandType.Text;

            Dr = Cmd.ExecuteReader();
            Dt.Load(Dr);
            Dr.Close();

            Con.Cerrar();

            return Dt;
        }

        //metodo para alternar los colores en las filas de un DataGridView
        public void AlternarColorFilaDataGridView(DataGridView Dgv)
        {
            Dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.LightBlue;
            Dgv.DefaultCellStyle.BackColor = Color.White;
        }
        

        //metodo para generar codigos de la DB a un DataGridView
        public string GenerarCodigo(string Tabla)
        {
            string Codigo = string.Empty;
            int Total = 0;

            Cmd = new SqlCommand("Select Count(*) as TotalRegistros From"+ " " + Tabla, Con.Abrir());
            Cmd.CommandType = CommandType.Text;

            Dr = Cmd.ExecuteReader();

            if(Dr.Read())
            {
                Total = Convert.ToInt32(Dr["TotalRegistros"]) + 1;
            }
            Dr.Close();

            if(Total < 10)
            {
                Codigo = "0000000" + Total;
            }
            else if (Total < 100) 
            {
                Codigo = "000000" + Total;
            }
            else if (Total < 1000)
            {
                Codigo = "00000" + Total;
            }
            else if (Total < 10000)
            {
                Codigo = "0000" + Total;
            }
            else if (Total < 100000)
            {
                Codigo = "000" + Total;
            }
            else if (Total < 1000000)
            {
                Codigo = "00" + Total;
            }
            else if (Total < 10000000)
            {
                Codigo = "0" + Total;
            }

            Con.Cerrar();

            return Codigo;
        }

        //GENERAR EL CORRELATIVO AUTOMATICAMENTE EN UN FORMULARIO
        public string GenerarCodigoFactura(string Campo)
        {
            string Codigo = string.Empty;
            int Total = 0;

            Cmd = new SqlCommand("Select * from Tipos_Comprobante where Id_Comprobante= " + Campo + " ", Con.Abrir());
            Cmd.CommandType = CommandType.Text;

            Dr = Cmd.ExecuteReader();

            if (Dr.Read())
            {
                Total = Convert.ToInt32(Dr[3]) + 1;
            }
            Dr.Close();

            if (Total < 10)
            {
                Codigo = "0000000" + Total;
            }
            else if (Total < 100)
            {
                Codigo = "000000" + Total;
            }
            else if (Total < 1000)
            {
                Codigo = "00000" + Total;
            }
            else if (Total < 10000)
            {
                Codigo = "0000" + Total;
            }
            else if (Total < 100000)
            {
                Codigo = "000" + Total;
            }
            else if (Total < 1000000)
            {
                Codigo = "00" + Total;
            }
            else if (Total < 10000000)
            {
                Codigo = "0" + Total;
            }

            Con.Cerrar();

            return Codigo;
        }

        //metodo para cargar los datos de la DB a un DataGridView
        public string GenerarCodigoId(string Tabla)
        {
            string Codigo = string.Empty;
            int Total = 0;

            Cmd = new SqlCommand("Select Count(*) as TotalRegistros From" + " " + Tabla, Con.Abrir());
            Cmd.CommandType = CommandType.Text;

            Dr = Cmd.ExecuteReader();

            if (Dr.Read())
            {
                Total = Convert.ToInt32(Dr["TotalRegistros"]) + 1;
            }
            Dr.Close();

            Codigo = Convert.ToString(Total);

            Con.Cerrar();

            return Codigo;
        }

        //metodo que permite dar formato moneda a una caja de texto
        public void FormatoMoneda(TextBox xTBox)
        {
            if (xTBox.Text == string.Empty) {
                return;
            }
            else
            {
                decimal Monto;
                Monto = Convert.ToDecimal(xTBox.Text);  
                xTBox.Text = Monto.ToString("N2");
            }
        }

        //metodo que permite limpiar controles
        public void LimpiarControles(Form xForm)
        {
            foreach(var xCtrl in xForm.Controls)
            {
                if (xCtrl is TextBox)
                {
                    ((TextBox)xCtrl).Text = string.Empty;   
                }
                else if (xCtrl is ComboBox)
                {
                    ((ComboBox)xCtrl).Text = string.Empty;
                }
            }
        }

        //metodo que permite llenar combobox
        public void LlenarComboBox(string Tabla, string Nombre, ComboBox xCBox)
        {
            Cmd = new SqlCommand("Select * from " + Tabla, Con.Abrir());
            Cmd.CommandType = CommandType.Text;

            Dr = Cmd.ExecuteReader();

            while(Dr.Read())
            {
                xCBox.Items.Add(Dr[Nombre].ToString());
            }
        }
    }
}
