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
    public partial class viewstudents : Form
    {
        sql cd = new sql();
        public viewstudents()
        {
            InitializeComponent();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM student where registration_no LIKE '%" + txtSearch.Text + "%' OR name LIKE '%" + txtSearch.Text + "%' OR department LIKE '%" + txtSearch.Text + "%' ";
            tableStudents.DataSource = cd.select(sql);
        }

        private void viewstudents_Load(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM student";
            tableStudents.DataSource = cd.select(sql);
        }
    }
}
