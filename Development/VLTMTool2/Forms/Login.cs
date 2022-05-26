using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VLTMTool.Forms
{
    public partial class Login : Form
    {
        #region Property
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public string user { get; set; }
        #endregion

        #region Constructor
        public Login()
        {
            InitializeComponent();
        }
        #endregion

        #region Events
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtUser.Text) || string.IsNullOrEmpty(txtPassword.Text))
                {
                    lblMessageError.Text = "LoginIncorrect";
                    return;
                }

                ViewModel.Authentication authentication = new ViewModel.Authentication(txtUser.Text, txtPassword.Text);

                if (authentication.IsAuthenticated)
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    lblMessageError.Text = authentication.Summary;
                    log.Error(authentication.Summary, authentication.Exception);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error"); //TODO Incluir el error en la clase de errores
                log.Error(ex.Message, ex);
            }


        }

        #endregion

        private void c1PictureBox4_MouseUp(object sender, MouseEventArgs e)
        {
            char c = (char)0x2022;
            txtPassword.PasswordChar = c;
            txtPassword.UseSystemPasswordChar = true;
        }

        private void c1PictureBox4_MouseDown(object sender, MouseEventArgs e)
        {
            txtPassword.PasswordChar = char.MinValue;
            txtPassword.UseSystemPasswordChar = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtUser_KeyUp(object sender, KeyEventArgs e)
        {
            if (CapsLockIndicator())
            {
                lblMessage.Text = "Error";
                pctWarning.Visible = true;
            }
            else
            {
                lblMessage.Text = string.Empty;
                pctWarning.Visible = false;
            }

            if (e.KeyValue == (int)Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
            else
            {
                if (e.KeyValue != (int)Keys.CapsLock)
                    lblMessageError.Text = string.Empty;
            }
        }

        private void Login_KeyUp(object sender, KeyEventArgs e)
        {
            if (CapsLockIndicator())
            {
                lblMessage.Text = "Error";
                pctWarning.Visible = true;
            }
            else
            {
                lblMessage.Text = string.Empty;
                pctWarning.Visible = false;
            }

            if (e.KeyValue == (int)Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
            else
            {
                if (e.KeyValue != (int)Keys.CapsLock)
                    lblMessageError.Text = string.Empty;
            }
        }



        private void txtPassword_KeyUp(object sender, KeyEventArgs e)
    {
            if (CapsLockIndicator())
            {
                lblMessage.Text = "Error";
                pctWarning.Visible = true;
            }
            else
            {
                lblMessage.Text = string.Empty;
                pctWarning.Visible = false;
            }

            if (e.KeyValue == (int)Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
            else
            {
                if (e.KeyValue != (int)Keys.CapsLock)
                    lblMessageError.Text = string.Empty;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtPassword.Text = String.Empty;
            txtUser.Text = String.Empty;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)panelUser.Controls["txtUser"];
            textBox.Select();
        }

        private void btnLogin_KeyUp(object sender, KeyEventArgs e)
        {
            if (CapsLockIndicator())
            {
                lblMessage.Text = "Error";
                pctWarning.Visible = true;
            }
            else
            {
                lblMessage.Text = string.Empty;
                pctWarning.Visible = false;
            }
        }

        private void btnClear_KeyUp(object sender, KeyEventArgs e)
        {
            if (CapsLockIndicator())
            {
                lblMessage.Text = "Error";
                pctWarning.Visible = true;
            }
            else
            {
                lblMessage.Text = string.Empty;
                pctWarning.Visible = false;
            }
        }
        public static bool CapsLockIndicator()
        {
            if (Control.IsKeyLocked(Keys.CapsLock))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
