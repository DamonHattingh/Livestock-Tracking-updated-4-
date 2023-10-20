using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Threading;
using System.Reflection.Emit;

namespace Livestock_Tracking
{
    public partial class Login : Form
    {
        private Dictionary<string, string> userCredentials;
        
        // Method for user credentials.
        public Login()
        {
            InitializeComponent();
            userCredentials = new Dictionary<string, string>
            {
                {"admin", "pass" },
                // { "name", "password" }
                // Add more users if needed. 
            };
        }

        // Event to log in to the main tracking form, after user credentials are verified.
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;


            if (userCredentials.ContainsKey(username))
            {
                panel5.Visible = false;

                if (userCredentials.ContainsValue(password))
                {
                    this.Hide();

                    TrackingData dataForm = new TrackingData();
                    dataForm.Show();
                }

                else
                {
                    panel6.Visible = true;
                    return;
                }
            }

            else
            {
                panel5.Visible = true;
                return;
            }

            if (string.IsNullOrEmpty(username) && string.IsNullOrEmpty(password))
            {
                panel6.Visible = true;
                panel5.Visible = true;
            }

        }


        // Events for formatting of textboxes when user is interactive with the form.
        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtUsername.ForeColor = Color.Black;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtPassword.ForeColor = Color.Black;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }

        private void txtUsername_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
        }

        private void txtPassword_Click(object sender, EventArgs e)
        {
            txtPassword.Clear();
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '*';
        }


        // Event for minimizing the form.
        private void btnMinimise_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        // Event for closing the form.
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}



