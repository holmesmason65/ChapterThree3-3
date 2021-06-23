/* Mason Holmes
 * 6/23/2021
 * This program provides a GUI for navigating a SQL Database.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace ChapterThree3_3
{
    public partial class frmCustomers : Form
    {
        SqlConnection NWConnection;
        SqlCommand customerCommand;
        SqlDataAdapter customerAdapter;
        CurrencyManager customerManager;
        DataTable customersTable;

        public frmCustomers()
        {
            InitializeComponent();
        }

        private void frmCustomers_Load(object sender, EventArgs e)
        {
            string pathName = Path.GetFullPath("SQLNwindDB.mdf");

            // connect to NWind database
            NWConnection = new SqlConnection($@"Data Source=.\SQLEXPRESS; AttachDbFileName={pathName}; Integrated Security=True; Connect Timeout=30; User Instance=True");

            // open the connection
            NWConnection.Open();

            // establish the command object 
            customerCommand = new SqlCommand("SELECT * FROM Customers", NWConnection);

            // establish data adapter/data table 
            customerAdapter = new SqlDataAdapter();
            customerAdapter.SelectCommand = customerCommand;
            customersTable = new DataTable(); 
            customerAdapter.Fill(customersTable);

            // bind controls to data table
            txtCustomerID.DataBindings.Add("Text", customersTable, "CustomerID");
            txtCompanyName.DataBindings.Add("Text", customersTable, "CompanyName");
            txtContactName.DataBindings.Add("Text", customersTable, "ContactName");
            txtContactTitle.DataBindings.Add("Text", customersTable, "ContactTitle");
            
            // establish concurency manager 
            customerManager = (CurrencyManager)BindingContext[customersTable];

            // close the connection 
            NWConnection.Close();

            // dispose of the connection 
            NWConnection.Dispose(); 
            customerCommand.Dispose(); 
            customerAdapter.Dispose();
            customersTable.Dispose(); 
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            customerManager.Position = 0;
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            customerManager.Position--;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            customerManager.Position++;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            customerManager.Position = customerManager.Count - 1; 
        }
    }
}
