using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// data base
using System.Data;
using _3.Controller; // data layer

namespace _1.Model
{
    public class clsTclient
    {
        // 1. Obj clsDataClient
        // encapsulate the variable
        /// <summary>
        /// 1. Obj clsDataClient -> object with the interactions with the data base
        /// </summary>
        private clsDataClient Controller = new clsDataClient();


        /// <summary>
        /// 2. Load client in the dataGridView -> call the info client from data base and returns the info in a table
        /// </summary>
        /// <returns>a client info table</returns>
        public DataTable DisplayClient()
        {
            // 1. Obj DataTable
            DataTable table = new DataTable();
            // 2. Info client in a table object
            table = Controller.Display();
            // 3. Make return
            return table;
        }

        /// <summary>
        /// 3. Save or update info client in the data base with one Stored Procedure
        /// </summary>
        public void SaveClient(string idclient, string clientNumber, string name, string lastName, string email, string img, string address, string cardNumber, string nip, string idagencies, string idemployee)
        {
            // we validate and convert data in the the Model layer
            // we do not validate and convert data in the View layer 

            // 1. Convert data
            int IDclient = Convert.ToInt32(idclient);
            int IDagencies = Convert.ToInt32(idagencies);
            // with idclient we update one row in the table
            int IDemployee = Convert.ToInt32(idemployee);
            // 2. Save or update in the controller layer
            Controller.Save(IDclient, clientNumber, name, lastName, email, img, address, cardNumber, nip, IDagencies, IDemployee);
        }

        public void DeleteClient(string idclient)
        {
            try
            {
                // 1. Convert data
                int IDclient = Convert.ToInt32(idclient);
                // 2. Delete in the controller layer
                Controller.Delete(IDclient);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error in the delete: " + " " + ex.Message);
            }
        }
    }
}
