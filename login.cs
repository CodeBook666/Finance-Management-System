using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace DM2_coursework
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();

            try
            {
                string connString = "User Id=system;Password=kenuli;Data Source=localhost:1521/xe;";

                using (OracleConnection conn = new OracleConnection(connString))
                {
                    conn.Open();

                    string query = "SELECT * FROM ACCOUNTS WHERE USER_NAME = :USER_NAME AND USER_PASSWORD_HASH = :USER_PASSWORD_HASH";

                    using (OracleCommand cmd = new OracleCommand(query, conn))
                    {
                        cmd.Parameters.Add(new OracleParameter("USER_NAME", username));
                        cmd.Parameters.Add(new OracleParameter("USER_PASSWORD_HASH", password));

                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                MessageBox.Show("Login Successful!");
                                dashboard dashboard = new dashboard();
                                dashboard.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Invalid username or password!");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Error: " + ex.Message);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            registration registrationForm = new registration(); 
            registrationForm.Show();
            this.Hide();
        }
    }
}
