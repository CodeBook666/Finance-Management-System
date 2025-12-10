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
    public partial class dashboard : Form
    {
        public dashboard()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            reports reportsForm = new reports();
            reportsForm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            syncData syncDataForm = new syncData();
            syncDataForm.Show();
            this.Hide();
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

        private void panel2_MouseClick(object sender, MouseEventArgs e)
        {
            budget budgetForm = new budget();
            budgetForm.Show();
            this.Hide();
        }

        private void panel3_MouseClick(object sender, MouseEventArgs e)
        {
            savingGoals savingGoalsForm = new savingGoals();
            savingGoalsForm.Show();
            this.Hide();
        }

        private void panel4_MouseClick(object sender, MouseEventArgs e)
        {
            expenses expensesForm = new expenses();
            expensesForm.Show();
            this.Hide();
        }
    }
}
