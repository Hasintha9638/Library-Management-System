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
    public partial class selectLogin : Form
    {
        sql cs = new sql();
        public selectLogin()
        {
            InitializeComponent();
        }

        private void selectLogin_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtPassword.Text = "";
            txtUsername.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            String sql = "";
            if (comboBox1.Text=="Admin")
            {
                
                sql = "SELECT * FROM admin WHERE username='" + txtUsername.Text + "' AND password0='" + txtPassword.Text + "'";
                bool isSuccess = cs.Login(sql);
                if (isSuccess)
                {
                    adminform x = new adminform();
                    x.Show();
                    x.dataParse(txtUsername.Text);
                    this.Dispose();
                  
                }
                else
                {
                    MessageBox.Show("Faild! Username or Password wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (comboBox1.Text=="Librarian")
            {
                
                sql = "SELECT * FROM librarian WHERE librarian_id='" + txtUsername.Text + "' AND password0='" + txtPassword.Text + "'";
                bool isSuccess = cs.Login(sql);
                if (isSuccess)
                {
                    Librarian x = new Librarian();
                    x.dataParse(txtUsername.Text);
                    this.Dispose();
                    x.Show();
                }else
                {
                    MessageBox.Show("Faild! Username or Password wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                  sql = "SELECT * FROM student WHERE registration_no='" + txtUsername.Text + "' AND password0='" + txtPassword.Text + "'";
                bool isSuccess = cs.Login(sql);
                if (isSuccess)
                {
                    students x = new students();
                  x.dataParse(txtUsername.Text);
                    this.Dispose();
                    x.Show();
                }else
                {
                    MessageBox.Show("Faild! Username or Password wrong", "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }

           
           
        }
    }
}
