using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// data base
using System.Data;
using System.Data.SqlClient;

namespace _3.Controller
{
    public class clsConnection
    {
        // Error 40: Could not open a connection to SQL Server fixed with  http://msdn.microsoft.com/en-us/library/ms174212.aspx
        // in My computer : C:\Windows\SysWOW64\SQLServerManager14.msc
        private SqlConnection Conexion = new SqlConnection("Data Source = .; DataBase = bd_crud_client; Integrated Security = true");

        // OPEN CONNECTION
        public SqlConnection OpenConnection()
        {
            try
            {
                if(Conexion.State==ConnectionState.Closed)
                {
                    Conexion.Open();
                }
                return Conexion;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error in Open Connection : " + " " + ex.Message);
                return null;
            }
        }

        // CLOSE CONNECTION
        public SqlConnection CloseConnection()
        {
            try
            {
                if(Conexion.State==ConnectionState.Open)
                {
                    Conexion.Close();
                }
                return Conexion;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error in Close Connection : " + " " + ex.Message);
                return null;
            }
        }
    }
} 
