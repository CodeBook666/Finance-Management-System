using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DM2_coursework
{
    public partial class reports : Form
    {
        public reports()
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            budget_report budget_Report = new budget_report();
            budget_Report.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            expense_report expense_Report = new expense_report();
            expense_Report.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            saving_goal_report saving_Goal_Report = new saving_goal_report();
            saving_Goal_Report.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            accounts_report accounts_Report = new accounts_report();
            accounts_Report.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            finance_report finance_Report = new finance_report();
            finance_Report.Show();
            this.Hide();
        }
    }
}
