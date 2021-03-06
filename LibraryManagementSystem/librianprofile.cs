﻿using LibraryManagementSystem.datagathering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
   
    public partial class librianprofile : Form
    {
        sql cd = new sql();
        string gender = "";
        static string myconstring = ConfigurationManager.ConnectionStrings["LibraryManagementSystem.Properties.Settings.libraryMangementConnectionString"].ConnectionString;
        OleDbConnection conn = new OleDbConnection(myconstring);
        public librianprofile()
        {
            InitializeComponent();
        }

        public void dataparse(string key)
        {
          

            string sql = "SELECT * FROM librarian  WHERE librarian_id='" + key + "'";
            try
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    txtRegNo.Text = reader["librarian_id"].ToString();
                    txtName.Text = reader["full_name"].ToString();
                    txtAddress.Text = reader["address"].ToString();
                    txtContactNo.Text = reader["contact_no"].ToString();
                    txtEmail.Text = reader["email"].ToString();
                    txtPassword.Text= reader["password0"].ToString();
                    string gen = reader["gender"].ToString();
                    if (gen == "Male")
                    {
                        radioMale.Checked = true;
                    }
                    else
                    {
                        radioFemale.Checked = true;
                    }

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }


        private void button8_Click(object sender, EventArgs e)
        {
            string sql = "UPDATE librarian SET full_name='" + txtName.Text + "',gender='" + gender + "',address='" + txtAddress.Text + "',email='" + txtEmail.Text + "',contact_no='" + txtContactNo.Text + "',password0='"+txtPassword.Text+"' WHERE librarian_id='" + txtRegNo.Text + "'";
            bool isSuccess = cd.update(sql);
            if (isSuccess == true)
            {
                MessageBox.Show("Librarian details Updated is successfully!", "Librarian Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Faild! Occure something wrong Try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            txtAddress.Text = "";
            txtContactNo.Text = "";
            txtName.Text = "";
            txtPassword.Text = "";
            txtRegNo.Text = "";
            radioFemale.Checked = false;
            radioMale.Checked = false;
            txtEmail.Text = "";
        }

        private void radioMale_CheckedChanged(object sender, EventArgs e)
        {
            gender = "Male";
        }

        private void radioFemale_CheckedChanged(object sender, EventArgs e)
        {
            gender = "Female";
        }

        private void checkBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowPassword.Checked == true)
            {
                txtPassword.UseSystemPasswordChar = false;

            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }
    }
}
