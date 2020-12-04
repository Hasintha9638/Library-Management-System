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
    
    public partial class viewissuebook : Form
    {
        sql cd = new sql();
        public viewissuebook()
        {
            InitializeComponent();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM issuebook where acc_no LIKE '%" + txtSearch.Text + "%' OR book_name LIKE '%" + txtSearch.Text + "%' OR student_reg  LIKE '%" + txtSearch.Text + "%' ";
            tableIssueBooks.DataSource = cd.select(sql);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
          
            string sql = "SELECT * FROM issuebook where issue_date LIKE '%"+DateTime.Now.Date.ToString("MM/dd/yyyy") +"%' ";
            tableIssueBooks.DataSource = cd.select(sql);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            radioToday.Checked = false;
            string sql = "SELECT * FROM issuebook where issue_date LIKE '%" + dateTimePicker1.Value.Date.ToString("MM/dd/yyyy") + "%' ";
            tableIssueBooks.DataSource = cd.select(sql);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM issuebook where issue_date LIKE '%" + dateTimePicker1.Value.Date.ToString("MM/dd/yyyy") + "%' ";
            tableIssueBooks.DataSource = cd.select(sql);
        }

        private void viewissuebook_Load(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM issuebook";
            tableIssueBooks.DataSource = cd.select(sql);
        }
    }
}
