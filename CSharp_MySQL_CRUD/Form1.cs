using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using CSharp_MySQL_CRUD.App_data;

namespace CSharp_MySQL_CRUD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            DBConnectionStatus();
            GetTotalStudents();
            
        }

        private void LoadData()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionManager.connectionString))
            {
                try
                {
                    MySqlDataAdapter _adapter = new MySqlDataAdapter("SELECT * FROM student", conn);
                    DataSet _dataset = new DataSet();
                    _adapter.Fill(_dataset, "table");
                    dataGridViewStudent.DataSource = _dataset;
                    dataGridViewStudent.DataMember = "table";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Connection Error!\n" + ex.Message, "Error Message",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void DBConnectionStatus()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionManager.connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT VERSION()";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    string version = Convert.ToString(cmd.ExecuteScalar());
                    lblDBStatusValue.Text = "Connection Established! - " + "MySQL Version: " + version;

                }
                catch (Exception ex)
                {
                    lblDBStatusValue.Text = "Connection Error!\n" + ex.Message;
                }
            }

        }

        private void GetTotalStudents()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionManager.connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM student";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    string records = Convert.ToString(cmd.ExecuteScalar());
                    lblRecords.Text = records;

                }
                catch (Exception ex)
                {
                    lblRecords.Text = "Error!";
                }
            }

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
