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
    public partial class budget : Form
    {
        public budget()
        {
            InitializeComponent();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            dashboard dashboardForm = new dashboard();
            dashboardForm.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            dashboard dashboardForm = new dashboard();
            dashboardForm.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            reports reportsForm = new reports();
            reportsForm.Show();
            this.Hide();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            reports reportsForm = new reports();
            reportsForm.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            syncData syncDataForm = new syncData();
            syncDataForm.Show();
            this.Hide();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            syncData syncDataForm = new syncData();
            syncDataForm.Show();
            this.Hide();
        }
        string connectionString = "User Id=system;Password=kenuli;Data Source=localhost:1521/xe;";

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                using (OracleConnection con = new OracleConnection(connectionString))
                {
                    con.Open();
                    string query = "INSERT INTO BUDGET (USER_ID, CATEGORY_ID, ALLOCATED_AMOUNT, START_DATE, END_DATE) " +
                                   "VALUES (:USER_ID, :CATEGORY_ID, :AMOUNT, :START_DATE, :END_DATE)";

                    OracleCommand cmd = new OracleCommand(query, con);
                    cmd.Parameters.Add(":USER_ID", textBox1.Text);
                    cmd.Parameters.Add(":CATEGORY_ID", textBox2.Text);
                    cmd.Parameters.Add(":AMOUNT", textBox3.Text);
                    cmd.Parameters.Add(":START_DATE", dateTimePicker1.Value);
                    cmd.Parameters.Add(":END_DATE", dateTimePicker2.Value);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Inserted successfully");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = "UPDATE Budget SET Category_ID = :Category_ID, Start_Date = :Start_Date, End_Date = :End_Date, Allocated_Amount = :Allocated_Amount WHERE User_ID = :User_ID";

                    OracleCommand cmd = new OracleCommand(query, conn);
                    cmd.Parameters.Add(":Category_ID", OracleDbType.Decimal).Value = Convert.ToDecimal(textBox2.Text);
                    cmd.Parameters.Add(":Start_Date", OracleDbType.Date).Value = dateTimePicker1.Value;
                    cmd.Parameters.Add(":End_Date", OracleDbType.Date).Value = dateTimePicker2.Value;
                    cmd.Parameters.Add(":Allocated_Amount", OracleDbType.Decimal).Value = Convert.ToDecimal(textBox3.Text);
                    cmd.Parameters.Add(":User_ID", OracleDbType.Decimal).Value = Convert.ToDecimal(textBox1.Text);

                    int rowsUpdated = cmd.ExecuteNonQuery();

                    if (rowsUpdated > 0)
                        MessageBox.Show("Record updated successfully!");
                    else
                        MessageBox.Show("No record found with the given User ID.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = "DELETE FROM Budget WHERE User_ID = :User_ID";

                    OracleCommand cmd = new OracleCommand(query, conn);
                    cmd.Parameters.Add(":User_ID", OracleDbType.Varchar2).Value = textBox1.Text;

                    int rowsDeleted = cmd.ExecuteNonQuery();

                    if (rowsDeleted > 0)
                        MessageBox.Show("Record deleted successfully!");
                    else
                        MessageBox.Show("No record found with the given User ID.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

        }
    }
}
