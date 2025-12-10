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
    public partial class savingGoals : Form
    {
        public savingGoals()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            dashboard dashboardForm = new dashboard();
            dashboardForm.Show();
            this.Hide();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            dashboard dashboardForm = new dashboard();
            dashboardForm.Show();
            this.Hide();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            syncData syncDataForm = new syncData();
            syncDataForm.Show();
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

        private void label12_Click(object sender, EventArgs e)
        {
            reports reportsForm = new reports();
            reportsForm.Show();
            this.Hide();
        }
        string connString = "User Id=system;Password=kenuli;Data Source=localhost:1521/xe;";
     
        private void button1_Click(object sender, EventArgs e)
        {
            using (OracleConnection conn = new OracleConnection(connString))
            {
                try
                {
                    conn.Open();

                    string query = "INSERT INTO SAVINGGOAL (TARGET_AMOUNT, CURRENT_AMOUNT, DEADLINE, USER_ID, CATEGORY_ID) " +
                                   "VALUES (:target_amount, :current_amount, :deadline, :user_id, :category_id)";

                    OracleCommand cmd = new OracleCommand(query, conn);
                    cmd.Parameters.Add(":target_amount", textBox3.Text);
                    cmd.Parameters.Add(":current_amount", textBox4.Text);
                    cmd.Parameters.Add(":deadline", dateTimePicker1.Value);
                    cmd.Parameters.Add(":category_id", textBox2.Text);
                    cmd.Parameters.Add(":user_id", textBox1.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record inserted successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error inserting record: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (OracleConnection con = new OracleConnection(connString))
            {
                try
                {
                    con.Open();

                    string query = "UPDATE SAVINGGOAL SET TARGET_AMOUNT = :target_amount, CURRENT_AMOUNT = :current_amount, " +
                                   "DEADLINE = :deadline, CATEGORY_ID = :category_id WHERE USER_ID = :user_id";

                    OracleCommand cmd = new OracleCommand(query, con);
                    cmd.Parameters.Add(":target_amount", textBox3.Text);
                    cmd.Parameters.Add(":current_amount", textBox4.Text);
                    cmd.Parameters.Add(":deadline", dateTimePicker1.Value);
                    cmd.Parameters.Add(":category_id", textBox2.Text);
                    cmd.Parameters.Add(":user_id", textBox1.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record updated successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating record: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (OracleConnection con = new OracleConnection(connString))
            {
                try
                {
                    con.Open();
                    string findSql = "SELECT USER_ID FROM SAVINGGOAL WHERE USER_ID = :user_id";

                    using (OracleCommand findCmd = new OracleCommand(findSql, con))
                    {
                        findCmd.Parameters.Add(":user_id", OracleDbType.Decimal).Value = Convert.ToDecimal(textBox1.Text);

                        object idObj = findCmd.ExecuteScalar();
                        if (idObj == null)
                        {
                            MessageBox.Show("No record found for the entered User ID.");
                            return;
                        }

                        string delSql = "DELETE FROM SAVINGGOAL WHERE USER_ID = :user_id";
                        using (OracleCommand delCmd = new OracleCommand(delSql, con))
                        {
                            delCmd.Parameters.Add(":user_id", OracleDbType.Decimal).Value = Convert.ToDecimal(textBox1.Text);

                            int rows = delCmd.ExecuteNonQuery();
                            if (rows > 0)
                                MessageBox.Show("Saving goal deleted successfully");
                            else
                                MessageBox.Show("Delete failed — no rows affected.");
                        }
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Please enter a valid numeric User ID.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting record: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }
    }
}
