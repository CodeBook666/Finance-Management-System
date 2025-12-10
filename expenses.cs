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
    public partial class expenses : Form
    {
        public expenses()
        {
            InitializeComponent();
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

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            syncData syncDataForm = new syncData();
            syncDataForm.Show();
            this.Hide();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            dashboard dashboardForm = new dashboard();
            dashboardForm.Show();
            this.Hide();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            reports reportsForm = new reports();
            reportsForm.Show();
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
                    string query = "INSERT INTO Expense (CATEGORY_ID, AMOUNT, EXPENSE_DATE, DESCRIPTION, USER_ID) " +
                                   "VALUES (:CATEGORY_ID, :AMOUNT, :EXPENSE_DATE, :DESCRIPTION, :USER_ID)";

                    OracleCommand cmd = new OracleCommand(query, con);
                    cmd.Parameters.Add(":CATEGORY_ID", textBox1.Text);
                    cmd.Parameters.Add(":AMOUNT", textBox2.Text);
                    cmd.Parameters.Add(":EXPENSE_DATE", dateTimePicker1.Value);
                    cmd.Parameters.Add(":DESCRIPTION", textBox3.Text);
                    cmd.Parameters.Add(":USER_ID", textBox4.Text);

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

                    string query = "UPDATE Expense SET CATEGORY_ID = :CATEGORY_ID, AMOUNT = :AMOUNT, EXPENSE_DATE = :EXPENSE_DATE, DESCRIPTION = :DESCRIPTION WHERE User_ID = :User_ID";

                    OracleCommand cmd = new OracleCommand(query, conn);
                    cmd.Parameters.Add(":CATEGORY_ID", OracleDbType.Decimal).Value = Convert.ToDecimal(textBox1.Text);
                    cmd.Parameters.Add(":AMOUNT", OracleDbType.Decimal).Value = Convert.ToDecimal(textBox2.Text);
                    cmd.Parameters.Add(":EXPENSE_DATE", OracleDbType.Date).Value = dateTimePicker1.Value;
                    cmd.Parameters.Add(":DESCRIPTION", OracleDbType.Varchar2).Value = textBox3.Text;
                    cmd.Parameters.Add(":USER_ID", OracleDbType.Decimal).Value = Convert.ToDecimal(textBox4.Text);

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

                    string query = "DELETE FROM Expense WHERE USER_ID = :USER_ID";

                    OracleCommand cmd = new OracleCommand(query, conn);
                    cmd.Parameters.Add(":USER_ID", OracleDbType.Varchar2).Value = textBox4.Text;

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
