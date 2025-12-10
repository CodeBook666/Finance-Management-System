using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DM2_coursework
{
    public partial class syncData : Form
    {
        public syncData()
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

        private void button1_Click(object sender, EventArgs e)
        {
            string oracleConnStr = "User Id=system;Password=kenuli;Data Source=localhost:1521/XE;";
            string sqliteConnStr = "Data Source=C:\\sqlite3\\coursework.db;";

            using (var oracleCon = new OracleConnection(oracleConnStr))
            using (var sqliteCon = new SQLiteConnection(sqliteConnStr))
            {
                oracleCon.Open();
                sqliteCon.Open();

                using (var transaction = sqliteCon.BeginTransaction())
                {
                    try
                    {        
                        string selectAccounts = "SELECT USER_ID, USER_NAME, USER_EMAIL, USER_PASSWORD_HASH FROM ACCOUNTS";
                        using (var cmd = new OracleCommand(selectAccounts, oracleCon))
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string insertAccounts = @"
                            INSERT OR REPLACE INTO ACCOUNTS (user_id, user_name, user_email, user_password_hash)
                            VALUES (@id, @name, @mail, @hash)";
                                using (var insertCmd = new SQLiteCommand(insertAccounts, sqliteCon))
                                {
                                    insertCmd.Parameters.AddWithValue("@id", reader["USER_ID"]);
                                    insertCmd.Parameters.AddWithValue("@name", reader["USER_NAME"]);
                                    insertCmd.Parameters.AddWithValue("@mail", reader["USER_EMAIL"]);
                                    insertCmd.Parameters.AddWithValue("@hash", reader["USER_PASSWORD_HASH"]);
                                    insertCmd.ExecuteNonQuery();
                                }
                            }
                        }

                        string selectCategory = "SELECT CATEGORY_ID, CATEGORY_NAME FROM CATEGORY";
                        using (var cmd = new OracleCommand(selectCategory, oracleCon))
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string insertCategory = @"
                            INSERT OR REPLACE INTO CATEGORY (category_id, category_name)
                            VALUES (@cid, @cname)";
                                using (var insertCmd = new SQLiteCommand(insertCategory, sqliteCon))
                                {
                                    insertCmd.Parameters.AddWithValue("@cid", reader["CATEGORY_ID"]);
                                    insertCmd.Parameters.AddWithValue("@cname", reader["CATEGORY_NAME"]);
                                    insertCmd.ExecuteNonQuery();
                                }
                            }
                        }
                        string selectGoal = "SELECT GOAL_ID, USER_ID, CATEGORY_ID, TARGET_AMOUNT, CURRENT_AMOUNT, DEADLINE FROM SAVINGGOAL";
                        using (var cmd = new OracleCommand(selectGoal, oracleCon))
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string insertGoal = @"
                            INSERT OR REPLACE INTO SAVINGGOAL (goal_id, user_id, category_id, target_amount, current_amount, deadline)
                            VALUES (@gid, @uid, @cid, @target, @current, @date)";
                                using (var insertCmd = new SQLiteCommand(insertGoal, sqliteCon))
                                {
                                    insertCmd.Parameters.AddWithValue("@gid", reader["GOAL_ID"]);
                                    insertCmd.Parameters.AddWithValue("@uid", reader["USER_ID"]);
                                    insertCmd.Parameters.AddWithValue("@cid", reader["CATEGORY_ID"]);
                                    insertCmd.Parameters.AddWithValue("@target", reader["TARGET_AMOUNT"]);
                                    insertCmd.Parameters.AddWithValue("@current", reader["CURRENT_AMOUNT"]);
                                    insertCmd.Parameters.AddWithValue("@date", reader["DEADLINE"]);
                                    insertCmd.ExecuteNonQuery();
                                }
                            }
                        }
                        string selectBudget = "SELECT BUDGET_ID, CATEGORY_ID, USER_ID, ALLOCATED_AMOUNT, START_DATE, END_DATE FROM BUDGET";
                        using (var cmd = new OracleCommand(selectBudget, oracleCon))
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string insertBudget = @"
                            INSERT OR REPLACE INTO BUDGET (budget_id, category_id, user_id, allocated_amount, start_date, end_date)
                            VALUES (@bid, @cid, @uid, @alloc, @start, @end)";
                                using (var insertCmd = new SQLiteCommand(insertBudget, sqliteCon))
                                {
                                    insertCmd.Parameters.AddWithValue("@bid", reader["BUDGET_ID"]);
                                    insertCmd.Parameters.AddWithValue("@cid", reader["CATEGORY_ID"]);
                                    insertCmd.Parameters.AddWithValue("@uid", reader["USER_ID"]);
                                    insertCmd.Parameters.AddWithValue("@alloc", reader["ALLOCATED_AMOUNT"]);
                                    insertCmd.Parameters.AddWithValue("@start", reader["START_DATE"]);
                                    insertCmd.Parameters.AddWithValue("@end", reader["END_DATE"]);
                                    insertCmd.ExecuteNonQuery();
                                }
                            }
                        }
                        string selectExpense = "SELECT EXPENSE_ID, AMOUNT, EXPENSE_DATE, DESCRIPTION, CATEGORY_ID, USER_ID FROM EXPENSE";
                        using (var cmd = new OracleCommand(selectExpense, oracleCon))
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string insertExpense = @"
                            INSERT OR REPLACE INTO EXPENSE (expense_id, amount, expense_date, description, category_id, user_id)
                            VALUES (@eid, @amount, @date, @desc, @cid, @uid)";
                                using (var insertCmd = new SQLiteCommand(insertExpense, sqliteCon))
                                {
                                    insertCmd.Parameters.AddWithValue("@eid", reader["EXPENSE_ID"]);
                                    insertCmd.Parameters.AddWithValue("@amount", reader["AMOUNT"]);
                                    insertCmd.Parameters.AddWithValue("@date", reader["EXPENSE_DATE"]);
                                    insertCmd.Parameters.AddWithValue("@desc", reader["DESCRIPTION"]);
                                    insertCmd.Parameters.AddWithValue("@cid", reader["CATEGORY_ID"]);
                                    insertCmd.Parameters.AddWithValue("@uid", reader["USER_ID"]);
                                    insertCmd.ExecuteNonQuery();
                                }
                            }
                        }

                        transaction.Commit();
                        MessageBox.Show("All tables synced successfully!");
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Sync failed: " + ex.Message);
                    }
                }
            }
        }
    }
}
