using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _1.Model; // business layer

namespace _2.View
{
    public partial class CRUD : Form
    {
        // 1. Obj clsTclient
        clsTclient Model = new clsTclient();

        public CRUD()
        {
            InitializeComponent();
           // gvClient.SelectionMode = DataGridViewSelectionMode.FullColumnSelect;
        }

        private void CRUD_Load(object sender, EventArgs e)
        {
            // init
            DisplayClients();
            btnDelete.Enabled = false;
            txtidclient.Text = "0";
            txtidclient.Visible = false;
            lblidclient.Visible = false;
        }

        /// <summary>
        /// 2. Loads the info client in to the dataGridView
        /// </summary>
        private void DisplayClients()
        {
            try
            {
                // newModel cleans the object everytime it is called
                // newModel cleans the view with every click
                clsTclient newModel = new clsTclient();
                gvClient.DataSource = newModel.DisplayClient();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error " + " " + ex.Message);
            }
        }

        /// <summary>
        /// 3. Select the info client each row in the dataGridView
        /// </summary>
        private void gvClient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gvClient.SelectedRows.Count > 0)
                {
                    // select clietn by row
                    txtidclient.Text = gvClient.SelectedRows[0].Cells["idclient"].Value.ToString();
                    txtclientNumber.Text = gvClient.SelectedRows[0].Cells["clientNumber"].Value.ToString();
                    txtname.Text = gvClient.SelectedRows[0].Cells["name"].Value.ToString();
                    txtlastName.Text = gvClient.SelectedRows[0].Cells["lastName"].Value.ToString();
                    txtemail.Text = gvClient.SelectedRows[0].Cells["email"].Value.ToString();
                    txtimg.Text = gvClient.SelectedRows[0].Cells["img"].Value.ToString();
                    txtaddress.Text = gvClient.SelectedRows[0].Cells["address"].Value.ToString();
                    txtcardNumber.Text = gvClient.SelectedRows[0].Cells["cardNumber"].Value.ToString();
                    txtnip.Text = gvClient.SelectedRows[0].Cells["nip"].Value.ToString();
                    txtidagencies.Text = gvClient.SelectedRows[0].Cells["idagencies"].Value.ToString();
                    txtidemployee.Text = gvClient.SelectedRows[0].Cells["idemployee"].Value.ToString();
                    // btnSave to btnUpdate
                    btnSave.Text = "Update >>>";
                    btnDelete.Enabled = true;
                }
                else
                {
                    MessageBox.Show("select a row please");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + " " + ex.Message);
            }
        }

        /// <summary>
        /// 4. Save or update the info client in to the data base
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            // 1. Get client info from text boxes
            string idclient = txtidclient.Text.Trim();
            string clientNumber = txtclientNumber.Text.Trim();
            string name = txtname.Text.Trim();
            string lastName = txtlastName.Text.Trim();
            string email = txtemail.Text.Trim();
            string img = txtimg.Text.Trim();
            string address = txtaddress.Text.Trim();
            string cardNumber = txtcardNumber.Text.Trim();
            string nip = txtnip.Text.Trim();
            string idagencies = txtidagencies.Text.Trim();
            string idemployee = txtidemployee.Text.Trim();

            try
            {
                // 2. Save or update client info
                Model.SaveClient(idclient, clientNumber, name, lastName, email, img, address, cardNumber, nip, idagencies, idemployee);
                if(idclient!="0")
                {
                    MessageBox.Show("Msg : " + " " + " client has been updated");
                }
                else
                {
                    MessageBox.Show("Msg : " + " " + " client has been saved");
                }
                // Refresh the dataGridView
                DisplayClients();
                // Cleans the text boxws in the form
                CleanTextboxes();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error  : " + " " + ex.Message);
            }
        }

        /// <summary>
        /// 4. Delete the info client in to the data base
        /// </summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // 1. Get client info from text boxes
            string idclient = txtidclient.Text.Trim();
            try
            {
                // 2. Delete info client in the data base
                Model.DeleteClient(idclient);
                // 3. Loads the info client in to the dataGridView
                DisplayClients();
                // 4. cleaan the text boxes 
                CleanTextboxes();
                // 5. Message
                MessageBox.Show("Msg : " + " " + " client has been deleted");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
        }

        /// <summary>
        /// 5. cleaan the text boxes 
        /// </summary>
        private void btnClear_Click(object sender, EventArgs e)
        {
            CleanTextboxes();
        }

        /// <summary>
        /// 6. cleaan the text boxes 
        /// </summary>
        public void CleanTextboxes()
        {
            txtidclient.Text = "0";
            txtclientNumber.Clear();
            txtname.Clear();
            txtlastName.Clear();
            txtemail.Clear();
            txtimg.Clear();
            txtaddress.Clear();
            txtcardNumber.Clear();
            txtnip.Clear();
            txtidagencies.Clear();
            txtidemployee.Clear();
            // btnSave to btnSave
            btnSave.Text = "Save >>>";
            btnDelete.Enabled = false;
        }
    }
}
