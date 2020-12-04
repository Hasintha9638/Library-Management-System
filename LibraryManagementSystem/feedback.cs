using LibraryManagementSystem.datagathering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public partial class feedback : Form
    {
        sql cd = new sql();
        public feedback()
        {
            InitializeComponent();
        }
        public void visibleButton()
        {
            btnDelete.Visible = true;
        }
        private void feedback_Load(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM feedback";
            tableFeedback.DataSource = cd.select(sql);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM feedback where student_registration_no LIKE '%" + txtSearch.Text + "%' OR student_name LIKE '%" + txtSearch.Text + "%' ";
            tableFeedback.DataSource = cd.select(sql);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM feedback where date LIKE '%" + dateTimePicker1.Value.Date.ToString("MM/dd/yyyy") + "%' ";
            tableFeedback.DataSource = cd.select(sql);
        }
        int row = -1;
        string deletekey="" ;


        private void tableFeedback_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            row = e.RowIndex;
            deletekey = tableFeedback.Rows[row].Cells[4].Value.ToString();
          
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (row > -1)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to permanently delete this?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    string sql = "DELETE  FROM feedback where message='" + deletekey + "' ";
                    cd.update(sql);
                    string sql2 = "SELECT * FROM feedback";
                    tableFeedback.DataSource = cd.select(sql2);
                    row = -1;
                }
            }
        }
    }
}
