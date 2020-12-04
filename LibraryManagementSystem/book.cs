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
    public partial class book : Form
    {
        sql cd = new sql();
        public book()
        {
            InitializeComponent();
        }

        private void radioAll_CheckedChanged(object sender, EventArgs e)
        {
            
            
        }

        private void book_Load(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM book";
            tableBooks.DataSource = cd.select(sql);

        }

        private void radioIssueBook_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM book where acc_no LIKE '%"+txtSearch.Text+"%' OR book_name LIKE '%"+txtSearch.Text+"%' OR type LIKE '%"+txtSearch.Text+"%' ";
            tableBooks.DataSource = cd.select(sql);
        }
    }
}
