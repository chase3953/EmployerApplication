using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessObjects;

namespace EmployerApplication
{
    public partial class Form1 : Form
    {
        EmployeeList el;
        public Form1()
        {
            InitializeComponent();
        }        
        private void Form1_Load(object sender, EventArgs e)
        {
            dgvEmployee.AutoGenerateColumns = false;
            el = new EmployeeList();
            el.Savable += El_Savable;
            el = el.GetAll();
            dgvEmployee.DataSource = el.List;
            mnuSave.Enabled = false;
        }

        private void El_Savable(SavableEventArgs e)
        {
            this.mnuSave.Enabled = e.Savable;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void mnuSave_Click(object sender, EventArgs e)
        {
            el.Save();        
            mnuSave.Enabled = false;
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
