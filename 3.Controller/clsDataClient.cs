using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; // MessageBox
// data base
using System.Data;
using System.Data.SqlClient;

namespace _3.Controller
{
    public class clsDataClient
    {
        // 1. Obj clsConnection
        // encapsulate the variable
        private clsConnection Connection = new clsConnection();

        // 2. Read rows
        SqlDataReader read;
        // 3. Store query rows
        DataTable table = new DataTable();
        // 4. Execute SQL
        SqlCommand command = new SqlCommand();

        // 5. Load client in the dataGridView
        public DataTable Display()
        {
            try
            {
                // 1. Execute open connection
                command.Connection = Connection.OpenConnection();
                // 2. Execute stored procedure
                command.CommandText = "selectallTclient";
                // 3. Execute Specify the command type
                command.CommandType = CommandType.StoredProcedure;
                // 4. Execute read the rows from stored procedure
                read = command.ExecuteReader(); // to read rows - return rows
                // 5. Load the table
                table.Load(read);
                // 6. Close connection
                Connection.CloseConnection();
                // 7. Make return
                return table;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error loading fron the data base : " + " " + ex.Message);
                return null;
            }
        }

        // 6. Save and Update
        public void Save(int idclient, string clientNumber, string name, string lastName, string email, string img, string address, string cardNumber, string nip, int idagencies, int idemployee)
        {
            try
            {
                // 1. Execute open connection
                command.Connection = Connection.OpenConnection();
                // 2. Execute stored procedure
                command.CommandText = "spserver_save_client";
                // 3. Execute Specify the command type
                command.CommandType = CommandType.StoredProcedure;
                // 4. Execute parameters
                command.Parameters.AddWithValue("@aidclient",idclient);
                command.Parameters.AddWithValue("@aclientNumber", clientNumber);
                command.Parameters.AddWithValue("@aname", name);
                command.Parameters.AddWithValue("@alastName", lastName);
                command.Parameters.AddWithValue("@aemail", email);
                command.Parameters.AddWithValue("@aimg", img);
                command.Parameters.AddWithValue("@aaddress", address);
                command.Parameters.AddWithValue("@acardNumber", cardNumber);
                command.Parameters.AddWithValue("@anip", nip);
                command.Parameters.AddWithValue("@aidagencies", idagencies);
                command.Parameters.AddWithValue("@aidemployee", idemployee);
                // 5. Execute instruction SQL
                command.ExecuteNonQuery();
                // 6. Execute reuse the object SqlCommand Command
                command.Parameters.Clear();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error in the function Save : " + " " + ex.Message);
            }
        }

        // 7. Delete
        public void Delete(int idclient)
        {
            // 1. Open connection
            command.Connection = Connection.OpenConnection();
            // 2. Execute stored procedure
            command.CommandText = "deleteTclient";
            // 3. Execute Specify the command type
            command.CommandType = CommandType.StoredProcedure;
            // 4. Execute parameter
            command.Parameters.AddWithValue("@aidclient", idclient);
            // 5. Execute instruction SQL
            command.ExecuteNonQuery();
            // 6. Execute reuse the object SqlCommand Command
            command.Parameters.Clear(); 
        } 
    }
}
