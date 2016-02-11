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

namespace CSharp_MySQL_CRUD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string connectionString = "host=192.168.0.91; database=c#1; user=test1; password=test1";
        private void Form1_Load(object sender, EventArgs e)
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = "SELECT VERSION()";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    string version = Convert.ToString(cmd.ExecuteScalar());
                    lblDBStatusValue.Text = "Connection Established! - " + "MySQL Version: " + version;

                }
                catch (Exception ex)
                {
                    lblDBStatusValue.Text = "Connection Error!\n" + ex.Message;
                }
            }
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = "SELECT COUNT(*) FROM student";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    string records = Convert.ToString(cmd.ExecuteScalar());
                    lblRecords.Text = records;

                }
                catch (Exception ex)
                {
                    lblRecords.Text = "Connection Error!";
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
