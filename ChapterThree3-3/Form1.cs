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
        public frmCustomers()
        {
            InitializeComponent();
        }

        private void frmCustomers_Load(object sender, EventArgs e)
        {
            string pathName = Path.GetFullPath("SQLNwindDB.mdf");
            MessageBox.Show(pathName);

            // connect to NWind database
            NWConnection = new SqlConnection($"Data Source=\\SQLEXPRESS; AttachDbFileName=" + pathName + "; Integrated Security=True; Connect Timeout=10; User Instance=True");

            // open the connection
            NWConnection.Open();
            NWConnection.Close();
            NWConnection.Dispose(); 

            // establish command object
            //customersCommand = new OleDbCommand
        }
    }
}
