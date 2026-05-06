using System;
using System.Drawing;
using System.Windows.Forms;

namespace MyClinic_1._0.src.features.login
{
    public partial class LoginView : UserControl
    {
        private Label lblUser;
        private Label lblPassword;
        private TextBox txtUser;
        private TextBox txtPassword;
        private Button btnLogin;
        private LinkLabel lnkForgot;

        public event Action<string, string> LoginRequested;

        public LoginView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();

            this.Size = new Size(380, 220);
            this.BackColor = Color.White;

            lblUser = new Label { Text = "Utilisateur", Location = new Point(30, 30), AutoSize = true };
            txtUser = new TextBox { Location = new Point(30, 55), Width = 320, Name = "txtUser" };

            lblPassword = new Label { Text = "Mot de passe", Location = new Point(30, 95), AutoSize = true };
            txtPassword = new TextBox { Location = new Point(30, 120), Width = 320, Name = "txtPassword", UseSystemPasswordChar = true };

            btnLogin = new Button { Text = "Se connecter", Location = new Point(30, 160), Width = 320, BackColor = Color.FromArgb(33, 150, 243), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            btnLogin.Click += BtnLogin_Click;

            lnkForgot = new LinkLabel { Text = "Mot de passe oublié ?", Location = new Point(30, 190), AutoSize = true };
            lnkForgot.Click += (s, e) => MessageBox.Show("Fonctionnalité à implémenter.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Controls.Add(lblUser);
            this.Controls.Add(txtUser);
            this.Controls.Add(lblPassword);
            this.Controls.Add(txtPassword);
            this.Controls.Add(btnLogin);
            this.Controls.Add(lnkForgot);

            this.ResumeLayout();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            LoginRequested?.Invoke(txtUser.Text.Trim(), txtPassword.Text);
        }
    }
}