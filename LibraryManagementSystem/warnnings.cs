using LibraryManagementSystem.datagathering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public partial class warnnings : Form
    {
        sql cd = new sql();
        public warnnings()
        {
            InitializeComponent();
        }

        private void warnnings_Load(object sender, EventArgs e)
        {
            
            string sql = "SELECT * FROM issuebook where closing_date<= Date()+2 ";
            tableWarnings.DataSource = cd.select(sql);
          
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM issuebook where closing_date<= Date()+2 AND (acc_no Like '%"+txtSearch.Text+"%' OR book_name LIKE '%"+txtSearch.Text+ "%' OR student_reg LIKE '%" + txtSearch.Text + "%')";
            tableWarnings.DataSource = cd.select(sql);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM issuebook where closing_date<= Date()+2 AND closing_date Like '%" + txtSearch.Text + "%' ";
            tableWarnings.DataSource = cd.select(sql);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (row>-1)
            {
                try
                {

                    MailMessage msg = new MailMessage();
                    msg.From = new MailAddress("hasinthaeanaweera07@gmail.com");
                    msg.To.Add(email);
                    msg.Subject = "Library mangement system";
                    msg.Body = "Dear student," + name + " \nThis is to inform about returning books\n"
                    + "You have borrowed a book 2 weeks ago.your deadline was expired."
                    + "There is only 2 days for you.please handover it quickly.Otherwise you have to pay according to library rules\n"
                    + "";

                    SmtpClient smt = new SmtpClient();
                    smt.Host = "smtp.gmail.com";
                    System.Net.NetworkCredential ntcd = new NetworkCredential();
                    ntcd.UserName = "hasinthaeanaweera07@gmail.com";
                    ntcd.Password = "hasimahipdv38";
                    smt.Credentials = ntcd;
                    smt.EnableSsl = true;
                    smt.Port = 587;
                    smt.Send(msg);

                    MessageBox.Show("Your Mail is sended");

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            
        }
        int row = -1;
        string email = "";
        string name = "";
        private void tableWarnings_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            row = e.RowIndex;
            email = tableWarnings.Rows[row].Cells[7].Value.ToString();
            name = tableWarnings.Rows[row].Cells[4].Value.ToString();
        }
    }
}
