using LibraryManagementSystem.datagathering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public partial class adminform : Form
    {
        sql cd = new sql();
        string key;
        public adminform()
        {
            InitializeComponent();
        }
        public void dataParse(string key)
        {
            this.key = key;
        }
        private void adminform_Load(object sender, EventArgs e)
        {
            if (cd.lableColor())
            {
                btnWarnings.BackColor = Color.Crimson;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            studentReg x = new studentReg();
            x.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            librarianReg x = new librarianReg();
            x.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            bookReg x = new bookReg();
            x.Show();
        }

        private void btnWarnings_Click(object sender, EventArgs e)
        {
            warnnings x = new warnnings();
            x.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            feedback x = new feedback();
            x.Show();
            x.visibleButton();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            viewissuebook x = new viewissuebook();
            x.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            returnbooks x = new returnbooks();
            x.Show();
            x.visibl();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            users x = new users();
            x.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            adminprofile x = new adminprofile();
            x.Show();
            x.dataparse(key);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            adminprofile x = new adminprofile();
            x.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            txtMessage.Text = "";
            txtSubject.Text = "";
            txtTo.Text = "";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {

                MailMessage msg = new MailMessage();
                msg.From = new MailAddress("hasinthaeanaweera07@gmail.com");
                msg.To.Add(txtTo.Text);
                msg.Subject = txtSubject.Text;
                msg.Body = txtMessage.Text;

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
                txtMessage.Text = "";
                txtSubject.Text = "";
                txtTo.Text = "";

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
